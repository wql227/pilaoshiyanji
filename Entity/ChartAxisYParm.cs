using System;


namespace DoPENetConnect
{
    /// <summary>
    /// 设置Y轴表示区间
    /// </summary>
    public class ChartAxisYParm
    {
        /// <summary>
        /// 设置项名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 区间最小值
        /// </summary>
        public double Minimum { get; set; }
        /// <summary>
        /// 区间最大值
        /// </summary>
        public double Maximum { get; set; }
        /// <summary>
        /// 区间间隔
        /// </summary>
        public double Interval { get; set; }
    }

}