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

namespace DoPENetConnect
{
    public partial class FrmMultiSensor : Form
    {
        private MainForm _parent;

        public FrmMultiSensor(MainForm _mainForm)
        {
            InitializeComponent();
            _parent = _mainForm;
        }


        private void FrmMultiSensor_Load(object sender, EventArgs e)
        {
            //timer_ShowData = new Timer();
            timer_ShowData.Interval = 500; // 每 500ms 检查一次
            //timer_ShowData.Tick += (s, e) => UpdateData();
            timer_ShowData.Start();
        }




        private void btn_FrmMultiSensor_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_ShowData_Tick(object sender, EventArgs e)
        {
            if (_parent.bConnected)
            {
                tb_Sensor4.Text = String.Format("{0}", (_parent.Sample.Sensor[(int)DoPE.SENSOR.SENSOR_4] / 1000000).ToString("0.000"));

                tb_Sensor5.Text = String.Format("{0}", (_parent.Sample.Sensor[(int)DoPE.SENSOR.SENSOR_5] / 1000000).ToString("0.000"));
                tb_Sensor6.Text = String.Format("{0}", (_parent.Sample.Sensor[(int)DoPE.SENSOR.SENSOR_6] / 1000000).ToString("0.000"));
                tb_Sensor7.Text = String.Format("{0}", (_parent.Sample.Sensor[(int)DoPE.SENSOR.SENSOR_7] / 1000000).ToString("0.000"));
       
            }
        }

        private void FrmMultiSensor_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_ShowData.Stop();
        }
    }

}
