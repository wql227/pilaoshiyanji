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
    public partial class FrmPos_A : Form
    {
        public FrmPos_A()
        {
            InitializeComponent();

            //默认选中第一个选项
            if (cmbX_PosA_EDC.Items.Count >= 1)
            {
                cmbX_PosA_EDC.SelectedIndex = 0;
            }

            if (cmbX_PosA_AccUnit.Items.Count >= 1)
            {
                cmbX_PosA_AccUnit.SelectedIndex = 0;
            }

            if (cmbX_PosA_SpeedUnit.Items.Count >= 1)
            {
                cmbX_PosA_SpeedUnit.SelectedIndex = 0;
            }

            if (cmbX_PosA_DecUnit.Items.Count >= 1)
            {
                cmbX_PosA_DecUnit.SelectedIndex = 0;
            }

            if (cmbX_PosA_Destnation.Items.Count >= 1)
            {
                cmbX_PosA_Destnation.SelectedIndex = 0;
            }

            //初始化移动控制选项
            cmbX_PosA_MoveCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_Pos_ASend_Click(object sender, EventArgs e)
        {
            MainForm.mainform.MovePos_A(0, double.Parse(tbX_Pos_AccCtrl.Text), double.Parse(tbX_Pos_SpeedCtrl.Text),
                double.Parse(tbX_Pos_DecCtrl.Text), double.Parse(tbX_Pos_Destnation.Text));

        }
    }
}
