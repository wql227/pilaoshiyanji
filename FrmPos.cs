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
    public partial class FrmPos : Form
    {
        public FrmPos()
        {
            InitializeComponent();

            //默认选中第一个选项
            if (cmbX_Pos_EDC.Items.Count >= 1)
            {
                cmbX_Pos_EDC.SelectedIndex = 0;
            }

            if (cmbX_Pos_SpeedUnit.Items.Count >= 1)
            {
                cmbX_Pos_SpeedUnit.SelectedIndex = 0;
            }

            if (cmbX_Pos_DestnationUnit.Items.Count >= 1)
            {
                cmbX_Pos_DestnationUnit.SelectedIndex = 0;
            }

            //初始化移动控制选项
            cmbX_Pos_MoveCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

            LoadIni();
        }


        /// <summary>
        /// 发送Move.Pos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_PosSend_Click(object sender, EventArgs e)
        {
            MainForm.mainform.MovePos((DoPE.CTRL)cmbX_Pos_MoveCtrl.SelectedIndex, double.Parse(tbX_Pos_SpeedCtrl.Text), double.Parse(tbX_Pos_Destnation.Text));

            WriteIni();
        }

        /// <summary>
        /// 加载配置文件参数
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            IniFileHelper.GetIniString("POS", "MoveCtrl", "0", strTmp, strTmp.Capacity);
            cmbX_Pos_MoveCtrl.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("POS", "SpeedCtrl", "0", strTmp, strTmp.Capacity);
            tbX_Pos_SpeedCtrl.Text = strTmp.ToString();

            IniFileHelper.GetIniString("POS", "SpeedUnit", "0", strTmp, strTmp.Capacity);
            cmbX_Pos_SpeedUnit.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("POS", "Destnation", "0", strTmp, strTmp.Capacity);
            tbX_Pos_Destnation.Text = strTmp.ToString();

            IniFileHelper.GetIniString("POS", "DestnationUnit", "0", strTmp, strTmp.Capacity);
            cmbX_Pos_DestnationUnit.SelectedIndex = int.Parse(strTmp.ToString());

        }


        /// <summary>
        /// 保存配置文件参数
        /// </summary>
        public void WriteIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            strTmp = cmbX_Pos_MoveCtrl.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("POS", "MoveCtrl", strTmp);

            strTmp = tbX_Pos_SpeedCtrl.Text;
            IniFileHelper.WriteIniString("POS", "SpeedCtrl", strTmp);

            strTmp = cmbX_Pos_SpeedUnit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("POS", "SpeedUnit", strTmp);

            strTmp = tbX_Pos_Destnation.Text;
            IniFileHelper.WriteIniString("POS", "Destnation", strTmp);

            strTmp = cmbX_Pos_DestnationUnit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("POS", "DestnationUnit", strTmp);

        }
    }
}
