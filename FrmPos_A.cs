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

namespace DoPENetConnect
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

            if (cmbX_PosA_DestnationUnit.Items.Count >= 1)
            {
                cmbX_PosA_DestnationUnit.SelectedIndex = 0;
            }

            //初始化移动控制选项
            cmbX_PosA_MoveCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

            LoadIni();
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

            WriteIni();

        }



        /// <summary>
        /// 加载配置文件参数
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            IniFileHelper.GetIniString("POS_A", "MoveCtrl", "0", strTmp, strTmp.Capacity);
            cmbX_PosA_MoveCtrl.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("POS_A", "AccCtrl", "0", strTmp, strTmp.Capacity);
            tbX_Pos_AccCtrl.Text = strTmp.ToString();

            IniFileHelper.GetIniString("POS_A", "AccUnit", "0", strTmp, strTmp.Capacity);
            cmbX_PosA_AccUnit.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("POS_A", "SpeedCtrl", "0", strTmp, strTmp.Capacity);
            tbX_Pos_SpeedCtrl.Text = strTmp.ToString();

            IniFileHelper.GetIniString("POS_A", "SpeedUnit", "0", strTmp, strTmp.Capacity);
            cmbX_PosA_SpeedUnit.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("POS_A", "DecCtrl", "0", strTmp, strTmp.Capacity);
            tbX_Pos_DecCtrl.Text = strTmp.ToString();

            IniFileHelper.GetIniString("POS_A", "DecUnit", "0", strTmp, strTmp.Capacity);
            cmbX_PosA_DecUnit.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("POS_A", "Destnation", "0", strTmp, strTmp.Capacity);
            tbX_Pos_Destnation.Text = strTmp.ToString();

            IniFileHelper.GetIniString("POS_A", "DestnationUnit", "0", strTmp, strTmp.Capacity);
            cmbX_PosA_DestnationUnit.SelectedIndex = int.Parse(strTmp.ToString()); ;

        }


        /// <summary>
        /// 保存配置文件参数
        /// </summary>
        public void WriteIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            strTmp = cmbX_PosA_MoveCtrl.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("POS_A", "MoveCtrl", strTmp);

            strTmp = tbX_Pos_AccCtrl.Text;
            IniFileHelper.WriteIniString("POS_A", "AccCtrl", strTmp);

            strTmp = cmbX_PosA_AccUnit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("POS_A", "AccUnit", strTmp);

            strTmp = tbX_Pos_SpeedCtrl.Text;
            IniFileHelper.WriteIniString("POS_A", "SpeedCtrl", strTmp);

            strTmp = cmbX_PosA_SpeedUnit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("POS_A", "SpeedUnit", strTmp);

            strTmp = tbX_Pos_DecCtrl.Text;
            IniFileHelper.WriteIniString("POS_A", "DecCtrl", strTmp);

            strTmp = cmbX_PosA_DecUnit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("POS_A", "DecUnit", strTmp);

            strTmp = tbX_Pos_Destnation.Text;
            IniFileHelper.WriteIniString("POS_A", "Destnation", strTmp);

            strTmp = cmbX_PosA_DestnationUnit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("POS_A", "DestnationUnit", strTmp);
       }
    }
}
