using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsConfigHelper
    {
        /// <summary>
        /// 通过keyName读取配置文件appSettings节点中对应的值
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string readCofigValueByKey(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName];
        }
        /// <summary>
        /// 通过keyName来修改配置文件appSettings节点中对应的值
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="newValue"></param>
        public static void updateConfigValueByKey(string keyName, string newValue)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            config.AppSettings.Settings[keyName].Value = newValue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
