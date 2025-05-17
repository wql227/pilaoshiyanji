using DevComponents.DotNetBar.Controls;
using Doli.DoPE10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Doli.DoPE10.DoPE;

namespace DoPE10Net_CSharpDemo
{
    public partial class FrmDynCtrl : Form
    {
        public FrmDynCtrl()
        {
            InitializeComponent();

            if (cmbX_Dyn_EDC.Items.Count >= 1)
            {
                cmbX_Dyn_EDC.SelectedIndex = 0;
            }

            if (cmbX_Dyn_StartCtrl.Items.Count >= 1)
            {
                cmbX_Dyn_StartCtrl.SelectedIndex = 0;
            }

            if (cmbX_Dyn_StartSpeed_Unit.Items.Count >= 1)
            {
                cmbX_Dyn_StartSpeed_Unit.SelectedIndex = 0;
            }

            if (cmbX_Dyn_MoveCtrl.Items.Count >= 1)
            {
                cmbX_Dyn_MoveCtrl.SelectedIndex = 0;
            }

            if (cmbX_Dyn_MoveCtrl_Unit.Items.Count >= 1)
            {
                cmbX_Dyn_MoveCtrl_Unit.SelectedIndex = 0;
            }

            if (cmbX_Dyn_WaveFrom.Items.Count >= 1)
            {
                cmbX_Dyn_WaveFrom.SelectedIndex = 0;
            }

            if (cmbX_Dyn_PeakCtrl.Items.Count >= 1)
            {
                cmbX_Dyn_PeakCtrl.SelectedIndex = 0;
            }

            cmbX_Dyn_PeakCtrl.Visible = false;

            cmbX_Dyn_StartCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

            cmbX_Dyn_WaveFrom.DataSource = System.Enum.GetNames(typeof(DoPE.DYN_WAVEFORM));

            cmbX_Dyn_MoveCtrl.DataSource = System.Enum.GetNames(typeof(DoPE.CTRL));

            tbX_Dyn_StartSpeed.Text = "20";

            tbX_Cycles.Text = "50";
            tbX_Dyn_PeakCtrl.Text = "0";
            tbX_Dyn_Offset.Text = "-10";
            tbX_Dyn_Amplitude.Text = "3";
            tbX_Dyn_Frequency.Text = "2";

        }

        private void cbX_PeakCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (cbX_Dyn_PeakCtrl.Checked)
            {
                cmbX_Dyn_PeakCtrl.Visible = true;
                tbX_Dyn_PeakCtrl.Visible = false;
            }
            else
            {
                cmbX_Dyn_PeakCtrl.Visible = false;
                tbX_Dyn_PeakCtrl.Visible = true;
            }
        }


        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnX_Dyn_Send_Click(object sender, EventArgs e)
        {
            DoPE.DYN_WAVEFORM WaveForm;
            bool Modify;
            DoPE.DYN_PEAKCTRL PeakCtrl;
            DoPE.CTRL MoveCtrl;
            bool RelativeDestination;
            double SpeedToStart;
            double Offset;
            double Amplitude;
            double HaltAtPlusAmplitude;
            double HaltAtMinusAmplitude;
            double Frequency;
            int HalfCycles;
            double SpeedToDestination;
            double Destination;
            DoPE.DYN_SWEEP SweepFrequencyMode;

            WaveForm = (DoPE.DYN_WAVEFORM)cmbX_Dyn_WaveFrom.SelectedIndex;

            if (cbX_Dyn_PeakCtrl.Checked)
            {
                PeakCtrl = (DoPE.DYN_PEAKCTRL)int.Parse(cmbX_Dyn_PeakCtrl.Text);
            }
            else
            {
                PeakCtrl = (DoPE.DYN_PEAKCTRL)int.Parse(tbX_Dyn_PeakCtrl.Text);
            }

            MoveCtrl = (DoPE.CTRL)cmbX_Dyn_MoveCtrl.SelectedIndex;
            SpeedToStart = double.Parse(tbX_Dyn_StartSpeed.Text);
            Offset = double.Parse(tbX_Dyn_Offset.Text);
            Amplitude = double.Parse(tbX_Dyn_Amplitude.Text);
            Frequency = double.Parse(tbX_Dyn_Frequency.Text);
            HalfCycles = int.Parse(tbX_Cycles.Text); /** 2;*/
            Modify = false;
            RelativeDestination = false;
            HaltAtPlusAmplitude = 0.0;
            HaltAtMinusAmplitude = 0.0;
            SpeedToDestination = 0.0;
            Destination = 0.0;
            SweepFrequencyMode = 0;

            MainForm.mainform.MoveDynCycles(WaveForm, Modify, PeakCtrl, MoveCtrl, RelativeDestination, SpeedToStart, Offset, Amplitude, HaltAtPlusAmplitude, HaltAtMinusAmplitude, Frequency, HalfCycles, SpeedToDestination, Destination, SweepFrequencyMode);

        }
    }
}
