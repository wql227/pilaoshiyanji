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
        public string sysCommonPasswd = "1234";
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Shown(object sender, EventArgs e)
        {

            comboBoxEx1.Text = MainForm.mainform.userInfo.userName;   //打开时将用户名设置为已经登录的用户名
            SetUiAccordUserRole();
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
                if (MainForm.mainform.userInfo.userName != "管理人员")
                {
                    MessageBox.Show("只有管理人员才可以修改密码，请先登录管理人员账户！");
                    return;
                }

                if (comboBoxEx1.Text == "")
                {
                    MessageBox.Show("请选择需要修改密码的账户类型！");
                    return;
                }
                else if (comboBoxEx1.Text == "管理人员")
                {
                    MessageBox.Show("该类人员的密码无法被修改，请选择其他类型账户！");
                    return;
                }
                else if (textBoxX2.Text != textBoxX3.Text)
                {
                    MessageBox.Show("两次输入的密不相等请重新输入！");
                    return;
                }
                else
                {
                    WritePasswdInfo(textBoxX2.Text);
                    this.Close();
                }
            }
        }

        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     //enter 键按下
            {
                if (MainForm.mainform.userInfo.userName != "管理人员")
                {
                    MessageBox.Show("只有管理人员才可以修改密码，请先登录管理人员账户！");
                    return;
                }

                if (comboBoxEx1.Text == "")
                {
                    MessageBox.Show("请选择需要修改密码的账户类型！");
                    return;
                }
                else if (comboBoxEx1.Text == "管理人员")
                {
                    MessageBox.Show("该类人员的密码无法被修改，请选择其他类型账户！");
                    return;
                }
                else if (textBoxX2.Text != textBoxX3.Text)
                {
                    MessageBox.Show("两次输入的密不相等请重新输入！");
                    return;
                }
                else
                {
                    WritePasswdInfo(textBoxX2.Text);
                    this.Close();
                }
            }
        }
        /// <summary>
        /// 根据登录账户的类型来修改界面
        /// </summary>
        private void SetUiAccordUserRole()
        {
            switch (MainForm.mainform.userInfo.userName)
            {
                case "普通操作者":
                    textBoxX2.Enabled = false;
                    textBoxX3.Enabled = false;
                    break;
                case "高级操作者":
                    textBoxX2.Enabled = false;
                    textBoxX3.Enabled = false;
                    break;
                case "管理人员":
                    textBoxX2.Enabled = true;
                    textBoxX3.Enabled = true;
                    break;
            }
        }
    }
}
