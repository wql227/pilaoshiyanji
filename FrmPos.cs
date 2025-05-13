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

            //默认选中第一个选项
            if (cmbX_Pos__EDC.Items.Count >= 1)
            {
                cmbX_Pos__EDC.SelectedIndex = 0;
            }

            if (cmbX_Pos_SpeedUnit.Items.Count >= 1)
            {
                cmbX_Pos_SpeedUnit.SelectedIndex = 0;
            }

            if (cmbX_Pos_Destnation.Items.Count >= 1)
            {
                cmbX_Pos_Destnation.SelectedIndex = 0;
            }

            //初始化移动控制选项
            cmbX_Pos_MoveCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

        }


        /// <summary>
        /// 发送Move.Pos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_PosSend_Click(object sender, EventArgs e)
        {
            MainForm.mainform.MovePos(0, double.Parse(tbX_Pos_SpeedCtrl.Text), double.Parse(tbX_Pos_Destnation.Text));

        }
    }
}
