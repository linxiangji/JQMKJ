using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsLogHelper
    {
        public static ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Debug(string str)
        {
            m_log.Debug(str);
        }

        public static void Info(string str)
        {
            m_log.Info(str);
        }

        public static void Error(string str)
        {
            m_log.Error(str);
        }

        public static void Fatal(string str)
        {
            m_log.Fatal(str);
        }

        public static void Warn(string str)
        {
            m_log.Warn(str);
        }
    }
}
