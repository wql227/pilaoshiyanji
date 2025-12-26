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
    public partial class FrmDynCtrl : Form
    {

        int operateFlag = 0;


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
        /// 构造函数
        /// </summary>
        public FrmDynCtrl()
        {
            InitializeComponent();

            this.TopMost = true;

            if (cmbX_Dyn_EDC.Items.Count >= 1)
            {
                cmbX_Dyn_EDC.SelectedIndex = 0;
            }

            cmbX_Dyn_PeakCtrl.Visible = true;
            tbX_Dyn_PeakCtrl.Visible = false;

            if (MainForm.mainform.currentMachineType == "0")
            {
                cmbX_Dyn_StartCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));
            }
            else
            {
                cmbX_Dyn_StartCtrl.DataSource = new string[] { "角度", "扭矩" };
            }

            cmbX_Dyn_WaveFrom.DataSource = System.Enum.GetNames(typeof(DoPE.DYN_WAVEFORM));

            if (MainForm.mainform.currentMachineType == "0")
            {

                cmbX_Dyn_MoveCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));
            }
            else
            {
                cmbX_Dyn_MoveCtrl.DataSource = new string[] { "角度", "扭矩" };
            }

            if (MainForm.mainform.isRunning)
            {
                cbX_DynCtrl_ModifyParam.Checked = true;
            }

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
            cmbX_Dyn_WaveFrom.Location = new Point(tbX_Dyn_StartSpeed.Location.X, cmbX_Dyn_WaveFrom.Location.Y);
            cmbX_Dyn_PeakCtrl.Location = new Point(tbX_Dyn_StartSpeed.Location.X, cmbX_Dyn_PeakCtrl.Location.Y);
            tbX_Dyn_PeakCtrl.Location = new Point(tbX_Dyn_StartSpeed.Location.X, tbX_Dyn_PeakCtrl.Location.Y);
            cbX_Dyn_PeakCtrl.Location = new Point(tbX_Dyn_StartSpeed.Location.X+5+ tbX_Dyn_PeakCtrl.Width, cbX_Dyn_PeakCtrl.Location.Y);
            tbX_Cycles.Location = new Point(tbX_Dyn_StartSpeed.Location.X, tbX_Cycles.Location.Y);
            cbX_Dyn_FadeInOut.Location = new Point(tbX_Dyn_StartSpeed.Location.X+5+ tbX_Cycles.Width, cbX_Dyn_FadeInOut.Location.Y);
            cmbX_Dyn_StartSpeed_Unit.Location = new Point(tbX_Dyn_StartSpeed.Location.X+cmbX_Dyn_StartSpeed_Unit.Width+15, cmbX_Dyn_StartSpeed_Unit.Location.Y);
            cmbX_Dyn_MoveCtrl_Unit.Location = new Point(tbX_Dyn_StartSpeed.Location.X +cmbX_Dyn_MoveCtrl_Unit.Width+ 15, cmbX_Dyn_MoveCtrl_Unit.Location.Y);
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
        private void cbX_PeakCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (cbX_Dyn_PeakCtrl.Checked)
            {
                cmbX_Dyn_PeakCtrl.Visible = false;
                tbX_Dyn_PeakCtrl.Visible = true;
            }
            else
            {
                cmbX_Dyn_PeakCtrl.Visible = true;
                tbX_Dyn_PeakCtrl.Visible = false;
            }
        }


        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_Dyn_Send_Click(object sender, EventArgs e)
        {
            if (MainForm.mainform.isChengkongRunning())
            {
                MessageBox.Show("程控正在运行，请等待程控结束或者手动点击结束按钮后再试！");
                return;
            }

            MainForm.mainform.currentCmd = cmbX_Dyn_MoveCtrl.SelectedIndex;
            MainForm.mainform.SetCmdSeriesAxisY(cmbX_Dyn_MoveCtrl.SelectedIndex);
            SendCommand();
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

            DoPE.DYN_WAVEFORM WaveForm;
            bool Modify;
            DoPE.DYN_PEAKCTRL PeakCtrl;
            DoPE.CTRL MoveCtrl;
            bool RelativeDestination;
            double SpeedToStart=0;
            double Offset=0;
            double Amplitude=0;
            double HaltAtPlusAmplitude;
            double HaltAtMinusAmplitude;
            double Frequency;
            int HalfCycles;
            double SpeedToDestination;
            double Destination;
            DoPE.DYN_SWEEP SweepFrequencyMode;

            WaveForm = (DoPE.DYN_WAVEFORM)cmbX_Dyn_WaveFrom.SelectedIndex;

            if (cbX_Dyn_PeakCtrl.Checked)
            {
                PeakCtrl = (DoPE.DYN_PEAKCTRL)int.Parse(cmbX_Dyn_PeakCtrl.Text);
            }
            else
            {
                PeakCtrl = (DoPE.DYN_PEAKCTRL)int.Parse(tbX_Dyn_PeakCtrl.Text);
            }

            MoveCtrl = (DoPE.CTRL)cmbX_Dyn_MoveCtrl.SelectedIndex;
            if (MainForm.mainform.currentMachineType == "0")    //疲劳
            {
                if (cmbX_Dyn_StartSpeed_Unit.Text.ToUpper() == "KN/S")
                {
                    //力控时转换成千牛
                    SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text) * 1000 / MainForm.mainform.loadDtaRatio;
                }
                else if (cmbX_Dyn_StartSpeed_Unit.Text.ToUpper() == "MM/MIN")
                {
                    //位移控时转换成mm/min
                    SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text) / 60 / MainForm.mainform.posDtaRatio;
                }
                else if (cmbX_Dyn_StartSpeed_Unit.Text.ToUpper() == "N/S")
                {
                    //力控时转换成千牛
                    SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text) / MainForm.mainform.loadDtaRatio;
                }
                else                   //mm/s
                {
                    //力控时转换成千牛
                    SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text) / MainForm.mainform.posDtaRatio;
                }
                

                if (cmbX_Dyn_MoveCtrl_Unit.Text.ToUpper() == "KN")
                {
                    Offset = double.Parse(tbX_Dyn_Offset.Text) * 1000 / MainForm.mainform.loadDtaRatio;
                    Amplitude = double.Parse(tbX_Dyn_Amplitude.Text) * 1000 / MainForm.mainform.loadDtaRatio;
                }
                else if(cmbX_Dyn_MoveCtrl_Unit.Text.ToUpper() == "N")
                {
                    Offset = double.Parse(tbX_Dyn_Offset.Text)/ MainForm.mainform.loadDtaRatio;
                    Amplitude = double.Parse(tbX_Dyn_Amplitude.Text)/ MainForm.mainform.loadDtaRatio;
                }
                else   //mm
                {
                    Offset = double.Parse(tbX_Dyn_Offset.Text) / MainForm.mainform.posDtaRatio;
                    Amplitude = double.Parse(tbX_Dyn_Amplitude.Text) / MainForm.mainform.posDtaRatio;
                }
            }
            else if(MainForm.mainform.currentMachineType == "1")     //扭转
            {
                if (cmbX_Dyn_StartSpeed_Unit.Text.ToUpper() == "KNM/S")
                {
                    //力控时转换成千牛
                    SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text) * 1000 / MainForm.mainform.loadDtaRatio;
                }
                else if (cmbX_Dyn_StartSpeed_Unit.Text.ToUpper() == "NM/S")
                {
                    //力控时转换成千牛
                    SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text) / MainForm.mainform.loadDtaRatio;
                }
                else if (cmbX_Dyn_StartSpeed_Unit.Text.ToUpper() == "DEG/MIN")
                {
                    //位移控时转换成mm/min
                    SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text) / 60 / MainForm.mainform.posDtaRatio;
                }
                else       //MM/S
                {
                    SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text)/ MainForm.mainform.posDtaRatio;
                }

                if (cmbX_Dyn_MoveCtrl_Unit.Text.ToUpper() == "KNM")
                {
                    Offset = double.Parse(tbX_Dyn_Offset.Text) * 1000 / MainForm.mainform.loadDtaRatio;
                    Amplitude = double.Parse(tbX_Dyn_Amplitude.Text) * 1000 / MainForm.mainform.loadDtaRatio;
                }
                else if (cmbX_Dyn_MoveCtrl_Unit.Text.ToUpper() == "NM")
                {
                    Offset = double.Parse(tbX_Dyn_Offset.Text)/ MainForm.mainform.loadDtaRatio;
                    Amplitude = double.Parse(tbX_Dyn_Amplitude.Text)/ MainForm.mainform.loadDtaRatio;
                }
                else    //deg
                {
                    Offset = double.Parse(tbX_Dyn_Offset.Text) / MainForm.mainform.posDtaRatio;
                    Amplitude = double.Parse(tbX_Dyn_Amplitude.Text) / MainForm.mainform.posDtaRatio;
                }
            }

            Frequency = double.Parse(tbX_Dyn_Frequency.Text);
            HalfCycles = int.Parse(tbX_Cycles.Text) * 2;

            if (MainForm.mainform.isRunning)
            {
                cbX_DynCtrl_ModifyParam.Checked = true;
            }

            Modify = cbX_DynCtrl_ModifyParam.Checked;
            RelativeDestination = cbX_DynCtrl_RelativeDestinations.Checked;
            HaltAtPlusAmplitude = 0.0;
            HaltAtMinusAmplitude = 0.0;
            SpeedToDestination = 0.0;
            Destination = Offset + Amplitude;
            SweepFrequencyMode = 0;

            //MainForm.mainform.PVPositionQueue.Clear();

            MainForm.mainform.MoveDynCycles(WaveForm, Modify, PeakCtrl, MoveCtrl, RelativeDestination, SpeedToStart, Offset, Amplitude, HaltAtPlusAmplitude, HaltAtMinusAmplitude, Frequency, HalfCycles, SpeedToDestination, Destination, SweepFrequencyMode);

            //不在运行时才能修改次数
            //if (!MainForm.mainform.isRunning)
            {
                tbX_TestCount.Text = MainForm.mainform.GetCountText();
                MainForm.mainform.nPreTestCount = int.Parse(tbX_TestCount.Text);
            }
            cbX_DynCtrl_ModifyParam.Checked = true;

            WriteIni();

            MainForm.mainform.PVPositionQueue.Clear();
        }

        public void SetCountText(string countNum)
        {
            tbX_TestCount.Text = countNum;
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


        private void btnX_Dyn_Offset_P1_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Offset.Text = OffsetAddSub(double.Parse(tbX_Dyn_Offset.Text), AddSubScale.Deci, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Offset_P2_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Offset.Text = OffsetAddSub(double.Parse(tbX_Dyn_Offset.Text), AddSubScale.One, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Offset_P3_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Offset.Text = OffsetAddSub(double.Parse(tbX_Dyn_Offset.Text), AddSubScale.Ten, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Offset_S1_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Offset.Text = OffsetAddSub(double.Parse(tbX_Dyn_Offset.Text), AddSubScale.Deci, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Offset_S2_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Offset.Text = OffsetAddSub(double.Parse(tbX_Dyn_Offset.Text), AddSubScale.One, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Offset_S3_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Offset.Text = OffsetAddSub(double.Parse(tbX_Dyn_Offset.Text), AddSubScale.Ten, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Amplitude_P1_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Amplitude.Text = OffsetAddSub(double.Parse(tbX_Dyn_Amplitude.Text), AddSubScale.Deci, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Amplitude_P2_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Amplitude.Text = OffsetAddSub(double.Parse(tbX_Dyn_Amplitude.Text), AddSubScale.One, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Amplitude_P3_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Amplitude.Text = OffsetAddSub(double.Parse(tbX_Dyn_Amplitude.Text), AddSubScale.Ten, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Amplitude_S1_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Amplitude.Text = OffsetAddSub(double.Parse(tbX_Dyn_Amplitude.Text), AddSubScale.Deci, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Amplitude_S2_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Amplitude.Text = OffsetAddSub(double.Parse(tbX_Dyn_Amplitude.Text), AddSubScale.One, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Amplitude_S3_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Amplitude.Text = OffsetAddSub(double.Parse(tbX_Dyn_Amplitude.Text), AddSubScale.Ten, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }


        private void btnX_Dyn_Freq_P1_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Frequency.Text = OffsetAddSub(double.Parse(tbX_Dyn_Frequency.Text), AddSubScale.Deci, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Freq_P2_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Frequency.Text = OffsetAddSub(double.Parse(tbX_Dyn_Frequency.Text), AddSubScale.One, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Freq_P3_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Frequency.Text = OffsetAddSub(double.Parse(tbX_Dyn_Frequency.Text), AddSubScale.Ten, true).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Freq_S1_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Frequency.Text = OffsetAddSub(double.Parse(tbX_Dyn_Frequency.Text), AddSubScale.Deci, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Freq_S2_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Frequency.Text = OffsetAddSub(double.Parse(tbX_Dyn_Frequency.Text), AddSubScale.One, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void btnX_Dyn_Freq_S3_Click(object sender, EventArgs e)
        {
            tbX_Dyn_Frequency.Text = OffsetAddSub(double.Parse(tbX_Dyn_Frequency.Text), AddSubScale.Ten, false).ToString();
            if (MainForm.mainform.isRunning)
            {
                SendCommand();
            }
        }

        private void tbX_Dyn_Offset_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // 允许数字
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // 允许一个小数点
            if (e.KeyChar == '.' && !tbX_Dyn_Offset.Text.Contains("."))
            {
                return;
            }

            // 允许负号（只能在最前面）
            if (e.KeyChar == '-' && tbX_Dyn_Offset.SelectionStart == 0 && tbX_Dyn_Offset.Text.IndexOf('-') == -1)
            {
                return;
            }

            // 不符合要求的字符禁止输入
            e.Handled = true;
        }


        /// <summary>
        /// 加载配置文件参数
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            IniFileHelper.GetIniString("DynCtrl", "StartCtrl", "0", strTmp, strTmp.Capacity);
            if(MainForm.mainform.currentMachineType == "1"&& int.Parse(strTmp.ToString()) > 1)
            {
                cmbX_Dyn_StartCtrl.SelectedIndex = 0;
            }
            else
                cmbX_Dyn_StartCtrl.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("DynCtrl", "StartSpeed", "0", strTmp, strTmp.Capacity);
            tbX_Dyn_StartSpeed.Text = strTmp.ToString();

            IniFileHelper.GetIniString("DynCtrl", "StartSpeedUnit", "0", strTmp, strTmp.Capacity);
            cmbX_Dyn_StartSpeed_Unit.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("DynCtrl", "MoveCtrl", "0", strTmp, strTmp.Capacity);
            if (MainForm.mainform.currentMachineType == "1" && int.Parse(strTmp.ToString()) > 1)
            {
                cmbX_Dyn_MoveCtrl.SelectedIndex = 0;
            }
            else
                cmbX_Dyn_MoveCtrl.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("DynCtrl", "MoveCtrlUnit", "0", strTmp, strTmp.Capacity);
            cmbX_Dyn_MoveCtrl_Unit.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("DynCtrl", "WaveFrom", "0", strTmp, strTmp.Capacity);
            cmbX_Dyn_WaveFrom.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("DynCtrl", "PeakCtrl", "0", strTmp, strTmp.Capacity);
            cmbX_Dyn_PeakCtrl.SelectedIndex = 1/*int.Parse(strTmp.ToString())*/;

            tbX_Dyn_PeakCtrl.Text = strTmp.ToString();

            IniFileHelper.GetIniString("DynCtrl", "PeakCtrlCheck", "0", strTmp, strTmp.Capacity);
            cbX_Dyn_PeakCtrl.Checked = strTmp.ToString() == "1";

            IniFileHelper.GetIniString("DynCtrl", "Cycles", "0", strTmp, strTmp.Capacity);
            tbX_Cycles.Text = strTmp.ToString();

            IniFileHelper.GetIniString("DynCtrl", "FadeInOut", "0", strTmp, strTmp.Capacity);
            cbX_Dyn_FadeInOut.Checked = strTmp.ToString() == "1";

            IniFileHelper.GetIniString("DynCtrl", "OffSet", "0", strTmp, strTmp.Capacity);
            tbX_Dyn_Offset.Text = strTmp.ToString();

            IniFileHelper.GetIniString("DynCtrl", "Amplitude", "0", strTmp, strTmp.Capacity);
            tbX_Dyn_Amplitude.Text = strTmp.ToString();

            IniFileHelper.GetIniString("DynCtrl", "Frequency", "0", strTmp, strTmp.Capacity);
            tbX_Dyn_Frequency.Text = strTmp.ToString();
        }


        /// <summary>
        /// 保存配置文件参数
        /// </summary>
        public void WriteIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            strTmp = cmbX_Dyn_StartCtrl.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("DynCtrl", "StartCtrl", strTmp);

            strTmp = tbX_Dyn_StartSpeed.Text;
            IniFileHelper.WriteIniString("DynCtrl", "StartSpeed", strTmp);

            strTmp = cmbX_Dyn_StartSpeed_Unit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("DynCtrl", "StartSpeedUnit", strTmp);

            strTmp = cmbX_Dyn_MoveCtrl.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("DynCtrl", "MoveCtrl", strTmp);

            strTmp = cmbX_Dyn_MoveCtrl_Unit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("DynCtrl", "MoveCtrlUnit", strTmp);

            strTmp = cmbX_Dyn_WaveFrom.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("DynCtrl", "WaveFrom", strTmp);

            if (cbX_Dyn_PeakCtrl.Checked)
            {
                strTmp = cmbX_Dyn_PeakCtrl.SelectedIndex.ToString();
                IniFileHelper.WriteIniString("DynCtrl", "PeakCtrl", strTmp);
            }
            else
            {
                strTmp = tbX_Dyn_PeakCtrl.Text;
                IniFileHelper.WriteIniString("DynCtrl", "PeakCtrl", strTmp);
            }

            strTmp = cbX_Dyn_PeakCtrl.Checked.ToString();
            IniFileHelper.WriteIniString("DynCtrl", "PeakCtrlCheck", strTmp);

            strTmp = tbX_Cycles.Text;
            IniFileHelper.WriteIniString("DynCtrl", "Cycles", strTmp);

            strTmp = cbX_Dyn_FadeInOut.Checked.ToString();
            IniFileHelper.WriteIniString("DynCtrl", "FadeInOut", strTmp);

            strTmp = tbX_Dyn_Offset.Text;
            IniFileHelper.WriteIniString("DynCtrl", "OffSet", strTmp);

            strTmp = tbX_Dyn_Amplitude.Text;
            IniFileHelper.WriteIniString("DynCtrl", "Amplitude", strTmp);

            strTmp = tbX_Dyn_Frequency.Text;
            IniFileHelper.WriteIniString("DynCtrl", "Frequency", strTmp);
        }

        private void cmbX_Dyn_StartCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbX_Dyn_StartCtrl.SelectedValue.ToString())
            {
                case "POS":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "mm/min" };
                        break;
                    }
                case "角度":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "deg/min" };
                        break;
                    }
                case "LOAD":
                    {
                        if (MainForm.mainform.LoadUnit.ToUpper() == "KN")
                        {
                            cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "kN/s" };
                        }
                        else
                        {
                            cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "N/s" };
                        }
                        break;
                    }
                case "扭矩":
                    {
                        if (MainForm.mainform.LoadUnit.ToUpper() == "KN")
                        {
                            cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "kNm/s" };
                        }
                        else
                        {
                            cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "Nm/s" };
                        }
                        break;
                    }
                case "EXTENSION":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "mm/min" };
                        break;
                    }
                default:
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "Unit/s" };
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
                        cmbX_Dyn_MoveCtrl_Unit.DataSource = new string[] { "mm" };
                        labelX9.Text = "mm";
                        labelX11.Text = "mm";
                        break;
                    }
                case "角度":
                    {
                        cmbX_Dyn_MoveCtrl_Unit.DataSource = new string[] { "deg" };
                        labelX9.Text = "deg";
                        labelX11.Text = "deg";
                        break;
                    }
                case "LOAD":
                    {

                        if (MainForm.mainform.LoadUnit.ToUpper() == "KN")
                        {
                            cmbX_Dyn_MoveCtrl_Unit.DataSource = new string[] { "kN" };
                            labelX9.Text = "kN";
                            labelX11.Text = "kN";
                        }
                        else
                        {
                            cmbX_Dyn_MoveCtrl_Unit.DataSource = new string[] { "N" };
                            labelX9.Text = "N";
                            labelX11.Text = "N";
                        }
      
                        break;
                    }
                case "扭矩":
                    {

                        if (MainForm.mainform.LoadUnit.ToUpper() == "KN")
                        {
                            cmbX_Dyn_MoveCtrl_Unit.DataSource = new string[] { "kNm" };
                            labelX9.Text = "kNm";
                            labelX11.Text = "kNm";
                        }
                        else
                        {
                            cmbX_Dyn_MoveCtrl_Unit.DataSource = new string[] { "Nm" };
                            labelX9.Text = "Nm";
                            labelX11.Text = "Nm";
                        }

                        break;
                    }
                case "EXTENSION":
                    {
                        cmbX_Dyn_MoveCtrl_Unit.DataSource = new string[] { "mm" };
                        labelX9.Text = "mm";
                        labelX11.Text = "mm";
                        break;
                    }
                default:
                    {
                        cmbX_Dyn_MoveCtrl_Unit.DataSource = new string[] { "Unit" };
                        break;
                    }
            }
        }

        private void FrmDynCtrl_Load(object sender, EventArgs e)
        {
            //ReplaceLanguage();
            //UiAutoSize();
        }

        private void labelX7_Click(object sender, EventArgs e)
        {
            if (operateFlag == 0)
            {
                operateFlag = 1;
                this.Height = 70;
                labelX7.Text = "Max";
            }
            else if (operateFlag == 1)
            {
                operateFlag = 0;
                this.Height = 539;
                labelX7.Text = "Min";
            }
        }

        private void labelX6_Click(object sender, EventArgs e)
        {
            labelX6.Visible = false;
            labelX5.Visible = true;
            this.TopMost = false;
        }

        private void labelX5_Click(object sender, EventArgs e)
        {
            labelX6.Visible = true;
            labelX5.Visible = false;
            this.TopMost = true;
        }
    }
}
