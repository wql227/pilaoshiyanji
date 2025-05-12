namespace DoPE10Net_CSharpDemo
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
            this.cmbX_EDC = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx4 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panelEx_POS = new DevComponents.DotNetBar.PanelEx();
            this.btnX_PosSend = new DevComponents.DotNetBar.ButtonX();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
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
            this.labelX1.Text = "EDC";
            // 
            // cmbX_EDC
            // 
            this.cmbX_EDC.DisplayMember = "Text";
            this.cmbX_EDC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbX_EDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbX_EDC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbX_EDC.FormattingEnabled = true;
            this.cmbX_EDC.ItemHeight = 21;
            this.cmbX_EDC.Items.AddRange(new object[] {
            this.comboItem1});
            this.cmbX_EDC.Location = new System.Drawing.Point(97, 35);
            this.cmbX_EDC.Name = "cmbX_EDC";
            this.cmbX_EDC.Size = new System.Drawing.Size(196, 27);
            this.cmbX_EDC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbX_EDC.TabIndex = 1;
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
            this.labelX2.Text = "移动控制";
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
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX1.Location = new System.Drawing.Point(97, 101);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(101, 26);
            this.textBoxX1.TabIndex = 2;
            // 
            // comboBoxEx2
            // 
            this.comboBoxEx2.DisplayMember = "Text";
            this.comboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx2.FormattingEnabled = true;
            this.comboBoxEx2.ItemHeight = 21;
            this.comboBoxEx2.Location = new System.Drawing.Point(97, 68);
            this.comboBoxEx2.Name = "comboBoxEx2";
            this.comboBoxEx2.Size = new System.Drawing.Size(101, 27);
            this.comboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx2.TabIndex = 1;
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxX2.Location = new System.Drawing.Point(97, 133);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.Size = new System.Drawing.Size(101, 26);
            this.textBoxX2.TabIndex = 2;
            // 
            // comboBoxEx3
            // 
            this.comboBoxEx3.DisplayMember = "Text";
            this.comboBoxEx3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx3.FormattingEnabled = true;
            this.comboBoxEx3.ItemHeight = 21;
            this.comboBoxEx3.Location = new System.Drawing.Point(204, 100);
            this.comboBoxEx3.Name = "comboBoxEx3";
            this.comboBoxEx3.Size = new System.Drawing.Size(89, 27);
            this.comboBoxEx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx3.TabIndex = 1;
            // 
            // comboBoxEx4
            // 
            this.comboBoxEx4.DisplayMember = "Text";
            this.comboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxEx4.FormattingEnabled = true;
            this.comboBoxEx4.ItemHeight = 21;
            this.comboBoxEx4.Location = new System.Drawing.Point(204, 133);
            this.comboBoxEx4.Name = "comboBoxEx4";
            this.comboBoxEx4.Size = new System.Drawing.Size(89, 27);
            this.comboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx4.TabIndex = 1;
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
            this.btnX_PosSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_PosSend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_PosSend.Image = ((System.Drawing.Image)(resources.GetObject("btnX_PosSend.Image")));
            this.btnX_PosSend.Location = new System.Drawing.Point(3, 3);
            this.btnX_PosSend.Name = "btnX_PosSend";
            this.btnX_PosSend.Size = new System.Drawing.Size(75, 23);
            this.btnX_PosSend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_PosSend.TabIndex = 0;
            this.btnX_PosSend.Text = "发送";
            this.btnX_PosSend.Click += new System.EventHandler(this.btnX_PosSend_Click);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "EDC0";
            // 
            // FrmPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 173);
            this.Controls.Add(this.panelEx_POS);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.comboBoxEx4);
            this.Controls.Add(this.comboBoxEx3);
            this.Controls.Add(this.comboBoxEx2);
            this.Controls.Add(this.cmbX_EDC);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPos";
            this.Text = "FrmPos";
            this.panelEx_POS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbX_EDC;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx4;
        private DevComponents.DotNetBar.PanelEx panelEx_POS;
        private DevComponents.DotNetBar.ButtonX btnX_PosSend;
        private DevComponents.Editors.ComboItem comboItem1;
    }
}