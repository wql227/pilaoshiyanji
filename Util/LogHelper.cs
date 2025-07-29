using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace DoPENetConnect
{
    public class LogHelper
    {
        private static ILog log;

        static LogHelper()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);//通过反射获取日志对象实例
        }

        /// <summary>
        /// Fatal记录
        /// </summary>
        /// <param name="info"></param>
        public static void Fatal(string info)
        {
            log.Fatal(info);
        }


        /// <summary>
        /// Error记录
        /// </summary>
        /// <param name="info"></param>
        public static void Error(string info)
        {
            log.Error(info);
        }


        /// <summary>
        /// Warn记录
        /// </summary>
        /// <param name="info"></param>
        public static void Warn(string info)
        {
            log.Warn(info);
        }


        /// <summary>
        /// Warn记录
        /// </summary>
        /// <param name="info"></param>
        public static void Info(string info)
        {
            log.Info(info);
        }


        /// <summary>
        /// Fatal记录
        /// </summary>
        /// <param name="info"></param>
        public static void Debug(string info)
        {
            log.Debug(info);
        }


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
                string logFilePath = Path.Combine(strLogPath, filename);
    
                // 判断文件夹是否存在
                if (!Directory.Exists(strLogPath))
                {
                    // 创建文件夹
                    Directory.CreateDirectory(strLogPath);
                }

                // 创建目录（如果不存在）
                if (!Directory.Exists(strLogPath))
                {
                    Directory.CreateDirectory(strLogPath);
                }

                // 检查文件大小并滚动
                int maxFileSize = 10 * 1024 * 1024; // 10MB
                FileInfo fi = new FileInfo(logFilePath);

                if (fi.Exists && fi.Length > maxFileSize)
                {
                    // 滚动日志文件（保留最多 5 个备份）
                    for (int i = 4; i >= 1; i--)
                    {
                        string oldFile = Path.Combine(strLogPath, $"{filename}.{i}");
                        if (File.Exists(oldFile))
                        {
                            File.Delete(oldFile);
                        }

                        string prevFile = Path.Combine(strLogPath, $"{filename}.{i - 1}");
                        if (File.Exists(prevFile))
                        {
                            File.Move(prevFile, oldFile);
                        }
                    }

                    // 将当前日志文件重命名为 .0，然后创建新文件
                    string backupFile = Path.Combine(strLogPath, $"{filename}.0");
                    if (File.Exists(backupFile))
                    {
                        File.Delete(backupFile);
                    }

                    File.Move(logFilePath, backupFile);
                }

                // 写入新的日志内容
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine($"{dt} {input}");
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }

        }


        /// <summary>
        /// 保存数值
        /// </summary>
        /// <param name="strs">strs为对应的参数字符,值之间用","隔开</param>
        public static void SaveCsvData(string strs)
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string logPath = Path.Combine(baseDirectory, "Logs");
                string dateStr = DateTime.Now.ToString("yyyy-MM-dd");

                StringBuilder tmpStr = new StringBuilder(255);
                IniFileHelper.GetIniString("AppOpenIndex", "IndexVal", "-1", tmpStr, tmpStr.Capacity);
                
                logPath = Path.Combine(logPath, dateStr);        //添加日期文件夹
                logPath = Path.Combine(logPath, tmpStr.ToString());
                string filename = Path.Combine(logPath, $"{dateStr}.CSV");

                // 创建目录（如果不存在）
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                int maxFileSize = 1 * 1024 * 1024; // 10 MB
                FileInfo fi = new FileInfo(filename);

                // 如果文件存在且超过最大大小，则进行滚动
                if (fi.Exists && fi.Length > maxFileSize)
                {
                    // 滚动旧文件，保留最多5个备份
                    for (int i = 4; i >= 1; i--)
                    {
                        string oldFile = Path.Combine(logPath, $"{dateStr}.CSV.{i}");
                        string prevFile = Path.Combine(logPath, $"{dateStr}.CSV.{i - 1}");

                        if (File.Exists(oldFile))
                        {
                            File.Delete(oldFile);
                        }

                        if (File.Exists(prevFile))
                        {
                            File.Move(prevFile, oldFile);
                        }
                    }

                    string firstBackup = Path.Combine(logPath, $"{dateStr}.CSV.0");
                    if (File.Exists(firstBackup))
                    {
                        File.Delete(firstBackup);
                    }
                    File.Move(filename, firstBackup);
                }

                // 如果文件不存在，先写入表头
                bool writeHeader = !File.Exists(filename);
                using (StreamWriter sw = new StreamWriter(filename, true, Encoding.Default))
                {
                    if (writeHeader)
                    {
                        string header = "Time [s],Position [mm],Load [N],Extension [Rev],Command [ ],Cycles [ ]";
                        sw.WriteLine(header);
                    }

                    sw.WriteLine(strs);
                }
            }
            catch (Exception ex)
            {
                // 可选：记录错误日志或弹出提示
                // MessageBox.Show(ex.Message);
            }
        }

        public void SetLogIndex() {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            StringBuilder tmpStr = new StringBuilder(255);
            IniFileHelper.GetIniString("AppOpenIndex", "Today", "-1", tmpStr, tmpStr.Capacity);
            string testStr = IniFileHelper.strIniFilePath;
            string dateStr = DateTime.Now.ToString("yyyy-MM-dd");
            if (tmpStr.ToString() is "-1" || tmpStr.ToString()!=dateStr) {

                IniFileHelper.WriteIniString("AppOpenIndex", "Today", dateStr);
                IniFileHelper.WriteIniString("AppOpenIndex", "IndexVal", "1");
                return;

            }


            IniFileHelper.GetIniString("AppOpenIndex", "IndexVal", "-1", tmpStr, tmpStr.Capacity);
            if (tmpStr.ToString() is "-1")
            {
                IniFileHelper.WriteIniString("AppOpenIndex", "IndexVal", "1");
                return;
            }

            int newIndex = (int.Parse(tmpStr.ToString()) + 1);

            IniFileHelper.WriteIniString("AppOpenIndex", "IndexVal", newIndex.ToString());


        }
}
}
