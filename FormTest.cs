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
        public string sampleLoad
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
          

        }

        private void FormTest_Load(object sender, EventArgs e)
        {
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
            this.Close();
        }
    }
}
