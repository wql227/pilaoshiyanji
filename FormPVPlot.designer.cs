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
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPVPlot));
            this.cb_ShowPosition = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.datarefresh_timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
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
            this.cb_ShowPosition.Location = new System.Drawing.Point(375, 12);
            this.cb_ShowPosition.Name = "cb_ShowPosition";
            this.cb_ShowPosition.Size = new System.Drawing.Size(102, 23);
            this.cb_ShowPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_ShowPosition.TabIndex = 72;
            this.cb_ShowPosition.Text = "峰谷值";
            this.cb_ShowPosition.Visible = false;
            this.cb_ShowPosition.CheckedChanged += new System.EventHandler(this.cb_ShowPosition_CheckedChanged);
            // 
            // datarefresh_timer
            // 
            this.datarefresh_timer.Enabled = true;
            this.datarefresh_timer.Interval = 500;
            this.datarefresh_timer.Tick += new System.EventHandler(this.datarefresh_timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 73;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            this.axTChart1.OnClickLegend += new AxTeeChart.ITChartEvents_OnClickLegendEventHandler(this.axTChart1_OnClickLegend);
            // 
            // FormPVPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 563);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_ShowPosition);
            this.Controls.Add(this.axTChart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPVPlot";
            this.Text = "峰谷值曲线";
            this.Load += new System.EventHandler(this.FormDensity_Load);
            this.Shown += new System.EventHandler(this.FormDensity_Shown);
            this.VisibleChanged += new System.EventHandler(this.FormPVPlot_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.axTChart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxTeeChart.AxTChart axTChart1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cb_ShowPosition;
        private System.Windows.Forms.Timer datarefresh_timer;
        private System.Windows.Forms.Button button1;
    }
}