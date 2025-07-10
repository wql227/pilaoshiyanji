using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DoPENetConnect
{
    public class LanguageLoad
    {
        public static Dictionary<string, Dictionary<string, string>> LoadLang(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("语言文件未找到", filePath);
            }

            var json = File.ReadAllText(filePath);
            var langData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);

            return langData;
        }

    }
}
