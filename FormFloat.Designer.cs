namespace DoPENetConnect
{
    partial class FormFloat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFloat));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.btnX_Connect = new DevComponents.DotNetBar.ButtonX();
            this.btnX_Disconnect = new DevComponents.DotNetBar.ButtonX();
            this.btn_ConState = new System.Windows.Forms.Button();
            this.bntX_MoveHalt = new DevComponents.DotNetBar.ButtonX();
            this.btnX_SetLow = new DevComponents.DotNetBar.ButtonX();
            this.bntX_MoveDown = new DevComponents.DotNetBar.ButtonX();
            this.bntX_GUIOn = new DevComponents.DotNetBar.ButtonX();
            this.btnX_MoveQuickUp = new DevComponents.DotNetBar.ButtonX();
            this.btnX_SetHigh = new DevComponents.DotNetBar.ButtonX();
            this.btnX_QuickMoveDown = new DevComponents.DotNetBar.ButtonX();
            this.bntX_GUIOff = new DevComponents.DotNetBar.ButtonX();
            this.bntX_MoveUp = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.line1);
            this.panelEx1.Controls.Add(this.btnX_Connect);
            this.panelEx1.Controls.Add(this.btnX_Disconnect);
            this.panelEx1.Controls.Add(this.btn_ConState);
            this.panelEx1.Controls.Add(this.bntX_MoveHalt);
            this.panelEx1.Controls.Add(this.btnX_SetLow);
            this.panelEx1.Controls.Add(this.bntX_MoveDown);
            this.panelEx1.Controls.Add(this.bntX_GUIOn);
            this.panelEx1.Controls.Add(this.btnX_MoveQuickUp);
            this.panelEx1.Controls.Add(this.btnX_SetHigh);
            this.panelEx1.Controls.Add(this.btnX_QuickMoveDown);
            this.panelEx1.Controls.Add(this.bntX_GUIOff);
            this.panelEx1.Controls.Add(this.bntX_MoveUp);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(-1, -1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(142, 500);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 89;
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(10, 393);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(120, 10);
            this.line1.TabIndex = 101;
            this.line1.Text = "line1";
            // 
            // btnX_Connect
            // 
            this.btnX_Connect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnX_Connect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_Connect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_Connect.Image = ((System.Drawing.Image)(resources.GetObject("btnX_Connect.Image")));
            this.btnX_Connect.Location = new System.Drawing.Point(10, 405);
            this.btnX_Connect.Name = "btnX_Connect";
            this.btnX_Connect.Size = new System.Drawing.Size(120, 40);
            this.btnX_Connect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_Connect.TabIndex = 99;
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
            this.btnX_Disconnect.Location = new System.Drawing.Point(10, 451);
            this.btnX_Disconnect.Name = "btnX_Disconnect";
            this.btnX_Disconnect.Size = new System.Drawing.Size(120, 40);
            this.btnX_Disconnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_Disconnect.TabIndex = 100;
            this.btnX_Disconnect.Text = "断     开";
            this.btnX_Disconnect.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.btnX_Disconnect.Click += new System.EventHandler(this.btnX_Disconnect_Click);
            // 
            // btn_ConState
            // 
            this.btn_ConState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConState.Enabled = false;
            this.btn_ConState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConState.Location = new System.Drawing.Point(10, 10);
            this.btn_ConState.Name = "btn_ConState";
            this.btn_ConState.Size = new System.Drawing.Size(120, 40);
            this.btn_ConState.TabIndex = 98;
            this.btn_ConState.Text = "OFFLINE";
            this.btn_ConState.UseVisualStyleBackColor = true;
            // 
            // bntX_MoveHalt
            // 
            this.bntX_MoveHalt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveHalt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveHalt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveHalt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveHalt.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveHalt.Image")));
            this.bntX_MoveHalt.Location = new System.Drawing.Point(10, 154);
            this.bntX_MoveHalt.Name = "bntX_MoveHalt";
            this.bntX_MoveHalt.Size = new System.Drawing.Size(120, 40);
            this.bntX_MoveHalt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveHalt.TabIndex = 91;
            this.bntX_MoveHalt.Text = "保     持";
            this.bntX_MoveHalt.Click += new System.EventHandler(this.bntX_MoveHalt_Click);
            // 
            // btnX_SetLow
            // 
            this.btnX_SetLow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_SetLow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_SetLow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_SetLow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_SetLow.Location = new System.Drawing.Point(75, 353);
            this.btnX_SetLow.Name = "btnX_SetLow";
            this.btnX_SetLow.Size = new System.Drawing.Size(55, 40);
            this.btnX_SetLow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_SetLow.TabIndex = 95;
            this.btnX_SetLow.Text = "LOW";
            this.btnX_SetLow.Click += new System.EventHandler(this.btnX_SetLow_Click);
            // 
            // bntX_MoveDown
            // 
            this.bntX_MoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveDown.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveDown.Image")));
            this.bntX_MoveDown.Location = new System.Drawing.Point(10, 202);
            this.bntX_MoveDown.Name = "bntX_MoveDown";
            this.bntX_MoveDown.Size = new System.Drawing.Size(120, 40);
            this.bntX_MoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveDown.TabIndex = 92;
            this.bntX_MoveDown.Text = "向     下";
            this.bntX_MoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bntX_MoveDown_MouseDown);
            this.bntX_MoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bntX_MoveDown_MouseUp);
            // 
            // bntX_GUIOn
            // 
            this.bntX_GUIOn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_GUIOn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_GUIOn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_GUIOn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_GUIOn.Location = new System.Drawing.Point(10, 307);
            this.bntX_GUIOn.Name = "bntX_GUIOn";
            this.bntX_GUIOn.Size = new System.Drawing.Size(55, 40);
            this.bntX_GUIOn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_GUIOn.TabIndex = 94;
            this.bntX_GUIOn.Text = "ON";
            this.bntX_GUIOn.Click += new System.EventHandler(this.bntX_GUIOn_Click);
            // 
            // btnX_MoveQuickUp
            // 
            this.btnX_MoveQuickUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_MoveQuickUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_MoveQuickUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_MoveQuickUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_MoveQuickUp.Image = ((System.Drawing.Image)(resources.GetObject("btnX_MoveQuickUp.Image")));
            this.btnX_MoveQuickUp.Location = new System.Drawing.Point(10, 58);
            this.btnX_MoveQuickUp.Name = "btnX_MoveQuickUp";
            this.btnX_MoveQuickUp.Size = new System.Drawing.Size(120, 40);
            this.btnX_MoveQuickUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_MoveQuickUp.TabIndex = 90;
            this.btnX_MoveQuickUp.Text = " 快速向上";
            this.btnX_MoveQuickUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnX_MoveQuickUp_MouseDown);
            this.btnX_MoveQuickUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnX_MoveQuickUp_MouseUp);
            // 
            // btnX_SetHigh
            // 
            this.btnX_SetHigh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_SetHigh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_SetHigh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_SetHigh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_SetHigh.Location = new System.Drawing.Point(10, 353);
            this.btnX_SetHigh.Name = "btnX_SetHigh";
            this.btnX_SetHigh.Size = new System.Drawing.Size(55, 40);
            this.btnX_SetHigh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_SetHigh.TabIndex = 97;
            this.btnX_SetHigh.Text = "HIGH";
            this.btnX_SetHigh.Click += new System.EventHandler(this.btnX_SetHigh_Click);
            // 
            // btnX_QuickMoveDown
            // 
            this.btnX_QuickMoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnX_QuickMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX_QuickMoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnX_QuickMoveDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnX_QuickMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnX_QuickMoveDown.Image")));
            this.btnX_QuickMoveDown.Location = new System.Drawing.Point(10, 250);
            this.btnX_QuickMoveDown.Name = "btnX_QuickMoveDown";
            this.btnX_QuickMoveDown.Size = new System.Drawing.Size(120, 40);
            this.btnX_QuickMoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnX_QuickMoveDown.TabIndex = 93;
            this.btnX_QuickMoveDown.Text = " 快速向下";
            this.btnX_QuickMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnX_QuickMoveDown_MouseDown);
            this.btnX_QuickMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnX_QuickMoveDown_MouseUp);
            // 
            // bntX_GUIOff
            // 
            this.bntX_GUIOff.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_GUIOff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_GUIOff.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_GUIOff.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_GUIOff.Location = new System.Drawing.Point(75, 307);
            this.bntX_GUIOff.Name = "bntX_GUIOff";
            this.bntX_GUIOff.Size = new System.Drawing.Size(55, 40);
            this.bntX_GUIOff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_GUIOff.TabIndex = 96;
            this.bntX_GUIOff.Text = "OFF";
            this.bntX_GUIOff.Click += new System.EventHandler(this.bntX_GUIOff_Click);
            // 
            // bntX_MoveUp
            // 
            this.bntX_MoveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntX_MoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bntX_MoveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntX_MoveUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntX_MoveUp.Image = ((System.Drawing.Image)(resources.GetObject("bntX_MoveUp.Image")));
            this.bntX_MoveUp.Location = new System.Drawing.Point(10, 106);
            this.bntX_MoveUp.Name = "bntX_MoveUp";
            this.bntX_MoveUp.Size = new System.Drawing.Size(120, 40);
            this.bntX_MoveUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntX_MoveUp.TabIndex = 89;
            this.bntX_MoveUp.Text = "向     上";
            this.bntX_MoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bntX_MoveUp_MouseDown);
            this.bntX_MoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bntX_MoveUp_MouseUp);
            // 
            // FormFloat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(140, 497);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(156, 536);
            this.Name = "FormFloat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FormFloat_Load);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Button btn_ConState;
        private DevComponents.DotNetBar.ButtonX bntX_MoveHalt;
        private DevComponents.DotNetBar.ButtonX btnX_SetLow;
        private DevComponents.DotNetBar.ButtonX bntX_MoveDown;
        private DevComponents.DotNetBar.ButtonX bntX_GUIOn;
        private DevComponents.DotNetBar.ButtonX btnX_MoveQuickUp;
        private DevComponents.DotNetBar.ButtonX btnX_SetHigh;
        private DevComponents.DotNetBar.ButtonX btnX_QuickMoveDown;
        private DevComponents.DotNetBar.ButtonX bntX_GUIOff;
        private DevComponents.DotNetBar.ButtonX bntX_MoveUp;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.ButtonX btnX_Connect;
        private DevComponents.DotNetBar.ButtonX btnX_Disconnect;
    }
}