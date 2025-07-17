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
    public partial class FrmSystemSetting : Form
    {
        public FrmSystemSetting()
        {
            InitializeComponent();
        }



        private void FrmSystemSetting_Load(object sender, EventArgs e)
        {
            LoadIni();

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

            IniFileHelper.GetIniString("FrmProtectOption", "限位保护选项", "0", strTmp, strTmp.Capacity);
            cbX_ProtectOption.SelectedIndex = int.Parse(strTmp.ToString());

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
            IniFileHelper.GetIniString("Device", "DeviceID", "0", strTmp, strTmp.Capacity);
            tbX_DeviceID.Text = strTmp.ToString();
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

            strTmp = tbX_DeviceID.Text;
            MainForm.mainform.RefreshDeviceID(strTmp);
            IniFileHelper.WriteIniString("Device", "DeviceID", strTmp);

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

    }
}
