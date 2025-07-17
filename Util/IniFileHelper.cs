using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DoPENetConnect
{
    // INI文件操作类
    class IniFileHelper
    {
        // ini配置文件路径
        public static string strIniFilePath { get; set; }

        //按BYTE方式读取配置文件
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(byte[] section, byte[] key, byte[] def, byte[] retVal, int size, string filePath);

        //按BYTE方式写入配置文件
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(byte[] section, byte[] key, byte[] val, string filePath);


        /// <summary>
        /// 编码格式
        /// </summary>
        public static string encodingName = "utf-8";

        //与ini交互必须统一编码格式
        private static byte[] getBytes(string s)
        {
            return null == s ? null : Encoding.GetEncoding(encodingName).GetBytes(s);
        }

        private static string getString(byte[] s)
        {
            return System.Text.Encoding.UTF8.GetString(s);
        }


        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="strIniFilePath">ini配置文件路径</param>
        /// <returns></returns>
        public IniFileHelper(string strIniFileName)
        {
            if (!String.IsNullOrEmpty(strIniFileName))
            {
                strIniFilePath = String.Concat(AppDomain.CurrentDomain.BaseDirectory, strIniFileName);
            }
        }


        /// <summary>
        /// 获取ini配置文件中的字符串
        /// </summary>
        /// <param name="section">节名</param>
        /// <param name="key">键名</param>
        /// <param name="strDefault">默认值</param>
        /// <param name="retVal">结果缓冲区</param>
        /// <param name="size">结果缓冲区大小</param>
        /// <returns>成功true,失败false</returns>
        public static bool GetIniString(string section, string key, string strDefault, StringBuilder retVal, int size)
        {
            byte[] buffer = new byte[size];
            int liRet = GetPrivateProfileString(getBytes(section), getBytes(key),
                getBytes(strDefault), buffer, size, strIniFilePath);
            string strRet = Encoding.GetEncoding(encodingName).GetString(buffer, 0, liRet).Trim();
            retVal.Clear();
            retVal.Append(strRet);
            return (liRet >= 1);
        }


        /// <summary>
        /// 往ini配置文件写入字符串
        /// </summary>
        /// <param name="section">节名</param>
        /// <param name="key">键名</param>
        /// <param name="val">要写入的字符串</param>
        /// <returns>成功true,失败false</returns>
        public static bool WriteIniString(string section, string key, string val)
        {
            return WritePrivateProfileString(getBytes(section), getBytes(key), getBytes(val), strIniFilePath);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <param name="size"></param>
        /// <param name="encodingName"></param>
        /// <returns></returns>
        public string ReadIniString(string section, string key, string defaultVal = "", int size = 1024)
        {
            byte[] buffer = new byte[size];
            int count = GetPrivateProfileString(getBytes(section), getBytes(key),
                getBytes(defaultVal), buffer, size, strIniFilePath);
            return Encoding.GetEncoding(encodingName).GetString(buffer, 0, count).Trim();
        }

    }
}
