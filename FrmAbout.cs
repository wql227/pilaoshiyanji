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
            ReplaceLanguage();

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
        }


        /// <summary>
        /// 替换界面语言
        /// </summary>
        public void ReplaceLanguage()
        {
            string strLanguage = MainForm.mainform.strLanguage;
            var langData = LanguageLoad.LoadLang(System.IO.Directory.GetCurrentDirectory() + "\\Lang\\" + strLanguage + ".json");

            //循环界面控件替换成指定的语言
            if (langData.TryGetValue(this.Name, out var mainFormLabels))
            {
                foreach (var kvp in mainFormLabels)
                {
                    var controlName = kvp.Key;
                    var textValue = kvp.Value;

                    // 根据控件名称查找控件（可以扩展为递归查找）
                    var ctrl = this.Controls.Find(controlName, true).FirstOrDefault();
                    if (ctrl != null)
                    {
                        ctrl.Text = textValue;
                    }
                }

                //foreach (var kvp in mainFormLabels)
                //{
                //    var controlName = kvp.Key;
                //    var textValue = kvp.Value;

                //    // 首先尝试从主窗体的控件集合中查找控件
                //    var ctrl = this.Controls.Find(controlName, true).FirstOrDefault();

                //    if (ctrl == null && this is Form form)
                //    {
                //        // 如果未找到，则检查 SuperTabControl 中的所有 SuperTabItem
                //        foreach (Control c in form.Controls)
                //        {
                //            if (c is SuperTabControl superTabControl)
                //            {
                //                foreach (SuperTabItem tabItem in superTabControl.Tabs)
                //                {
                //                    // 获取当前 TabItem 的内容区域
                //                    Control contentContainer = GetContentContainer(tabItem);
                //                    if (contentContainer != null)
                //                    {
                //                        ctrl = contentContainer.Controls.Find(controlName, true).FirstOrDefault();
                //                        if (ctrl != null)
                //                        {
                //                            break; // 找到后跳出循环
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }

                //    if (ctrl != null)
                //    {
                //        ctrl.Text = textValue;
                //    }
                //}

                //foreach (var kvp in mainFormLabels)
                //{
                //    var controlName = kvp.Key;
                //    var textValue = kvp.Value;
                //}
            }
        }


        private Control GetContentContainer(SuperTabItem tabItem)
        {
            // 获取 SuperTabItem 对应的内容区域
            return tabItem.AttachedControl;
        }

    }
}
