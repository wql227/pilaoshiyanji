namespace DoPENetConnect
{
    partial class FormPVPlot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPVPlot));
            this.cb_ShowPosition = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.axTChart1 = new AxTeeChart.AxTChart();
            ((System.ComponentModel.ISupportInitialize)(this.axTChart1)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_ShowPosition
            // 
            // 
            // 
            // 
            this.cb_ShowPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cb_ShowPosition.Checked = true;
            this.cb_ShowPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ShowPosition.CheckValue = "Y";
            this.cb_ShowPosition.Location = new System.Drawing.Point(134, 10);
            this.cb_ShowPosition.Name = "cb_ShowPosition";
            this.cb_ShowPosition.Size = new System.Drawing.Size(58, 23);
            this.cb_ShowPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_ShowPosition.TabIndex = 72;
            this.cb_ShowPosition.Text = "密度";
            this.cb_ShowPosition.CheckedChanged += new System.EventHandler(this.cb_ShowPosition_CheckedChanged);
            // 
            // axTChart1
            // 
            this.axTChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTChart1.Enabled = true;
            this.axTChart1.Location = new System.Drawing.Point(0, 0);
            this.axTChart1.Name = "axTChart1";
            this.axTChart1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTChart1.OcxState")));
            this.axTChart1.Size = new System.Drawing.Size(1325, 563);
            this.axTChart1.TabIndex = 70;
            // 
            // FormDensity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 563);
            this.Controls.Add(this.cb_ShowPosition);
            this.Controls.Add(this.axTChart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDensity";
            this.Text = "密度曲线";
            this.Load += new System.EventHandler(this.FormDensity_Load);
            this.Shown += new System.EventHandler(this.FormDensity_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.axTChart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxTeeChart.AxTChart axTChart1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cb_ShowPosition;
    }
}