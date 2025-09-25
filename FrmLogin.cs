using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DevComponents.DotNetBar2;

namespace DoPENetConnect
{
    public partial class FrmLogin : Office2007Form
    {
        public string sysSuperPasswd = "newtest";
        public string sysCommonPasswd = "admin";
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            balloonTip1.SetBalloonText(textBoxX1, "输入密码后按回车键登录");
            LoadIni();
            //Console.WriteLine("login shown");
        }

        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            string strConfigSetion = this.Name;

            IniFileHelper.GetIniString("Account", "passwd", "0", strTmp, strTmp.Capacity);
            if (strTmp.ToString() == "0")
            {
            }
            else {
                sysCommonPasswd = strTmp.ToString();
            }

        }

        public void WritePasswdInfo(string passwdStr)
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            string strConfigSetion = this.Name;

            //按试验次数记录日志
            strTmp = passwdStr;
            sysCommonPasswd = passwdStr;
            IniFileHelper.WriteIniString("Account", "passwd", strTmp);
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     //enter 键按下
            {
                if (comboBoxEx1.Text == "")
                {
                    MessageBox.Show("账户输入为空，请重新输入后再试");
                    return;
                }
                else if (textBoxX1.Text == "")
                {
                    MessageBox.Show("密码输入为空，请重新输入后再试");
                }
                else if (comboBoxEx1.Text==comboBoxEx1.Items[2].ToString()) {


                    if (textBoxX1.Text == sysSuperPasswd)
                    {
                        MainForm.mainform.userInfo.userName = comboBoxEx1.Text;
                        MainForm.mainform.userInfo.isLogged = true;
                        MainForm.mainform.userInfo.passWd = textBoxX1.Text;
                        this.Close();
                    }
                    else {
                        MessageBox.Show("密码输入错误，请重新输入");
                        return;
                    }
                }
                else 
                {


                    if (textBoxX1.Text == sysCommonPasswd)
                    {
                        MainForm.mainform.userInfo.userName = comboBoxEx1.Text;
                        MainForm.mainform.userInfo.isLogged = true;
                        MainForm.mainform.userInfo.passWd = textBoxX1.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码输入错误，请重新输入");
                        return;
                    }
                }

            }
        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     //enter 键按下
            {
                if (comboBoxEx1.Text == "")
                {
                    //MessageBox.Show("账户输入为空，请重新输入后再试");
                    return;
                }
                else if (textBoxX1.Text == "")
                {
                    MessageBox.Show("密码输入为空，请重新输入后再试");
                }
                else if (textBoxX1.Text == sysSuperPasswd)
                {
                    MainForm.mainform.userInfo.userName = comboBoxEx1.Text;
                    MainForm.mainform.userInfo.isLogged = true;
                    this.Close();
                }
            }
        }

        //private void textBoxX1_MouseHover(object sender, EventArgs e)
        //{
        //    balloonTip1.SetBalloonText(textBoxX1, "输入密码后按回车键登录");
        //    balloonTip1.ShowBalloon(textBoxX1);
        //}
    }
}
