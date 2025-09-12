using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Security.Cryptography;

namespace DoPENetConnect
{
    public partial class FrmSystemSetting : Form
    {
        public FrmSystemSetting()
        {

            InitializeComponent();
        }



        private void FrmSystemSetting_Load(object sender, EventArgs e)
        {
            LoadIni();
            ReplaceLanguage();
            UiAutoSize();

        }

        /// <summary>
        /// 根据语言自适应控件位置参数
        /// 由于语言长度不同 因此需要根据语言长度设置控件长度自适应
        /// </summary>
        private void UiAutoSize()
        {

            ///底部按钮
            int btnsBottomLength =btnX_FrmProtectOption_OK.Width + 150;
            int btnBottomStart = (this.Width-btnsBottomLength)/ 2;
            btnX_FrmProtectOption_OK.Location = new Point(btnBottomStart, btnX_FrmProtectOption_OK.Bounds.Y);
            //btnX_FrmProtectOption_Cencel.Location = new Point(btnBottomStart + 180, btnX_FrmProtectOption_Cencel.Bounds.Y);

            ///系统设置
            ///groupPannel3
            int lineStart = 15;
            checkBoxX3.Location = new Point(lineStart, checkBoxX3.Location.Y);
            numericUpDown1.Location = new Point(checkBoxX3.Location.X+checkBoxX3.Width+5, numericUpDown1.Location.Y);
            label12.Location = new Point(numericUpDown1.Location.X + numericUpDown1.Width + 5, label12.Location.Y);

            checkBoxX4.Location = new Point(lineStart, checkBoxX4.Location.Y);
            numericUpDown2.Location = new Point(numericUpDown1.Location.X , numericUpDown2.Location.Y);
            label11.Location = new Point(label12.Location.X , label11.Location.Y);

            ///groupPanne5
            NUD_CountLog.Location = new Point(lineStart, NUD_CountLog.Location.Y);
            label2.Location = new Point(NUD_CountLog.Location.X + NUD_CountLog.Width + 5, label2.Location.Y);

            ///groupPanel6
            label3.Location = new Point(lineStart, label3.Location.Y);
            tbX_DeviceID.Location = new Point(label3.Location.X + label3.Width + 5, tbX_DeviceID.Location.Y);


            ///动态实验过程保护选项
            ///Line1
            label1.Location = new Point(lineStart, label1.Location.Y);
            cbX_ProtectOption.Location = new Point(label1.Location.X + label1.Width + 5, cbX_ProtectOption.Location.Y);

            //titles
            label16.Location = new Point(lineStart, label16.Location.Y);
            label22.Location = new Point(label16.Location.X, label22.Location.Y);
            label24.Location = new Point(label16.Location.X, label24.Location.Y);
            label27.Location = new Point(label16.Location.X, label27.Location.Y);
            label9.Location = new Point(label16.Location.X, label9.Location.Y);
            label39.Location = new Point(label16.Location.X, label39.Location.Y);

            label18.Location = new Point(label16.Location.X + label16.Width + 100, label18.Location.Y);
            label23.Location = new Point(label18.Location.X, label23.Location.Y);
            label25.Location = new Point(label18.Location.X, label25.Location.Y);
            label26.Location = new Point(label18.Location.X, label26.Location.Y);
            label5.Location = new Point(label18.Location.X, label5.Location.Y);
            label38.Location = new Point(label18.Location.X, label38.Location.Y);

            //groupPanels
            tbX_FrmProtectOption_PosMaxOut.Location = new Point(lineStart+2, tbX_FrmProtectOption_PosMaxOut.Location.Y);
            label6.Location = new Point(tbX_FrmProtectOption_PosMaxOut.Location.X + tbX_FrmProtectOption_PosMaxOut.Width + 5, label6.Location.Y);
            cbX_FrmProtectOption_PosMaxOut_Effect.Location = new Point(label6.Location.X + label6.Width + 5, cbX_FrmProtectOption_PosMaxOut_Effect.Location.Y);

            tbX_FrmProtectOption_PosMinOut.Location = new Point(lineStart + 2, tbX_FrmProtectOption_PosMinOut.Location.Y);
            label7.Location = new Point(label6.Bounds.X, label7.Location.Y);
            cbX_FrmProtectOption_PosMinOut_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxOut_Effect.Bounds.X, cbX_FrmProtectOption_PosMinOut_Effect.Location.Y);

            tbX_FrmProtectOption_LoadMaxOut.Location = new Point(lineStart + 2, tbX_FrmProtectOption_LoadMaxOut.Location.Y);
            label8.Location = new Point(label6.Bounds.X, label8.Location.Y);
            cbX_FrmProtectOption_LoadMaxOut_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxOut_Effect.Bounds.X, cbX_FrmProtectOption_LoadMaxOut_Effect.Location.Y);

            tbX_FrmProtectOption_LoadMinOut.Location = new Point(lineStart + 2, tbX_FrmProtectOption_LoadMinOut.Location.Y);
            label30.Location = new Point(label6.Bounds.X, label30.Location.Y);
            cbX_FrmProtectOption_LoadMinOut_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxOut_Effect.Bounds.X, cbX_FrmProtectOption_LoadMinOut_Effect.Location.Y);

            tbX_FrmProtectOption_ExtMaxOut.Location = new Point(lineStart + 2, tbX_FrmProtectOption_ExtMaxOut.Location.Y);
            label14.Location = new Point(label6.Bounds.X, label14.Location.Y);
            cbX_FrmProtectOption_ExtMaxOut_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxOut_Effect.Bounds.X, cbX_FrmProtectOption_ExtMaxOut_Effect.Location.Y);

            tbX_FrmProtectOption_ExtMinOut.Location = new Point(lineStart + 2, tbX_FrmProtectOption_ExtMinOut.Location.Y);
            label13.Location = new Point(label6.Bounds.X, label13.Location.Y);
            cbX_FrmProtectOption_ExtMinOut_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxOut_Effect.Bounds.X, cbX_FrmProtectOption_ExtMinOut_Effect.Location.Y);


            tbX_FrmProtectOption_PosMaxIn.Location = new Point(label18.Bounds.X+2, tbX_FrmProtectOption_PosMaxIn.Location.Y);
            label19.Location = new Point(tbX_FrmProtectOption_PosMaxIn.Location.X + tbX_FrmProtectOption_PosMaxIn.Width + 5, label19.Location.Y);
            cbX_FrmProtectOption_PosMaxIn_Effect.Location = new Point(label19.Location.X + label19.Width + 5, cbX_FrmProtectOption_PosMaxIn_Effect.Location.Y);

            tbX_FrmProtectOption_PosMinIn.Location = new Point(tbX_FrmProtectOption_PosMaxIn.Bounds.X, tbX_FrmProtectOption_PosMinIn.Location.Y);
            label20.Location = new Point(label19.Bounds.X, label20.Location.Y);
            cbX_FrmProtectOption_PosMinIn_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxIn_Effect.Bounds.X, cbX_FrmProtectOption_PosMinIn_Effect.Location.Y);

            tbX_FrmProtectOption_LoadMaxIn.Location = new Point(tbX_FrmProtectOption_PosMaxIn.Bounds.X, tbX_FrmProtectOption_LoadMaxIn.Location.Y);
            label28.Location = new Point(label19.Bounds.X, label28.Location.Y);
            cbX_FrmProtectOption_LoadMaxIn_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxIn_Effect.Bounds.X, cbX_FrmProtectOption_LoadMaxIn_Effect.Location.Y);

            tbX_FrmProtectOption_LoadMinIn.Location = new Point(tbX_FrmProtectOption_PosMaxIn.Bounds.X, tbX_FrmProtectOption_LoadMinIn.Location.Y);
            label31.Location = new Point(label19.Bounds.X, label31.Location.Y);
            cbX_FrmProtectOption_LoadMinIn_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxIn_Effect.Bounds.X, cbX_FrmProtectOption_LoadMinIn_Effect.Location.Y);

            tbX_FrmProtectOption_ExtMaxIn.Location = new Point(tbX_FrmProtectOption_PosMaxIn.Bounds.X, tbX_FrmProtectOption_ExtMaxIn.Location.Y);
            label35.Location = new Point(label19.Bounds.X, label35.Location.Y);
            cbX_FrmProtectOption_ExtMaxIn_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxIn_Effect.Bounds.X, cbX_FrmProtectOption_ExtMaxIn_Effect.Location.Y);

            tbX_FrmProtectOption_ExtMinIn.Location = new Point(tbX_FrmProtectOption_PosMaxIn.Bounds.X, tbX_FrmProtectOption_ExtMinIn.Location.Y);
            label36.Location = new Point(label19.Bounds.X, label36.Location.Y);
            cbX_FrmProtectOption_ExtMinIn_Effect.Location = new Point(cbX_FrmProtectOption_PosMaxIn_Effect.Bounds.X, cbX_FrmProtectOption_ExtMinIn_Effect.Location.Y);

            ///试验机参数
            //主参数
            lbX_MaxForce.Location = new Point(lineStart , lbX_MaxForce.Location.Y);
            comboBoxEx_MaxForce.Location = new Point(lbX_MaxForce.Location.X + lbX_MaxForce.Width + 60, comboBoxEx_MaxForce.Location.Y);
            label17.Location = new Point(comboBoxEx_MaxForce.Location.X + comboBoxEx_MaxForce.Width + 5, label17.Location.Y);
            cbX_MaxForce.Location = new Point(label17.Location.X + label17.Width + 5, cbX_MaxForce.Location.Y);

            lbX_MaxTrip.Location = new Point(lbX_MaxForce.Bounds.X, lbX_MaxTrip.Location.Y);
            comboBoxEx_MaxTrip.Location = new Point(comboBoxEx_MaxForce.Location.X, comboBoxEx_MaxTrip.Location.Y);
            label10.Location = new Point(label17.Location.X, label10.Location.Y);
            cbX_MaxTrip.Location = new Point(cbX_MaxForce.Location.X, cbX_MaxTrip.Location.Y);

            label29.Location = new Point(lbX_MaxForce.Bounds.X, label29.Location.Y);
            tbX_MaxTripSpeed.Location = new Point(comboBoxEx_MaxForce.Location.X, tbX_MaxTripSpeed.Location.Y);
            label15.Location = new Point(label17.Location.X, label15.Location.Y);

            label33.Location = new Point(lbX_MaxForce.Bounds.X, label33.Location.Y);
            comboBoxEx_TripSensor.Location = new Point(comboBoxEx_MaxForce.Location.X, comboBoxEx_TripSensor.Location.Y);

            label32.Location = new Point(lbX_MaxForce.Bounds.X, label32.Location.Y);
            tbDeviceNo.Location = new Point(comboBoxEx_MaxForce.Location.X, tbDeviceNo.Location.Y);
            //单位选择
            label43.Location = new Point(lineStart, label43.Location.Y);
            comboBoxEx_ForceUnit.Location = new Point(comboBoxEx_MaxForce.Location.X, comboBoxEx_ForceUnit.Location.Y);

            ///按键常数
            label44.Location = new Point(lineStart, label44.Location.Y);
            tbX_upval.Location = new Point(label44.Location.X + label44.Width + 100, tbX_upval.Location.Y);
            label40.Location = new Point(tbX_upval.Location.X + tbX_upval.Width + 5, label40.Location.Y);


            label21.Location = new Point(lineStart, label21.Location.Y);
            tbX_hurryupval.Location = new Point(tbX_upval.Location.X , tbX_hurryupval.Location.Y);
            label4.Location = new Point(label40.Location.X, label4.Location.Y);




            label34.Location = new Point(lineStart, label34.Location.Y);
            tbX_downval.Location = new Point(tbX_upval.Location.X, tbX_downval.Location.Y);
            label37.Location = new Point(label40.Location.X, label37.Location.Y);



            label41.Location = new Point(lineStart, label41.Location.Y);
            tbX_hurrydownval.Location = new Point(tbX_upval.Location.X, tbX_hurrydownval.Location.Y);
            label42.Location = new Point(label40.Location.X, label42.Location.Y);



        }

        private void ReplaceLanguage()
        {
            StringBuilder strTmp = new StringBuilder();
            IniFileHelper.GetIniString("Setting", "Language", "0", strTmp, strTmp.Capacity);
            string strLanguage = strTmp.ToString();
            var langData = LanguageLoad.LoadLang(System.IO.Directory.GetCurrentDirectory() + "\\Lang\\" + strLanguage + ".json");
                       
            //循环界面控件替换成指定的语言
            if (langData.TryGetValue(this.Name, out var frmSystemSetting))
            {
                //foreach (var kvp in mainFormLabels)
                //{
                //    var controlName = kvp.Key;
                //    var textValue = kvp.Value;

                //    // 根据控件名称查找控件（可以扩展为递归查找）
                //    var ctrl = this.Controls.Find(controlName, true).FirstOrDefault();
                //    if (ctrl != null)
                //    {
                //        ctrl.Text = textValue;
                //    }
                //}



                //
                // 只要是下拉框就先清除
                //
                int protectOptionCurrentIndex = cbX_ProtectOption.SelectedIndex;
                while (cbX_ProtectOption.Items.Count != 0)
                {
                    cbX_ProtectOption.Items.RemoveAt(0);
                }
                int tripSensorCurrentIndex = comboBoxEx_TripSensor.SelectedIndex;
                while (comboBoxEx_TripSensor.Items.Count != 0)
                {
                    comboBoxEx_TripSensor.Items.RemoveAt(0);
                }


                foreach (var kvp in frmSystemSetting)
                {
                    var controlName = kvp.Key;
                    var textValue = kvp.Value;

                    // 首先尝试从主窗体的控件集合中查找控件
                    var ctrl = this.Controls.Find(controlName, true).FirstOrDefault();

                    if (ctrl == null)
                    {
                        foreach (SuperTabItem tabItem in superTabControl1.Tabs)
                        {
                            // 获取当前 TabItem 的内容区域
                            if (tabItem.Name == controlName)
                            {
                                tabItem.Text = textValue;
                                break;
                            }
                        }

                        if (controlName.Contains("cbX_ProtectOption"))
                        {
                            cbX_ProtectOption.Items.Add(textValue);
                        }
                        if (controlName.Contains("comboBoxEx_TripSensor"))
                        {
                             comboBoxEx_TripSensor.Items.Add(textValue);
                        }
                    }
                    else {
                        ctrl.Text = textValue;
                    }

                }

                #region RestoreUi
                if(cbX_ProtectOption.Items.Count>protectOptionCurrentIndex)
                    cbX_ProtectOption.SelectedIndex = protectOptionCurrentIndex;

                if (comboBoxEx_TripSensor.Items.Count > tripSensorCurrentIndex)
                    comboBoxEx_TripSensor.SelectedIndex = tripSensorCurrentIndex;

                #endregion RestoreUi


            }
        }

        private Control GetContentContainer(SuperTabItem tabItem)
        {
            // 获取 SuperTabItem 对应的内容区域
            return tabItem.AttachedControl;
        }


        /// <summary>
        /// 加载配置文件参数
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            string strConfigSetion = this.Name;

            IniFileHelper.GetIniString("Setting", "CountLog", "0", strTmp, strTmp.Capacity);
            NUD_CountLog.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "限位保护选项", "0", strTmp, strTmp.Capacity);
            int indexToBeSetted = int.Parse(strTmp.ToString());
            if (cbX_ProtectOption.Items.Count > indexToBeSetted)
                cbX_ProtectOption.SelectedIndex = indexToBeSetted;

            //峰值保护选项
            IniFileHelper.GetIniString(strConfigSetion, "位移峰值外保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_PosMaxOut.Text = strTmp.ToString();

            double aaa = MainForm.mainform.protectOption.ProtectOption_ExtMaxIn;

            IniFileHelper.GetIniString(strConfigSetion, "位移峰值外保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_PosMaxOut_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "位移谷值外保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_PosMinOut.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "位移谷值外保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_PosMinOut_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "位移峰值内保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_PosMaxIn.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "位移峰值内保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_PosMaxIn_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "位移谷值内保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_PosMinIn.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "位移谷值内保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_PosMinIn_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            //试验力保护选项
            IniFileHelper.GetIniString(strConfigSetion, "试验力峰值外保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_LoadMaxOut.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "试验力峰值外保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_LoadMaxOut_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "试验力谷值外保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_LoadMinOut.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "试验力谷值外保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_LoadMinOut_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "试验力峰值内保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_LoadMaxIn.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "试验力峰值内保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_LoadMaxIn_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "试验力谷值内保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_LoadMinIn.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "试验力谷值内保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_LoadMinIn_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            //变形保护选项
            IniFileHelper.GetIniString(strConfigSetion, "变形峰值外保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_ExtMaxOut.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "变形峰值外保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_ExtMaxOut_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "变形谷值外保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_ExtMinOut.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "变形谷值外保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_ExtMinOut_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "变形峰值内保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_ExtMaxIn.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "变形峰值内保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_ExtMaxIn_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "变形谷值内保护", "0", strTmp, strTmp.Capacity);
            tbX_FrmProtectOption_ExtMinIn.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "变形谷值内保护生效", "0", strTmp, strTmp.Capacity);
            cbX_FrmProtectOption_ExtMinIn_Effect.Checked = strTmp.ToString() == "0" ? false : true;

            //系统保护设置  section=SysProtectSetting numericUpDown1: key=OverLoad_Percent=10; numericUpDown2:OverLoad_Force = 10;
            IniFileHelper.GetIniString("SysProtectSetting", "OverLoad_Percent","0",strTmp,strTmp.Capacity);
            numericUpDown1.Value = Convert.ToDecimal(strTmp.ToString());

            IniFileHelper.GetIniString("SysProtectSetting", "OverLoadPercent_Flag", "0", strTmp, strTmp.Capacity);
            checkBoxX3.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("SysProtectSetting", "OverLoad_Force", "0", strTmp, strTmp.Capacity);
            numericUpDown2.Value = decimal.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("SysProtectSetting", "OverLoadForce_Flag", "0", strTmp, strTmp.Capacity);
            checkBoxX4.Checked = strTmp.ToString() == "0" ? false : true;
            //系统设置-设备id
            //IniFileHelper.GetIniString("Device", "DeviceID", "0", strTmp, strTmp.Capacity);
            //tbX_DeviceID.Text = strTmp.ToString();

            //按钮常量设置
            IniFileHelper.GetIniString("PushButtonFunctionConstant", "Up", "0", strTmp, strTmp.Capacity);
            tbX_upval.Text = strTmp.ToString();

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "HurryUp", "0", strTmp, strTmp.Capacity);
            tbX_hurryupval.Text = strTmp.ToString();

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "Down", "0", strTmp, strTmp.Capacity);
            tbX_downval.Text = strTmp.ToString();

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "HurryDown", "0", strTmp, strTmp.Capacity);
            tbX_hurrydownval.Text = strTmp.ToString();

            ///ui 选中状态
            //IniFileHelper.GetIniString("UIDefault", "cbX_ProtectOption", "0", strTmp, strTmp.Capacity);
            //cbX_ProtectOption.SelectedIndex = int.Parse(strTmp.ToString());
            IniFileHelper.GetIniString("UIDefault", "comboBoxEx_MaxForce", "0", strTmp, strTmp.Capacity);
            comboBoxEx_MaxForce.SelectedIndex = int.Parse(strTmp.ToString());
            IniFileHelper.GetIniString("UIDefault", "comboBoxEx_MaxTrip", "0", strTmp, strTmp.Capacity);
            comboBoxEx_MaxTrip.SelectedIndex = int.Parse(strTmp.ToString());
            IniFileHelper.GetIniString("UIDefault", "comboBoxEx_TripSensor", "0", strTmp, strTmp.Capacity);
            indexToBeSetted = int.Parse(strTmp.ToString());
            if (comboBoxEx_TripSensor.Items.Count > indexToBeSetted)
                comboBoxEx_TripSensor.SelectedIndex = indexToBeSetted;
            IniFileHelper.GetIniString("UIDefault", "comboBoxEx_ForceUnit", "0", strTmp, strTmp.Capacity);
            comboBoxEx_ForceUnit.SelectedIndex = int.Parse(strTmp.ToString());

            //通信
            IniFileHelper.GetIniString("Communication", "Com", "0", strTmp, strTmp.Capacity);
            comboBoxComSelect.Text = strTmp.ToString();

            IniFileHelper.GetIniString("Communication", "Interval", "0", strTmp, strTmp.Capacity);
            comboBoxSendInterval.Text = strTmp.ToString();

            //采样
            IniFileHelper.GetIniString("Sample", "Rate", "0", strTmp, strTmp.Capacity);
            string sampleRateVal;
            if (int.Parse(strTmp.ToString()) == 0)
            {
                sampleRateVal = "10";
            }
            else
                sampleRateVal = strTmp.ToString();
            numericUpDown3.Value = decimal.Parse(sampleRateVal);
        }


        /// <summary>
        /// 保存配置文件参数
        /// </summary>
        public void WriteIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            string strConfigSetion = this.Name;

            //按试验次数记录日志
            strTmp = NUD_CountLog.Text;
            MainForm.mainform.nCountLog = int.Parse(strTmp);
            IniFileHelper.WriteIniString("Setting", "CountLog", strTmp);

            strTmp = cbX_ProtectOption.SelectedIndex.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "限位保护选项", strTmp);

            //位移保护选项
            strTmp = tbX_FrmProtectOption_PosMaxOut.Text;
            MainForm.mainform.protectOption.ProtectOption_PosMaxOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "位移峰值外保护", strTmp);

            strTmp = cbX_FrmProtectOption_PosMaxOut_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_PosMaxOut_Effect = cbX_FrmProtectOption_PosMaxOut_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "位移峰值外保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_PosMinOut.Text;
            MainForm.mainform.protectOption.ProtectOption_PosMinOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "位移谷值外保护", strTmp);

            strTmp = cbX_FrmProtectOption_PosMinOut_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_PosMinOut_Effect = cbX_FrmProtectOption_PosMinOut_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "位移谷值外保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_PosMaxIn.Text;
            MainForm.mainform.protectOption.ProtectOption_PosMaxIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "位移峰值内保护", strTmp);

            strTmp = cbX_FrmProtectOption_PosMaxIn_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_PosMaxIn_Effect = cbX_FrmProtectOption_PosMaxIn_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "位移峰值内保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_PosMinIn.Text;
            MainForm.mainform.protectOption.ProtectOption_PosMinIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "位移谷值内保护", strTmp);

            strTmp = cbX_FrmProtectOption_PosMinIn_Effect.Checked == true ? "1" : "0";
            MainForm.mainform.protectOption.ProtectOption_PosMinIn_Effect = cbX_FrmProtectOption_PosMinIn_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "位移谷值内保护生效", strTmp);

            //试验力保护选项
            strTmp = tbX_FrmProtectOption_LoadMaxOut.Text;
            MainForm.mainform.protectOption.ProtectOption_LoadMaxOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "试验力峰值外保护", strTmp);

            strTmp = cbX_FrmProtectOption_LoadMaxOut_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_LoadMaxOut_Effect = cbX_FrmProtectOption_LoadMaxOut_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "试验力峰值外保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_LoadMinOut.Text;
            MainForm.mainform.protectOption.ProtectOption_LoadMinOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "试验力谷值外保护", strTmp);

            strTmp = cbX_FrmProtectOption_LoadMinOut_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_LoadMinOut_Effect = cbX_FrmProtectOption_LoadMinOut_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "试验力谷值外保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_LoadMaxIn.Text;
            MainForm.mainform.protectOption.ProtectOption_LoadMaxIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "试验力峰值内保护", strTmp);

            strTmp = cbX_FrmProtectOption_LoadMaxIn_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_LoadMaxIn_Effect = cbX_FrmProtectOption_LoadMaxIn_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "试验力峰值内保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_LoadMinIn.Text;
            MainForm.mainform.protectOption.ProtectOption_LoadMinIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "试验力谷值内保护", strTmp);

            strTmp = cbX_FrmProtectOption_LoadMinIn_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_LoadMinIn_Effect = cbX_FrmProtectOption_LoadMinIn_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "试验力谷值内保护生效", strTmp);

            //变形保护选项
            strTmp = tbX_FrmProtectOption_ExtMaxOut.Text;
            MainForm.mainform.protectOption.ProtectOption_ExtMaxOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "变形峰值外保护", strTmp);

            strTmp = cbX_FrmProtectOption_ExtMaxOut_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_ExtMaxOut_Effect = cbX_FrmProtectOption_ExtMaxOut_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "变形峰值外保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_ExtMinOut.Text;
            MainForm.mainform.protectOption.ProtectOption_ExtMinOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "变形谷值外保护", strTmp);

            strTmp = cbX_FrmProtectOption_ExtMinOut_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_ExtMinOut_Effect = cbX_FrmProtectOption_ExtMinOut_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "变形谷值外保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_ExtMaxIn.Text;
            MainForm.mainform.protectOption.ProtectOption_ExtMaxIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "变形峰值内保护", strTmp);

            strTmp = cbX_FrmProtectOption_ExtMaxIn_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_ExtMaxIn_Effect = cbX_FrmProtectOption_ExtMaxIn_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "变形峰值内保护生效", strTmp);

            strTmp = tbX_FrmProtectOption_ExtMinIn.Text;
            MainForm.mainform.protectOption.ProtectOption_ExtMinIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "变形谷值内保护", strTmp);

            strTmp = cbX_FrmProtectOption_ExtMinIn_Effect.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_ExtMinIn_Effect = cbX_FrmProtectOption_ExtMinIn_Effect.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "变形谷值内保护生效", strTmp);

            //系统保护设置  section=SysProtectSetting numericUpDown1: key=OverLoad_Percent=10; numericUpDown2:OverLoad_Force = 10;
            strTmp = checkBoxX3.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_OverLoadPercent_Flag = checkBoxX3.Checked;
            IniFileHelper.WriteIniString("SysProtectSetting", "OverLoadPercent_Flag", strTmp);
          
            strTmp = numericUpDown1.Value.ToString();
            MainForm.mainform.protectOption.ProtectOption_OverLoadPercent = double.Parse(strTmp);
            IniFileHelper.WriteIniString("SysProtectSetting", "OverLoad_Percent", strTmp);


            strTmp = checkBoxX4.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_OverLoadForce_Flag = checkBoxX4.Checked;
            IniFileHelper.WriteIniString("SysProtectSetting", "OverLoadForce_Flag", strTmp);

            strTmp = numericUpDown2.Value.ToString();
            MainForm.mainform.protectOption.ProtectOption_OverLoadForce = double.Parse(strTmp);
            IniFileHelper.WriteIniString("SysProtectSetting", "OverLoad_Force", strTmp);

            if (tbX_DeviceID.Text != "")
            {
                strTmp = DESEncrypt.Encrypt(tbX_DeviceID.Text);
                MainForm.mainform.RefreshDeviceID(tbX_DeviceID.Text);
                IniFileHelper.WriteIniString("Device", "DeviceID", strTmp);
                tbX_DeviceID.Clear();
            }

            //按钮常量设置
            strTmp = tbX_upval.Text;
            MainForm.mainform.btnUpConstantVal = double.Parse(strTmp);
            IniFileHelper.WriteIniString("PushButtonFunctionConstant", "Up", strTmp);

            strTmp = tbX_hurryupval.Text;
            MainForm.mainform.btnHurryUpConstantVal = double.Parse(strTmp);
            IniFileHelper.WriteIniString("PushButtonFunctionConstant", "HurryUp", strTmp);

            strTmp = tbX_upval.Text;
            MainForm.mainform.btnDownConstantVal = double.Parse(strTmp);
            IniFileHelper.WriteIniString("PushButtonFunctionConstant", "Down", strTmp);

            strTmp = tbX_hurryupval.Text;
            MainForm.mainform.btnHurryDownConstantVal = double.Parse(strTmp);
            IniFileHelper.WriteIniString("PushButtonFunctionConstant", "HurryDown", strTmp);


            ///ui 选中状态
            //strTmp = cbX_ProtectOption.SelectedIndex.ToString();
           // IniFileHelper.WriteIniString("UIDefault ", "cbX_ProtectOption", strTmp);

            strTmp = comboBoxEx_MaxForce.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("UIDefault ", "comboBoxEx_MaxForce", strTmp);

            strTmp = comboBoxEx_MaxTrip.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("UIDefault ", "comboBoxEx_MaxTrip", strTmp);

            strTmp = comboBoxEx_TripSensor.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("UIDefault ", "comboBoxEx_TripSensor", strTmp);

            strTmp = comboBoxEx_ForceUnit.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("UIDefault ", "comboBoxEx_ForceUnit", strTmp);

            //串口设定
            strTmp = comboBoxComSelect.Text;      //端口号
            IniFileHelper.WriteIniString("communication ", "Com", strTmp);

            strTmp = comboBoxSendInterval.Text;      //发送周期
            IniFileHelper.WriteIniString("communication ", "Interval", strTmp);

            MainForm.mainform.SetRealtimeParamComParams(comboBoxComSelect.Text,comboBoxSendInterval.Text);

            //采样频率添加
            strTmp = numericUpDown3.Value.ToString();
            IniFileHelper.WriteIniString("Sample", "Rate", strTmp);
            MainForm.mainform.sampleRate = int.Parse(strTmp);
            
        }


        /// <summary>
        /// 校验各项数据
        /// </summary>
        /// <returns></returns>
        private bool ValidityCheck()
        {
            //位移峰值外保护校验
            if (double.Parse(tbX_FrmProtectOption_PosMaxOut.Text) <= double.Parse(tbX_FrmProtectOption_PosMaxIn.Text))
            {
                MessageBox.Show("位移峰值外保护值不能小于等于位移峰值内保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmProtectOption_PosMaxOut.Focus();
                return false;
            }

            //位移谷值内保护校验
            if (double.Parse(tbX_FrmProtectOption_PosMinOut.Text) >= double.Parse(tbX_FrmProtectOption_PosMinIn.Text))
            {
                MessageBox.Show("位移谷值内保护值不能小于等于位移谷值外保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmProtectOption_PosMinOut.Focus();
                return false;
            }

            //试验力峰值外保护校验
            if (double.Parse(tbX_FrmProtectOption_LoadMaxOut.Text) <= double.Parse(tbX_FrmProtectOption_LoadMaxIn.Text))
            {
                MessageBox.Show("试验力峰值外保护值不能小于试验力峰值外保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmProtectOption_LoadMaxOut.Focus();
                return false;
            }

            //试验力谷值外保护校验
            if (double.Parse(tbX_FrmProtectOption_LoadMinOut.Text) >= double.Parse(tbX_FrmProtectOption_LoadMinIn.Text))
            {
                MessageBox.Show("试验力峰值内保护值不能小于等于试验力谷值外保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmProtectOption_LoadMinOut.Focus();
                return false;
            }

            //变形峰值谷值内保护校验
            if (double.Parse(tbX_FrmProtectOption_ExtMaxOut.Text) <= double.Parse(tbX_FrmProtectOption_ExtMaxIn.Text))
            {
                MessageBox.Show("变形峰值外保护值不能小于变形谷值外保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmProtectOption_ExtMaxOut.Focus();
                return false;
            }

            //变形峰值谷值内保护校验
            if (double.Parse(tbX_FrmProtectOption_ExtMinOut.Text) >= double.Parse(tbX_FrmProtectOption_ExtMinIn.Text))
            {
                MessageBox.Show("变形峰值内保护值不能小于变形谷值外保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmProtectOption_ExtMaxOut.Focus();
                return false;
            }

            return true;
        }



        /// <summary>
        /// 位移峰值外保护值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbX_FrmProtectOption_PosMaxOut_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbX_FrmProtectOption_PosMaxOut.Text))
            {
                tbX_FrmProtectOption_PosMaxOut.Text = "0";
                tbX_FrmProtectOption_PosMaxOut.Focus();
                MessageBox.Show("请输入一个值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// 位移谷值外保护值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 位移谷值内保护值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 位移谷值内保护值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX8_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 试验力峰值外保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 试验力谷值外保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX10_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 试验力峰值内保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX9_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 试验力谷值内保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX11_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 变形峰值外保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX6_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 变形谷值外保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 变形峰值内保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 变形谷值内保护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxX12_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 位移峰值外保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 位移谷值外保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX7_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 位移峰值内保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX6_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 位移谷值内保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX8_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 试验力峰值外保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 试验力谷值外保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX10_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 试验力峰值内保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX9_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 试验力谷值内保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX11_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 变形峰值外保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX5_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 变形谷值外保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX13_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 变形峰值内保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX12_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 变形谷值内保护生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxX14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnX_FrmProtectOption_OK_Click(object sender, EventArgs e)
        {
            if (!ValidityCheck())
            {
                MessageBox.Show("数据校验不通过", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WriteIni();
            this.Close();
        }

        private void btnX_FrmProtectOption_Cencel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void comboBoxEx_TripSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBoxEx_TripSensor.SelectedIndex);
            Console.WriteLine(comboBoxEx_TripSensor.SelectedText);
        }

        private void cbX_ProtectOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(cbX_ProtectOption.SelectedIndex);
            Console.WriteLine(cbX_ProtectOption.Text);
            
        }
        public string ComputeMD5(string input)

        {

            using (MD5 md5 = MD5.Create())

            {

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)

                {

                    sb.Append(hashBytes[i].ToString("x2"));

                }

                return sb.ToString();

            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            MainForm.mainform.SetupResetXHead();
        }

        private void superTabItem5_DoubleClick(object sender, EventArgs e)
        {
            FormInputBox tmpInput = new FormInputBox();
            tmpInput.Show();
            //IniFileHelper.WriteIniString("")
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double tmpValue =double.Parse(numericUpDown3.Value.ToString());
            double tmpLast = tmpValue % 10;
            double tmpCurrentVal = tmpValue;
            if (tmpLast != 0) {
                tmpCurrentVal = tmpValue - tmpLast + 10;
            }
            numericUpDown3.Value = decimal.Parse(Math.Ceiling(tmpCurrentVal).ToString());
       
        }
    }
}
