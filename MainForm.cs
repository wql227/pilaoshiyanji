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

namespace DoPENetConnect
{
    /// <summary>
    /// Demo-application for the DoPE .NET library.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Initialization


        public static MainForm mainform;

        /// <summary>
        /// Represents one EDC.
        /// This object is needed to perform DoPE tasks.
        /// (Similar to the DoPE-handle in C++.)
        /// </summary>
        private Edc MyEdc;

        /// <summary>
        /// 查询所有EDC
        /// </summary>
        public EdcList MyEdcList;

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
        /// 数据线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// Random value generator.
        /// </summary>
        private Random[] _rand;

        /// <summary>
        /// 是否暂停绘制
        /// </summary>
        private bool bPause = false;

        /// <summary>
        /// 是否正在运行
        /// </summary>
        private bool isRunning = false;

        private int nCount = 0;

        public Stopwatch stopwatch = new Stopwatch();


        readonly double[] Values = new double[25];
        readonly Stopwatch Stopwatch = Stopwatch.StartNew();

        decimal[] array_display1 = new decimal[150];         //波形显示数据1
        decimal[] array_display2 = new decimal[150];         //波形显示数据2
        decimal[] array_display3 = new decimal[150];         //波形显示数据3

        //位移
        decimal data_display1 ;

        //力反馈
        decimal data_display2 ;

        //拉伸
        decimal data_display3 ;
        decimal data_displayEnable = 0;


        double _pointsPerSec = 2000;    // Data rate for each channel
        int _channelCount = 0;          // Channel count.
        double _xLength = 0;            // X axis length.
        double _previousX = 0;          // Latest X value on axis.
        long _startTicks;               // Controls timing.
        double _pointsOutput;
        long _renderingTime;

        // Constants
        const double YMin = -20;       // Minimal y-value.
        const double YMax = 20;        // Maximal y-value.

        private volatile bool _stop;    // Stops thread work.
        private bool _bFormClosing = false;

        double[] _previousTemperature;

        /// <summary>
        /// 
        /// </summary>
        double x_Position = 0.0;
        double x_Load = 0.0;
        double x_Extension = 0.0;
        double x_Command = 0.0;

        /// <summary>
        /// Position 峰谷值
        /// </summary>
        float maxPos = 0.0F;
        float minPos = 0.0F;

        /// <summary>
        /// Load 峰谷值
        /// </summary>
        float maxLoad = 0.0F;
        float minLoad = 0.0F;

        /// <summary>
        /// Load 峰谷值
        /// </summary>
        float maxExt = 0.0F;
        float minExt = 0.0F;

        /// <summary>
        /// 记录试验次数
        /// </summary>
        int nTestCount = 0;

        double nAxisStep = 0;


        /// <summary>
        /// Boolean for random data
        /// </summary>
        public bool randomdata = false;

        //Stopwatch for controlling the timing 
        Stopwatch _stopWatch;

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


        #region 获取峰谷值的配置值

        /// <summary>
        /// 位移峰值外保护
        /// </summary>
        public double ProtectOption_PosMaxOut = 0.0;

        /// <summary>
        /// 启用位移峰值外保护
        /// </summary>
        public bool ProtectOption_PosMaxOut_Effect = false;


        /// <summary>
        /// 位移谷值外保护
        /// </summary>
        public double ProtectOption_PosMinOut = 0.0;

        /// <summary>
        /// 启用位移谷值外保护
        /// </summary>
        public bool ProtectOption_PosMinOut_Effect = false;

        /// <summary>
        /// 位移峰值内保护
        /// </summary>
        public double ProtectOption_PosMaxIn = 0.0;

        /// <summary>
        /// 启用位移峰值内保护
        /// </summary>
        public bool ProtectOption_PosMaxIn_Effect = false;

        /// <summary>
        /// 位移谷值内保护
        /// </summary>
        public double ProtectOption_PosMinIn = 0.0;

        /// <summary>
        /// 启用位移谷值内保护
        /// </summary>
        public bool ProtectOption_PosMinIn_Effect = false;

        #endregion 

        ///----------------------------------------------------------------------
        /// <summary>Constructor</summary>
        ///----------------------------------------------------------------------
        public MainForm()
        {
            // Initialize graphical-user-interface.
            InitializeComponent();

            LoadIni();

            _stop = false;
            _thread = null;
            _stopWatch = new Stopwatch();
            _stopWatch.Start();

            bPause = false;
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

            //传递当前实例
            mainform = this;

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
                MyEdcList = new EdcList(32);
                MyEdc = MyEdcList[0];
                //MyEdc = new Edc(DoPE.OpenBy.DeviceId, 0);
                //MyEdc = new Edc(DoPE.OpenBy.FunctionId, 0);
                if (MyEdc != null)
                {
                    Display("连接成功，Name:" + MyEdc.ModuleInfo.Name + "; DeviceId = " + MyEdc.ModuleInfo.DeviceID + "; FunctionId = " + MyEdc.ModuleInfo.DeviceID + "; SerNr = " + MyEdc.ModuleInfo.SerNr + "\n");

                    LogHelper.WriteLogFile("AAAA");
                    lbX_EDCName.Text = MyEdc.ModuleInfo.Name;
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
                double aaa = (0.030 / Machine.MDef.SystemTime + Machine.MDef.SystemTime / 2);
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
                StartCommunicationWithEdcTimer.Start();
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
                StartCommunicationWithEdcTimer.Stop();
                DisplayError(error, "Off");

                btnX_SetLow.Checked = false;
                btnX_SetHigh.Checked = false;

                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                }
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
            }
            else if (LineState == DoPE.LineState.ONLINE)
            {
                btn_ConState.BackColor = Color.Lime;
                btn_ConState.Text = "ONLINE";
            }
            else if (LineState == DoPE.LineState.RESTART)
            {
                btn_ConState.BackColor = Color.Yellow;
                btn_ConState.Text = "RESTART";
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

                //Sample.CtrlState1.

                text = String.Format("{0}", Sample.Time.ToString("0.000"));
                //if (nCount >= 20)
                //{
                //    guiTime.Text = text;
                //}

                strCSVLog += text + ",";
                text = String.Format("{0}", Sample.Sensor[(int)DoPE.SENSOR.SENSOR_S].ToString("0.000"));

                //位移队列
                PVPositionQueue.Enqueue(Sample.Sensor[(int)DoPE.SENSOR.SENSOR_S]);
                if (PVPositionQueue.Count >= 50)
                {
                    tb_MaxPos.Text = PVPositionQueue.Max().ToString("0.000");
                    tb_MinPos.Text = PVPositionQueue.Min().ToString("0.000");

                    //判断是否处于正常峰值区间
                    if (ProtectOption_PosMaxOut_Effect)
                    {
                        if ( PVPositionQueue.Max() > ProtectOption_PosMaxOut )
                        {
                            MessageBox.Show("峰值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            OffEDC();
                        }
                    }

                    if (ProtectOption_PosMaxIn_Effect)
                    {
                        if (PVPositionQueue.Max() < ProtectOption_PosMaxIn )
                        {
                            MessageBox.Show("峰值超过内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            OffEDC();
                        }
                    }

                    //判断是否处于正常谷值区间
                    if (ProtectOption_PosMinOut_Effect)
                    {
                        if (PVPositionQueue.Min() < ProtectOption_PosMinOut)
                        {
                            MessageBox.Show("谷值超过外保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            OffEDC();
                        }
                    }

                    if (ProtectOption_PosMinIn_Effect)
                    {
                        if (PVPositionQueue.Min() > ProtectOption_PosMinIn )
                        {
                            MessageBox.Show("谷值超过内保护限制", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            OffEDC();
                        }
                    }

                    PVPositionQueue.Clear();
                }

                // TODO:判断峰谷值是否超过外保护
                double dPosition = 0; //获取峰值外保护
                //if (Sample.Sensor[(int)DoPE.SENSOR.SENSOR_S] > 7.0 )
                //{
                //    //DoPE.ERR error = MyEdc.Move.Halt(DoPE.CTRL.POS, ref MyTan);
                //    OffEDC();
                //}

                if (nCount >= 20)
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

                    PVLoadQueue.Clear();
                }

                //if (Sample.Sensor[(int)DoPE.SENSOR.SENSOR_F] > 3.0)
                {
                    //DoPE.ERR error = MyEdc.Move.Halt(DoPE.CTRL.POS, ref MyTan);
                    //OffEDC();
                }
                //ProtectOption_PosMaxOut

                if (nCount >= 20)
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
                    tb_MaxExt.Text = PVExtensionQueue.Min().ToString("0.000");
                    PVExtensionQueue.Clear();
                }

                //if (Sample.Sensor[(int)DoPE.SENSOR.SENSOR_E] > 7.0)
                //{
                //    //DoPE.ERR error = MyEdc.Move.Halt(DoPE.CTRL.POS, ref MyTan);
                //    OffEDC();
                //}

                if (nCount >= 20)
                {
                    guiExtension.Text = text;
                }

                strCSVLog += text + ",";
                //data_display3 = decimal.Parse(guiExtension.Text);

                text = String.Format("{0}", Sample.Sensor[(int)DoPE.OUT.COMMAND].ToString("0.000"));
                strCSVLog += text + ",";

                if (nCount >= 20)
                {
                    nCount = 0;
                }

                //if ((Sample.Cycles) % 2 == 0)
                {
                    strCSVLog += (Sample.Cycles << 1).ToString() + ",";
                    tbX_TestCycles.Text = (Sample.Cycles >> 1).ToString();
                }

                LogHelper.SaveCsvData(strCSVLog);

                //tb_MaxPos.Text =  FindPeaks(Sample.Sensor[(int)DoPE.SENSOR.SENSOR_S]);

                //波形图
                if (bConnected && bActivated)
                {
                    ShowWave(Block);
                }

                //for (int pointIndex = 0; pointIndex < pointPacksToGenerate; pointIndex++)
                //{
                //    multiChannelData[channelIndex][pointIndex].X = _pointsOutput + pointIndex; //Use index as X value for the data point
                //    multiChannelData[channelIndex][pointIndex].Y = Decimal.ToDouble(data_display1); // generating y value (using random in this point is way too heavy with multiple channels
                //                                                                                    //multiChannelData[channelIndex][pointIndex].Y = Math.Sin((double)(_pointsOutput + pointIndex) / 150.0) * 50; // generating y value (using random in this point is way too heavy with multiple channels
                //}


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
        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 保存数据问题及ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            // formsPlot1.XLabel("这是X轴的描述");

            //formsPlot1.Plot.Axes.SetLimitsY(0, 10);

            //formsPlot1.Plot.A

            // superTabControl1.SelectedTabIndex = 1;

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            timer_UpdateData.Interval = 300;
            timer_UpdateData.Start();

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
        }


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


        /// <summary>
        /// 断开EDC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_Disconnect_Click(object sender, EventArgs e)
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
            if (bConnected)
            {
                double speed;

                try
                {
                    speed = Convert.ToDouble("30") * 10;

                    DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 2, ref MyTan);
                    DisplayError(error, "FDPoti");
                }
                catch (NullReferenceException)
                {
                    Display(CommandFailedString);
                }
            }
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
            if (bConnected)
            {
                double speed;

                try
                {
                    speed = Convert.ToDouble(300);

                    //DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_UP, 20, ref MyTan);
                    //DisplayError(error, "FDPoti");
                    DoPE.ERR error = MyEdc.Move.FMove_A(DoPE.MOVE.UP, DoPE.CTRL.POS, 300, speed, ref MyTan);
                    DisplayError(error, "FMove_A");
                }
                catch (NullReferenceException)
                {
                    Display(CommandFailedString);
                }
            }
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
            if (bConnected)
            {
                try
                {
                    DoPE.ERR error = MyEdc.Move.Halt(DoPE.CTRL.POS, ref MyTan);
                    DisplayError(error, "Halt");
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
            if (bConnected)
            {
                double speed;

                try
                {
                    speed = Convert.ToDouble("30");

                    DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref MyTan);
                    DisplayError(error, "FDPoti");
                }
                catch (NullReferenceException)
                {
                    Display(CommandFailedString);
                }
            }
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
            if (bConnected)
            {
                double speed;

                try
                {
                    speed = Convert.ToDouble(3000);

                    //DoPE.ERR error = MyEdc.Move.FDPoti(DoPE.CTRL.POS, speed, DoPE.SENSOR.SENSOR_DP, 3, DoPE.EXT.SPEED_DOWN, 2, ref MyTan);
                    //DisplayError(error, "FDPoti");

                    DoPE.ERR error = MyEdc.Move.FMove_A(DoPE.MOVE.DOWN, DoPE.CTRL.POS, 300, speed, ref MyTan);
                    DisplayError(error, "FMove_A");
                }
                catch (NullReferenceException)
                {
                    Display(CommandFailedString);
                }
            }
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
                //位移
                //chart_machine.Series[0].Points.Clear();
                //x_Position = 0.0;
                //chart_machine.Series[0].Points.AddXY(0.0, 0.0);

                ////试验力
                //chart_machine.Series[1].Points.Clear();
                //x_Load = 0.0;
                //chart_machine.Series[1].Points.AddXY(0.0, 0.0);

                GetXaxisScale();

                btnX_SetLow.Checked = true;
                btnX_SetHigh.Checked = false;
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


        /// <summary>
        /// IO高压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_SetHigh_Click(object sender, EventArgs e)
        {
            DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureSet(true);
            //DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureEnable(true);

            if (Err == DoPE.ERR.NOERROR)
            {
                btnX_SetLow.Checked = false;
                btnX_SetHigh.Checked = true;
            }
        }


        /// <summary>
        /// IO低压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_SetLow_Click(object sender, EventArgs e)
        {
            DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureSet(false);
            //DoPE.ERR Err = MyEdc.IoSignal.IOHighPressureEnable(false);

            if (Err == DoPE.ERR.NOERROR)
            {
                btnX_SetHigh.Checked = false;
                btnX_SetLow.Checked = true;
            }
        }

        #endregion 




        /// <summary>
        /// 示波
        /// </summary>
        /// <param name="Block"></param>
        private async void ShowWave(DoPE.OnDataBlock Block)
        {
            try
            {
                //if (MyEdc.IsConnected() && bConnected)
                if (chart_machine != null)
                {
                    if (!bPause)
                    {
                        for (int i = 50; Block.Data.Length > i; i += 100)
                        //for (int i = 20; Block.Data.Length > i; i += 100)
                        {

                            //绘制Position
                            double y_Position = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_S];
                            //x_Position += nAxisStep;
                            x_Position += 0.03;

                            if (chart_machine.Series != null)
                            {
                                if (chart_machine.Series[0] != null)
                                {
                                    chart_machine.Series[0].Points.AddXY(x_Position, y_Position);
                                    if (chart_machine.Series[0].Points.Count - 1 == 333)
                                    {
                                        //chart1.Series[0].Points.AddXY(10.0, y);
                                        chart_machine.Series[0].Points.Clear();
                                        // 异步更新图表数据
                                        //await chart1.InvokeAsync(() =>
                                        //{
                                        //    chartControl.Series[0].Points.AddXY(.0, y);
                                        //});

                                        chart_machine.Series[0].Points.AddXY(0.0, y_Position);
                                        x_Position = 0.0;
                                    }
                                    /*if (x >= 10.0)
                                    {
                                        x = 0.0;
                                        chart1.Series[0].Points.Clear();
                                        chart1.Series[0].Points.AddXY(-1.0, y);
                                    }*/
                                }
                            }

                            //绘制Load
                            double y_Load = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_F];
                            //x_Load += nAxisStep;
                            x_Load += 0.03;

                            if (chart_machine.Series[1] != null)
                            {
                                chart_machine.Series[1].Points.AddXY(x_Load, y_Load);
                                if (chart_machine.Series[1].Points.Count - 1 == 333)
                                {
                                    //chart1.Series[0].Points.AddXY(10.0, y);
                                    chart_machine.Series[1].Points.Clear();

                                    chart_machine.Series[1].Points.AddXY(0.0, y_Load);
                                    x_Load = 0.0;
                                }
                                /*if (x >= 10.0)
                                {
                                    x = 0.0;
                                    chart1.Series[0].Points.Clear();
                                    chart1.Series[0].Points.AddXY(-1.0, y);
                                }*/
                            }

                            //绘制Extension
                            double y_Extension = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_E];
                            //x_Load += nAxisStep;
                            x_Extension += 0.03;

                            if (chart_machine.Series[2] != null)
                            {
                                chart_machine.Series[2].Points.AddXY(x_Extension, y_Extension);
                                if (chart_machine.Series[2].Points.Count - 1 == 333)
                                {
                                    //chart1.Series[0].Points.AddXY(10.0, y);
                                    chart_machine.Series[2].Points.Clear();

                                    chart_machine.Series[2].Points.AddXY(0.0, y_Extension);
                                    x_Extension = 0.0;
                                }
                                /*if (x >= 10.0)
                                {
                                    x = 0.0;
                                    chart1.Series[0].Points.Clear();
                                    chart1.Series[0].Points.AddXY(-1.0, y);
                                }*/
                            }

                            //绘制Command
                            //double y_Command = Block.Data[i].Data.Sensor[(int)DoPE.SENSOR.SENSOR_DP];
                            double y_Command = Block.Data[i].Data.Command;
                            //x_Load += nAxisStep;
                            x_Command += 0.03;

                            var Axis = chart_machine.ChartAreas[0].AxisX;
                            // 获取X轴的最小值和最大值
                            double minValue = Axis.Minimum;
                            double maxValue = Axis.Maximum;
                            if (chart_machine.Series[3] != null)
                            {
                                chart_machine.Series[3].Points.AddXY(x_Command, y_Command);
                                if (chart_machine.Series[3].Points.Count - 1 == 333)
                                {
                                    //chart1.Series[0].Points.AddXY(10.0, y);
                                    chart_machine.Series[3].Points.Clear();

                                    chart_machine.Series[3].Points.AddXY(0.0, y_Command);
                                    x_Command = 0.0;
                                }
                                /*if (x >= 10.0)
                                {
                                    x = 0.0;
                                    chart1.Series[0].Points.Clear();
                                    chart1.Series[0].Points.AddXY(-1.0, y);
                                }*/
                            }
                        }


                        //计算Position 峰谷值
                        //if (double.Parse(guiPosition.Text) > double.Parse(guiPosition.Text) * 0.9 )
                        //{
                        //    tb_MaxPos.Text = guiPosition.Text.ToString();
                        //}

                        //if (double.Parse(guiPosition.Text) < double.Parse(guiPosition.Text) * 0.1)
                        //{
                        //    tb_MinPos.Text = guiPosition.Text.ToString();
                        //}


                        //if (maxPos < float.Parse(guiPosition.Text))
                        //{
                        //    maxPos = float.Parse(guiPosition.Text);
                        //    tb_MaxPos.Text = maxPos.ToString();
                        //}

                        //if (minPos > float.Parse(guiPosition.Text))
                        //{
                        //    minPos = float.Parse(guiPosition.Text);
                        //    tb_MinPos.Text = minPos.ToString();
                        //}

                        ////计算Load 峰谷值
                        //if (maxLoad < float.Parse(guiLoad.Text))
                        //{
                        //    maxLoad = float.Parse(guiLoad.Text);
                        //    tb_MaxLoad.Text = maxLoad.ToString();
                        //}

                        //if (minLoad > float.Parse(guiLoad.Text))
                        //{
                        //    minLoad = float.Parse(guiLoad.Text);
                        //    tb_MinLoad.Text = minLoad.ToString();
                        //}

                        ////计算Extension 峰谷值
                        //if (maxExt < float.Parse(guiExtension.Text))
                        //{
                        //    maxExt = float.Parse(guiExtension.Text);
                        //    tb_MaxLoad.Text = maxExt.ToString();
                        //}

                        //if (minExt > float.Parse(guiExtension.Text))
                        //{
                        //    minExt = float.Parse(guiExtension.Text);
                        //    tb_MinExt.Text = minExt.ToString();
                        //}

                        //nTestCount++;

                        //if (nTestCount > 0)
                        //{

                        //}
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }


            //max_label.Text = max.ToString();
            //min_label.Text = min.ToString();

        }





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

                EnableButton();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bConnected)
            {
                OffEDC();
            }
        }


        private void timer_UpdateData_Tick(object sender, EventArgs e)
        {
            if (!bConnected)
            {
                return;
            }

            TimeSpan elapsed = stopwatch.Elapsed;
            guiTime.Text = string.Format(@"{0:D2}:{1:D2}:{2:D2}", (int)elapsed.TotalHours, elapsed.Minutes, elapsed.Seconds);

            EnableButton();
        }


        /// <summary>
        /// Calculate Y value for random data
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private double CalculateYValue(int i)
        {
            // Use the latest value and generate some difference to it.
            double nextY = (_previousTemperature[i] + (_rand[i].NextDouble() - 0.5)) / 1000 /** 8*/;

            // Limit the value between 100...
            if (nextY > 50)
            {
                nextY = 50;
            }

            // ... and 0.
            if (nextY < -50)
            {
                nextY = -50;
            }

            // Update the latest values.
            _previousTemperature[i] = nextY;

            return nextY;
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


        public void MoveDynCycles(DoPE.DYN_WAVEFORM WaveForm, bool Modify, DoPE.DYN_PEAKCTRL PeakCtrl, DoPE.CTRL MoveCtrl, 
            bool RelativeDestination, double SpeedToStart, double Offset, double Amplitude, double HaltAtPlusAmplitude, double HaltAtMinusAmplitude, 
            double Frequency, int HalfCycles, double SpeedToDestination, double Destination, DoPE.DYN_SWEEP SweepFrequencyMode)
        {
            DoPE.ERR error = MyEdc.Move.DynCycles(WaveForm, Modify, PeakCtrl, MoveCtrl, false, SpeedToStart, Offset, Amplitude, 0.0, 
                0.0, Frequency, HalfCycles, SpeedToDestination, Destination, SweepFrequencyMode, 
                0.0, 0.0, 0, 0, 0.0, 0.0, 0, 0, 0.0, 0.0, 0, 0, 0.0, 0.0, 0, 0, 0.0, 0.0, 0.0, ref MyTan);

            //正常返回，开始计时
            if (error == DoPE.ERR.NOERROR)
            {
                stopwatch.Start();
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
                startStopDrawToolStripMenuItem.Text = "启动绘制";
            }
            else
            {
                startStopDrawToolStripMenuItem.Text = "暂停绘制";
            }

            chart_machine.Enabled = false;
        }


        # endregion 快捷工具栏消息响应事件



        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void cb_TarePos_CheckedChanged(object sender, EventArgs e)
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

        private void cb_TareLoad_CheckedChanged(object sender, EventArgs e)
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

        private void cb_TareExt_CheckedChanged(object sender, EventArgs e)
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

        private void btnX_AxisYMax_Click(object sender, EventArgs e)
        {
            chart_machine.ChartAreas[0].AxisY.Maximum += 5;
            chart_machine.ChartAreas[0].AxisY.Minimum += 5;
        }

        private void btnX_AsixYMin_Click(object sender, EventArgs e)
        {
            chart_machine.ChartAreas[0].AxisY.Maximum -= 5;
            chart_machine.ChartAreas[0].AxisY.Minimum -= 5;

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
        }

        private void cb_DrawCommand_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DrawCommand.Checked)
            {
                chart_machine.Series[3].Enabled = true;
            }
            else
            {
                chart_machine.Series[3].Enabled = false;
            }
        }

        //运行时才能决定是否执行内联
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public ushort setUInt16(float src, ushort k = 1)
        {
            return (ushort)(src * k);
        }

        private void 系统保护选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProtectOption frmProtectOption = new FrmProtectOption();
            frmProtectOption.ShowDialog();
        }


        /// <summary>
        /// 加载配置文件
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            string strConfigSetion = this.Name;
            IniFileHelper.GetIniString("FrmProtectOption", "位移峰值外保护", "0", strTmp, strTmp.Capacity);
            ProtectOption_PosMaxOut = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmProtectOption", "位移峰值外保护生效", "0", strTmp, strTmp.Capacity);
            ProtectOption_PosMaxOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmProtectOption", "位移谷值外保护", "0", strTmp, strTmp.Capacity);
            ProtectOption_PosMinOut = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmProtectOption", "位移谷值外保护生效", "0", strTmp, strTmp.Capacity);
            ProtectOption_PosMinOut_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmProtectOption", "位移峰值内保护", "0", strTmp, strTmp.Capacity);
            ProtectOption_PosMaxIn = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmProtectOption", "位移峰值内保护生效", "0", strTmp, strTmp.Capacity);
            ProtectOption_PosMaxIn_Effect = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString("FrmProtectOption", "位移谷值内保护", "0", strTmp, strTmp.Capacity);
            ProtectOption_PosMinIn = double.Parse(strTmp.ToString());

            IniFileHelper.GetIniString("FrmProtectOption", "位移谷值内保护生效", "0", strTmp, strTmp.Capacity);
            ProtectOption_PosMinIn_Effect = strTmp.ToString() == "0" ? false : true;
        }
    }
}
