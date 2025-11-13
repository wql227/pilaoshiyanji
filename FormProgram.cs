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
            tmpInput.Show();
            //if(tmpInput.)
            //if(tmpInput)
        }
    }
}
