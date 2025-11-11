namespace DoPENetConnect
{
    partial class FrmPos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPos));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cmbX_Pos_EDC = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbX_Pos_SpeedCtrl = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbX_Pos_MoveCtrl = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbX_Pos_Destnation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbX_Pos_SpeedUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.cmbX_Pos_DestnationUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.panelEx_POS = new DevComponents.DotNetBar.PanelEx();
            this.btnX_PosSend = new DevComponents.DotNetBar.ButtonX();
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
            this.labelX1.Location = new System.Drawing.Point(11, 35);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(80, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "控制器";
            // 
            // cmbX_Pos_EDC
            // 
            this.cmbX_Pos_EDC.DisplayMember = "Text";
            this.cmbX_Pos_EDC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_Pos_EDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbX_Pos_EDC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_Pos_EDC.FormattingEnabled = true;
            this.cmbX_Pos_EDC.ItemHeight = 21;
            this.cmbX_Pos_EDC.Items.AddRange(new object[] {
            this.comboItem1});
            this.cmbX_Pos_EDC.Location = new System.Drawing.Point(97, 35);
            this.cmbX_Pos_EDC.Name = "cmbX_Pos_EDC";
            this.cmbX_Pos_EDC.Size = new System.Drawing.Size(196, 27);
            this.cmbX_Pos_EDC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_Pos_EDC.TabIndex = 1;
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
            this.labelX2.Location = new System.Drawing.Point(11, 68);
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
            this.labelX3.Location = new System.Drawing.Point(11, 101);
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
            this.labelX4.Location = new System.Drawing.Point(11, 133);
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
            this.tbX_Pos_SpeedCtrl.Location = new System.Drawing.Point(97, 101);
            this.tbX_Pos_SpeedCtrl.Name = "tbX_Pos_SpeedCtrl";
            this.tbX_Pos_SpeedCtrl.PreventEnterBeep = true;
            this.tbX_Pos_SpeedCtrl.Size = new System.Drawing.Size(101, 26);
            this.tbX_Pos_SpeedCtrl.TabIndex = 2;
            this.tbX_Pos_SpeedCtrl.Text = "10";
            // 
            // cmbX_Pos_MoveCtrl
            // 
            this.cmbX_Pos_MoveCtrl.DisplayMember = "Text";
            this.cmbX_Pos_MoveCtrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_Pos_MoveCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbX_Pos_MoveCtrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_Pos_MoveCtrl.FormattingEnabled = true;
            this.cmbX_Pos_MoveCtrl.ItemHeight = 21;
            this.cmbX_Pos_MoveCtrl.Location = new System.Drawing.Point(97, 68);
            this.cmbX_Pos_MoveCtrl.Name = "cmbX_Pos_MoveCtrl";
            this.cmbX_Pos_MoveCtrl.Size = new System.Drawing.Size(101, 27);
            this.cmbX_Pos_MoveCtrl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_Pos_MoveCtrl.TabIndex = 1;
            this.cmbX_Pos_MoveCtrl.SelectedIndexChanged += new System.EventHandler(this.cmbX_Pos_MoveCtrl_SelectedIndexChanged);
            // 
            // tbX_Pos_Destnation
            // 
            // 
            // 
            // 
            this.tbX_Pos_Destnation.Border.Class = "TextBoxBorder";
            this.tbX_Pos_Destnation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbX_Pos_Destnation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbX_Pos_Destnation.Location = new System.Drawing.Point(97, 133);
            this.tbX_Pos_Destnation.Name = "tbX_Pos_Destnation";
            this.tbX_Pos_Destnation.PreventEnterBeep = true;
            this.tbX_Pos_Destnation.Size = new System.Drawing.Size(101, 26);
            this.tbX_Pos_Destnation.TabIndex = 2;
            this.tbX_Pos_Destnation.Text = "10";
            // 
            // cmbX_Pos_SpeedUnit
            // 
            this.cmbX_Pos_SpeedUnit.DisplayMember = "Text";
            this.cmbX_Pos_SpeedUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_Pos_SpeedUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbX_Pos_SpeedUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_Pos_SpeedUnit.FormattingEnabled = true;
            this.cmbX_Pos_SpeedUnit.ItemHeight = 21;
            this.cmbX_Pos_SpeedUnit.Items.AddRange(new object[] {
            this.comboItem3});
            this.cmbX_Pos_SpeedUnit.Location = new System.Drawing.Point(204, 100);
            this.cmbX_Pos_SpeedUnit.Name = "cmbX_Pos_SpeedUnit";
            this.cmbX_Pos_SpeedUnit.Size = new System.Drawing.Size(89, 27);
            this.cmbX_Pos_SpeedUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_Pos_SpeedUnit.TabIndex = 1;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "mm/min";
            // 
            // cmbX_Pos_DestnationUnit
            // 
            this.cmbX_Pos_DestnationUnit.DisplayMember = "Text";
            this.cmbX_Pos_DestnationUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_Pos_DestnationUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbX_Pos_DestnationUnit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_Pos_DestnationUnit.FormattingEnabled = true;
            this.cmbX_Pos_DestnationUnit.ItemHeight = 21;
            this.cmbX_Pos_DestnationUnit.Items.AddRange(new object[] {
            this.comboItem7,
            this.comboItem8,
            this.comboItem9});
            this.cmbX_Pos_DestnationUnit.Location = new System.Drawing.Point(204, 133);
            this.cmbX_Pos_DestnationUnit.Name = "cmbX_Pos_DestnationUnit";
            this.cmbX_Pos_DestnationUnit.Size = new System.Drawing.Size(89, 27);
            this.cmbX_Pos_DestnationUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_Pos_DestnationUnit.TabIndex = 1;
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
            this.panelEx_POS.Controls.Add(this.btnX_PosSend);
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
            // btnX_PosSend
            // 
            this.btnX_PosSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_PosSend.AutoSize = true;
            this.btnX_PosSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_PosSend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_PosSend.Image = ((System.Drawing.Image)(resources.GetObject("btnX_PosSend.Image")));
            this.btnX_PosSend.Location = new System.Drawing.Point(3, 3);
            this.btnX_PosSend.MaximumSize = new System.Drawing.Size(0, 23);
            this.btnX_PosSend.Name = "btnX_PosSend";
            this.btnX_PosSend.Size = new System.Drawing.Size(75, 27);
            this.btnX_PosSend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_PosSend.TabIndex = 0;
            this.btnX_PosSend.Text = "发送";
            this.btnX_PosSend.Click += new System.EventHandler(this.btnX_PosSend_Click);
            // 
            // FrmPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 173);
            this.Controls.Add(this.panelEx_POS);
            this.Controls.Add(this.tbX_Pos_Destnation);
            this.Controls.Add(this.tbX_Pos_SpeedCtrl);
            this.Controls.Add(this.cmbX_Pos_DestnationUnit);
            this.Controls.Add(this.cmbX_Pos_SpeedUnit);
            this.Controls.Add(this.cmbX_Pos_MoveCtrl);
            this.Controls.Add(this.cmbX_Pos_EDC);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPos";
            this.Text = "FrmPos";
            this.Load += new System.EventHandler(this.FrmPos_Load);
            this.panelEx_POS.ResumeLayout(false);
            this.panelEx_POS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_Pos_EDC;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbX_Pos_SpeedCtrl;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_Pos_MoveCtrl;
        private DevComponents.DotNetBar.Controls.TextBoxX tbX_Pos_Destnation;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_Pos_SpeedUnit;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_Pos_DestnationUnit;
        private DevComponents.DotNetBar.PanelEx panelEx_POS;
        private DevComponents.DotNetBar.ButtonX btnX_PosSend;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
    }
}