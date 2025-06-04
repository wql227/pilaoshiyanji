namespace DoPE10Net_CSharpDemo
{
    partial class FrmPos_A
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPos_A));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cmbX_PosA_EDC = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbX_Pos_SpeedCtrl = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbX_PosA_MoveCtrl = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbX_Pos_Destnation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbX_PosA_SpeedUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.cmbX_PosA_DestnationUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.panelEx_POS = new DevComponents.DotNetBar.PanelEx();
            this.btnX_Pos_ASend = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbX_Pos_AccCtrl = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.tbX_Pos_DecCtrl = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbX_PosA_AccUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.cmbX_PosA_DecUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem15 = new DevComponents.Editors.ComboItem();
            this.comboItem16 = new DevComponents.Editors.ComboItem();
            this.panelEx_POS.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(13, 39);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(80, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "控制器";
            // 
            // cmbX_PosA_EDC
            // 
            this.cmbX_PosA_EDC.DisplayMember = "Text";
            this.cmbX_PosA_EDC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_PosA_EDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbX_PosA_EDC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_PosA_EDC.FormattingEnabled = true;
            this.cmbX_PosA_EDC.ItemHeight = 21;
            this.cmbX_PosA_EDC.Items.AddRange(new object[] {
            this.comboItem1});
            this.cmbX_PosA_EDC.Location = new System.Drawing.Point(99, 35);
            this.cmbX_PosA_EDC.Name = "cmbX_PosA_EDC";
            this.cmbX_PosA_EDC.Size = new System.Drawing.Size(191, 27);
            this.cmbX_PosA_EDC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_PosA_EDC.TabIndex = 1;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "EDC0";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(12, 72);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(80, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "控制方式";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(12, 137);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(80, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "速度";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(13, 203);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(80, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "目的地";
            // 
            // tbX_Pos_SpeedCtrl
            // 
            // 
            // 
            // 
            this.tbX_Pos_SpeedCtrl.Border.Class = "TextBoxBorder";
            this.tbX_Pos_SpeedCtrl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbX_Pos_SpeedCtrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbX_Pos_SpeedCtrl.Location = new System.Drawing.Point(99, 135);
            this.tbX_Pos_SpeedCtrl.Name = "tbX_Pos_SpeedCtrl";
            this.tbX_Pos_SpeedCtrl.PreventEnterBeep = true;
            this.tbX_Pos_SpeedCtrl.Size = new System.Drawing.Size(101, 26);
            this.tbX_Pos_SpeedCtrl.TabIndex = 2;
            this.tbX_Pos_SpeedCtrl.Text = "10";
            // 
            // cmbX_PosA_MoveCtrl
            // 
            this.cmbX_PosA_MoveCtrl.DisplayMember = "Text";
            this.cmbX_PosA_MoveCtrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_PosA_MoveCtrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_PosA_MoveCtrl.FormattingEnabled = true;
            this.cmbX_PosA_MoveCtrl.ItemHeight = 21;
            this.cmbX_PosA_MoveCtrl.Location = new System.Drawing.Point(99, 68);
            this.cmbX_PosA_MoveCtrl.Name = "cmbX_PosA_MoveCtrl";
            this.cmbX_PosA_MoveCtrl.Size = new System.Drawing.Size(191, 27);
            this.cmbX_PosA_MoveCtrl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_PosA_MoveCtrl.TabIndex = 1;
            // 
            // tbX_Pos_Destnation
            // 
            // 
            // 
            // 
            this.tbX_Pos_Destnation.Border.Class = "TextBoxBorder";
            this.tbX_Pos_Destnation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbX_Pos_Destnation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbX_Pos_Destnation.Location = new System.Drawing.Point(99, 200);
            this.tbX_Pos_Destnation.Name = "tbX_Pos_Destnation";
            this.tbX_Pos_Destnation.PreventEnterBeep = true;
            this.tbX_Pos_Destnation.Size = new System.Drawing.Size(101, 26);
            this.tbX_Pos_Destnation.TabIndex = 2;
            this.tbX_Pos_Destnation.Text = "10";
            // 
            // cmbX_PosA_SpeedUnit
            // 
            this.cmbX_PosA_SpeedUnit.DisplayMember = "Text";
            this.cmbX_PosA_SpeedUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_PosA_SpeedUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_PosA_SpeedUnit.FormattingEnabled = true;
            this.cmbX_PosA_SpeedUnit.ItemHeight = 21;
            this.cmbX_PosA_SpeedUnit.Items.AddRange(new object[] {
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6});
            this.cmbX_PosA_SpeedUnit.Location = new System.Drawing.Point(206, 134);
            this.cmbX_PosA_SpeedUnit.Name = "cmbX_PosA_SpeedUnit";
            this.cmbX_PosA_SpeedUnit.Size = new System.Drawing.Size(84, 27);
            this.cmbX_PosA_SpeedUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_PosA_SpeedUnit.TabIndex = 1;
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "mm/min";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "mm/s";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "μm/s";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "μm/min";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "m/s";
            // 
            // cmbX_PosA_DestnationUnit
            // 
            this.cmbX_PosA_DestnationUnit.DisplayMember = "Text";
            this.cmbX_PosA_DestnationUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_PosA_DestnationUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_PosA_DestnationUnit.FormattingEnabled = true;
            this.cmbX_PosA_DestnationUnit.ItemHeight = 21;
            this.cmbX_PosA_DestnationUnit.Items.AddRange(new object[] {
            this.comboItem7,
            this.comboItem8,
            this.comboItem9});
            this.cmbX_PosA_DestnationUnit.Location = new System.Drawing.Point(206, 200);
            this.cmbX_PosA_DestnationUnit.Name = "cmbX_PosA_DestnationUnit";
            this.cmbX_PosA_DestnationUnit.Size = new System.Drawing.Size(84, 27);
            this.cmbX_PosA_DestnationUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_PosA_DestnationUnit.TabIndex = 1;
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "mm";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "μm";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "m";
            // 
            // panelEx_POS
            // 
            this.panelEx_POS.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_POS.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_POS.Controls.Add(this.btnX_Pos_ASend);
            this.panelEx_POS.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_POS.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx_POS.Location = new System.Drawing.Point(0, 0);
            this.panelEx_POS.Name = "panelEx_POS";
            this.panelEx_POS.Size = new System.Drawing.Size(302, 30);
            this.panelEx_POS.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_POS.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_POS.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_POS.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_POS.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_POS.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_POS.Style.GradientAngle = 90;
            this.panelEx_POS.TabIndex = 3;
            // 
            // btnX_Pos_ASend
            // 
            this.btnX_Pos_ASend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_Pos_ASend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_Pos_ASend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_Pos_ASend.Image = ((System.Drawing.Image)(resources.GetObject("btnX_Pos_ASend.Image")));
            this.btnX_Pos_ASend.Location = new System.Drawing.Point(3, 3);
            this.btnX_Pos_ASend.Name = "btnX_Pos_ASend";
            this.btnX_Pos_ASend.Size = new System.Drawing.Size(75, 23);
            this.btnX_Pos_ASend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_Pos_ASend.TabIndex = 0;
            this.btnX_Pos_ASend.Text = "发送";
            this.btnX_Pos_ASend.Click += new System.EventHandler(this.btnX_Pos_ASend_Click);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(11, 104);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(80, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "加速度";
            // 
            // tbX_Pos_AccCtrl
            // 
            // 
            // 
            // 
            this.tbX_Pos_AccCtrl.Border.Class = "TextBoxBorder";
            this.tbX_Pos_AccCtrl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbX_Pos_AccCtrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbX_Pos_AccCtrl.Location = new System.Drawing.Point(99, 101);
            this.tbX_Pos_AccCtrl.Name = "tbX_Pos_AccCtrl";
            this.tbX_Pos_AccCtrl.PreventEnterBeep = true;
            this.tbX_Pos_AccCtrl.Size = new System.Drawing.Size(101, 26);
            this.tbX_Pos_AccCtrl.TabIndex = 2;
            this.tbX_Pos_AccCtrl.Text = "10";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.Location = new System.Drawing.Point(12, 168);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(80, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "加速度";
            // 
            // tbX_Pos_DecCtrl
            // 
            // 
            // 
            // 
            this.tbX_Pos_DecCtrl.Border.Class = "TextBoxBorder";
            this.tbX_Pos_DecCtrl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbX_Pos_DecCtrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbX_Pos_DecCtrl.Location = new System.Drawing.Point(99, 168);
            this.tbX_Pos_DecCtrl.Name = "tbX_Pos_DecCtrl";
            this.tbX_Pos_DecCtrl.PreventEnterBeep = true;
            this.tbX_Pos_DecCtrl.Size = new System.Drawing.Size(101, 26);
            this.tbX_Pos_DecCtrl.TabIndex = 2;
            this.tbX_Pos_DecCtrl.Text = "10";
            // 
            // cmbX_PosA_AccUnit
            // 
            this.cmbX_PosA_AccUnit.DisplayMember = "Text";
            this.cmbX_PosA_AccUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_PosA_AccUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_PosA_AccUnit.FormattingEnabled = true;
            this.cmbX_PosA_AccUnit.ItemHeight = 21;
            this.cmbX_PosA_AccUnit.Items.AddRange(new object[] {
            this.comboItem10,
            this.comboItem11});
            this.cmbX_PosA_AccUnit.Location = new System.Drawing.Point(205, 101);
            this.cmbX_PosA_AccUnit.Name = "cmbX_PosA_AccUnit";
            this.cmbX_PosA_AccUnit.Size = new System.Drawing.Size(85, 27);
            this.cmbX_PosA_AccUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_PosA_AccUnit.TabIndex = 1;
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "mm/s²";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "m/s²";
            // 
            // cmbX_PosA_DecUnit
            // 
            this.cmbX_PosA_DecUnit.DisplayMember = "Text";
            this.cmbX_PosA_DecUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_PosA_DecUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_PosA_DecUnit.FormattingEnabled = true;
            this.cmbX_PosA_DecUnit.ItemHeight = 21;
            this.cmbX_PosA_DecUnit.Items.AddRange(new object[] {
            this.comboItem15,
            this.comboItem16});
            this.cmbX_PosA_DecUnit.Location = new System.Drawing.Point(206, 167);
            this.cmbX_PosA_DecUnit.Name = "cmbX_PosA_DecUnit";
            this.cmbX_PosA_DecUnit.Size = new System.Drawing.Size(84, 27);
            this.cmbX_PosA_DecUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_PosA_DecUnit.TabIndex = 1;
            // 
            // comboItem15
            // 
            this.comboItem15.Text = "mm/s²";
            // 
            // comboItem16
            // 
            this.comboItem16.Text = "m/s²";
            // 
            // FrmPos_A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 242);
            this.Controls.Add(this.panelEx_POS);
            this.Controls.Add(this.tbX_Pos_Destnation);
            this.Controls.Add(this.tbX_Pos_DecCtrl);
            this.Controls.Add(this.tbX_Pos_AccCtrl);
            this.Controls.Add(this.tbX_Pos_SpeedCtrl);
            this.Controls.Add(this.cmbX_PosA_DestnationUnit);
            this.Controls.Add(this.cmbX_PosA_DecUnit);
            this.Controls.Add(this.cmbX_PosA_AccUnit);
            this.Controls.Add(this.cmbX_PosA_SpeedUnit);
            this.Controls.Add(this.cmbX_PosA_MoveCtrl);
            this.Controls.Add(this.cmbX_PosA_EDC);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPos_A";
            this.Text = "FrmPos_A";
            this.panelEx_POS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_PosA_EDC;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbX_Pos_SpeedCtrl;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_PosA_MoveCtrl;
        private DevComponents.DotNetBar.Controls.TextBoxX tbX_Pos_Destnation;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_PosA_SpeedUnit;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_PosA_DestnationUnit;
        private DevComponents.DotNetBar.PanelEx panelEx_POS;
        private DevComponents.DotNetBar.ButtonX btnX_Pos_ASend;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbX_Pos_AccCtrl;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX tbX_Pos_DecCtrl;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_PosA_AccUnit;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_PosA_DecUnit;
        private DevComponents.Editors.ComboItem comboItem15;
        private DevComponents.Editors.ComboItem comboItem16;
    }
}