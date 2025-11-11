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
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public string userName = "";

        /// <summary>
        /// 登陆用户的密码
        /// </summary>
        public string userPwd = "";

        public FrmLogin()
        {
            InitializeComponent();
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LoadIni();

            cbX_SelectUser.SelectedIndex = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbX_SelectUser.Text))
            {
                MessageBox.Show("请选择一个用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbX_SelectUser.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbX_UserPwd.Text))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbX_UserPwd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(MainForm.mainform.strUserPwd))
            {
                string strtmp = DESEncrypt.Encrypt(tbX_UserPwd.Text);
            }

            if (MainForm.mainform.strUserPwd != DESEncrypt.Encrypt(tbX_UserPwd.Text))
            {
                MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbX_UserPwd.Focus();
                return;
            }
            else
            {
                MainForm.mainform.strLoginName = cbX_SelectUser.Text;
                MainForm.mainform.strUserPwd = DESEncrypt.Encrypt(tbX_UserPwd.Text);
                MessageBox.Show("登陆成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            WriteIni();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 加载配置文件
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder strTmp = new StringBuilder(255);
            string strConfigSetion = "Setting";

            //读取用户密码
            IniFileHelper.GetIniString(strConfigSetion, "UserPWD", "", strTmp, strTmp.Capacity);
            MainForm.mainform.strUserPwd = strTmp.ToString();
        }


        /// <summary>
        /// 保存配置文件参数
        /// </summary>
        public void WriteIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            strTmp = cbX_SelectUser.Text;
            IniFileHelper.WriteIniString("Setting", "LoginName", strTmp);

            if (!string.IsNullOrEmpty(tbX_UserPwd.Text))
            {
                strTmp = DESEncrypt.Encrypt(tbX_UserPwd.Text);
                IniFileHelper.WriteIniString("Setting", "UserPWD", strTmp);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public void ModifyPwd()
        {
            if (string.IsNullOrEmpty(tbX_UserPwd.Text))
            {
                MessageBox.Show("请输入登陆密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MainForm.mainform.strUserPwd != DESEncrypt.Encrypt(tbX_UserPwd.Text))
            {
                MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbX_UserPwd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbX_Pwd.Text) || string.IsNullOrEmpty(tbX_ConfrimPwd.Text))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbX_Pwd.Text != tbX_ConfrimPwd.Text)
            {
                MessageBox.Show("两次输入密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbX_Pwd.Text.Length < 5)
            {
                MessageBox.Show("密码不能小于5位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbX_UserPwd.Text == tbX_Pwd.Text)
            {
                MessageBox.Show("新密码不能跟原密码密码一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            string strTmp = "";
            if (!string.IsNullOrEmpty(tbX_Pwd.Text))
            {
                IniFileHelper.WriteIniString("Setting", "UserPWD", DESEncrypt.Encrypt(tbX_Pwd.Text));
                MainForm.mainform.strUserPwd = DESEncrypt.Encrypt(tbX_Pwd.Text);

                IniFileHelper.WriteIniString("Setting", "LoginName", cbX_SelectUser.Text);

                MessageBox.Show("修改密码成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnX_ModifyPwd_Click(object sender, EventArgs e)
        {
            ModifyPwd();
        }
    }
}
