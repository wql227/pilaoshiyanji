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
            if (MainForm.mainform.currentMachineType == "0")
                cmbX_Pos_MoveCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));
            else {
                cmbX_Pos_MoveCtrl.DataSource = new string[]{"角度","扭矩" };
            }

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
            if (cmbX_Pos_SpeedUnit.Text == "kN/s"|| cmbX_Pos_SpeedUnit.Text == "kNm/s")
            {
                Pos_SpeedCtrl = double.Parse(tbX_Pos_SpeedCtrl.Text) * 1000 / MainForm.mainform.loadDtaRatio;
            }
            else if (cmbX_Pos_SpeedUnit.Text == "mm/min"|| cmbX_Pos_SpeedUnit.Text == "deg/min")
            {
                //mm/min
                Pos_SpeedCtrl = double.Parse(tbX_Pos_SpeedCtrl.Text) / 60 / MainForm.mainform.posDtaRatio;
            }
            else if(cmbX_Pos_SpeedUnit.Text == "N/s")
            {
                Pos_SpeedCtrl = double.Parse(tbX_Pos_SpeedCtrl.Text) / MainForm.mainform.loadDtaRatio;
            }
            else
                Pos_SpeedCtrl = double.Parse(tbX_Pos_SpeedCtrl.Text)/ MainForm.mainform.posDtaRatio;

            if (cmbX_Pos_DestnationUnit.Text == "kN" || cmbX_Pos_DestnationUnit.Text == "kNm")
            {
                Pos_Destnation = double.Parse(tbX_Pos_Destnation.Text) * 1000 / MainForm.mainform.loadDtaRatio;
            }
            else if (cmbX_Pos_DestnationUnit.Text == "N" )
            {
                Pos_Destnation = double.Parse(tbX_Pos_Destnation.Text) / MainForm.mainform.loadDtaRatio;
            }
            else
            { 
                Pos_Destnation = double.Parse(tbX_Pos_Destnation.Text) / MainForm.mainform.posDtaRatio;
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
            if (MainForm.mainform.currentMachineType == "1" && int.Parse(strTmp.ToString()) > 1){
                cmbX_Pos_MoveCtrl.SelectedIndex = 0;
            }
            else
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
                        cmbX_Pos_SpeedUnit.DataSource = new string[] { "mm/min" };
                        cmbX_Pos_DestnationUnit.DataSource = new string[] { "mm" };
                        break;
                    }
                case "角度":
                    {
                        cmbX_Pos_SpeedUnit.DataSource = new string[] { "deg/min" };
                        cmbX_Pos_DestnationUnit.DataSource = new string[] { "deg" };
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
                case "扭矩":
                    {
                        if (MainForm.mainform.LoadUnit.ToUpper() == "KN")
                        {
                            cmbX_Pos_SpeedUnit.DataSource = new string[] { "kNm/s" };
                            cmbX_Pos_DestnationUnit.DataSource = new string[] { "kNm" };
                        }
                        else
                        {
                            cmbX_Pos_SpeedUnit.DataSource = new string[] { "Nm/s" };
                            cmbX_Pos_DestnationUnit.DataSource = new string[] { "Nm" };
                        }
                        break;
                    }
                case "EXTENSION":
                    {
                        cmbX_Pos_SpeedUnit.DataSource = new string[] { "mm/min" };
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

            SetUnitbySystemType(MainForm.mainform.currentMachineType);
        }


        public void SetUnitbySystemType(string type)
        {
            switch (type)
            {
                case "0":
                    break;
                case "1":
                    //label17.Text = "kNm";
                    //label10.Text = "deg";
                    //label15.Text = "deg/min";
                    //label48.Text = "扭矩";
                    //label49.Text = "角度";
                    //label40.Text = "deg/min";
                    //label4.Text = "deg/min";
                    //lbX_MaxForce.Text = "系统最大试验扭矩";
                    //lbX_MaxTrip.Text = "系统最大试验角度";
                    //label29.Text = "最大角速度";
                    //label33.Text = "角度测量采用";
                    break;
            }
        }
    }
}
