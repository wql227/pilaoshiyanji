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
        }


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
            tbX_FrmSetChartAxisY_TimeY_Min.Text = strTmp.ToString();

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

            strTmp = tbX_FrmSetChartAxisY_CommandY_Min.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "CommandY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_CommandY_Min.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "CommandY_MIN", strTmp);

            strTmp = tbX_FrmSetChartAxisY_TimeY_Max.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "TimeX_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_TimeY_Max.Text.ToString();
            IniFileHelper.WriteIniString(strConfigSetion, "TimeX_MIN", strTmp);
        }


        private void btn_FrmSerAxisY_OK_Click(object sender, EventArgs e)
        {
            if (!ValidityCheck())
            {
                MessageBox.Show("数据校验不通过", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WriteIni();

            MainForm.mainform.chart_machine.ChartAreas[0].AxisY.Maximum = double.Parse(tbX_FrmSetChartAxisY_PosY_Max.Text);
            MainForm.mainform.chart_machine.ChartAreas[0].AxisY.Minimum = double.Parse(tbX_FrmSetChartAxisY_PosY_Min.Text);

            MainForm.mainform.chart_machine.ChartAreas[0].AxisY2.Maximum = double.Parse(tbX_FrmSetChartAxisY_LoadY_Max.Text);
            MainForm.mainform.chart_machine.ChartAreas[0].AxisY2.Minimum = double.Parse(tbX_FrmSetChartAxisY_LoadY_Min.Text);

            MainForm.mainform.chart_machine.ChartAreas[0].AxisX.Maximum = double.Parse(tbX_FrmSetChartAxisY_TimeY_Max.Text);
            MainForm.mainform.AxisXMax = double.Parse(tbX_FrmSetChartAxisY_TimeY_Max.Text);
            MainForm.mainform.nTotal = MainForm.mainform.AxisXMax / MainForm.mainform.dStep;

            MainForm.mainform.Chart_Pos_Step = double.Parse(cbX_Pos_Range.Text);
            MainForm.mainform.Chart_Load_Step = double.Parse(cbX_Load_Range.Text);
            MainForm.mainform.Chart_Ext_Step = double.Parse(cbX_Ext_Range.Text);
            MainForm.mainform.Chart_Command_Step = double.Parse(cbX_Command_Range.Text);

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

            if (double.Parse((tbX_FrmSetChartAxisY_CommandY_Min.Text)) > double.Parse((tbX_FrmSetChartAxisY_CommandY_Max.Text)))
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
