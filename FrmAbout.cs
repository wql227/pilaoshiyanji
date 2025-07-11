using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DevComponents.DotNetBar2;

namespace DoPENetConnect
{
    public partial class FrmAbout : Office2007Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string strtitle = "";
            var attrs = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attrs.Length > 0)
            {
                var attr = (AssemblyTitleAttribute)attrs[0];
                if (attr.Title != "")
                {
                    strtitle = attr.Title;
                }
            }

            attrs = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            string strCompany = (attrs.Length == 0) ? "" : ((AssemblyCompanyAttribute)attrs[0]).Company;

            //获取程序标识
            attrs = assembly.GetCustomAttributes(typeof(GuidAttribute), false);
            Guid gGuid = (attrs.Length == 0) ? Guid.Empty : new Guid(((GuidAttribute)attrs[0]).Value.ToString());

            //获取程序说明
            attrs = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            string strDescription = (attrs.Length == 0) ? "" : ((AssemblyDescriptionAttribute)attrs[0]).Description;

            labelX1.Text = string.Format(@"{0}", strtitle + " - " + assembly.GetName().Name);
            labelX2.Text = string.Format("{0}", assembly.GetName().Version);
            labelX3.Text = string.Format(@"{0}", gGuid.ToString());
            labelX4.Text = string.Format(@"{0}", strDescription);
            labelX4.Text = string.Format(@"{0}", Environment.UserName + " @ " + Environment.MachineName);
            labelX5.Text = string.Format(@"{0}", Environment.OSVersion.ToString());
            labelX6.Text = string.Format(@"{0}", Environment.Version.ToString());
            labelX7.Text = string.Format(@"：{0}", assembly.Location);
            labelX8.Text = string.Format(@"{0}", Environment.WorkingSet.ToString("N0") + " bytes");

            labelX9.Text = "程序名称：";
            labelX10.Text = "程序版本：";
            labelX11.Text = "程序标识：";
            labelX12.Text = "计算机用户：";
            labelX13.Text = "操作系统：";
            labelX14.Text = "公共语言运行库：";
            labelX15.Text = "程序文件名称：";
            labelX16.Text = "程序内存使用：";
        }

        
    }
}
