using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoPENetConnect
{
    public class ProtectOption
    {
        /// <summary>
        /// 触发保护停机的方式，停机，Halt等
        /// </summary>
        public string ProtectOptionType = "";

        #region 位移峰谷值保护
        /// <summary>
        /// 位移峰值外保护
        /// </summary>
        public double ProtectOption_PosMaxOut = 0.0;

        /// <summary>
        /// 位移峰值外保护生效
        /// </summary>
        public bool ProtectOption_PosMaxOut_Effect = false;

        /// <summary>
        /// 位移峰值内保护
        /// </summary>
        public double ProtectOption_PosMaxIn = 0.0;

        /// <summary>
        /// 位移峰值内保护生效
        /// </summary>
        public bool ProtectOption_PosMaxIn_Effect = false;

        /// <summary>
        /// 位移谷值外保护
        /// </summary>
        public double ProtectOption_PosMinOut = 0.0;

        /// <summary>
        /// 位移谷值外保护生效
        /// </summary>
        public bool ProtectOption_PosMinOut_Effect = false;

        /// <summary>
        /// 位移谷值内保护
        /// </summary>
        public double ProtectOption_PosMinIn = 0.0;

        /// <summary>
        /// 位移谷值内保护生效
        /// </summary>
        public bool ProtectOption_PosMinIn_Effect = false;

        #endregion 位移峰谷值保护

        #region 试验力峰谷值保护
        /// <summary>
        /// 试验力峰值外保护
        /// </summary>
        public double ProtectOption_LoadMaxOut = 0.0;

        /// <summary>
        /// 试验力峰值外保护生效
        /// </summary>
        public bool ProtectOption_LoadMaxOut_Effect = false;

        /// <summary>
        /// 试验力峰值内保护
        /// </summary>
        public double ProtectOption_LoadMaxIn = 0.0;

        /// <summary>
        /// 试验力峰值内保护生效
        /// </summary>
        public bool ProtectOption_LoadMaxIn_Effect = false;

        /// <summary>
        /// 试验力谷值外保护
        /// </summary>
        public double ProtectOption_LoadMinOut = 0.0;

        /// <summary>
        /// 试验力谷值外保护生效
        /// </summary>
        public bool ProtectOption_LoadMinOut_Effect = false;

        /// <summary>
        /// 试验力谷值内保护
        /// </summary>
        public double ProtectOption_LoadMinIn = 0.0;

        /// <summary>
        /// 试验力谷值内保护生效
        /// </summary>
        public bool ProtectOption_LoadMinIn_Effect = false;
        #endregion 试验力峰谷值保护

        #region 变形峰谷值保护
        /// <summary>
        /// 变形峰值外保护
        /// </summary>
        public double ProtectOption_ExtMaxOut = 0.0;

        /// <summary>
        /// 变形峰值外保护生效
        /// </summary>
        public bool ProtectOption_ExtMaxOut_Effect = false;

        /// <summary>
        /// 变形峰值内保护
        /// </summary>
        public double ProtectOption_ExtMaxIn = 0.0;

        /// <summary>
        /// 变形峰值内保护生效
        /// </summary>
        public bool ProtectOption_ExtMaxIn_Effect = false;

        /// <summary>
        /// 变形谷值外保护
        /// </summary>
        public double ProtectOption_ExtMinOut = 0.0;

        /// <summary>
        /// 变形谷值外保护生效
        /// </summary>
        public bool ProtectOption_ExtMinOut_Effect = false;

        /// <summary>
        /// 变形谷值内保护
        /// </summary>
        public double ProtectOption_ExtMinIn = 0.0;

        /// <summary>
        /// 变形谷值内保护生效
        /// </summary>
        public bool ProtectOption_ExtMinIn_Effect = false;
        #endregion 变形峰谷值保护

        #region 系统保护
        /// <summary>
        /// 试验力以百分比设定保护范围生效
        /// </summary>
        public bool ProtectOption_OverLoadPercent_Flag = false;

        /// <summary>
        /// 实验力以百分比设定保护范围
        /// </summary>
        public double ProtectOption_OverLoadPercent = 0.0;

        /// <summary>
        /// 试验力以数值设定保护范围生效
        /// </summary>
        public bool ProtectOption_OverLoadForce_Flag = false;

        /// <summary>
        /// 实验力以数值设定保护范围
        /// </summary>
        public double ProtectOption_OverLoadForce = 0.0;


        #endregion 系统保护

    }
}
