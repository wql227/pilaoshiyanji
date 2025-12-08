using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoPENetConnect
{
    public class LogDataItem
    {

        /// <summary>
        /// 控制器通道号
        /// </summary>
        public int ChannelNo { get; set; }

        /// <summary>
        /// 每行日志内容
        /// </summary>
        public string LogLine { get; set; } // 格式: "time,pos,load,cycles,half_cycles"

        public LogDataItem(int channelNo, string logLine)
        {
            ChannelNo = channelNo;
            LogLine = logLine;
        }

        public LogDataItem(string logLine)
        {
            LogLine = logLine;
        }
    }
}
