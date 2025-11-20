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

//glm-dynorigin
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
using TeeChart;
using DoPENetConnect.Util;

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
        /// 接收的数据块
        /// </summary>
        public DoPE.OnDataBlock gBlock;

        /// <summary>
        /// 接收的数据点
        /// </summary>
        public DoPE.Data gSample;

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
        /// 登录用户名和密码
        /// </summary>
        public string strLoginName = "";
        public string strUserPwd = "";


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
        /// 按次数延迟显示实时数据
        /// </summary>
        private double nCountREfresh = 20;

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
        double x_Data = 0.0;
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
        /// 联机后显示传感器数据，达到试验次数或停机后 为 false
        /// </summary>
        bool bShowSensorData = true;


        /// <summary>
        /// 记录位移峰谷值的队列
        /// </summary>
        public Queue<double> PVPositionQueue = new Queue<double>(2000);

        /// <summary>
        /// 判断位移峰谷值的列表
        /// </summary>
        public List<double> PVPositionList = new List<double>();

        /// <summary>
        /// 位移峰值平均值列表
        /// </summary>
        public List<double> PVPositionMaxAverageList = new List<double>();

        /// <summary>
        /// 位移谷值平均值列表
        /// </summary>
        public List<double> PVPositionMinAverageList = new List<double>();

        /// <summary>
        /// 记录试验力峰谷值的队列
        /// </summary>
        public Queue<double> PVLoadQueue = new Queue<double>(1000);

        /// <summary>
        /// 判断试验力峰谷值的列表
        /// </summary>
        public List<double> PVLoadList = new List<double>();

        /// <summary>
        /// 试验力峰值平均值列表
        /// </summary>
        public List<double> PVLoadMaxAverageList = new List<double>();

        /// <summary>
        /// 试验力谷值平均值列表
        /// </summary>
        public List<double> PVLoadMinAverageList = new List<double>();

        /// <summary>
        /// 记录变形峰谷值的队列
        /// </summary>
        public Queue<double> PVExtensionQueue = new Queue<double>(1000);

        /// <summary>
        /// 判断变形峰谷值的列表
        /// </summary>
        public List<double> PVExtensionList = new List<double>();

        /// <summary>
        /// 变形峰值平均值列表
        /// </summary>
        public List<double> PVExtensionMaxAverageList = new List<double>();

        /// <summary>
        /// 变形谷值平均值列表
        /// </summary>
        public List<double> PVExtensionMinAverageList = new List<double>();

        /// <summary>
        /// 是否按试验次数记录日志
        /// </summary>
        public bool bSaveCountLog = false;

        /// <summary>
        /// 日志试验记录次数
        /// </summary>
        public int nCountLog = 500;

        /// <summary>
        /// 是否按试验次数记录峰谷值日志
        /// </summary>
        public bool bSavePVCountLog = false;

        /// <summary>
        /// 记录峰谷值日志试验间隔次数
        /// </summary>
        public int nPVCountLog = 500;

        /// <summary>
        /// 存过试验停止时屏幕数据
        /// </summary>
        public bool bSaveStopScreenLog = false;

        /// <summary>
        /// 存储试验过程的数据
        /// </summary>
        public bool bSaveRunningLog = false;

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
        public StringBuilder strBlockLog = new StringBuilder();

        /// <summary>
        /// 记录上一次记录峰谷值的半循环序号
        /// </summary>
        public int LastRecordedHalfCycle = -1;

        /// <summary>
        /// 记录上一次日志的半循环序号
        /// </summary>
        public int LastRecordedCountHalfCycle = -1;

        /// <summary>
        /// 设备id
        /// </summary>
        public StringBuilder devId;

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
        public double Chart_X_Step = 5.0;

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
        /// 上一次运行次数
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
        /// 
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
		
        /// <summary>
        /// 多传感器窗口
        /// </summary>
        public FrmMultiSensor frmMultiSensor = null;

        /// <summary>
        /// 试验力单位
        /// </summary>
        public string LoadUnit = "N";

        public double g_Position = 0.0d;

        public double g_MaxPosition = 0.0d;

        public double g_MinPosition = 0.0d;

        public double g_Load = 0.0d;

        public double g_MaxLoad = 0.0d;

        public double g_MinLoad = 0.0d;

        public double g_Command = 0.0d;

        public double g_Extension = 0.0d;

        public double g_MaxExtension = 0.0d;

        public double g_MinExtension = 0.0d;

        /// <summary>
        /// 周期
        /// </summary>
        public long g_Count = 0;

        /// <summary>
        /// 采样频率
        /// </summary>
        public double SampleFrequency = 1;

        /// <summary>
        /// 数据刷新频率
        /// </summary>
        public double DataRefreshFrequency = 200;

        /// <summary>
        /// 波形显示频率
        /// </summary>
        public double WaveRefreshFrequency = 200;

        /// <summary>
        /// 位移小数显示位数
        /// </summary>
        public decimal PosDigit = 3;

        /// <summary>
        /// 试验力小数显示位数
        /// </summary>
        public decimal LoadDigit = 3;

        /// <summary>
        /// 变形小数显示位数
        /// </summary>
        public decimal ExtDigit = 3;

        /// <summary>
        /// X轴列表
        /// </summary>
        public List<double> chartX = new List<double>();

        /// <summary>
        /// 位移Y轴列表
        /// </summary>
        public List<double> chartPosY = new List<double>();

        /// <summary>
        ///试验力移Y轴列表
        /// </summary>
        public List<double> chartLoadY = new List<double>();

        /// <summary>
        /// 命令Y轴列表
        /// </summary>
        public List<double> chartCommandY = new List<double>();

        /// <summary>
        /// 变形Y轴列表
        /// </summary>
        public List<double> chartExtY = new List<double>();

        public double PositionYMax = 0.0;

        /// <summary>
        /// 启用高压
        /// </summary>
        public string EnableHigh = "0";

        /// <summary>
        /// 启用低压
        /// </summary>
        public string EnableLow = "0";

        /// <summary>
        /// 显示位移曲线
        /// </summary>
        public static bool bShowPosition = true;

        /// <summary>
        /// 显示力曲线
        /// </summary>
        public static bool bShowLoad = true;

        /// <summary>
        /// 显示变形曲线
        /// </summary>
        public static bool bShowExtension = true;

        /// <summary>
        /// 显示命令曲线
        /// </summary>
        public static bool bShowCommand = true;


        public AxTeeChart.AxTChart m_AxTeechart
        {
            get { return this.axTChart1; }

        }


        public delegate void UpdateDataToTextBox(string str);

        public event UpdateDataToTextBox updateTextBox;

        public int systemCounter = 0;

        public bool isProcessing = false;

        public int themeComboIndex = 0;

        /// <summary>
        /// 退出程序
        /// </summary>
        public bool bQuit = false;
        /// <summary>
        /// 程序控制
        /// </summary>
        FormProgControl progControl=null;

        //System.Timers.Timer timer;

        //public delegate void SetControlValue(string value);


        ///// <summary>
        ///// 初始化Timer控件
        ///// </summary>
        //private void InitTimer()
        //{
        //    //设置定时间隔(毫秒为单位)
        //    int interval = 1000;
        //    timer = new System.Timers.Timer(interval);
        //    //设置执行一次（false）还是一直执行(true)
        //    timer.AutoReset = true;
        //    //设置是否执行System.Timers.Timer.Elapsed事件
        //    timer.Enabled = true;
        //    //绑定Elapsed事件
        //    timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);

        //    timer.Start();
        //}


        ///// <summary>
        ///// Timer类执行定时到点事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TimerUp(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    try
        //    {
        //        systemCounter += 1;
        //        this.Invoke(new SetControlValue(SetTextBoxText), systemCounter.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("定时事件失败:" + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// 更新文本框的值
        ///// </summary>
        ///// <param name="strValue"></param>
        //private void SetTextBoxText(string strValue)
        //{
        //    this.toolStripStatusLabel_SystemTime.Text = strValue;
        //}


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

            //updateTextBox += new UpdateDataToTextBox(UpdateData);

            //悬浮工具框
            floatMenus = new FormFloat();
            floatMenus.Owner = this;
            floatMenus.Location = new Point(this.Location.X+2, 273);
            //InitTimer();

        }

        public void UpdateData(string str)
        {
            if (!this.guiPosition.InvokeRequired)
            {
                guiPosition.Text = str;
            }
            else
            {
                this.guiPosition.Invoke(new UpdateDataToTextBox(UpdateData), str);
            }

        }

        ///----------------------------------------------------------------------
        /// <summary>FormShown initialzes    GUI and starts communication with EDC</summary>
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

            try
            {
                DoPE.ERR error;
                //DoPE.IgnoreTcpIpNIC(true);
                // open the first EDC found on this PC
                //打开edc列表
                //MyEdcList = new EdcList(32);
                //MyEdc = MyEdcList[0];
                //MyEdc = new Edc(DoPE.OpenBy.DeviceId, 0);02137E43 
                if (devId != null)
                {
                    MyEdc = new Edc(DoPE.OpenBy.DeviceId, int.Parse(devId.ToString(), System.Globalization.NumberStyles.HexNumber));
                }
                else
                {
                    return;
                }

                //MyEdc = new Edc(DoPE.OpenBy.FunctionId, 0);
                if (MyEdc != null)
                {
                    Display("连接成功，Name:" + MyEdc.ModuleInfo.Name + "; DeviceId = " + MyEdc.ModuleInfo.DeviceID + "; FunctionId = " + MyEdc.ModuleInfo.DeviceID + "; SerNr = " + MyEdc.ModuleInfo.SerNr + "\n");

                    LogHelper.WriteLogFile("连接成功");

                    lbX_EDCName.Text = MyEdc.ModuleInfo.Name;

                    toolStripStatusLabel4.Text = this.devId.ToString();

                    bShowSensorData = true;
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
                //SampleFrequency = 0.2;
                MyEdc.Eh.SetOnDataBlockSize((Int32)((SampleFrequency / 1000)/ Machine.MDef.SystemTime + Machine.MDef.SystemTime / 2));
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

                LogHelper.Debug(Text);

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
                //StartCommunicationWithEdcTimer.Start();
                DisplayError(error, "On");

                if (MyEdc.IsConnected() /*&& bActivated*/)
                {
                    //GetXaxisScale();
                    timer_UpdateData.Start();
                    bActivated = true;
                    bShowSensorData = true;

                    //bntX_GUIOn.Checked = true;
                   // btnX_SetLow.Checked = true;
                    //btnX_SetHigh.Checked = false;

                    this.MaximizeBox = false;
                    //timer_ShowWave.Start();
                }

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
                //关闭使能
                DoPE.ERR error = MyEdc.Move.Off();

                bActivated = false;
                bShowSensorData = false;

                //StartCommunicationWithEdcTimer.Stop();
                DisplayError(error, "Off");
                isRunning = false;
                //btnX_SetLow.Checked = false;
                //btnX_SetHigh.Checked = false;

                SetControlEnable(true);

                //bntX_GUIOn.Checked = false;
                floatMenus.btnX_GUIOn_Checked(false);   //请与上边一行同步修改

                this.MaximizeBox = true;

                nCycleCount = 0;

                timer_UpdateData.Stop();

                //timer_ShowWave.Stop();

                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                }

                tbX_TestCount.Text = tbX_TestCycles.Text;

                IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCycles.Text);

                tbX_TestCount.Enabled = true;

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
                //btn_ConState.BackColor = Color.Red;
                //btn_ConState.Text = "OFFLINE";

                floatMenus.btn_ConState_color(Color.Red);
                floatMenus.btn_ConState_Text("OFFLINE");

            }
            else if (LineState == DoPE.LineState.ONLINE)
            {
                //btn_ConState.BackColor = Color.Lime;
                //btn_ConState.Text = "ONLINE";
                floatMenus.btn_ConState_color(Color.Lime);
                floatMenus.btn_ConState_Text("ONLINE");
            }
            else if (LineState == DoPE.LineState.RESTART)
            {
                //btn_ConState.BackColor = Color.Yellow;
                //btn_ConState.Text = "RESTART";
                floatMenus.btn_ConState_color(Color.Yellow);
                floatMenus.btn_ConState_Text("RESTART");
            }

            return 0;
        }

        private int OnDataBlock(ref DoPE.OnDataBlock Block, object Parameter)
        {
            //CSV日志
            string strCSVLog = "";

            //峰谷值日志
            string strPVLog = "";
            if (Block.Data.Length > 0)
            {
                nCount++;
                // refesh edit controls with the latest sample
                gSample = Block.Data[Block.Data.Length - 1].Data;
                string text;

                text = String.Format("{0}", gSample.Time.ToString("0.000"));

                //记录位移
                strCSVLog += text + ",";
                text = String.Format("{0}", gSample.Sensor[(int)DoPE.SENSOR.SENSOR_S].ToString("0.000"));
                g_Position = gSample.Sensor[(int)DoPE.SENSOR.SENSOR_S];

                if (bConnected)
                {
                    //TODO
                    //位移队列
                    PVPositionQueue.Enqueue(gSample.Sensor[(int)DoPE.SENSOR.SENSOR_S]);
                    if (PVPositionQueue.Count >= 200)
                    {
                        PVPositionList = PVPositionQueue.Distinct().ToList();

                        for (int i = 0; i <= PVPositionList.Count; i++)
                        {
                            // 判断是否为峰值： //PVPositionQueue.Count
                            if (i < 3 || i > PVPositionList.Count - 2)
                            {
                                continue;
                            }

                            if (PVPositionList[i - 1] < PVPositionList[i] && PVPositionList[i] > PVPositionList[i + 1])
                            {
                                PVPositionMaxAverageList.Add(PVPositionList[i]);
                                if (PVPositionMaxAverageList.Count > 0)
                                {
                                    //if (PVPositionList[i] > PVPositionMaxAverageList.Average())
                                    {
                                        //g_MaxPosition = PVPositionList[i];
                                        g_MaxPosition = PVPositionMaxAverageList.Max();
                                    }
                                }

                                //g_MaxPosition = PVPositionList[i];
                            }

                            // 判断是否为谷值：小于左右相邻的数据
                            if (PVPositionList[i - 1] > PVPositionList[i] && PVPositionList[i] < PVPositionList[i + 1])
                            {
                                PVPositionMinAverageList.Add(PVPositionList[i]);
                                if (PVPositionMinAverageList.Count > 0)
                                {
                                    //if (PVPositionList[i] < PVPositionMinAverageList.Average())
                                    {
                                        g_MinPosition = PVPositionList[i];
                                        g_MinPosition = PVPositionMinAverageList.Min();
                                    }
                                }

                                //g_MinPosition = PVPositionList[i];
                            }
                        }

                        //g_MaxPosition = PVPositionQueue.Max();
                        //g_MinPosition = PVPositionQueue.Min();

                        if (bActivated && isRunning)
                        {
                            #region 判断位移峰谷值
                            //判断是否处于正常峰值区间
                            if (protectOption.ProtectOption_PosMaxOut_Effect)
                            {
                                if (g_MaxPosition > protectOption.ProtectOption_PosMaxOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("位移峰值触发外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            if (protectOption.ProtectOption_PosMaxIn_Effect)
                            {
                                if (g_MaxPosition < protectOption.ProtectOption_PosMaxIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("位移峰值触发内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于正常谷值区间
                            if (protectOption.ProtectOption_PosMinOut_Effect)
                            {
                                if (g_MinPosition < protectOption.ProtectOption_PosMinOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("位移谷值触发外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            if (protectOption.ProtectOption_PosMinIn_Effect)
                            {
                                if (g_MinPosition > protectOption.ProtectOption_PosMinIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("位移谷值触发内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }
                            #endregion 判断位移峰谷值
                        }

                        while (PVPositionQueue.Count > 200)
                        {
                            //PVPositionQueue.Dequeue();
                            PVPositionQueue.Clear();
                        }

                        while (PVPositionMinAverageList.Count > 200)
                        {
                            PVPositionMinAverageList.RemoveRange(0, PVPositionMinAverageList.Count / 2);
                        }

                        while (PVPositionMaxAverageList.Count > 200)
                        {
                            PVPositionMaxAverageList.RemoveRange(0, PVPositionMaxAverageList.Count / 2);
                        }
                    }

                    // TODO:判断峰谷值是否超过外保护
                    double dPosition = 0;

                    //刷新位移
                    if (nCount >= nCountREfresh /*&& bActivated*/ )
                    {
                        //if (this.IsHandleCreated)
                        //{
                            //this.BeginInvoke(new Action(() =>
                            {
         
                            guiPosition.Text = g_Position.ToString($"F{PosDigit}");

                            if (bShowSensorData)
                            {
                                tb_MaxPos.Text = g_MaxPosition.ToString($"F{PosDigit}");
                                tb_MinPos.Text = g_MinPosition.ToString($"F{PosDigit}");
                                Invalidate(tb_MaxPos.Bounds);
                                Invalidate(tb_MinPos.Bounds);
                            }
                            Invalidate(guiPosition.Bounds);

                        }
                        //));
                        //}
                        //Invalidate();
                    }

                    //记录试验力
                    strCSVLog += text + ",";
                    text = String.Format("{0}", gSample.Sensor[(int)DoPE.SENSOR.SENSOR_F].ToString("0.000"));
                    g_Load = gSample.Sensor[(int)DoPE.SENSOR.SENSOR_F];

                    //试验力队列
                    PVLoadQueue.Enqueue(gSample.Sensor[(int)DoPE.SENSOR.SENSOR_F]);
                    if (PVLoadQueue.Count >= 400 )
                    {
                        PVLoadList = PVLoadQueue.Distinct().ToList();

                        for (int i = 0; i < PVLoadList.Count; i++)
                        {
                            if (i < 3 || i > PVLoadList.Count - 2)
                            {
                                continue;
                            }

                            // 判断是否为峰值：大于左右相邻的数据
                            if (PVLoadList[i - 1] < PVLoadList[i] && PVLoadList[i] > PVLoadList[i + 1])
                            {
                                if (LoadUnit.ToUpper() == "KN")
                                {
                                    PVLoadMaxAverageList.Add(PVLoadList[i]);

                                    if (PVLoadMaxAverageList.Count > 0)
                                    {
                                        g_MaxLoad = PVLoadMaxAverageList.Max() / 1000;
                                    }
                                }
                                else
                                {
                                    PVLoadMaxAverageList.Add(PVLoadList[i]);

                                    if (PVLoadMaxAverageList.Count > 0)
                                    {
                                        g_MaxLoad = PVLoadMaxAverageList.Max();
                                    }
                                }
                            }

                            // 判断是否为谷值：小于左右相邻的数据
                            if (PVLoadList[i - 1] > PVLoadList[i] && PVLoadList[i] < PVLoadList[i + 1])
                            {
                                if (LoadUnit.ToUpper() == "KN")
                                {
                                    PVLoadMinAverageList.Add(PVLoadList[i]);

                                    if (PVLoadMinAverageList.Count > 0)
                                    {
                                        g_MinLoad = PVLoadMinAverageList.Min() / 1000;
                                    }
                                }
                                else
                                {
                                    PVLoadMinAverageList.Add(PVLoadList[i]);

                                    if (PVLoadMinAverageList.Count > 0)
                                    {
                                        g_MinLoad = PVLoadMinAverageList.Min();
                                    }
                                }
                            }
                        }

                        if (bActivated && isRunning)
                        {
                            #region 判断试验力峰谷值
                            //判断是否处于合理的试验力峰值区间 峰值外保护
                            if (protectOption.ProtectOption_LoadMaxOut_Effect)
                            {
                                double ProtectOption_LoadMaxOutReal = LoadUnit.ToUpper() == "KN" ? protectOption.ProtectOption_LoadMaxOut * 1000 : protectOption.ProtectOption_LoadMaxOut;
                                if (g_MaxLoad > ProtectOption_LoadMaxOutReal)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("试验力峰值触发外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的试验力峰值区间 峰值内保护
                            if (protectOption.ProtectOption_LoadMaxIn_Effect)
                            {
                                if (g_MaxLoad < protectOption.ProtectOption_LoadMaxIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("试验力峰值触发内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的试验力谷值区间 谷值外保护
                            if (protectOption.ProtectOption_LoadMinOut_Effect)
                            {
                                double ProtectOption_LoadMinOutReal = LoadUnit.ToUpper() == "KN" ? protectOption.ProtectOption_LoadMinOut * 1000 : protectOption.ProtectOption_LoadMinOut;
                                if (g_MinLoad < ProtectOption_LoadMinOutReal)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("试验力谷值触发外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的试验力谷值区间 谷值内保护
                            if (protectOption.ProtectOption_LoadMinIn_Effect)
                            {
                                if (g_MinLoad > protectOption.ProtectOption_LoadMinIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("试验力谷值触发内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }
                            #endregion 判断试验力峰谷值
                        }

                        while (PVLoadQueue.Count > 200)
                        {
                            PVLoadQueue.Dequeue();
                            //PVLoadQueue.Clear();
                        }

                        while (PVLoadMaxAverageList.Count > 200)
                        {
                            PVLoadMaxAverageList.RemoveRange(0, PVLoadMaxAverageList.Count / 2);
                        }

                        while (PVLoadMinAverageList.Count > 200)
                        {
                            PVLoadMinAverageList.RemoveRange(0, PVLoadMinAverageList.Count / 2);
                        }

                    }

                    //刷新试验力
                    if (nCount >= nCountREfresh /*&& bActivated*/ )
                    {
                        //if (this.IsHandleCreated)
                        {
                            //this.BeginInvoke(new Action(() =>
                            //{

                            if (LoadUnit.ToUpper() == "KN")
                            {
                                guiLoad.Text = (g_Load / 1e3).ToString($"F{LoadDigit}");
                            }
                            else
                            {
                                guiLoad.Text = g_Load.ToString($"F{LoadDigit}");
                            }

                            if (bShowSensorData)
                            {
                                tb_MaxLoad.Text = g_MaxLoad.ToString($"F{LoadDigit}");
                                tb_MinLoad.Text = g_MinLoad.ToString($"F{LoadDigit}");

                                Invalidate(tb_MaxLoad.Bounds);
                                Invalidate(tb_MinLoad.Bounds);
                            }
                            Invalidate(guiLoad.Bounds);

                            //}
                            //));
                        }
                    }

                    //记录变形
                    strCSVLog += text + ",";
                    //data_display2 = decimal.Parse(guiLoad.Text);
                    text = String.Format("{0}", gSample.Sensor[(int)DoPE.SENSOR.SENSOR_E].ToString("0.000"));
                    g_Extension = gSample.Sensor[(int)DoPE.SENSOR.SENSOR_E];

                    //变形队列
                    PVExtensionQueue.Enqueue(gSample.Sensor[(int)DoPE.SENSOR.SENSOR_E]);
                    if (PVExtensionQueue.Count >= 200)
                    {
                        PVExtensionList = PVExtensionQueue.Distinct().ToList();
                        for (int i = 0; i <= PVExtensionList.Count; i++)
                        {
                            // 判断是否为峰值： //PVPositionQueue.Count
                            if (i < 3 || i > PVExtensionList.Count - 2)
                            {
                                continue;
                            }

                            if (PVExtensionList[i - 1] < PVExtensionList[i] && PVExtensionList[i] > PVExtensionList[i + 1] &&
                                (PVExtensionList[i - 1] + PVExtensionList[i + 1]) / 2 < PVExtensionList[i])
                            {
                                PVExtensionMaxAverageList.Add(PVExtensionList[i]);
                                double averageExtension = 0.0d;
                                if (PVExtensionMaxAverageList.Count > 0)
                                {
                                    averageExtension = PVExtensionMaxAverageList.Average();
                                }

                                if (PVExtensionList[i] >= averageExtension)
                                {
                                    g_MaxExtension = PVExtensionList[i];
                                }
                            }

                            // 判断是否为谷值：小于左右相邻的数据
                            if (PVExtensionList[i - 1] > PVExtensionList[i] && PVExtensionList[i] < PVExtensionList[i + 1] &&
                                (PVExtensionList[i - 1] + PVExtensionList[i + 1]) / 2 > PVExtensionList[i])
                            {
                                PVExtensionMinAverageList.Add(PVExtensionList[i]);
                                double averageExtension = 0.0d;
                                if (PVExtensionMinAverageList.Count > 0)
                                {
                                    averageExtension = PVExtensionMinAverageList.Average();
                                }

                                if (PVExtensionList[i] <= averageExtension)
                                {
                                    g_MinExtension = PVExtensionList[i];
                                }
                            }
                        }

                        if (bActivated && isRunning)
                        {
                            #region 判断变形峰谷值
                            //判断是否处于合理的变形峰值区间 峰值外保护
                            if (protectOption.ProtectOption_ExtMaxOut_Effect)
                            {
                                if (g_MaxExtension > protectOption.ProtectOption_ExtMaxOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("变形峰值触发外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的变形峰值区间 峰值内保护
                            if (protectOption.ProtectOption_ExtMaxIn_Effect)
                            {
                                if (g_MaxExtension < protectOption.ProtectOption_ExtMaxIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("变形峰值触发内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的变形谷值区间 谷值外保护
                            if (protectOption.ProtectOption_ExtMinOut_Effect)
                            {
                                if (g_MinExtension < protectOption.ProtectOption_ExtMinOut)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("变形谷值触发外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }

                            //判断是否处于合理的变形谷值区间 谷值内保护
                            if (protectOption.ProtectOption_ExtMinIn_Effect)
                            {
                                if (g_MinExtension > protectOption.ProtectOption_ExtMinIn)
                                {
                                    if (protectOption.ProtectOptionType == "0")
                                    {
                                        MoveHalt();
                                    }
                                    else
                                    {
                                        OffEDC();
                                    }
                                    PauseDrawWave();
                                    MessageBox.Show("变形谷值触发内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return 0;
                                }
                            }
                            #endregion 判断变形峰谷值
                        }

                        while (PVExtensionQueue.Count > 200)
                        {
                            PVExtensionQueue.Dequeue();
                        }

                        if (PVExtensionMaxAverageList.Count > 200)
                        {
                            PVExtensionMaxAverageList.RemoveRange(0, PVExtensionMaxAverageList.Count / 2);
                        }

                        if (PVExtensionMinAverageList.Count > 200)
                        {
                            PVExtensionMinAverageList.RemoveRange(0, PVExtensionMinAverageList.Count / 2);
                        }
                    }

                    //刷新变形
                    if (nCount >= nCountREfresh /*&& bActivated*/ )
                    {
                        guiExtension.Text = g_Extension.ToString($"F{ExtDigit}");
                        Invalidate(guiExtension.Bounds);

                        if (bShowSensorData)
                        {
                            tb_MaxExt.Text = g_MaxExtension.ToString($"F{ExtDigit}");
                            tb_MinExt.Text = g_MinExtension.ToString($"F{ExtDigit}");

                            Invalidate(tb_MaxExt.Bounds);
                            Invalidate(tb_MinExt.Bounds);
                        }

                        Update();
                    }

                    //记录命令
                    strCSVLog += text + ",";
                    text = String.Format("{0}", gSample.Sensor[(int)DoPE.OUT.COMMAND].ToString("0.000"));

                    //记录半周期
                    strCSVLog += text + ",";
                    text = (gSample.Cycles /*<< 1*/).ToString();

                    //记录输出
                    strCSVLog += text + ",";
                    text = String.Format("{0}", gSample.Output.ToString("0.000"));

                    //记录反馈
                    strCSVLog += text + ",";
                    text = String.Format("{0}", gSample.Feedback.ToString("0.000"));

                    //记录周期
                    strCSVLog += text + ",";
                    strCSVLog += (gSample.Cycles >> 1).ToString();

                    //var xval = axTChart1.Series(0).XValues;
                    //var yval = axTChart1.Series(0).YValues;
                    //double fdsfsdf = yval.Maximum;

                    if (isRunning)
                    {
                        //保存当前屏幕日志
                        if (bSavePVCountLog)
                        {
                            if ((gSample.Cycles >> 1) > 0 && (gSample.Cycles >> 1) % nCountLog == 0 && !isProcessing)
                            {
                                int currentHalfCyclez = gSample.Cycles >> 1;

                                if (currentHalfCyclez != LastRecordedCountHalfCycle)
                                {
                                    var task1 = Task.Run(() => GetSeriesPoint());
                                    LastRecordedCountHalfCycle = currentHalfCyclez;
                                }
                            }
                        }

                        strBlockLog.Append(strCSVLog + "\r\n");

                        //按配置的次数存储日志
                        //TODO 修改成 达到nCountLog 次数时只存储当前屏幕数据
                        if ((gSample.Cycles /*>> 1*/) % nCountLog == 0)
                        {
                            if (bSaveRunningLog)
                            {
                                LogHelper.SaveCsvData(strBlockLog.ToString());
                            }

                            strBlockLog.Clear();
                        }

                        int currentHalfCycle = gSample.Cycles >> 1;

                        //按配置的次数存储峰谷值日志
                        if (bSavePVCountLog)
                        {
                            int halfCyclesCompleted = gSample.Cycles >> 1; // 计算已完成的半周期数
                            int currentLogInterval = 1; // 默认存储间隔

                            // --- 根据已完成的半周期数确定存储间隔 ---
                            if (halfCyclesCompleted < 10)
                            {
                                currentLogInterval = 1; // 小于10次，每次都存
                            }
                            else if (halfCyclesCompleted < 100)
                            {
                                currentLogInterval = 10; // 10到99次，每10次存一次
                            }
                            else if (halfCyclesCompleted < 1000)
                            {
                                currentLogInterval = 100; // 100到999次，每100次存一次
                            }
                            else
                            {
                                currentLogInterval = 1000; // 1000次及以上，每1000次存一次
                            }

                            if (halfCyclesCompleted % currentLogInterval == 0)
                            {
                                //防止同一秒记录多次
                                if (currentHalfCycle != LastRecordedHalfCycle)
                                {
                                    strPVLog = g_MaxPosition.ToString("F6") + "," + g_MinPosition.ToString("F6") + "," + g_MaxLoad.ToString("F6") + "," + g_MinLoad.ToString("F6") + "," + g_MaxExtension.ToString("F6") + "," + g_MinExtension.ToString("F6") + "," + (gSample.Cycles >> 1);
                                    LogHelper.SavePeakValleyData(strPVLog);
                                    LastRecordedHalfCycle = currentHalfCycle;
                                }
                            }
                        }
                    }

                    if (!isRunning)
                    {
                        if ((gSample.Cycles >> 1) > 0 && nTotalTestCount == 0)
                        {
                            tbX_TestCycles.Text = nPreTestCount.ToString();
                        }
                    }
                    else
                    {
                        if (cb_TareTime.Checked)
                        {
                            nTotalTestCount = (gSample.Cycles >> 1) - nCurrentCount;
                            tbX_TestCycles.Text = nTotalTestCount.ToString();
                        }
                        else
                        {
                            nTotalTestCount = (gSample.Cycles >> 1) + nPreTestCount;
                            tbX_TestCycles.Text = nTotalTestCount.ToString();
                            //g_Count = nTotalTestCount;
                        }
                    }

                    //试验次数达到指定的试验次数
                    if (isRunning) 
                    {
                        nCycleCount++;

                        if (nCycleCount > 20 && gSample.Cycles /*>> 1*/ >= nTestCount)
                        {
                            isRunning = false;
                            bShowSensorData = false;
                            SetControlEnable(true);
                            timer_UpdateData.Stop();

                            tbX_TestCount.Text = tbX_TestCycles.Text;
                            if (bSaveStopScreenLog)
                            {
                                //存储实验停止后的日志
                                var task1 = Task.Run(() => GetSeriesPoint());
                            }

                            //最后一次的试验次数写入配置文件
                            IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCycles.Text);

                            nCycleCount = 0;

                            //清除上次计数
                            DoPE.ERR error = MyEdc.Move.Halt(DoPE.CTRL.POS, ref MyTan);
                        }
                    }
                }

                //波形图
                if (bShowSensorData/* && bActivated*/ && !bQuit)
                {
                    //Task.Run(() =>
                    //{
                    // 数据处理逻辑放在这里...
                    ShowWave(Block);

                    //});
                }

                if (nCount >= nCountREfresh)
                {
                    nCount = 0;
                }

            }

            return 0;
        }


        /// <summary>
        /// 获取序列上所有的点
        /// </summary>
        public void GetSeriesPoint()
        {
            try
            {
                //位移
                ISeries PosSeries = axTChart1.Series(0);

                //试验力
                ISeries LoadSeries = axTChart1.Series(1);

                //变形
                ISeries ExtensionSeries = axTChart1.Series(2);

                //命令
                ISeries CommandSeries = axTChart1.Series(3);

                //int count = Math.Min(Math.Min(PosSeries.Count, LoadSeries.Count),
                //         Math.Min(ExtensionSeries.Count, CommandSeries.Count));

                LogHelper.SaveCountCsvData(PosSeries, LoadSeries, ExtensionSeries, CommandSeries, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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

            floatMenus.SetStateText(RuntimeError.ErrorNumber.ToString());

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

            floatMenus.SetStateText(SystemMsg.MsgNumber.ToString());

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


        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadIni();

            //程控相关
            RemoveDataGridView();
            RefreshDbNameList();

            //LoadLanguage();

            //ReplaceLanguage();

            //计算每秒步长
            dStep = SampleFrequency / 1000;

            //采样频率
            //SampleFrequency = SampleFrequency / 1000;

            //总步长
            nTotal = AxisXMax / dStep;

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            timer_UpdateData.Interval = (int)DataRefreshFrequency;

            //btn_ConState.BackColor = Color.Red;

            //初始化chart控件
            //x_Position = 0.0;

            SetMemberParam();

            //试验力
            //x_Load = 0.0;


            axTChart1.Axis.Bottom.Minimum = 0;

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            //if (EnableHigh == "0")
            //{
            //    btnX_SetHigh.Visible = false;
            //}
            //else
            //{
                //btnX_SetHigh.Visible = true;
           // }

            //if (EnableLow == "0")
            //{
            //    btnX_SetLow.Visible = false;
            //}
            //else
            //{
                //btnX_SetLow.Visible = true;
            //}

            //设置时间轴
            axTChart1.Axis.Bottom.SetMinMax(0, AxisXMax);

            //设置左侧试验力轴
            axTChart1.Axis.Left.SetMinMax(-20, 20);

            //设置右侧位移轴
            axTChart1.Axis.Right.SetMinMax(-20, 20);

            axTChart1.Axis.Custom[0].SetMinMax(-20, 20);

            axTChart1.Axis.Custom[1].SetMinMax(-20, 20);

            axTChart1.Series(0).Color = (uint)(Color.Blue.B << 16) | (ushort)((Color.Blue.G << 8) | Color.Blue.R);
            axTChart1.Series(1).Color = (uint)(Color.Red.B << 16) | (ushort)((Color.Red.G << 8) | Color.Red.R);
            axTChart1.Series(2).Color = (uint)(Color.Black.B << 16) | (ushort)((Color.Black.G << 8) | Color.Black.R);
            axTChart1.Series(3).Color = (uint)(Color.SeaGreen.B << 16) | (ushort)((Color.SeaGreen.G << 8) | Color.SeaGreen.R);


            axTChart1.Repaint();

            //测试数据
            //for (int i = 0; i < 100; i++)
            //{
            //    axTChart1.Series(0).AddXY(i, 0.15 * i, "", 0);

            //    axTChart1.Series(1).AddXY(i, 0.3 * i, "", 0);
            //}

            //cb_ShowPosition.CheckState = CheckState.Checked;

            //添加皮肤种类
            var skinNames = Enum.GetNames(typeof(eStyle));
            foreach (string skin in skinNames)
            {
                this.cbk_Skin.Items.Add(skin);
            }
            this.cbk_Skin.SelectedIndex = themeComboIndex;

            if (Enum.TryParse<eStyle>(this.cbk_Skin.Text, out var result))
            {
                this.styleManager1.ManagerStyle = result;
            }
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

                    if (ctrl == null)
                    {
                        foreach (SuperTabItem tabItem in superTabControl1.Tabs)
                        {
                            // 获取当前 TabItem 的内容区域
                            if (tabItem.Name == controlName)
                            {
                                tabItem.Text = textValue;
                                break;
                            }
                        }

                        //for (int i = 0; i < chart_machine.ChartAreas[0].Axes.Count(); i++)
                        //{
                        //    if (chart_machine.ChartAreas[0].Axes[i].Name == controlName)
                        //    {
                        //        chart_machine.ChartAreas[0].Axes[i].Title = textValue;
                        //        break;
                        //    }
                        //}

                        //if (controlName.Contains("chartSeries"))
                        //{
                        //    for (int i = 0; i < chart_machine.Series.Count(); i++)
                        //    {
                        //        if (controlName.Contains(i.ToString()))
                        //        {
                        //            chart_machine.Series[i].Name = textValue;
                        //            break;
                        //        }
                        //    }
                        //}

                        if (controlName.Contains("toolStripStatusLabel"))
                        {
                            for (int i = 0; i < this.statusStrip1.Items.Count; i++)
                            {
                                if (statusStrip1.Items[i].Name == controlName)
                                {
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
                //btnX_Disconnect.Enabled = true;
                //btnX_MoveQuickUp.Enabled = true;
                //bntX_MoveUp.Enabled = true;
                //bntX_MoveHalt.Enabled = true;
                //bntX_MoveDown.Enabled = true;
                //btnX_QuickMoveDown.Enabled = true;
                //bntX_GUIOn.Enabled = true;
                //bntX_GUIOff.Enabled = true;

                //floatMenus
                floatMenus.EnableButton(true);
            }
            else
            {
                //btnX_Connect.Enabled = true;
                //btnX_Disconnect.Enabled = false;
                //btnX_MoveQuickUp.Enabled = false;
                //bntX_MoveUp.Enabled = false;
                //bntX_MoveHalt.Enabled = false;
                //bntX_MoveDown.Enabled = false;
                //btnX_QuickMoveDown.Enabled = false;
                //bntX_GUIOn.Enabled = false;
                //bntX_GUIOff.Enabled = false;

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
        //private void bntX_MoveUp_Click(object sender, EventArgs e)
        //{

        //}


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
                        speed = btnUpConstantVal/60;

                        //DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 2, ref MyTan);
                        DoPE.ERR error = MyEdc.Move.FMove(DoPE.MOVE.UP, DoPE.CTRL.POS, speed, ref MyTan);
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
                        speed = btnUpConstantVal/60;

                        DoPE.ERR error = MyEdc.Move.FMove(MOVE.UP, DoPE.CTRL.POS, speed, ref MyTan);
                        DisplayError(error, "FMove");
                    }
                    catch (NullReferenceException)
                    {
                        Display(CommandFailedString);
                    }
                }
            }
        }

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
        //private void btnX_MoveQuickUp_Click(object sender, EventArgs e)
        //{
            
        //}


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
                        speed = btnHurryUpConstantVal/60;
                        //DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 20, ref MyTan);
                        DoPE.ERR error = MyEdc.Move.FMove(DoPE.MOVE.UP, DoPE.CTRL.POS, speed, ref MyTan);
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
                        speed = btnHurryUpConstantVal/60;

                        DoPE.ERR error = MyEdc.Move.FMove(MOVE.UP, DoPE.CTRL.POS, speed, ref MyTan);
                        DisplayError(error, "FMove");
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

                    bShowSensorData = false;
                    nCycleCount = 0;

                    //timer_UpdateData.Stop();
                    stopwatch.Stop();

                    SetControlEnable(true);

                    tbX_TestCount.Text = tbX_TestCycles.Text;

                    IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCycles.Text);

                    tbX_TestCount.Enabled = true;
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
                        speed = btnDownConstantVal/60;

                        //DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref MyTan);
                        DoPE.ERR error = MyEdc.Move.FMove(DoPE.MOVE.DOWN, DoPE.CTRL.POS, speed, ref MyTan);
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
                        speed = btnDownConstantVal/60;

                        DoPE.ERR error = MyEdc.Move.FMove(MOVE.DOWN, DoPE.CTRL.POS, speed, ref MyTan);
                        DisplayError(error, "FMove");
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
                        speed = btnHurryDownConstantVal/60;

                        //DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref MyTan);
                        DoPE.ERR error = MyEdc.Move.FMove(DoPE.MOVE.DOWN, DoPE.CTRL.POS, speed, ref MyTan);
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
                        speed = btnHurryDownConstantVal/60;

                        DoPE.ERR error = MyEdc.Move.FMove(MOVE.DOWN, DoPE.CTRL.POS, speed, ref MyTan);
                        DisplayError(error, "FMove");

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
                    //btnX_SetLow.Checked = false;
                    //btnX_SetHigh.Checked = true;
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

                //if (Err == DoPE.ERR.NOERROR)
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

                //if (Err == DoPE.ERR.NOERROR)
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

        #endregion 


        /// <summary>
        /// 示波
        /// </summary>
        /// <param name="Block"></param>
        private async void ShowWave(DoPE.OnDataBlock Block)
        {
             //X轴坐标长度 = dStep * nTotal
            //dStep = 0.01;
            //dStep = 0.001;
            //nTotal = 2000;

            //if (chart_machine != null)
            {
                if (!bPause)
                {
                    double y_Position = 0.0d;
                    double y_Load = 0.0d;
                    double y_Extension = 0.0d;
                    double y_Command = 0.0d;
                    //for (int i = 20; Block.Data.Length > i; i += 200)
                    //for (int i = 5; Block.Data.Length >= i; i += 50)
                    for (int i = 0; Block.Data.Length > i; i += (int)SampleFrequency * 10/*5 / 2*/)
                    {
                        //绘制Position
                         y_Position = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_S];

                        //绘制Load
                        y_Load = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_F];

                        if (LoadUnit.ToUpper() == "KN")
                        {
                            y_Load = y_Load / 1000;
                        }
                        //绘制Extension
                         y_Extension = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_E];

                        //绘制Command
                        y_Command = Block.Data[i].Data.Command;

                        chartX.Add(x_Data);

                        //批量添加点

                        //axTChart1.Series(0).BeginUpdate();
                        //暂停重绘提高性能
                        chartPosY.Add(y_Position);
                        chartLoadY.Add(y_Load);
                        chartExtY.Add(y_Extension);
                        chartCommandY.Add(y_Command);
                        try
                        {
                            //axTChart1.AutoRepaint = false;
                            if (chartX.Count % (200/*DataRefreshFrequency / SampleFrequency*/) == 0)
                            {
                                //axTChart1.Series(0).AddXY(x_Data, y_Position, null, 0);  // Position
                                //axTChart1.Series(1).AddXY(x_Data, y_Load, "", 0);   // Load
                                if (bShowPosition)
                                {
                                    axTChart1.Series(0).AddArray(chartX.Count, chartPosY.ToArray(), chartX.ToArray());
                                }

                                if (bShowLoad)
                                {
                                    axTChart1.Series(1).AddArray(chartX.Count, chartLoadY.ToArray(), chartX.ToArray());
                                }

                                if (bShowExtension)
                                {
                                    axTChart1.Series(2).AddArray(chartX.Count, chartExtY.ToArray(), chartX.ToArray());
                                }

                                if (bShowCommand)
                                {
                                    axTChart1.Series(3).AddArray(chartX.Count, chartCommandY.ToArray(), chartX.ToArray());
                                }
                                //axTChart1.AutoRepaint = true; 

                                //axTChart1.Series(0).EndUpdate();

                            }

                            if (chartX.Count >= nTotal)
                            {
                                x_Data = 0.0;

                                chartX.Clear();
                                chartPosY.Clear();
                                chartLoadY.Clear();
                                chartExtY.Clear();
                                chartCommandY.Clear();
                                //axTChart1.AutoRepaint = true;
                                //axTChart1.Refresh();
                            }
                        }
                        finally
                        {
                            // 恢复重绘
                            //chart_machine.ResumeLayout();
                        }

                        x_Data += dStep;
                    }
                }
            }
        }


        /// <summary>
        /// 自动调整Y轴的大小
        /// </summary>
        /// <param name="series0maxY"></param>
        /// <param name="series0minY"></param>
        /// <param name="series1maxY"></param>
        /// <param name="series1minY"></param>
        /// <param name="series2maxY"></param>
        /// <param name="series2minY"></param>
        /// <param name="series3maxY"></param>
        /// <param name="series3minY"></param>
        public void AutoFittingCurve(double series0maxY, double series0minY, double series1maxY, double series1minY, double series2maxY, double series2minY, double series3maxY, double series3minY)
        {
            //Console.WriteLine("glmxxx-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}", series0maxY, series0minY, series1maxY, series1minY, series2maxY, series2minY, series3maxY, series3minY);
            //位移y轴自适应
            double series02MaxY = series0maxY;// series0maxY >= series2maxY ? series0maxY : series2maxY;
            double series02minY = series0minY;// series0minY >= series2minY ? series2minY : series0minY;

            double maxSeriesMaxYVal = series02MaxY;
            double maxSeriesMinYVal = series02minY;

            double range1 = maxSeriesMaxYVal - maxSeriesMinYVal;
            double totalHeight1 = range1 / 0.85;        // Y 轴总高度的85%
            double padding1 = (totalHeight1 - range1) / 2.0;  // 上下留白

            double yAxisMax1 = maxSeriesMaxYVal + padding1;
            double yAxisMin1 = maxSeriesMinYVal - padding1;

            //Console.WriteLine("glmyyy-{0}-{1}", yAxisMax1, yAxisMin1);
            //力y轴自适应
             maxSeriesMaxYVal = series1maxY;
             maxSeriesMinYVal = series1minY;

             range1 = maxSeriesMaxYVal - maxSeriesMinYVal;
             totalHeight1 = range1 / 0.85;        // Y 轴总高度的85%
             padding1 = (totalHeight1 - range1) / 2.0;  // 上下留白

             yAxisMax1 = maxSeriesMaxYVal + padding1;
             yAxisMin1 = maxSeriesMinYVal - padding1;

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


        /// <summary>
        /// 数据更新定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_UpdateData_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_SystemTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Invalidate(toolStripStatusLabel_SystemTime.Bounds);
            Invalidate(guiTime.Bounds);

            if (!bConnected)
            {
                return;
            }

            TimeSpan elapsed = stopwatch.Elapsed;
            guiTime.Text = string.Format(@"{0:D2}:{1:D2}:{2:D2}", (int)elapsed.TotalHours, elapsed.Minutes, elapsed.Seconds);

            //EnableButton();
            Update();

        }


        /// <summary>
        /// 设置参数
        /// </summary>
        public void SetMemberParam()
        {
            nCountREfresh = DataRefreshFrequency / (double)SampleFrequency;

            if (LoadUnit.ToUpper() == "KN")
            {
                //chart_machine.ChartAreas[0].AxisY2.Title = "试 \n\n验\n\n力\n\n(kN)";
                axTChart1.Axis.Right.Title.Caption = "试验力(kN)";
                gp_Load.Text = "试验力(kN)";
            }
            else
            {
                //chart_machine.ChartAreas[0].AxisY2.Title = "试 \n\n验\n\n力\n\n(N)";
                axTChart1.Axis.Right.Title.Caption = "试验力(N)";
                gp_Load.Text = "试验力(N)";
            }

            //axTChart1.Chart.AnimatedUpdate = true;
            //axTChart1.Chart.AnimatedDuration = 300; // 动画持续时间（毫秒）
            //axTChart1.Series(0).Clear();

            //axTChart1.DoubleBuffer.Double = true;

        }


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
                //stopwatch.Start();
            }
        }

        public void MoveHaultW(DoPE.CTRL control, double delay)
        {
            DoPE.ERR error = MyEdc.Move.HaltW(control, delay, ref MyTan);

            ////正常返回，开始计时
            //if (error == DoPE.ERR.NOERROR)
            //{
            //    //stopwatch.Start();
            //}
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
                //stopwatch.Start();
            }
        }


        /// <summary>
        /// 设置命令曲线坐标轴
        /// </summary>
        /// <param name="seriesType">曲线类型，根据命令类型得出，比如按照dopectrl中的参数得到</param>
        /// <param name="axisType">坐标轴编号primary or secondary</param>
        public void SetCmdSeriesAxisY(int cmdType)
        {
            //switch (cmdType)
            //{
            //    case 0:            //position
            //        chart_machine.Series[3].YAxisType = AxisType.Primary;
            //        break;
            //    case 1:            //Load
            //        chart_machine.Series[3].YAxisType = AxisType.Secondary;
            //        break;
            //    case 2:           //Extension
            //        chart_machine.Series[3].YAxisType = AxisType.Primary;
            //        break;
            //    default:      //position
            //        chart_machine.Series[3].YAxisType = AxisType.Primary;
            //        break;
            //}
        }


        /// <summary>
        /// DynCycles
        /// </summary>
        /// <param name="WaveForm"></param>
        /// <param name="Modify"></param>
        /// <param name="PeakCtrl"></param>
        /// <param name="MoveCtrl"></param>
        /// <param name="RelativeDestination"></param>
        /// <param name="SpeedToStart"></param>
        /// <param name="Offset"></param>
        /// <param name="Amplitude"></param>
        /// <param name="HaltAtPlusAmplitude"></param>
        /// <param name="HaltAtMinusAmplitude"></param>
        /// <param name="Frequency"></param>
        /// <param name="HalfCycles"></param>
        /// <param name="SpeedToDestination"></param>
        /// <param name="Destination"></param>
        /// <param name="SweepFrequencyMode"></param>
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
            if (error == DoPE.ERR.NOERROR || error == DoPE.ERR.CMD_PARCORR || error == DoPE.ERR.CMD_PAR)
            {
                string strtmp = "";
                //MessageBox.Show(((DoPE.CTRL)MoveCtrl).ToString());
                if ((DoPE.CTRL)MoveCtrl == DoPE.CTRL.POS)
                {
                    strtmp = "mm";
                }
                else if ((DoPE.CTRL)MoveCtrl == DoPE.CTRL.LOAD)
                {
                    strtmp = "kN";
                }

                string strAmplitude = "", strOffset = "";
                if (LoadUnit.ToUpper() == "KN")
                {
                    strAmplitude = (Amplitude / 1000).ToString();
                    strOffset = (Offset / 1000).ToString();
                }

                //设置试验参数
                tb_TestParam.Text = string.Format("控制方式：{0}，波形方式：{1}，循环次数：{2} 次，偏移:{3} {6}, 振幅:{4} {6}, 频率:{5} Hz",
               MoveCtrl, WaveForm, HalfCycles / 2, strOffset, strAmplitude, Frequency, strtmp);

                //开始计时
                timer_UpdateData.Start();

                bShowSensorData = true;
                isRunning = true;
                SetControlEnable(false);
                nTestCount = HalfCycles;
                stopwatch.Start();

                IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCount.Text);

                //读取最后一次实验次数
                StringBuilder strTmp = new StringBuilder(255);
                IniFileHelper.GetIniString("Setting", "TestCount", "0", strTmp, strTmp.Capacity);
                nPreTestCount = int.Parse(strTmp.ToString());
         
                //实验开始禁用次数修改
                tbX_TestCount.Enabled = false;

                //清理位移队列
                if (PVPositionQueue.Count > 0)
                {
                    PVPositionQueue.Clear();
                }

                //清理位移平均值队列
                if (PVPositionMaxAverageList.Count > 0)
                {
                    PVPositionMaxAverageList.Clear();
                }

                if (PVPositionMinAverageList.Count > 0)
                {
                    PVPositionMinAverageList.Clear();
                }

                //清理试验力队列
                if (PVLoadQueue.Count > 0)
                {
                    PVLoadQueue.Clear();
                }

                //清理试验力平均值队列
                PVLoadMaxAverageList.Clear();
                PVLoadMinAverageList.Clear();

                //清理变形队列
                if (PVExtensionQueue.Count > 0)
                {
                    PVExtensionQueue.Clear();
                }

                //清理位移平均值队列
                PVExtensionMaxAverageList.Clear();
                PVExtensionMinAverageList.Clear();
       
            }

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
                frmDynCtrl.SetCountText(tbX_TestCount.Text);
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
            PauseDrawWave();
        }


        public void PauseDrawWave()
        {
            bPause = !bPause;

            if (bPause)
            {
                startStopDrawToolStripMenuItem.Text = GetValueFromLanguageFile("startStopDrawToolStripMenuItemPause");

                axTChart1.AutoRepaint = false;
                axTChart1.Refresh(); // 如果有需要，强制一次重绘
            }
            else
            {
                startStopDrawToolStripMenuItem.Text = GetValueFromLanguageFile("startStopDrawToolStripMenuItem");
                axTChart1.AutoRepaint = true;

                if (MainForm.mainform.AxisXMax <= axTChart1.Axis.Bottom.Minimum)
                {
                    axTChart1.Axis.Bottom.Minimum = 0;
                    axTChart1.Axis.Bottom.Maximum = MainForm.mainform.AxisXMax;
                }
                else {
                    axTChart1.Axis.Bottom.Maximum = MainForm.mainform.AxisXMax;
                    axTChart1.Axis.Bottom.Minimum = 0;
                }
            }

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
            //btnX_MoveQuickUp.Enabled = bState;
            //bntX_MoveUp.Enabled = bState;
            //bntX_MoveDown.Enabled = bState;
            //btnX_QuickMoveDown.Enabled = bState;
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
            //运行时禁止修改
            if (!isRunning)
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
            //运行时禁止修改
            if (!isRunning)
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


        /// <summary>
        /// 获取X轴缩放
        /// </summary>
        public void GetXaxisScale()
        {
            //if (chart_machine != null)
            //{
            //    double dMax = chart_machine.ChartAreas[0].AxisX.Maximum;
            //    double dMin = chart_machine.ChartAreas[0].AxisX.Minimum;
            //    if ((dMax - dMin) > 0)
            //    {
            //        nAxisStep = 1 / ((dMax - dMin) /** 2*/);
            //    }
            //    else
            //    {
            //        nAxisStep = 0.1;
            //    }
            //}
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


        //运行时才能决定是否执行内联
        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        //public ushort setUInt16(float src, ushort k = 1)
        //{
        //    return (ushort)(src * k);
        //}


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
            string idEncry = devIdEncrypted.ToString();
            if (idEncry != "0" && idEncry != "")
            {
                devId = new StringBuilder(DESEncrypt.Decrypt(idEncry));
            }
            //devId = new StringBuilder("02132F05");

            //string aaa = DESEncrypt.Encrypt("0214C55E");

            //读取上次的试验次数
            IniFileHelper.GetIniString("Setting", "TestCount", "0", strTmp, strTmp.Capacity);
            nPreTestCount = int.Parse(strTmp.ToString());
            tbX_TestCount.Text = strTmp.ToString();
            tbX_TestCycles.Text = tbX_TestCount.Text;

            //按试验次数记录日志
            IniFileHelper.GetIniString("Setting", "SaveCountLog", "0", strTmp, strTmp.Capacity);
            bSaveCountLog = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("Setting", "CountLog", "100", strTmp, strTmp.Capacity);
            nCountLog = int.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("Setting", "SavePVCountLog", "0", strTmp, strTmp.Capacity);
            bSavePVCountLog = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("Setting", "PVCountLog", "100", strTmp, strTmp.Capacity);
            nPVCountLog = int.Parse(strTmp.ToString());

            //试验结束时自动存储当前屏幕数据
            IniFileHelper.GetIniString("Setting", "SaveStopScreen", "0", strTmp, strTmp.Capacity);
            bSaveStopScreenLog = strTmp.ToString() == "0" ? false : true;

            //自动存储试验过程数据
            IniFileHelper.GetIniString("Setting", "SaveRunningLog", "0", strTmp, strTmp.Capacity);
            bSaveRunningLog = strTmp.ToString() == "0" ? false : true;

            //语言
            IniFileHelper.GetIniString("Setting", "Language", "简体中文", strTmp, strTmp.Capacity);
            strLanguage = strTmp.ToString();

            //试验力单位
            IniFileHelper.GetIniString("Setting", "LoadUnit", "N", strTmp, strTmp.Capacity);
            LoadUnit = strTmp.ToString();

            //采样频率
            IniFileHelper.GetIniString("Setting", "SampleFrequency", "1", strTmp, strTmp.Capacity);
            SampleFrequency = double.Parse(strTmp.ToString());

            //数据刷新频率
            IniFileHelper.GetIniString("Setting", "DataRefreshFrequency", "200", strTmp, strTmp.Capacity);
            DataRefreshFrequency = int.Parse(strTmp.ToString());

            //曲线刷新频率
            IniFileHelper.GetIniString("Setting", "WaveRefreshFrequency", "200", strTmp, strTmp.Capacity);
            WaveRefreshFrequency = int.Parse(strTmp.ToString());

            //曲线刷新频率
            IniFileHelper.GetIniString("Setting", "EnableHigh", "0", strTmp, strTmp.Capacity);
            EnableHigh = strTmp.ToString();

            //曲线刷新频率
            IniFileHelper.GetIniString("Setting", "EnableLow", "0", strTmp, strTmp.Capacity);
            EnableLow = strTmp.ToString();

            //主题
            IniFileHelper.GetIniString("Setting", "Theme", "-1", strTmp, strTmp.Capacity);            
            themeComboIndex =int.Parse(strTmp.ToString());
            if (themeComboIndex == -1) themeComboIndex = 0;

            //停机保护选项
            IniFileHelper.GetIniString("FrmSystemSetting", "限位保护选项", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOptionType = strTmp.ToString();

            #region 位移保护
            IniFileHelper.GetIniString("FrmSystemSetting", "位移峰值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMaxOut = double.Parse(strTmp.ToString());
            textBoxX17.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "位移峰值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMaxOut_Effect = strTmp.ToString() == "0" ? false : true;
            checkBoxX6.Checked = protectOption.ProtectOption_PosMaxOut_Effect;

            IniFileHelper.GetIniString("FrmSystemSetting", "位移谷值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMinOut = double.Parse(strTmp.ToString());
            textBoxX15.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "位移谷值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMinOut_Effect = strTmp.ToString() == "0" ? false : true;
            checkBoxX2.Checked = protectOption.ProtectOption_PosMinOut_Effect;

            IniFileHelper.GetIniString("FrmSystemSetting", "位移峰值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMaxIn = double.Parse(strTmp.ToString());
            textBoxX16.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "位移峰值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMaxIn_Effect = false;// strTmp.ToString() == "0" ? false : true;
            checkBoxX5.Checked = protectOption.ProtectOption_PosMaxIn_Effect;

            IniFileHelper.GetIniString("FrmSystemSetting", "位移谷值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMinIn = double.Parse(strTmp.ToString());
            textBoxX14.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "位移谷值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_PosMinIn_Effect = false; // strTmp.ToString() == "0" ? false : true;
            checkBoxX1.Checked = protectOption.ProtectOption_PosMinIn_Effect;
            #endregion 位移保护

            #region 试验力保护
            IniFileHelper.GetIniString("FrmSystemSetting", "试验力峰值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMaxOut = double.Parse(strTmp.ToString());
            textBoxX21.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力峰值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMaxOut_Effect = strTmp.ToString() == "0" ? false : true;
            checkBoxX8.Checked = protectOption.ProtectOption_LoadMaxOut_Effect;

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力谷值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMinOut = double.Parse(strTmp.ToString());
            textBoxX20.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力谷值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMinOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力峰值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMaxIn = double.Parse(strTmp.ToString());
            textBoxX19.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力峰值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMaxIn_Effect = false;// strTmp.ToString() == "0" ? false : true;
            checkBoxX7.Checked = protectOption.ProtectOption_LoadMaxIn_Effect;

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力谷值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMinIn = double.Parse(strTmp.ToString());
            textBoxX18.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "试验力谷值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_LoadMinIn_Effect = false; // strTmp.ToString() == "0" ? false : true;
            checkBoxX3.Checked = protectOption.ProtectOption_LoadMinIn_Effect;
            #endregion 试验力保护

            #region 变形保护
            IniFileHelper.GetIniString("FrmSystemSetting", "变形峰值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMaxOut = double.Parse(strTmp.ToString());
            textBoxX25.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "变形峰值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMaxOut_Effect = strTmp.ToString() == "0" ? false : true;
            checkBoxX12.Checked = protectOption.ProtectOption_ExtMaxOut_Effect;

            IniFileHelper.GetIniString("FrmSystemSetting", "变形谷值外保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMinOut = double.Parse(strTmp.ToString());
            textBoxX23.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "变形谷值外保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMinOut_Effect = strTmp.ToString() == "0" ? false : true;
            checkBoxX10.Checked = protectOption.ProtectOption_ExtMinOut_Effect;

            IniFileHelper.GetIniString("FrmSystemSetting", "变形峰值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMaxIn = double.Parse(strTmp.ToString());
            textBoxX24.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "变形峰值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMaxIn_Effect = false; // strTmp.ToString() == "0" ? false : true;
            checkBoxX11.Checked = protectOption.ProtectOption_ExtMaxIn_Effect;

            IniFileHelper.GetIniString("FrmSystemSetting", "变形谷值内保护", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMinIn = double.Parse(strTmp.ToString());
            textBoxX22.Text = strTmp.ToString();

            IniFileHelper.GetIniString("FrmSystemSetting", "变形谷值内保护生效", "0", strTmp, strTmp.Capacity);
            protectOption.ProtectOption_ExtMinIn_Effect = false;// strTmp.ToString() == "0" ? false : true;
            checkBoxX9.Checked = protectOption.ProtectOption_ExtMinIn_Effect;
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
            IniFileHelper.GetIniString("PushButtonFunctionConstant", "Up", "1", strTmp, strTmp.Capacity);
            btnUpConstantVal = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "HurryUp", "10", strTmp, strTmp.Capacity);
            btnHurryUpConstantVal = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "Down", "1", strTmp, strTmp.Capacity);
            btnDownConstantVal = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("PushButtonFunctionConstant", "HurryDown", "10", strTmp, strTmp.Capacity);
            btnHurryDownConstantVal = double.Parse(strTmp.ToString());
            #endregion 按键功能常数

            IniFileHelper.GetIniString("FrmSetChartAxisY", "TimeX_MAX", "5", strTmp, strTmp.Capacity);
            AxisXMax = double.Parse(strTmp.ToString());
            axTChart1.Axis.Bottom.Maximum = AxisXMax;

            //IniFileHelper.GetIniString("FrmSetChartAxisY", "PositionEnable", "0", strTmp, strTmp.Capacity);
            //cb_ShowPosition.Checked = true;// strTmp.ToString() == "0" ? false : true;

            //IniFileHelper.GetIniString("FrmSetChartAxisY", "LoadEnable", "0", strTmp, strTmp.Capacity);
            //cb_ShowLoad.Checked = true;// strTmp.ToString() == "0" ? false : true;

            //IniFileHelper.GetIniString("FrmSetChartAxisY", "ExtEnable", "1", strTmp, strTmp.Capacity);
            //cb_ShowExtension.Checked = true;// strTmp.ToString() == "0" ? false : true;

            //IniFileHelper.GetIniString("FrmSetChartAxisY", "CommandEnable", "1", strTmp, strTmp.Capacity);
            //cb_ShowCommand.Checked = true;// strTmp.ToString() == "0" ? false : true;

            //单位切换
            IniFileHelper.GetIniString("UIDefault", "comboBoxEx_ForceUnit", "0", strTmp, strTmp.Capacity);
            ProtectionUnitModify(int.Parse(strTmp.ToString()));

            #region 其他标签
            IniFileHelper.GetIniString("SoftWareInfo ", "Name", "电液伺服疲劳试验机", strTmp, strTmp.Capacity);
            this.Text = strTmp.ToString();

            IniFileHelper.GetIniString("CompanyInfo ", "CompanyName", "有限公司", strTmp, strTmp.Capacity);
            lbX_CompanyName.Text = strTmp.ToString();

            IniFileHelper.GetIniString("CompanyInfo ", "CompanyTel", "联系电话", strTmp, strTmp.Capacity);
            lbX_CompanyTel.Text = strTmp.ToString();

            #endregion
        }


        /// <summary>
        /// 打开系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_SystemSetting_Click(object sender, EventArgs e)
        {
            FrmSystemSetting frmSystemSetting = new FrmSystemSetting();
            frmSystemSetting.ShowDialog();
        }


        /// <summary>
        /// 创建多个Y轴
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="area"></param>
        /// <param name="series"></param>
        /// <param name="axisOffset"></param>
        /// <param name="labelsSize"></param>
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
            if (!bPause)
            {
                bPause = true;
                startStopDrawToolStripMenuItem.Text = GetValueFromLanguageFile("startStopDrawToolStripMenuItemPause");
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
            openFileDialog.Filter = "CSV文件 (*.csv)|*.csv"; // 如果需要筛选特定类型的文件，如CSV
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // 使用选中的文件路径进行操作

                if (!string.IsNullOrEmpty(selectedFilePath))
                {
                    ExcelHelper excelHelper = new ExcelHelper(selectedFilePath);

                    DataTable trCsvData = excelHelper.CSVToDataTable(false);

                    //DataPoint dpPos = null;
                    //DataPoint dpLoad = null;
                    //DataPoint dpExt = null;
                    //DataPoint dpCommand = null;
                    chartX.Clear();
                    chartPosY.Clear();
                    chartLoadY.Clear();
                    chartExtY.Clear();
                    chartCommandY.Clear();


                    //List<DataPoint> points = new List<DataPoint>();

                    //for (int i = 0; i < chart_machine.Series[0].Points.Count; i++)
                    //{
                    //    chart_machine.Series[0].Points.RemoveAt(i);
                    //}
                    //for (int i = 0; i < chart_machine.Series[1].Points.Count; i++)
                    //{
                    //    chart_machine.Series[1].Points.RemoveAt(i);
                    //}
                    //for (int i = 0; i < chart_machine.Series[2].Points.Count; i++)
                    //{
                    //    chart_machine.Series[2].Points.RemoveAt(i);
                    //}
                    //for (int i = 0; i < chart_machine.Series[3].Points.Count; i++)
                    //{
                    //    chart_machine.Series[3].Points.RemoveAt(i);
                    //}

                    //chart_machine.Series[0].Points.Clear();
                    //chart_machine.Series[1].Points.Clear();
                    //chart_machine.Series[2].Points.Clear();
                    //chart_machine.Series[3].Points.Clear();

                    if (trCsvData != null && trCsvData.Rows.Count >= 1)
                    {
                        for (int i = 0; i < trCsvData.Rows.Count; i++)
                        {
                            //double strX = double.Parse(trCsvData.Rows[i][0].ToString());
                            //double strYPos = double.Parse(trCsvData.Rows[i][1].ToString());
                            //double strYLoad = double.Parse(trCsvData.Rows[i][2].ToString());
                            //double strYExt = double.Parse(trCsvData.Rows[i][3].ToString());
                            //double strYCommand = double.Parse(trCsvData.Rows[i][4].ToString());

                            //dpPos = new DataPoint(strX, strYPos);
                            //dpLoad = new DataPoint(strX, strYLoad);
                            //dpExt = new DataPoint(strX, strYExt);
                            //dpCommand = new DataPoint(strX, strYCommand);

                            //chart_machine.Series[0].Points.Add(dpPos);
                            //chart_machine.Series[1].Points.Add(dpLoad);
                            //chart_machine.Series[2].Points.Add(dpExt);
                            //chart_machine.Series[3].Points.Add(dpCommand);


                            chartX.Add(double.Parse(trCsvData.Rows[i][0].ToString()));
                            chartPosY.Add(double.Parse(trCsvData.Rows[i][1].ToString()));
                            chartLoadY.Add(double.Parse(trCsvData.Rows[i][2].ToString()));
                            chartExtY.Add(double.Parse(trCsvData.Rows[i][3].ToString()));
                            chartCommandY.Add(double.Parse(trCsvData.Rows[i][4].ToString()));
                        }

                        //if (bShowPosition)
                        {
                            axTChart1.Series(0).AddArray(chartX.Count, chartPosY.ToArray(), chartX.ToArray());
                        }

                        //if (bShowLoad)
                        {
                            axTChart1.Series(1).AddArray(chartX.Count, chartLoadY.ToArray(), chartX.ToArray());
                        }

                        if (chartPosY.Max() <= axTChart1.Axis.Left.Minimum)
                        {
                            axTChart1.Axis.Left.Minimum = chartPosY.Min();
                            axTChart1.Axis.Left.Maximum = chartPosY.Max();
                        }
                        else
                        {
                            axTChart1.Axis.Left.Maximum = chartPosY.Max();
                            axTChart1.Axis.Left.Minimum = chartPosY.Min();
                        }

                        if (chartLoadY.Max() <= axTChart1.Axis.Right.Minimum)
                        {
                            axTChart1.Axis.Right.Minimum = chartLoadY.Min();
                            axTChart1.Axis.Right.Maximum = chartLoadY.Max();
                        }
                        else
                        {
                            axTChart1.Axis.Right.Maximum = chartLoadY.Max();
                            axTChart1.Axis.Right.Minimum = chartLoadY.Min();
                        }

                        if (chartX.Max() <= axTChart1.Axis.Bottom.Minimum)
                        {
                            axTChart1.Axis.Bottom.Minimum = chartX.Min();
                            axTChart1.Axis.Bottom.Maximum = chartX.Max();
                        }
                        else
                        {
                            axTChart1.Axis.Bottom.Maximum = chartX.Max();
                            axTChart1.Axis.Bottom.Minimum = chartX.Min();
                        }

                        //if (bShowExtension)
                        //{
                        //    axTChart1.Series(2).AddArray(chartX.Count, chartExtY.ToArray(), chartX.ToArray());
                        //}

                        //if (bShowCommand)
                        //{
                        //    axTChart1.Series(3).AddArray(chartX.Count, chartCommandY.ToArray(), chartX.ToArray());
                        //}
                        //axTChart1.AutoRepaint = true; 

                        //axTChart1.Series(0).EndUpdate();
                    }
                    else
                    {
                        MessageBox.Show("所选的文件内无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

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

            for (int i = 0; i < corrNo; i ++)
            {
                string strLoadIndex = string.Format(@"S1Data_{0}", i);
                dLoad[i] = double.Parse(section[strLoadIndex] ?? "0") * 1000;

                string strDeformationIndex = string.Format(@"S2Data_{0}", i);
                dDeformation[i] = double.Parse(section[strDeformationIndex] ?? "0");
            }

            SensorCorrectionTable stiffnessCorrectionTable = new SensorCorrectionTable();
            stiffnessCorrectionTable.CorrNo = corrNo;
            stiffnessCorrectionTable.S1Correction = dLoad;
            stiffnessCorrectionTable.S2Value = dDeformation;

            return stiffnessCorrectionTable;
        }


        /// <summary>
        /// 调整左侧Y轴最小值增大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_AxisPOSY_MinUp_Click(object sender, EventArgs e)
        {
            if (Chart_Pos_Step >= (axTChart1.Axis.Left.Maximum - axTChart1.Axis.Left.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                axTChart1.Axis.Left.Minimum += Chart_Pos_Step;
            }
        }


        /// <summary>
        /// 调整左侧Y轴最大值减小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_AsixPOSY_MinDown_Click(object sender, EventArgs e)
        {
            axTChart1.Axis.Left.Minimum -= Chart_Pos_Step;
        }


        /// <summary>
        /// 调整左侧Y轴最大值增大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_AxisPOSY_MaxUp_Click(object sender, EventArgs e)
        {
            axTChart1.Axis.Left.Maximum += Chart_Pos_Step;
        }


        /// <summary>
        /// 调整左侧Y轴最大值减小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_AxisPOSY_MaxDown_Click(object sender, EventArgs e)
        {
            if (Chart_Pos_Step >= (axTChart1.Axis.Left.Maximum - axTChart1.Axis.Left.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                axTChart1.Axis.Left.Maximum -= Chart_Pos_Step;
            }

        }


        /// <summary>
        /// 调整右侧Y轴最大值增大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_AxisLoadY_MaxUp_Click(object sender, EventArgs e)
        {
            axTChart1.Axis.Right.Maximum += Chart_Load_Step;
        }


        /// <summary>
        /// 调整右侧Y轴最大值减小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_AxisLoadY_MaxDown_Click(object sender, EventArgs e)
        {
            if (Chart_Load_Step >= (axTChart1.Axis.Right.Maximum - axTChart1.Axis.Right.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                axTChart1.Axis.Right.Maximum -= Chart_Load_Step;
            }
        }


        /// <summary>
        /// 调整右侧Y轴最小值增大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_AxisLoadY_MinUp_Click(object sender, EventArgs e)
        {
            if (Chart_Load_Step >= (axTChart1.Axis.Right.Maximum - axTChart1.Axis.Right.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                axTChart1.Axis.Right.Minimum += Chart_Load_Step;
            }
        }


        /// <summary>
        /// 调整右侧Y轴最小值增大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_AxisLoadY_MinDown_Click(object sender, EventArgs e)
        {
            axTChart1.Axis.Right.Minimum -= Chart_Load_Step;
        }


        /// <summary>
        /// 刷新设备编号
        /// </summary>
        /// <param name="strID"></param>
        public void RefreshDeviceID(string strID)
        {
            devId = new StringBuilder(strID);
            //Console.WriteLine("refresh_controls:{0}",strControl);
        }


        /// <summary>
        /// 检查Y轴大小区间是否合理
        /// </summary>
        /// <param name="maxAxis"></param>
        /// <param name="minAxis"></param>
        /// <returns></returns>
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
                bQuit = true;

                if (bConnected)
                {
                    OffEDC();
                }
            }
            else if (result == DialogResult.No)
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
            //#region postion axis auto fitting
            //位移曲线自适应
            try
            {
                if (!double.TryParse(tb_MaxPos.Text, out double maxPos) ||
                  !double.TryParse(tb_MinPos.Text, out double minPos))
                {
                    // 解析失败，使用默认范围或不处理
                    axTChart1.Axis.Left.Maximum = 0.1;
                    axTChart1.Axis.Left.Minimum = -0.1;
                    axTChart1.Axis.Left.Labels.ValueFormat = "##0.###";
                    return;
                }

                // 处理绝对值过小的情况（接近0）
                if (Math.Abs(maxPos) <= 0.01 && Math.Abs(minPos) <= 0.01)
                {
                    axTChart1.Axis.Left.Maximum = 0.1;
                    axTChart1.Axis.Left.Minimum = -0.1;
                }
                else
                {
                    // 使用一个小的 epsilon 避免除以0或范围过小
                    const double epsilon = 1e-10;
                    double range = Math.Max(Math.Abs(maxPos - minPos), epsilon);

                    // 如果 max 和 min 非常接近，强制设置一个对称范围
                    if (range < epsilon * 100) // 可调阈值
                    {
                        double center = (maxPos + minPos) / 2.0;
                        axTChart1.Axis.Left.Maximum = center + 0.1;
                        axTChart1.Axis.Left.Minimum = center - 0.1;
                    }
                    else
                    {
                        // 正常情况：保留 85% 的数据范围，上下各留 7.5%
                        double totalHeight = range / 0.85;
                        double padding = (totalHeight - range) / 2.0;

                        axTChart1.Axis.Left.Maximum = maxPos + padding;
                        axTChart1.Axis.Left.Minimum = minPos - padding;
                    }

                    // 统一设置标签格式
                    axTChart1.Axis.Left.Labels.ValueFormat = "##0.###";
                }


                //double maxSeriesMaxYValCmd = -1;
                //double maxSeriesMinYValCmd = -1;
                //if (chart_machine.Series[3].Points.Count > 0 )
                //{
                //    maxSeriesMaxYValCmd = chart_machine.Series[3].Points.Max(point => point.YValues[0]);
                //    maxSeriesMinYValCmd = chart_machine.Series[3].Points.Min(point => point.YValues[0]);
                //}

                //if (chart_machine.Series[0].Points.Count > 0)
                //{
                //    double maxSeriesMaxYVal = chart_machine.Series[0].Points.Max(point => point.YValues[0]);
                //    double maxSeriesMinYVal = chart_machine.Series[0].Points.Min(point => point.YValues[0]);
                //    if (chart_machine.Series[3].YAxisType == chart_machine.Series[0].YAxisType)
                //    {
                //        if (maxSeriesMaxYValCmd != -1 && maxSeriesMinYValCmd != -1 && cb_DrawCommand.Checked)
                //        {

                //            if (maxSeriesMaxYVal < maxSeriesMaxYValCmd) maxSeriesMaxYVal = maxSeriesMaxYValCmd;
                //            if (maxSeriesMinYVal > maxSeriesMinYValCmd) maxSeriesMinYVal = maxSeriesMinYValCmd;
                //        }
                //    }

                //    double range1 = maxSeriesMaxYVal - maxSeriesMinYVal;
                //    double totalHeight1 = range1 / 0.85;        // Y 轴总高度的85%
                //    double padding1 = (totalHeight1 - range1) / 2.0;  // 上下留白

                //    double yAxisMax1 = maxSeriesMaxYVal + padding1;
                //    double yAxisMin1 = maxSeriesMinYVal - padding1;
                //    if (Math.Abs(yAxisMax1 - yAxisMin1)>=0.1)
                //    {
                //        chart_machine.ChartAreas[0].AxisY.Maximum = Math.Round(yAxisMax1, 2);
                //        chart_machine.ChartAreas[0].AxisY.Minimum = Math.Round(yAxisMin1, 2);
                //    }
                //}
                //#endregion postion axis auto fitting


                //试验力曲线自适应
                //#region load auto fitting

                if (Math.Abs(double.Parse(tb_MaxLoad.Text)) <= 0.01 || Math.Abs(double.Parse(tb_MinLoad.Text)) <= 0.01)
                {
                    axTChart1.Axis.Right.Maximum = 0.1;
                    axTChart1.Axis.Right.Minimum = -0.1;
                }
                else
                {
                    if (double.Parse(tb_MaxLoad.Text) == double.Parse(tb_MinLoad.Text))
                    {
                        axTChart1.Axis.Right.Maximum = Math.Round(double.Parse(tb_MaxLoad.Text), 2) * 1.2 + 1;
                        axTChart1.Axis.Right.Minimum = Math.Round(double.Parse(tb_MinLoad.Text), 2) * 1.2 - 1;
                    }
                    else
                    {
                        double range = double.Parse(tb_MaxLoad.Text) - double.Parse(tb_MinLoad.Text);
                        double totalHeight = range / 0.85;        // Y 轴总高度的85%
                        double padding = (totalHeight - range) / 2.0;  // 上下留白

                        double yAxisMax = double.Parse(tb_MaxLoad.Text) + padding;
                        double yAxisMin = double.Parse(tb_MinLoad.Text) - padding;

                        axTChart1.Axis.Right.Maximum = yAxisMax;
                        axTChart1.Axis.Right.Minimum = yAxisMin;
                    }
                    axTChart1.Axis.Right.Labels.ValueFormat = "##0.###";
                }

                //if (chart_machine.Series[1].Points.Count > 0)
                //{
                //    double maxSeriesMaxYVal = chart_machine.Series[1].Points.Max(point => point.YValues[0]);
                //    double maxSeriesMinYVal = chart_machine.Series[1].Points.Min(point => point.YValues[0]);

                //    if (chart_machine.Series[3].YAxisType == chart_machine.Series[1].YAxisType)
                //    {
                //        if (maxSeriesMaxYValCmd != -1 && maxSeriesMinYValCmd != -1 && cb_DrawCommand.Checked)
                //        {

                //            if (maxSeriesMaxYVal < maxSeriesMaxYValCmd) maxSeriesMaxYVal = maxSeriesMaxYValCmd;
                //            if (maxSeriesMinYVal > maxSeriesMinYValCmd) maxSeriesMinYVal = maxSeriesMinYValCmd;
                //        }
                //    }

                //    double range1 = maxSeriesMaxYVal - maxSeriesMinYVal;
                //    double totalHeight1 = range1 / 0.85;        // Y 轴总高度的85%
                //    double padding1 = (totalHeight1 - range1) / 2.0;  // 上下留白

                //    double yAxisMax1 = maxSeriesMaxYVal + padding1;
                //    double yAxisMin1 = maxSeriesMinYVal - padding1;
                //    if (Math.Abs(yAxisMax1 - yAxisMin1) >= 0.1)
                //    {
                //        chart_machine.ChartAreas[0].AxisY2.Maximum = Math.Round(yAxisMax1, 2);
                //        chart_machine.ChartAreas[0].AxisY2.Minimum = Math.Round(yAxisMin1, 2);
                //    }

                //}
                //#endregion load auto fitting
            }
            catch (Exception ex)
            {
                return;
            }
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

        private void ToolStripMenuItem_Setting_Click(object sender, EventArgs e)
        {
            FrmSystemSetting frmSystemSetting = new FrmSystemSetting();
            frmSystemSetting.ShowDialog();
        }

        private void MultiSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }


        /// <summary>
        /// 保存当前屏幕数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveStaticDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //保存图像
            //chart_machine.SaveImage(String.Format(@"D:\{0}.png", DateTime.Now.ToString("yyyyMMddhhmmssfff")), ChartImageFormat.Png);
            // TODO 增加键盘事件
            if (bPause)
            {
                string strSaveStaticLog = "";
                string strBlockLog = "";
                int n = 0;

                //保存X Y 值的 列表
                List<double> listXPoint = new List<double>();

                //位移 
                List<double> listYPosPoint = new List<double>();

                //试验力
                List<double> listYLoadPoint= new List<double>();

                //变形
                List<double> listYExtPoint= new List<double>();

                //命令
                List<double> listYCommandPoint = new List<double>();

                if (axTChart1.Series(1).Count > 0)
                {
                    listXPoint.AddRange(Enumerable.Range(0, axTChart1.Series(1).Count)
                        .Select(i => axTChart1.Series(1).XValues.Value[i]));
                }

                if (axTChart1.Series(1).Count > 0)
                {
                    listYPosPoint.AddRange(Enumerable.Range(0, axTChart1.Series(0).Count)
                        .Select(i => axTChart1.Series(0).YValues.Value[i]));
                }

                if (axTChart1.Series(1).Count > 0)
                {
                    listYLoadPoint.AddRange(Enumerable.Range(0, axTChart1.Series(1).Count)
                        .Select(i => axTChart1.Series(1).YValues.Value[i]));
                }

                if (listXPoint != null && listYPosPoint != null && listYLoadPoint != null
                    && listYExtPoint != null && listYCommandPoint != null)
                {
                    for (int i = 0; i < listXPoint.Count - 1; i++)
                    {
                        strBlockLog = listXPoint[i].ToString("#0.0000") + "," + listYPosPoint[i].ToString("#0.0000") + ","
                            + listYLoadPoint[i].ToString("#0.0000") + "," + listYExtPoint[i].ToString("#0.0000")
                            + "," + listYCommandPoint[i].ToString("#0.0000") + ",0";
                        strSaveStaticLog = strBlockLog;
                        LogHelper.SaveStaticCsvData(strSaveStaticLog);
                    }

                    MessageBox.Show("保存日志成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请先暂停绘制！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ToolStripMenuItem_OpenLangDir_Click(object sender, EventArgs e)
        {

        }

        private void timer_ShowWave_Tick(object sender, EventArgs e)
        {
            //if (bConnected)
            //{
            //    //ShowWaveNew();
            //}

        }

        private void pl_DataShow_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {                
                floatMenus.Location = new Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
                floatMenus.Visible = true;
            }
        }
		
        /// <summary>
        /// 初始化试验次数判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbX_TestCount_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(tbX_TestCount.Text.Trim(), out int value))
            {
                if (value < 0)
                {
                    MessageBox.Show("请输入正整数的试验次数。");
                    tbX_TestCount.Focus();
                    tbX_TestCount.SelectAll();
                    return;
                }
                else
                {
                    IniFileHelper.WriteIniString("Setting", "TestCount", tbX_TestCount.Text);
                }
            }
            else
            {
                MessageBox.Show("请输入一个有效的数字。");
                return;
            }
        }

        private void labelX33_Click(object sender, EventArgs e)
        {

        }

        private void cb_ShowPosition_CheckedChanged(object sender, EventArgs e)
        {
            //bShowPosition = cb_ShowPosition.Checked;
            ////axTChart1.Series(0).Active = bShowPosition;
            //axTChart1.Series(0).Pen.Visible = bShowPosition;
        }

        private void cb_ShowLoad_CheckedChanged(object sender, EventArgs e)
        {
            //bShowLoad = cb_ShowLoad.Checked;
            ////axTChart1.Series(1).Active = bShowLoad;
            //axTChart1.Series(1).Pen.Visible = bShowLoad;
        }

        private void cb_ShowExtension_CheckedChanged(object sender, EventArgs e)
        {
            //bShowExtension = cb_ShowExtension.Checked;
            ////axTChart1.Series(2).Active = bShowExtension;
            //axTChart1.Series(2).Pen.Visible = bShowExtension;
        }

        private void cb_ShowCommand_CheckedChanged(object sender, EventArgs e)
        {
            //bShowCommand = cb_ShowCommand.Checked;
            ////axTChart1.Series(3).Active = bShowLoad;
            //axTChart1.Series(3).Pen.Visible = bShowLoad;
        }


        /// <summary>
        /// 校正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 校正ToolStripMenuItem_Click(object sender, EventArgs e)
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
            }
            else
            {
                Console.WriteLine("未选择文件");
                return;
            }
        }

        public void 校正ToolStripMenuItem_Click()
        {
            EventArgs tmpArg = new EventArgs();
            校正ToolStripMenuItem_Click(this, tmpArg);
        }


        /// <summary>
        /// 多传感器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 多传感器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMultiSensor == null || frmMultiSensor.IsDisposed)
            {
                frmMultiSensor = new FrmMultiSensor(this); // 传入父窗口引用
                frmMultiSensor.Show();
            }
            else
            {
                frmMultiSensor.BringToFront();
            }
        }

        public void 多传感器ToolStripMenuItem_Click()
        {
            EventArgs tmpArgs = new EventArgs();
            多传感器ToolStripMenuItem_Click(this, tmpArgs);
        }

            private void pOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            posToolStripMenuItem_Click(sender, e);
        }

        private void dynCtrlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dynCtrlToolStripMenuItem_Click(sender, e);
        }
        bool floatRunOnce = true;
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (floatRunOnce)
            {
                this.Invoke(new MethodInvoker(ShowFloatMenus));
                floatRunOnce = false;
            }
        }

        public void ShowFloatMenus()
        {
            floatMenus.Show();
            floatMenus.Activate();
            floatMenus.TopMost = true;
        }

        /// <summary>
        /// 保护选项生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_ApplyProtection_Click(object sender, EventArgs e)
        {
            //if (!ValidityCheck())
            //{
            //    MessageBox.Show("数据校验不通过", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            //    return;
            //}
            SaveProtect2Ini();

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UnitIndex"></param>
        public void ProtectionUnitModify(int UnitIndex)
        {
            if (UnitIndex == 0)
            { //kN
                label6.Text = "kN";
                label5.Text = "kN";
                label4.Text = "kN";
                label3.Text = "kN";

            }
            else
            { //N
                label6.Text = "N";
                label5.Text = "N";
                label4.Text = "N";
                label3.Text = "N";

            }
        }

        private void SaveProtect2Ini()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            string strConfigSetion = "FrmSystemSetting";

            //位移保护选项
            strTmp = textBoxX17.Text;
            MainForm.mainform.protectOption.ProtectOption_PosMaxOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "位移峰值外保护", strTmp);

            strTmp = checkBoxX6.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_PosMaxOut_Effect = checkBoxX6.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "位移峰值外保护生效", strTmp);

            strTmp = textBoxX15.Text;
            MainForm.mainform.protectOption.ProtectOption_PosMinOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "位移谷值外保护", strTmp);

            strTmp = checkBoxX2.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_PosMinOut_Effect = checkBoxX2.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "位移谷值外保护生效", strTmp);

            strTmp = textBoxX16.Text;
            MainForm.mainform.protectOption.ProtectOption_PosMaxIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "位移峰值内保护", strTmp);

            strTmp = checkBoxX5.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_PosMaxIn_Effect = checkBoxX5.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "位移峰值内保护生效", strTmp);

            strTmp = textBoxX14.Text;
            MainForm.mainform.protectOption.ProtectOption_PosMinIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "位移谷值内保护", strTmp);

            strTmp = checkBoxX1.Checked == true ? "1" : "0";
            MainForm.mainform.protectOption.ProtectOption_PosMinIn_Effect = checkBoxX1.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "位移谷值内保护生效", strTmp);

            //试验力保护选项
            strTmp = textBoxX21.Text;
            MainForm.mainform.protectOption.ProtectOption_LoadMaxOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "试验力峰值外保护", strTmp);

            strTmp = checkBoxX8.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_LoadMaxOut_Effect = checkBoxX8.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "试验力峰值外保护生效", strTmp);

            strTmp = textBoxX20.Text;
            MainForm.mainform.protectOption.ProtectOption_LoadMinOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "试验力谷值外保护", strTmp);

            strTmp = checkBoxX4.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_LoadMinOut_Effect = checkBoxX4.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "试验力谷值外保护生效", strTmp);

            strTmp = textBoxX19.Text;
            MainForm.mainform.protectOption.ProtectOption_LoadMaxIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "试验力峰值内保护", strTmp);

            strTmp = checkBoxX7.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_LoadMaxIn_Effect = checkBoxX7.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "试验力峰值内保护生效", strTmp);

            strTmp = textBoxX18.Text;
            MainForm.mainform.protectOption.ProtectOption_LoadMinIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "试验力谷值内保护", strTmp);

            strTmp = checkBoxX3.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_LoadMinIn_Effect = checkBoxX3.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "试验力谷值内保护生效", strTmp);

            //变形保护选项
            strTmp = textBoxX25.Text;
            MainForm.mainform.protectOption.ProtectOption_ExtMaxOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "变形峰值外保护", strTmp);

            strTmp = checkBoxX12.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_ExtMaxOut_Effect = checkBoxX12.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "变形峰值外保护生效", strTmp);

            strTmp = textBoxX23.Text;
            MainForm.mainform.protectOption.ProtectOption_ExtMinOut = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "变形谷值外保护", strTmp);

            strTmp = checkBoxX10.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_ExtMinOut_Effect = checkBoxX10.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "变形谷值外保护生效", strTmp);

            strTmp = textBoxX24.Text;
            MainForm.mainform.protectOption.ProtectOption_ExtMaxIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "变形峰值内保护", strTmp);

            strTmp = checkBoxX11.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_ExtMaxIn_Effect = checkBoxX11.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "变形峰值内保护生效", strTmp);

            strTmp = textBoxX22.Text;
            MainForm.mainform.protectOption.ProtectOption_ExtMinIn = double.Parse(strTmp);
            IniFileHelper.WriteIniString(strConfigSetion, "变形谷值内保护", strTmp);

            strTmp = checkBoxX9.Checked == false ? "0" : "1";
            MainForm.mainform.protectOption.ProtectOption_ExtMinIn_Effect = checkBoxX9.Checked;
            IniFileHelper.WriteIniString(strConfigSetion, "变形谷值内保护生效", strTmp);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ValidityCheck()
        {
            //位移峰值外保护校验
            if (double.Parse(textBoxX17.Text) <= double.Parse(textBoxX16.Text))
            {
                MessageBox.Show("位移峰值外保护值不能小于等于位移峰值内保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                textBoxX17.Focus();
                return false;
            }

            //位移谷值内保护校验
            if (double.Parse(textBoxX15.Text) >= double.Parse(textBoxX14.Text))
            {
                MessageBox.Show("位移谷值内保护值不能小于等于位移谷值外保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                textBoxX15.Focus();
                return false;
            }

            //试验力峰值外保护校验
            if (double.Parse(textBoxX21.Text) <= double.Parse(textBoxX19.Text))
            {
                MessageBox.Show("试验力峰值外保护值不能小于试验力峰值内保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                textBoxX21.Focus();
                return false;
            }

            //试验力谷值外保护校验
            if (double.Parse(textBoxX20.Text) >= double.Parse(textBoxX18.Text))
            {
                MessageBox.Show("试验力谷值内保护值不能小于等于试验力谷值外保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                textBoxX20.Focus();
                return false;
            }

            //变形峰值谷值内保护校验
            if (double.Parse(textBoxX25.Text) <= double.Parse(textBoxX24.Text))
            {
                MessageBox.Show("变形峰值外保护值不能小于变形峰值内保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                textBoxX25.Focus();
                return false;
            }

            //变形峰值谷值内保护校验
            if (double.Parse(textBoxX23.Text) >= double.Parse(textBoxX22.Text))
            {
                MessageBox.Show("变形谷值内保护值不能小于变形谷值外保护值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                textBoxX23.Focus();
                return false;
            }

            return true;
        }

        private void cbk_Skin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse<eStyle>(this.cbk_Skin.Text, out var result))
            {
                this.styleManager1.ManagerStyle = result;
            }
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            string strConfigSetion = this.Name;


            //保存选择的皮肤
            strTmp = cbk_Skin.SelectedIndex.ToString();
            IniFileHelper.WriteIniString("Setting", "Theme", strTmp);
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            axTChart1.Axis.Bottom.Minimum -= Chart_X_Step;
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {

            double value = 0;
            value= axTChart1.Axis.Bottom.Minimum+Chart_X_Step;
            if (value <= axTChart1.Axis.Bottom.Maximum)
            {
                axTChart1.Axis.Bottom.Minimum = value;
            }
            else
            {
                MessageBox.Show("设定值超出x轴最大值范围!");
            }
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            double value = 0;
            value = axTChart1.Axis.Bottom.Maximum - Chart_X_Step;
            if (value >= axTChart1.Axis.Bottom.Minimum)
            {
                axTChart1.Axis.Bottom.Maximum = value;
            }
            else
            {
                MessageBox.Show("设定值超出x轴最小值范围!");
            }
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {
            axTChart1.Axis.Bottom.Maximum += Chart_X_Step;
        }

        private void buttonX21_Click(object sender, EventArgs e)
        {
            FormProgram tmpProgrammer = new FormProgram();
            tmpProgrammer.Show();
        }

        public void SetProgramDtas(string tableName, List<string[]> dtas) {
            //Console.WriteLine(tableName);
            comboBoxEx7.Text = tableName;
            //先清除目前显示的数据
            dataGridViewX1.Rows.Clear();
            for (int i = 0; i < dtas.Count; i++) {
                dataGridViewX1.Rows.Add(dtas[i]);
            }

        }

        public void RemoveDataGridView()
        {
            dataGridViewX1.AllowUserToAddRows = false;
            while (dataGridViewX1.RowCount > 0)
            {
                dataGridViewX1.Rows.RemoveAt(0);
            }
        }

        public void RefreshDbNameList()
        {
            AccessHelper tmpHelper = new AccessHelper();
            tmpHelper.InitProgramDb();
            string[] nameStrs = tmpHelper.GetTableNames();
            if (nameStrs!=null&&nameStrs.Length > 0)
            {
                comboBoxEx7.Items.Clear();
                comboBoxEx7.Items.AddRange(nameStrs);
            }
        }

        public void ClearProgramDataGridView(string programName)
        {
            //程序名称显示列表处理
            try
            {
                comboBoxEx7.Text = "";
                int index = comboBoxEx7.Items.IndexOf(programName);
                comboBoxEx7.Items.RemoveAt(index);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            //数据显示处理
            dataGridViewX1.Rows.Clear();
        }

        private void comboBoxEx7_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccessHelper tmpHelper = new AccessHelper();
            tmpHelper.InitProgramDb();
            List<string[]> tmpDtas = tmpHelper.GetDtas(comboBoxEx7.Text);
            if (tmpDtas.Count != 0)
            {
                while (dataGridViewX1.Rows.Count != 0)
                {   //清空当前gridview
                    dataGridViewX1.Rows.RemoveAt(dataGridViewX1.Rows.Count - 1);
                }

                for (int i = 0; i < tmpDtas.Count; i++) {
                    dataGridViewX1.Rows.Add(tmpDtas[i]);
                }
            }
        }

        private void buttonX24_Click(object sender, EventArgs e)
        {
            if (isRunning || !bActivated) {
                MessageBox.Show("有试验正在运行或者控制器未激活，请检查后再试！");
            }

            if (comboBoxEx7.Text != "")        //确定试验被选中
            {
                if(progControl==null)
                    progControl = new FormProgControl();

                List<string[]> tmpList = new List<string[]>();
                
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string[] tmpStrs = new string[5];
                    for (int j = 0; j < dataGridViewX1.Rows[i].Cells.Count; j++)
                    {
                        tmpStrs[j] = dataGridViewX1.Rows[i].Cells[j].Value.ToString();
                    }
                    tmpList.Add(tmpStrs);
                }
                progControl.SetCmdParmas(tmpList);
                progControl.StartRunProgram();
            }
        }
    }
}
