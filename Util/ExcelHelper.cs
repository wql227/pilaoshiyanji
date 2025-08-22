using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoPENetConnect
{
    public class ExcelHelper
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        private static string _fileName = null;

        /// <summary>
        /// 文件流
        /// </summary>
        public static FileStream fs = null;

        /// <summary>
        /// 标题列
        /// </summary>
        public static int headColumnNum;

        public ExcelHelper(string fileName)
        {
            _fileName = fileName;
        }


        /// <summary>
        /// 读取CSV文件
        /// </summary>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public DataTable CSVToDataTable(bool isFirstRowColumn)
        {
            DataTable dataTable = new DataTable();
            string text = "H";
            DataTable dtResult;
            try
            {
                fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fs, Encoding.Default);
                fs.Seek(0L, SeekOrigin.Begin);
                int num = 0;
                while (text != null)
                {
                    text = streamReader.ReadLine();
                    num++;
                    if (text != null)
                    {
                        if (1 == num)
                        {
                            string[] array = text.Split(',');
                            for (int i = 0; i < array.Length; i++)
                            {
                                DataColumn dataColumn = new DataColumn(array[i]);
                                dataTable.Columns.Add(dataColumn);
                            }
                        }
                        else
                        {
                            string[] array2 = text.Split(',');

                            if (array2.Length <= 1)
                            {
                                continue;
                            }

                            DataRow dataRow = dataTable.NewRow();
                            for (int j = 0; j < dataTable.Columns.Count; j++)
                            {
                                dataRow[j] = array2[j];
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                    }
                }

                if (streamReader != null)
                {
                    streamReader.Close();
                }
                dtResult = dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                MessageBox.Show("Exception: " + ex.Message);
                dtResult = null;
            }
            return dtResult;
        }

    }
}
