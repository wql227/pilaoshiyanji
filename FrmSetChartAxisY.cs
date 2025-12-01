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
    public partial class FrmSetChartAxisY : Form
    {
        public FrmSetChartAxisY()
        {
            InitializeComponent();
        }


        private void FrmSetChartAxisY_Load(object sender, EventArgs e)
        {
            LoadIni();
            ReplaceLanguage();
            UiAutoSize();
        }

        string strLanguage;


        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            string strConfigSetion = this.Name;

            IniFileHelper.GetIniString(strConfigSetion, "TimeEnable", "1", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_TimeEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "TimeRange", "1", strTmp, strTmp.Capacity);
            cbX_Time_Range.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString(strConfigSetion, "PositionEnable", "0", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_PosEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "PosRange", "0", strTmp, strTmp.Capacity);
            cbX_Pos_Range.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString(strConfigSetion, "LoadEnable", "0", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_LoadEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "LoadRange", "0", strTmp, strTmp.Capacity);
            cbX_Load_Range.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString(strConfigSetion, "ExtEnable", "0", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_ExtEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "ExtRange", "0", strTmp, strTmp.Capacity);
            cbX_Ext_Range.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString(strConfigSetion, "CommandEnable", "0", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_CommandEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "CommandRange", "0", strTmp, strTmp.Capacity);
            cbX_Command_Range.SelectedIndex = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString(strConfigSetion, "TimeX_MAX", "5", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_TimeY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "TimeX_MIN", "0", strTmp, strTmp.Capacity);
            if (strTmp.ToString() != "0")
            {
                tbX_FrmSetChartAxisY_TimeY_Min.Text = "0";
            }
            else
            {
                tbX_FrmSetChartAxisY_TimeY_Min.Text = strTmp.ToString();
            }

            IniFileHelper.GetIniString(strConfigSetion, "PositionY_MAX", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_PosY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "PositionY_MIN", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_PosY_Min.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "LoadY_MAX", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_LoadY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "LoadY_MIN", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_LoadY_Min.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "ExtY_MAX", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_ExtY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "ExtY_MIN", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_ExtY_Min.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "CommandY_MAX", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_CommandY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "CommandY_MIN", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_CommandY_Min.Text = strTmp.ToString();

        }

        public void WriteIni()
        {
            string strConfigSetion = this.Name;

            string strTmp = "";
            strTmp = cbX_FrmSetChartAxisY_PosEnable.Checked == false ? "0" : "1";
            IniFileHelper.WriteIniString(strConfigSetion, "PositionEnable", strTmp);

            strTmp = cbX_Pos_Range.SelectedIndex.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "PosRange", strTmp);

            strTmp = cbX_FrmSetChartAxisY_LoadEnable.Checked == false ? "0" : "1";
            IniFileHelper.WriteIniString(strConfigSetion, "LoadEnable", strTmp);

            strTmp = cbX_Load_Range.SelectedIndex.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "LoadRange", strTmp);

            strTmp = cbX_FrmSetChartAxisY_ExtEnable.Checked == false ? "0" : "1";
            IniFileHelper.WriteIniString(strConfigSetion, "ExtEnable", strTmp);

            strTmp = cbX_Ext_Range.SelectedIndex.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "ExtRange", strTmp);

            strTmp = cbX_FrmSetChartAxisY_CommandEnable.Checked == false ? "0" : "1";
            IniFileHelper.WriteIniString(strConfigSetion, "CommandEnable", strTmp);

            strTmp = cbX_Command_Range.SelectedIndex.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "CommandRange", strTmp);

            strTmp = tbX_FrmSetChartAxisY_PosY_Max.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "PositionY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_PosY_Min.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "PositionY_MIN", strTmp);

            strTmp = tbX_FrmSetChartAxisY_LoadY_Max.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "LoadY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_LoadY_Min.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "LoadY_MIN", strTmp);

            strTmp = tbX_FrmSetChartAxisY_ExtY_Max.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "ExtY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_ExtY_Min.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "ExtY_MIN", strTmp);

            strTmp = tbX_FrmSetChartAxisY_CommandY_Max.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "CommandY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_CommandY_Min.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "CommandY_MIN", strTmp);

            strTmp = tbX_FrmSetChartAxisY_TimeY_Max.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "TimeX_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_TimeY_Min.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "TimeX_MIN", strTmp);
        }
        /// <summary>
        /// 根据语言自适应控件位置参数
        /// 由于语言长度不同 因此需要根据语言长度设置控件长度自适应
        /// </summary>
        private void UiAutoSize()
        {
            int maxCtrlLen = 0;
            foreach (Control ctrl in panelEx1.Controls)
            {
                if (ctrl.Width > maxCtrlLen) maxCtrlLen = ctrl.Width;
            }

            labelX1.Width = maxCtrlLen;
            cbX_FrmSetChartAxisY_TimeEnable.Width = maxCtrlLen;
            cbX_FrmSetChartAxisY_PosEnable.Width = maxCtrlLen;
            cbX_FrmSetChartAxisY_LoadEnable.Width = maxCtrlLen;
            cbX_FrmSetChartAxisY_ExtEnable.Width = maxCtrlLen;
            cbX_FrmSetChartAxisY_CommandEnable.Width = maxCtrlLen;
            cbX_FrmSetChartAxisY_TimeEnable.Location = new Point(labelX1.Location.X + maxCtrlLen + 10, labelX1.Location.Y);
            cbX_FrmSetChartAxisY_PosEnable.Location = new Point(cbX_FrmSetChartAxisY_TimeEnable.Location.X + maxCtrlLen + 10, labelX1.Location.Y);
            cbX_FrmSetChartAxisY_LoadEnable.Location = new Point(cbX_FrmSetChartAxisY_PosEnable.Location.X + maxCtrlLen + 10, labelX1.Location.Y);
            cbX_FrmSetChartAxisY_ExtEnable.Location = new Point(cbX_FrmSetChartAxisY_LoadEnable.Location.X + maxCtrlLen + 10, labelX1.Location.Y);
            cbX_FrmSetChartAxisY_CommandEnable.Location = new Point(cbX_FrmSetChartAxisY_ExtEnable.Location.X + maxCtrlLen + 10, labelX1.Location.Y);

            labelX3.Location = new Point(labelX1.Location.X, labelX3.Location.Y);

            labelX2.Location = new Point(labelX1.Location.X, labelX2.Location.Y);

            labelX4.Location = new Point(labelX1.Location.X, labelX4.Location.Y);

            tbX_FrmSetChartAxisY_TimeY_Max.Location = new Point(cbX_FrmSetChartAxisY_TimeEnable.Location.X, tbX_FrmSetChartAxisY_TimeY_Max.Location.Y);

            tbX_FrmSetChartAxisY_PosY_Max.Location = new Point(cbX_FrmSetChartAxisY_PosEnable.Location.X, tbX_FrmSetChartAxisY_PosY_Max.Location.Y);

            tbX_FrmSetChartAxisY_LoadY_Max.Location = new Point(cbX_FrmSetChartAxisY_LoadEnable.Location.X, tbX_FrmSetChartAxisY_LoadY_Max.Location.Y);

            tbX_FrmSetChartAxisY_ExtY_Max.Location = new Point(cbX_FrmSetChartAxisY_ExtEnable.Location.X, tbX_FrmSetChartAxisY_ExtY_Max.Location.Y);

            tbX_FrmSetChartAxisY_CommandY_Max.Location = new Point(cbX_FrmSetChartAxisY_CommandEnable.Location.X, tbX_FrmSetChartAxisY_CommandY_Max.Location.Y);


            tbX_FrmSetChartAxisY_TimeY_Min.Location = new Point(cbX_FrmSetChartAxisY_TimeEnable.Location.X, tbX_FrmSetChartAxisY_TimeY_Min.Location.Y);

            tbX_FrmSetChartAxisY_PosY_Min.Location = new Point(cbX_FrmSetChartAxisY_PosEnable.Location.X, tbX_FrmSetChartAxisY_PosY_Min.Location.Y);

            tbX_FrmSetChartAxisY_LoadY_Min.Location = new Point(cbX_FrmSetChartAxisY_LoadEnable.Location.X, tbX_FrmSetChartAxisY_LoadY_Min.Location.Y);

            tbX_FrmSetChartAxisY_ExtY_Min.Location = new Point(cbX_FrmSetChartAxisY_ExtEnable.Location.X, tbX_FrmSetChartAxisY_ExtY_Min.Location.Y);

            tbX_FrmSetChartAxisY_CommandY_Min.Location = new Point(cbX_FrmSetChartAxisY_CommandEnable.Location.X, tbX_FrmSetChartAxisY_CommandY_Min.Location.Y);


            cbX_Time_Range.Location = new Point(cbX_FrmSetChartAxisY_TimeEnable.Location.X, cbX_Time_Range.Location.Y);

            cbX_Pos_Range.Location = new Point(cbX_FrmSetChartAxisY_PosEnable.Location.X, cbX_Pos_Range.Location.Y);

            cbX_Load_Range.Location = new Point(cbX_FrmSetChartAxisY_LoadEnable.Location.X, cbX_Load_Range.Location.Y);

            cbX_Ext_Range.Location = new Point(cbX_FrmSetChartAxisY_ExtEnable.Location.X, cbX_Ext_Range.Location.Y);

            cbX_Command_Range.Location = new Point(cbX_FrmSetChartAxisY_CommandEnable.Location.X, cbX_Command_Range.Location.Y);

            if (strLanguage == "English" || strLanguage == "简体中文")
            {
                this.Width = 850;
            }
            else if(strLanguage == "Español")
                this.Width = 1600;

            int startPos = (this.Width-231- btn_FrmSerAxisY_OK.Width)/ 2;
            int btn2 = startPos + 231;

            btn_FrmSerAxisY_OK.Location = new Point(startPos, btn_FrmSerAxisY_OK.Location.Y);
            btn_FrmSerAxisY_Cancel.Location = new Point(btn2, btn_FrmSerAxisY_Cancel.Location.Y);

        }

        /// <summary>
        /// 语言文件
        /// </summary>
        private void ReplaceLanguage()
        {
            StringBuilder strTmp = new StringBuilder();
            IniFileHelper.GetIniString("Setting", "Language", "0", strTmp, strTmp.Capacity);
             strLanguage = strTmp.ToString();
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

        private void btn_FrmSerAxisY_OK_Click(object sender, EventArgs e)
        {
            if (!ValidityCheck())
            {
                MessageBox.Show("数据校验不通过", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WriteIni();
            try
            {
                if (double.Parse(tbX_FrmSetChartAxisY_PosY_Max.Text) < MainForm.mainform.m_AxTeechart.Axis.Left.Maximum)
                {
                    MainForm.mainform.m_AxTeechart.Axis.Left.Minimum = double.Parse(tbX_FrmSetChartAxisY_PosY_Min.Text);
                    MainForm.mainform.m_AxTeechart.Axis.Left.Maximum = double.Parse(tbX_FrmSetChartAxisY_PosY_Max.Text);
                }
                else
                {
                    MainForm.mainform.m_AxTeechart.Axis.Left.Maximum = double.Parse(tbX_FrmSetChartAxisY_PosY_Max.Text);
                    MainForm.mainform.m_AxTeechart.Axis.Left.Minimum = double.Parse(tbX_FrmSetChartAxisY_PosY_Min.Text);
                }

                if (double.Parse(tbX_FrmSetChartAxisY_LoadY_Max.Text) < MainForm.mainform.m_AxTeechart.Axis.Right.Maximum)
                {
                    MainForm.mainform.m_AxTeechart.Axis.Right.Minimum = double.Parse(tbX_FrmSetChartAxisY_LoadY_Min.Text);
                    MainForm.mainform.m_AxTeechart.Axis.Right.Maximum = double.Parse(tbX_FrmSetChartAxisY_LoadY_Max.Text);
                }
                else
                {
                    MainForm.mainform.m_AxTeechart.Axis.Right.Maximum = double.Parse(tbX_FrmSetChartAxisY_LoadY_Max.Text);
                    MainForm.mainform.m_AxTeechart.Axis.Right.Minimum = double.Parse(tbX_FrmSetChartAxisY_LoadY_Min.Text);
                }

                if (double.Parse(tbX_FrmSetChartAxisY_ExtY_Max.Text) < MainForm.mainform.m_AxTeechart.Axis.Custom[0].Maximum)
                {
                    MainForm.mainform.m_AxTeechart.Axis.Custom[0].Minimum = double.Parse(tbX_FrmSetChartAxisY_ExtY_Min.Text);
                    MainForm.mainform.m_AxTeechart.Axis.Custom[0].Maximum = double.Parse(tbX_FrmSetChartAxisY_ExtY_Max.Text);
                }
                else
                {
                    MainForm.mainform.m_AxTeechart.Axis.Custom[0].Maximum = double.Parse(tbX_FrmSetChartAxisY_ExtY_Max.Text);
                    MainForm.mainform.m_AxTeechart.Axis.Custom[0].Minimum = double.Parse(tbX_FrmSetChartAxisY_ExtY_Min.Text);
                }

                if (double.Parse(tbX_FrmSetChartAxisY_CommandY_Max.Text) < MainForm.mainform.m_AxTeechart.Axis.Custom[1].Maximum)
                {
                    MainForm.mainform.m_AxTeechart.Axis.Custom[1].Minimum = double.Parse(tbX_FrmSetChartAxisY_CommandY_Min.Text);
                    MainForm.mainform.m_AxTeechart.Axis.Custom[1].Maximum = double.Parse(tbX_FrmSetChartAxisY_CommandY_Max.Text);
                }
                else
                {
                    MainForm.mainform.m_AxTeechart.Axis.Custom[1].Maximum = double.Parse(tbX_FrmSetChartAxisY_CommandY_Max.Text);
                    MainForm.mainform.m_AxTeechart.Axis.Custom[1].Minimum = double.Parse(tbX_FrmSetChartAxisY_CommandY_Min.Text);
                }

                MainForm.mainform.m_AxTeechart.Axis.Bottom.Maximum = double.Parse(tbX_FrmSetChartAxisY_TimeY_Max.Text);

                MainForm.mainform.AxisXMax = double.Parse(tbX_FrmSetChartAxisY_TimeY_Max.Text);
                MainForm.mainform.nTotal = MainForm.mainform.AxisXMax / MainForm.mainform.dStep;

                MainForm.mainform.Chart_Pos_Step = double.Parse(cbX_Pos_Range.Text);
                MainForm.mainform.Chart_Load_Step = double.Parse(cbX_Load_Range.Text);
                MainForm.mainform.Chart_Ext_Step = double.Parse(cbX_Ext_Range.Text);
                MainForm.mainform.Chart_Command_Step = double.Parse(cbX_Command_Range.Text);
                MainForm.mainform.Chart_X_Step = double.Parse(cbX_Time_Range.Text);
            }
            catch (Exception ex) {
                MessageBox.Show("设置坐标轴问题:{0}",ex.ToString());
            }

            this.Close();
        }

        private void btn_FrmSerAxisY_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 校验各项数据
        /// </summary>
        /// <returns></returns>
        private bool ValidityCheck()
        {
            //bool bCheckState = true;
            if (string.IsNullOrEmpty(tbX_FrmSetChartAxisY_PosY_Max.Text))
            {
                tbX_FrmSetChartAxisY_PosY_Max.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbX_FrmSetChartAxisY_LoadY_Max.Text))
            {
                tbX_FrmSetChartAxisY_LoadY_Max.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbX_FrmSetChartAxisY_ExtY_Max.Text))
            {
                tbX_FrmSetChartAxisY_ExtY_Max.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbX_FrmSetChartAxisY_CommandY_Max.Text))
            {
                tbX_FrmSetChartAxisY_CommandY_Max.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbX_FrmSetChartAxisY_PosY_Min.Text))
            {
                tbX_FrmSetChartAxisY_PosY_Min.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbX_FrmSetChartAxisY_LoadY_Min.Text))
            {
                tbX_FrmSetChartAxisY_LoadY_Min.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbX_FrmSetChartAxisY_ExtY_Min.Text))
            {
                tbX_FrmSetChartAxisY_ExtY_Min.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbX_FrmSetChartAxisY_CommandY_Min.Text))
            {
                tbX_FrmSetChartAxisY_CommandY_Min.Focus();
                return false;
            }


            if (double.Parse((tbX_FrmSetChartAxisY_PosY_Min.Text)) >= double.Parse((tbX_FrmSetChartAxisY_PosY_Max.Text)))
            {
                MessageBox.Show("位移坐标最小值不能大于最大值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmSetChartAxisY_PosY_Min.Focus();
                return false;
            }

            if (double.Parse((tbX_FrmSetChartAxisY_LoadY_Min.Text)) >= double.Parse((tbX_FrmSetChartAxisY_LoadY_Max.Text)))
            {
                MessageBox.Show("试验力坐标最小值不能大于最大值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmSetChartAxisY_LoadY_Min.Focus();
                return false;
            }

            if (double.Parse((tbX_FrmSetChartAxisY_ExtY_Min.Text)) >= double.Parse((tbX_FrmSetChartAxisY_ExtY_Max.Text)))
            {
                MessageBox.Show("变形坐标最小值不能大于最大值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmSetChartAxisY_ExtY_Min.Focus();
                return false;
            }

            if (double.Parse((tbX_FrmSetChartAxisY_CommandY_Min.Text)) >= double.Parse((tbX_FrmSetChartAxisY_CommandY_Max.Text)))
            {
                MessageBox.Show("命令坐标最小值不能大于最大值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_FrmSetChartAxisY_CommandY_Min.Focus();
                return false;
            }

            if (cbX_Pos_Range.SelectedIndex == -1)
            {
                MessageBox.Show("位移坐标调整量程请选中一个值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbX_Pos_Range.Focus();
                return false;
            }

            if (cbX_Load_Range.SelectedIndex == -1)
            {
                MessageBox.Show("试验力坐标调整量程请选中一个值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbX_Load_Range.Focus();
                return false;
            }

            if (cbX_Ext_Range.SelectedIndex == -1)
            {
                MessageBox.Show("变形坐标调整量程请选中一个值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbX_Ext_Range.Focus();
                return false;
            }

            if (cbX_Command_Range.SelectedIndex == -1)
            {
                MessageBox.Show("命令坐标调整量程请选中一个值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbX_Command_Range.Focus();
                return false;
            }

            return true;
        }

    }
}
