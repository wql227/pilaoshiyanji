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
            timer_ShowData.Interval = 500; // 每 500ms 检查一次
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
                tb_Sensor4.Text = String.Format("{0}", (_parent.gSample.Sensor[(int)DoPE.SENSOR.SENSOR_4] / 1000000).ToString("0.000"));
                tb_Sensor5.Text = String.Format("{0}", (_parent.gSample.Sensor[(int)DoPE.SENSOR.SENSOR_5] / 1000000).ToString("0.000"));
                tb_Sensor6.Text = String.Format("{0}", (_parent.gSample.Sensor[(int)DoPE.SENSOR.SENSOR_6] / 1000000).ToString("0.000"));
                tb_Sensor7.Text = String.Format("{0}", (_parent.gSample.Sensor[(int)DoPE.SENSOR.SENSOR_7] / 1000000).ToString("0.000"));
            }
        }

        private void FrmMultiSensor_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_ShowData.Stop();
        }

        public void LoadSettings()
        {

            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);

            //多传感器   
            IniFileHelper.GetIniString("MultiSensor", "MainParam", "蓄能器压力显示", strTmp, strTmp.Capacity);
            this.Text = strTmp.ToString();

            IniFileHelper.GetIniString("MultiSensor", "Para1Name", "蓄能器1", strTmp, strTmp.Capacity);
            labelX8.Text = strTmp.ToString();

            IniFileHelper.GetIniString("MultiSensor", "Para1Unit", "MPa", strTmp, strTmp.Capacity);
            labelX20.Text = strTmp.ToString();

            IniFileHelper.GetIniString("MultiSensor", "Para2Name", "蓄能器2", strTmp, strTmp.Capacity);
            labelX1.Text = strTmp.ToString();

            IniFileHelper.GetIniString("MultiSensor", "Para2Unit", "MPa", strTmp, strTmp.Capacity);
            labelX21.Text = strTmp.ToString();

            IniFileHelper.GetIniString("MultiSensor", "Para3Name", "蓄能器3", strTmp, strTmp.Capacity);
            labelX2.Text = strTmp.ToString();

            IniFileHelper.GetIniString("MultiSensor", "Para3Unit", "MPa", strTmp, strTmp.Capacity);
            labelX23.Text = strTmp.ToString();

            IniFileHelper.GetIniString("MultiSensor", "Para4Name", "蓄能器4", strTmp, strTmp.Capacity);
            labelX3.Text = strTmp.ToString();

            IniFileHelper.GetIniString("MultiSensor", "Para4Unit", "MPa", strTmp, strTmp.Capacity);
            labelX24.Text = strTmp.ToString();
        }
    }

}
