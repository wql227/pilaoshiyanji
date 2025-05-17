namespace DoPE10Net_CSharpDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StartCommunicationWithEdcTimer = new System.Windows.Forms.Timer(this.components);
            this.试验数据 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lightningChart1 = new Arction.WinForms.Charting.LightningChart();
            this.lbX_EDCName = new DevComponents.DotNetBar.LabelX();
            this.btn_ConState = new System.Windows.Forms.Button();
            this.buttonX15 = new DevComponents.DotNetBar.ButtonX();
            this.bntX_GUIPos = new DevComponents.DotNetBar.ButtonX();
            this.bntX_GUIOff = new DevComponents.DotNetBar.ButtonX();
            this.bntX_GUIOn = new DevComponents.DotNetBar.ButtonX();
            this.btnX_QuickMoveDown = new DevComponents.DotNetBar.ButtonX();
            this.bntX_MoveDown = new DevComponents.DotNetBar.ButtonX();
            this.bntX_MoveHalt = new DevComponents.DotNetBar.ButtonX();
            this.btnX_MoveQuickUp = new DevComponents.DotNetBar.ButtonX();
            this.bntX_MoveUp = new DevComponents.DotNetBar.ButtonX();
            this.btnX_Disconnect = new DevComponents.DotNetBar.ButtonX();
            this.btnX_Connect = new DevComponents.DotNetBar.ButtonX();
            this.lblDestinationUnit = new System.Windows.Forms.Label();
            this.lblSpeedUnit = new System.Windows.Forms.Label();
            this.guiDestination = new System.Windows.Forms.TextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblControl = new System.Windows.Forms.Label();
            this.guiSpeed = new System.Windows.Forms.TextBox();
            this.guiControl = new System.Windows.Forms.ComboBox();
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
            this.dynCtrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblExtension = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.guiPosition = new System.Windows.Forms.TextBox();
            this.guiExtension = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.guiTime = new System.Windows.Forms.TextBox();
            this.guiLoad = new System.Windows.Forms.TextBox();
            this.guiDebug = new System.Windows.Forms.RichTextBox();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
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
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.试验数据回访ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.试验操作选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统保护选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘图选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.试验数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开数据文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存数据问题及ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.保存当前曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.试验结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拷贝当前曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印当前曲线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.timer_UpdateData = new System.Windows.Forms.Timer(this.components);
            this.Pos_AtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbX_ScrollMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.menuStrip1);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = -1;
            this.superTabControl1.Size = new System.Drawing.Size(1418, 702);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 57;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2,
            this.superTabItem1});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.panelEx1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 52);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1418, 650);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panel2);
            this.panelEx1.Controls.Add(this.panel1);
            this.panelEx1.Controls.Add(this.guiDebug);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1418, 650);
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
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1127, 595);
            this.panel2.TabIndex = 57;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbX_ScrollMode);
            this.groupBox1.Controls.Add(this.lightningChart1);
            this.groupBox1.Controls.Add(this.lbX_EDCName);
            this.groupBox1.Controls.Add(this.btn_ConState);
            this.groupBox1.Controls.Add(this.buttonX15);
            this.groupBox1.Controls.Add(this.bntX_GUIPos);
            this.groupBox1.Controls.Add(this.bntX_GUIOff);
            this.groupBox1.Controls.Add(this.bntX_GUIOn);
            this.groupBox1.Controls.Add(this.btnX_QuickMoveDown);
            this.groupBox1.Controls.Add(this.bntX_MoveDown);
            this.groupBox1.Controls.Add(this.bntX_MoveHalt);
            this.groupBox1.Controls.Add(this.btnX_MoveQuickUp);
            this.groupBox1.Controls.Add(this.bntX_MoveUp);
            this.groupBox1.Controls.Add(this.btnX_Disconnect);
            this.groupBox1.Controls.Add(this.btnX_Connect);
            this.groupBox1.Controls.Add(this.lblDestinationUnit);
            this.groupBox1.Controls.Add(this.lblSpeedUnit);
            this.groupBox1.Controls.Add(this.guiDestination);
            this.groupBox1.Controls.Add(this.lblDestination);
            this.groupBox1.Controls.Add(this.lblSpeed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblControl);
            this.groupBox1.Controls.Add(this.guiSpeed);
            this.groupBox1.Controls.Add(this.guiControl);
            this.groupBox1.Controls.Add(this.menuStrip2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1127, 595);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // lightningChart1
            // 
            this.lightningChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightningChart1.BackColor = System.Drawing.Color.Gray;
            this.lightningChart1.Background = ((Arction.WinForms.Charting.Fill)(resources.GetObject("lightningChart1.Background")));
            this.lightningChart1.ChartManager = null;
            this.lightningChart1.ColorTheme = Arction.WinForms.Charting.ColorTheme.SkyBlue;
            this.lightningChart1.Location = new System.Drawing.Point(6, 51);
            this.lightningChart1.MinimumSize = new System.Drawing.Size(110, 90);
            this.lightningChart1.Name = "lightningChart1";
            this.lightningChart1.Options = ((Arction.WinForms.Charting.ChartOptions)(resources.GetObject("lightningChart1.Options")));
            this.lightningChart1.OutputStream = null;
            this.lightningChart1.RenderOptions = ((Arction.WinForms.Charting.Views.RenderOptionsCommon)(resources.GetObject("lightningChart1.RenderOptions")));
            this.lightningChart1.Size = new System.Drawing.Size(853, 538);
            this.lightningChart1.TabIndex = 60;
            this.lightningChart1.Title = ((Arction.WinForms.Charting.Titles.ChartTitle)(resources.GetObject("lightningChart1.Title")));
            this.lightningChart1.View3D = ((Arction.WinForms.Charting.Views.View3D.View3D)(resources.GetObject("lightningChart1.View3D")));
            this.lightningChart1.ViewPie3D = ((Arction.WinForms.Charting.Views.ViewPie3D.ViewPie3D)(resources.GetObject("lightningChart1.ViewPie3D")));
            this.lightningChart1.ViewPolar = ((Arction.WinForms.Charting.Views.ViewPolar.ViewPolar)(resources.GetObject("lightningChart1.ViewPolar")));
            this.lightningChart1.ViewSmith = ((Arction.WinForms.Charting.Views.ViewSmith.ViewSmith)(resources.GetObject("lightningChart1.ViewSmith")));
            this.lightningChart1.ViewXY = ((Arction.WinForms.Charting.Views.ViewXY.ViewXY)(resources.GetObject("lightningChart1.ViewXY")));
            // 
            // lbX_EDCName
            // 
            this.lbX_EDCName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbX_EDCName.BackColor = System.Drawing.Color.LightSkyBlue;
            // 
            // 
            // 
            this.lbX_EDCName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbX_EDCName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbX_EDCName.Location = new System.Drawing.Point(998, 16);
            this.lbX_EDCName.Name = "lbX_EDCName";
            this.lbX_EDCName.Size = new System.Drawing.Size(123, 29);
            this.lbX_EDCName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.lbX_EDCName.TabIndex = 59;
            // 
            // btn_ConState
            // 
            this.btn_ConState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConState.Enabled = false;
            this.btn_ConState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConState.Location = new System.Drawing.Point(998, 51);
            this.btn_ConState.Name = "btn_ConState";
            this.btn_ConState.Size = new System.Drawing.Size(123, 42);
            this.btn_ConState.TabIndex = 58;
            this.btn_ConState.Text = "OFFLINE";
            this.btn_ConState.UseVisualStyleBackColor = true;
            // 
            // buttonX15
            // 
            this.buttonX15.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX15.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX15.Image = ((System.Drawing.Image)(resources.GetObject("buttonX15.Image")));
            this.buttonX15.Location = new System.Drawing.Point(998, 551);
            this.buttonX15.Name = "buttonX15";
            this.buttonX15.Size = new System.Drawing.Size(123, 39);
            this.buttonX15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX15.TabIndex = 57;
            this.buttonX15.Text = " P  O  S";
            this.buttonX15.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.buttonX15.Click += new System.EventHandler(this.buttonX15_Click);
            // 
            // bntX_GUIPos
            // 
            this.bntX_GUIPos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_GUIPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_GUIPos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_GUIPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_GUIPos.Image = ((System.Drawing.Image)(resources.GetObject("bntX_GUIPos.Image")));
            this.bntX_GUIPos.Location = new System.Drawing.Point(998, 506);
            this.bntX_GUIPos.Name = "bntX_GUIPos";
            this.bntX_GUIPos.Size = new System.Drawing.Size(123, 39);
            this.bntX_GUIPos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_GUIPos.TabIndex = 57;
            this.bntX_GUIPos.Text = " P  O  S";
            this.bntX_GUIPos.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_GUIPos.Click += new System.EventHandler(this.bntX_GUIPos_Click);
            // 
            // bntX_GUIOff
            // 
            this.bntX_GUIOff.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_GUIOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_GUIOff.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_GUIOff.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_GUIOff.Image = ((System.Drawing.Image)(resources.GetObject("bntX_GUIOff.Image")));
            this.bntX_GUIOff.Location = new System.Drawing.Point(998, 460);
            this.bntX_GUIOff.Name = "bntX_GUIOff";
            this.bntX_GUIOff.Size = new System.Drawing.Size(123, 39);
            this.bntX_GUIOff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_GUIOff.TabIndex = 57;
            this.bntX_GUIOff.Text = "停    用";
            this.bntX_GUIOff.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_GUIOff.Click += new System.EventHandler(this.bntX_GUIOff_Click);
            // 
            // bntX_GUIOn
            // 
            this.bntX_GUIOn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_GUIOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_GUIOn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_GUIOn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_GUIOn.Image = ((System.Drawing.Image)(resources.GetObject("bntX_GUIOn.Image")));
            this.bntX_GUIOn.Location = new System.Drawing.Point(998, 414);
            this.bntX_GUIOn.Name = "bntX_GUIOn";
            this.bntX_GUIOn.Size = new System.Drawing.Size(123, 39);
            this.bntX_GUIOn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_GUIOn.TabIndex = 57;
            this.bntX_GUIOn.Text = "激    活";
            this.bntX_GUIOn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_GUIOn.Click += new System.EventHandler(this.bntX_GUIOn_Click);
            // 
            // btnX_QuickMoveDown
            // 
            this.btnX_QuickMoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_QuickMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_QuickMoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_QuickMoveDown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_QuickMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnX_QuickMoveDown.Image")));
            this.btnX_QuickMoveDown.Location = new System.Drawing.Point(998, 369);
            this.btnX_QuickMoveDown.Name = "btnX_QuickMoveDown";
            this.btnX_QuickMoveDown.Size = new System.Drawing.Size(123, 39);
            this.btnX_QuickMoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_QuickMoveDown.TabIndex = 57;
            this.btnX_QuickMoveDown.Text = "快速向下";
            this.btnX_QuickMoveDown.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_QuickMoveDown.Click += new System.EventHandler(this.btnX_QuickMoveDown_Click);
            // 
            // bntX_MoveDown
            // 
            this.bntX_MoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveDown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveDown.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveDown.Image")));
            this.bntX_MoveDown.Location = new System.Drawing.Point(998, 324);
            this.bntX_MoveDown.Name = "bntX_MoveDown";
            this.bntX_MoveDown.Size = new System.Drawing.Size(123, 39);
            this.bntX_MoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveDown.TabIndex = 57;
            this.bntX_MoveDown.Text = "向    下";
            this.bntX_MoveDown.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_MoveDown.Click += new System.EventHandler(this.bntX_MoveDown_Click);
            // 
            // bntX_MoveHalt
            // 
            this.bntX_MoveHalt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveHalt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveHalt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveHalt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveHalt.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveHalt.Image")));
            this.bntX_MoveHalt.Location = new System.Drawing.Point(998, 279);
            this.bntX_MoveHalt.Name = "bntX_MoveHalt";
            this.bntX_MoveHalt.Size = new System.Drawing.Size(123, 39);
            this.bntX_MoveHalt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveHalt.TabIndex = 57;
            this.bntX_MoveHalt.Text = "保    持";
            this.bntX_MoveHalt.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_MoveHalt.Click += new System.EventHandler(this.bntX_MoveHalt_Click);
            // 
            // btnX_MoveQuickUp
            // 
            this.btnX_MoveQuickUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_MoveQuickUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_MoveQuickUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_MoveQuickUp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_MoveQuickUp.Image = ((System.Drawing.Image)(resources.GetObject("btnX_MoveQuickUp.Image")));
            this.btnX_MoveQuickUp.Location = new System.Drawing.Point(998, 189);
            this.btnX_MoveQuickUp.Name = "btnX_MoveQuickUp";
            this.btnX_MoveQuickUp.Size = new System.Drawing.Size(123, 39);
            this.btnX_MoveQuickUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_MoveQuickUp.TabIndex = 57;
            this.btnX_MoveQuickUp.Text = "快速向上";
            this.btnX_MoveQuickUp.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_MoveQuickUp.Click += new System.EventHandler(this.btnX_MoveQuickUp_Click);
            // 
            // bntX_MoveUp
            // 
            this.bntX_MoveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveUp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveUp.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveUp.Image")));
            this.bntX_MoveUp.Location = new System.Drawing.Point(998, 234);
            this.bntX_MoveUp.Name = "bntX_MoveUp";
            this.bntX_MoveUp.Size = new System.Drawing.Size(123, 39);
            this.bntX_MoveUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveUp.TabIndex = 57;
            this.bntX_MoveUp.Text = "向    上";
            this.bntX_MoveUp.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.bntX_MoveUp.Click += new System.EventHandler(this.bntX_MoveUp_Click);
            // 
            // btnX_Disconnect
            // 
            this.btnX_Disconnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_Disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_Disconnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_Disconnect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_Disconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnX_Disconnect.Image")));
            this.btnX_Disconnect.Location = new System.Drawing.Point(998, 144);
            this.btnX_Disconnect.Name = "btnX_Disconnect";
            this.btnX_Disconnect.Size = new System.Drawing.Size(123, 39);
            this.btnX_Disconnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_Disconnect.TabIndex = 57;
            this.btnX_Disconnect.Text = "断    开";
            this.btnX_Disconnect.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_Disconnect.Click += new System.EventHandler(this.btnX_Disconnect_Click);
            // 
            // btnX_Connect
            // 
            this.btnX_Connect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_Connect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_Connect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_Connect.Image = ((System.Drawing.Image)(resources.GetObject("btnX_Connect.Image")));
            this.btnX_Connect.Location = new System.Drawing.Point(998, 99);
            this.btnX_Connect.Name = "btnX_Connect";
            this.btnX_Connect.Size = new System.Drawing.Size(123, 39);
            this.btnX_Connect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_Connect.TabIndex = 57;
            this.btnX_Connect.Text = "连    接";
            this.btnX_Connect.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_Connect.Click += new System.EventHandler(this.btnX_Connect_Click);
            // 
            // lblDestinationUnit
            // 
            this.lblDestinationUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDestinationUnit.AutoSize = true;
            this.lblDestinationUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDestinationUnit.Location = new System.Drawing.Point(972, 258);
            this.lblDestinationUnit.Name = "lblDestinationUnit";
            this.lblDestinationUnit.Size = new System.Drawing.Size(23, 16);
            this.lblDestinationUnit.TabIndex = 54;
            this.lblDestinationUnit.Text = "mm";
            // 
            // lblSpeedUnit
            // 
            this.lblSpeedUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeedUnit.AutoSize = true;
            this.lblSpeedUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpeedUnit.Location = new System.Drawing.Point(928, 210);
            this.lblSpeedUnit.Name = "lblSpeedUnit";
            this.lblSpeedUnit.Size = new System.Drawing.Size(39, 16);
            this.lblSpeedUnit.TabIndex = 53;
            this.lblSpeedUnit.Text = "mm/s";
            // 
            // guiDestination
            // 
            this.guiDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guiDestination.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.guiDestination.Location = new System.Drawing.Point(878, 277);
            this.guiDestination.Name = "guiDestination";
            this.guiDestination.Size = new System.Drawing.Size(100, 26);
            this.guiDestination.TabIndex = 51;
            this.guiDestination.Text = "0";
            this.guiDestination.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDestination
            // 
            this.lblDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDestination.Location = new System.Drawing.Point(877, 258);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(95, 16);
            this.lblDestination.TabIndex = 50;
            this.lblDestination.Text = "Destination";
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpeed.Location = new System.Drawing.Point(875, 210);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(47, 16);
            this.lblSpeed.TabIndex = 49;
            this.lblSpeed.Text = "Speed";
            // 
            // lblControl
            // 
            this.lblControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblControl.AutoSize = true;
            this.lblControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblControl.Location = new System.Drawing.Point(876, 158);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(63, 16);
            this.lblControl.TabIndex = 48;
            this.lblControl.Text = "Control";
            // 
            // guiSpeed
            // 
            this.guiSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guiSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.guiSpeed.Location = new System.Drawing.Point(877, 229);
            this.guiSpeed.Name = "guiSpeed";
            this.guiSpeed.Size = new System.Drawing.Size(100, 26);
            this.guiSpeed.TabIndex = 46;
            this.guiSpeed.Text = "5";
            this.guiSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // guiControl
            // 
            this.guiControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guiControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guiControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.guiControl.FormattingEnabled = true;
            this.guiControl.Items.AddRange(new object[] {
            "Position",
            "Load",
            "Extension"});
            this.guiControl.Location = new System.Drawing.Point(878, 183);
            this.guiControl.MaxDropDownItems = 16;
            this.guiControl.Name = "guiControl";
            this.guiControl.Size = new System.Drawing.Size(94, 24);
            this.guiControl.TabIndex = 47;
            this.guiControl.SelectedIndexChanged += new System.EventHandler(this.guiControl_SelectedIndexChanged);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsToolStripMenuItem,
            this.posToolStripMenuItem,
            this.Pos_AtoolStripMenuItem1,
            this.dynCtrlToolStripMenuItem,
            this.pIDToolStripMenuItem,
            this.setBitToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 17);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1121, 25);
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
            // 
            // setBitToolStripMenuItem
            // 
            this.setBitToolStripMenuItem.Name = "setBitToolStripMenuItem";
            this.setBitToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.setBitToolStripMenuItem.Text = "SetBit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblExtension);
            this.panel1.Controls.Add(this.lblLoad);
            this.panel1.Controls.Add(this.guiPosition);
            this.panel1.Controls.Add(this.guiExtension);
            this.panel1.Controls.Add(this.lblPosition);
            this.panel1.Controls.Add(this.guiTime);
            this.panel1.Controls.Add(this.guiLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 55);
            this.panel1.TabIndex = 56;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(53, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(77, 13);
            this.lblTime.TabIndex = 26;
            this.lblTime.Text = "运行时间 [s]";
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtension.Location = new System.Drawing.Point(501, 2);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(92, 13);
            this.lblExtension.TabIndex = 32;
            this.lblExtension.Text = "Extension [mm]";
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoad.Location = new System.Drawing.Point(366, 2);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(56, 13);
            this.lblLoad.TabIndex = 30;
            this.lblLoad.Text = "Load [N]";
            // 
            // guiPosition
            // 
            this.guiPosition.BackColor = System.Drawing.Color.Black;
            this.guiPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiPosition.ForeColor = System.Drawing.Color.Lime;
            this.guiPosition.Location = new System.Drawing.Point(167, 20);
            this.guiPosition.Name = "guiPosition";
            this.guiPosition.Size = new System.Drawing.Size(145, 29);
            this.guiPosition.TabIndex = 39;
            this.guiPosition.Text = "0.000";
            this.guiPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guiExtension
            // 
            this.guiExtension.BackColor = System.Drawing.Color.Black;
            this.guiExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiExtension.ForeColor = System.Drawing.Color.Lime;
            this.guiExtension.Location = new System.Drawing.Point(471, 20);
            this.guiExtension.Name = "guiExtension";
            this.guiExtension.Size = new System.Drawing.Size(145, 29);
            this.guiExtension.TabIndex = 41;
            this.guiExtension.Text = "0.000";
            this.guiExtension.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(205, 2);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(82, 13);
            this.lblPosition.TabIndex = 28;
            this.lblPosition.Text = "Position [mm]";
            // 
            // guiTime
            // 
            this.guiTime.BackColor = System.Drawing.Color.Black;
            this.guiTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiTime.ForeColor = System.Drawing.Color.Lime;
            this.guiTime.Location = new System.Drawing.Point(16, 20);
            this.guiTime.Name = "guiTime";
            this.guiTime.Size = new System.Drawing.Size(145, 29);
            this.guiTime.TabIndex = 25;
            this.guiTime.Text = "0.000";
            this.guiTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guiLoad
            // 
            this.guiLoad.BackColor = System.Drawing.Color.Black;
            this.guiLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiLoad.ForeColor = System.Drawing.Color.Lime;
            this.guiLoad.Location = new System.Drawing.Point(318, 20);
            this.guiLoad.Name = "guiLoad";
            this.guiLoad.Size = new System.Drawing.Size(145, 29);
            this.guiLoad.TabIndex = 40;
            this.guiLoad.Text = "0.000";
            this.guiLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guiDebug
            // 
            this.guiDebug.Dock = System.Windows.Forms.DockStyle.Right;
            this.guiDebug.HideSelection = false;
            this.guiDebug.Location = new System.Drawing.Point(1127, 0);
            this.guiDebug.Name = "guiDebug";
            this.guiDebug.ReadOnly = true;
            this.guiDebug.Size = new System.Drawing.Size(291, 650);
            this.guiDebug.TabIndex = 0;
            this.guiDebug.Text = "Starting Communication\n";
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "控制器实时曲线";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.superTabControlPanel1.Controls.Add(this.panelEx2);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 52);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1418, 650);
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
            this.panelEx2.Size = new System.Drawing.Size(1418, 650);
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
            this.panelEx7.Size = new System.Drawing.Size(1115, 490);
            this.panelEx7.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx7.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx7.Style.GradientAngle = 90;
            this.panelEx7.TabIndex = 6;
            this.panelEx7.Click += new System.EventHandler(this.panelEx7_Click);
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
            this.panelEx6.Location = new System.Drawing.Point(0, 490);
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
            this.textBoxX7.TextChanged += new System.EventHandler(this.textBoxX6_TextChanged);
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
            this.textBoxX6.TextChanged += new System.EventHandler(this.textBoxX6_TextChanged);
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
            this.superTabControl2.Size = new System.Drawing.Size(303, 650);
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
            this.superTabControlPanel3.Size = new System.Drawing.Size(303, 625);
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
            this.panelEx3.Size = new System.Drawing.Size(303, 625);
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
            this.superTabControl3.Location = new System.Drawing.Point(0, 515);
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
            this.labelX28.Click += new System.EventHandler(this.labelX28_Click);
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
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.参数设置ToolStripMenuItem,
            this.试验数据ToolStripMenuItem,
            this.试验结果ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1418, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录ToolStripMenuItem,
            this.试验数据回访ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.登录ToolStripMenuItem.Text = "登录";
            this.登录ToolStripMenuItem.Click += new System.EventHandler(this.登录ToolStripMenuItem_Click);
            // 
            // 试验数据回访ToolStripMenuItem
            // 
            this.试验数据回访ToolStripMenuItem.Name = "试验数据回访ToolStripMenuItem";
            this.试验数据回访ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.试验数据回访ToolStripMenuItem.Text = "试验数据回放";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 参数设置ToolStripMenuItem
            // 
            this.参数设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.试验操作选项ToolStripMenuItem,
            this.系统保护选项ToolStripMenuItem,
            this.绘图选项ToolStripMenuItem});
            this.参数设置ToolStripMenuItem.Name = "参数设置ToolStripMenuItem";
            this.参数设置ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.参数设置ToolStripMenuItem.Text = "参数设置";
            // 
            // 试验操作选项ToolStripMenuItem
            // 
            this.试验操作选项ToolStripMenuItem.Name = "试验操作选项ToolStripMenuItem";
            this.试验操作选项ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.试验操作选项ToolStripMenuItem.Text = "试验操作选项";
            // 
            // 系统保护选项ToolStripMenuItem
            // 
            this.系统保护选项ToolStripMenuItem.Name = "系统保护选项ToolStripMenuItem";
            this.系统保护选项ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.系统保护选项ToolStripMenuItem.Text = "系统保护选项";
            // 
            // 绘图选项ToolStripMenuItem
            // 
            this.绘图选项ToolStripMenuItem.Name = "绘图选项ToolStripMenuItem";
            this.绘图选项ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.绘图选项ToolStripMenuItem.Text = "绘图选项";
            // 
            // 试验数据ToolStripMenuItem
            // 
            this.试验数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开数据文件ToolStripMenuItem,
            this.保存数据问题及ToolStripMenuItem,
            this.toolStripSeparator1,
            this.保存当前曲线ToolStripMenuItem});
            this.试验数据ToolStripMenuItem.Name = "试验数据ToolStripMenuItem";
            this.试验数据ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.试验数据ToolStripMenuItem.Text = "试验数据";
            // 
            // 打开数据文件ToolStripMenuItem
            // 
            this.打开数据文件ToolStripMenuItem.Name = "打开数据文件ToolStripMenuItem";
            this.打开数据文件ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.打开数据文件ToolStripMenuItem.Text = "打开数据文件";
            // 
            // 保存数据问题及ToolStripMenuItem
            // 
            this.保存数据问题及ToolStripMenuItem.Name = "保存数据问题及ToolStripMenuItem";
            this.保存数据问题及ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.保存数据问题及ToolStripMenuItem.Text = "保存数据文件";
            this.保存数据问题及ToolStripMenuItem.Click += new System.EventHandler(this.保存数据问题及ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // 保存当前曲线ToolStripMenuItem
            // 
            this.保存当前曲线ToolStripMenuItem.Name = "保存当前曲线ToolStripMenuItem";
            this.保存当前曲线ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.保存当前曲线ToolStripMenuItem.Text = "保存当前曲线";
            // 
            // 试验结果ToolStripMenuItem
            // 
            this.试验结果ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拷贝当前曲线ToolStripMenuItem,
            this.打印当前曲线ToolStripMenuItem});
            this.试验结果ToolStripMenuItem.Name = "试验结果ToolStripMenuItem";
            this.试验结果ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.试验结果ToolStripMenuItem.Text = "试验结果";
            // 
            // 拷贝当前曲线ToolStripMenuItem
            // 
            this.拷贝当前曲线ToolStripMenuItem.Name = "拷贝当前曲线ToolStripMenuItem";
            this.拷贝当前曲线ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.拷贝当前曲线ToolStripMenuItem.Text = "拷贝当前曲线";
            // 
            // 打印当前曲线ToolStripMenuItem
            // 
            this.打印当前曲线ToolStripMenuItem.Name = "打印当前曲线ToolStripMenuItem";
            this.打印当前曲线ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.打印当前曲线ToolStripMenuItem.Text = "打印当前曲线";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
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
            // Pos_AtoolStripMenuItem1
            // 
            this.Pos_AtoolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("Pos_AtoolStripMenuItem1.Image")));
            this.Pos_AtoolStripMenuItem1.Name = "Pos_AtoolStripMenuItem1";
            this.Pos_AtoolStripMenuItem1.Size = new System.Drawing.Size(70, 21);
            this.Pos_AtoolStripMenuItem1.Text = "Pos_A";
            this.Pos_AtoolStripMenuItem1.Click += new System.EventHandler(this.Pos_AtoolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(865, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "滚动模式";
            // 
            // cmbX_ScrollMode
            // 
            this.cmbX_ScrollMode.DisplayMember = "Text";
            this.cmbX_ScrollMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_ScrollMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_ScrollMode.FormattingEnabled = true;
            this.cmbX_ScrollMode.ItemHeight = 21;
            this.cmbX_ScrollMode.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5});
            this.cmbX_ScrollMode.Location = new System.Drawing.Point(865, 70);
            this.cmbX_ScrollMode.Name = "cmbX_ScrollMode";
            this.cmbX_ScrollMode.Size = new System.Drawing.Size(121, 27);
            this.cmbX_ScrollMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_ScrollMode.TabIndex = 62;
            this.cmbX_ScrollMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx7_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "None";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "Scrolling";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "Stepping";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "Sweeping";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "Triggered";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 702);
            this.Controls.Add(this.superTabControl1);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoPE10Net C# Demo";
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
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox guiDestination;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.TextBox guiSpeed;
        private System.Windows.Forms.ComboBox guiControl;
        private System.Windows.Forms.RichTextBox guiDebug;
        private System.Windows.Forms.TextBox guiExtension;
        private System.Windows.Forms.TextBox guiTime;
        private System.Windows.Forms.TextBox guiLoad;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox guiPosition;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.Label lblExtension;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试验数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试验结果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试验数据回访ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试验操作选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统保护选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘图选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开数据文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存数据问题及ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 保存当前曲线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拷贝当前曲线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印当前曲线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
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
        private System.Windows.Forms.Label lblDestinationUnit;
        private System.Windows.Forms.Label lblSpeedUnit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnX_Connect;
        private DevComponents.DotNetBar.ButtonX btnX_Disconnect;
        private DevComponents.DotNetBar.ButtonX bntX_MoveDown;
        private DevComponents.DotNetBar.ButtonX bntX_MoveHalt;
        private DevComponents.DotNetBar.ButtonX bntX_MoveUp;
        private DevComponents.DotNetBar.ButtonX bntX_GUIPos;
        private DevComponents.DotNetBar.ButtonX bntX_GUIOff;
        private DevComponents.DotNetBar.ButtonX bntX_GUIOn;
        private System.Windows.Forms.Button btn_ConState;
        private DevComponents.DotNetBar.ButtonX btnX_MoveQuickUp;
        private DevComponents.DotNetBar.ButtonX btnX_QuickMoveDown;
        private DevComponents.DotNetBar.LabelX lbX_EDCName;
        private Arction.WinForms.Charting.LightningChart lightningChart1;
        private DevComponents.DotNetBar.ButtonX buttonX15;
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
        private System.Windows.Forms.ToolStripMenuItem dynCtrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setBitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Pos_AtoolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_ScrollMode;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
    }
}

