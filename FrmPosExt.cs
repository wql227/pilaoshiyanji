using DevComponents.DotNetBar.Controls;
using Doli.DoPE10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Doli.DoPE10.DoPE;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoPENetConnect
{


    public partial class FrmPosExt : Form
    {
        /// <summary>
        /// 加减系数枚举
        /// </summary>
        public enum AddSubScale
        {
            None = -1,
            Deci,
            One,
            Ten,
        }

        /// <summary>
        /// 
        /// </summary>
        struct PosExtParams
        {
            public DoPE.CTRL MoveCtrl;
            public double SpeedToStart;
            public DoPE.LIMITMODE LimitMode;
            public double LimitVal;
            public DoPE.CTRL DestinationCtrl;
            public double DestinationVal;
            public DESTMODE DestMode;
        }


        PosExtParams tmpParams;
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmPosExt()
        {
            InitializeComponent();

            this.TopMost = true;

            if (cmbX_Dyn_EDC.Items.Count >= 1)
            {
                cmbX_Dyn_EDC.SelectedIndex = 0;
            }
            
            cmbX_Dyn_StartCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

            cmbX_Limit_Mode.DataSource = System.Enum.GetNames(typeof(DoPE.LIMITMODE));

            cmbX_Dyn_MoveCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

            comboBoxEx5.DataSource = System.Enum.GetNames(typeof(DoPE.DESTMODE));


            LoadIni();
        }
        /// <summary>
        /// 根据语言自适应控件位置参数
        /// 由于语言长度不同 因此需要根据语言长度设置控件长度自适应
        /// </summary>
        private void UiAutoSize()
        {

            ///
            tbX_Dyn_StartSpeed.Location = new Point(labelX3.Location.X+labelX3.Width, tbX_Dyn_StartSpeed.Location.Y);
            cmbX_Dyn_EDC.Location=new Point(tbX_Dyn_StartSpeed.Location.X, cmbX_Dyn_EDC.Location.Y);
            cmbX_Dyn_StartCtrl.Location = new Point(tbX_Dyn_StartSpeed.Location.X, cmbX_Dyn_StartCtrl.Location.Y);
            cmbX_Dyn_MoveCtrl.Location = new Point(tbX_Dyn_StartSpeed.Location.X, cmbX_Dyn_MoveCtrl.Location.Y);
            cmbX_Limit_Mode.Location = new Point(tbX_Dyn_StartSpeed.Location.X, cmbX_Limit_Mode.Location.Y);
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
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_Dyn_Send_Click(object sender, EventArgs e)
        {
            if (this.tbX_Dyn_StartSpeed.Text == "" || this.textBoxX1.Text == "" || this.textBoxX2.Text == "")
            {
                MessageBox.Show("输入不能为空，请重新输入！");
                return;
            }
            double tmpDobleNum;

            if (!double.TryParse(this.tbX_Dyn_StartSpeed.Text, out tmpDobleNum) || !double.TryParse(this.textBoxX1.Text, out tmpDobleNum) || !double.TryParse(this.textBoxX2.Text, out tmpDobleNum))
            {
                MessageBox.Show("请输入数字！");
                return;
            }


            MainForm.mainform.currentCmd = cmbX_Dyn_MoveCtrl.SelectedIndex;
            MainForm.mainform.SetCmdSeriesAxisY(cmbX_Dyn_MoveCtrl.SelectedIndex);
            SendCommand();
        }

       

        public void send_FrmPosExts_command(DoPE.CTRL MoveCtrl, double Speed, int LimitMode, double Limit, CTRL DestinationCtrl, double Destination,
            DESTMODE DestMode)
        {           
            MainForm.mainform.MovePosExt(MoveCtrl, Speed, (LIMITMODE)LimitMode == 0 ? LIMITMODE.RELATIVE : LIMITMODE.NOT_ACTIVE, Limit, DestinationCtrl, Destination, DestMode);
        }

        /// <summary>
        /// 发送命令
        /// </summary>
        private void SendCommand()
        {
            if (!MainForm.mainform.bActivated)
            {
                MessageBox.Show("请先激活控制器！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            tmpParams.MoveCtrl = (DoPE.CTRL)cmbX_Dyn_StartCtrl.SelectedIndex;
            tmpParams.SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text);
            tmpParams.LimitMode = (DoPE.LIMITMODE)cmbX_Limit_Mode.SelectedIndex;
            tmpParams.LimitVal = double.Parse(textBoxX1.Text);
            tmpParams.DestinationCtrl = (DoPE.CTRL)cmbX_Dyn_MoveCtrl.SelectedIndex;
            tmpParams.DestinationVal = double.Parse(textBoxX2.Text);
            tmpParams.DestMode = (DESTMODE)comboBoxEx5.SelectedIndex;



            MainForm.mainform.MovePosExt(tmpParams.MoveCtrl, tmpParams.SpeedToStart, tmpParams.LimitMode, tmpParams.LimitVal, tmpParams.DestinationCtrl, tmpParams.DestinationVal, tmpParams.DestMode);

            WriteIni();
        }       


        /// <summary>
        /// 增加和减小偏移量
        /// </summary>
        private double OffsetAddSub(double dOffset, AddSubScale addSubScale, bool isadd )
        {
            double Offset = dOffset;

            if (addSubScale == AddSubScale.Deci)
            {
                if (isadd)
                {
                    Offset += 0.1;
                }
                else
                {
                    Offset += -0.1;
                }
            }
            else if (addSubScale == AddSubScale.One)
            {
                if (isadd)
                {
                    Offset += 1;
                }
                else
                {
                    Offset += -1;
                }
            }
            else if (addSubScale == AddSubScale.Ten)
            {
                if (isadd)
                {
                    Offset += 10;
                }
                else
                {
                    Offset += -10;
                }
            }

            return Offset;
        }


        /// <summary>
        /// 加载配置文件参数
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            IniFileHelper.GetIniString("PosExt", "StartCtrl", "0", strTmp, strTmp.Capacity);
            cmbX_Dyn_StartCtrl.SelectedIndex = int.Parse(strTmp.ToString());
            
            
           
        }


        /// <summary>
        /// 保存配置文件参数
        /// </summary>
        public void WriteIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            strTmp = cmbX_Dyn_StartCtrl.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("PosExt", "StartCtrl", strTmp);

            strTmp = tbX_Dyn_StartSpeed.Text;
            IniFileHelper.WriteIniString("PosExt", "StartSpeed", strTmp);

            strTmp = cmbX_Dyn_StartSpeed_Unit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("PosExt", "StartSpeedUnit", strTmp);

            strTmp = cmbX_Limit_Mode.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("PosExt", "LimitMode", strTmp);

            strTmp = textBoxX1.Text;
            IniFileHelper.WriteIniString("PosExt", "Limit", strTmp);

            strTmp = comboBoxEx2.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("PosExt", "LimitUnit", strTmp);


            strTmp = cmbX_Dyn_MoveCtrl.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("PosExt", "MoveCtrl", strTmp);

            strTmp = textBoxX2.Text;
            IniFileHelper.WriteIniString("PosExt", "Destination", strTmp);

            strTmp = comboBoxEx3.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("PosExt", "DestinationUnit", strTmp);


            strTmp = comboBoxEx5.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("PosExt", "DestMode", strTmp);
        }

        private void cmbX_Dyn_StartCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbX_Dyn_StartCtrl.SelectedValue.ToString())
            {
                case "POS":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "mm/s" };
                        comboBoxEx2.DataSource = new string[] { "mm/s" };
                        break;
                    }
                case "LOAD":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "N/s" };
                        comboBoxEx2.DataSource = new string[] { "N/s" };
                        break;
                    }
                case "EXTENSION":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "mm/s" };
                        comboBoxEx2.DataSource = new string[] { "mm/s" };
                        break;
                    }
                default:
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "Unit/s" };
                        comboBoxEx2.DataSource = new string[] { "Unit/s" };
                        break;
                    }

            }
        }

        private void cmbX_Dyn_MoveCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbX_Dyn_MoveCtrl.SelectedValue.ToString())
            {
                case "POS":
                    {
                        comboBoxEx3.DataSource = new string[] { "mm" };
                        break;
                    }
                case "LOAD":
                    {
                        comboBoxEx3.DataSource = new string[] { "N" };
                        break;
                    }
                case "EXTENSION":
                    {
                        comboBoxEx3.DataSource = new string[] { "mm" };
                        break;
                    }
                default:
                    {
                        comboBoxEx3.DataSource = new string[] { "Unit" };
                        break;
                    }
            }
        }

        private void FrmPosExt_Load(object sender, EventArgs e)
        {
            ReplaceLanguage();
            //UiAutoSize();
        }
    }
}
