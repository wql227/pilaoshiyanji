using DevComponents.DotNetBar.Controls;
using Doli.DoPE10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoPE10Net_CSharpDemo
{
    public partial class FrmPos : Form
    {
        public FrmPos()
        {
            InitializeComponent();

            //MainForm.mainform.

            comboBoxEx2.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

        }


        /// <summary>
        /// 发送Move.Pos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_PosSend_Click(object sender, EventArgs e)
        {
            MainForm.mainform.MovePos(0, double.Parse("50"), double.Parse("-15"));

        }
    }
}
