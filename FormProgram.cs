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
                case "定位移动":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_定位移动.Visible = true;
                    break;
                case "波形控制":
                    panelEx_boxing.Visible = true;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_定位移动.Visible = false;
                    break;
                case "延时":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = true;
                    panelEx_Empty.Visible = false;
                    panelEx_定位移动.Visible = false;
                    break;
                default:
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = true;
                    panelEx_定位移动.Visible = false;
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
                case "定位移动":
                    break;
                //case "定位移动":
                //    break;
            }
        }

        //public void InsertOneSteps(void)
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
