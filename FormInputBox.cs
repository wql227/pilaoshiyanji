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
    public partial class FormInputBox : Form
    {
        public FormInputBox()
        {
            InitializeComponent();
            Loadini();
            this.StartPosition = FormStartPosition.Manual;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            IniFileHelper.WriteIniString("SoftWareInfo", "Name", textBoxX1.Text);
            this.Close();
        }

        private void Loadini()
        {
            StringBuilder defStr=new StringBuilder(255);
            IniFileHelper.GetIniString("SoftWareInfo", "Name", "0", defStr, defStr.Capacity);

            if ("0" != defStr.ToString()) {
                textBoxX1.Text = defStr.ToString();
            }
        }
    }
}
