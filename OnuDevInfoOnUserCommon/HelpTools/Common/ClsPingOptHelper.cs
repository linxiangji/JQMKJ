using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    [Serializable]
    public class ClsPingOptHelper
    {
        public static bool IsPingOLTDevSuccessConnect(ClsResultInfoTableBo currResultInfoTableBo)
        {
            bool isSuccessPingFlag = false;
            try
            {
                if (currResultInfoTableBo.oltInfoVo != null)
                {
                    Ping pingOltDev = new Ping();
                    PingReply currPingOptReply = pingOltDev.Send(currResultInfoTableBo.oltInfoVo.ipAddress, currResultInfoTableBo.currHeaderConfParamVo.pingTimeOutTime); //发送主机名或Ip地址
                    if (currPingOptReply.Status == IPStatus.Success)
                    {
                        isSuccessPingFlag = true;
                    }
                    else
                    {
                        currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.PING_CANNOT_CONNECT;
                        currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.PING_CANNOT_CONNECT);
                    }
                }
            }
            catch (Exception ex)
            {
                return isSuccessPingFlag;
            }
            return isSuccessPingFlag;
        }
    }
}
