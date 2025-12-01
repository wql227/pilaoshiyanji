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
    public partial class FormFloat : Form
    {
        int operateFlag = 0;
        public FormFloat()
        {
            InitializeComponent();
        }

        private void FormFloat_Load(object sender, EventArgs e)
        {
            this.Activate();
            btn_ConState.BackColor = Color.Red;


            labelX2.Visible = true;
            labelX3.Visible = false;
            this.TopMost = true;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="color"></param>
        public void btn_ConState_color(Color color)
        {
            btn_ConState.BackColor = color;
        }

        public void EnableButton(bool status)
        {
            if (status)
            {
                //btnX_Connect.Enabled = true;
                btnX_Disconnect.Enabled = true;
                btnX_MoveQuickUp.Enabled = true;
                bntX_MoveUp.Enabled = true;
                bntX_MoveHalt.Enabled = true;
                bntX_MoveDown.Enabled = true;
                btnX_QuickMoveDown.Enabled = true;
                bntX_GUIOn.Enabled = true;
                bntX_GUIOff.Enabled = true;
                btnX_SetHigh.Enabled = true;
                btnX_SetLow.Enabled = true;


                bntX_GUIOn.Checked = false;
                bntX_GUIOff.Checked = false;
                btnX_SetHigh.Checked = false;
                btnX_SetLow.Checked = false;

            }
            else
            {
                //btnX_Connect.Enabled = true;
                btnX_Disconnect.Enabled = false;
                btnX_MoveQuickUp.Enabled = false;
                bntX_MoveUp.Enabled = false;
                bntX_MoveHalt.Enabled = false;
                bntX_MoveDown.Enabled = false;
                btnX_QuickMoveDown.Enabled = false;
                bntX_GUIOn.Enabled = false;
                bntX_GUIOff.Enabled = false;
                btnX_SetHigh.Enabled = false;
                btnX_SetLow.Enabled = false;

                bntX_GUIOn.Checked = false;
                bntX_GUIOff.Checked = false;
                btnX_SetHigh.Checked = false;
                btnX_SetLow.Checked = false;
            }
        }


        public void btn_ConState_Text(string text) {
            btn_ConState.Text = text;
        }

        public void btnX_GUIOn_Enable(bool state)
        {
            bntX_GUIOn.Enabled = state;
        }


        public void btnX_GUIOn_Checked(bool state)
        {
            bntX_GUIOn.Checked = state;
        }

        public void SetControlEnable(bool bState)
        {
            //上下控制禁用
            btnX_MoveQuickUp.Enabled = bState;
            bntX_MoveUp.Enabled = bState;
            bntX_MoveDown.Enabled = bState;
            btnX_QuickMoveDown.Enabled = bState;
        }

        private void bntX_GUIOn_Click(object sender, EventArgs e)
        {
            MainForm.mainform.FormFloat_bntX_GUIOn_Click();
            bntX_GUIOn.Checked = true;
            btnX_SetLow.Checked = true;
            btnX_SetHigh.Checked = false;
        }

        public void bntX_GUIOn_Click()
        {
            MainForm.mainform.FormFloat_bntX_GUIOn_Click();
            bntX_GUIOn.Checked = true;
            btnX_SetLow.Checked = true;
            btnX_SetHigh.Checked = false;
        }

        private void bntX_GUIOff_Click(object sender, EventArgs e)
        {
            MainForm.mainform.FormFloat_bntX_GUIOff_Click();
            btnX_SetLow.Checked = false;
            btnX_SetHigh.Checked = false;
        }

        private void btnX_MoveQuickUp_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.mainform.FormFloat_btnX_MoveQuickUp_MouseDown();

        }

        private void btnX_MoveQuickUp_MouseUp(object sender, MouseEventArgs e)
        {

            MainForm.mainform.FormFloat_btnX_MoveQuickUp_MouseUp();
        }

        private void bntX_MoveUp_MouseDown(object sender, MouseEventArgs e)
        {

            MainForm.mainform.FormFloat_bntX_MoveUp_MouseDown();
        }

        private void bntX_MoveUp_MouseUp(object sender, MouseEventArgs e)
        {

            MainForm.mainform.FormFloat_bntX_MoveUp_MouseUp();
        }

        private void bntX_MoveHalt_Click(object sender, EventArgs e)
        {

            MainForm.mainform.FormFloat_bntX_MoveHalt_Click();
        }

        private void bntX_MoveDown_MouseDown(object sender, MouseEventArgs e)
        {

            MainForm.mainform.FormFloat_bntX_MoveDown_MouseDown();
        }

        private void bntX_MoveDown_MouseUp(object sender, MouseEventArgs e)
        {


            MainForm.mainform.FormFloat_bntX_MoveDown_MouseUp();
        }

        private void btnX_QuickMoveDown_MouseDown(object sender, MouseEventArgs e)
        {

            MainForm.mainform.FormFloat_btnX_QuickMoveDown_MouseDown();
        }

        private void btnX_QuickMoveDown_MouseUp(object sender, MouseEventArgs e)
        {

            MainForm.mainform.FormFloat_btnX_QuickMoveDown_MouseUp();
        }

        private void btnX_SetHigh_Click(object sender, EventArgs e)
        {

            MainForm.mainform.FormFloat_btnX_SetHigh_Click();
        }

        private void btnX_SetLow_Click(object sender, EventArgs e)
        {

            MainForm.mainform.FormFloat_btnX_SetLow_Click();
        }

        public void btnX_SetLow_Checked(bool state)
        {
            btnX_SetLow.Checked = state;
        }
        public void btnX_SetHigh_Checked(bool state)
        {
            btnX_SetHigh.Checked = state;
        }

        private void btnX_Connect_Click(object sender, EventArgs e)
        {

            MainForm.mainform.FormFloat_btnX_Connect_Click();

        }

        private void btnX_Disconnect_Click(object sender, EventArgs e)
        {
            btn_ConState.BackColor = Color.Red;
            btn_ConState.Text = "OFFLINE";
            MainForm.mainform.FormFloat_btnX_Disconnect_Click();
        }

        private void FormFloat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void FormFloat_Shown(object sender, EventArgs e)
        {
            LoadIni();
        }

        public void LoadIni()
        {
            //IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            //StringBuilder strTmp = new StringBuilder(255);

            ////按钮文字
            //IniFileHelper.GetIniString("PushButtonFunctionConstant", "UpText", "0", strTmp, strTmp.Capacity);
            //bntX_MoveUp.Text = strTmp.ToString();

            //IniFileHelper.GetIniString("PushButtonFunctionConstant", "HurryUpText", "0", strTmp, strTmp.Capacity);
            //btnX_MoveQuickUp.Text = strTmp.ToString();

            //IniFileHelper.GetIniString("PushButtonFunctionConstant", "DownText", "0", strTmp, strTmp.Capacity);
            //bntX_MoveDown.Text = strTmp.ToString();

            //IniFileHelper.GetIniString("PushButtonFunctionConstant", "HurryDownText", "0", strTmp, strTmp.Capacity);
            //btnX_QuickMoveDown.Text = strTmp.ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            MainForm.mainform.FormFloat_bntX_MoveHalt_Click();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {
            if (operateFlag == 0)
            {
                buttonX1.Visible = true;
                operateFlag = 1;
                this.Height = 172;
            }
            else if (operateFlag == 1)
            {
                buttonX1.Visible = false;
                operateFlag = 0;
                this.Height = 583;
            }
        }


        /// <summary>
        /// 设置状态按钮文本
        /// </summary>
        /// <param name="strStateText"></param>
        public void SetStateText(string strStateText)
        {
            btn_ConState.BackColor = Color.Red;
            btn_ConState.Text = strStateText;
        }

        private void labelX2_Click(object sender, EventArgs e)
        {
            labelX2.Visible = false;
            labelX3.Visible = true;
            this.TopMost = false;
        }

        private void labelX3_Click(object sender, EventArgs e)
        {
            labelX2.Visible = true;
            labelX3.Visible = false;
            this.TopMost = true;
        }
    }
    
}
