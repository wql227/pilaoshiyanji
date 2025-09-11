using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalysis
{
    public partial class FrmSetting : Office2007Form
    {
        SettingClass setting = new SettingClass();

        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            LoadIni();
        }


        /// <summary>
        /// 加载配置文件
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Setting.ini");
            StringBuilder strTmp = new StringBuilder(255);

            #region 加载报告参数

            //报告名称
            IniFileHelper.GetIniString("Setting", "ReportTitle", "阻尼力-位移试验检测报告", strTmp, strTmp.Capacity);
            //tbX_EnvironmentTemperature.Text = strTmp.ToString();
            setting.EnvironmentTemperature = strTmp.ToString();

            //环境温度
            IniFileHelper.GetIniString("Setting", "EnvironmentTemperature", "29", strTmp, strTmp.Capacity);
            tbX_EnvironmentTemperature.Text = strTmp.ToString();
            setting.EnvironmentTemperature = strTmp.ToString();

            //试验温度
            IniFileHelper.GetIniString("Setting", "EnvironmentTemperature", "26", strTmp, strTmp.Capacity);
            tbX_ExperimentalTemperature.Text = strTmp.ToString();
            setting.ExperimentalTemperature = strTmp.ToString();

            //试验设备
            IniFileHelper.GetIniString("Setting", "TestingEquipment", "设备", strTmp, strTmp.Capacity);
            tbX_TestingEquipment.Text = strTmp.ToString();
            setting.TestingEquipment = strTmp.ToString();

            //试验规格
            IniFileHelper.GetIniString("Setting", "SampleSpecification", "规格", strTmp, strTmp.Capacity);
            tbX_SampleSpecification.Text = strTmp.ToString();
            setting.SampleSpecification = strTmp.ToString();

            //试验人员
            IniFileHelper.GetIniString("Setting", "Tester", "试验人员", strTmp, strTmp.Capacity);
            tbX_Tester.Text = strTmp.ToString();
            setting.Tester = strTmp.ToString();

            //审核人员
            IniFileHelper.GetIniString("Setting", "Auditor", "审核人员", strTmp, strTmp.Capacity);
            tbX_Auditor.Text = strTmp.ToString();
            setting.Auditor = strTmp.ToString();

            //控制方式
            IniFileHelper.GetIniString("Setting", "MoveCtrl", "POS", strTmp, strTmp.Capacity);
            cbX_MoveCtrl.Text = strTmp.ToString();
            setting.MoveCtrl = strTmp.ToString();

            //波形显示
            IniFileHelper.GetIniString("Setting", "WaveCtrl", "余弦波", strTmp, strTmp.Capacity);
            tbX_WaveCtrl.Text = strTmp.ToString();
            setting.WaveCtrl = strTmp.ToString();

            //中值
            IniFileHelper.GetIniString("Setting", "Offset", "0", strTmp, strTmp.Capacity);
            tbX_Offset.Text = strTmp.ToString();
            setting.MoveOffset = strTmp.ToString();

            //振幅
            IniFileHelper.GetIniString("Setting", "Amplitude", "0", strTmp, strTmp.Capacity);
            tbX_Amplitude.Text = strTmp.ToString();
            setting.MoveAmplitude = strTmp.ToString();

            //频率
            IniFileHelper.GetIniString("Setting", "Frequency", "0", strTmp, strTmp.Capacity);
            tbX_Frequency.Text = strTmp.ToString();
            setting.MoveFrequency = strTmp.ToString();

            #endregion

            #region 图表调整

            //位移Y轴最大值
            IniFileHelper.GetIniString("FrmSetChartAxisY", "PositionY_MAX", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());
            tbX_FrmSetChartAxisY_PosY_Max.Text = strTmp.ToString();


            //位移Y轴最小值
            IniFileHelper.GetIniString("FrmSetChartAxisY", "PositionY_MIN", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());
            tbX_FrmSetChartAxisY_PosY_Min.Text = strTmp.ToString();

            //位移Y轴调整量程
            IniFileHelper.GetIniString("FrmSetChartAxisY", "PosRange", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());
            cbX_Pos_Range.Text = strTmp.ToString();

            //阻尼力Y轴最大值
            IniFileHelper.GetIniString("FrmSetChartAxisY", "LoadY_MAX", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());
            tbX_FrmSetChartAxisY_LoadY_Max.Text = strTmp.ToString();

            //阻尼力Y轴最小值
            IniFileHelper.GetIniString("FrmSetChartAxisY", "LoadY_MIN", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());
            tbX_FrmSetChartAxisY_LoadY_Min.Text = strTmp.ToString();

            //阻尼力Y轴调整量程
            IniFileHelper.GetIniString("FrmSetChartAxisY", "LoadRange", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());
            cbX_Load_Range.Text = strTmp.ToString();

            #endregion

        }

        private void brnX_OK_Click(object sender, EventArgs e)
        {
            WriteIni();
        }

        private void brnX_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 写入配置文件
        /// </summary>
        public void WriteIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Setting.ini");

            #region 报告参数
            //环境温度
            IniFileHelper.WriteIniString("Setting", "EnvironmentTemperature", tbX_EnvironmentTemperature.Text.ToString());
            setting.EnvironmentTemperature = tbX_EnvironmentTemperature.Text.ToString();

            //试验温度
            IniFileHelper.WriteIniString("Setting", "EnvironmentTemperature", tbX_ExperimentalTemperature.Text.ToString());
            setting.EnvironmentTemperature = tbX_ExperimentalTemperature.Text.ToString();

            //试验设备
            IniFileHelper.WriteIniString("Setting", "TestingEquipment", tbX_TestingEquipment.Text.ToString());
            setting.EnvironmentTemperature = tbX_TestingEquipment.Text.ToString();

            //试验规格
            IniFileHelper.WriteIniString("Setting", "SampleSpecification", tbX_SampleSpecification.Text.ToString());
            setting.EnvironmentTemperature = tbX_SampleSpecification.Text.ToString();

            //试验人员
            IniFileHelper.WriteIniString("Setting", "Tester", tbX_Tester.Text.ToString());
            setting.EnvironmentTemperature = tbX_Tester.Text.ToString();

            //审核人员
            IniFileHelper.WriteIniString("Setting", "Auditor", tbX_Auditor.Text.ToString());
            setting.EnvironmentTemperature = tbX_Auditor.Text.ToString();

            //控制方式
            IniFileHelper.WriteIniString("Setting", "MoveCtrl", cbX_MoveCtrl.Text);
            setting.MoveCtrl = cbX_MoveCtrl.Text.ToString();

            //波形显示
            IniFileHelper.WriteIniString("Setting", "WaveCtrl", tbX_WaveCtrl.Text);
            setting.WaveCtrl = tbX_WaveCtrl.Text;

            //中值
            IniFileHelper.WriteIniString("Setting", "Offset", tbX_WaveCtrl.Text);
            setting.MoveOffset = tbX_WaveCtrl.Text.ToString();

            //振幅
            IniFileHelper.WriteIniString("Setting", "Amplitude", tbX_WaveCtrl.Text);
            setting.MoveAmplitude = tbX_WaveCtrl.Text.ToString();

            //频率
            IniFileHelper.WriteIniString("Setting", "Frequency", tbX_Frequency.Text);
            setting.MoveFrequency = tbX_Frequency.Text.ToString();

            #endregion

            #region 图表调整

            //位移Y轴最大值
            IniFileHelper.WriteIniString("FrmSetChartAxisY", "PositionY_MAX", tbX_FrmSetChartAxisY_PosY_Max.Text);
            setting.PosYAxisMax = double.Parse(tbX_FrmSetChartAxisY_PosY_Max.Text.ToString());

            //位移Y轴最小值
            IniFileHelper.WriteIniString("FrmSetChartAxisY", "PositionY_MIN", tbX_FrmSetChartAxisY_PosY_Min.Text);
            setting.PosYAxisMax = double.Parse(tbX_FrmSetChartAxisY_PosY_Min.Text);

            //位移Y轴调整量程
            IniFileHelper.WriteIniString("FrmSetChartAxisY", "PosRange", cbX_Pos_Range.Text);
            setting.PosYAxisMax = double.Parse(cbX_Pos_Range.Text);

            //阻尼力Y轴最大值
            IniFileHelper.WriteIniString("FrmSetChartAxisY", "LoadY_MAX", tbX_FrmSetChartAxisY_LoadY_Max.Text);
            setting.PosYAxisMax = double.Parse(tbX_FrmSetChartAxisY_LoadY_Max.Text.ToString());

            //阻尼力Y轴最小值
            IniFileHelper.WriteIniString("FrmSetChartAxisY", "LoadY_MIN", tbX_FrmSetChartAxisY_LoadY_Min.Text);
            setting.PosYAxisMax = double.Parse(tbX_FrmSetChartAxisY_LoadY_Min.Text.ToString());

            //阻尼力Y轴调整量程
            IniFileHelper.WriteIniString("FrmSetChartAxisY", "LoadRange", cbX_Load_Range.Text);
            setting.PosYAxisMax = double.Parse(cbX_Load_Range.Text.ToString());

            #endregion
        }
    }
}
