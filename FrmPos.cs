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

            this.TopMost = true;

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
        /// 语言文件
        /// </summary>
        private void ReplaceLanguage()
        {
            StringBuilder strTmp = new StringBuilder();
            IniFileHelper.GetIniString("Setting", "Language", "0", strTmp, strTmp.Capacity);
            string strLanguage = strTmp.ToString();
            var langData = LanguageLoad.LoadLang(System.IO.Directory.GetCurrentDirectory() + "\\Lang\\" + strLanguage + ".json");

            //循环界面控件替换成指定的语言
            if (langData.TryGetValue(this.Name, out var frmSystemSetting))
            {

                foreach (var kvp in frmSystemSetting)
                {
                    var controlName = kvp.Key;
                    var textValue = kvp.Value;

                    // 首先尝试从主窗体的控件集合中查找控件
                    var ctrl = this.Controls.Find(controlName, true).FirstOrDefault();

                    if (ctrl == null)
                    {
                       
                    }
                    else
                    {
                        ctrl.Text = textValue;
                    }

                }
            }
        }
        /// <summary>
        /// 发送Move.Pos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_PosSend_Click(object sender, EventArgs e)
        {
            if (!MainForm.mainform.bActivated)
            {
                MessageBox.Show("请先激活控制器！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            double Pos_SpeedCtrl = 0.0d;
            double Pos_Destnation = 0.0d;
            if (cmbX_Pos_SpeedUnit.Text == "kN/s")
            {
                Pos_SpeedCtrl = double.Parse(tbX_Pos_SpeedCtrl.Text) * 1000;
            }
            else
            {
                Pos_SpeedCtrl = double.Parse(tbX_Pos_SpeedCtrl.Text);
            }

            if (cmbX_Pos_DestnationUnit.Text == "kN")
            {
                Pos_Destnation = double.Parse(tbX_Pos_Destnation.Text) * 1000;
            }
            else
            {
                Pos_Destnation = double.Parse(tbX_Pos_Destnation.Text);
            }

            MainForm.mainform.MovePos((DoPE.CTRL)cmbX_Pos_MoveCtrl.SelectedIndex, Pos_SpeedCtrl, Pos_Destnation);

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

        private void cmbX_Pos_MoveCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbX_Pos_MoveCtrl.SelectedValue.ToString())
            {
                case "POS":
                    {
                        cmbX_Pos_SpeedUnit.DataSource = new string[] { "mm/s" };
                        cmbX_Pos_DestnationUnit.DataSource = new string[] { "mm" };
                        break;
                    }
                case "LOAD":
                    {
                        if (MainForm.mainform.LoadUnit.ToUpper() == "KN")
                        {
                            cmbX_Pos_SpeedUnit.DataSource = new string[] { "kN/s" };
                            cmbX_Pos_DestnationUnit.DataSource = new string[] { "kN" };
                        }
                        else
                        {
                            cmbX_Pos_SpeedUnit.DataSource = new string[] { "N/s" };
                            cmbX_Pos_DestnationUnit.DataSource = new string[] { "N" };
                        }
                        break;
                    }
                case "EXTENSION":
                    {
                        cmbX_Pos_SpeedUnit.DataSource = new string[] { "mm/s" };
                        cmbX_Pos_DestnationUnit.DataSource = new string[] { "mm" };
                        break;
                    }
                default:
                    {
                        cmbX_Pos_SpeedUnit.DataSource = new string[] { "Unit/s" };
                        cmbX_Pos_DestnationUnit.DataSource = new string[] { "Unit" };
                        break;
                    }

            }
        }

        private void FrmPos_Load(object sender, EventArgs e)
        {
            ReplaceLanguage();
        }
    }
}
