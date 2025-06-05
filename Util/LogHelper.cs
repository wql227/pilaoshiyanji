using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DoPENetConnect
{
    public class LogHelper
    {
        //// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input"></param>
        public static void WriteLogFile(string input, bool showmsg = false)
        {
            if (showmsg)
            {
                MessageBox.Show(input, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                string filename = DateTime.Now.ToString("yyyyMMdd") + ".log";
                string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string strLogPath = System.AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
                // 判断文件夹是否存在
                if (!Directory.Exists(strLogPath))
                {
                    // 创建文件夹
                    Directory.CreateDirectory(strLogPath);
                }

                System.IO.FileInfo file = new System.IO.FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + filename); //如果是web程序，这个的变成Http什么的
                System.IO.StreamWriter sw = null;
                if (!file.Exists)
                {
                    sw = file.CreateText();
                    sw.WriteLine(dt + " " + input.ToString());
                }
                else
                {
                    sw = file.AppendText();
                    sw.WriteLine(dt + " " + input.ToString());
                }
                sw.Close();
                sw.Flush();
                sw.Dispose();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }

        }


        /// <summary>
        /// 保存数值
        /// </summary>
        /// <param name="strs">strs为对应的参数字符,值之间用","隔开</param>
        public static void SaveCsvData(string strs)
        {
            //当前是根据日期每天生成一个,所以在记录之前需要判断是否已经存在文件
            string paths = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";
            string filename = paths + DateTime.Now.ToString("yyyy-MM-dd") + ".CSV";
            if (!Directory.Exists(paths))
            {
                Directory.CreateDirectory(paths);
            }
            //string logPath = paths + file + ".csv";
            if (!File.Exists(paths + DateTime.Now.ToString("yyyy-MM-dd") + ".CSV"))
            {
                //判断是否存在，若不存在，则首先添加Hearder
                string ColumnHead = "Time [s],Position [mm],Load [ N],Extension [ Rev],Command [ ],Cycles [ ]";
                FileStream fs1 = new FileStream(filename, FileMode.Create, FileAccess.Write);//创建写入文件
                StreamWriter sw1 = new StreamWriter(fs1, Encoding.Default);
                //"\r\n"回车换行,下一条记录直接换行
                sw1.Write(ColumnHead + "\r\n");
                sw1.Close();
                fs1.Close();
            }

            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);

            sw.Write(strs + "\r\n");
            sw.Close();
            fs.Close();
        }

    }
}
