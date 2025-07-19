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
    public partial class FrmSetChartAxisY : Form
    {
        public FrmSetChartAxisY()
        {
            InitializeComponent();
        }


        private void FrmSetChartAxisY_Load(object sender, EventArgs e)
        {
            LoadIni();
        }


        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            string strConfigSetion = this.Name;

            IniFileHelper.GetIniString(strConfigSetion, "PositionEnable", "0", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_PosEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "LoadEnable", "0", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_LoadEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "ExtEnable", "0", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_ExtEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "CommandEnable", "0", strTmp, strTmp.Capacity);
            cbX_FrmSetChartAxisY_CommandEnable.Checked = strTmp.ToString() == "0" ? false : true;

            IniFileHelper.GetIniString(strConfigSetion, "PositionY_MAX", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_PosY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "PositionY_MIN", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_PosY_Min.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "LoadY_MAX", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_LoadY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "LoadY_MIN", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_LoadY_Min.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "ExtY_MAX", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_ExtY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "ExtY_MIN", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_ExtY_Min.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "CommandY_MAX", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_CommandY_Max.Text = strTmp.ToString();

            IniFileHelper.GetIniString(strConfigSetion, "CommandY_MIN", "0", strTmp, strTmp.Capacity);
            tbX_FrmSetChartAxisY_CommandY_Min.Text = strTmp.ToString();

        }

        public void WriteIni()
        {
            string strTmp = "";
            strTmp = cbX_FrmSetChartAxisY_PosEnable.Checked == false ? "0" : "1";
            IniFileHelper.WriteIniString("Setting", "PositionEnable", strTmp);

            strTmp = cbX_FrmSetChartAxisY_LoadEnable.Checked == false ? "0" : "1";
            IniFileHelper.WriteIniString("Setting", "LoadEnable", strTmp);

            strTmp = cbX_FrmSetChartAxisY_ExtEnable.Checked == false ? "0" : "1";
            IniFileHelper.WriteIniString("Setting", "ExtEnable", strTmp);

            strTmp = cbX_FrmSetChartAxisY_CommandEnable.Checked == false ? "0" : "1";
            IniFileHelper.WriteIniString("Setting", "CommandEnable", strTmp);

            strTmp = tbX_FrmSetChartAxisY_PosY_Max.Text.ToString();
            IniFileHelper.WriteIniString("Setting", "PositionY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_PosY_Min.Text.ToString();
            IniFileHelper.WriteIniString("Setting", "PositionY_MIN", strTmp);

            strTmp = tbX_FrmSetChartAxisY_LoadY_Max.Text.ToString();
            IniFileHelper.WriteIniString("Setting", "LoadY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_LoadY_Min.Text.ToString();
            IniFileHelper.WriteIniString("Setting", "LoadY_MIN", strTmp);

            strTmp = tbX_FrmSetChartAxisY_ExtY_Max.Text.ToString();
            IniFileHelper.WriteIniString("Setting", "ExtY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_ExtY_Min.Text.ToString();
            IniFileHelper.WriteIniString("Setting", "ExtY_MIN", strTmp);

            strTmp = tbX_FrmSetChartAxisY_CommandY_Min.Text.ToString();
            IniFileHelper.WriteIniString("Setting", "CommandY_MAX", strTmp);

            strTmp = tbX_FrmSetChartAxisY_CommandY_Min.Text.ToString();
            IniFileHelper.WriteIniString("Setting", "CommandY_MIN", strTmp);
        }


        private void btn_FrmSerAxisY_OK_Click(object sender, EventArgs e)
        {

        }

        private void btn_FrmSerAxisY_Cancel_Click(object sender, EventArgs e)
        {

        }

      
    }
}
