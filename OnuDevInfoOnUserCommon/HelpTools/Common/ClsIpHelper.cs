using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsIpHelper
    {
        /// <summary>
        /// 检测IP
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public static bool PingIP(string strIP)
        {
            if (!IsValidIP(strIP))
            {
                return false;
            }
            Ping psender = new Ping();
            PingReply prep = psender.Send(strIP, 100);
            if (prep.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 验证IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidIP(string ip)
        {
            if (Regex.IsMatch(ip, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
            {
                string[] ips = ip.Split('.');
                if (ips.Length == 4 || ips.Length == 6)
                {
                    if (System.Int32.Parse(ips[0]) < 256 && System.Int32.Parse(ips[1]) < 256 & System.Int32.Parse(ips[2]) < 256 & System.Int32.Parse(ips[3]) < 256)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
