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
    public enum CMDNAMES
    {
        POS,
        POSLOAD,
        LOAD,
        LOADPOS,
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
    public partial class FormProgControl : Form
    {


        public Dictionary<string, DoPE.DYN_WAVEFORM> ProgramWaveForm;
        public struct PROGSTATUS
        {
            public CMDNAMES currentCmd;
            public double IntervalKeepping;
            public string[] cmdParams;
            public string[] endGoal;
            public DateTime oldDateTime;
            public int TimesForWave;
            public double startPos;
            //current value
            public double pos;
            public double load;
            public double extension;
            //counter for cycles
            public int[] currentCycleCountEveryStep;
            public int currentCycleSet;

        }
        /// <summary>
        /// element 0:cmd name
        /// </summary>
        public List<string[]> cmdDta = null;
        public int currentCmdIndex = -1;
        public PROGSTATUS ProgStatus;
        public bool isRunning = false;

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

        public void SetCmdParmas(List<string[]> dta,double startPos,double startLoad,double startExtession)
        {
            cmdDta = dta;
            currentCmdIndex = 0;
            ProgStatus.startPos = startPos;
            ProgStatus.pos = startPos;
            ProgStatus.load = startLoad;
            ProgStatus.extension = startExtession;
            ProgStatus.currentCycleCountEveryStep = new int[dta.Count];    //创建每一步对应的循环数存储数组
            for(int i=0;i< dta.Count; i++) {
                ProgStatus.currentCycleCountEveryStep[i] = 0;
            }
            
        }


        public void StartRunProgram()
        {
            isRunning = true;
            RunCmd();
        }
        int aaa = 0;
        public void RunCmd()
        {
            if (currentCmdIndex >= cmdDta.Count) {    //超出指令当前指令上限   结束？
                return;
            }
            MainForm.mainform.SetDataGridViewSelected(currentCmdIndex, true);
            string[] cmdParams = cmdDta[currentCmdIndex][2].Split(',');   //获取指令内容
            string[] cmd = new string[20];
            if (ProgStatus.endGoal == null)   //获取最终目标值
            {
                ProgStatus.endGoal = new string[8];
            }
            if (cmdDta[currentCmdIndex][4] == "")
                ProgStatus.currentCycleSet = 0;
            else
                ProgStatus.currentCycleSet = int.Parse(cmdDta[currentCmdIndex][4]);   //获取当前步对应的循环次数设置

            switch (cmdDta[currentCmdIndex][1]) {
                case "等速位移":
                    cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("mm"));
                    if (cmdParams[2].Contains("位移达到"))
                    {
                        ProgStatus.currentCmd = CMDNAMES.POS;
                        cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("mm"));
                        ProgStatus.endGoal[0] = cmd[1];
                        direction = DirectionAdjust(ProgStatus.pos, double.Parse(cmd[1]));

                        //pos 指令
                        //MainForm.mainform.MovePos(DoPE.CTRL.POS, double.Parse(cmd[0]) / 60, double.Parse(cmd[1]));
                        MainForm.mainform.MovePosExt(DoPE.CTRL.POS, double.Parse(cmd[0]) / 60, DoPE.LIMITMODE.NOT_ACTIVE,
                            0, DoPE.CTRL.POS, double.Parse(cmd[1]), DoPE.DESTMODE.DEST_POSITION);
                    }
                    else if (cmdParams[2].Contains("力达到"))
                    {
                        ProgStatus.currentCmd = CMDNAMES.POSLOAD;
                        cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("kN"));
                        ProgStatus.endGoal[0] = cmd[1];
                        direction = DirectionAdjust(ProgStatus.load, double.Parse(cmd[1]));

                        //pos 指令
                        //MainForm.mainform.MovePos(DoPE.CTRL.POS, double.Parse(cmd[0]) / 60, double.Parse(cmd[1])*1000);
                        MainForm.mainform.MovePosExt(DoPE.CTRL.POS, double.Parse(cmd[0]) / 60, DoPE.LIMITMODE.NOT_ACTIVE,
                        0, DoPE.CTRL.LOAD, double.Parse(cmd[1])*1000, DoPE.DESTMODE.DEST_POSITION);
                    }
                    break;
                case "等速力":
                    cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("kN"));
                    if (cmdParams[2].Contains("位移达到"))
                    {
                        ProgStatus.currentCmd = CMDNAMES.LOADPOS;
                        cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("mm"));

                        ProgStatus.endGoal[0] = cmd[1];
                        direction = DirectionAdjust(ProgStatus.load, double.Parse(cmd[1]));
                        //MainForm.mainform.MovePos(DoPE.CTRL.LOAD, double.Parse(cmd[0]) * 1000, double.Parse(cmd[1]) * 1000);
                        MainForm.mainform.MovePosExt(DoPE.CTRL.LOAD, double.Parse(cmd[0]) * 1000, DoPE.LIMITMODE.NOT_ACTIVE,
                        0, DoPE.CTRL.POS, double.Parse(cmd[1]), DoPE.DESTMODE.DEST_POSITION);
                    }
                    else if (cmdParams[2].Contains("力达到"))
                    {
                        ProgStatus.currentCmd = CMDNAMES.LOAD;
                        cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("kN"));
                       
                        ProgStatus.endGoal[0] = cmd[1];
                        direction = DirectionAdjust(ProgStatus.load, double.Parse(cmd[1]));
                        //MainForm.mainform.MovePos(DoPE.CTRL.LOAD, double.Parse(cmd[0]) * 1000, double.Parse(cmd[1]) * 1000);
                        MainForm.mainform.MovePosExt(DoPE.CTRL.LOAD, double.Parse(cmd[0])*1000, DoPE.LIMITMODE.NOT_ACTIVE,
                        0, DoPE.CTRL.LOAD, double.Parse(cmd[1]) * 1000, DoPE.DESTMODE.DEST_POSITION);
                    }
                    break;
                case "位移保持":
                    {
                        double speed = 10;  //定义移动速度为10mm/s
                        //此处进行位移保持第一步，移动至指定位置
                        cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("mm"));
                        cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("s"));
                        //pos 指令
                        direction = DirectionAdjust(ProgStatus.pos, double.Parse(cmd[0]));
                        MainForm.mainform.MovePos(DoPE.CTRL.POS, speed, double.Parse(cmd[0]));
                        ProgStatus.currentCmd = CMDNAMES.POSKEEP;
                        ProgStatus.IntervalKeepping = double.Parse(cmd[1]);
                        break;
                    }
                case "力保持":
                    {
                        double speed = 0.1;  //定义速度0.1kN/s
                        //此处进行位移保持第一步，移动至指定位置
                        cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("kN"));
                        cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("s"));
                        //pos 指令
                        direction = DirectionAdjust(ProgStatus.load, double.Parse(cmd[0]));
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
                    ProgStatus.TimesForWave = 0;//计数器清零
                                                //pos 指令
                    aaa++;
                    Console.WriteLine("wave{0}", aaa);
                    direction = DirectionAdjust(ProgStatus.pos, double.Parse(cmd[1]));
                    MainForm.mainform.MoveDynCycles(ProgramWaveForm[cmd[0]], false, DoPE.DYN_PEAKCTRL.ONE, DoPE.CTRL.POS, false, double.Parse(cmd[5])/60, double.Parse(cmd[1]), double.Parse(cmd[2]),0, 0, double.Parse(cmd[3]),int.Parse(cmd[4])*2, 0, double.Parse(cmd[1])+ double.Parse(cmd[2]), 0);
                    break;
                case "延时":
                    ProgStatus.currentCmd = CMDNAMES.DELAY;
                    cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("s"));  //延时值
                    ProgStatus.oldDateTime = DateTime.Now;
                    ProgStatus.IntervalKeepping = double.Parse(cmd[0]);
                    MainForm.mainform.MoveHaultW(DoPE.CTRL.POS, double.Parse(cmd[0]));   //保持
                    break;
                case "高压启动":
                    ProgStatus.currentCmd = CMDNAMES.HIGHPRESSURE;
                    MainForm.mainform.FormFloat_btnX_SetHigh_Click();   //保持
                    break;
                case "切换到低压":
                    ProgStatus.currentCmd = CMDNAMES.HIGHPRESSURE;
                    MainForm.mainform.FormFloat_btnX_SetLow_Click();   //保持
                    break;
                case "试验结束":
                    ProgStatus.currentCmd = CMDNAMES.ENDED;
                    MainForm.mainform.FormFloat_bntX_MoveHalt_Click();   //保持
                    break;
            }
            ProgStatus.cmdParams = cmd;
        }

        public void WaveTimesInc()
        {
            ProgStatus.TimesForWave++;
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

        int direction = 0;
        public int DirectionAdjust(double origin,double finalval)
        {
           // Console.WriteLine("direction：{0}：{1}", origin, finalval);
            if (finalval > origin)
                return 0;
            else if (finalval < origin)
                return 1;
            else
                return 2;
        }


        // DateTime oldDataTime;
        /// <summary>
        /// 
        /// </summary> 
        /// 
        public void CmdSwitch(double pos, double load, double extension,int dynCycle)
        {
            ProgStatus.pos = pos;
            ProgStatus.load = load;
            ProgStatus.extension = extension;

            Console.WriteLine("glm-current params：{0}：{1}：{2}：{3}", pos, load, extension,dynCycle);
            bool switchOrNot = false;
            switch (ProgStatus.currentCmd) {
                case CMDNAMES.POS:     //等速位移-位移达到
                    Console.WriteLine("direction-res：{0}", direction);
                    if (direction==0&&pos >= double.Parse(ProgStatus.cmdParams[1]))   //达到目标
                    {
                        Console.WriteLine("glm-current params1");
                        switchOrNot = true;

                    }
                    else if(direction==1&&pos <= double.Parse(ProgStatus.cmdParams[1]))   //达到目标
                    {
                        Console.WriteLine("glm-current params2");
                        switchOrNot = true;

                    }
                    break;
                case CMDNAMES.POSLOAD:    //等速位移-力达到
                    Console.WriteLine("direction-res：{0}", direction);
                    if (direction == 0 && load >= double.Parse(ProgStatus.cmdParams[1]))   //达到目标
                    {
                        Console.WriteLine("glm-current params3");
                        switchOrNot = true;

                    }
                    else if (direction == 1 && load <= double.Parse(ProgStatus.cmdParams[1]))   //达到目标
                    {
                        Console.WriteLine("glm-current params4");
                        switchOrNot = true;

                    }
                    break;
                case CMDNAMES.LOAD:       //等速力--力达到
                    Console.WriteLine("direction-res：{0}", direction);
                    if (direction==0&&load >= double.Parse(ProgStatus.cmdParams[1]))
                    {
                        Console.WriteLine("glm-current params5");
                        switchOrNot = true;
                    }
                    else if (direction == 1 && load <= double.Parse(ProgStatus.cmdParams[1]))
                    {
                        Console.WriteLine("glm-current params6");
                        switchOrNot = true;
                    }
                    break;
                case CMDNAMES.LOADPOS:   //等速力--位移达到
                    Console.WriteLine("direction-res：{0}", direction);
                    if (direction == 0 && pos >= double.Parse(ProgStatus.cmdParams[1]))
                    {
                        Console.WriteLine("glm-current params7");
                        switchOrNot = true;
                    }
                    else if (direction == 1 && pos <= double.Parse(ProgStatus.cmdParams[1]))
                    {
                        Console.WriteLine("glm-current params8");
                        switchOrNot = true;
                    }
                    break;
                case CMDNAMES.POSKEEP:
                    Console.WriteLine("direction-res：{0}", direction);
                    if (direction == 0 && pos >= double.Parse(ProgStatus.cmdParams[0]))   //达到目标
                    {
                        Console.WriteLine("glm-current params9");
                        ProgStatus.oldDateTime = DateTime.Now;
                        WaitAfterKeepCmd(DoPE.CTRL.POS);
                        return;
                    }
                    else if (direction == 1 && pos <= double.Parse(ProgStatus.cmdParams[0]))   //达到目标
                    {
                        Console.WriteLine("glm-current params10");
                        ProgStatus.oldDateTime = DateTime.Now;
                        WaitAfterKeepCmd(DoPE.CTRL.POS);
                        return;
                    }
                        break;
                case CMDNAMES.POSKEEPW:
                    DateTime currentDateTime = DateTime.Now;
                    TimeSpan timeElpse = currentDateTime - ProgStatus.oldDateTime;
                    int seconds = (int)timeElpse.TotalSeconds;
                    if (ProgStatus.IntervalKeepping>0&&seconds >= ProgStatus.IntervalKeepping)
                    {
                        Console.WriteLine("glm-current params11");
                        switchOrNot = true;
                    }
                    break;
                case CMDNAMES.LOADKEEP:
                    Console.WriteLine("direction-res：{0}", direction);
                    if (direction == 0 && load >= double.Parse(ProgStatus.cmdParams[0]))
                    {
                        Console.WriteLine("glm-current params12");
                        ProgStatus.oldDateTime = DateTime.Now;
                        WaitAfterKeepCmd(DoPE.CTRL.LOAD);
                        return;
                    }
                    else if (direction == 1 && load <= double.Parse(ProgStatus.cmdParams[0]))
                    {
                        Console.WriteLine("glm-current params13");
                        ProgStatus.oldDateTime = DateTime.Now;
                        WaitAfterKeepCmd(DoPE.CTRL.LOAD);
                        return;
                    }
                    break;
                case CMDNAMES.LOADKEEPW:
                    DateTime currentDateTime1 = DateTime.Now;
                    TimeSpan timeElpse1 = currentDateTime1 - ProgStatus.oldDateTime;
                    int seconds1 = (int)timeElpse1.TotalSeconds;
                    if (ProgStatus.IntervalKeepping > 0 && seconds1 >= ProgStatus.IntervalKeepping)
                    {
                        switchOrNot = true;
                    }
                    break;
                case CMDNAMES.WAVE:
                    if (dynCycle==1)
                    {
                        switchOrNot = true;
                    }
                    break;
                case CMDNAMES.ENDED:
                    MainForm.mainform.FormFloat_bntX_MoveHalt_Click();
                    currentCmdIndex = -1;    //试验结束后将当前指令索引号置为-1
                    break;
                case CMDNAMES.DELAY:
                    DateTime currentDateTime2 = DateTime.Now;
                    TimeSpan timeElpse2 = currentDateTime2 - ProgStatus.oldDateTime;
                    int seconds2 = (int)timeElpse2.TotalSeconds;
                    if (ProgStatus.IntervalKeepping > 0 && seconds2 >= ProgStatus.IntervalKeepping)
                    {
                        switchOrNot = true;
                    }
                    break;
            }

            if (switchOrNot)
            {
                
                MainForm.mainform.SetDataGridViewSelected(currentCmdIndex, false); //当前行设为非选中状态
                if(ProgStatus.currentCycleCountEveryStep[currentCmdIndex]< ProgStatus.currentCycleSet)
                    ProgStatus.currentCycleCountEveryStep[currentCmdIndex]++;

                if (ProgStatus.currentCycleCountEveryStep[currentCmdIndex] == ProgStatus.currentCycleSet) {   //达到循环次数进入下一步
                    if (currentCmdIndex + 1 <= cmdDta.Count) {    //不是最后一部直接切换
                        currentCmdIndex += 1;
                    }

                    //ProgStatus.currentCycleCountEveryStep[currentCmdIndex] = 0;     //次数累计清零
                }
                else    //如果没有达到次数则直接跳转
                    currentCmdIndex = int.Parse(cmdDta[currentCmdIndex][3])-1;
                RunCmd();
            }
        }

        public void StopProgram()
        {
            isRunning = false;
            currentCmdIndex = -1;
        }
        public double GetOriginPos()
        {
            return ProgStatus.startPos;
        }


        public void GetMaxAndMinVal(ref double posMax, ref double posMin, ref double loadMax, ref double loadMin, ref double extMax, ref double extMin)
        {
            for (int i = 0; i < cmdDta.Count; i++)
            {
                string[] cmdParams = cmdDta[i][2].Split(',');   //获取指令内容
                switch (cmdDta[i][1])
                {
                    case "等速位移":                       
                        if (cmdParams[2].Contains("位移达到"))
                        {
                            double posVal = double.Parse( cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("mm")));

                            if (posMax < posVal) posMax = posVal;
                            if (posMin > posVal) posMin = posVal;
                        }
                        else if (cmdParams[2].Contains("力达到"))
                        {
                            double loadVal = double.Parse(cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("kN")));

                            if (loadMax < loadVal) loadMax = loadVal;
                            if (loadMin > loadVal) loadMin = loadVal;
                        }
                        break;
                    case "等速力":                        
                        if (cmdParams[2].Contains("位移达到"))
                        {
                            double posVal = double.Parse(cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("mm")));

                            if (posMax < posVal) posMax = posVal;
                            if (posMin > posVal) posMin = posVal;
                        }
                        else if (cmdParams[2].Contains("力达到"))
                        {
                            double loadVal = double.Parse(cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("kN")));

                            if (loadMax < loadVal) loadMax = loadVal;
                            if (loadMin > loadVal) loadMin = loadVal;
                        }
                        break;
                    case "位移保持":
                        {
                            double posVal = double.Parse(cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("mm")));
                            if (posMax < posVal) posMax = posVal;
                            if (posMin > posVal) posMin = posVal;
                            break;
                        }
                    case "力保持":
                        {
                            double loadVal = double.Parse(cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("kN")));
                            if (loadMax < loadVal) loadMax = loadVal;
                            if (loadMin > loadVal) loadMin = loadVal;
                            break;
                        }
                    case "波形控制":
                        double zhongVal = double.Parse(cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("mm")));//中值
                        double zhengVal = double.Parse(cmdParams[3].Split(':').ElementAt(1).Substring(0, cmdParams[3].Split(':').ElementAt(1).IndexOf("mm")));//中值
                        double maxVal = zhongVal + zhengVal;
                        double minVal = zhongVal - zhengVal;

                        if (posMax < maxVal) posMax = maxVal;
                        if (posMin > minVal) posMin = minVal;
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
            }
        
        }
    }
}
