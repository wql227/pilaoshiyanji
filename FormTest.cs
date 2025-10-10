using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoPENetConnect
{
    public partial class FormTest : Form
    {
        public string sampleCode {
            set;
            get;
        }
        public string sampleNo
        {
            set;
            get;
        }
        public string sampleShape
        {
            set;
            get;
        }
        public string sampleOperator
        {
            set;
            get;
        }
        public string sampleChecker
        {
            set;
            get;
        }
        public string sampleDependation
        {
            set;
            get;
        }
        public string sampleNotes
        {
            set;
            get;
        }

        public DateTime sampleTime
        {
            set;
            get;
        }

        public string sampleMaxLoad
        {
            set;
            get;
        }
        public bool sampleFinished
        {
            set;
            get;
        }
        public string sampleLogPath
        {
            set;
            get;
        }


        public string sampleReportPath
        {
            set;
            get;
        }

        public string sampleImageName
        {
            set;
            get;
        }

        public FormTest()
        {
            InitializeComponent();
        }


        public void RemoveDataGridView()
        {
            dataGridViewX1.AllowUserToAddRows = false;
            while (dataGridViewX1.RowCount > 0) {
                dataGridViewX1.Rows.RemoveAt(0);
            }
        }

        bool isThereOneRows = true;
        private void buttonX1_Click(object sender, EventArgs e)
        {

            //var grpControls = groupPanel1.Controls;
            //DataGridViewRow newRow;

            //if (isThereOneRows == true)
            //{
            //    newRow = dataGridViewX1.Rows[0];
            //}
            //else
            //{
            //    newRow = new DataGridViewRow();
            //    newRow.CreateCells(dataGridViewX1);
            //}
            //int columnN = dataGridViewX1.ColumnCount;
            //if (grpControls.Count < dataGridViewX1.ColumnCount)
            //{
            //    columnN = grpControls.Count;
            //}
            //int j = 0;
            //for (int i = grpControls.Count - 1; i >= 0; i--)
            //{
            //    if (grpControls[i].Name.Contains("textBox"))
            //    {
            //        newRow.Cells[j].Value = grpControls[i].Text;
            //        j++;
            //    }
            //}
            //if(isThereOneRows == false)
            //    dataGridViewX1.Rows.Add(newRow);


            //newRow.HeaderCell.Value = (dataGridViewX1.Rows.Count).ToString();

            //if (isThereOneRows == true) {

            //    isThereOneRows = false;
            //}
            //for (int i = 0; i < dataGridViewX1.Rows.Count; i++) {
            //    Console.WriteLine(dataGridViewX1.Rows[i].HeaderCell.Value);
            //}


            if(textBoxX1.Text == "")//|| textBoxX2.Text == ""|| textBoxX3.Text == ""|| textBoxX4.Text == ""|| textBoxX5.Text == ""|| textBoxX6.Text == ""|| textBoxX7.Text == "")
            {
                MessageBox.Show("试验编号不能为空，请重新输入！");
                return;
            }


            #region 多行同时插入  
            /*
            var grpControls = groupPanel1.Controls;
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridViewX1);
            //if (dataGridViewX1.Rows.Count != 0&&isThereOneRows) {
            //    isThereOneRows = false;
            //    dataGridViewX1.Rows.RemoveAt(0);
            //}
            int j = 0;
            for (int i = grpControls.Count - 1; i >= 0; i--)
            {
                if (grpControls[i].Name.Contains("textBox"))
                {
                    newRow.Cells[j].Value = grpControls[i].Text;
                    j++;
                }
            }
            //if (isThereOneRows == false)
            dataGridViewX1.Rows.Add(newRow);
            newRow.HeaderCell.Value = (dataGridViewX1.Rows.Count).ToString();
            */
            #endregion 多行同时插入
            #region 只插入一行
            var grpControls = groupPanel1.Controls;
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridViewX1);
            //if (dataGridViewX1.Rows.Count != 0&&isThereOneRows) {
            //    isThereOneRows = false;
            //    dataGridViewX1.Rows.RemoveAt(0);
            //}
            int j = 0;
            for (int i = grpControls.Count - 1; i >= 0; i--)
            {
                if (grpControls[i].Name.Contains("textBox"))
                {
                    newRow.Cells[j].Value = grpControls[i].Text;
                    j++;
                }
            }
            if (dataGridViewX1.RowCount == 0)
            {
                dataGridViewX1.Rows.Add(newRow);
                newRow.HeaderCell.Value = (dataGridViewX1.Rows.Count).ToString();
            }
            else
            {
                dataGridViewX1.Rows.RemoveAt(0);
                dataGridViewX1.Rows.Add(newRow);
                newRow.HeaderCell.Value = (dataGridViewX1.Rows.Count).ToString();
            }

            #endregion 只插入一行



        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            this.sampleFinished = false;
            this.Activate();
        }

        private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void btnX_FrmProtectOption_Cencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnX_FrmProtectOption_OK_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SetTestInfo(dataGridViewX1);
            WriteExpParams();
            this.sampleFinished = false;    //标志此次试验没有完成
            this.Close();
        }

        /// <summary>
        /// 试验参数保存至文件
        /// </summary>
        public void WriteExpParams()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            string strConfigSetion = this.Name;

            //按试验次数记录日志
            strTmp = textBoxX1.Text;
            IniFileHelper.WriteIniString(strConfigSetion, "SampleCode", strTmp);
            strTmp = textBoxX2.Text;
            IniFileHelper.WriteIniString(strConfigSetion, "SampleNo", strTmp);
            strTmp = textBoxX3.Text;
            IniFileHelper.WriteIniString(strConfigSetion, "SampleShape", strTmp);
            strTmp = textBoxX4.Text;
            IniFileHelper.WriteIniString(strConfigSetion, "SampleOperator", strTmp);
            strTmp = textBoxX5.Text;
            IniFileHelper.WriteIniString(strConfigSetion, "SampleChecker", strTmp);
            strTmp = textBoxX6.Text;
            IniFileHelper.WriteIniString(strConfigSetion, "SampleDependation", strTmp);
            strTmp = textBoxX7.Text;
            IniFileHelper.WriteIniString(strConfigSetion, "SampleNote", strTmp);

        }

        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            string strConfigSetion = this.Name;


            IniFileHelper.GetIniString(strConfigSetion, "SampleCode", "-EOF", strTmp, strTmp.Capacity);
            if (strTmp.ToString() != "-EOF")
            {
                textBoxX1.Text = strTmp.ToString();
            }

            IniFileHelper.GetIniString(strConfigSetion, "SampleNo", "-EOF", strTmp, strTmp.Capacity);
            if (strTmp.ToString() != "-EOF")
            {
                textBoxX2.Text = strTmp.ToString();
            }

            IniFileHelper.GetIniString(strConfigSetion, "SampleShape", "-EOF", strTmp, strTmp.Capacity);
            if (strTmp.ToString() != "-EOF")
            {
                textBoxX3.Text = strTmp.ToString();
            }

            IniFileHelper.GetIniString(strConfigSetion, "SampleOperator", "-EOF", strTmp, strTmp.Capacity);
            if (strTmp.ToString() != "-EOF")
            {
                textBoxX4.Text = strTmp.ToString();
            }

            IniFileHelper.GetIniString(strConfigSetion, "SampleChecker", "-EOF", strTmp, strTmp.Capacity);
            if (strTmp.ToString() != "-EOF")
            {
                textBoxX5.Text = strTmp.ToString();
            }

            IniFileHelper.GetIniString(strConfigSetion, "SampleDependation", "-EOF", strTmp, strTmp.Capacity);
            if (strTmp.ToString() != "-EOF")
            {
                textBoxX6.Text = strTmp.ToString();
            }

            IniFileHelper.GetIniString(strConfigSetion, "SampleNote", "-EOF", strTmp, strTmp.Capacity);
            if (strTmp.ToString() != "-EOF")
            {
                textBoxX7.Text = strTmp.ToString();
            }

        }

        private void FormTest_Shown(object sender, EventArgs e)
        {
            LoadIni();
        }
    }
}
