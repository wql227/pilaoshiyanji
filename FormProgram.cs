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
            comboBoxEx3.Text = "1";
        }
    }
}
