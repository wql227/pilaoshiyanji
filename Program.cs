using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoPENetConnect
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //配置日志
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(System.IO.Directory.GetCurrentDirectory() + "\\log4net.config"));

            Application.Run(new MainForm());
        }
    }
}
