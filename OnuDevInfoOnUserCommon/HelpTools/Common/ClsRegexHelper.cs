using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserCommon.HelpTools
{
   public class ClsRegexHelper
    {
        /// <summary>
        /// 验证是否是MAC地址
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        public static bool IsMacAddress(string macAddress)
        {
            Regex regex = new Regex(@"^([0-9a-fA-F]{2})(([/\s:-][0-9a-fA-F]{2}){5})$");
            return regex.IsMatch(macAddress);
        }
        /// <summary>
        ///  得到进行SNMP请求的MAC地址
        /// </summary>
        /// <param name="oldMacAddress"></param>
        /// <returns></returns>
        public static string GetOptMacAddress(string oldMacAddress)
        {
            return "0x " + Regex.Replace(oldMacAddress.ToLower(), @"(:|-)", " ");
        }
        /// <summary>
        /// 得到没有符号的MAC地址
        /// </summary>
        /// <param name="oldMacAddress"></param>
        /// <returns></returns>
        public static string GetOptMacAddressKey(string oldMacAddress)
        {
            return Regex.Replace(oldMacAddress.ToLower(), @"(:|-)", " ");
        }
        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            Regex regex = new Regex(@"^[+]{0,1}(\d+)$");
            return regex.IsMatch(str);
        }
        /// <summary>
        /// 验证纯字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLetter(string str)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            return regex.IsMatch(str);
        }
        /// <summary>
        /// 验证是否是IP地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIpAddress(string str)
        {
            Regex rx = new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
            return rx.IsMatch(str);
        }
        /// <summary>
        /// 判断是否是读写共同
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsCommunity(string str)
        {
            if ("public".Equals(str))
            {
                return true;
            } else if ("private".Equals(str))
            {
                return true;
            }
            else if ("ocn".Equals(str))
            {
                return true;
            }
            return false;
        }
    }
}
