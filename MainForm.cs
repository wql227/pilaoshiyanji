/*-----------------------------------------------------------------------------
 
 Project:     DoPE10Net - Demo
 Description: Demo project for DoPE .NET
 
 (C) DOLI Elektronik GmbH, 2010-present
 
 Author:   Benjamin Fröhlich / HEG
  
Changes :
=========
 
 EDR 01.02.2011 - V1.0
 * wrote it.
 
 HEG 15.02.2011 - V2.0
 * removed trace stuff to simplify customer demo
 
 HEG 19.09.2011 - V2.01
 * IoSHalt Message Handler implemented
 
 HEG 30.10.2013 - V2.77
 * OnDebugMsg event handler installed (but not enabled)
 
 HEG 27.10.2014 - V2.80
 * Simplified demo
 * OnDataBlock handler implemented
 
 HEG 02.03.2016 - V2.83
 * Rmc.Enable needs to be called after Setup.SelSetup

 HEG 7.10.2016 - V10.00
 * EDCi support

 HEG 19.07.2017 - V10.02
 * DoPE V10.02 demo

 HEG 21.08.2017 - V10.03
 * DoPE V10.03 demo

 HEG 15.12.2017 - V10.10
 * Linux support

 PET 08.02.2022 - V10.19
 - Framework updated to .Net 4.0
 - Two platforms added X86 and x64
 - OnIoSHaltMsg and OnGuardMsg handler added
-------------------------------------------------------------------------------*/


// To use DoPE .NET in your own project, the following files must be in your .exe directory:
// - DoPE10.dll         (x86  platform)
// - DoPE10Net.dll      (x86  platform)
// - DoDpx10.dll        (x86  platform)
//
// - DoPE10x64.dll      (x64 platform)
// - DoPE10x64Net.dll   (x64 platform)
// - DoDpx10x64.dll     (x64 platform)
//
// In your project, you also need to add a reference for the files
// - DoPE10Net.dll      (x86  platform)
//
// - DoPE10x64Net.dll   (x64 platform)
//
// How to add a reference?
// - In Solution Explorer, right-click on the project node and click Add Reference.
// - In the Add Reference dialog box, select the "Browse"-tab and choose the DoPENet.dll
// - Click the OK-Button.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Doli.DoPE10;
using System.Diagnostics;
using DevComponents.DotNetBar;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Threading.Tasks;
using static Doli.DoPE10.DoPE;
using System.Linq;
using System.IO;
using log4net;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace DoPENetConnect
{
    /// <summary>
    /// Demo-application for the DoPE .NET library.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Initialization


        public static MainForm mainform = null;

        /// <summary>
        /// 保护配置
        /// </summary>
        public ProtectOption protectOption = null;

        /// <summary>
        /// Represents one EDC.
        /// This object is needed to perform DoPE tasks.
        /// (Similar to the DoPE-handle in C++.)
        /// </summary>
        private Edc MyEdc = null;

        /// <summary>
        /// 查询所有EDC
        /// </summary>
        public EdcList MyEdcList = null;

        /// <summary>
        /// TAN number assigned to a DoPE command.
        /// (To get informed when a task has been performed.)
        /// </summary>
        private short MyTan;

        /// <summary>
        /// Just an error constant string which is used
        /// when the EDC could not be initialized correctly.
        /// </summary>
        private const string CommandFailedString = "Command failed. Please make sure, that the Edc is successfully initialized. \n";

        /// <summary>
        /// 是否已经连接控制器
        /// </summary>
        public bool bConnected = false;

        /// <summary>
        /// 是否已经激活控制器
        /// </summary>
        public bool bActivated = false;

        /// <summary>
        /// 是否暂停绘制
        /// </summary>
        private bool bPause = false;

        /// <summary>
        /// 是否正在运行
        /// </summary>
        public bool isRunning = false;

        /// <summary>
        /// 按次数延迟显示实时数据
        /// </summary>
        private int nCount = 0;

        /// <summary>
        /// 
        /// </summary>
        public Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// 
        /// </summary>
        readonly double[] Values = new double[25];
        //readonly Stopwatch Stopwatch = Stopwatch.StartNew();

        decimal[] array_display1 = new decimal[150];         //波形显示数据1
        decimal[] array_display2 = new decimal[150];         //波形显示数据2
        decimal[] array_display3 = new decimal[150];         //波形显示数据3

        /// <summary>
        /// 
        /// </summary>
        double x_Position = 0.0;
        double x_Load = 0.0;
        double x_Extension = 0.0;
        double x_Command = 0.0;

        /// <summary>
        /// 记录试验次数
        /// </summary>
        int nTestCount = 0;

        double nAxisStep = 0;


        /// <summary>
        /// 记录位移峰谷值的队列
        /// </summary>
        Queue<double> PVPositionQueue = new Queue<double>(1000);

        /// <summary>
        /// 记录试验力峰谷值的队列
        /// </summary>
        Queue<double> PVLoadQueue = new Queue<double>(1000);

        /// <summary>
        /// 记录试验力峰谷值的队列
        /// </summary>
        Queue<double> PVExtensionQueue = new Queue<double>(1000);

        /// <summary>
        /// 峰值列表
        /// </summary>
        Queue<double> PeakQueue = new Queue<double>(2000);

        /// <summary>
        /// 谷值列表
        /// </summary>
        Queue<double> ValleyQueue = new Queue<double>(2000);

        /// <summary>
        /// 日志试验记录次数
        /// </summary>
        public int nCountLog = 100;

        /// <summary>
        /// 日志试验记录次数
        /// </summary>
        public string strLanguage = "简体中文";

        /// <summary>
        /// Y轴重新设置表示区间
        /// </summary>
        public List<ChartAxisYParm> m_ChartAxixYParmList;

        /// <summary>
        /// 每行日志内容
        /// </summary>
        public string strBlockLog = "";

        /// <summary>
        /// 设备id
        /// </summary>
        StringBuilder devId;

        /// <summary>
        /// 向上向下按动标识
        /// </summary>
        private bool EndUp = false;
        private bool EndDown = false;
        private bool EndQuickUp = false;
        private bool EndQuickDown = false;

        /// <summary>
        /// 向上按钮步进值
        /// </summary>
        public double btnUpConstantVal = 0.0;
        public double btnHurryUpConstantVal = 0.0;
        public double btnDownConstantVal = 0.0;
        public double btnHurryDownConstantVal = 0.0;

        /// <summary>
        /// 图表按钮调整量程
        /// </summary>
        public double Chart_Pos_Step = 5.0;
        public double Chart_Load_Step = 5.0;
        public double Chart_Ext_Step = 5.0;
        public double Chart_Command_Step = 5.0;

        /// <summary>
        /// X轴最大长度（秒）
        /// </summary>
        public double AxisXMax = 5;

        /// <summary>
        /// 每个循环前进的秒数
        /// </summary>
        public double dStep = 0.01;

        /// <summary>
        /// 总共前进次数
        /// </summary>
        public double nTotal = 500;

        /// <summary>
        /// 单次实验记录循环次数
        /// </summary>
        public long nTotalTestCount = 0;

        /// <summary>
        /// 记录当前试验次数
        /// </summary>
        public long nCurrentCount = 0;

        /// <summary>
        /// 
        /// </summary>
        public long nPreTestCount = 0;

        /// <summary>
        /// 循环次数
        /// </summary>
        public long nCycleCount = 0;

        /// <summary>
        /// 当前命令
        /// </summary>
        public int currentCmd;

        public int autoFittingFlag = 0;
        /// <summary>
        /// 曲线自动自适应
        /// </summary>

        double maxSeries0 = 0;
        double maxSeries1 = 0;
        double maxSeries2 = 0;
        double maxSeries3 = 0;

        double minSeries0 = 0;
        double minSeries1 = 0;
        double minSeries2 = 0;
        double minSeries3 = 0;

        public bool valInScaleSetted = false;


        public bool valInScaleSetted1 = false;


        public bool valInScaleSetted2 = false;

        /// <summary>
        /// 手动窗口
        /// </summary>
        FormFloat floatMenus;

        ///----------------------------------------------------------------------
        /// <summary>Constructor</summary>
        ///----------------------------------------------------------------------
        public MainForm()
        {
            LogHelper.Info("开始执行记录任务");

            // Initialize graphical-user-interface.
            InitializeComponent();

            //_stop = false;
            //_thread = null;
            //_stopWatch = new Stopwatch();
            //_stopWatch.Start();

            bPause = false;

            //实例化保护选项
            protectOption = new ProtectOption();

            //传递当前实例
            mainform = this;

            LoadIni();

            nTotal = AxisXMax / dStep;

//悬浮工具框
            floatMenus = new FormFloat();
            floatMenus.Owner = this;
            floatMenus.Show();
            floatMenus.Location = new Point(this.Location.X-floatMenus.Width, this.Location.Y);
        }

        ///----------------------------------------------------------------------
        /// <summary>FormShown initialzes GUI and starts communication with EDC</summary>
        ///----------------------------------------------------------------------
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // show platform type
            Text += Environment.Is64BitProcess ? " x64" : " x32";

            // show GUI
            Application.DoEvents();

            // show DoPE.Ctrl enum members in guiControl combo-box.
            //guiControl.DataSource = Enum.GetNames(typeof(DoPE.CTRL));

            // Set the control-combobox to "position".
            //guiControl.SelectedIndex = (int)DoPE.CTRL.POS;

            EnableButton();

            // Connect to EDC
            ConnectToEdc();

            //设置lightningchart参数
            CreateChart();

            floatMenus.Activate();
        }


        private void CreateChart()
        {
        //    //Disable rendering.
        //    lightningChart1.BeginUpdate();

        //    //Set V-Sync to prevent 'tearing'
        //    lightningChart1.RenderOptions.WaitForVSync = true;

        //    // Change axis layout.
        //    lightningChart1.ViewXY.AxisLayout.YAxesLayout = YAxesLayout.Stacked;
        //    lightningChart1.ViewXY.AxisLayout.SegmentsGap = 10;

        //    lightningChart1.ViewXY.DropOldSeriesData = true; // Drop old data, increase preformance.

        //    // Zooming and panning horizontal mode.
        //    lightningChart1.ViewXY.ZoomPanOptions.RectangleZoomMode = RectangleZoomMode.Horizontal;
        //    lightningChart1.ViewXY.ZoomPanOptions.PanDirection = PanDirection.Horizontal;

        //    // Configure x-axis
        //    lightningChart1.ViewXY.XAxes[0].ScrollPosition = 0;
        //    lightningChart1.ViewXY.XAxes[0].ScrollMode = XAxisScrollMode.Scrolling;
        //    //Configure legend
        //    lightningChart1.ViewXY.LegendBoxes[0].Visible = false;
        //    lightningChart1.ViewXY.AxisLayout.AutoAdjustMargins = false;

        //    //Allow rendering.
        //    lightningChart1.EndUpdate();
        }


        ///----------------------------------------------------------------------
        /// <summary>Connect to EDC</summary>
        ///----------------------------------------------------------------------
        private void ConnectToEdc()
        {
            // tell DoPE which DoPE10Net.dll and DoPE.dll version we are using
            // THE API CANNOT BE USED WITHOUT THIS CHECK !
            DoPE.ERR apiErr = DoPE.CheckApi("10.23");

            if (bConnected)
            {
                MessageBox.Show("已经连接控制器！");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            //改成线程访问，防止卡顿界面
           // Task.Run(() =>
           // {
                try
                {
                    DoPE.ERR error;
                //DoPE.IgnoreTcpIpNIC(true);
                // open the first EDC found on this PC
                //打开edc列表
                //MyEdcList = new EdcList(32);
                //MyEdc = MyEdcList[0];
                //MyEdc = new Edc(DoPE.OpenBy.DeviceId, 0);02137E43 
                if (devId != null) MyEdc = new Edc(DoPE.OpenBy.DeviceId, int.Parse(devId.ToString(), System.Globalization.NumberStyles.HexNumber));
                else
                {
                    return;
                }
                    //MyEdc = new Edc(DoPE.OpenBy.DeviceId, 3491251);

                    //MyEdc = new Edc(DoPE.OpenBy.FunctionId, 0);
                    if (MyEdc != null)
                    {
                        Display("连接成功，Name:" + MyEdc.ModuleInfo.Name + "; DeviceId = " + MyEdc.ModuleInfo.DeviceID + "; FunctionId = " + MyEdc.ModuleInfo.DeviceID + "; SerNr = " + MyEdc.ModuleInfo.SerNr + "\n");

                        LogHelper.WriteLogFile("AAAA");

                        lbX_EDCName.Text = MyEdc.ModuleInfo.Name;

                        toolStripStatusLabel4.Text = this.devId.ToString();

                    }

                    bConnected = MyEdc.IsConnected();

                    EnableButton();

                    //DoPEcheck dope_block = new DoPEcheck(MyEdc);

                    //DoPE.ERR aaa = dope_block.ClrCheck();

                    // hang in event-handler to receive DoPE-events
                    MyEdc.Eh.OnLineHdlr += new DoPE.OnLineHdlr(OnLine);
                    // Set number of samples for OnDataBlock events
                    // for a 300 ms display refresh
                    DoPE.Machine Machine = new DoPE.Machine(0);
                    MyEdc.Setup.RdMachine(DoPE.MACHINE_NUMBER.MACHINE_1, ref Machine);
                    double aaa = (0.01 / Machine.MDef.SystemTime /*+ Machine.MDef.SystemTime / 2*/);
                    MyEdc.Eh.SetOnDataBlockSize((Int32)(aaa)); 
                    MyEdc.Eh.OnDataBlockHdlr += new DoPE.OnDataBlockHdlr(OnDataBlock);
                    MyEdc.Eh.OnCommandErrorHdlr += new DoPE.OnCommandErrorHdlr(OnCommandError);
                    MyEdc.Eh.OnPosMsgHdlr += new DoPE.OnPosMsgHdlr(OnPosMsg);
                    MyEdc.Eh.OnTPosMsgHdlr += new DoPE.OnTPosMsgHdlr(OnTPosMsg);
                    MyEdc.Eh.OnLPosMsgHdlr += new DoPE.OnLPosMsgHdlr(OnLPosMsg);
                    MyEdc.Eh.OnSftMsgHdlr += new DoPE.OnSftMsgHdlr(OnSftMsg);
                    MyEdc.Eh.OnOffsCMsgHdlr += new DoPE.OnOffsCMsgHdlr(OnOffsCMsg);
                    MyEdc.Eh.OnCheckMsgHdlr += new DoPE.OnCheckMsgHdlr(OnCheckMsg);
                    MyEdc.Eh.OnRefSignalMsgHdlr += new DoPE.OnRefSignalMsgHdlr(OnRefSignalMsg);
                    MyEdc.Eh.OnSensorMsgHdlr += new DoPE.OnSensorMsgHdlr(OnSensorMsg);
                    MyEdc.Eh.OnIoSHaltMsgHdlr += new DoPE.OnIoSHaltMsgHdlr(OnIoSHaltMsg);
                    MyEdc.Eh.OnGuardMsgHdlr += new DoPE.OnGuardMsgHdlr(OnGuardMsg);
                    MyEdc.Eh.OnKeyMsgHdlr += new DoPE.OnKeyMsgHdlr(OnKeyMsg);
                    MyEdc.Eh.OnRuntimeErrorHdlr += new DoPE.OnRuntimeErrorHdlr(OnRuntimeError);
                    MyEdc.Eh.OnOverflowHdlr += new DoPE.OnOverflowHdlr(OnOverflow);
                    MyEdc.Eh.OnSystemMsgHdlr += new DoPE.OnSystemMsgHdlr(OnSystemMsg);
                    MyEdc.Eh.OnDebugMsgHdlr += new DoPE.OnDebugMsgHdlr(OnDebugMsg);
                    MyEdc.Eh.OnRmcEventHdlr += new DoPE.OnRmcEventHdlr(OnRmcEvent);

                    // Set UserScale
                    DoPE.UserScale userScale = new DoPE.UserScale();
                    // set position and extension scale to mm
                    userScale[DoPE.SENSOR.SENSOR_S] = 1000;
                    userScale[DoPE.SENSOR.SENSOR_E] = 1000;

                    // Select machine setup and initialize
                    error = MyEdc.Setup.SelMachine(DoPE.MACHINE_NUMBER.MACHINE_1, userScale);
                    if (error != DoPE.ERR.NOERROR)
                    {
                        DisplayError(error, "SelectMachine");
                    }
                    else
                    {
                        Display("SelectMachine : OK !\n");
                    }

                    MyEdc.Rmc.Enable(-1, -1);
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.ToString());
                //    Display(string.Format("{0}\n", ex));
                //}
                catch (DoPEException ex)
                {
                    // During the initialization and the
                    // shut-down phase a DoPE Exception can arise.
                    // Other errors are reported by the DoPE
                    // error return codes.
                    Display(string.Format("{0}\n", ex));
                }

          //  });


            this.Cursor = Cursors.Default;

        }
        #endregion

        #region GUI

        ///----------------------------------------------------------------------
        /// <summary>
        /// Formates and displays DoPE-errors.
        /// </summary>
        /// <param name="error">the dope error to display</param>
        /// <param name="Text">additional text to display</param>
        ///----------------------------------------------------------------------
        private void DisplayError(DoPE.ERR error, string Text)
        {
            if (error != DoPE.ERR.NOERROR)
            {
                Display(Text + " Error: " + error + "\n");
            }
        }


        ///----------------------------------------------------------------------
        /// <summary>Display debug text</summary>
        ///----------------------------------------------------------------------
        private void Display(string Text)
        {
            try
            {
                if (guiDebug.InvokeRequired)
                {
                    guiDebug.Invoke(new Action<string>(Display), Text);
                }
                else
                {
                    guiDebug.AppendText(Text + "\r\n");
                    guiDebug.ScrollToCaret(); // 自动滚动到底部
                                              //Refresh();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        /// <summary>
        /// 激活EDC
        /// </summary>
        private void OnEDC()
        {
            try
            {
                DoPE.ERR error = MyEdc.Move.On();
                bActivated = true;
                //StartCommunicationWithEdcTimer.Start();
                DisplayError(error, "On");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }


        ///----------------------------------------------------------------------
        /// <summary>Deactivates the EDC's drive.</summary>
        ///----------------------------------------------------------------------
        private void guiOff_Click(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// 取消EDC
        /// </summary>
        private void OffEDC()
        {
            try
            {
                DoPE.ERR error = MyEdc.Move.Off();
                bActivated = false;
                //StartCommunicationWithEdcTimer.Stop();
                DisplayError(error, "Off");
                isRunning = false;
                btnX_SetLow.Checked = false;
                btnX_SetHigh.Checked = false;

                SetControlEnable(true);

                bntX_GUIOn.Checked = false;
                floatMenus.btnX_GUIOn_Checked(false);   //请与上边同步修改

                this.MaximizeBox = true;

                nCycleCount = 0;

                timer_UpdateData.Stop();

                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                }

                tbX_TestCount.Text = tbX_TestCycles.Text;

                IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCycles.Text);

            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }

        private void guiUp_Click(object sender, EventArgs e)
        {
            double speed;

            try
            {
                speed = Convert.ToDouble("30");

                DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 2, ref MyTan);
                DisplayError(error, "FDPoti");
            }
            catch (NullReferenceException)
            {
                Display(CommandFailedString);
            }
        }


        ///----------------------------------------------------------------------
        /// <summary>
        /// Sends a move command to the EDC. The command-parameters
        /// are copied from the user-interface.
        /// </summary>
        ///----------------------------------------------------------------------
        private void guiPos_Click(object sender, EventArgs e)
        {
            //DoPE.CTRL control;
            //double speed;
            //double destination;

            //try
            //{
            //    control = (DoPE.CTRL)guiControl.SelectedIndex;
            //    speed = Convert.ToDouble(guiSpeed.Text);
            //    destination = Convert.ToDouble(guiDestination.Text);

            //    DoPE.ERR error = MyEdc.Move.Pos(control, speed, destination, ref MyTan);
            //    //formsPlot1.

            //    DisplayError(error, "Pos");
            //}
            //catch (NullReferenceException)
            //{
            //    Display(CommandFailedString);
            //}
        }

        ///----------------------------------------------------------------------
        /// <summary>Sets the correct units depending on the selected control-mode.</summary>
        ///----------------------------------------------------------------------
        private void guiControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DoPE.CTRL control = (DoPE.CTRL)guiControl.SelectedIndex;

            //switch (control)
            //{
            //    case DoPE.CTRL.POS:
            //        {
            //            lblSpeedUnit.Text = "mm/s";
            //            lblDestinationUnit.Text = "mm";
            //            break;
            //        }
            //    case DoPE.CTRL.LOAD:
            //        {
            //            lblSpeedUnit.Text = "N/s";
            //            lblDestinationUnit.Text = "N";
            //            break;
            //        }
            //    case DoPE.CTRL.EXTENSION:
            //        {
            //            lblSpeedUnit.Text = "mm/s";
            //            lblDestinationUnit.Text = "mm";
            //            break;
            //        }
            //    default:
            //        {
            //            lblSpeedUnit.Text = "Unit/s";
            //            lblDestinationUnit.Text = "Unit";
            //            break;
            //        }
            //}
        }

        #endregion

        #region DoPE Events DoPE事件消息

        private int OnLine(DoPE.LineState LineState, object Parameter)
        {
            Display(string.Format("OnLine: {0}\n", LineState));

            if (LineState == DoPE.LineState.OFFLINE)
            {
                btn_ConState.BackColor = Color.Red;
                btn_ConState.Text = "OFFLINE";

                floatMenus.btn_ConState_color(Color.Red);
                floatMenus.btn_ConState_Text("OFFLINE");

            }
            else if (LineState == DoPE.LineState.ONLINE)
            {
                btn_ConState.BackColor = Color.Lime;
                btn_ConState.Text = "ONLINE";

                floatMenus.btn_ConState_color(Color.Lime);
                floatMenus.btn_ConState_Text("ONLINE");
            }
            else if (LineState == DoPE.LineState.RESTART)
            {
                btn_ConState.BackColor = Color.Yellow;
                btn_ConState.Text = "RESTART";

                floatMenus.btn_ConState_color(Color.Yellow);
                floatMenus.btn_ConState_Text("RESTART");
            }

            return 0;
        }

        private int OnDataBlock(ref DoPE.OnDataBlock Block, object Parameter)
        {
            string strCSVLog = "";
            if (Block.Data.Length > 0)
            {
                nCount++;
                // refesh edit controls with the latest sample
                DoPE.Data Sample = Block.Data[Block.Data.Length - 1].Data;
                string text;

                text = String.Format("{0}", Sample.Time.ToString("0.000"));

                strCSVLog += text + ",";
                text = String.Format("{0}", Sample.Sensor[(int)DoPE.SENSOR.SENSOR_S].ToString("0.000"));

                if (bConnected )
                {
                    //位移队列
                    PVPositionQueue.Enqueue(Sample.Sensor[(int)DoPE.SENSOR.SENSOR_S]);
                    if (PVPositionQueue.Count >= 50)
                    {
                        tb_MaxPos.Text = PVPositionQueue.Max().ToString("0.000");
                        tb_MinPos.Text = PVPositionQueue.Min().ToString("0.000");

                        if (bActivated && isRunning)
                        {
                            //判断是否处于正常峰值区间
                            if (protectOption.ProtectOption_PosMaxOut_Effect)
                            {
                                if (PVPositionQueue.Max() > protectOption.ProtectOption_PosMaxOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("位移峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            if (protectOption.ProtectOption_PosMaxIn_Effect)
                            {
                                if (PVPositionQueue.Max() < protectOption.ProtectOption_PosMaxIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("位移峰值超过内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于正常谷值区间
                            if (protectOption.ProtectOption_PosMinOut_Effect)
                            {
                                if (PVPositionQueue.Min() < protectOption.ProtectOption_PosMinOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("位移谷值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            if (protectOption.ProtectOption_PosMinIn_Effect)
                            {
                                if (PVPositionQueue.Min() > protectOption.ProtectOption_PosMinIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("位移谷值超过内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }
                        }

                        PVPositionQueue.Clear();
                    }

                    // TODO:判断峰谷值是否超过外保护
                    double dPosition = 0; 

                    if (nCount >= 50)
                    {
                        guiPosition.Text = text;
                    }
                    strCSVLog += text + ",";
                    //data_display1 = decimal.Parse(guiPosition.Text == "" ? "" : "0");
                    text = String.Format("{0}", Sample.Sensor[(int)DoPE.SENSOR.SENSOR_F].ToString("0.000"));

                    //试验力队列
                    PVLoadQueue.Enqueue(Sample.Sensor[(int)DoPE.SENSOR.SENSOR_F]);
                    if (PVLoadQueue.Count >= 50)
                    {
                        tb_MaxLoad.Text = PVLoadQueue.Max().ToString("0.000");
                        tb_MinLoad.Text = PVLoadQueue.Min().ToString("0.000");
                        if (bActivated && isRunning)
                        {
                            //判断是否处于合理的试验力峰值区间 峰值外保护
                            if (protectOption.ProtectOption_LoadMaxOut_Effect)
                            {
                                if (PVLoadQueue.Max() > protectOption.ProtectOption_LoadMaxOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("试验力峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的试验力峰值区间 峰值内保护
                            if (protectOption.ProtectOption_LoadMaxIn_Effect)
                            {
                                if (PVLoadQueue.Max() < protectOption.ProtectOption_LoadMaxIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("试验力峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的试验力谷值区间 谷值外保护
                            if (protectOption.ProtectOption_LoadMinOut_Effect)
                            {
                                if (PVLoadQueue.Min() < protectOption.ProtectOption_LoadMinOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("试验力峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的试验力谷值区间 谷值内保护
                            if (protectOption.ProtectOption_LoadMinIn_Effect)
                            {
                                if (PVLoadQueue.Min() > protectOption.ProtectOption_LoadMinIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("试验力峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }
                        }

                        PVLoadQueue.Clear();
                    }

                    //if (Sample.Sensor[(int)DoPE.SENSOR.SENSOR_F] > 3.0)
                    {
                        //DoPE.ERR error = MyEdc.Move.Halt(DoPE.CTRL.POS, ref MyTan);
                        //OffEDC();
                    }
                    //ProtectOption_PosMaxOut

                    if (nCount >= 50)
                    {
                        guiLoad.Text = text;
                    }

                    strCSVLog += text + ",";
                    //data_display2 = decimal.Parse(guiLoad.Text);
                    text = String.Format("{0}", Sample.Sensor[(int)DoPE.SENSOR.SENSOR_E].ToString("0.000"));

                    //变形队列
                    PVExtensionQueue.Enqueue(Sample.Sensor[(int)DoPE.SENSOR.SENSOR_E]);
                    if (PVExtensionQueue.Count >= 50)
                    {
                        tb_MaxExt.Text = PVExtensionQueue.Max().ToString("0.000");
                        tb_MinExt.Text = PVExtensionQueue.Min().ToString("0.000");

                        if (bActivated && isRunning)
                        {
                            //判断是否处于合理的变形峰值区间 峰值外保护
                            if (protectOption.ProtectOption_ExtMaxOut_Effect)
                            {
                                if (PVExtensionQueue.Max() > protectOption.ProtectOption_ExtMaxOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("变形峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的变形峰值区间 峰值内保护
                            if (protectOption.ProtectOption_ExtMaxIn_Effect)
                            {
                                if (PVExtensionQueue.Max() < protectOption.ProtectOption_ExtMaxIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("变形峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的变形谷值区间 谷值外保护
                            if (protectOption.ProtectOption_ExtMinOut_Effect)
                            {
                                if (PVExtensionQueue.Min() < protectOption.ProtectOption_ExtMinOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("变形峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的变形谷值区间 谷值内保护
                            if (protectOption.ProtectOption_ExtMinIn_Effect)
                            {
                                if (PVExtensionQueue.Min() > protectOption.ProtectOption_ExtMinIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    MessageBox.Show("变形峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }
                        }
                        PVExtensionQueue.Clear();
                    }

                    if (nCount >= 50)
                    {
                        guiExtension.Text = text;
                    }

                    strCSVLog += text + ",";
                    //data_display3 = decimal.Parse(guiExtension.Text);

                    text = String.Format("{0}", Sample.Sensor[(int)DoPE.OUT.COMMAND].ToString("0.000"));
                    strCSVLog += text + ",";
                    strCSVLog += (Sample.Cycles /*<< 1*/).ToString() + ",";

                    if (nCount >= 50)
                    {
                        nCount = 0;
                    }

                    if (isRunning)
                    {
                        strBlockLog += (strCSVLog + "\r\n");
                        strBlockLog = strBlockLog.Replace("\r\n\r\n", "\r\n");

                        //按配置的次数存储日志
                        if ((Sample.Cycles /*>> 1*/) % nCountLog == 0)
                        {
                            LogHelper.SaveCsvData(strBlockLog);
                            strBlockLog = "";
                        }
                    }

                    if (!isRunning)
                    {
                        if ((Sample.Cycles >> 1) > 0 && nTotalTestCount == 0)
                        {
                            tbX_TestCycles.Text = nPreTestCount.ToString();
                        }
                    }
                    else
                    {
                        if (cb_TareTime.Checked)
                        {
                            nTotalTestCount = (Sample.Cycles >> 1) - nCurrentCount;
                            tbX_TestCycles.Text = nTotalTestCount.ToString();
                        }
                        else
                        {
                            nTotalTestCount = (Sample.Cycles >> 1) + nPreTestCount;
                            tbX_TestCycles.Text = nTotalTestCount.ToString();
                        }
                    }

                    //labelX33.Text = (Sample.Cycles >> 1).ToString();
                    //试验次数达到指定的试验次数
                    if (isRunning) 
                    {
                        nCycleCount++;

                        if (nCycleCount > 1 && Sample.Cycles /*>> 1*/ >= nTestCount)
                        {
                            isRunning = false;
                            SetControlEnable(!isRunning);
                            timer_UpdateData.Stop();

                            tbX_TestCount.Text = tbX_TestCycles.Text;

                            //最后一次的试验次数写入配置文件
                            IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCycles.Text);

                            nCycleCount = 0;
                        }
                    }
                }

                //波形图
                if (bConnected && bActivated)
                {
                    ShowWave(Block);
                }

                //IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCycles.Text);
            }

            return 0;
        }

        private int OnCommandError(ref DoPE.OnCommandError CommandError, object Parameter)
        {
            Display(string.Format("OnCommandError: CommandNumber={0} ErrorNumber={1} usTAN={2} \n",
              CommandError.CommandNumber, CommandError.ErrorNumber, CommandError.usTAN));

            return 0;
        }

        private int OnPosMsg(ref DoPE.OnPosMsg PosMsg, object Parameter)
        {
            Display(string.Format("OnPosMsg: DoPError={0} Reached={1} Time={2} Control={3} Position={4} DControl={5} Destination={6} usTAN={7} \n",
              PosMsg.DoPError, PosMsg.Reached, PosMsg.Time, PosMsg.Control, PosMsg.Position, PosMsg.DControl, PosMsg.Destination, PosMsg.usTAN));

            return 0;
        }

        private int OnTPosMsg(ref DoPE.OnPosMsg PosMsg, object Parameter)
        {
            Display(string.Format("OnTPosMsg: DoPError={0} Reached={1} Time={2} Control={3} Position={4} DControl={5} Destination={6} usTAN={7} \n",
              PosMsg.DoPError, PosMsg.Reached, PosMsg.Time, PosMsg.Control, PosMsg.Position, PosMsg.DControl, PosMsg.Destination, PosMsg.usTAN));

            return 0;
        }

        private int OnLPosMsg(ref DoPE.OnPosMsg PosMsg, object Parameter)
        {
            Display(string.Format("OnLPosMsg: DoPError={0} Reached={1} Time={2} Control={3} Position={4} DControl={5} Destination={6} usTAN={7} \n",
              PosMsg.DoPError, PosMsg.Reached, PosMsg.Time, PosMsg.Control, PosMsg.Position, PosMsg.DControl, PosMsg.Destination, PosMsg.usTAN));

            return 0;
        }

        private int OnSftMsg(ref DoPE.OnSftMsg SftMsg, object Parameter)
        {
            Display(string.Format("OnSftMsg: DoPError={0} Upper={1} Time={2} Control={3} Position={4} usTAN={5} \n",
              SftMsg.DoPError, SftMsg.Upper, SftMsg.Time, SftMsg.Control, SftMsg.Position, SftMsg.usTAN));

            return 0;
        }

        private int OnOffsCMsg(ref DoPE.OnOffsCMsg OffsCMsg, object Parameter)
        {
            Display(string.Format("OnOffsCMsg: DoPError={0} Time={1} Offset={2} usTAN={3} \n",
              OffsCMsg.DoPError, OffsCMsg.Time, OffsCMsg.Offset, OffsCMsg.usTAN));

            return 0;
        }

        private int OnCheckMsg(ref DoPE.OnCheckMsg CheckMsg, object Parameter)
        {
            Display(string.Format("OnCheckMsg: DoPError={0} Action={1} Time={2} CheckId={3} Position={4} SensorNo={5} usTAN={6} \n",
              CheckMsg.DoPError, CheckMsg.Action, CheckMsg.Time, CheckMsg.CheckId, CheckMsg.Position, CheckMsg.SensorNo, CheckMsg.usTAN));

            return 0;
        }

        private int OnRefSignalMsg(ref DoPE.OnRefSignalMsg RefSignalMsg, object Parameter)
        {
            Display(string.Format("OnRefSignalMsg: DoPError={0} Time={1} SensorNo={2} Position={3} usTAN={4} \n",
              RefSignalMsg.DoPError, RefSignalMsg.Time, RefSignalMsg.SensorNo, RefSignalMsg.Position, RefSignalMsg.usTAN));

            return 0;
        }

        private int OnSensorMsg(ref DoPE.OnSensorMsg SensorMsg, object Parameter)
        {
            Display(string.Format("OnSensorMsg: DoPError={0} Time={1} SensorNo={2} usTAN={3} \n",
              SensorMsg.DoPError, SensorMsg.Time, SensorMsg.SensorNo, SensorMsg.usTAN));

            return 0;
        }

        private int OnIoSHaltMsg(ref DoPE.OnIoSHaltMsg IoSHaltMsg, object Parameter)
        {
            Display(string.Format("OnIoSHaltMsg: DoPError={0} Upper={1} Time={2} Control={3} Position={4} usTAN={5} \n",
              IoSHaltMsg.DoPError, IoSHaltMsg.Upper, IoSHaltMsg.Time, IoSHaltMsg.Control, IoSHaltMsg.Position, IoSHaltMsg.usTAN));

            return 0;
        }

        private int OnGuardMsg(ref DoPE.OnGuardMsg GuardMsg, object Parameter)
        {
            Display(string.Format("OnGuardMsg: DoPError={0} Trigger={1} Time={2} TriggerSensor={3} TriggerValue={4} TriggerLimit={5} usTAN={6} \n",
              GuardMsg.DoPError, GuardMsg.Trigger, GuardMsg.Time, GuardMsg.TriggerSensor, GuardMsg.TriggerValue, GuardMsg.TriggerLimit, GuardMsg.usTAN));

            return 0;
        }

        private int OnKeyMsg(ref DoPE.OnKeyMsg KeyMsg, object Parameter)
        {
            Display(string.Format("OnKeyMsg: DoPError={0} Time={1} Keys={2} NewKeys={3} GoneKeys={4} OemKeys={5} NewOemKeys={6} GoneOemKeys={7} usTAN={8} \n",
              KeyMsg.DoPError, KeyMsg.Time, KeyMsg.Keys, KeyMsg.NewKeys, KeyMsg.GoneKeys, KeyMsg.OemKeys, KeyMsg.NewOemKeys, KeyMsg.GoneOemKeys, KeyMsg.usTAN));

            return 0;
        }

        private int OnRuntimeError(ref DoPE.OnRuntimeError RuntimeError, object Parameter)
        {
            Display(string.Format("OnRuntimeError: DoPError={0} ErrorNumber={1} Time={2} Device={3} Bits={4} usTAN={5} \n",
              RuntimeError.DoPError, RuntimeError.ErrorNumber, RuntimeError.Time, RuntimeError.Device, RuntimeError.Bits, RuntimeError.usTAN));

            return 0;
        }

        private int OnOverflow(int Overflow, object Parameter)
        {
            Display(string.Format("OnOverflow: Overflow={0} \n", Overflow));

            return 0;
        }

        private int OnDebugMsg(ref DoPE.OnDebugMsg DebugMsg, object Parameter)
        {
            Display(string.Format("OnDebugMsg: DoPError={0} MsgType={1} Time={2} Text={3} \n",
              DebugMsg.DoPError, DebugMsg.MsgType, DebugMsg.Time, DebugMsg.Text));

            return 0;
        }

        private int OnSystemMsg(ref DoPE.OnSystemMsg SystemMsg, object Parameter)
        {
            Display(string.Format("OnSystemMsg: DoPError={0} MsgNumber={1} Time={2} Text={3} \n",
              SystemMsg.DoPError, SystemMsg.MsgNumber, SystemMsg.Time, SystemMsg.Text));

            return 0;
        }

        private int OnRmcEvent(ref DoPE.OnRmcEvent RmcEvent, object Parameter)
        {
            Display(string.Format("OnRmcEvent: Keys={0} NewKeys={1} GoneKeys={2} Leds={3} NewLeds={4} GoneLeds={5} \n",
              RmcEvent.Keys, RmcEvent.NewKeys, RmcEvent.GoneKeys, RmcEvent.Leds, RmcEvent.NewLeds, RmcEvent.GoneLeds));

            //Color aaa = To_RGB(Convert.ToInt32(RmcEvent.Leds));
            //button3.BackColor = To_RGB(Convert.ToInt32(RmcEvent.Leds));
            //button4.BackColor = To_RGB(Convert.ToInt32(RmcEvent.NewLeds));
            return 0;
        }

        private Color To_RGB(int color)
        {
            int r = 0xFF & color;
            int g = 0xFF00 & color;
            g >>= 8;
            int b = 0xFF0000 & color;
            b >>= 16;
            return Color.FromArgb(r, g, b);
        }


        #endregion




        #region 菜单选项响应事件

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Login_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }


        private void 保存数据问题及ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        #endregion 菜单选项响应事件

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0014) // 禁掉清除背景消息
        //    {
        //        return;
        //    }

        //    base.WndProc(ref m);
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadLanguage();

            ReplaceLanguage();

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            timer_UpdateData.Interval = 300;

            btn_ConState.BackColor = Color.Red;
            //取消平滑
            //chart_DrawGraph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //lightningChart1.ColorTheme = ColorTheme.SkyBlue;

            //初始化chart控件
            chart_machine.Series[0].Points.Clear();
            //x_Position = 0.0;
            chart_machine.Series[0].Points.AddXY(0.0, 0.0);

            //试验力
            chart_machine.Series[1].Points.Clear();
            //x_Load = 0.0;
            chart_machine.Series[1].Points.AddXY(0.0, 0.0);



            //// 获取或创建 ChartArea
            //ChartArea chartArea = chart_machine.ChartAreas[0];

            //// 设置主 Y 轴（左边）
            //chartArea.AxisY.Title = "Position";

            //// 添加副 Y 轴（右边）
            //chartArea.AxisY2.Enabled = AxisEnabled.True;
            //chartArea.AxisY2.Title = "Load";
            //chartArea.AxisY2.LabelStyle.Enabled = true;

            //// 为 Series[0] 设置使用主 Y 轴（AxisY）
            //chart_machine.Series[0].YAxisType = AxisType.Primary;

            //// 为 Series[1] 设置使用副 Y 轴（AxisY2）
            //chart_machine.Series[1].YAxisType = AxisType.Secondary;

            //// 可选：设置样式以区分两个系列
            //chart_machine.Series[0].Color = Color.Blue;
            //chart_machine.Series[1].Color = Color.Red;

            chart_machine.ChartAreas[0].AxisX.Minimum = 0;
            //chart_machine.ChartAreas[0].AxisX.Maximum = 5;

        }


        /// <summary>
        /// 加载语言项菜单
        /// </summary>
        public void LoadLanguage()
        {
            // 动态绑定菜单：遍历指定目录中的语言文件并生成菜单项
            string langPath = System.IO.Directory.GetCurrentDirectory() + "\\Lang";

            if (Directory.Exists(langPath))
            {
                string[] strLanguages = Directory.GetFiles(langPath);

                foreach (string filePath in strLanguages)
                {
                    // 获取文件名（不含路径）
                    string fileName = Path.GetFileName(filePath);
                    fileName = Path.GetFileNameWithoutExtension(filePath);

                    // 创建菜单项
                    ToolStripMenuItem langMenuItem = new ToolStripMenuItem();
                    langMenuItem.Text = fileName; // 显示文件名作为菜单项文本
                    langMenuItem.Tag = filePath;  // 使用 Tag 存储完整路径，便于事件中使用

                    // 绑定点击事件
                    langMenuItem.Click += LangMenuItem_Click;

                    // 添加到父菜单项下
                    ToolStripMenuItem_Language.DropDownItems.Add(langMenuItem);
                }
            }
            else
            {
                MessageBox.Show("语言目录不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        /// <summary>
        /// 替换界面语言
        /// </summary>
        public void ReplaceLanguage()
        {
            var langData = LanguageLoad.LoadLang(System.IO.Directory.GetCurrentDirectory() + "\\Lang\\" + strLanguage + ".json");

            List<string> allMenuNames = GetAllMenuNames(this.menuStrip1.Items);

            // 输出所有菜单项名称
            foreach (var name in allMenuNames)
            {
                Console.WriteLine(name);
            }


            //循环界面控件替换成指定的语言
            if (langData.TryGetValue(this.Name, out var mainFormLabels))
            {
                //foreach (var kvp in mainFormLabels)
                //{
                //    var controlName = kvp.Key;
                //    var textValue = kvp.Value;

                //    // 根据控件名称查找控件（可以扩展为递归查找）
                //    var ctrl = this.Controls.Find(controlName, true).FirstOrDefault();
                //    if (ctrl != null)
                //    {
                //        ctrl.Text = textValue;
                //    }
                //}

                foreach (var kvp in mainFormLabels)
                {
                    var controlName = kvp.Key;
                    var textValue = kvp.Value;

                    // 首先尝试从主窗体的控件集合中查找控件
                    var ctrl = this.Controls.Find(controlName, true).FirstOrDefault();

                    if (ctrl == null && this is Form form)
                    {
                        // 如果未找到，则检查 SuperTabControl 中的所有 SuperTabItem
                        foreach (Control c in form.Controls)
                        {
                            if (c is SuperTabControl superTabControl)
                            {
                                foreach (SuperTabItem tabItem in superTabControl.Tabs)
                                {
                                    // 获取当前 TabItem 的内容区域
                                    Control contentContainer = GetContentContainer(tabItem);
                                    if (contentContainer != null)
                                    {
                                        ctrl = contentContainer.Controls.Find(controlName, true).FirstOrDefault();
                                        if (ctrl != null)
                                        {
                                            break; // 找到后跳出循环
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (ctrl == null) {
                        foreach (SuperTabItem tabItem in superTabControl1.Tabs)
                        {
                            // 获取当前 TabItem 的内容区域
                            if (tabItem.Name == controlName)
                            {
                                tabItem.Text = textValue;
                                break;
                            }
                        }
                        for (int i = 0; i < chart_machine.ChartAreas[0].Axes.Count(); i++)
                        {
                            if (chart_machine.ChartAreas[0].Axes[i].Name == controlName)
                            {
                                chart_machine.ChartAreas[0].Axes[i].Title = textValue;
                                break;
                            }
                        }

                        if (controlName.Contains("chartSeries")){
                            for (int i = 0; i < chart_machine.Series.Count(); i++) {
                                if (controlName.Contains(i.ToString()))
                                {
                                    chart_machine.Series[i].Name = textValue;
                                    break;
                                }
                            }
                        }
                        if (controlName.Contains("toolStripStatusLabel")) {
                            for (int i = 0; i < this.statusStrip1.Items.Count; i++)
                            {
                                if (statusStrip1.Items[i].Name == controlName) {
                                    statusStrip1.Items[i].Text = textValue;
                                    break;
                                }
                            }
                        }
                        //二级菜单
                        if (controlName.Contains("ToolStripMenuItem")&& controlName.Contains("@"))
                        {
                            string[] realCtrlName = controlName.Split('@');

                            if (realCtrlName[1] == "1")
                            {
                                foreach (ToolStripMenuItem tmpItm in ToolStripMenuItem_Oper.DropDownItems)
                                {
                                    if (tmpItm.Name == realCtrlName[0])
                                    {
                                        tmpItm.Text = textValue;
                                        break;
                                    }
                                }
                            }
                            else if (realCtrlName[1] == "2")
                            {
                                foreach (ToolStripMenuItem tmpItm in ToolStripMenuItem_Setting.DropDownItems)
                                {
                                    if (tmpItm.Name == realCtrlName[0])
                                    {
                                        tmpItm.Text = textValue;
                                        break;
                                    }
                                }
                            }
                            else if (realCtrlName[1] == "3")
                            {
                                foreach (ToolStripMenuItem tmpItm in ToolStripMenuItem_Data.DropDownItems)
                                {
                                    if (tmpItm.Name == realCtrlName[0])
                                    {
                                        tmpItm.Text = textValue;
                                        break;
                                    }
                                }
                            }
                            else if (realCtrlName[1] == "5")
                            {
                                foreach (ToolStripMenuItem tmpItm in ToolStripMenuItem_Language.DropDownItems)
                                {
                                    if (tmpItm.Name == realCtrlName[0])
                                    {
                                        tmpItm.Text = textValue;
                                        break;
                                    }
                                }
                            }
                            else if (realCtrlName[1] == "6")
                            {
                                foreach (ToolStripMenuItem tmpItm in ToolStripMenuItem_Help.DropDownItems)
                                {
                                    if (tmpItm.Name == realCtrlName[0])
                                    {
                                        tmpItm.Text = textValue;
                                        break;
                                    }
                                }
                            }


                        }
                    }

                    if (ctrl != null)
                    {
                        ctrl.Text = textValue;
                    }
                }

                foreach (var kvp in mainFormLabels)
                {
                    var controlName = kvp.Key;
                    var textValue = kvp.Value;

                    ToolStripMenuItem menuItem1 = FindMenuItem(this.menuStrip1.Items, controlName);
                    if (menuItem1 != null)
                    {
                        menuItem1.Text = textValue;
                    }

                    ToolStripMenuItem menuItem2 = FindMenuItem(this.menuStrip2.Items, controlName);
                    if (menuItem2 != null)
                    {
                        menuItem2.Text = textValue;
                    }
                }

            }
        }

        private List<string> GetAllMenuNames(ToolStripItemCollection items)
        {
            List<string> menuNames = new List<string>();

            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem toolStripMenuItem)
                {
                    menuNames.Add(toolStripMenuItem.Name);

                    if (toolStripMenuItem.HasDropDownItems)
                    {
                        menuNames.AddRange(GetAllMenuNames(toolStripMenuItem.DropDownItems));
                    }
                }
            }

            return menuNames;
        }


        private Control GetContentContainer(SuperTabItem tabItem)
        {
            // 获取 SuperTabItem 对应的内容区域
            return tabItem.AttachedControl;
        }

        private ToolStripMenuItem FindMenuItem(ToolStripItemCollection items, string name)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem toolStripMenuItem && toolStripMenuItem.Name == name)
                {
                    return toolStripMenuItem;
                }
                //else if (item.HasDropDownItems)
                //{
                //    ToolStripMenuItem foundItem = FindMenuItem(toolStripMenuItem.DropDownItems, name);
                //    if (foundItem != null)
                //    {
                //        return foundItem;
                //    }
                //}
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LangMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedItem)
            {
                string selectedFile = clickedItem.Tag?.ToString();
                string selectedText = clickedItem.Text;
                strLanguage = selectedText;

                IniFileHelper.WriteIniString("Setting", "Language", selectedText);
                ReplaceLanguage();
            }
        }


        /// <summary>
        /// 启用禁用按钮
        /// </summary>
        public void EnableButton()
        {
            if (bConnected)
            {
                //btnX_Connect.Enabled = true;
                btnX_Disconnect.Enabled = true;
                btnX_MoveQuickUp.Enabled = true;
                bntX_MoveUp.Enabled = true;
                bntX_MoveHalt.Enabled = true;
                bntX_MoveDown.Enabled = true;
                btnX_QuickMoveDown.Enabled = true;
                bntX_GUIOn.Enabled = true;
                bntX_GUIOff.Enabled = true;

                //floatMenus
                floatMenus.EnableButton(true);
            }
            else
            {
                //btnX_Connect.Enabled = true;
                btnX_Disconnect.Enabled = false;
                btnX_MoveQuickUp.Enabled = false;
                bntX_MoveUp.Enabled = false;
                bntX_MoveHalt.Enabled = false;
                bntX_MoveDown.Enabled = false;
                btnX_QuickMoveDown.Enabled = false;
                bntX_GUIOn.Enabled = false;
                bntX_GUIOff.Enabled = false;

                //floatMenus
                floatMenus.EnableButton(false);
            }
        }

        private void StartCommunicationWithEdcTimer_Tick(object sender, EventArgs e)
        {
            UpdateValues();
            //formsPlot1.Render();
        }

        #region 界面按钮消息事件

        /// <summary>
        /// 连接到EDC控制器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_Connect_Click(object sender, EventArgs e)
        {
            ConnectToEdc();
        }

        public void FormFloat_btnX_Connect_Click()
        {
            ConnectToEdc();
        }

        /// <summary>
        /// 断开EDC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_Disconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        public void FormFloat_btnX_Disconnect_Click()
        {
            Disconnect();
        }

        /// <summary>
        /// 向上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///----------------------------------------------------------------------
        /// <summary>Sends a move-command with direction "up" to the EDC.</summary>
        ///----------------------------------------------------------------------
        private void bntX_MoveUp_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 向上移动按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntX_MoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            EndUp = true;
            if (EndUp)
            {
                if (bConnected)
                {
                    double speed;

                    try
                    {
                        speed = btnUpConstantVal;

                        DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 2, ref MyTan);
                        DisplayError(error, "FDPoti");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }


        /// <summary>
        /// 向上移动按钮抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntX_MoveUp_MouseUp(object sender, MouseEventArgs e)
        {
            EndUp = false;

            MoveHalt();
        }


        public void FormFloat_bntX_MoveUp_MouseDown()
        {
            EndUp = true;
            if (EndUp)
            {
                if (bConnected)
                {
                    double speed;

                    try
                    {
                        speed = btnUpConstantVal;

                        DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 2, ref MyTan);
                        DisplayError(error, "FDPoti");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }


        /// <summary>
        /// 向上移动按钮抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FormFloat_bntX_MoveUp_MouseUp()
        {
            EndUp = false;

            MoveHalt();
        }


        /// <summary>
        /// 快速向上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///----------------------------------------------------------------------
        /// <summary>Sends a move-command with direction "up" to the EDC.</summary>
        ///----------------------------------------------------------------------
        private void btnX_MoveQuickUp_Click(object sender, EventArgs e)
        {
            
        }


        private void btnX_MoveQuickUp_MouseDown(object sender, MouseEventArgs e)
        {
            EndQuickUp = true;

            if (EndQuickUp)
            {
                if (bConnected)
                {
                    double speed;

                    try
                    {
                        speed = btnHurryUpConstantVal;

                        DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 20, ref MyTan);
                        DisplayError(error, "FDPoti");
                        //DoPE.ERR error = MyEdc.Move.FMove_A(DoPE.MOVE.UP, DoPE.CTRL.POS, 300, speed, ref MyTan);
                        //DisplayError(error, "FMove_A");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }

        private void btnX_MoveQuickUp_MouseUp(object sender, MouseEventArgs e)
        {
            EndQuickUp = false;

            MoveHalt();
        }


        public void FormFloat_btnX_MoveQuickUp_MouseDown()
        {
            EndQuickUp = true;

            if (EndQuickUp)
            {
                if (bConnected)
                {
                    double speed;

                    try
                    {
                        speed = btnHurryUpConstantVal;

                        DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 20, ref MyTan);
                        DisplayError(error, "FDPoti");
                        //DoPE.ERR error = MyEdc.Move.FMove_A(DoPE.MOVE.UP, DoPE.CTRL.POS, 300, speed, ref MyTan);
                        //DisplayError(error, "FMove_A");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }

        public void FormFloat_btnX_MoveQuickUp_MouseUp()
        {
            EndQuickUp = false;

            MoveHalt();
        }


        /// <summary>
        /// 保持
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///----------------------------------------------------------------------
        /// <summary>Sends a halt-command to the EDC.</summary>
        ///----------------------------------------------------------------------
        private void bntX_MoveHalt_Click(object sender, EventArgs e)
        {
            MoveHalt();
        }

        public void FormFloat_bntX_MoveHalt_Click()
        {
            MoveHalt();
        }
        /// <summary>
        /// MoveHalt 移动停止
        /// </summary>
        private void MoveHalt()
        {
            if (bConnected)
            {
                try
                {
                    DoPE.ERR error = MyEdc.Move.Halt(DoPE.CTRL.POS, ref MyTan);
                    DisplayError(error, "Halt");

                    isRunning = false;

                    nCycleCount = 0;

                    timer_UpdateData.Stop();

                    SetControlEnable(true);

                    tbX_TestCount.Text = tbX_TestCycles.Text;

                    IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCycles.Text);
                }
                catch (NullReferenceException)
                {
                    Display(CommandFailedString);
                }
            }
        }


        /// <summary>
        /// 向下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///----------------------------------------------------------------------
        /// <summary>Sends a move-command with direction "down" to the EDC.</summary>
        ///----------------------------------------------------------------------
        private void bntX_MoveDown_Click(object sender, EventArgs e)
        {
  
        }


        private void bntX_MoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            EndDown = true;
            if (EndDown)
            {
                if (bConnected)
                {
                    double speed;

                    try
                    {
                        speed = btnDownConstantVal;

                        DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref MyTan);
                        DisplayError(error, "FDPoti");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }

        private void bntX_MoveDown_MouseUp(object sender, MouseEventArgs e)
        {
            EndDown = false;

            MoveHalt();
        }


        public void FormFloat_bntX_MoveDown_MouseDown()
        {
            EndDown = true;
            if (EndDown)
            {
                if (bConnected)
                {
                    double speed;

                    try
                    {
                        speed = btnDownConstantVal;

                        DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref MyTan);
                        DisplayError(error, "FDPoti");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }

        public void FormFloat_bntX_MoveDown_MouseUp()
        {
            EndDown = false;

            MoveHalt();
        }
        /// <summary>
        /// 快速向下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///----------------------------------------------------------------------
        /// <summary>Sends a move-command with direction "down" to the EDC.</summary>
        ///----------------------------------------------------------------------
        private void btnX_QuickMoveDown_Click(object sender, EventArgs e)
        {
 
        }


        private void btnX_QuickMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            EndQuickDown = true;
            if (EndQuickDown)
            {
                if (bConnected)
                {
                    double speed;

                    try
                    {
                        speed = btnHurryDownConstantVal;

                        DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref MyTan);
                        DisplayError(error, "FDPoti");

                        //DoPE.ERR error = MyEdc.Move.FMove_A(DoPE.MOVE.DOWN, DoPE.CTRL.POS, 300, speed, ref MyTan);
                        //DisplayError(error, "FMove_A");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }


        private void btnX_QuickMoveDown_MouseUp(object sender, MouseEventArgs e)
        {
            EndQuickDown = false;

            MoveHalt();
         }

        /// <summary>
        /// 
        /// </summary>
        public void FormFloat_btnX_QuickMoveDown_MouseDown()
        {
            EndQuickDown = true;
            if (EndQuickDown)
            {
                if (bConnected)
                {
                    double speed;

                    try
                    {
                        speed = btnHurryDownConstantVal;

                        DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref MyTan);
                        DisplayError(error, "FDPoti");

                        //DoPE.ERR error = MyEdc.Move.FMove_A(DoPE.MOVE.DOWN, DoPE.CTRL.POS, 300, speed, ref MyTan);
                        //DisplayError(error, "FMove_A");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }


        public void FormFloat_btnX_QuickMoveDown_MouseUp()
        {
            EndQuickDown = false;

            MoveHalt();
        }


        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///----------------------------------------------------------------------
        /// <summary>Activates the EDC's drive.</summary>
        ///----------------------------------------------------------------------
        private void bntX_GUIOn_Click(object sender, EventArgs e)
        {
            OnEDC();

            if (MyEdc.IsConnected() && bActivated)
            {
                //GetXaxisScale();

                bntX_GUIOn.Checked = true;
                btnX_SetLow.Checked = true;
                btnX_SetHigh.Checked = false;

                this.MaximizeBox = false;
            }
        }

        public void FormFloat_bntX_GUIOn_Click()
        {
            OnEDC();

            if (MyEdc.IsConnected() && bActivated)
            {

                this.MaximizeBox = false;
            }
        }


        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///----------------------------------------------------------------------
        /// <summary>Activates the EDC's drive.</summary>
        ///----------------------------------------------------------------------
        private void bntX_GUIOff_Click(object sender, EventArgs e)
        {
            OffEDC();
        }

        public void FormFloat_bntX_GUIOff_Click()
        {
            OffEDC();
        }


        /// <summary>
        /// IO高压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_SetHigh_Click(object sender, EventArgs e)
        {
            if (bConnected)
            {
                DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureSet(true);
                //DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureEnable(true);

                if (Err == DoPE.ERR.NOERROR)
                {
                    btnX_SetLow.Checked = false;
                    btnX_SetHigh.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("请先连接控制器！");
            }
        }

        public void FormFloat_btnX_SetHigh_Click()
        {
            if (bConnected)
            {
                DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureSet(true);
                //DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureEnable(true);

                if (Err == DoPE.ERR.NOERROR)
                {
                    //btnX_SetLow.Checked = false;
                    //btnX_SetHigh.Checked = true;

                    floatMenus.btnX_SetLow_Checked(false);
                    floatMenus.btnX_SetHigh_Checked(true);
                }
            }
            else
            {
                MessageBox.Show("请先连接控制器！");
            }
        }

        /// <summary>
        /// IO低压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_SetLow_Click(object sender, EventArgs e)
        {
            if (bConnected)
            {
                DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureSet(false);
                //DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureEnable(false);

                if (Err == DoPE.ERR.NOERROR)
                {
                    //btnX_SetHigh.Checked = false;
                    //btnX_SetLow.Checked = true;

                    floatMenus.btnX_SetHigh_Checked(false);
                    floatMenus.btnX_SetLow_Checked(true);
                }
            }
            else
            {
                MessageBox.Show("请先连接控制器！");
            }
        }

        public void FormFloat_btnX_SetLow_Click()
        {
            if (bConnected)
            {
                DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureSet(false);
                //DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureEnable(false);

                if (Err == DoPE.ERR.NOERROR)
                {
                    btnX_SetHigh.Checked = false;
                    btnX_SetLow.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("请先连接控制器！");
            }
        }

        #endregion 




        /// <summary>
        /// 示波
        /// </summary>
        /// <param name="Block"></param>
        private async void ShowWave(DoPE.OnDataBlock Block)
        {


            //try
            //{
            //X轴坐标长度 = dStep * nTotal
            dStep = 0.01;
            //dStep = 0.0005;
            //if (MyEdc.IsConnected() && bConnected)
            if (chart_machine != null)
            {
                if (!bPause)
                {
                    //for (int i = 50; Block.Data.Length > i; i += 2500)
                    //for (int i = 30; Block.Data.Length >= i; i += 60)
                    //for (int i = 20; Block.Data.Length > i; i += 200)
                    for (int i = 10; Block.Data.Length > i; i += 100)
                        //for (int i = 1; Block.Data.Length > i; i ++)
                    {
                        //绘制Position
                        double y_Position = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_S];
                        //x_Position += nAxisStep;
                        //获取位移曲线最大最小值
                        //if (x_Position == 0)
                        //{
                        //    maxSeries0 = 0;
                        //    minSeries0 = 0;
                        //    maxSeries1 = 0;
                        //    minSeries1 = 0;
                        //    maxSeries2 = 0;
                        //    minSeries2 = 0;
                        //    maxSeries3 = 0;
                        //    minSeries3 = 0;
                        //}
                        //Console.WriteLine("glm1-{0}", y_Position);
                        //if(!valInScaleSetted)
                        if (x_Position == 0)
                        {
                            valInScaleSetted = true;
                            maxSeries0 = y_Position;
                            minSeries0 = y_Position;
                        }
                        if (maxSeries0 <y_Position)maxSeries0 = y_Position;
                        if (minSeries0 > y_Position)minSeries0 = y_Position;

                        Console.WriteLine("glm-{0}-{1}-{2}-{3}", y_Position, i,maxSeries0,minSeries0);
                        if (chart_machine.Series == null)
                        {
                            return;
                        }

                        if (chart_machine.Series[0] != null)
                        {
                            chart_machine.Series[0].Points.AddXY(x_Position, y_Position);

                            x_Position += dStep;

                            if (chart_machine.Series[0].Points.Count >= nTotal )
                            {
                                chart_machine.Series[0].Points.Clear();
                                //chart_machine.Series[1].Points.AddXY(0.0, y_Position);

                                x_Position = 0.0;
                            }
                        }

                        //绘制Load
                        double y_Load = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_F];
                        //x_Load += nAxisStep;
                       // Console.WriteLine("glm2-{0}", y_Load);

                        //获取力曲线最大最小值
                        if (x_Load == 0)
                        {
                            maxSeries1 =  y_Load;
                            minSeries1 = y_Load;
                        }
                        if (maxSeries1 < y_Load) maxSeries1 = y_Load;
                        if (minSeries1 > y_Load) minSeries1 = y_Load;

                        if (chart_machine.Series[1] != null)
                        {
                            chart_machine.Series[1].Points.AddXY(x_Load, y_Load);
                            x_Load += dStep;
                            if (chart_machine.Series[1].Points.Count >= nTotal)
                            {
                                chart_machine.Series[1].Points.Clear();

                                //chart_machine.Series[1].Points.AddXY(0.0, y_Load);
                                x_Load = 0.0;
                            }

                        }

                        //绘制Extension
                        double y_Extension = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_E];
                        //x_Load += nAxisStep;
                        //Console.WriteLine("glm3-{0}", y_Extension);

                        //获取形变曲线最大最小值
                        if (x_Extension == 0)
                        {
                            maxSeries2 =  y_Extension;
                            minSeries2 = y_Extension;
                        }
                        if (maxSeries2 < y_Extension) maxSeries2 = y_Extension;
                        if (minSeries2 > y_Extension) minSeries2 = y_Extension;
                        if (chart_machine.Series[2] != null)
                        {
                            chart_machine.Series[2].Points.AddXY(x_Extension, y_Extension);
                            x_Extension += dStep;
                            if (chart_machine.Series[2].Points.Count >= nTotal)
                            {
                                chart_machine.Series[2].Points.Clear();

                                //chart_machine.Series[2].Points.AddXY(0.0, y_Extension);
                                x_Extension = 0.0;
                            }
                        }

                        //绘制Command
                        double y_Command = Block.Data[i].Data.Command;
                        //x_Load += nAxisStep;
                        //获取命令曲线最大最小值
                        //Console.WriteLine("glm4-{0}", y_Command);
                        //if (!valInScaleSetted2)
                        if (x_Command == 0){
                            valInScaleSetted2 = true;
                            maxSeries3 = y_Command;
                            minSeries3 = y_Command;
                        }
                        if (maxSeries3 < y_Command) maxSeries3 = y_Command;
                        if (minSeries3 > y_Command) minSeries3 = y_Command;
                        var Axis = chart_machine.ChartAreas[0].AxisX;
                        // 获取X轴的最小值和最大值
                        double minValue = Axis.Minimum;
                        double maxValue = Axis.Maximum;

                        if (chart_machine.Series[3] != null)
                        {
                            chart_machine.Series[3].Points.AddXY(x_Command, y_Command);
                            x_Command += dStep;
                            if (chart_machine.Series[3].Points.Count >= nTotal)
                            {
                                chart_machine.Series[3].Points.Clear();

                                //chart_machine.Series[3].Points.AddXY(0.0, y_Command);
                                x_Command = 0.0;
                            }
                        }
                        
                    }


                    autoFittingFlag++;
                    if (autoFittingFlag == nTotal/2)
                    {

                        autoFittingFlag = 0;
                        AutoFittingCurve(maxSeries0, minSeries0, maxSeries1, minSeries1, maxSeries2, minSeries2, maxSeries3, minSeries3);
                    }
                }

            }

            //}
            //catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                //return;
            }

        }
       
        public void AutoFittingCurve(double series0maxY, double series0minY, double series1maxY, double series1minY, double series2maxY, double series2minY, double series3maxY, double series3minY)
        {
            //Console.WriteLine("glmxxx-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}", series0maxY, series0minY, series1maxY, series1minY, series2maxY, series2minY, series3maxY, series3minY);
            //位移y轴自适应
            double series02MaxY = series0maxY;// series0maxY >= series2maxY ? series0maxY : series2maxY;
            double series02minY = series0minY;// series0minY >= series2minY ? series2minY : series0minY;

            double maxSeriesMaxYVal = series02MaxY;
            double maxSeriesMinYVal = series02minY;
            if (chart_machine.Series[3].YAxisType == chart_machine.Series[0].YAxisType)
            {
                if (cb_DrawCommand.Checked)
                {

                    //if (maxSeriesMaxYVal < series3maxY) maxSeriesMaxYVal = series3maxY;
                    //if (maxSeriesMinYVal > series3minY) maxSeriesMinYVal = series3minY;
                }
            }

            double range1 = maxSeriesMaxYVal - maxSeriesMinYVal;
            double totalHeight1 = range1 / 0.85;        // Y 轴总高度的85%
            double padding1 = (totalHeight1 - range1) / 2.0;  // 上下留白

            double yAxisMax1 = maxSeriesMaxYVal + padding1;
            double yAxisMin1 = maxSeriesMinYVal - padding1;
            if (Math.Abs(yAxisMax1 - yAxisMin1) >= 0.1)
            {
                chart_machine.ChartAreas[0].AxisY.Maximum = Math.Round(yAxisMax1, 2);
                chart_machine.ChartAreas[0].AxisY.Minimum = Math.Round(yAxisMin1, 2);
            }
            //Console.WriteLine("glmyyy-{0}-{1}", yAxisMax1, yAxisMin1);
            //力y轴自适应
             maxSeriesMaxYVal = series1maxY;
             maxSeriesMinYVal = series1minY;

            if (chart_machine.Series[3].YAxisType == chart_machine.Series[1].YAxisType)
            {
                if ( cb_DrawCommand.Checked)
                {
                    if (maxSeriesMaxYVal < series3maxY) maxSeriesMaxYVal = series3maxY;
                    if (maxSeriesMinYVal > series3minY) maxSeriesMinYVal = series3minY;
                }
            }

             range1 = maxSeriesMaxYVal - maxSeriesMinYVal;
             totalHeight1 = range1 / 0.85;        // Y 轴总高度的85%
             padding1 = (totalHeight1 - range1) / 2.0;  // 上下留白

             yAxisMax1 = maxSeriesMaxYVal + padding1;
             yAxisMin1 = maxSeriesMinYVal - padding1;
            if (Math.Abs(yAxisMax1 - yAxisMin1) >= 0.1)
            {
                chart_machine.ChartAreas[0].AxisY2.Maximum = Math.Round(yAxisMax1, 2);
                chart_machine.ChartAreas[0].AxisY2.Minimum = Math.Round(yAxisMin1, 2);
            }
            //Console.WriteLine("glmzzz-{0}-{1}", yAxisMax1, yAxisMin1);
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateValues()
        {
            //double phase = Stopwatch.Elapsed.TotalSeconds;
            //double multiplier = 2 * Math.PI / Values.Length;
            //for (int i = 0; i < Values.Length; i++)
            //{
            //    Values[i] = Math.Sin(i * multiplier + phase);
            //}

            //double[] sin = Generate.Sin(51);

            //// add a signal plot to the plot
            //formsPlot1.Plot.Add();

            //formsPlot1.Refresh();
        }

        //测试按钮
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //formsPlot1.Plot.AxisSet(0, .05, -1.1, 1.1); // we know what the limits should be
            StartCommunicationWithEdcTimer.Enabled = true; // start automatic updates
        }


        /// <summary>
        /// 断开设备连接
        /// </summary>
        private void Disconnect()
        {
            if (bConnected)
            {
                MyEdc.Dispose();
                bConnected = false;

                SetControlEnable(true);

                EnableButton();
            }
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           LogHelper.ResetLogParamsIni();
        }


        private void timer_UpdateData_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_SystemTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (!bConnected)
            {
                return;
            }

            TimeSpan elapsed = stopwatch.Elapsed;
            guiTime.Text = string.Format(@"{0:D2}:{1:D2}:{2:D2}", (int)elapsed.TotalHours, elapsed.Minutes, elapsed.Seconds);

            //EnableButton();
        }


        /// <summary>
        /// Calculate Y value for random data
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        //private double CalculateYValue(int i)
        //{
        //    // Use the latest value and generate some difference to it.
        //    double nextY = (_previousTemperature[i] + (_rand[i].NextDouble() - 0.5)) / 1000 /** 8*/;

        //    // Limit the value between 100...
        //    if (nextY > 50)
        //    {
        //        nextY = 50;
        //    }

        //    // ... and 0.
        //    if (nextY < -50)
        //    {
        //        nextY = -50;
        //    }

        //    // Update the latest values.
        //    _previousTemperature[i] = nextY;

        //    return nextY;
        //}


        /// <summary>
        /// Move.POS
        /// </summary>
        /// <param name="control"></param>
        /// <param name="speed"></param>
        /// <param name="destination"></param>
        public void MovePos(DoPE.CTRL control, double speed, double destination)
        {
            DoPE.ERR error = MyEdc.Move.Pos(control, speed, destination, ref MyTan);

            //正常返回，开始计时
            if (error == DoPE.ERR.NOERROR)
            {
                stopwatch.Start();
            }
        }


        /// <summary>
        /// Move.POS_A
        /// </summary>
        /// <param name="control"></param>
        /// <param name="speed"></param>
        /// <param name="destination"></param>
        public void MovePos_A(DoPE.CTRL control, double acc, double speed, double dec, double destination)
        {
            DoPE.ERR error = MyEdc.Move.Pos_A(control, acc, speed, dec, destination, ref MyTan);

            //正常返回，开始计时
            if (error == DoPE.ERR.NOERROR)
            {
                stopwatch.Start();
            }

        }
        /// <summary>
        /// 设置命令曲线坐标轴
        /// </summary>
        /// <param name="seriesType">曲线类型，根据命令类型得出，比如按照dopectrl中的参数得到</param>
        /// <param name="axisType">坐标轴编号primary or secondary</param>
        public void SetCmdSeriesAxisY(int cmdType)
        {
            switch (cmdType)
            {
                case 0:            //position
                    chart_machine.Series[3].YAxisType = AxisType.Primary;
                    break;
                case 1:            //Load
                    chart_machine.Series[3].YAxisType = AxisType.Secondary;
                    break;
                case 2:           //Extension
                    chart_machine.Series[3].YAxisType = AxisType.Primary;
                    break;
                default:      //position
                    chart_machine.Series[3].YAxisType = AxisType.Primary;
                    break;
            }
        }

        public void MoveDynCycles(DoPE.DYN_WAVEFORM WaveForm, bool Modify, DoPE.DYN_PEAKCTRL PeakCtrl, DoPE.CTRL MoveCtrl, 
            bool RelativeDestination, double SpeedToStart, double Offset, double Amplitude, double HaltAtPlusAmplitude, double HaltAtMinusAmplitude, 
            double Frequency, int HalfCycles, double SpeedToDestination, double Destination, DoPE.DYN_SWEEP SweepFrequencyMode)
        {
            if (isRunning)
            {
                Modify = true;
            }
            else
            {
                Modify = false;
            }
            DoPE.ERR error = MyEdc.Move.DynCycles(WaveForm, Modify, PeakCtrl, MoveCtrl, false, SpeedToStart, Offset, Amplitude, 0.0, 
                0.0, Frequency, HalfCycles, SpeedToDestination, Destination, SweepFrequencyMode, 
                0.0, 0.0, 0, 0, 0.0, 0.0, 0, 0, 0.0, 0.0, 0, 0, 0.0, 0.0, 0, 0, 0.0, 0.0, 0.0, ref MyTan);

            //正常返回，开始计时
            if (error == DoPE.ERR.NOERROR)
            {
                //开始计时
                timer_UpdateData.Start();

                isRunning = true;
                SetControlEnable(false);
                nTestCount = HalfCycles;
                stopwatch.Start();

                //读取最后一次实验次数
                StringBuilder strTmp = new StringBuilder(255);
                IniFileHelper.GetIniString("Setting", "TestCount", "0", strTmp, strTmp.Capacity);
                nPreTestCount = int.Parse(strTmp.ToString());
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MoveCtrl"></param>
        /// <param name="Speed"></param>
        /// <param name="LimitMode"></param>
        /// <param name="Limit"></param>
        /// <param name="DestinationCtrl"></param>
        /// <param name="Destination"></param>
        /// <param name="DestMode"></param>
        public void MovePosExt(DoPE.CTRL MoveCtrl, double Speed, LIMITMODE LimitMode, double Limit, CTRL DestinationCtrl, double Destination,
            DESTMODE DestMode)
        {
            DoPE.ERR error = MyEdc.Move.PosExt(MoveCtrl, Speed, LimitMode, Limit, DestinationCtrl, Destination, DestMode, ref MyTan);

            //正常返回，开始计时
            if (error == DoPE.ERR.NOERROR)
            {
                //开始计时
                timer_UpdateData.Start();

                isRunning = true;
                SetControlEnable(false);
                //nTestCount = HalfCycles;
                stopwatch.Start();

                //读取最后一次实验次数
                StringBuilder strTmp = new StringBuilder(255);
                IniFileHelper.GetIniString("Setting", "TestCount", "0", strTmp, strTmp.Capacity);
                nPreTestCount = int.Parse(strTmp.ToString());
            }
        }

        public void SetupResetXHead()
        {
            DoPE.ERR error = MyEdc.Setup.InitializeResetXHead();
        }


            #region 快捷工具栏消息响应事件

            /// <summary>
            /// 工具栏POS
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void posToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bConnected)
            {
                FrmPos frmPos = new FrmPos();
                frmPos.Show();
            }
            else
            {
                MessageBox.Show("请先激活控制器!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        /// <summary>
        /// 工具栏DYNCTRL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dynCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bConnected)
            {
                FrmDynCtrl frmDynCtrl = new FrmDynCtrl();
                frmDynCtrl.Show();
            }
            else
            {
                MessageBox.Show("请先激活控制器!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// 工具栏POS_A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pos_AtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (bConnected)
            {
                FrmPos_A frmPos = new FrmPos_A();
                frmPos.Show();
            }
            else
            {
                MessageBox.Show("请先激活控制器!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        /// <summary>
        /// 显示日志窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }


        /// <summary>
        /// 启动和暂停绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startStopDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bPause = !bPause;


            if (bPause)
            {
                startStopDrawToolStripMenuItem.Text = GetValueFromLanguageFile("startStopDrawToolStripMenuItemPause");
            }
            else
            {
                startStopDrawToolStripMenuItem.Text = GetValueFromLanguageFile("startStopDrawToolStripMenuItem");
            }

            chart_machine.Enabled = false;
        }


        # endregion 快捷工具栏消息响应事件

        /// <summary>
        /// 根据控件名称获取语言文件中的值
        /// </summary>
        /// <returns></returns>
        private string GetValueFromLanguageFile(string keyName)
        {
            var langData = LanguageLoad.LoadLang(System.IO.Directory.GetCurrentDirectory() + "\\Lang\\" + strLanguage + ".json");

            //循环界面控件替换成指定的语言
            if (langData.TryGetValue(this.Name, out var dictionaryVals))
            {
                return dictionaryVals[keyName];
            }
            else
                return "-1";

        }


        /// <summary>
        /// 设置部分控件禁用
        /// </summary>
        /// <param name="bState"></param>
        private void SetControlEnable(bool bState)
        {
            cb_TarePos.Enabled = bState;
            cb_TareLoad.Enabled = bState;
            cb_TareExt.Enabled = bState;
            cb_TareTime.Enabled = bState;

            //上下控制禁用
            btnX_MoveQuickUp.Enabled = bState;
            bntX_MoveUp.Enabled = bState;
            bntX_MoveDown.Enabled = bState;
            btnX_QuickMoveDown.Enabled = bState;

            //Formfloat上下禁用 
            floatMenus.SetControlEnable(bState);
        }



        private void lblTime_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 位移清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_TarePos_CheckedChanged(object sender, EventArgs e)
        {
            if (isRunning)
            {
                return;
            }
            else
            {
                if (cb_TarePos.Checked)
                {
                    MyEdc.Tare.Tare(DoPE.SENSOR.SENSOR_S, true);
                }
                else
                {
                    MyEdc.Tare.Tare(DoPE.SENSOR.SENSOR_S, false);
                }
            }
        }


        /// <summary>
        /// 试验力清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_TareLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (isRunning)
            {
                return;
            }
            else
            {
                if (cb_TareLoad.Checked)
                {
                    MyEdc.Tare.Tare(DoPE.SENSOR.SENSOR_F, true);
                }
                else
                {
                    MyEdc.Tare.Tare(DoPE.SENSOR.SENSOR_F, false);
                }
            }
        }


        /// <summary>
        /// 变形清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_TareExt_CheckedChanged(object sender, EventArgs e)
        {
            if (isRunning)
            {
                return;
            }
            else
            {
                if (cb_TareExt.Checked)
                {
                    MyEdc.Tare.Tare(DoPE.SENSOR.SENSOR_E, true);
                }
                else
                {
                    MyEdc.Tare.Tare(DoPE.SENSOR.SENSOR_E, false);
                }
            }
        }


        public void GetXaxisScale()
        {
            if (chart_machine != null)
            {
                double dMax = chart_machine.ChartAreas[0].AxisX.Maximum;
                double dMin = chart_machine.ChartAreas[0].AxisX.Minimum;
                if ((dMax - dMin) > 0)
                {
                    nAxisStep = 1 / ((dMax - dMin) /** 2*/);
                }
                else
                {
                    nAxisStep = 0.1;
                }
            }
        }



        //测试寻峰算法
        public static List<double> FindPeaks(int[] data)
        {
            var peaks = new List<double>();

            if (data.Length < 3)
            {
                return peaks; // 如果数组长度小于3，则不可能有峰值
            }

            for (int i = 1; i < data.Length - 1; i++)
            {
                // 检查当前点是否为峰值
                if (data[i] > data[i - 1] && data[i] > data[i + 1])
                {
                    peaks.Add(i); // 添加峰值的位置
                }
            }

            return peaks;
        }

        private void cb_DrawPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DrawPosition.Checked)
            {
                chart_machine.Series[0].Enabled = true;
            }
            else
            {
                chart_machine.Series[0].Enabled = false;
            }

            //int selectConut = 0;
            //while (chart_machine.Series.Count > 7)
            //{
            //    chart_machine.Series.RemoveAt((chart_machine.Series.Count - 1));
            //}

            //while (chart_machine.ChartAreas.Count > 1)
            //{
            //    chart_machine.ChartAreas.RemoveAt((chart_machine.ChartAreas.Count - 1));
            //}

            //foreach (Control c in this.Controls)
            //{
            //    if (c is CheckBox && ((CheckBox)c).Checked == true)
            //    {
            //        selectConut++;
            //    }
            //}

            //chart_machine.Series[cb_DrawPosition.Text].Enabled = cb_DrawPosition.Checked;

            //float axisOffset = 12;
            //CreateYAxis(chart_machine, chart_machine.ChartAreas["ChartArea1"], chart_machine.Series["变形"], axisOffset, 3);
            //axisOffset += 6;

        }

        private void cb_DrawLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DrawLoad.Checked)
            {
                chart_machine.Series[1].Enabled = true;
            }
            else
            {
                chart_machine.Series[1].Enabled = false;
            }
        }

        private void cb_DrawExtension_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DrawExtension.Checked)
            {
                chart_machine.Series[2].Enabled = true;
            }
            else
            {
                chart_machine.Series[2].Enabled = false;
            }

            //int selectConut = 0;
            //while (chart_machine.Series.Count > 4)
            //{
            //    chart_machine.Series.RemoveAt((chart_machine.Series.Count - 1));
            //}

            //while (chart_machine.ChartAreas.Count > 1)
            //{
            //    chart_machine.ChartAreas.RemoveAt((chart_machine.ChartAreas.Count - 1));
            //}

            //foreach (Control c in this.Controls)
            //{
            //    if (c is CheckBox && ((CheckBox)c).Checked == true)
            //    {
            //        selectConut++;
            //    }
            //}

            //chart_machine.Series[cb_DrawPosition.Text].Enabled = cb_DrawExtension.Checked;

            //if (cb_DrawExtension.Checked)
            //{
            //    //x坐标点
            //    int positionx = 0;
            //    //char宽度计数
            //    int charWith = 0;
            //    positionx = positionx == 1 ? positionx += 10 : positionx += 10;
            //    charWith += 5;

            //    //chart_machine.ChartAreas["ChartArea1"].Position = new ElementPosition(positionx, 10, 100 - charWith, 85);
            //    chart_machine.ChartAreas["ChartArea1"].InnerPlotPosition = new ElementPosition(10, 0, 100 - charWith - 1, 90);

            //    float axisOffset = 12;
            //    CreateYAxis(chart_machine, chart_machine.ChartAreas["ChartArea1"], chart_machine.Series["变形"], axisOffset, 3);
            //    axisOffset += 6;
            //}
        }

        private void cb_DrawCommand_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DrawCommand.Checked)
            {
                chart_machine.Series[3].Enabled = cb_DrawCommand.Checked;
            }
            else
            {
                chart_machine.Series[3].Enabled = false;
            }

            //int selectConut = 0;
            //while (chart_machine.Series.Count > 4)
            //{
            //    chart_machine.Series.RemoveAt((chart_machine.Series.Count - 1));
            //}

            //while (chart_machine.ChartAreas.Count > 1)
            //{
            //    chart_machine.ChartAreas.RemoveAt((chart_machine.ChartAreas.Count - 1));
            //}

            //foreach (Control c in this.Controls)
            //{
            //    if (c is CheckBox && ((CheckBox)c).Checked == true)
            //    {
            //        selectConut++;
            //    }
            //}

            //chart_machine.Series[cb_DrawCommand.Text].Enabled = cb_DrawCommand.Checked;

            //if (cb_DrawCommand.Checked)
            //{
            //    //x坐标点
            //    int positionx = 0;
            //    //char宽度计数
            //    int charWith = 0;
            //    positionx = positionx == 1 ? positionx += 11 : positionx += 8;
            //    charWith += 6;

            //    chart_machine.ChartAreas["ChartArea1"].Position = new ElementPosition(positionx, 10, 100 - charWith, 85);
            //    chart_machine.ChartAreas["ChartArea1"].InnerPlotPosition = new ElementPosition(10, 0, 50 - charWith, 90);

            //    float axisOffset = 2;
            //    CreateYAxis_New(chart_machine, chart_machine.ChartAreas["ChartArea1"], chart_machine.Series["命令"], axisOffset, 1);
            //    axisOffset += 3;
            //}

        }


        public void SeriesCheckChanged()
        {


        }



        //运行时才能决定是否执行内联
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public ushort setUInt16(float src, ushort k = 1)
        {
            return (ushort)(src * k);
        }


        /// <summary>
        /// 加载配置文件
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            string strConfigSetion = this.Name;

            //软件信息
            IniFileHelper.GetIniString("SoftWareInfo", "Name", "0", strTmp, strTmp.Capacity);
            this.Text = strTmp.ToString();
            //获取EDC设备id
            StringBuilder devIdEncrypted = new StringBuilder(255);
            bool idRet = IniFileHelper.GetIniString("Device", "DeviceID", "0", devIdEncrypted, devIdEncrypted.Capacity);
            string idEncry=devIdEncrypted.ToString();
            if (idEncry != "0" && idEncry != "")
            {
                devId = new StringBuilder(DESEncrypt.Decrypt(idEncry));
            }

            //读取上次的试验次数
            IniFileHelper.GetIniString("Setting", "TestCount", "0", strTmp, strTmp.Capacity);
            nPreTestCount = int.Parse(strTmp.ToString());
            tbX_TestCount.Text = strTmp.ToString();
            tbX_TestCycles.Text = tbX_TestCount.Text;

            //按试验次数记录日志
            IniFileHelper.GetIniString("Setting", "CountLog", "0", strTmp, strTmp.Capacity);
            nCountLog = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("Setting", "Language", "0", strTmp, strTmp.Capacity);
            strLanguage = strTmp.ToString();


            //停机保护选项
            IniFileHelper.GetIniString("FrmSystemSetting", "限位保护选项", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOptionType = strTmp.ToString();

            #region 位移保护
            IniFileHelper.GetIniString("FrmSystemSetting", "位移峰值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMaxOut = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "位移峰值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMaxOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "位移谷值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMinOut = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "位移谷值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMinOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "位移峰值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMaxIn = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "位移峰值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMaxIn_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "位移谷值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMinIn = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "位移谷值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMinIn_Effect = strTmp.ToString() == "0" ? false : true;
            #endregion 位移保护

            #region 试验力保护
            IniFileHelper.GetIniString("FrmSystemSetting", "试验力峰值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMaxOut = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力峰值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMaxOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力谷值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMinOut = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力谷值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMinOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力峰值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMaxIn = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力峰值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMaxIn_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力谷值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMinIn = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力谷值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMinIn_Effect = strTmp.ToString() == "0" ? false : true;
            #endregion 试验力保护

            #region 变形保护
            IniFileHelper.GetIniString("FrmSystemSetting", "变形峰值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMaxOut = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "变形峰值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMaxOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "变形谷值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMinOut = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "变形谷值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMinOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "变形峰值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMaxIn = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "变形峰值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMaxIn_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "变形谷值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMinIn = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmSystemSetting", "变形谷值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMinIn_Effect = strTmp.ToString() == "0" ? false : true;
            #endregion 变形保护

            #region 系统保护
            IniFileHelper.GetIniString("SysProtectSetting", "OverLoadPercent_Flag", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_OverLoadPercent_Flag = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("SysProtectSetting", "OverLoad_Percent", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_OverLoadPercent = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("SysProtectSetting", "OverLoadForce_Flag", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_OverLoadForce_Flag = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("SysProtectSetting", "OverLoad_Force", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_OverLoadForce = double.Parse(strTmp.ToString());

            #endregion 系统保护

            #region 按键功能常数
            IniFileHelper.GetIniString("PushButtonFunctionConstant", "Up", "0", strTmp, strTmp.Capacity);
            btnUpConstantVal = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "HurryUp", "0", strTmp, strTmp.Capacity);
            btnHurryUpConstantVal = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "Down", "0", strTmp, strTmp.Capacity);
            btnDownConstantVal = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "HurryDown", "0", strTmp, strTmp.Capacity);
            btnHurryDownConstantVal = double.Parse(strTmp.ToString());
            #endregion 按键功能常数

            IniFileHelper.GetIniString("FrmSetChartAxisY", "TimeX_MAX", "5", strTmp, strTmp.Capacity);
            AxisXMax = double.Parse(strTmp.ToString());
            chart_machine.ChartAreas[0].AxisX.Maximum = AxisXMax;

            IniFileHelper.GetIniString("FrmSetChartAxisY", "PositionEnable", "0", strTmp, strTmp.Capacity);
            cb_DrawPosition.Checked = true;// strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSetChartAxisY", "LoadEnable", "0", strTmp, strTmp.Capacity);
            cb_DrawLoad.Checked = true;// strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSetChartAxisY", "ExtEnable", "0", strTmp, strTmp.Capacity);
            cb_DrawExtension.Checked = true;// strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSetChartAxisY", "CommandEnable", "0", strTmp, strTmp.Capacity);
            cb_DrawCommand.Checked = true;// strTmp.ToString() == "0" ? false : true;

        }

        private void ToolStripMenuItem_SystemSetting_Click(object sender, EventArgs e)
        {
            FrmSystemSetting frmSystemSetting = new FrmSystemSetting();
            frmSystemSetting.ShowDialog();
        }


        public void CreateYAxis_New(Chart chart, ChartArea area, Series series, float axisOffset, float labelsSize)
        {
            // Create new chart area for original series
            ChartArea areaSeries = chart.ChartAreas.Add("ChartArea_" + series.Name);
            areaSeries.BackColor = Color.Transparent;
            areaSeries.BorderColor = Color.Transparent;
            areaSeries.Position.FromRectangleF(area.Position.ToRectangleF());
            areaSeries.InnerPlotPosition.FromRectangleF(area.InnerPlotPosition.ToRectangleF());
            areaSeries.AxisX.MajorGrid.Enabled = false;
            areaSeries.AxisX.MajorTickMark.Enabled = false;
            areaSeries.AxisX.LabelStyle.Enabled = false;
            areaSeries.AxisY.MajorGrid.Enabled = true;
            areaSeries.AxisY.MajorTickMark.Enabled = true;
            areaSeries.AxisY.LabelStyle.Enabled = true;
            areaSeries.AxisY.IsStartedFromZero = area.AxisY.IsStartedFromZero;

            series.ChartArea = areaSeries.Name;

            // Create new chart area for axis
            ChartArea areaAxis = chart.ChartAreas.Add("AxisY_" + series.ChartArea);
            areaAxis.BackColor = Color.Transparent;
            areaAxis.BorderColor = Color.Transparent;
            areaAxis.Position.FromRectangleF(chart.ChartAreas[series.ChartArea].Position.ToRectangleF());
            areaAxis.InnerPlotPosition.FromRectangleF(chart.ChartAreas[series.ChartArea].InnerPlotPosition.ToRectangleF());

            // Create a copy of specified series
            Series seriesCopy = chart.Series.Add(series.Name + "_Copy");
            seriesCopy.ChartType = series.ChartType;
            foreach (DataPoint point in series.Points)
            {
                seriesCopy.Points.AddXY(point.XValue, point.YValues[0]);
            }

            // Hide copied series
            seriesCopy.IsVisibleInLegend = false;
            seriesCopy.Color = Color.Transparent;
            seriesCopy.BorderColor = Color.Transparent;
            seriesCopy.ChartArea = areaAxis.Name;

            // Disable drid lines & tickmarks
            areaAxis.AxisX.LineWidth = 0;
            areaAxis.AxisX.MajorGrid.Enabled = false;
            areaAxis.AxisX.MajorTickMark.Enabled = false;
            areaAxis.AxisX.LabelStyle.Enabled = false;
            areaAxis.AxisY.MajorGrid.Enabled = true;
            areaAxis.AxisY.IsStartedFromZero = area.AxisY.IsStartedFromZero;
            areaAxis.AxisY.LabelStyle.Font = area.AxisY.LabelStyle.Font;

            // Adjust area position
            //areaAxis.Position.X -= axisOffset;
            areaAxis.InnerPlotPosition.X += labelsSize;

        }


        /// <summary>
        /// Creates Y axis for the specified series.
        /// </summary>
        /// <param name="chart">Chart control.</param>
        /// <param name="area">Original chart area.</param>
        /// <param name="series">Series.</param>
        /// <param name="axisOffset">New Y axis offset in relative coordinates.</param>
        /// <param name="labelsSize">Extar space for new Y axis labels in relative coordinates.</param>
        public void CreateYAxis(Chart chart, ChartArea area, Series series, float axisOffset, float labelsSize)
        {
            try
            {
                ChartArea areaSeries = chart.ChartAreas.Add("ChartArea_" + series.Name);
                areaSeries.BackColor = Color.Transparent;
                areaSeries.BorderColor = Color.Transparent;
                areaSeries.Position.FromRectangleF(area.Position.ToRectangleF());
                areaSeries.InnerPlotPosition.FromRectangleF(area.InnerPlotPosition.ToRectangleF());
                areaSeries.AxisX.MajorGrid.Enabled = false;
                areaSeries.AxisX.MajorTickMark.Enabled = false;
                areaSeries.AxisX.LabelStyle.Enabled = false;
                areaSeries.AxisY.MajorGrid.Enabled = false;
                areaSeries.AxisY.MajorTickMark.Enabled = false;
                areaSeries.AxisY.LabelStyle.Enabled = false;
                areaSeries.AxisY.IsStartedFromZero = area.AxisY.IsStartedFromZero;
                areaSeries.CursorX.AutoScroll = true;
                areaSeries.AxisX.ScrollBar.Enabled = true;
                areaSeries.CursorX.IsUserEnabled = true;
                areaSeries.CursorX.IsUserSelectionEnabled = true;
                areaSeries.AxisX.ScaleView.Zoomable = true;
                areaSeries.AxisX.ScaleView.Position = 1;
                //areaSeries.AxisX.ScaleView.Size = 10;
                areaSeries.AxisX.ScaleView.Position = 1D;
                areaSeries.AxisX.ScaleView.Size = area.AxisX.ScaleView.Size;
                areaSeries.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Lime;
                areaSeries.AxisX.ScrollBar.LineColor = System.Drawing.Color.Yellow;
                areaSeries.CursorX.IsUserEnabled = true;
                areaSeries.CursorX.IsUserSelectionEnabled = true;

                areaSeries.AxisY.LineColor = area.AxisY.LineColor;
                areaSeries.AxisY.TitleForeColor = area.AxisY.TitleForeColor;
                areaSeries.AxisY.TitleAlignment = StringAlignment.Far;
                areaSeries.AxisY.LabelStyle.ForeColor = area.AxisY.LabelStyle.ForeColor;
                areaSeries.AxisX.IsMarginVisible = false;
                areaSeries.AxisX.ScaleView.Zoomable = false;
                areaSeries.AxisY.ScaleView.Zoomable = false;
                if (null != m_ChartAxixYParmList)
                {
                    ChartAxisYParm data = m_ChartAxixYParmList.FirstOrDefault(t => t.ItemName.Equals(series.Name));
                    if (null != data)
                    {
                        areaSeries.AxisY.Interval = data.Interval;//100刻度间隔
                        if (data.Maximum > 0)
                        {
                            areaSeries.AxisY.Maximum = data.Maximum;
                        }
                        areaSeries.AxisY.Minimum = data.Minimum;
                    }
                }

                series.ChartArea = areaSeries.Name;

                //areaSeries.AxisX.Interval = 0.5;//100刻度间隔
                // Create new chart area for axis
                ChartArea areaAxis = chart.ChartAreas.Add("AxisY_" + series.ChartArea);
                areaAxis.BackColor = Color.Transparent;
                areaAxis.BorderColor = Color.Transparent;
                areaAxis.Position.FromRectangleF(chart.ChartAreas[series.ChartArea].Position.ToRectangleF());
                areaAxis.InnerPlotPosition.FromRectangleF(chart.ChartAreas[series.ChartArea].InnerPlotPosition.ToRectangleF());
                //areaAxis.AxisX.Interval = 0.5;//100刻度间隔
                // Create a copy of specified series
                Series seriesCopy = chart.Series.Add(series.Name + "_Copy");
                seriesCopy.ChartType = series.ChartType;
                if (null != m_ChartAxixYParmList)
                {
                    ChartAxisYParm data = m_ChartAxixYParmList.FirstOrDefault(t => t.ItemName.Equals(series.Name));
                    if (null != data)
                    {
                        areaAxis.AxisY.Interval = data.Interval;//100刻度间隔
                        if (data.Maximum > 0)
                        {
                            areaAxis.AxisY.Maximum = data.Maximum;
                        }

                        areaAxis.AxisY.Minimum = data.Minimum;
                    }
                }

                foreach (DataPoint point in series.Points)
                {
                    seriesCopy.Points.AddXY(point.XValue, point.YValues[0]);
                }

                // Hide copied series
                seriesCopy.IsVisibleInLegend = series.IsVisibleInLegend;
                seriesCopy.Color = Color.Transparent;
                seriesCopy.BorderColor = Color.Transparent;
                seriesCopy.ChartArea = areaAxis.Name;

                // Disable drid lines & tickmarks
                areaAxis.AxisX.LineWidth = 0;
                areaAxis.AxisX.MajorGrid.Enabled = false;
                areaAxis.AxisX.MajorTickMark.Enabled = false;
                areaAxis.AxisX.LabelStyle.Enabled = false;
                areaAxis.AxisY.MajorGrid.Enabled = false;
                areaAxis.AxisY.IsStartedFromZero = area.AxisY.IsStartedFromZero;
                areaAxis.AxisY.LabelStyle.Font = area.AxisY.LabelStyle.Font;
                areaAxis.AxisX.IsMarginVisible = false;
                areaAxis.AxisX.ScaleView.Zoomable = false;
                areaAxis.AxisY.ScaleView.Zoomable = false;

                if (m_ChartAxixYParmList == null)
                {
                    m_ChartAxixYParmList = new List<ChartAxisYParm>();
                }

                if (null != m_ChartAxixYParmList)
                {
                    ChartAxisYParm data = m_ChartAxixYParmList.FirstOrDefault(t => t.ItemName.Equals(series.Name));
                    if (null == data)
                    {
                        ChartAxisYParm item = new ChartAxisYParm();
                        item.Interval = area.AxisY.Interval;//100刻度间隔
                        item.Maximum = area.AxisY.Maximum;
                        item.Minimum = area.AxisY.Minimum;
                        item.ItemName = series.Name;
                        m_ChartAxixYParmList.Add(item);
                    }
                    else
                    {
                        foreach (var item in m_ChartAxixYParmList)
                        {
                            if (item.ItemName.Equals(series.Name))
                            {
                                item.Interval = area.AxisY.Interval;//100刻度间隔
                                item.Maximum = area.AxisY.Maximum;
                                item.Minimum = area.AxisY.Minimum;
                                item.ItemName = series.Name;
                            }
                        }
                    }
                }

                if (series.Name.Equals("Rn浓度"))
                {
                    areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(65, 140, 240);
                    areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(65, 140, 240);
                    areaAxis.AxisY.Title = "C_Rn";
                    areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(252, 180, 65);
                }
                else if (series.Name.Equals("Rn误差"))
                {
                    //areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(252, 180, 65);
                    //areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(252, 180, 65);
                    //areaAxis.AxisY.Title = "Rn误差";
                    //areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    //areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(252, 180, 65);

                }
                else if (series.Name.Equals("变形"))
                {
                    areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(224, 64, 10);
                    areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(224, 64, 10);
                    areaAxis.AxisY.Title = "变形";
                    areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(224, 64, 10);
                }
                else if (series.Name.Equals("CRnInWater误差"))
                {
                    //areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(3, 100, 147);
                    //areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(3, 100, 147);
                    //areaAxis.AxisY.Title = "CRnInWater误差";
                    //areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    //areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(3, 100, 147);
                }
                else if (series.Name.Equals("命令"))
                {
                    areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(130, 130, 130);
                    areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
                    areaAxis.AxisY.Title = "命令";
                    areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
                }
                else if (series.Name.Equals("温度"))
                {
                    areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(26, 59, 105);
                    areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(26, 59, 105);
                    areaAxis.AxisY.Title = "气温";
                    areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(26, 59, 105);
                }
                else if (series.Name.Equals("湿度"))
                {
                    areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(255, 204, 44);
                    areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(255, 204, 44);
                    areaAxis.AxisY.Title = "湿度";
                    areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(255, 204, 44);
                }
                else if (series.Name.Equals("大气压"))
                {
                    areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(18, 25, 221);
                    areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(18, 25, 221);
                    areaAxis.AxisY.Title = "大气压";
                    areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(18, 25, 221);
                }
                else if (series.Name.Equals("电量"))
                {
                    areaAxis.AxisY.LineColor = System.Drawing.Color.FromArgb(124, 46, 21);
                    areaAxis.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(124, 46, 21);
                    areaAxis.AxisY.Title = "电量";
                    areaAxis.AxisY.TitleAlignment = StringAlignment.Far;
                    areaAxis.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(124, 46, 21);
                }

                if (!series.Name.Equals("CRnInWater误差"))
                {
                    // Adjust area position
                    if (areaAxis.Position.X - axisOffset > 100)
                    {
                        areaAxis.Position.X = 100;
                    }
                    else if (areaAxis.Position.X - axisOffset < 0)
                    {
                        areaAxis.Position.X = 0;
                    }
                    else
                    {
                        areaAxis.Position.X -= axisOffset;
                    }

                    if (areaAxis.InnerPlotPosition.X + labelsSize > 100)
                    {
                        areaAxis.InnerPlotPosition.X = 100;
                    }
                    else if (areaAxis.InnerPlotPosition.X + labelsSize < 0)
                    {
                        areaAxis.InnerPlotPosition.X = 0;
                    }
                    else
                    {
                        areaAxis.InnerPlotPosition.X += labelsSize;
                    }
                }
            }
            catch (Exception ex)
            {
                //MsgLog.WriteLog(" Creates Y axis for the specified series.", ex);
                Console.WriteLine("class " + ex.Message);
                Console.WriteLine("class " + ex);
                MessageBox.Show("出现意外错误：：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            // Create new chart area for original series

        }


        /// <summary>
        /// 打开日志文件目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_OpenLogsDir_Click(object sender, EventArgs e)
        {
            string strLogFilePath = "Logs";
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + "\\"+ strLogFilePath);
        }


        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public SensorCorrectionTable/*StiffnessCorrectionTable*/ ParseStiffnessCorrection(IConfigurationSection section)
        {
            int corrNo = int.Parse(section["CorrNo"] ?? "0");

            double[] dLoad = new double[STIFF_CORR_MAX];
            double[] dDeformation = new double[STIFF_CORR_MAX];

            double S2Data_0 = double.Parse(section["S2Data_0"] ?? "0");
            double S1Data_1 = double.Parse(section["S1Data_1"] ?? "0");

            for (int i = 0; i < corrNo; i ++)
            {
                string strLoadIndex = string.Format(@"S1Data_{0}", i);
                dLoad[i] = double.Parse(section[strLoadIndex] ?? "0") * 1000;

                string strDeformationIndex = string.Format(@"S2Data_{0}", i);
                dDeformation[i] = double.Parse(section[strDeformationIndex] ?? "0");
            }

            //StiffnessCorrectionTable stiffnessCorrectionTable = new StiffnessCorrectionTable();
            //stiffnessCorrectionTable.CorrNo = corrNo;
            //stiffnessCorrectionTable.Load = dLoad;
            //stiffnessCorrectionTable.Deformation = dDeformation;

            SensorCorrectionTable stiffnessCorrectionTable = new SensorCorrectionTable();
            stiffnessCorrectionTable.CorrNo = corrNo;
            stiffnessCorrectionTable.S1Correction = dLoad;
            stiffnessCorrectionTable.S2Value = dDeformation;

            return stiffnessCorrectionTable;
        }


        private void btnX_AxisPOSY_MinUp_Click(object sender, EventArgs e)
        {
            if (Chart_Pos_Step >= (chart_machine.ChartAreas[0].AxisY.Maximum - chart_machine.ChartAreas[0].AxisY.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                chart_machine.ChartAreas[0].AxisY.Minimum += Chart_Pos_Step;
            }
        }

        private void btnX_AsixPOSY_MinDown_Click(object sender, EventArgs e)
        {
            chart_machine.ChartAreas[0].AxisY.Minimum -= Chart_Pos_Step;
        }

        private void btnX_AxisPOSY_MaxUp_Click(object sender, EventArgs e)
        {
            chart_machine.ChartAreas[0].AxisY.Maximum += Chart_Pos_Step;
        }

        private void btnX_AxisPOSY_MaxDown_Click(object sender, EventArgs e)
        {
            if (Chart_Pos_Step >= (chart_machine.ChartAreas[0].AxisY.Maximum - chart_machine.ChartAreas[0].AxisY.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                chart_machine.ChartAreas[0].AxisY.Maximum -= Chart_Pos_Step;
            }

        }

        private void btnX_AxisLoadY_MaxUp_Click(object sender, EventArgs e)
        {
            chart_machine.ChartAreas[0].AxisY2.Maximum += Chart_Load_Step;
        }

        private void btnX_AxisLoadY_MaxDown_Click(object sender, EventArgs e)
        {
            if (Chart_Load_Step >= (chart_machine.ChartAreas[0].AxisY.Maximum - chart_machine.ChartAreas[0].AxisY.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                chart_machine.ChartAreas[0].AxisY2.Maximum -= Chart_Load_Step;
            }
        }

        private void btnX_AxisLoadY_MinUp_Click(object sender, EventArgs e)
        {
            if (Chart_Load_Step >= (chart_machine.ChartAreas[0].AxisY.Maximum - chart_machine.ChartAreas[0].AxisY.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            { 
                chart_machine.ChartAreas[0].AxisY2.Minimum += Chart_Load_Step;
            }
        }

        private void btnX_AxisLoadY_MinDown_Click(object sender, EventArgs e)
        {
            chart_machine.ChartAreas[0].AxisY2.Minimum -= Chart_Load_Step;
        }


        public void RefreshDeviceID(string strID)
        {
            devId = new StringBuilder(strID);
            //Console.WriteLine("refresh_controls:{0}",strControl);
        }

        private double CheckYAxis(double maxAxis, double minAxis)
        {
            if ((maxAxis - minAxis) <= 0)
            {
                return 0;
            }

            return 0.0;
        }


        /// <summary>
        /// 右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart_machine_DoubleClick(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 使用校正配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdjustToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件 (*.corr)|*.corr";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddIniFile(ofd.FileName);

                IConfiguration config = builder.Build();
                var correctionTable = ParseStiffnessCorrection(config.GetSection("SensorCorrection"));

                DoPE.ERR SSCStatre = mainform.MyEdc.Corr.SetSensorCorrection(DoPE.SENSOR.SENSOR_E, ref correctionTable);

                //DoPE.ERR SSCStatre = mainform.MyEdc.Corr.SetStiffnessCorrection(ref correctionTable);
            }
            else
            {
                Console.WriteLine("未选择文件");
                return;
            }
        }


        /// <summary>
        /// 图表设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetChartAxisY frmSetChartAxisY = new FrmSetChartAxisY();
            frmSetChartAxisY.ShowDialog();
        }


        /// <summary>
        /// 计数器清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ck_TareCount_CheckedChanged(object sender, EventArgs e)
        {
            //DoPE.ERR Err = MyEdc.Data.SetTime(DoPE.SETTIME_MODE.FIRST_CYCLE, 0);

            //MyEdc.Tare.Tare(DoPE.Data..SENSOR_E, true);

            //if (!isRunning)
            //{
            //    if (cb_TareExt.Checked)
            //    {
            //        MyEdc.Tare.Tare(DoPE.SENSOR.SENSOR_E, true);
            //    }
            //    else
            //    {
            //        MyEdc.Tare.Tare(DoPE.SENSOR.SENSOR_E, false);
            //    }
            //}
        }


        /// <summary>
        /// 退出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出程序吗？", "退出确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (bConnected)
                {
                    OffEDC();
                }

                Application.Exit();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出程序吗？", "退出确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (bConnected)
                {
                    OffEDC();
                }
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true; // 取消关闭
            }
        }


        /// <summary>
        /// 曲线自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoSetYAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region postion axis auto fitting
            //位移曲线自适应
            /*
            if (Math.Abs(double.Parse(tb_MaxPos.Text)) <= 0.01 || Math.Abs(double.Parse(tb_MinPos.Text)) <= 0.01)
            {
                chart_machine.ChartAreas[0].AxisY.Maximum = 0.1;
                chart_machine.ChartAreas[0].AxisY.Minimum = -0.1;
            }
            else 
            {
                if (double.Parse(tb_MaxPos.Text) == double.Parse(tb_MinPos.Text))
                {
                    chart_machine.ChartAreas[0].AxisY.Maximum = Math.Round(double.Parse(tb_MaxPos.Text), 2) * 1.2 + 1;
                    chart_machine.ChartAreas[0].AxisY.Minimum = Math.Round(double.Parse(tb_MinPos.Text), 2) * 1.2 - 1;
                }
                else
                {
                    double range = double.Parse(tb_MaxPos.Text) - double.Parse(tb_MinPos.Text);
                    double totalHeight = range / 0.85;        // Y 轴总高度的85%
                    double padding = (totalHeight - range) / 2.0;  // 上下留白

                    double yAxisMax = double.Parse(tb_MaxPos.Text) + padding;
                    double yAxisMin = double.Parse(tb_MinPos.Text) - padding;

                    chart_machine.ChartAreas[0].AxisY.Maximum = yAxisMax;
                    chart_machine.ChartAreas[0].AxisY.Minimum = yAxisMin;
                }
    
                chart_machine.ChartAreas[0].AxisY.LabelStyle.Format = "F2";

            }
*/

            double maxSeriesMaxYValCmd = -1;
            double maxSeriesMinYValCmd = -1;
            if (chart_machine.Series[3].Points.Count > 0 )
            {
                maxSeriesMaxYValCmd = chart_machine.Series[3].Points.Max(point => point.YValues[0]);
                maxSeriesMinYValCmd = chart_machine.Series[3].Points.Min(point => point.YValues[0]);
            }

            if (chart_machine.Series[0].Points.Count > 0)
            {
                double maxSeriesMaxYVal = chart_machine.Series[0].Points.Max(point => point.YValues[0]);
                double maxSeriesMinYVal = chart_machine.Series[0].Points.Min(point => point.YValues[0]);
                if (chart_machine.Series[3].YAxisType == chart_machine.Series[0].YAxisType)
                {
                    if (maxSeriesMaxYValCmd != -1 && maxSeriesMinYValCmd != -1 && cb_DrawCommand.Checked)
                    {

                        if (maxSeriesMaxYVal < maxSeriesMaxYValCmd) maxSeriesMaxYVal = maxSeriesMaxYValCmd;
                        if (maxSeriesMinYVal > maxSeriesMinYValCmd) maxSeriesMinYVal = maxSeriesMinYValCmd;
                    }
                }

                double range1 = maxSeriesMaxYVal - maxSeriesMinYVal;
                double totalHeight1 = range1 / 0.85;        // Y 轴总高度的85%
                double padding1 = (totalHeight1 - range1) / 2.0;  // 上下留白

                double yAxisMax1 = maxSeriesMaxYVal + padding1;
                double yAxisMin1 = maxSeriesMinYVal - padding1;
                if (Math.Abs(yAxisMax1 - yAxisMin1)>=0.1)
                {
                    chart_machine.ChartAreas[0].AxisY.Maximum = Math.Round(yAxisMax1, 2);
                    chart_machine.ChartAreas[0].AxisY.Minimum = Math.Round(yAxisMin1, 2);
                }
            }
            #endregion postion axis auto fitting


            //试验力曲线自适应
            #region load auto fitting
            /*
            if (Math.Abs(double.Parse(tb_MaxLoad.Text)) <= 0.01 || Math.Abs(double.Parse(tb_MinLoad.Text)) <= 0.01)
            {
                chart_machine.ChartAreas[0].AxisY2.Maximum = 0.1;
                chart_machine.ChartAreas[0].AxisY2.Minimum = -0.1;
            }
            else
            {
                if (double.Parse(tb_MaxLoad.Text) == double.Parse(tb_MinLoad.Text))
                {
                    chart_machine.ChartAreas[0].AxisY2.Maximum = Math.Round(double.Parse(tb_MaxLoad.Text), 2) * 1.2 + 1;
                    chart_machine.ChartAreas[0].AxisY2.Minimum = Math.Round(double.Parse(tb_MinLoad.Text), 2) * 1.2 - 1;
                }
                else
                {
                    double range = double.Parse(tb_MaxLoad.Text) - double.Parse(tb_MinLoad.Text);
                    double totalHeight = range / 0.85;        // Y 轴总高度的85%
                    double padding = (totalHeight - range) / 2.0;  // 上下留白

                    double yAxisMax = double.Parse(tb_MaxLoad.Text) + padding;
                    double yAxisMin = double.Parse(tb_MinLoad.Text) - padding;

                    chart_machine.ChartAreas[0].AxisY2.Maximum = yAxisMax;
                    chart_machine.ChartAreas[0].AxisY2.Minimum = yAxisMin;
                }
                chart_machine.ChartAreas[0].AxisY2.LabelStyle.Format = "F2";
            }
            */
            if (chart_machine.Series[1].Points.Count > 0)
            {
                double maxSeriesMaxYVal = chart_machine.Series[1].Points.Max(point => point.YValues[0]);
                double maxSeriesMinYVal = chart_machine.Series[1].Points.Min(point => point.YValues[0]);

                if (chart_machine.Series[3].YAxisType == chart_machine.Series[1].YAxisType)
                {
                    if (maxSeriesMaxYValCmd != -1 && maxSeriesMinYValCmd != -1 && cb_DrawCommand.Checked)
                    {

                        if (maxSeriesMaxYVal < maxSeriesMaxYValCmd) maxSeriesMaxYVal = maxSeriesMaxYValCmd;
                        if (maxSeriesMinYVal > maxSeriesMinYValCmd) maxSeriesMinYVal = maxSeriesMinYValCmd;
                    }
                }

                double range1 = maxSeriesMaxYVal - maxSeriesMinYVal;
                double totalHeight1 = range1 / 0.85;        // Y 轴总高度的85%
                double padding1 = (totalHeight1 - range1) / 2.0;  // 上下留白

                double yAxisMax1 = maxSeriesMaxYVal + padding1;
                double yAxisMin1 = maxSeriesMinYVal - padding1;
                if (Math.Abs(yAxisMax1 - yAxisMin1) >= 0.1)
                {
                    chart_machine.ChartAreas[0].AxisY2.Maximum = Math.Round(yAxisMax1, 2);
                    chart_machine.ChartAreas[0].AxisY2.Minimum = Math.Round(yAxisMin1, 2);
                }

            }
            #endregion load auto fitting

        }

        private void cb_TareTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_TareTime.Checked)
            {
                nCurrentCount = int.Parse(tbX_TestCycles.Text);
                tbX_TestCycles.Text = "0";
                tbX_TestCount.Text = "0";
                nCurrentCount = 0;
                IniFileHelper.WriteIniString("Setting", "TestCount", "0");

                cb_TareTime.Checked = false;
            }

        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            if (bConnected)
            {
                if (this.tbX_Dyn_StartSpeed.Text == "" || this.textBoxX14.Text == "" || this.textBoxX15.Text == "")
                {
                    MessageBox.Show("输入不能为空，请重新输入！");
                    return;
                }
                double tmpDobleNum;

                if (!double.TryParse(this.tbX_Dyn_StartSpeed.Text, out tmpDobleNum) || !double.TryParse(this.textBoxX14.Text, out tmpDobleNum) || !double.TryParse(this.textBoxX15.Text, out tmpDobleNum))
                {
                    MessageBox.Show("请输入数字！");
                    return;
                }

                FrmPosExt frmPosExt = new FrmPosExt();
                frmPosExt.send_FrmPosExts_command((DoPE.CTRL)cmbX_Dyn_StartCtrl.SelectedIndex,double.Parse(tbX_Dyn_StartSpeed.Text),(LIMITMODE)comboBoxEx7.SelectedIndex,double.Parse(textBoxX14.Text),
                                                 (CTRL)comboBoxEx9.SelectedIndex,double.Parse(textBoxX15.Text),(DESTMODE)comboBoxEx11.SelectedIndex);
            }
            else
            {
                MessageBox.Show("请先激活控制器!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void superTabControl4_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
           // Console.WriteLine("glm{0}", superTabControl4.SelectedTabIndex);
            //if (superTabControl4.SelectedTabIndex == 1)
            {
                if (cmbX_Dyn_EDC.Items.Count >= 1)
                {
                    cmbX_Dyn_EDC.SelectedIndex = 0;
                }

                cmbX_Dyn_StartCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

                comboBoxEx7.DataSource = System.Enum.GetNames(typeof(DoPE.LIMITMODE));

                comboBoxEx9.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

                comboBoxEx11.DataSource = System.Enum.GetNames(typeof(DoPE.DESTMODE));
            }
        }

        public void after_Controller_Online()
        {
            if (superTabControl4.SelectedTabIndex == 1)
            {
                if (cmbX_Dyn_EDC.Items.Count >= 1)
                {
                    cmbX_Dyn_EDC.SelectedIndex = 0;
                }

                cmbX_Dyn_StartCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

                comboBoxEx7.DataSource = System.Enum.GetNames(typeof(DoPE.LIMITMODE));

                comboBoxEx9.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

                comboBoxEx11.DataSource = System.Enum.GetNames(typeof(DoPE.DESTMODE));
            }
        }

        private void cmbX_Dyn_StartCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbX_Dyn_StartCtrl.SelectedValue.ToString())
            {
                case "POS":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "mm/s" };
                        comboBoxEx8.DataSource = new string[] { "mm/s" };
                        break;
                    }
                case "LOAD":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "N/s" };
                        comboBoxEx8.DataSource = new string[] { "N/s" };
                        break;
                    }
                case "EXTENSION":
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "mm/s" };
                        comboBoxEx8.DataSource = new string[] { "mm/s" };
                        break;
                    }
                default:
                    {
                        cmbX_Dyn_StartSpeed_Unit.DataSource = new string[] { "Unit/s" };
                        comboBoxEx8.DataSource = new string[] { "Unit/s" };
                        break;
                    }

            }
        }

        private void comboBoxEx9_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEx9.SelectedValue.ToString())
            {
                case "POS":
                    {
                        comboBoxEx10.DataSource = new string[] { "mm/s" };
                        break;
                    }
                case "LOAD":
                    {
                        comboBoxEx10.DataSource = new string[] { "N/s" };
                        break;
                    }
                case "EXTENSION":
                    {
                        comboBoxEx10.DataSource = new string[] { "mm/s" };
                        break;
                    }
                default:
                    {
                        comboBoxEx10.DataSource = new string[] { "Unit/s" };
                        break;
                    }

            }
        }

        private void posExtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (bConnected)
            {
                FrmPosExt frmPosExt = new FrmPosExt();
                frmPosExt.Show();
            }
            else
            {
                MessageBox.Show("请先激活控制器!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void pl_DataShow_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                floatMenus.Visible = true;
            }
        }
    }
}
