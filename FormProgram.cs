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
    public partial class FormProgram : Form
    {
        public string programName {
            get;
            set;
        }

        public string step_No {
            get;
            set;
        }
        
        public string cmdParameter {
            get;
            set;
        }

        public string cmdString {
            get;
            set;
        }



        public FormProgram()
        {
            InitializeComponent();
        }

        private void btnX_FrmProtectOption_OK_Click(object sender, EventArgs e)
        {
            FormInputBox tmpInput = new FormInputBox();
            tmpInput.Location = new Point(this.Location.X + this.Width / 2, this.Location.Y + 100);
            tmpInput.ShowDialog();
            //if(tmpInput.)
            Console.WriteLine(this.Name);
            if (tmpInput.inputedString != null) {
                programName = tmpInput.inputedString;
                comboBoxEx1.Text = programName;
            }
        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEx3.Text)
            {
                case "等速位移":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = true;
                    break;
                case "波形控制":
                    panelEx_boxing.Visible = true;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = false;
                    break;
                case "延时":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = true;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = false;
                    break;
                default:
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = true;
                    panelEx_dengsuweiyi.Visible = false;
                    break;


            }
        }

        private void FormProgram_Load(object sender, EventArgs e)
        {
            comboBoxEx3.SelectedIndex = 0;
            comboBoxEx2.SelectedIndex = 0;
            comboBoxEx5.SelectedIndex = 1;
        }

        private void btnX_FrmProtectOption_Cencel_Click(object sender, EventArgs e)
        {
            switch (comboBoxEx3.Text)
            {
                case "等速位移":
                    break;
                //case "等速位移":
                //    break;
            }
        }

        public string[] GetInsertStrings() {
            string[] tmpStrings = new string[] { };
            tmpStrings[0] = comboBoxEx2.Text;
            tmpStrings[1] = comboBoxEx3.Text;

            string[] tmpParams1 = new string[] { };
            switch (comboBoxEx3.Text)
            {
                case "等速位移":
                    //tmpParams1
                    break;
                    //case "等速位移":
                    //    break;
            }
            tmpStrings[3] = comboBoxEx5.Text;
            tmpStrings[4] = textBoxX4.Text;
            return tmpStrings;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        //public void InsertOneSteps()
        //{
        //    var grpControls = groupPanel1.Controls;
        //    DataGridViewRow newRow = new DataGridViewRow();
        //    newRow.CreateCells(dataGridViewX1);
        //    //if (dataGridViewX1.Rows.Count != 0&&isThereOneRows) {
        //    //    isThereOneRows = false;
        //    //    dataGridViewX1.Rows.RemoveAt(0);
        //    //}
        //    int j = 0;
        //    for (int i = grpControls.Count - 1; i >= 0; i--)
        //    {
        //        if (grpControls[i].Name.Contains("textBox"))
        //        {
        //            newRow.Cells[j].Value = grpControls[i].Text;
        //            j++;
        //        }
        //    }
        //    if (dataGridViewX1.RowCount == 0)
        //    {
        //        dataGridViewX1.Rows.Add(newRow);
        //        newRow.HeaderCell.Value = (dataGridViewX1.Rows.Count).ToString();
        //    }
        //    else
        //    {
        //        dataGridViewX1.Rows.RemoveAt(0);
        //        dataGridViewX1.Rows.Add(newRow);
        //        newRow.HeaderCell.Value = (dataGridViewX1.Rows.Count).ToString();
        //    }
        //}
    }
}
