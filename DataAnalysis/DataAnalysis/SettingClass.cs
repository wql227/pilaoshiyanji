using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis
{
    public class SettingClass
    {
        #region 报告参数
        /// <summary>
        /// 报告名称
        /// </summary>
        public string ReportTitle = "";

        /// <summary>
        /// 环境温度
        /// </summary>
        public string EnvironmentTemperature = "30℃";

        /// <summary>
        /// 实验温度
        /// </summary>
        public string ExperimentalTemperature = "29℃";

        /// <summary>
        /// 试验设备
        /// </summary>
        public string TestingEquipment = "疲劳试验机";

        /// <summary>
        /// 试样规格
        /// </summary>
        public string SampleSpecification = "123";

        /// <summary>
        /// 试验人员
        /// </summary>
        public string Tester = "测试人";

        /// <summary>
        /// 审核人员
        /// </summary>
        public string Auditor = "审核员";

        /// <summary>
        /// 控制方式
        /// </summary>
        public string MoveCtrl = "";

        /// <summary>
        /// 波形显示
        /// </summary>
        public string WaveCtrl = "";

        /// <summary>
        /// 中值
        /// </summary>
        public string MoveOffset = "";

        /// <summary>
        /// 振幅
        /// </summary>
        public string MoveAmplitude = "";

        /// <summary>
        /// 频率
        /// </summary>
        public string MoveFrequency = "";

        #endregion

        #region 图表参数

        /// <summary>
        /// 阻尼力Y轴最大值
        /// </summary>
        public double LoadYAxisMax = 1.0;

        /// <summary>
        /// 阻尼力Y轴最小值
        /// </summary>
        public double LoadYAxisMin = 1.0;

        /// <summary>
        /// 阻尼力Y轴调整量程
        /// </summary>
        public double LoadYAxisStep = 1.0;

        /// <summary>
        /// 位移Y轴最大值
        /// </summary>
        public double PosYAxisMax = 1.0;

        /// <summary>
        /// 位移Y轴最大值
        /// </summary>
        public double PosYAxisMin = 1.0;

        /// <summary>
        /// 位移Y轴最大值
        /// </summary>
        public double PosYAxisStep = 1.0;

        #endregion


    }
}
