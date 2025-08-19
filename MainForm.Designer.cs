namespace DoPENetConnect
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StartCommunicationWithEdcTimer = new System.Windows.Forms.Timer(this.components);
            this.试验数据 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelEx10 = new DevComponents.DotNetBar.PanelEx();
            this.tbX_TestCount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.cb_DrawPosition = new System.Windows.Forms.CheckBox();
            this.cb_DrawCommand = new System.Windows.Forms.CheckBox();
            this.cb_DrawExtension = new System.Windows.Forms.CheckBox();
            this.cb_DrawLoad = new System.Windows.Forms.CheckBox();
            this.btnX_AxisPOSY_MaxUp = new DevComponents.DotNetBar.ButtonX();
            this.btnX_AxisLoadY_MaxUp = new DevComponents.DotNetBar.ButtonX();
            this.btnX_AxisPOSY_MaxDown = new DevComponents.DotNetBar.ButtonX();
            this.btnX_AxisLoadY_MinUp = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnX_AxisLoadY_MaxDown = new DevComponents.DotNetBar.ButtonX();
            this.btnX_AsixYMin = new DevComponents.DotNetBar.ButtonX();
            this.btnX_AxisLoadY_MinDown = new DevComponents.DotNetBar.ButtonX();
            this.btnX_AxisYMax = new DevComponents.DotNetBar.ButtonX();
            this.chart_machine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnX_Connect = new DevComponents.DotNetBar.ButtonX();
            this.btnX_Disconnect = new DevComponents.DotNetBar.ButtonX();
            this.bntX_MoveUp = new DevComponents.DotNetBar.ButtonX();
            this.btnX_MoveQuickUp = new DevComponents.DotNetBar.ButtonX();
            this.bntX_MoveHalt = new DevComponents.DotNetBar.ButtonX();
            this.bntX_MoveDown = new DevComponents.DotNetBar.ButtonX();
            this.btnX_QuickMoveDown = new DevComponents.DotNetBar.ButtonX();
            this.btn_ConState = new System.Windows.Forms.Button();
            this.bntX_GUIOn = new DevComponents.DotNetBar.ButtonX();
            this.btnX_SetLow = new DevComponents.DotNetBar.ButtonX();
            this.bntX_GUIOff = new DevComponents.DotNetBar.ButtonX();
            this.btnX_SetHigh = new DevComponents.DotNetBar.ButtonX();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbX_EDCName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_SystemTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posExtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posExtAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fMoveaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynCyclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPeakCtrlValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPeakCtrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ext2CtrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sHaltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.pcCmdFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.setOpenLoopCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haltWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haltWAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trigAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xpCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.synchronizeMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pos_AtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dynCtrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStopDrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdjustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChartSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSetYAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiSensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveStaticDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pl_DataShow = new System.Windows.Forms.Panel();
            this.labelX33 = new DevComponents.DotNetBar.LabelX();
            this.cb_TareTime = new System.Windows.Forms.CheckBox();
            this.cb_TareExt = new System.Windows.Forms.CheckBox();
            this.cb_TareLoad = new System.Windows.Forms.CheckBox();
            this.cb_TarePos = new System.Windows.Forms.CheckBox();
            this.lblExtensionMinValue = new System.Windows.Forms.Label();
            this.lblLoadMinValue = new System.Windows.Forms.Label();
            this.lblPositionMinValue = new System.Windows.Forms.Label();
            this.lblExtensionMaxValue = new System.Windows.Forms.Label();
            this.lblLoadMaxValue = new System.Windows.Forms.Label();
            this.lblTestCycles = new System.Windows.Forms.Label();
            this.lblExtensionMaxMin = new System.Windows.Forms.Label();
            this.lblLoadMaxMin = new System.Windows.Forms.Label();
            this.lblPositionMaxValue = new System.Windows.Forms.Label();
            this.lblPositionMaxMin = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tb_MinExt = new System.Windows.Forms.TextBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.tb_MinLoad = new System.Windows.Forms.TextBox();
            this.tb_MaxExt = new System.Windows.Forms.TextBox();
            this.lblLoad = new System.Windows.Forms.Label();
            this.tb_MaxLoad = new System.Windows.Forms.TextBox();
            this.tb_MinPos = new System.Windows.Forms.TextBox();
            this.tb_MaxPos = new System.Windows.Forms.TextBox();
            this.guiPosition = new System.Windows.Forms.TextBox();
            this.tbX_TestCycles = new System.Windows.Forms.TextBox();
            this.guiExtension = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.guiTime = new System.Windows.Forms.TextBox();
            this.guiLoad = new System.Windows.Forms.TextBox();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel7 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx9 = new DevComponents.DotNetBar.PanelEx();
            this.guiDebug = new System.Windows.Forms.RichTextBox();
            this.superTabItem7 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx7 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX23 = new DevComponents.DotNetBar.LabelX();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX10 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX8 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX9 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX7 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx6 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx5 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superTabControl2 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX14 = new DevComponents.DotNetBar.ButtonX();
            this.superTabControl3 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx8 = new DevComponents.DotNetBar.PanelEx();
            this.labelX30 = new DevComponents.DotNetBar.LabelX();
            this.labelX32 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX12 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX31 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX13 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX29 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem6 = new DevComponents.DotNetBar.SuperTabItem();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX17 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX20 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX23 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX13 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX12 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX8 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX11 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX10 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.slider1 = new DevComponents.DotNetBar.Controls.Slider();
            this.labelX28 = new DevComponents.DotNetBar.LabelX();
            this.labelX27 = new DevComponents.DotNetBar.LabelX();
            this.labelX26 = new DevComponents.DotNetBar.LabelX();
            this.labelX25 = new DevComponents.DotNetBar.LabelX();
            this.labelX24 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX11 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.superTabItem5 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Oper = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.试验数据回访ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SystemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_OpenLogsDir = new System.Windows.Forms.ToolStripMenuItem();
            this.保存数据问题及ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.保存当前曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Result = new System.Windows.Forms.ToolStripMenuItem();
            this.拷贝当前曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印当前曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Language = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_OpenLangDir = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Adout = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.timer_UpdateData = new System.Windows.Forms.Timer(this.components);
            this.timer_ShowWave = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelEx10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_machine)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.pl_DataShow.SuspendLayout();
            this.superTabControlPanel7.SuspendLayout();
            this.panelEx9.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx6.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).BeginInit();
            this.superTabControl2.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl3)).BeginInit();
            this.superTabControl3.SuspendLayout();
            this.superTabControlPanel6.SuspendLayout();
            this.panelEx8.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartCommunicationWithEdcTimer
            // 
            this.StartCommunicationWithEdcTimer.Tick += new System.EventHandler(this.StartCommunicationWithEdcTimer_Tick);
            // 
            // 试验数据
            // 
            this.试验数据.GlobalItem = false;
            this.试验数据.Name = "试验数据";
            this.试验数据.Text = "superTabItem1";
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Controls.Add(this.superTabControlPanel7);
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.menuStrip1);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = -1;
            this.superTabControl1.Size = new System.Drawing.Size(1418, 759);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 57;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2,
            this.superTabItem1,
            this.superTabItem7});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.panelEx1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 52);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1418, 707);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panel2);
            this.panelEx1.Controls.Add(this.pl_DataShow);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1418, 707);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1418, 625);
            this.panel2.TabIndex = 57;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panelEx10);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.menuStrip2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1418, 625);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // panelEx10
            // 
            this.panelEx10.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx10.Controls.Add(this.tbX_TestCount);
            this.panelEx10.Controls.Add(this.line2);
            this.panelEx10.Controls.Add(this.line1);
            this.panelEx10.Controls.Add(this.cb_DrawPosition);
            this.panelEx10.Controls.Add(this.cb_DrawCommand);
            this.panelEx10.Controls.Add(this.cb_DrawExtension);
            this.panelEx10.Controls.Add(this.cb_DrawLoad);
            this.panelEx10.Controls.Add(this.btnX_AxisPOSY_MaxUp);
            this.panelEx10.Controls.Add(this.btnX_AxisLoadY_MaxUp);
            this.panelEx10.Controls.Add(this.btnX_AxisPOSY_MaxDown);
            this.panelEx10.Controls.Add(this.btnX_AxisLoadY_MinUp);
            this.panelEx10.Controls.Add(this.label2);
            this.panelEx10.Controls.Add(this.label1);
            this.panelEx10.Controls.Add(this.btnX_AxisLoadY_MaxDown);
            this.panelEx10.Controls.Add(this.btnX_AsixYMin);
            this.panelEx10.Controls.Add(this.btnX_AxisLoadY_MinDown);
            this.panelEx10.Controls.Add(this.btnX_AxisYMax);
            this.panelEx10.Controls.Add(this.chart_machine);
            this.panelEx10.Controls.Add(this.btnX_Connect);
            this.panelEx10.Controls.Add(this.btnX_Disconnect);
            this.panelEx10.Controls.Add(this.bntX_MoveUp);
            this.panelEx10.Controls.Add(this.btnX_MoveQuickUp);
            this.panelEx10.Controls.Add(this.bntX_MoveHalt);
            this.panelEx10.Controls.Add(this.bntX_MoveDown);
            this.panelEx10.Controls.Add(this.btnX_QuickMoveDown);
            this.panelEx10.Controls.Add(this.btn_ConState);
            this.panelEx10.Controls.Add(this.bntX_GUIOn);
            this.panelEx10.Controls.Add(this.btnX_SetLow);
            this.panelEx10.Controls.Add(this.bntX_GUIOff);
            this.panelEx10.Controls.Add(this.btnX_SetHigh);
            this.panelEx10.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx10.Location = new System.Drawing.Point(3, 42);
            this.panelEx10.Name = "panelEx10";
            this.panelEx10.Size = new System.Drawing.Size(1412, 554);
            this.panelEx10.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx10.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx10.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx10.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx10.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx10.Style.GradientAngle = 90;
            this.panelEx10.TabIndex = 67;
            // 
            // tbX_TestCount
            // 
            this.tbX_TestCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbX_TestCount.Border.Class = "TextBoxBorder";
            this.tbX_TestCount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbX_TestCount.Location = new System.Drawing.Point(1239, 424);
            this.tbX_TestCount.Name = "tbX_TestCount";
            this.tbX_TestCount.PreventEnterBeep = true;
            this.tbX_TestCount.ReadOnly = true;
            this.tbX_TestCount.Size = new System.Drawing.Size(90, 21);
            this.tbX_TestCount.TabIndex = 68;
            // 
            // line2
            // 
            this.line2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line2.ForeColor = System.Drawing.Color.Red;
            this.line2.Location = new System.Drawing.Point(0, -1);
            this.line2.Name = "line2";
            this.line2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.line2.Size = new System.Drawing.Size(1412, 4);
            this.line2.TabIndex = 67;
            this.line2.Text = "line2";
            this.line2.Thickness = 4;
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(1239, 451);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(120, 10);
            this.line1.TabIndex = 66;
            this.line1.Text = "line1";
            // 
            // cb_DrawPosition
            // 
            this.cb_DrawPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_DrawPosition.BackColor = System.Drawing.Color.White;
            this.cb_DrawPosition.Checked = true;
            this.cb_DrawPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_DrawPosition.Location = new System.Drawing.Point(1096, 104);
            this.cb_DrawPosition.Name = "cb_DrawPosition";
            this.cb_DrawPosition.Size = new System.Drawing.Size(100, 16);
            this.cb_DrawPosition.TabIndex = 65;
            this.cb_DrawPosition.Text = "位移";
            this.cb_DrawPosition.UseVisualStyleBackColor = false;
            this.cb_DrawPosition.CheckedChanged += new System.EventHandler(this.cb_DrawPosition_CheckedChanged);
            // 
            // cb_DrawCommand
            // 
            this.cb_DrawCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_DrawCommand.BackColor = System.Drawing.Color.White;
            this.cb_DrawCommand.Checked = true;
            this.cb_DrawCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_DrawCommand.Location = new System.Drawing.Point(1096, 171);
            this.cb_DrawCommand.Name = "cb_DrawCommand";
            this.cb_DrawCommand.Size = new System.Drawing.Size(100, 16);
            this.cb_DrawCommand.TabIndex = 65;
            this.cb_DrawCommand.Text = "命令";
            this.cb_DrawCommand.UseVisualStyleBackColor = false;
            this.cb_DrawCommand.CheckedChanged += new System.EventHandler(this.cb_DrawCommand_CheckedChanged);
            // 
            // cb_DrawExtension
            // 
            this.cb_DrawExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_DrawExtension.BackColor = System.Drawing.Color.White;
            this.cb_DrawExtension.Checked = true;
            this.cb_DrawExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_DrawExtension.Location = new System.Drawing.Point(1096, 149);
            this.cb_DrawExtension.Name = "cb_DrawExtension";
            this.cb_DrawExtension.Size = new System.Drawing.Size(100, 16);
            this.cb_DrawExtension.TabIndex = 65;
            this.cb_DrawExtension.Text = "变形";
            this.cb_DrawExtension.UseVisualStyleBackColor = false;
            this.cb_DrawExtension.CheckedChanged += new System.EventHandler(this.cb_DrawExtension_CheckedChanged);
            // 
            // cb_DrawLoad
            // 
            this.cb_DrawLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_DrawLoad.BackColor = System.Drawing.Color.White;
            this.cb_DrawLoad.Checked = true;
            this.cb_DrawLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_DrawLoad.Location = new System.Drawing.Point(1096, 127);
            this.cb_DrawLoad.Name = "cb_DrawLoad";
            this.cb_DrawLoad.Size = new System.Drawing.Size(100, 16);
            this.cb_DrawLoad.TabIndex = 65;
            this.cb_DrawLoad.Text = "试验力";
            this.cb_DrawLoad.UseVisualStyleBackColor = false;
            this.cb_DrawLoad.CheckedChanged += new System.EventHandler(this.cb_DrawLoad_CheckedChanged);
            // 
            // btnX_AxisPOSY_MaxUp
            // 
            this.btnX_AxisPOSY_MaxUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_AxisPOSY_MaxUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_AxisPOSY_MaxUp.Location = new System.Drawing.Point(91, 24);
            this.btnX_AxisPOSY_MaxUp.Name = "btnX_AxisPOSY_MaxUp";
            this.btnX_AxisPOSY_MaxUp.Size = new System.Drawing.Size(25, 25);
            this.btnX_AxisPOSY_MaxUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_AxisPOSY_MaxUp.TabIndex = 64;
            this.btnX_AxisPOSY_MaxUp.Text = "▲";
            this.btnX_AxisPOSY_MaxUp.Click += new System.EventHandler(this.btnX_AxisPOSY_MaxUp_Click);
            // 
            // btnX_AxisLoadY_MaxUp
            // 
            this.btnX_AxisLoadY_MaxUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_AxisLoadY_MaxUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_AxisLoadY_MaxUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_AxisLoadY_MaxUp.Location = new System.Drawing.Point(992, 24);
            this.btnX_AxisLoadY_MaxUp.Name = "btnX_AxisLoadY_MaxUp";
            this.btnX_AxisLoadY_MaxUp.Size = new System.Drawing.Size(25, 25);
            this.btnX_AxisLoadY_MaxUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_AxisLoadY_MaxUp.TabIndex = 64;
            this.btnX_AxisLoadY_MaxUp.Text = "▲";
            this.btnX_AxisLoadY_MaxUp.Click += new System.EventHandler(this.btnX_AxisLoadY_MaxUp_Click);
            // 
            // btnX_AxisPOSY_MaxDown
            // 
            this.btnX_AxisPOSY_MaxDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_AxisPOSY_MaxDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_AxisPOSY_MaxDown.Location = new System.Drawing.Point(91, 55);
            this.btnX_AxisPOSY_MaxDown.Name = "btnX_AxisPOSY_MaxDown";
            this.btnX_AxisPOSY_MaxDown.Size = new System.Drawing.Size(25, 25);
            this.btnX_AxisPOSY_MaxDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_AxisPOSY_MaxDown.TabIndex = 64;
            this.btnX_AxisPOSY_MaxDown.Text = "▼";
            this.btnX_AxisPOSY_MaxDown.Click += new System.EventHandler(this.btnX_AxisPOSY_MaxDown_Click);
            // 
            // btnX_AxisLoadY_MinUp
            // 
            this.btnX_AxisLoadY_MinUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_AxisLoadY_MinUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_AxisLoadY_MinUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_AxisLoadY_MinUp.Location = new System.Drawing.Point(996, 450);
            this.btnX_AxisLoadY_MinUp.Name = "btnX_AxisLoadY_MinUp";
            this.btnX_AxisLoadY_MinUp.Size = new System.Drawing.Size(25, 25);
            this.btnX_AxisLoadY_MinUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_AxisLoadY_MinUp.TabIndex = 64;
            this.btnX_AxisLoadY_MinUp.Text = "▲";
            this.btnX_AxisLoadY_MinUp.Click += new System.EventHandler(this.btnX_AxisLoadY_MinUp_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1333, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "次";
            this.label2.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1235, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "初始总计数";
            this.label1.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // btnX_AxisLoadY_MaxDown
            // 
            this.btnX_AxisLoadY_MaxDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_AxisLoadY_MaxDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_AxisLoadY_MaxDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_AxisLoadY_MaxDown.Location = new System.Drawing.Point(992, 55);
            this.btnX_AxisLoadY_MaxDown.Name = "btnX_AxisLoadY_MaxDown";
            this.btnX_AxisLoadY_MaxDown.Size = new System.Drawing.Size(25, 25);
            this.btnX_AxisLoadY_MaxDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_AxisLoadY_MaxDown.TabIndex = 64;
            this.btnX_AxisLoadY_MaxDown.Text = "▼";
            this.btnX_AxisLoadY_MaxDown.Click += new System.EventHandler(this.btnX_AxisLoadY_MaxDown_Click);
            // 
            // btnX_AsixYMin
            // 
            this.btnX_AsixYMin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_AsixYMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnX_AsixYMin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_AsixYMin.Location = new System.Drawing.Point(91, 481);
            this.btnX_AsixYMin.Name = "btnX_AsixYMin";
            this.btnX_AsixYMin.Size = new System.Drawing.Size(25, 25);
            this.btnX_AsixYMin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_AsixYMin.TabIndex = 64;
            this.btnX_AsixYMin.Text = "▼";
            this.btnX_AsixYMin.Click += new System.EventHandler(this.btnX_AsixPOSY_MinDown_Click);
            // 
            // btnX_AxisLoadY_MinDown
            // 
            this.btnX_AxisLoadY_MinDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_AxisLoadY_MinDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_AxisLoadY_MinDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_AxisLoadY_MinDown.Location = new System.Drawing.Point(996, 481);
            this.btnX_AxisLoadY_MinDown.Name = "btnX_AxisLoadY_MinDown";
            this.btnX_AxisLoadY_MinDown.Size = new System.Drawing.Size(25, 25);
            this.btnX_AxisLoadY_MinDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_AxisLoadY_MinDown.TabIndex = 64;
            this.btnX_AxisLoadY_MinDown.Text = "▼";
            this.btnX_AxisLoadY_MinDown.Click += new System.EventHandler(this.btnX_AxisLoadY_MinDown_Click);
            // 
            // btnX_AxisYMax
            // 
            this.btnX_AxisYMax.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_AxisYMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnX_AxisYMax.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_AxisYMax.Location = new System.Drawing.Point(91, 450);
            this.btnX_AxisYMax.Name = "btnX_AxisYMax";
            this.btnX_AxisYMax.Size = new System.Drawing.Size(25, 25);
            this.btnX_AxisYMax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_AxisYMax.TabIndex = 64;
            this.btnX_AxisYMax.Text = "▲";
            this.btnX_AxisYMax.Click += new System.EventHandler(this.btnX_AxisPOSY_MinUp_Click);
            // 
            // chart_machine
            // 
            this.chart_machine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea7.AxisX.Interval = 1D;
            chartArea7.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea7.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea7.AxisX.MajorGrid.LineColor = System.Drawing.Color.OliveDrab;
            chartArea7.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea7.AxisX.Maximum = 10D;
            chartArea7.AxisX.MaximumAutoSize = 100F;
            chartArea7.AxisX.Minimum = 0D;
            chartArea7.AxisX.MinorTickMark.Enabled = true;
            chartArea7.AxisX.MinorTickMark.Size = 0.5F;
            chartArea7.AxisX.Title = "时间(s)";
            chartArea7.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea7.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea7.AxisY.LineColor = System.Drawing.Color.DodgerBlue;
            chartArea7.AxisY.MajorGrid.LineColor = System.Drawing.Color.Red;
            chartArea7.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea7.AxisY.Maximum = 20D;
            chartArea7.AxisY.Minimum = -20D;
            chartArea7.AxisY.MinorTickMark.Enabled = true;
            chartArea7.AxisY.MinorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea7.AxisY.MinorTickMark.Size = 0.5F;
            chartArea7.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea7.AxisY.Title = "位 \\n\\n移 \\n\\n(mm)";
            chartArea7.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisY.TitleForeColor = System.Drawing.Color.DodgerBlue;
            chartArea7.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea7.AxisY2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea7.AxisY2.LineColor = System.Drawing.Color.Orange;
            chartArea7.AxisY2.MajorGrid.LineColor = System.Drawing.Color.OliveDrab;
            chartArea7.AxisY2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea7.AxisY2.Maximum = 20D;
            chartArea7.AxisY2.Minimum = -20D;
            chartArea7.AxisY2.MinorTickMark.Enabled = true;
            chartArea7.AxisY2.MinorTickMark.Size = 0.5F;
            chartArea7.AxisY2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea7.AxisY2.Title = "试 \\n\\n验\\n\\n力\\n\\n(N)";
            chartArea7.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisY2.TitleForeColor = System.Drawing.Color.Orange;
            chartArea7.Name = "ChartArea1";
            this.chart_machine.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart_machine.Legends.Add(legend7);
            this.chart_machine.Location = new System.Drawing.Point(0, 0);
            this.chart_machine.Name = "chart_machine";
            series25.ChartArea = "ChartArea1";
            series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series25.Legend = "Legend1";
            series25.Name = "位移";
            series25.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series26.ChartArea = "ChartArea1";
            series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series26.Legend = "Legend1";
            series26.Name = "试验力";
            series26.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series27.ChartArea = "ChartArea1";
            series27.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series27.Legend = "Legend1";
            series27.Name = "变形";
            series28.ChartArea = "ChartArea1";
            series28.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series28.Color = System.Drawing.Color.BlueViolet;
            series28.Legend = "Legend1";
            series28.Name = "命令";
            series28.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart_machine.Series.Add(series25);
            this.chart_machine.Series.Add(series26);
            this.chart_machine.Series.Add(series27);
            this.chart_machine.Series.Add(series28);
            this.chart_machine.Size = new System.Drawing.Size(1212, 554);
            this.chart_machine.TabIndex = 63;
            // 
            // btnX_Connect
            // 
            this.btnX_Connect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnX_Connect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_Connect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_Connect.Image = ((System.Drawing.Image)(resources.GetObject("btnX_Connect.Image")));
            this.btnX_Connect.Location = new System.Drawing.Point(1239, 467);
            this.btnX_Connect.Name = "btnX_Connect";
            this.btnX_Connect.Size = new System.Drawing.Size(120, 39);
            this.btnX_Connect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_Connect.TabIndex = 57;
            this.btnX_Connect.Text = "连     接";
            this.btnX_Connect.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_Connect.Click += new System.EventHandler(this.btnX_Connect_Click);
            // 
            // btnX_Disconnect
            // 
            this.btnX_Disconnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_Disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_Disconnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_Disconnect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_Disconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnX_Disconnect.Image")));
            this.btnX_Disconnect.Location = new System.Drawing.Point(1239, 512);
            this.btnX_Disconnect.Name = "btnX_Disconnect";
            this.btnX_Disconnect.Size = new System.Drawing.Size(120, 40);
            this.btnX_Disconnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_Disconnect.TabIndex = 57;
            this.btnX_Disconnect.Text = "断     开";
            this.btnX_Disconnect.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_Disconnect.Click += new System.EventHandler(this.btnX_Disconnect_Click);
            // 
            // bntX_MoveUp
            // 
            this.bntX_MoveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveUp.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveUp.Image")));
            this.bntX_MoveUp.Location = new System.Drawing.Point(1239, 96);
            this.bntX_MoveUp.Name = "bntX_MoveUp";
            this.bntX_MoveUp.Size = new System.Drawing.Size(120, 40);
            this.bntX_MoveUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveUp.TabIndex = 57;
            this.bntX_MoveUp.Text = "向     上";
            this.bntX_MoveUp.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_MoveUp.Click += new System.EventHandler(this.bntX_MoveUp_Click);
            this.bntX_MoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bntX_MoveUp_MouseDown);
            this.bntX_MoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bntX_MoveUp_MouseUp);
            // 
            // btnX_MoveQuickUp
            // 
            this.btnX_MoveQuickUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_MoveQuickUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_MoveQuickUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_MoveQuickUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_MoveQuickUp.Image = ((System.Drawing.Image)(resources.GetObject("btnX_MoveQuickUp.Image")));
            this.btnX_MoveQuickUp.Location = new System.Drawing.Point(1239, 51);
            this.btnX_MoveQuickUp.Name = "btnX_MoveQuickUp";
            this.btnX_MoveQuickUp.Size = new System.Drawing.Size(120, 40);
            this.btnX_MoveQuickUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_MoveQuickUp.TabIndex = 57;
            this.btnX_MoveQuickUp.Text = " 快速向上";
            this.btnX_MoveQuickUp.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_MoveQuickUp.Click += new System.EventHandler(this.btnX_MoveQuickUp_Click);
            this.btnX_MoveQuickUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnX_MoveQuickUp_MouseDown);
            this.btnX_MoveQuickUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnX_MoveQuickUp_MouseUp);
            // 
            // bntX_MoveHalt
            // 
            this.bntX_MoveHalt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveHalt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveHalt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveHalt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveHalt.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveHalt.Image")));
            this.bntX_MoveHalt.Location = new System.Drawing.Point(1239, 141);
            this.bntX_MoveHalt.Name = "bntX_MoveHalt";
            this.bntX_MoveHalt.Size = new System.Drawing.Size(120, 40);
            this.bntX_MoveHalt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveHalt.TabIndex = 57;
            this.bntX_MoveHalt.Text = "保     持";
            this.bntX_MoveHalt.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_MoveHalt.Click += new System.EventHandler(this.bntX_MoveHalt_Click);
            // 
            // bntX_MoveDown
            // 
            this.bntX_MoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveDown.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveDown.Image")));
            this.bntX_MoveDown.Location = new System.Drawing.Point(1239, 186);
            this.bntX_MoveDown.Name = "bntX_MoveDown";
            this.bntX_MoveDown.Size = new System.Drawing.Size(120, 40);
            this.bntX_MoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveDown.TabIndex = 57;
            this.bntX_MoveDown.Text = "向     下";
            this.bntX_MoveDown.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_MoveDown.Click += new System.EventHandler(this.bntX_MoveDown_Click);
            this.bntX_MoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bntX_MoveDown_MouseDown);
            this.bntX_MoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bntX_MoveDown_MouseUp);
            // 
            // btnX_QuickMoveDown
            // 
            this.btnX_QuickMoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_QuickMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_QuickMoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_QuickMoveDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_QuickMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnX_QuickMoveDown.Image")));
            this.btnX_QuickMoveDown.Location = new System.Drawing.Point(1239, 231);
            this.btnX_QuickMoveDown.Name = "btnX_QuickMoveDown";
            this.btnX_QuickMoveDown.Size = new System.Drawing.Size(120, 40);
            this.btnX_QuickMoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_QuickMoveDown.TabIndex = 57;
            this.btnX_QuickMoveDown.Text = " 快速向下";
            this.btnX_QuickMoveDown.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_QuickMoveDown.Click += new System.EventHandler(this.btnX_QuickMoveDown_Click);
            this.btnX_QuickMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnX_QuickMoveDown_MouseDown);
            this.btnX_QuickMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnX_QuickMoveDown_MouseUp);
            // 
            // btn_ConState
            // 
            this.btn_ConState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConState.Enabled = false;
            this.btn_ConState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConState.Location = new System.Drawing.Point(1239, 3);
            this.btn_ConState.Name = "btn_ConState";
            this.btn_ConState.Size = new System.Drawing.Size(123, 42);
            this.btn_ConState.TabIndex = 58;
            this.btn_ConState.Text = "OFFLINE";
            this.btn_ConState.UseVisualStyleBackColor = true;
            // 
            // bntX_GUIOn
            // 
            this.bntX_GUIOn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_GUIOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_GUIOn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_GUIOn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_GUIOn.Location = new System.Drawing.Point(1239, 276);
            this.bntX_GUIOn.Name = "bntX_GUIOn";
            this.bntX_GUIOn.Size = new System.Drawing.Size(55, 40);
            this.bntX_GUIOn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_GUIOn.TabIndex = 57;
            this.bntX_GUIOn.Text = "ON";
            this.bntX_GUIOn.Click += new System.EventHandler(this.bntX_GUIOn_Click);
            // 
            // btnX_SetLow
            // 
            this.btnX_SetLow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_SetLow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_SetLow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_SetLow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_SetLow.Location = new System.Drawing.Point(1304, 323);
            this.btnX_SetLow.Name = "btnX_SetLow";
            this.btnX_SetLow.Size = new System.Drawing.Size(55, 40);
            this.btnX_SetLow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_SetLow.TabIndex = 57;
            this.btnX_SetLow.Text = "LOW";
            this.btnX_SetLow.Click += new System.EventHandler(this.btnX_SetLow_Click);
            // 
            // bntX_GUIOff
            // 
            this.bntX_GUIOff.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_GUIOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_GUIOff.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_GUIOff.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_GUIOff.Location = new System.Drawing.Point(1304, 277);
            this.bntX_GUIOff.Name = "bntX_GUIOff";
            this.bntX_GUIOff.Size = new System.Drawing.Size(55, 40);
            this.bntX_GUIOff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_GUIOff.TabIndex = 57;
            this.bntX_GUIOff.Text = "OFF";
            this.bntX_GUIOff.Click += new System.EventHandler(this.bntX_GUIOff_Click);
            // 
            // btnX_SetHigh
            // 
            this.btnX_SetHigh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_SetHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_SetHigh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_SetHigh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_SetHigh.Location = new System.Drawing.Point(1239, 322);
            this.btnX_SetHigh.Name = "btnX_SetHigh";
            this.btnX_SetHigh.Size = new System.Drawing.Size(55, 40);
            this.btnX_SetHigh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_SetHigh.TabIndex = 57;
            this.btnX_SetHigh.Text = "HIGH";
            this.btnX_SetHigh.Click += new System.EventHandler(this.btnX_SetHigh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbX_EDCName,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_SystemTime});
            this.statusStrip1.Location = new System.Drawing.Point(3, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1412, 26);
            this.statusStrip1.TabIndex = 66;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 21);
            this.toolStripStatusLabel1.Text = "控制器型号：";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // lbX_EDCName
            // 
            this.lbX_EDCName.AutoSize = false;
            this.lbX_EDCName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbX_EDCName.Name = "lbX_EDCName";
            this.lbX_EDCName.Size = new System.Drawing.Size(160, 21);
            this.lbX_EDCName.Visible = false;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(72, 21);
            this.toolStripStatusLabel3.Text = "设备编号：";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.AutoSize = false;
            this.toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(80, 21);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(72, 21);
            this.toolStripStatusLabel2.Text = "系统时间：";
            this.toolStripStatusLabel2.Visible = false;
            // 
            // toolStripStatusLabel_SystemTime
            // 
            this.toolStripStatusLabel_SystemTime.AutoSize = false;
            this.toolStripStatusLabel_SystemTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_SystemTime.Name = "toolStripStatusLabel_SystemTime";
            this.toolStripStatusLabel_SystemTime.Size = new System.Drawing.Size(160, 21);
            this.toolStripStatusLabel_SystemTime.Visible = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsToolStripMenuItem,
            this.posToolStripMenuItem,
            this.Pos_AtoolStripMenuItem1,
            this.dynCtrlToolStripMenuItem,
            this.pIDToolStripMenuItem,
            this.setBitToolStripMenuItem,
            this.ShowLogToolStripMenuItem,
            this.startStopDrawToolStripMenuItem,
            this.AdjustToolStripMenuItem,
            this.ChartSetToolStripMenuItem,
            this.AutoSetYAxisToolStripMenuItem,
            this.MultiSensorToolStripMenuItem,
            this.SaveStaticDataToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 17);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1412, 25);
            this.menuStrip2.TabIndex = 61;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem});
            this.commandsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("commandsToolStripMenuItem.Image")));
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(108, 21);
            this.commandsToolStripMenuItem.Text = "Command▼";
            this.commandsToolStripMenuItem.Visible = false;
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posAToolStripMenuItem,
            this.posExtToolStripMenuItem,
            this.posExtAToolStripMenuItem,
            this.toolStripSeparator2,
            this.fMoveToolStripMenuItem,
            this.fMoveaToolStripMenuItem,
            this.toolStripSeparator3,
            this.cycleToolStripMenuItem,
            this.dynCyclesToolStripMenuItem,
            this.setPeakCtrlValueToolStripMenuItem,
            this.setPeakCtrlToolStripMenuItem,
            this.toolStripSeparator4,
            this.ext2CtrlToolStripMenuItem,
            this.haltToolStripMenuItem,
            this.sHaltToolStripMenuItem,
            this.toolStripSeparator5,
            this.pcCmdFromFileToolStripMenuItem,
            this.toolStripSeparator6,
            this.setOpenLoopCommandToolStripMenuItem,
            this.toolStripSeparator7,
            this.blockToolStripMenuItem,
            this.haltWToolStripMenuItem,
            this.haltWAToolStripMenuItem,
            this.trigToolStripMenuItem,
            this.trigAToolStripMenuItem,
            this.xpCountToolStripMenuItem,
            this.toolStripSeparator8,
            this.synchronizeMoveToolStripMenuItem});
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.moveToolStripMenuItem.Text = "Move";
            // 
            // posAToolStripMenuItem
            // 
            this.posAToolStripMenuItem.Name = "posAToolStripMenuItem";
            this.posAToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.posAToolStripMenuItem.Text = "Pos_A";
            // 
            // posExtToolStripMenuItem
            // 
            this.posExtToolStripMenuItem.Name = "posExtToolStripMenuItem";
            this.posExtToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.posExtToolStripMenuItem.Text = "PosExt";
            // 
            // posExtAToolStripMenuItem
            // 
            this.posExtAToolStripMenuItem.Name = "posExtAToolStripMenuItem";
            this.posExtAToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.posExtAToolStripMenuItem.Text = "PosExt_A";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // fMoveToolStripMenuItem
            // 
            this.fMoveToolStripMenuItem.Name = "fMoveToolStripMenuItem";
            this.fMoveToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.fMoveToolStripMenuItem.Text = "FMove";
            // 
            // fMoveaToolStripMenuItem
            // 
            this.fMoveaToolStripMenuItem.Name = "fMoveaToolStripMenuItem";
            this.fMoveaToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.fMoveaToolStripMenuItem.Text = "FMove_A";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(213, 6);
            // 
            // cycleToolStripMenuItem
            // 
            this.cycleToolStripMenuItem.Name = "cycleToolStripMenuItem";
            this.cycleToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.cycleToolStripMenuItem.Text = "Cycle";
            // 
            // dynCyclesToolStripMenuItem
            // 
            this.dynCyclesToolStripMenuItem.Name = "dynCyclesToolStripMenuItem";
            this.dynCyclesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.dynCyclesToolStripMenuItem.Text = "DynCycles";
            // 
            // setPeakCtrlValueToolStripMenuItem
            // 
            this.setPeakCtrlValueToolStripMenuItem.Name = "setPeakCtrlValueToolStripMenuItem";
            this.setPeakCtrlValueToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.setPeakCtrlValueToolStripMenuItem.Text = "SetPeakCtrlValue";
            // 
            // setPeakCtrlToolStripMenuItem
            // 
            this.setPeakCtrlToolStripMenuItem.Name = "setPeakCtrlToolStripMenuItem";
            this.setPeakCtrlToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.setPeakCtrlToolStripMenuItem.Text = "SetPeakCtrl";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(213, 6);
            // 
            // ext2CtrlToolStripMenuItem
            // 
            this.ext2CtrlToolStripMenuItem.Name = "ext2CtrlToolStripMenuItem";
            this.ext2CtrlToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.ext2CtrlToolStripMenuItem.Text = "Ext2Ctrl";
            // 
            // haltToolStripMenuItem
            // 
            this.haltToolStripMenuItem.Name = "haltToolStripMenuItem";
            this.haltToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.haltToolStripMenuItem.Text = "Halt";
            // 
            // sHaltToolStripMenuItem
            // 
            this.sHaltToolStripMenuItem.Name = "sHaltToolStripMenuItem";
            this.sHaltToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.sHaltToolStripMenuItem.Text = "SHalt";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(213, 6);
            // 
            // pcCmdFromFileToolStripMenuItem
            // 
            this.pcCmdFromFileToolStripMenuItem.Name = "pcCmdFromFileToolStripMenuItem";
            this.pcCmdFromFileToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.pcCmdFromFileToolStripMenuItem.Text = "PcCmdFromFile";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(213, 6);
            // 
            // setOpenLoopCommandToolStripMenuItem
            // 
            this.setOpenLoopCommandToolStripMenuItem.Name = "setOpenLoopCommandToolStripMenuItem";
            this.setOpenLoopCommandToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.setOpenLoopCommandToolStripMenuItem.Text = "SetOpenLoopCommand";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(213, 6);
            // 
            // blockToolStripMenuItem
            // 
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            this.blockToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.blockToolStripMenuItem.Text = "Block";
            // 
            // haltWToolStripMenuItem
            // 
            this.haltWToolStripMenuItem.Name = "haltWToolStripMenuItem";
            this.haltWToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.haltWToolStripMenuItem.Text = "HaltW";
            // 
            // haltWAToolStripMenuItem
            // 
            this.haltWAToolStripMenuItem.Name = "haltWAToolStripMenuItem";
            this.haltWAToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.haltWAToolStripMenuItem.Text = "HaltW_A";
            // 
            // trigToolStripMenuItem
            // 
            this.trigToolStripMenuItem.Name = "trigToolStripMenuItem";
            this.trigToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.trigToolStripMenuItem.Text = "Trig";
            // 
            // trigAToolStripMenuItem
            // 
            this.trigAToolStripMenuItem.Name = "trigAToolStripMenuItem";
            this.trigAToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.trigAToolStripMenuItem.Text = "Trig_A";
            // 
            // xpCountToolStripMenuItem
            // 
            this.xpCountToolStripMenuItem.Name = "xpCountToolStripMenuItem";
            this.xpCountToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.xpCountToolStripMenuItem.Text = "XpCount";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(213, 6);
            // 
            // synchronizeMoveToolStripMenuItem
            // 
            this.synchronizeMoveToolStripMenuItem.Name = "synchronizeMoveToolStripMenuItem";
            this.synchronizeMoveToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.synchronizeMoveToolStripMenuItem.Text = "SynchronizeMove";
            // 
            // posToolStripMenuItem
            // 
            this.posToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("posToolStripMenuItem.Image")));
            this.posToolStripMenuItem.Name = "posToolStripMenuItem";
            this.posToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.posToolStripMenuItem.Text = "Pos";
            this.posToolStripMenuItem.Click += new System.EventHandler(this.posToolStripMenuItem_Click);
            // 
            // Pos_AtoolStripMenuItem1
            // 
            this.Pos_AtoolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("Pos_AtoolStripMenuItem1.Image")));
            this.Pos_AtoolStripMenuItem1.Name = "Pos_AtoolStripMenuItem1";
            this.Pos_AtoolStripMenuItem1.Size = new System.Drawing.Size(70, 21);
            this.Pos_AtoolStripMenuItem1.Text = "Pos_A";
            this.Pos_AtoolStripMenuItem1.Visible = false;
            this.Pos_AtoolStripMenuItem1.Click += new System.EventHandler(this.Pos_AtoolStripMenuItem1_Click);
            // 
            // dynCtrlToolStripMenuItem
            // 
            this.dynCtrlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dynCtrlToolStripMenuItem.Image")));
            this.dynCtrlToolStripMenuItem.Name = "dynCtrlToolStripMenuItem";
            this.dynCtrlToolStripMenuItem.Size = new System.Drawing.Size(78, 21);
            this.dynCtrlToolStripMenuItem.Text = "DynCtrl";
            this.dynCtrlToolStripMenuItem.Click += new System.EventHandler(this.dynCtrlToolStripMenuItem_Click);
            // 
            // pIDToolStripMenuItem
            // 
            this.pIDToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pIDToolStripMenuItem.Image")));
            this.pIDToolStripMenuItem.Name = "pIDToolStripMenuItem";
            this.pIDToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.pIDToolStripMenuItem.Text = "PID";
            this.pIDToolStripMenuItem.Visible = false;
            // 
            // setBitToolStripMenuItem
            // 
            this.setBitToolStripMenuItem.Name = "setBitToolStripMenuItem";
            this.setBitToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.setBitToolStripMenuItem.Text = "SetBit";
            this.setBitToolStripMenuItem.Visible = false;
            // 
            // ShowLogToolStripMenuItem
            // 
            this.ShowLogToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowLogToolStripMenuItem.Name = "ShowLogToolStripMenuItem";
            this.ShowLogToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.ShowLogToolStripMenuItem.Text = "显示日志";
            this.ShowLogToolStripMenuItem.Visible = false;
            this.ShowLogToolStripMenuItem.Click += new System.EventHandler(this.ShowLogToolStripMenuItem_Click);
            // 
            // startStopDrawToolStripMenuItem
            // 
            this.startStopDrawToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startStopDrawToolStripMenuItem.Name = "startStopDrawToolStripMenuItem";
            this.startStopDrawToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.startStopDrawToolStripMenuItem.Text = "暂停绘制";
            this.startStopDrawToolStripMenuItem.Click += new System.EventHandler(this.startStopDrawToolStripMenuItem_Click);
            // 
            // AdjustToolStripMenuItem
            // 
            this.AdjustToolStripMenuItem.Name = "AdjustToolStripMenuItem";
            this.AdjustToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.AdjustToolStripMenuItem.Text = "校正";
            this.AdjustToolStripMenuItem.Click += new System.EventHandler(this.AdjustToolStripMenuItem_Click);
            // 
            // ChartSetToolStripMenuItem
            // 
            this.ChartSetToolStripMenuItem.Name = "ChartSetToolStripMenuItem";
            this.ChartSetToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ChartSetToolStripMenuItem.Text = "图表设置";
            this.ChartSetToolStripMenuItem.Click += new System.EventHandler(this.ChartSetToolStripMenuItem_Click);
            // 
            // AutoSetYAxisToolStripMenuItem
            // 
            this.AutoSetYAxisToolStripMenuItem.Name = "AutoSetYAxisToolStripMenuItem";
            this.AutoSetYAxisToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.AutoSetYAxisToolStripMenuItem.Text = "曲线坐标自适应";
            this.AutoSetYAxisToolStripMenuItem.Click += new System.EventHandler(this.AutoSetYAxisToolStripMenuItem_Click);
            // 
            // MultiSensorToolStripMenuItem
            // 
            this.MultiSensorToolStripMenuItem.Name = "MultiSensorToolStripMenuItem";
            this.MultiSensorToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.MultiSensorToolStripMenuItem.Text = "多传感器";
            this.MultiSensorToolStripMenuItem.Click += new System.EventHandler(this.MultiSensorToolStripMenuItem_Click);
            // 
            // SaveStaticDataToolStripMenuItem
            // 
            this.SaveStaticDataToolStripMenuItem.Name = "SaveStaticDataToolStripMenuItem";
            this.SaveStaticDataToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.SaveStaticDataToolStripMenuItem.Text = "保存静态数据";
            this.SaveStaticDataToolStripMenuItem.Click += new System.EventHandler(this.SaveStaticDataToolStripMenuItem_Click);
            // 
            // pl_DataShow
            // 
            this.pl_DataShow.Controls.Add(this.labelX33);
            this.pl_DataShow.Controls.Add(this.cb_TareTime);
            this.pl_DataShow.Controls.Add(this.cb_TareExt);
            this.pl_DataShow.Controls.Add(this.cb_TareLoad);
            this.pl_DataShow.Controls.Add(this.cb_TarePos);
            this.pl_DataShow.Controls.Add(this.lblExtensionMinValue);
            this.pl_DataShow.Controls.Add(this.lblLoadMinValue);
            this.pl_DataShow.Controls.Add(this.lblPositionMinValue);
            this.pl_DataShow.Controls.Add(this.lblExtensionMaxValue);
            this.pl_DataShow.Controls.Add(this.lblLoadMaxValue);
            this.pl_DataShow.Controls.Add(this.lblTestCycles);
            this.pl_DataShow.Controls.Add(this.lblExtensionMaxMin);
            this.pl_DataShow.Controls.Add(this.lblLoadMaxMin);
            this.pl_DataShow.Controls.Add(this.lblPositionMaxValue);
            this.pl_DataShow.Controls.Add(this.lblPositionMaxMin);
            this.pl_DataShow.Controls.Add(this.lblTime);
            this.pl_DataShow.Controls.Add(this.tb_MinExt);
            this.pl_DataShow.Controls.Add(this.lblExtension);
            this.pl_DataShow.Controls.Add(this.tb_MinLoad);
            this.pl_DataShow.Controls.Add(this.tb_MaxExt);
            this.pl_DataShow.Controls.Add(this.label3);
            this.pl_DataShow.Controls.Add(this.lblLoad);
            this.pl_DataShow.Controls.Add(this.tb_MaxLoad);
            this.pl_DataShow.Controls.Add(this.tb_MinPos);
            this.pl_DataShow.Controls.Add(this.tb_MaxPos);
            this.pl_DataShow.Controls.Add(this.guiPosition);
            this.pl_DataShow.Controls.Add(this.tbX_TestCycles);
            this.pl_DataShow.Controls.Add(this.guiExtension);
            this.pl_DataShow.Controls.Add(this.lblPosition);
            this.pl_DataShow.Controls.Add(this.guiTime);
            this.pl_DataShow.Controls.Add(this.guiLoad);
            this.pl_DataShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_DataShow.Location = new System.Drawing.Point(0, 0);
            this.pl_DataShow.Name = "pl_DataShow";
            this.pl_DataShow.Size = new System.Drawing.Size(1418, 82);
            this.pl_DataShow.TabIndex = 56;
            // 
            // labelX33
            // 
            // 
            // 
            // 
            this.labelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX33.Location = new System.Drawing.Point(1294, 2);
            this.labelX33.Name = "labelX33";
            this.labelX33.Size = new System.Drawing.Size(75, 23);
            this.labelX33.TabIndex = 43;
            this.labelX33.Text = "labelX33";
            this.labelX33.Visible = false;
            // 
            // cb_TareTime
            // 
            this.cb_TareTime.AutoSize = true;
            this.cb_TareTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_TareTime.Location = new System.Drawing.Point(1160, 4);
            this.cb_TareTime.Name = "cb_TareTime";
            this.cb_TareTime.Size = new System.Drawing.Size(35, 20);
            this.cb_TareTime.TabIndex = 42;
            this.cb_TareTime.Text = "T";
            this.cb_TareTime.UseVisualStyleBackColor = true;
            this.cb_TareTime.CheckedChanged += new System.EventHandler(this.cb_TareTime_CheckedChanged);
            // 
            // cb_TareExt
            // 
            this.cb_TareExt.AutoSize = true;
            this.cb_TareExt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_TareExt.Location = new System.Drawing.Point(831, 4);
            this.cb_TareExt.Name = "cb_TareExt";
            this.cb_TareExt.Size = new System.Drawing.Size(35, 20);
            this.cb_TareExt.TabIndex = 42;
            this.cb_TareExt.Text = "T";
            this.cb_TareExt.UseVisualStyleBackColor = true;
            this.cb_TareExt.CheckedChanged += new System.EventHandler(this.cb_TareExt_CheckedChanged);
            // 
            // cb_TareLoad
            // 
            this.cb_TareLoad.AutoSize = true;
            this.cb_TareLoad.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_TareLoad.Location = new System.Drawing.Point(503, 4);
            this.cb_TareLoad.Name = "cb_TareLoad";
            this.cb_TareLoad.Size = new System.Drawing.Size(35, 20);
            this.cb_TareLoad.TabIndex = 42;
            this.cb_TareLoad.Text = "T";
            this.cb_TareLoad.UseVisualStyleBackColor = true;
            this.cb_TareLoad.CheckedChanged += new System.EventHandler(this.cb_TareLoad_CheckedChanged);
            // 
            // cb_TarePos
            // 
            this.cb_TarePos.AutoSize = true;
            this.cb_TarePos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_TarePos.Location = new System.Drawing.Point(174, 2);
            this.cb_TarePos.Name = "cb_TarePos";
            this.cb_TarePos.Size = new System.Drawing.Size(35, 20);
            this.cb_TarePos.TabIndex = 42;
            this.cb_TarePos.Text = "T";
            this.cb_TarePos.UseVisualStyleBackColor = true;
            this.cb_TarePos.CheckedChanged += new System.EventHandler(this.cb_TarePos_CheckedChanged);
            // 
            // lblExtensionMinValue
            // 
            this.lblExtensionMinValue.AutoSize = true;
            this.lblExtensionMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtensionMinValue.Location = new System.Drawing.Point(994, 52);
            this.lblExtensionMinValue.Name = "lblExtensionMinValue";
            this.lblExtensionMinValue.Size = new System.Drawing.Size(38, 17);
            this.lblExtensionMinValue.TabIndex = 26;
            this.lblExtensionMinValue.Text = "谷值";
            this.lblExtensionMinValue.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblLoadMinValue
            // 
            this.lblLoadMinValue.AutoSize = true;
            this.lblLoadMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadMinValue.Location = new System.Drawing.Point(666, 52);
            this.lblLoadMinValue.Name = "lblLoadMinValue";
            this.lblLoadMinValue.Size = new System.Drawing.Size(38, 17);
            this.lblLoadMinValue.TabIndex = 26;
            this.lblLoadMinValue.Text = "谷值";
            this.lblLoadMinValue.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblPositionMinValue
            // 
            this.lblPositionMinValue.AutoSize = true;
            this.lblPositionMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionMinValue.Location = new System.Drawing.Point(337, 52);
            this.lblPositionMinValue.Name = "lblPositionMinValue";
            this.lblPositionMinValue.Size = new System.Drawing.Size(38, 17);
            this.lblPositionMinValue.TabIndex = 26;
            this.lblPositionMinValue.Text = "谷值";
            this.lblPositionMinValue.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblExtensionMaxValue
            // 
            this.lblExtensionMaxValue.AutoSize = true;
            this.lblExtensionMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtensionMaxValue.Location = new System.Drawing.Point(994, 28);
            this.lblExtensionMaxValue.Name = "lblExtensionMaxValue";
            this.lblExtensionMaxValue.Size = new System.Drawing.Size(38, 17);
            this.lblExtensionMaxValue.TabIndex = 26;
            this.lblExtensionMaxValue.Text = "峰值";
            this.lblExtensionMaxValue.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblLoadMaxValue
            // 
            this.lblLoadMaxValue.AutoSize = true;
            this.lblLoadMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadMaxValue.Location = new System.Drawing.Point(666, 28);
            this.lblLoadMaxValue.Name = "lblLoadMaxValue";
            this.lblLoadMaxValue.Size = new System.Drawing.Size(38, 17);
            this.lblLoadMaxValue.TabIndex = 26;
            this.lblLoadMaxValue.Text = "峰值";
            this.lblLoadMaxValue.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblTestCycles
            // 
            this.lblTestCycles.AutoSize = true;
            this.lblTestCycles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestCycles.Location = new System.Drawing.Point(1201, 4);
            this.lblTestCycles.Name = "lblTestCycles";
            this.lblTestCycles.Size = new System.Drawing.Size(77, 20);
            this.lblTestCycles.TabIndex = 26;
            this.lblTestCycles.Text = "试验次数";
            this.lblTestCycles.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblExtensionMaxMin
            // 
            this.lblExtensionMaxMin.AutoSize = true;
            this.lblExtensionMaxMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtensionMaxMin.Location = new System.Drawing.Point(1057, 1);
            this.lblExtensionMaxMin.Name = "lblExtensionMaxMin";
            this.lblExtensionMaxMin.Size = new System.Drawing.Size(94, 20);
            this.lblExtensionMaxMin.TabIndex = 26;
            this.lblExtensionMaxMin.Text = "变形峰谷值";
            this.lblExtensionMaxMin.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblLoadMaxMin
            // 
            this.lblLoadMaxMin.AutoSize = true;
            this.lblLoadMaxMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadMaxMin.Location = new System.Drawing.Point(714, 2);
            this.lblLoadMaxMin.Name = "lblLoadMaxMin";
            this.lblLoadMaxMin.Size = new System.Drawing.Size(111, 20);
            this.lblLoadMaxMin.TabIndex = 26;
            this.lblLoadMaxMin.Text = "试验力峰谷值";
            this.lblLoadMaxMin.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblPositionMaxValue
            // 
            this.lblPositionMaxValue.AutoSize = true;
            this.lblPositionMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionMaxValue.Location = new System.Drawing.Point(337, 28);
            this.lblPositionMaxValue.Name = "lblPositionMaxValue";
            this.lblPositionMaxValue.Size = new System.Drawing.Size(38, 17);
            this.lblPositionMaxValue.TabIndex = 26;
            this.lblPositionMaxValue.Text = "峰值";
            this.lblPositionMaxValue.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblPositionMaxMin
            // 
            this.lblPositionMaxMin.AutoSize = true;
            this.lblPositionMaxMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionMaxMin.Location = new System.Drawing.Point(403, 2);
            this.lblPositionMaxMin.Name = "lblPositionMaxMin";
            this.lblPositionMaxMin.Size = new System.Drawing.Size(94, 20);
            this.lblPositionMaxMin.TabIndex = 26;
            this.lblPositionMaxMin.Text = "位移峰谷值";
            this.lblPositionMaxMin.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(12, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(101, 20);
            this.lblTime.TabIndex = 26;
            this.lblTime.Text = "运行时间 [s]";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // tb_MinExt
            // 
            this.tb_MinExt.BackColor = System.Drawing.Color.Black;
            this.tb_MinExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MinExt.ForeColor = System.Drawing.Color.Lime;
            this.tb_MinExt.Location = new System.Drawing.Point(1057, 49);
            this.tb_MinExt.Name = "tb_MinExt";
            this.tb_MinExt.Size = new System.Drawing.Size(94, 23);
            this.tb_MinExt.TabIndex = 39;
            this.tb_MinExt.Text = "0.000";
            this.tb_MinExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtension.Location = new System.Drawing.Point(905, 4);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(86, 20);
            this.lblExtension.TabIndex = 32;
            this.lblExtension.Text = "变形 [mm]";
            // 
            // tb_MinLoad
            // 
            this.tb_MinLoad.BackColor = System.Drawing.Color.Black;
            this.tb_MinLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MinLoad.ForeColor = System.Drawing.Color.Lime;
            this.tb_MinLoad.Location = new System.Drawing.Point(731, 49);
            this.tb_MinLoad.Name = "tb_MinLoad";
            this.tb_MinLoad.Size = new System.Drawing.Size(94, 23);
            this.tb_MinLoad.TabIndex = 39;
            this.tb_MinLoad.Text = "0.000";
            this.tb_MinLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_MaxExt
            // 
            this.tb_MaxExt.BackColor = System.Drawing.Color.Black;
            this.tb_MaxExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MaxExt.ForeColor = System.Drawing.Color.Lime;
            this.tb_MaxExt.Location = new System.Drawing.Point(1057, 25);
            this.tb_MaxExt.Name = "tb_MaxExt";
            this.tb_MaxExt.Size = new System.Drawing.Size(94, 23);
            this.tb_MaxExt.TabIndex = 39;
            this.tb_MaxExt.Text = "0.000";
            this.tb_MaxExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoad.Location = new System.Drawing.Point(573, 1);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(60, 20);
            this.lblLoad.TabIndex = 30;
            this.lblLoad.Text = "试验力";
            // 
            // tb_MaxLoad
            // 
            this.tb_MaxLoad.BackColor = System.Drawing.Color.Black;
            this.tb_MaxLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MaxLoad.ForeColor = System.Drawing.Color.Lime;
            this.tb_MaxLoad.Location = new System.Drawing.Point(731, 25);
            this.tb_MaxLoad.Name = "tb_MaxLoad";
            this.tb_MaxLoad.Size = new System.Drawing.Size(94, 23);
            this.tb_MaxLoad.TabIndex = 39;
            this.tb_MaxLoad.Text = "0.000";
            this.tb_MaxLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_MinPos
            // 
            this.tb_MinPos.BackColor = System.Drawing.Color.Black;
            this.tb_MinPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MinPos.ForeColor = System.Drawing.Color.Lime;
            this.tb_MinPos.Location = new System.Drawing.Point(403, 49);
            this.tb_MinPos.Name = "tb_MinPos";
            this.tb_MinPos.Size = new System.Drawing.Size(94, 23);
            this.tb_MinPos.TabIndex = 39;
            this.tb_MinPos.Text = "0.000";
            this.tb_MinPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_MaxPos
            // 
            this.tb_MaxPos.BackColor = System.Drawing.Color.Black;
            this.tb_MaxPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MaxPos.ForeColor = System.Drawing.Color.Lime;
            this.tb_MaxPos.Location = new System.Drawing.Point(403, 25);
            this.tb_MaxPos.Name = "tb_MaxPos";
            this.tb_MaxPos.Size = new System.Drawing.Size(94, 23);
            this.tb_MaxPos.TabIndex = 39;
            this.tb_MaxPos.Text = "0.000";
            this.tb_MaxPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guiPosition
            // 
            this.guiPosition.BackColor = System.Drawing.Color.Black;
            this.guiPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiPosition.ForeColor = System.Drawing.Color.Lime;
            this.guiPosition.Location = new System.Drawing.Point(174, 25);
            this.guiPosition.Name = "guiPosition";
            this.guiPosition.Size = new System.Drawing.Size(157, 47);
            this.guiPosition.TabIndex = 39;
            this.guiPosition.Text = "0.000";
            this.guiPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbX_TestCycles
            // 
            this.tbX_TestCycles.BackColor = System.Drawing.Color.Black;
            this.tbX_TestCycles.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbX_TestCycles.ForeColor = System.Drawing.Color.Lime;
            this.tbX_TestCycles.Location = new System.Drawing.Point(1157, 25);
            this.tbX_TestCycles.Name = "tbX_TestCycles";
            this.tbX_TestCycles.Size = new System.Drawing.Size(205, 47);
            this.tbX_TestCycles.TabIndex = 41;
            this.tbX_TestCycles.Text = "0";
            this.tbX_TestCycles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guiExtension
            // 
            this.guiExtension.BackColor = System.Drawing.Color.Black;
            this.guiExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiExtension.ForeColor = System.Drawing.Color.Lime;
            this.guiExtension.Location = new System.Drawing.Point(831, 25);
            this.guiExtension.Name = "guiExtension";
            this.guiExtension.Size = new System.Drawing.Size(157, 47);
            this.guiExtension.TabIndex = 41;
            this.guiExtension.Text = "0.000";
            this.guiExtension.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(245, 2);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(86, 20);
            this.lblPosition.TabIndex = 28;
            this.lblPosition.Text = "位移 [mm]";
            // 
            // guiTime
            // 
            this.guiTime.BackColor = System.Drawing.Color.Black;
            this.guiTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiTime.ForeColor = System.Drawing.Color.Lime;
            this.guiTime.Location = new System.Drawing.Point(11, 25);
            this.guiTime.Name = "guiTime";
            this.guiTime.Size = new System.Drawing.Size(157, 47);
            this.guiTime.TabIndex = 25;
            this.guiTime.Text = "00:00:00";
            this.guiTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guiLoad
            // 
            this.guiLoad.BackColor = System.Drawing.Color.Black;
            this.guiLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiLoad.ForeColor = System.Drawing.Color.Lime;
            this.guiLoad.Location = new System.Drawing.Point(503, 25);
            this.guiLoad.Name = "guiLoad";
            this.guiLoad.Size = new System.Drawing.Size(157, 47);
            this.guiLoad.TabIndex = 40;
            this.guiLoad.Text = "0.000";
            this.guiLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "控制器实时曲线";
            // 
            // superTabControlPanel7
            // 
            this.superTabControlPanel7.Controls.Add(this.panelEx9);
            this.superTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel7.Location = new System.Drawing.Point(0, 52);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            this.superTabControlPanel7.Size = new System.Drawing.Size(1418, 707);
            this.superTabControlPanel7.TabIndex = 0;
            this.superTabControlPanel7.TabItem = this.superTabItem7;
            // 
            // panelEx9
            // 
            this.panelEx9.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx9.Controls.Add(this.guiDebug);
            this.panelEx9.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx9.Location = new System.Drawing.Point(0, 0);
            this.panelEx9.Name = "panelEx9";
            this.panelEx9.Size = new System.Drawing.Size(1418, 707);
            this.panelEx9.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx9.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx9.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx9.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx9.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx9.Style.GradientAngle = 90;
            this.panelEx9.TabIndex = 0;
            // 
            // guiDebug
            // 
            this.guiDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guiDebug.HideSelection = false;
            this.guiDebug.Location = new System.Drawing.Point(0, 0);
            this.guiDebug.Name = "guiDebug";
            this.guiDebug.ReadOnly = true;
            this.guiDebug.Size = new System.Drawing.Size(1418, 707);
            this.guiDebug.TabIndex = 1;
            this.guiDebug.Text = "Starting Communication\n";
            // 
            // superTabItem7
            // 
            this.superTabItem7.AttachedControl = this.superTabControlPanel7;
            this.superTabItem7.GlobalItem = false;
            this.superTabItem7.Name = "superTabItem7";
            this.superTabItem7.Text = "日志消息";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.superTabControlPanel1.Controls.Add(this.panelEx2);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 52);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1418, 707);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.panelEx7);
            this.panelEx2.Controls.Add(this.panelEx6);
            this.panelEx2.Controls.Add(this.superTabControl2);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1418, 707);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // panelEx7
            // 
            this.panelEx7.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx7.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx7.Location = new System.Drawing.Point(0, 0);
            this.panelEx7.Name = "panelEx7";
            this.panelEx7.Size = new System.Drawing.Size(1115, 547);
            this.panelEx7.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx7.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx7.Style.GradientAngle = 90;
            this.panelEx7.TabIndex = 6;
            // 
            // panelEx6
            // 
            this.panelEx6.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx6.Controls.Add(this.groupPanel1);
            this.panelEx6.Controls.Add(this.buttonX1);
            this.panelEx6.Controls.Add(this.textBoxX7);
            this.panelEx6.Controls.Add(this.textBoxX6);
            this.panelEx6.Controls.Add(this.textBoxX5);
            this.panelEx6.Controls.Add(this.textBoxX3);
            this.panelEx6.Controls.Add(this.textBoxX1);
            this.panelEx6.Controls.Add(this.textBoxX4);
            this.panelEx6.Controls.Add(this.textBoxX2);
            this.panelEx6.Controls.Add(this.comboBoxEx6);
            this.panelEx6.Controls.Add(this.comboBoxEx5);
            this.panelEx6.Controls.Add(this.comboBoxEx4);
            this.panelEx6.Controls.Add(this.comboBoxEx3);
            this.panelEx6.Controls.Add(this.comboBoxEx2);
            this.panelEx6.Controls.Add(this.dateTimeInput1);
            this.panelEx6.Controls.Add(this.comboBoxEx1);
            this.panelEx6.Controls.Add(this.labelX17);
            this.panelEx6.Controls.Add(this.labelX15);
            this.panelEx6.Controls.Add(this.labelX16);
            this.panelEx6.Controls.Add(this.labelX14);
            this.panelEx6.Controls.Add(this.labelX12);
            this.panelEx6.Controls.Add(this.labelX9);
            this.panelEx6.Controls.Add(this.labelX13);
            this.panelEx6.Controls.Add(this.labelX6);
            this.panelEx6.Controls.Add(this.labelX3);
            this.panelEx6.Controls.Add(this.labelX11);
            this.panelEx6.Controls.Add(this.labelX8);
            this.panelEx6.Controls.Add(this.labelX5);
            this.panelEx6.Controls.Add(this.labelX2);
            this.panelEx6.Controls.Add(this.labelX10);
            this.panelEx6.Controls.Add(this.labelX7);
            this.panelEx6.Controls.Add(this.labelX4);
            this.panelEx6.Controls.Add(this.labelX1);
            this.panelEx6.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx6.Location = new System.Drawing.Point(0, 547);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(1115, 160);
            this.panelEx6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx6.Style.GradientAngle = 90;
            this.panelEx6.TabIndex = 2;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX23);
            this.groupPanel1.Controls.Add(this.labelX22);
            this.groupPanel1.Controls.Add(this.labelX21);
            this.groupPanel1.Controls.Add(this.labelX18);
            this.groupPanel1.Controls.Add(this.labelX20);
            this.groupPanel1.Controls.Add(this.labelX19);
            this.groupPanel1.Controls.Add(this.textBoxX10);
            this.groupPanel1.Controls.Add(this.textBoxX8);
            this.groupPanel1.Controls.Add(this.textBoxX9);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(914, 53);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(200, 107);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 6;
            this.groupPanel1.Text = "计算刚度";
            // 
            // labelX23
            // 
            // 
            // 
            // 
            this.labelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX23.Location = new System.Drawing.Point(139, 61);
            this.labelX23.Name = "labelX23";
            this.labelX23.Size = new System.Drawing.Size(57, 23);
            this.labelX23.TabIndex = 0;
            this.labelX23.Text = "N.m/°";
            // 
            // labelX22
            // 
            // 
            // 
            // 
            this.labelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX22.Location = new System.Drawing.Point(139, 32);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(42, 23);
            this.labelX22.TabIndex = 0;
            this.labelX22.Text = "N.m";
            // 
            // labelX21
            // 
            // 
            // 
            // 
            this.labelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX21.Location = new System.Drawing.Point(139, 3);
            this.labelX21.Name = "labelX21";
            this.labelX21.Size = new System.Drawing.Size(42, 23);
            this.labelX21.TabIndex = 0;
            this.labelX21.Text = "N.m";
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX18.Location = new System.Drawing.Point(3, 3);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(70, 23);
            this.labelX18.TabIndex = 0;
            this.labelX18.Text = "第一点 T1";
            // 
            // labelX20
            // 
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX20.Location = new System.Drawing.Point(3, 61);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(64, 23);
            this.labelX20.TabIndex = 0;
            this.labelX20.Text = "刚度";
            // 
            // labelX19
            // 
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX19.Location = new System.Drawing.Point(3, 32);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(70, 23);
            this.labelX19.TabIndex = 0;
            this.labelX19.Text = "第二点 T2";
            // 
            // textBoxX10
            // 
            // 
            // 
            // 
            this.textBoxX10.Border.Class = "TextBoxBorder";
            this.textBoxX10.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX10.Location = new System.Drawing.Point(78, 61);
            this.textBoxX10.Name = "textBoxX10";
            this.textBoxX10.PreventEnterBeep = true;
            this.textBoxX10.Size = new System.Drawing.Size(55, 23);
            this.textBoxX10.TabIndex = 4;
            // 
            // textBoxX8
            // 
            // 
            // 
            // 
            this.textBoxX8.Border.Class = "TextBoxBorder";
            this.textBoxX8.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX8.Location = new System.Drawing.Point(78, 3);
            this.textBoxX8.Name = "textBoxX8";
            this.textBoxX8.PreventEnterBeep = true;
            this.textBoxX8.Size = new System.Drawing.Size(55, 23);
            this.textBoxX8.TabIndex = 4;
            // 
            // textBoxX9
            // 
            // 
            // 
            // 
            this.textBoxX9.Border.Class = "TextBoxBorder";
            this.textBoxX9.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX9.Location = new System.Drawing.Point(78, 32);
            this.textBoxX9.Name = "textBoxX9";
            this.textBoxX9.PreventEnterBeep = true;
            this.textBoxX9.Size = new System.Drawing.Size(55, 23);
            this.textBoxX9.TabIndex = 4;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(749, 60);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(141, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = "存储";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // textBoxX7
            // 
            // 
            // 
            // 
            this.textBoxX7.Border.Class = "TextBoxBorder";
            this.textBoxX7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX7.Location = new System.Drawing.Point(800, 122);
            this.textBoxX7.Name = "textBoxX7";
            this.textBoxX7.PreventEnterBeep = true;
            this.textBoxX7.Size = new System.Drawing.Size(60, 23);
            this.textBoxX7.TabIndex = 4;
            // 
            // textBoxX6
            // 
            // 
            // 
            // 
            this.textBoxX6.Border.Class = "TextBoxBorder";
            this.textBoxX6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX6.Location = new System.Drawing.Point(800, 96);
            this.textBoxX6.Name = "textBoxX6";
            this.textBoxX6.PreventEnterBeep = true;
            this.textBoxX6.Size = new System.Drawing.Size(90, 23);
            this.textBoxX6.TabIndex = 4;
            // 
            // textBoxX5
            // 
            // 
            // 
            // 
            this.textBoxX5.Border.Class = "TextBoxBorder";
            this.textBoxX5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX5.Location = new System.Drawing.Point(604, 120);
            this.textBoxX5.Name = "textBoxX5";
            this.textBoxX5.PreventEnterBeep = true;
            this.textBoxX5.Size = new System.Drawing.Size(61, 23);
            this.textBoxX5.TabIndex = 4;
            // 
            // textBoxX3
            // 
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX3.Location = new System.Drawing.Point(430, 91);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.PreventEnterBeep = true;
            this.textBoxX3.Size = new System.Drawing.Size(98, 23);
            this.textBoxX3.TabIndex = 4;
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX1.Location = new System.Drawing.Point(430, 58);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(98, 23);
            this.textBoxX1.TabIndex = 4;
            // 
            // textBoxX4
            // 
            // 
            // 
            // 
            this.textBoxX4.Border.Class = "TextBoxBorder";
            this.textBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX4.Location = new System.Drawing.Point(256, 124);
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.PreventEnterBeep = true;
            this.textBoxX4.Size = new System.Drawing.Size(71, 23);
            this.textBoxX4.TabIndex = 4;
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX2.Location = new System.Drawing.Point(82, 124);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.Size = new System.Drawing.Size(97, 23);
            this.textBoxX2.TabIndex = 4;
            // 
            // comboBoxEx6
            // 
            this.comboBoxEx6.DisplayMember = "Text";
            this.comboBoxEx6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx6.FormattingEnabled = true;
            this.comboBoxEx6.ItemHeight = 18;
            this.comboBoxEx6.Location = new System.Drawing.Point(604, 92);
            this.comboBoxEx6.Name = "comboBoxEx6";
            this.comboBoxEx6.Size = new System.Drawing.Size(120, 24);
            this.comboBoxEx6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx6.TabIndex = 2;
            // 
            // comboBoxEx5
            // 
            this.comboBoxEx5.DisplayMember = "Text";
            this.comboBoxEx5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx5.FormattingEnabled = true;
            this.comboBoxEx5.ItemHeight = 18;
            this.comboBoxEx5.Location = new System.Drawing.Point(604, 59);
            this.comboBoxEx5.Name = "comboBoxEx5";
            this.comboBoxEx5.Size = new System.Drawing.Size(120, 24);
            this.comboBoxEx5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx5.TabIndex = 2;
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 18;
            this.comboBoxEx4.Location = new System.Drawing.Point(430, 120);
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(98, 24);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 2;
            // 
            // comboBoxEx3
            // 
            this.comboBoxEx3.DisplayMember = "Text";
            this.comboBoxEx3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx3.FormattingEnabled = true;
            this.comboBoxEx3.ItemHeight = 18;
            this.comboBoxEx3.Location = new System.Drawing.Point(256, 58);
            this.comboBoxEx3.Name = "comboBoxEx3";
            this.comboBoxEx3.Size = new System.Drawing.Size(98, 24);
            this.comboBoxEx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx3.TabIndex = 2;
            // 
            // comboBoxEx2
            // 
            this.comboBoxEx2.DisplayMember = "Text";
            this.comboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx2.FormattingEnabled = true;
            this.comboBoxEx2.ItemHeight = 18;
            this.comboBoxEx2.Location = new System.Drawing.Point(82, 91);
            this.comboBoxEx2.Name = "comboBoxEx2";
            this.comboBoxEx2.Size = new System.Drawing.Size(98, 24);
            this.comboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx2.TabIndex = 2;
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(256, 89);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2025, 2, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(98, 23);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 3;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 18;
            this.comboBoxEx1.Location = new System.Drawing.Point(82, 58);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(98, 24);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 2;
            // 
            // labelX17
            // 
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX17.Location = new System.Drawing.Point(866, 122);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(42, 23);
            this.labelX17.TabIndex = 0;
            this.labelX17.Text = "(°)";
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX15.Location = new System.Drawing.Point(964, 96);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(33, 23);
            this.labelX15.TabIndex = 0;
            this.labelX15.Text = "N.m";
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX16.Location = new System.Drawing.Point(670, 120);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(124, 23);
            this.labelX16.TabIndex = 0;
            this.labelX16.Text = "最大扭矩时的角度";
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX14.Location = new System.Drawing.Point(730, 96);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(64, 23);
            this.labelX14.TabIndex = 0;
            this.labelX14.Text = "最大扭矩";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX12.Location = new System.Drawing.Point(534, 120);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(64, 23);
            this.labelX12.TabIndex = 0;
            this.labelX12.Text = "额定扭矩";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX9.Location = new System.Drawing.Point(360, 121);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(64, 23);
            this.labelX9.TabIndex = 0;
            this.labelX9.Text = "试验依据";
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX13.Location = new System.Drawing.Point(333, 122);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(29, 23);
            this.labelX13.TabIndex = 0;
            this.labelX13.Text = "℃";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.Location = new System.Drawing.Point(186, 124);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(64, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "试验温度";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(12, 124);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(64, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "试验装置";
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX11.Location = new System.Drawing.Point(534, 91);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(64, 23);
            this.labelX11.TabIndex = 0;
            this.labelX11.Text = "破坏情况";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX8.Location = new System.Drawing.Point(360, 93);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(64, 23);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "校核人员";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(186, 92);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(64, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "试验日期";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(12, 92);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(64, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "汽车型号";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX10.Location = new System.Drawing.Point(534, 60);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(64, 23);
            this.labelX10.TabIndex = 0;
            this.labelX10.Text = "破坏位置";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX7.Location = new System.Drawing.Point(360, 60);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(64, 23);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "试验人员";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(186, 59);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(64, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "试验目的";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(12, 59);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(64, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "试验样品";
            // 
            // superTabControl2
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl2.ControlBox.MenuBox.Name = "";
            this.superTabControl2.ControlBox.Name = "";
            this.superTabControl2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl2.ControlBox.MenuBox,
            this.superTabControl2.ControlBox.CloseBox});
            this.superTabControl2.Controls.Add(this.superTabControlPanel3);
            this.superTabControl2.Controls.Add(this.superTabControlPanel4);
            this.superTabControl2.Controls.Add(this.superTabControlPanel5);
            this.superTabControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.superTabControl2.Location = new System.Drawing.Point(1115, 0);
            this.superTabControl2.Name = "superTabControl2";
            this.superTabControl2.ReorderTabsEnabled = true;
            this.superTabControl2.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl2.SelectedTabIndex = 0;
            this.superTabControl2.Size = new System.Drawing.Size(303, 707);
            this.superTabControl2.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl2.TabIndex = 0;
            this.superTabControl2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem3,
            this.superTabItem4,
            this.superTabItem5});
            this.superTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Document;
            this.superTabControl2.Text = "superTabControl2";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.panelEx3);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(303, 682);
            this.superTabControlPanel3.TabIndex = 1;
            this.superTabControlPanel3.TabItem = this.superTabItem3;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.buttonX14);
            this.panelEx3.Controls.Add(this.superTabControl3);
            this.panelEx3.Controls.Add(this.groupPanel3);
            this.panelEx3.Controls.Add(this.buttonX13);
            this.panelEx3.Controls.Add(this.groupPanel2);
            this.panelEx3.Controls.Add(this.slider1);
            this.panelEx3.Controls.Add(this.labelX28);
            this.panelEx3.Controls.Add(this.labelX27);
            this.panelEx3.Controls.Add(this.labelX26);
            this.panelEx3.Controls.Add(this.labelX25);
            this.panelEx3.Controls.Add(this.labelX24);
            this.panelEx3.Controls.Add(this.textBoxX11);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(303, 682);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 0;
            // 
            // buttonX14
            // 
            this.buttonX14.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX14.BackColor = System.Drawing.Color.Transparent;
            this.buttonX14.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX14.Location = new System.Drawing.Point(157, 392);
            this.buttonX14.Name = "buttonX14";
            this.buttonX14.Size = new System.Drawing.Size(114, 66);
            this.buttonX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX14.TabIndex = 5;
            this.buttonX14.Text = "试验结束";
            // 
            // superTabControl3
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl3.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl3.ControlBox.MenuBox.Name = "";
            this.superTabControl3.ControlBox.Name = "";
            this.superTabControl3.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl3.ControlBox.MenuBox,
            this.superTabControl3.ControlBox.CloseBox});
            this.superTabControl3.Controls.Add(this.superTabControlPanel6);
            this.superTabControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.superTabControl3.Location = new System.Drawing.Point(0, 572);
            this.superTabControl3.Name = "superTabControl3";
            this.superTabControl3.ReorderTabsEnabled = false;
            this.superTabControl3.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl3.SelectedTabIndex = 0;
            this.superTabControl3.Size = new System.Drawing.Size(303, 110);
            this.superTabControl3.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
            this.superTabControl3.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl3.TabIndex = 7;
            this.superTabControl3.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem6});
            this.superTabControl3.Text = "superTabControl3";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.panelEx8);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(303, 85);
            this.superTabControlPanel6.TabIndex = 1;
            this.superTabControlPanel6.TabItem = this.superTabItem6;
            // 
            // panelEx8
            // 
            this.panelEx8.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx8.Controls.Add(this.labelX30);
            this.panelEx8.Controls.Add(this.labelX32);
            this.panelEx8.Controls.Add(this.textBoxX12);
            this.panelEx8.Controls.Add(this.labelX31);
            this.panelEx8.Controls.Add(this.textBoxX13);
            this.panelEx8.Controls.Add(this.labelX29);
            this.panelEx8.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx8.Location = new System.Drawing.Point(0, 0);
            this.panelEx8.Name = "panelEx8";
            this.panelEx8.Size = new System.Drawing.Size(303, 85);
            this.panelEx8.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx8.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx8.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx8.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx8.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx8.Style.GradientAngle = 90;
            this.panelEx8.TabIndex = 0;
            // 
            // labelX30
            // 
            // 
            // 
            // 
            this.labelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX30.Location = new System.Drawing.Point(19, 15);
            this.labelX30.Name = "labelX30";
            this.labelX30.Size = new System.Drawing.Size(81, 23);
            this.labelX30.TabIndex = 0;
            this.labelX30.Text = "角速度：";
            // 
            // labelX32
            // 
            // 
            // 
            // 
            this.labelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX32.Location = new System.Drawing.Point(200, 44);
            this.labelX32.Name = "labelX32";
            this.labelX32.Size = new System.Drawing.Size(58, 23);
            this.labelX32.TabIndex = 0;
            this.labelX32.Text = "N.m/s";
            // 
            // textBoxX12
            // 
            // 
            // 
            // 
            this.textBoxX12.Border.Class = "TextBoxBorder";
            this.textBoxX12.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX12.Location = new System.Drawing.Point(106, 44);
            this.textBoxX12.Name = "textBoxX12";
            this.textBoxX12.PreventEnterBeep = true;
            this.textBoxX12.Size = new System.Drawing.Size(88, 23);
            this.textBoxX12.TabIndex = 4;
            // 
            // labelX31
            // 
            // 
            // 
            // 
            this.labelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX31.Location = new System.Drawing.Point(200, 15);
            this.labelX31.Name = "labelX31";
            this.labelX31.Size = new System.Drawing.Size(67, 23);
            this.labelX31.TabIndex = 0;
            this.labelX31.Text = "°/min";
            // 
            // textBoxX13
            // 
            // 
            // 
            // 
            this.textBoxX13.Border.Class = "TextBoxBorder";
            this.textBoxX13.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX13.Location = new System.Drawing.Point(106, 15);
            this.textBoxX13.Name = "textBoxX13";
            this.textBoxX13.PreventEnterBeep = true;
            this.textBoxX13.Size = new System.Drawing.Size(88, 23);
            this.textBoxX13.TabIndex = 4;
            // 
            // labelX29
            // 
            // 
            // 
            // 
            this.labelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX29.Location = new System.Drawing.Point(19, 44);
            this.labelX29.Name = "labelX29";
            this.labelX29.Size = new System.Drawing.Size(81, 23);
            this.labelX29.TabIndex = 0;
            this.labelX29.Text = "扭矩速度：";
            // 
            // superTabItem6
            // 
            this.superTabItem6.AttachedControl = this.superTabControlPanel6;
            this.superTabItem6.GlobalItem = false;
            this.superTabItem6.Name = "superTabItem6";
            this.superTabItem6.Text = "试验速度";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.buttonX17);
            this.groupPanel3.Controls.Add(this.buttonX20);
            this.groupPanel3.Controls.Add(this.buttonX23);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(6, 275);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(294, 99);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 6;
            this.groupPanel3.Text = "角度控制";
            // 
            // buttonX17
            // 
            this.buttonX17.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX17.BackColor = System.Drawing.Color.Transparent;
            this.buttonX17.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX17.Location = new System.Drawing.Point(194, 3);
            this.buttonX17.Name = "buttonX17";
            this.buttonX17.Size = new System.Drawing.Size(88, 66);
            this.buttonX17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX17.TabIndex = 5;
            this.buttonX17.Text = "反转";
            // 
            // buttonX20
            // 
            this.buttonX20.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX20.BackColor = System.Drawing.Color.Transparent;
            this.buttonX20.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX20.Location = new System.Drawing.Point(97, 3);
            this.buttonX20.Name = "buttonX20";
            this.buttonX20.Size = new System.Drawing.Size(88, 66);
            this.buttonX20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX20.TabIndex = 5;
            this.buttonX20.Text = "停止";
            // 
            // buttonX23
            // 
            this.buttonX23.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX23.BackColor = System.Drawing.Color.Transparent;
            this.buttonX23.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX23.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX23.Location = new System.Drawing.Point(3, 3);
            this.buttonX23.Name = "buttonX23";
            this.buttonX23.Size = new System.Drawing.Size(88, 66);
            this.buttonX23.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX23.TabIndex = 5;
            this.buttonX23.Text = "正转";
            // 
            // buttonX13
            // 
            this.buttonX13.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX13.BackColor = System.Drawing.Color.Transparent;
            this.buttonX13.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX13.Location = new System.Drawing.Point(36, 392);
            this.buttonX13.Name = "buttonX13";
            this.buttonX13.Size = new System.Drawing.Size(114, 66);
            this.buttonX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX13.TabIndex = 5;
            this.buttonX13.Text = "试验开始";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.buttonX9);
            this.groupPanel2.Controls.Add(this.buttonX5);
            this.groupPanel2.Controls.Add(this.buttonX12);
            this.groupPanel2.Controls.Add(this.buttonX8);
            this.groupPanel2.Controls.Add(this.buttonX4);
            this.groupPanel2.Controls.Add(this.buttonX11);
            this.groupPanel2.Controls.Add(this.buttonX7);
            this.groupPanel2.Controls.Add(this.buttonX3);
            this.groupPanel2.Controls.Add(this.buttonX10);
            this.groupPanel2.Controls.Add(this.buttonX6);
            this.groupPanel2.Controls.Add(this.buttonX2);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(6, 122);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(294, 147);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 6;
            this.groupPanel2.Text = "角速度";
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.BackColor = System.Drawing.Color.Transparent;
            this.buttonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX9.Location = new System.Drawing.Point(219, 43);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.Size = new System.Drawing.Size(66, 34);
            this.buttonX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX9.TabIndex = 5;
            this.buttonX9.Text = "100";
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.BackColor = System.Drawing.Color.Transparent;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX5.Location = new System.Drawing.Point(219, 3);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(66, 34);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.TabIndex = 5;
            this.buttonX5.Text = "5";
            // 
            // buttonX12
            // 
            this.buttonX12.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX12.BackColor = System.Drawing.Color.Transparent;
            this.buttonX12.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX12.Location = new System.Drawing.Point(147, 83);
            this.buttonX12.Name = "buttonX12";
            this.buttonX12.Size = new System.Drawing.Size(66, 34);
            this.buttonX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX12.TabIndex = 5;
            this.buttonX12.Text = "540";
            // 
            // buttonX8
            // 
            this.buttonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX8.BackColor = System.Drawing.Color.Transparent;
            this.buttonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX8.Location = new System.Drawing.Point(147, 43);
            this.buttonX8.Name = "buttonX8";
            this.buttonX8.Size = new System.Drawing.Size(66, 34);
            this.buttonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX8.TabIndex = 5;
            this.buttonX8.Text = "50";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.BackColor = System.Drawing.Color.Transparent;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX4.Location = new System.Drawing.Point(147, 3);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(66, 34);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 5;
            this.buttonX4.Text = "2";
            // 
            // buttonX11
            // 
            this.buttonX11.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX11.BackColor = System.Drawing.Color.Transparent;
            this.buttonX11.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX11.Location = new System.Drawing.Point(75, 83);
            this.buttonX11.Name = "buttonX11";
            this.buttonX11.Size = new System.Drawing.Size(66, 34);
            this.buttonX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX11.TabIndex = 5;
            this.buttonX11.Text = "500";
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.BackColor = System.Drawing.Color.Transparent;
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX7.Location = new System.Drawing.Point(75, 43);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(66, 34);
            this.buttonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX7.TabIndex = 5;
            this.buttonX7.Text = "20";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.Color.Transparent;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX3.Location = new System.Drawing.Point(75, 3);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(66, 34);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 5;
            this.buttonX3.Text = "1";
            // 
            // buttonX10
            // 
            this.buttonX10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX10.BackColor = System.Drawing.Color.Transparent;
            this.buttonX10.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX10.Location = new System.Drawing.Point(3, 83);
            this.buttonX10.Name = "buttonX10";
            this.buttonX10.Size = new System.Drawing.Size(66, 34);
            this.buttonX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX10.TabIndex = 5;
            this.buttonX10.Text = "200";
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.BackColor = System.Drawing.Color.Transparent;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX6.Location = new System.Drawing.Point(3, 43);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(66, 34);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 5;
            this.buttonX6.Text = "10";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.Transparent;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX2.Location = new System.Drawing.Point(3, 3);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(66, 34);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 5;
            this.buttonX2.Text = "0.5";
            // 
            // slider1
            // 
            // 
            // 
            // 
            this.slider1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.slider1.Location = new System.Drawing.Point(-16, 64);
            this.slider1.Minimum = 20;
            this.slider1.Name = "slider1";
            this.slider1.Size = new System.Drawing.Size(307, 23);
            this.slider1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.slider1.TabIndex = 5;
            this.slider1.Value = 20;
            // 
            // labelX28
            // 
            // 
            // 
            // 
            this.labelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX28.Location = new System.Drawing.Point(256, 93);
            this.labelX28.Name = "labelX28";
            this.labelX28.Size = new System.Drawing.Size(44, 23);
            this.labelX28.TabIndex = 0;
            this.labelX28.Text = "100.0";
            // 
            // labelX27
            // 
            // 
            // 
            // 
            this.labelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX27.Location = new System.Drawing.Point(26, 93);
            this.labelX27.Name = "labelX27";
            this.labelX27.Size = new System.Drawing.Size(35, 23);
            this.labelX27.TabIndex = 0;
            this.labelX27.Text = "20.0";
            // 
            // labelX26
            // 
            // 
            // 
            // 
            this.labelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX26.Location = new System.Drawing.Point(180, 17);
            this.labelX26.Name = "labelX26";
            this.labelX26.Size = new System.Drawing.Size(64, 23);
            this.labelX26.TabIndex = 0;
            this.labelX26.Text = "°/min";
            // 
            // labelX25
            // 
            // 
            // 
            // 
            this.labelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX25.Location = new System.Drawing.Point(180, 14);
            this.labelX25.Name = "labelX25";
            this.labelX25.Size = new System.Drawing.Size(64, 23);
            this.labelX25.TabIndex = 0;
            this.labelX25.Text = "角速度：";
            // 
            // labelX24
            // 
            // 
            // 
            // 
            this.labelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX24.Location = new System.Drawing.Point(6, 17);
            this.labelX24.Name = "labelX24";
            this.labelX24.Size = new System.Drawing.Size(64, 23);
            this.labelX24.TabIndex = 0;
            this.labelX24.Text = "角速度：";
            // 
            // textBoxX11
            // 
            // 
            // 
            // 
            this.textBoxX11.Border.Class = "TextBoxBorder";
            this.textBoxX11.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX11.Location = new System.Drawing.Point(76, 17);
            this.textBoxX11.Name = "textBoxX11";
            this.textBoxX11.PreventEnterBeep = true;
            this.textBoxX11.Size = new System.Drawing.Size(98, 23);
            this.textBoxX11.TabIndex = 4;
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.superTabControlPanel3;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Text = "角度控制";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.panelEx4);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 36);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(303, 566);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.superTabItem4;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx4.Location = new System.Drawing.Point(0, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(303, 566);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 4;
            // 
            // superTabItem4
            // 
            this.superTabItem4.AttachedControl = this.superTabControlPanel4;
            this.superTabItem4.GlobalItem = false;
            this.superTabItem4.Name = "superTabItem4";
            this.superTabItem4.Text = "单步控制";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.panelEx5);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(303, 542);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.superTabItem5;
            // 
            // panelEx5
            // 
            this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx5.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx5.Location = new System.Drawing.Point(0, 0);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(303, 542);
            this.panelEx5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx5.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx5.Style.GradientAngle = 90;
            this.panelEx5.TabIndex = 4;
            // 
            // superTabItem5
            // 
            this.superTabItem5.AttachedControl = this.superTabControlPanel5;
            this.superTabItem5.GlobalItem = false;
            this.superTabItem5.Name = "superTabItem5";
            this.superTabItem5.Text = "程控试验";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "试验数据";
            this.superTabItem1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Oper,
            this.ToolStripMenuItem_Setting,
            this.ToolStripMenuItem_Data,
            this.ToolStripMenuItem_Result,
            this.ToolStripMenuItem_Language,
            this.ToolStripMenuItem_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1418, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_Oper
            // 
            this.ToolStripMenuItem_Oper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Login,
            this.试验数据回访ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.ToolStripMenuItem_Oper.Name = "ToolStripMenuItem_Oper";
            this.ToolStripMenuItem_Oper.Size = new System.Drawing.Size(76, 20);
            this.ToolStripMenuItem_Oper.Text = "操作(&O)";
            // 
            // ToolStripMenuItem_Login
            // 
            this.ToolStripMenuItem_Login.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_Login.Image")));
            this.ToolStripMenuItem_Login.Name = "ToolStripMenuItem_Login";
            this.ToolStripMenuItem_Login.Size = new System.Drawing.Size(172, 22);
            this.ToolStripMenuItem_Login.Text = "登录...(&L)";
            this.ToolStripMenuItem_Login.Visible = false;
            this.ToolStripMenuItem_Login.Click += new System.EventHandler(this.ToolStripMenuItem_Login_Click);
            // 
            // 试验数据回访ToolStripMenuItem
            // 
            this.试验数据回访ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("试验数据回访ToolStripMenuItem.Image")));
            this.试验数据回访ToolStripMenuItem.Name = "试验数据回访ToolStripMenuItem";
            this.试验数据回访ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.试验数据回访ToolStripMenuItem.Text = "试验数据回放";
            this.试验数据回访ToolStripMenuItem.Visible = false;
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出ToolStripMenuItem.Image")));
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.退出ToolStripMenuItem.Text = "退出(&Q)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Setting
            // 
            this.ToolStripMenuItem_Setting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_SystemSetting});
            this.ToolStripMenuItem_Setting.Name = "ToolStripMenuItem_Setting";
            this.ToolStripMenuItem_Setting.Size = new System.Drawing.Size(108, 20);
            this.ToolStripMenuItem_Setting.Text = "参数设置(&S)";
            this.ToolStripMenuItem_Setting.Click += new System.EventHandler(this.ToolStripMenuItem_Setting_Click);
            // 
            // ToolStripMenuItem_SystemSetting
            // 
            this.ToolStripMenuItem_SystemSetting.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_SystemSetting.Image")));
            this.ToolStripMenuItem_SystemSetting.Name = "ToolStripMenuItem_SystemSetting";
            this.ToolStripMenuItem_SystemSetting.Size = new System.Drawing.Size(188, 22);
            this.ToolStripMenuItem_SystemSetting.Text = "系统设置...(&S)";
            this.ToolStripMenuItem_SystemSetting.Visible = false;
            this.ToolStripMenuItem_SystemSetting.Click += new System.EventHandler(this.ToolStripMenuItem_SystemSetting_Click);
            // 
            // ToolStripMenuItem_Data
            // 
            this.ToolStripMenuItem_Data.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_OpenLogsDir,
            this.保存数据问题及ToolStripMenuItem,
            this.toolStripSeparator1,
            this.保存当前曲线ToolStripMenuItem});
            this.ToolStripMenuItem_Data.Name = "ToolStripMenuItem_Data";
            this.ToolStripMenuItem_Data.Size = new System.Drawing.Size(108, 20);
            this.ToolStripMenuItem_Data.Text = "试验数据(&D)";
            // 
            // ToolStripMenuItem_OpenLogsDir
            // 
            this.ToolStripMenuItem_OpenLogsDir.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_OpenLogsDir.Image")));
            this.ToolStripMenuItem_OpenLogsDir.Name = "ToolStripMenuItem_OpenLogsDir";
            this.ToolStripMenuItem_OpenLogsDir.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItem_OpenLogsDir.Text = "打开数据文件(&O)";
            this.ToolStripMenuItem_OpenLogsDir.Click += new System.EventHandler(this.ToolStripMenuItem_OpenLogsDir_Click);
            // 
            // 保存数据问题及ToolStripMenuItem
            // 
            this.保存数据问题及ToolStripMenuItem.Name = "保存数据问题及ToolStripMenuItem";
            this.保存数据问题及ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.保存数据问题及ToolStripMenuItem.Text = "保存数据文件";
            this.保存数据问题及ToolStripMenuItem.Visible = false;
            this.保存数据问题及ToolStripMenuItem.Click += new System.EventHandler(this.保存数据问题及ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // 保存当前曲线ToolStripMenuItem
            // 
            this.保存当前曲线ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存当前曲线ToolStripMenuItem.Image")));
            this.保存当前曲线ToolStripMenuItem.Name = "保存当前曲线ToolStripMenuItem";
            this.保存当前曲线ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.保存当前曲线ToolStripMenuItem.Text = "保存当前曲线";
            this.保存当前曲线ToolStripMenuItem.Visible = false;
            // 
            // ToolStripMenuItem_Result
            // 
            this.ToolStripMenuItem_Result.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拷贝当前曲线ToolStripMenuItem,
            this.打印当前曲线ToolStripMenuItem});
            this.ToolStripMenuItem_Result.Name = "ToolStripMenuItem_Result";
            this.ToolStripMenuItem_Result.Size = new System.Drawing.Size(108, 20);
            this.ToolStripMenuItem_Result.Text = "试验结果(&R)";
            this.ToolStripMenuItem_Result.Visible = false;
            // 
            // 拷贝当前曲线ToolStripMenuItem
            // 
            this.拷贝当前曲线ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("拷贝当前曲线ToolStripMenuItem.Image")));
            this.拷贝当前曲线ToolStripMenuItem.Name = "拷贝当前曲线ToolStripMenuItem";
            this.拷贝当前曲线ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.拷贝当前曲线ToolStripMenuItem.Text = "拷贝当前曲线(&C)";
            this.拷贝当前曲线ToolStripMenuItem.Visible = false;
            // 
            // 打印当前曲线ToolStripMenuItem
            // 
            this.打印当前曲线ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打印当前曲线ToolStripMenuItem.Image")));
            this.打印当前曲线ToolStripMenuItem.Name = "打印当前曲线ToolStripMenuItem";
            this.打印当前曲线ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.打印当前曲线ToolStripMenuItem.Text = "打印当前曲线(&P)";
            this.打印当前曲线ToolStripMenuItem.Visible = false;
            // 
            // ToolStripMenuItem_Language
            // 
            this.ToolStripMenuItem_Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_OpenLangDir});
            this.ToolStripMenuItem_Language.Name = "ToolStripMenuItem_Language";
            this.ToolStripMenuItem_Language.Size = new System.Drawing.Size(108, 20);
            this.ToolStripMenuItem_Language.Text = "界面语言(&L)";
            // 
            // ToolStripMenuItem_OpenLangDir
            // 
            this.ToolStripMenuItem_OpenLangDir.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_OpenLangDir.Image")));
            this.ToolStripMenuItem_OpenLangDir.Name = "ToolStripMenuItem_OpenLangDir";
            this.ToolStripMenuItem_OpenLangDir.Size = new System.Drawing.Size(212, 22);
            this.ToolStripMenuItem_OpenLangDir.Text = "打开多语言目录(&D)";
            this.ToolStripMenuItem_OpenLangDir.Click += new System.EventHandler(this.ToolStripMenuItem_OpenLangDir_Click);
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Adout});
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(76, 20);
            this.ToolStripMenuItem_Help.Text = "帮助(&H)";
            // 
            // ToolStripMenuItem_Adout
            // 
            this.ToolStripMenuItem_Adout.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem_Adout.Image")));
            this.ToolStripMenuItem_Adout.Name = "ToolStripMenuItem_Adout";
            this.ToolStripMenuItem_Adout.Size = new System.Drawing.Size(132, 22);
            this.ToolStripMenuItem_Adout.Text = "关于(&A)";
            this.ToolStripMenuItem_Adout.Click += new System.EventHandler(this.ToolStripMenuItem_About_Click);
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.contextMenuBar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.contextMenuBar1.IsMaximized = false;
            this.contextMenuBar1.Location = new System.Drawing.Point(478, -11);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(75, 24);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.TabIndex = 0;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "contextMenuBar1";
            // 
            // timer_UpdateData
            // 
            this.timer_UpdateData.Tick += new System.EventHandler(this.timer_UpdateData_Tick);
            // 
            // timer_ShowWave
            // 
            this.timer_ShowWave.Tick += new System.EventHandler(this.timer_ShowWave_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(632, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = " [N] ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 759);
            this.Controls.Add(this.superTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoPE10NetConnect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControl1.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelEx10.ResumeLayout(false);
            this.panelEx10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_machine)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.pl_DataShow.ResumeLayout(false);
            this.pl_DataShow.PerformLayout();
            this.superTabControlPanel7.ResumeLayout(false);
            this.panelEx9.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx6.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).EndInit();
            this.superTabControl2.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl3)).EndInit();
            this.superTabControl3.ResumeLayout(false);
            this.superTabControlPanel6.ResumeLayout(false);
            this.panelEx8.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.superTabControlPanel4.ResumeLayout(false);
            this.superTabControlPanel5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Timer StartCommunicationWithEdcTimer;
        private DevComponents.DotNetBar.SuperTabItem 试验数据;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox guiExtension;
        private System.Windows.Forms.TextBox guiTime;
        private System.Windows.Forms.TextBox guiLoad;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox guiPosition;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.Label lblExtension;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Oper;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Setting;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Data;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Result;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Login;
        private System.Windows.Forms.ToolStripMenuItem 试验数据回访ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenLogsDir;
        private System.Windows.Forms.ToolStripMenuItem 保存数据问题及ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 保存当前曲线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拷贝当前曲线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印当前曲线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Adout;
        private DevComponents.DotNetBar.SuperTabControl superTabControl2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.SuperTabItem superTabItem3;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private DevComponents.DotNetBar.PanelEx panelEx5;
        private DevComponents.DotNetBar.SuperTabItem superTabItem5;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.SuperTabItem superTabItem4;
        private DevComponents.DotNetBar.PanelEx panelEx6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx3;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX4;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx5;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX6;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX7;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labelX23;
        private DevComponents.DotNetBar.LabelX labelX22;
        private DevComponents.DotNetBar.LabelX labelX21;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX10;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX8;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX9;
        private DevComponents.DotNetBar.PanelEx panelEx7;
        private DevComponents.DotNetBar.LabelX labelX24;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX11;
        private DevComponents.DotNetBar.LabelX labelX26;
        private DevComponents.DotNetBar.LabelX labelX25;
        private DevComponents.DotNetBar.Controls.Slider slider1;
        private DevComponents.DotNetBar.LabelX labelX28;
        private DevComponents.DotNetBar.LabelX labelX27;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX9;
        private DevComponents.DotNetBar.ButtonX buttonX12;
        private DevComponents.DotNetBar.ButtonX buttonX8;
        private DevComponents.DotNetBar.ButtonX buttonX11;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.ButtonX buttonX10;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX buttonX17;
        private DevComponents.DotNetBar.ButtonX buttonX20;
        private DevComponents.DotNetBar.ButtonX buttonX23;
        private DevComponents.DotNetBar.SuperTabControl superTabControl3;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel6;
        private DevComponents.DotNetBar.SuperTabItem superTabItem6;
        private DevComponents.DotNetBar.PanelEx panelEx8;
        private DevComponents.DotNetBar.LabelX labelX30;
        private DevComponents.DotNetBar.LabelX labelX32;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX12;
        private DevComponents.DotNetBar.LabelX labelX31;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX13;
        private DevComponents.DotNetBar.LabelX labelX29;
        private DevComponents.DotNetBar.ButtonX buttonX14;
        private DevComponents.DotNetBar.ButtonX buttonX13;
        private System.Windows.Forms.Timer timer_UpdateData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pl_DataShow;
        private DevComponents.DotNetBar.ButtonX btnX_Connect;
        private DevComponents.DotNetBar.ButtonX btnX_Disconnect;
        private DevComponents.DotNetBar.ButtonX bntX_MoveDown;
        private DevComponents.DotNetBar.ButtonX bntX_MoveHalt;
        private DevComponents.DotNetBar.ButtonX bntX_MoveUp;
        private DevComponents.DotNetBar.ButtonX bntX_GUIOff;
        private DevComponents.DotNetBar.ButtonX bntX_GUIOn;
        private System.Windows.Forms.Button btn_ConState;
        private DevComponents.DotNetBar.ButtonX btnX_MoveQuickUp;
        private DevComponents.DotNetBar.ButtonX btnX_QuickMoveDown;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart_machine;
        private System.Windows.Forms.CheckBox cb_TarePos;
        private System.Windows.Forms.CheckBox cb_TareExt;
        private System.Windows.Forms.CheckBox cb_TareLoad;
        private System.Windows.Forms.Label lblPositionMaxMin;
        private System.Windows.Forms.TextBox tb_MaxPos;
        private System.Windows.Forms.TextBox tb_MinPos;
        private System.Windows.Forms.Label lblPositionMaxValue;
        private System.Windows.Forms.Label lblPositionMinValue;
        private System.Windows.Forms.Label lblLoadMinValue;
        private System.Windows.Forms.Label lblLoadMaxValue;
        private System.Windows.Forms.Label lblLoadMaxMin;
        private System.Windows.Forms.TextBox tb_MinLoad;
        private System.Windows.Forms.TextBox tb_MaxLoad;
        private System.Windows.Forms.Label lblExtensionMinValue;
        private System.Windows.Forms.Label lblExtensionMaxValue;
        private System.Windows.Forms.Label lblExtensionMaxMin;
        private System.Windows.Forms.TextBox tb_MinExt;
        private System.Windows.Forms.TextBox tb_MaxExt;
        private DevComponents.DotNetBar.ButtonX btnX_SetHigh;
        private DevComponents.DotNetBar.ButtonX btnX_SetLow;
        private System.Windows.Forms.Label lblTestCycles;
        private System.Windows.Forms.TextBox tbX_TestCycles;
        private DevComponents.DotNetBar.ButtonX btnX_AxisYMax;
        private DevComponents.DotNetBar.ButtonX btnX_AsixYMin;
        private System.Windows.Forms.CheckBox cb_DrawPosition;
        private System.Windows.Forms.CheckBox cb_DrawExtension;
        private System.Windows.Forms.CheckBox cb_DrawLoad;
        private System.Windows.Forms.CheckBox cb_DrawCommand;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel7;
        private DevComponents.DotNetBar.PanelEx panelEx9;
        private DevComponents.DotNetBar.SuperTabItem superTabItem7;
        private System.Windows.Forms.RichTextBox guiDebug;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SystemSetting;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevComponents.DotNetBar.PanelEx panelEx10;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posExtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posExtAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fMoveaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dynCyclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPeakCtrlValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPeakCtrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ext2CtrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sHaltToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem pcCmdFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem setOpenLoopCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem blockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haltWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haltWAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trigAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xpCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem synchronizeMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Pos_AtoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dynCtrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setBitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStopDrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Language;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenLangDir;
        private System.Windows.Forms.ToolStripMenuItem AdjustToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnX_AxisLoadY_MinUp;
        private DevComponents.DotNetBar.ButtonX btnX_AxisLoadY_MinDown;
        private DevComponents.DotNetBar.ButtonX btnX_AxisLoadY_MaxUp;
        private DevComponents.DotNetBar.ButtonX btnX_AxisLoadY_MaxDown;
        private DevComponents.DotNetBar.ButtonX btnX_AxisPOSY_MaxUp;
        private DevComponents.DotNetBar.ButtonX btnX_AxisPOSY_MaxDown;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbX_EDCName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_SystemTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private DevComponents.DotNetBar.Controls.Line line1;
        private System.Windows.Forms.ToolStripMenuItem ChartSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoSetYAxisToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.Line line2;
        private System.Windows.Forms.CheckBox cb_TareTime;
        private DevComponents.DotNetBar.LabelX labelX33;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbX_TestCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem MultiSensorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveStaticDataToolStripMenuItem;
        private System.Windows.Forms.Timer timer_ShowWave;
        private System.Windows.Forms.Label label3;
    }
}

