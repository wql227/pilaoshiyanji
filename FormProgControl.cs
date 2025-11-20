using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doli.DoPE10;

namespace DoPENetConnect
{
    public partial class FormProgControl : Form
    {
        public enum CMDNAMES
        {
            POS,
            LOAD,
            POSKEEP,
            POSKEEPW,
            LOADKEEP,
            LOADKEEPW,
            WAVE,
            DELAY,
            HIGHPRESSURE,
            LOWPRESSURE,
            ENDED
        }

        public Dictionary<string,DoPE.DYN_WAVEFORM> ProgramWaveForm;
        public struct PROGSTATUS
        {
            public CMDNAMES currentCmd;
            public double IntervalKeepping;
            public string[] cmdParams;
        }
        /// <summary>
        /// element 0:cmd name
        /// </summary>
        public List<string[]> cmdDta=null; 
        public int currentCmdIndex = 0;
        public PROGSTATUS ProgStatus;


        public FormProgControl()
        {
            InitializeComponent();
            BuildParamsBeforeRun();
        }

        public void BuildParamsBeforeRun()
        {
            ProgramWaveForm = new Dictionary<string, DoPE.DYN_WAVEFORM>();
            ProgramWaveForm.Add("正弦波", DoPE.DYN_WAVEFORM.SINE);
            ProgramWaveForm.Add("三角波", DoPE.DYN_WAVEFORM.TRIANGLE);
            ProgramWaveForm.Add("方波", DoPE.DYN_WAVEFORM.RECTANGLE);
            ProgramWaveForm.Add("锯齿波", DoPE.DYN_WAVEFORM.SAW_TOOTH);
            ProgramWaveForm.Add("反向锯齿波", DoPE.DYN_WAVEFORM.SAW_TOOTH_INV);
            ProgramWaveForm.Add("脉冲波形", DoPE.DYN_WAVEFORM.PULSE);
        }

        public void SetCmdParmas(List<string[]> dta)
        {
            cmdDta = dta;
            currentCmdIndex = 0;
        }

        public void StartRunProgram()
        {
            string[] cmdParams = cmdDta[currentCmdIndex][2].Split(',');
            string[] cmd = new string[20];
            switch (cmdDta[currentCmdIndex][1]) {
                case "等速位移":
                    ProgStatus.currentCmd = CMDNAMES.POS;
                    cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("mm"));
                   cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("mm"));
                    //pos 指令
                   MainForm.mainform.MovePos(DoPE.CTRL.POS, double.Parse(cmd[0])/60, double.Parse(cmd[1]));
                    break;
                case "等速力":
                    ProgStatus.currentCmd = CMDNAMES.LOAD;
                    cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("kN"));
                    cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("kN"));
                    //pos 指令
                    MainForm.mainform.MovePos(DoPE.CTRL.LOAD, double.Parse(cmd[0])*1000, double.Parse(cmd[1])*1000);
                    break;
                case "位移保持":
                    {
                        double speed = 10;  //定义移动速度为10mm/s
                        //此处进行位移保持第一步，移动至指定位置
                        cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("mm"));
                        cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("s"));
                        //pos 指令
                        MainForm.mainform.MovePos(DoPE.CTRL.POS, speed, double.Parse(cmd[0]));
                        ProgStatus.currentCmd = CMDNAMES.POSKEEP;
                        ProgStatus.IntervalKeepping = double.Parse(cmd[1]);
                        break;
                    }
                case "力保持":
                    {
                        double speed = 0.1;  //定义速度0.1kN/s
                        //此处进行位移保持第一步，移动至指定位置
                        cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("mm"));
                        cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("s"));
                        //pos 指令
                        MainForm.mainform.MovePos(DoPE.CTRL.LOAD, speed, double.Parse(cmd[0]));
                        ProgStatus.currentCmd = CMDNAMES.LOADKEEP;
                        ProgStatus.IntervalKeepping = double.Parse(cmd[1]);
                        break;
                    }
                case "波形控制":
                    ProgStatus.currentCmd = CMDNAMES.WAVE;
                    cmd[0] = cmdParams[1].Split(':').ElementAt(1);   //波形
                    cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("mm"));//中值
                    cmd[2] = cmdParams[3].Split(':').ElementAt(1).Substring(0, cmdParams[3].Split(':').ElementAt(1).IndexOf("mm"));//振幅
                    cmd[3] = cmdParams[4].Split(':').ElementAt(1).Substring(0, cmdParams[4].Split(':').ElementAt(1).IndexOf("Hz"));//中值
                    cmd[4] = cmdParams[5].Split(':').ElementAt(1);//次数
                    cmd[5] = cmdParams[6].Split(':').ElementAt(1).Substring(0, cmdParams[6].Split(':').ElementAt(1).IndexOf("mm"));//趋近速度
                    cmd[6] = cmdParams[7].Split(':').ElementAt(1).Substring(0, cmdParams[7].Split(':').ElementAt(1).IndexOf("mm"));//目标值
                    //pos 指令
                    MainForm.mainform.MoveDynCycles(ProgramWaveForm[cmd[0]], false, DoPE.DYN_PEAKCTRL.ONE, DoPE.CTRL.POS, false, double.Parse(cmd[5])/60, double.Parse(cmd[1]), double.Parse(cmd[2]),0, 0, double.Parse(cmd[3]),int.Parse(cmd[4])*2, 0, double.Parse(cmd[1])+ double.Parse(cmd[2]), 0);
                    break;
                case "延时":
                    break;
                case "高压启动":
                    break;
                case "切换到低压":
                    break;
                case "试验结束":
                    break;
            }
            ProgStatus.cmdParams = cmd;
        }

        /// <summary>
        /// 按照特定模式保持
        /// </summary>
        /// <param name="ctrlMode"></param>
        public void WaitAfterKeepCmd(DoPE.CTRL ctrlMode)
        {
            if (ctrlMode == DoPE.CTRL.POS)
            {
                ProgStatus.currentCmd = CMDNAMES.POSKEEPW;
            }
            else if (ctrlMode == DoPE.CTRL.LOAD)
            {
                ProgStatus.currentCmd = CMDNAMES.LOADKEEPW;
            }
            MainForm.mainform.MoveHaultW(ctrlMode, ProgStatus.IntervalKeepping);   //保持
        }

    }
}
