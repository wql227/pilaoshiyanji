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

        public string[] programParams = new string[18] ;
        



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

                    labelX23.Text = "速率mm/min";
                    labelX24.Text = "mm";
                    comboBoxEx8.Text = "位移达到";
                    break;
                case "等速力":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = true;
                    labelX23.Text = "速率kN/s";
                    labelX24.Text = "kN";
                    comboBoxEx8.Text = "力达到";
                    break;
                case "位移保持":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = true;
                    labelX23.Text = "mm";
                    labelX24.Text = "s";
                    comboBoxEx8.Text = "保持时间";
                    break;
                case "力保持":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = true;
                    textBoxX15.Text = "kN";
                    labelX24.Text = "s";
                    comboBoxEx8.Text = "保持时间";
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
            RemoveDataGridView();
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
            string[] tmpStrings = new string[5];
            tmpStrings[0] = comboBoxEx2.Text;
            tmpStrings[1] = comboBoxEx3.Text;

            string[] tmpParams1 = new string[18];
            switch (comboBoxEx3.Text)
            {
                case "等速位移":
                    tmpStrings[2] = string.Format("{3}，速率:{0}mm/min,{1}:{2}mm", textBoxX15.Text, comboBoxEx8.Text, textBoxX16.Text, comboBoxEx3.Text);
                    break;
                case "等速力":
                    break;
                    //case "等速位移":
                    //    break;
            }
            tmpStrings[3] = comboBoxEx5.Text;   //存储跳转到第几步
            tmpStrings[4] = textBoxX4.Text;     //循环多少次
            return tmpStrings;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string[] tmpCmdParams = GetInsertStrings();
            InsertOneSteps(tmpCmdParams);
        }

        public void RemoveDataGridView()
        {
            dataGridViewX1.AllowUserToAddRows = false;
            while (dataGridViewX1.RowCount > 0)
            {
                dataGridViewX1.Rows.RemoveAt(0);
            }
        }

        public void InsertOneSteps(string[] cmdParams)
        {
            //replace&insert
            foreach (DataGridViewRow tmpRow in dataGridViewX1.Rows)
            {
                if (tmpRow.Cells[0].Value.ToString() == cmdParams[0]) {
                    int tmpIndex = tmpRow.Index;
                    dataGridViewX1.Rows.RemoveAt(tmpRow.Index);
                    dataGridViewX1.Rows.Insert(tmpIndex, cmdParams);
                    return;
                }
            }

            //add
            string[] tmpCmdParams = new string[5];
            tmpCmdParams[1] = "等速位移";
            tmpCmdParams[2] = "等速位移,速率:0mm/min,保持时间0s";
            tmpCmdParams[3] = "0";
            tmpCmdParams[4] = "0";
            
            if (dataGridViewX1.Rows.Count > 0)
            {
                for (int i = int.Parse(dataGridViewX1.Rows[dataGridViewX1.Rows.Count-1].Cells[0].Value.ToString()); i < int.Parse(cmdParams[0])-1; i++)
                {
                    tmpCmdParams[0] = (i+1).ToString();
                    dataGridViewX1.Rows.Add(tmpCmdParams);
                    //newRow.HeaderCell.Value = (dataGridViewX1.Rows.Count).ToString();
                }
            }
                dataGridViewX1.Rows.Add(cmdParams);
            

            //for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            //{
            //    Console.WriteLine("glm{0}", dataGridViewX1.Rows[i].Cells[2].Value.ToString());
            //}
        }
    }
}
