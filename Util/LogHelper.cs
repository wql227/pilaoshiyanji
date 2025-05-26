using System;
using System.IO;
using System.Windows.Forms;

namespace DoPE10Net_CSharpDemo
{
    public class LogHelper
    {
        //// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input"></param>
        public static void WriteLogFile(string input, bool showmsg = false)
        {
            if (showmsg)
            {
                MessageBox.Show(input, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                string filename = DateTime.Now.ToString("yyyyMMdd") + ".log";
                string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string strLogPath = System.AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
                // 判断文件夹是否存在
                if (!Directory.Exists(strLogPath))
                {
                    // 创建文件夹
                    Directory.CreateDirectory(strLogPath);
                }

                System.IO.FileInfo file = new System.IO.FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + filename); //如果是web程序，这个的变成Http什么的
                System.IO.StreamWriter sw = null;
                if (!file.Exists)
                {
                    sw = file.CreateText();
                    sw.WriteLine(dt + " " + input.ToString());
                }
                else
                {
                    sw = file.AppendText();
                    sw.WriteLine(dt + " " + input.ToString());
                }
                sw.Close();
                sw.Flush();
                sw.Dispose();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }

        }

    }
}
