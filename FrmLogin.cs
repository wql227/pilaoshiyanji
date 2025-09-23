using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DevComponents.DotNetBar2;

namespace DoPENetConnect
{
    public partial class FrmLogin : Office2007Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            //Console.WriteLine("login shown");
        }
        
        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Console.WriteLine("login shown");
            }
        }
    }
}
