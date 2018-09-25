using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.Enum;
using OnuDevInfoOnUserModel.VoClass;
using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    [Serializable]
    public class ClsSnmpOptHelper
    {
        public static object lockObj=new object();
        public static string SetOnuDevMacAddressOID = GetSetOnuDevMacAddressOIDFromConfig();
        public static string SetOnuDevIndexOID = SetOnuDevIndexOIDFromConfig();

        public static string GetOnuMacAddressSubTreeOID = GetOnuMacAddressSubTreeOIDFromConfig();

        //用户侧信息Entry
        public static string GetOnuUniMacAddressEntryOid = "1.3.6.1.4.1.17409.2.3.38207.1.1.4.1";
        //得到用户侧表的所有字段OID
        public static string GetOnuUniDeviceIndexOid = "1.3.6.1.4.1.17409.2.3.38207.1.1.4.1.1";
        public static string GetOnuUniIndexOid = "1.3.6.1.4.1.17409.2.3.38207.1.1.4.1.2";
        public static string GetOnuUniMacAddressOid = "1.3.6.1.4.1.17409.2.3.38207.1.1.4.1.3";
        public static string GetOnuUniVidOid = "1.3.6.1.4.1.17409.2.3.38207.1.1.4.1.4";
        public static string GetOnuUniStaticOid = "1.3.6.1.4.1.17409.2.3.38207.1.1.4.1.5";
        public static string GetOnuUniMulticastOid = "1.3.6.1.4.1.17409.2.3.38207.1.1.4.1.6";
        /// <summary>
        /// 得到Set操作设备索引的OID
        /// </summary>
        /// <returns></returns>
        private static string SetOnuDevIndexOIDFromConfig()
        {
            return ClsCofigHelper.readCofigValueByKey("SetOnuDevIndexOID");
        }
        /// <summary>
        /// 得到Set操作用户侧MacAddress的OID路径
        /// </summary>
        /// <returns></returns>
        public static string GetSetOnuDevMacAddressOIDFromConfig()
        {
            return ClsCofigHelper.readCofigValueByKey("SetOnuDevMacAddressOID");
        }
        /// <summary>
        /// 得到查询Olt下连接多少台ONU设备的OID
        /// </summary>
        /// <returns></returns>
        private static string GetOnuMacAddressSubTreeOIDFromConfig()
        {
            return ClsCofigHelper.readCofigValueByKey("GetOnuMacAddressSubTreeOID");
        }
       
        /// <summary>
        /// SNMP进行Set操作设置ONU的Mac地址，指定要查找哪台ONU
        /// </summary>
        public static bool SetOptOnuDevIndexMethod(ClsResultInfoTableBo currResultInfoTableBo)
        {
            bool isSetSuccessFlag = false;
            UdpTarget target = null;
            try
            {
                OctetString community = new OctetString(currResultInfoTableBo.oltInfoVo.writeCommunity);
                AgentParameters param = new AgentParameters(community);
                // SNMP 版本 1 (or 2)
                param.Version = SnmpVersion.Ver2;
                IpAddress agentHostAddress = new IpAddress(currResultInfoTableBo.oltInfoVo.ipAddress);
                target = new UdpTarget((IPAddress)agentHostAddress, currResultInfoTableBo.snmpPduInfoVo.port, currResultInfoTableBo.snmpPduInfoVo.timeOut, currResultInfoTableBo.snmpPduInfoVo.snmpReTry);
                // 填充请求需要发送的PDU数据包参数
                Pdu pdu = new Pdu(PduType.Set);
                string snmpTrueMacAddress = ClsRegexHelper.GetOptMacAddress(currResultInfoTableBo.onuInfoEntryVo.onuMacAddress);
                pdu.VbList.Add(new Oid(currResultInfoTableBo.snmpPduInfoVo.setOnuDevIndexOid),new UInteger32(currResultInfoTableBo.onuInfoEntryVo.onuDeviceIndex.ToString()));
                // 发送PDU包进行SNMP网络请求，且得到请求的结果
                SnmpV2Packet currSnmpV2PacketResult = (SnmpV2Packet)target.Request(pdu, param);
                // 进行snmp得到的结果判断
                if (currSnmpV2PacketResult != null)
                {
                    //对snmp得到PDU结果数据包进行错误判断
                    Pdu currSnmpV2ResponseResultPDU = currSnmpV2PacketResult.Pdu;
                    if (currSnmpV2ResponseResultPDU.ErrorStatus != 0)
                    {
                        currResultInfoTableBo.optMsgInfoVo.optIndex = currSnmpV2ResponseResultPDU.ErrorIndex;
                        currResultInfoTableBo.optMsgInfoVo.optStatus = (EnumSnmpOptStatus)currSnmpV2ResponseResultPDU.ErrorStatus;
                        currResultInfoTableBo.optMsgInfoVo.optMsg = "SNMP-Set索引请求失败（状态码：" + ClsEnumHelper.GetEnumDescription(currResultInfoTableBo.optMsgInfoVo.optStatus)+")";
                    }
                    else
                    {
                        //SNMP操作成功
                        currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.NO_ERROR;
                        currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.NO_ERROR);
                        isSetSuccessFlag = true;
                    }
                }
                else
                {
                    currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.SNMP_NOT_REPONSE_MESSAGE;
                    currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.SNMP_NOT_REPONSE_MESSAGE);
                }
            }
            catch (Exception ex)
            {
                currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.SNMP_ERROR_SET_REQUEST;
                currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.SNMP_ERROR_SET_REQUEST)+"[Error:"+ ex.Message+ "]";
            }
            finally
            {
                if (target!=null)
                {
                    target.Dispose();
                }
            }
            return isSetSuccessFlag;
        }
        /// <summary>
        /// 查询ONU设备MacAddress地址子树的所有信息
        /// </summary>
        /// <param name="currResultInfoTableBo"></param>
        /// <returns></returns>
        public static Dictionary<string, ClsOnuInfoEntryVo> GetSubTreeOnuMacAddressInfo(ClsResultInfoTableBo currResultInfoTableBo)
        {
            Dictionary<string,ClsOnuInfoEntryVo> currOnuInfoEntryVoDictionary = new Dictionary<string,ClsOnuInfoEntryVo>();
            while (true)
            {
                ClsOnuInfoEntryVo currOnuInfoEntryVo = new ClsOnuInfoEntryVo();
                if (GetOnuMacAddressInfoByGetNextMethod(currResultInfoTableBo, currOnuInfoEntryVo) == false)
                {
                    break;
                }
                if (ClsRegexHelper.IsMacAddress(currOnuInfoEntryVo.onuMacAddress)==false)
                {
                    break;
                }
                currOnuInfoEntryVoDictionary.Add(currOnuInfoEntryVo.onuMacAddress, currOnuInfoEntryVo);
                Thread.Sleep(10);
            }
            return currOnuInfoEntryVoDictionary;
        }

        /// <summary>
        /// 进行getNext操作获取ONU用户信息主要逻辑
        /// </summary>
        public static bool GetOnuMacAddressInfoByGetNextMethod(ClsResultInfoTableBo currResultInfoTableBo, ClsOnuInfoEntryVo currOnuInfoEntryVo)
        {
            bool isSetSuccessFlag = false;
            UdpTarget target = null;
            try
            {
                OctetString community = new OctetString(currResultInfoTableBo.oltInfoVo.readCommunity);
                AgentParameters param = new AgentParameters(community);
                // SNMP 版本 1 (or 2)
                param.Version = SnmpVersion.Ver2;
                IpAddress agentHostAddress = new IpAddress(currResultInfoTableBo.oltInfoVo.ipAddress);
                target = new UdpTarget((IPAddress)agentHostAddress, currResultInfoTableBo.snmpPduInfoVo.port, currResultInfoTableBo.snmpPduInfoVo.timeOut, currResultInfoTableBo.snmpPduInfoVo.snmpReTry);
                // 填充请求需要发送的PDU数据包参数
                Pdu pdu = new Pdu(PduType.GetNext);
                pdu.VbList.Add(new Oid(currResultInfoTableBo.snmpPduInfoVo.onuDevIndexOid));
                // 发送PDU包进行SNMP网络请求，且得到请求的结果
                SnmpV2Packet currSnmpV2PacketResult = (SnmpV2Packet)target.Request(pdu, param);
                if (currSnmpV2PacketResult != null)
                {
                    //对snmp得到PDU结果数据包进行错误判断
                    Pdu currSnmpV2ResponseResultPDU = currSnmpV2PacketResult.Pdu;
                    if (currSnmpV2ResponseResultPDU.ErrorStatus != 0)
                    {
                        currResultInfoTableBo.optMsgInfoVo.optIndex = currSnmpV2ResponseResultPDU.ErrorIndex;
                        currResultInfoTableBo.optMsgInfoVo.optStatus = (EnumSnmpOptStatus)currSnmpV2ResponseResultPDU.ErrorStatus;
                        currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(currResultInfoTableBo.optMsgInfoVo.optStatus);
                    }
                    else
                    {
                        if (currSnmpV2ResponseResultPDU.VbList.Count>0)
                        {
                            //SNMP操作成功
                            string responseResultOID = currSnmpV2ResponseResultPDU.VbList[0].Oid.ToString();
                            string responseResultValueMac = currSnmpV2ResponseResultPDU.VbList[0].Value.ToString().ToLower();
                            currOnuInfoEntryVo.onuDeviceIndex = Convert.ToInt32(responseResultOID.Substring(responseResultOID.LastIndexOf(".")+1));
                            currOnuInfoEntryVo.onuMacAddress = responseResultValueMac;

                            /*Console.WriteLine("Success in SNMP Descr({0}) ({1}): {2}",
                            currSnmpV2ResponseResultPDU.VbList[0].Oid.ToString(), SnmpConstants.GetTypeName(currSnmpV2ResponseResultPDU.VbList[0].Value.Type),
                            currSnmpV2ResponseResultPDU.VbList[0].Value.ToString());
                            */
                            currResultInfoTableBo.snmpPduInfoVo.onuDevIndexOid = responseResultOID;
                            currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.NO_ERROR;
                            currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.NO_ERROR);
                            isSetSuccessFlag = true;
                        }
                    }
                }
                else
                {
                    currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.SNMP_NOT_REPONSE_MESSAGE;
                    currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.SNMP_NOT_REPONSE_MESSAGE);
                }
            }
            catch (Exception ex)
            {
                currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.SNMP_ERROR_GETNEXT_REQUEST;
                currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.SNMP_ERROR_GETNEXT_REQUEST) + "[Error:" + ex.Message + "]";
            }
            finally
            {
                if (target != null)
                {
                    target.Dispose();
                }
            }
            return isSetSuccessFlag;
        }
        /// <summary>
        /// 查询ONU设备用户侧MacAddress地址子树的所有信息
        /// </summary>
        /// <param name="currResultInfoTableBo"></param>
        /// <returns></returns>
        public static Dictionary<string, ClsOnuUniMacAddressEntryVo> GetSubTreeOnuUserMacAddressInfo(ClsResultInfoTableBo currResultInfoTableBo)
        {
            Dictionary<string, ClsOnuUniMacAddressEntryVo> currOnuInfoEntryVoDictionary = new Dictionary<string, ClsOnuUniMacAddressEntryVo>();
            while (true)
            {
                ClsOnuUniMacAddressEntryVo currOnuUniMacAddressEntryVo = new ClsOnuUniMacAddressEntryVo();
                if (GetOnuUserInfoByGetNextMethod(currResultInfoTableBo, currOnuUniMacAddressEntryVo) == false)
                {
                    break;
                }
                if (ClsRegexHelper.IsMacAddress(currOnuUniMacAddressEntryVo.onuUniMacAddress)==false)
                {
                    currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniDeviceIndex = "";
                    currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniIndex = "";
                    currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMacAddress = "";
                    currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniVid = "";
                    currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniStatic = "";
                    currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMulticast = "";
                    break;
                }
                currOnuInfoEntryVoDictionary.Add(currOnuUniMacAddressEntryVo.onuUniMacAddress, currOnuUniMacAddressEntryVo);
                Thread.Sleep(10);
            }
            return currOnuInfoEntryVoDictionary;
        }
        /// <summary>
        /// 进行getNext操作获取ONU用户信息主要逻辑
        /// </summary>
        public static bool GetOnuUserInfoByGetNextMethod(ClsResultInfoTableBo currResultInfoTableBo,ClsOnuUniMacAddressEntryVo currOnuUniMacAddressEntryVo)
        {
            bool isSetSuccessFlag = false;
            UdpTarget target = null;
            try
            {
                OctetString community = new OctetString(currResultInfoTableBo.oltInfoVo.readCommunity);
                AgentParameters param = new AgentParameters(community);
                // SNMP 版本 1 (or 2)
                param.Version = SnmpVersion.Ver2;
                IpAddress agentHostAddress = new IpAddress(currResultInfoTableBo.oltInfoVo.ipAddress);
                target = new UdpTarget((IPAddress)agentHostAddress, currResultInfoTableBo.snmpPduInfoVo.port, currResultInfoTableBo.snmpPduInfoVo.timeOut, currResultInfoTableBo.snmpPduInfoVo.snmpReTry);
                // 填充请求需要发送的PDU数据包参数
                Pdu pdu = new Pdu(PduType.GetNext);
                pdu.VbList.Add(new Oid(currResultInfoTableBo.snmpPduInfoVo.onuUniMacAddressOid));
                pdu.VbList.Add(new Oid(currResultInfoTableBo.snmpPduInfoVo.onuUniVidOid));
                pdu.VbList.Add(new Oid(currResultInfoTableBo.snmpPduInfoVo.onuUniStaticOid));
                pdu.VbList.Add(new Oid(currResultInfoTableBo.snmpPduInfoVo.onuUniMulticastOid));
                // 发送PDU包进行SNMP网络请求，且得到请求的结果
                SnmpV2Packet currSnmpV2PacketResult = (SnmpV2Packet)target.Request(pdu, param);
                if (currSnmpV2PacketResult != null)
                {
                    //对snmp得到PDU结果数据包进行错误判断
                    Pdu currSnmpV2ResponseResultPDU = currSnmpV2PacketResult.Pdu;
                    if (currSnmpV2ResponseResultPDU.ErrorStatus != 0)
                    {
                        currResultInfoTableBo.optMsgInfoVo.optIndex = currSnmpV2ResponseResultPDU.ErrorIndex;
                        currResultInfoTableBo.optMsgInfoVo.optStatus = (EnumSnmpOptStatus)currSnmpV2ResponseResultPDU.ErrorStatus;
                        currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(currResultInfoTableBo.optMsgInfoVo.optStatus);
                    }
                    else
                    {

                        if (currSnmpV2ResponseResultPDU.VbList.Count > 0)
                        {
                            //SNMP操作成功
                            /*Console.WriteLine("Success in SNMP Descr({0}) ({1}): {2}",
                            currSnmpV2ResponseResultPDU.VbList[0].Oid.ToString(), SnmpConstants.GetTypeName(currSnmpV2ResponseResultPDU.VbList[0].Value.Type),
                            currSnmpV2ResponseResultPDU.VbList[0].Value.ToString());
                            */
                            currResultInfoTableBo.snmpPduInfoVo.onuUniMacAddressOid = currSnmpV2ResponseResultPDU.VbList[0].Oid.ToString();
                            currResultInfoTableBo.snmpPduInfoVo.onuUniVidOid = currSnmpV2ResponseResultPDU.VbList[1].Oid.ToString();
                            currResultInfoTableBo.snmpPduInfoVo.onuUniStaticOid = currSnmpV2ResponseResultPDU.VbList[2].Oid.ToString();
                            currResultInfoTableBo.snmpPduInfoVo.onuUniMulticastOid = currSnmpV2ResponseResultPDU.VbList[3].Oid.ToString();

                            string[] stringArray = null;
                            lock (lockObj)
                            {
                                stringArray = currSnmpV2ResponseResultPDU.VbList[0].Oid.ToString().Split('.');
                            }
                            currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniDeviceIndex = stringArray[stringArray.Length-2];
                            currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniIndex = stringArray[stringArray.Length - 1];
                            currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMacAddress = currSnmpV2ResponseResultPDU.VbList[0].Value.ToString();
                            currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniVid = currSnmpV2ResponseResultPDU.VbList[1].Value.ToString();
                            currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniStatic = currSnmpV2ResponseResultPDU.VbList[2].Value.ToString();
                            currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMulticast = currSnmpV2ResponseResultPDU.VbList[3].Value.ToString();

                            currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.NO_ERROR;
                            currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.NO_ERROR);

                            currOnuUniMacAddressEntryVo.onuUniDeviceIndex = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniDeviceIndex;
                            currOnuUniMacAddressEntryVo.onuUniIndex = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniIndex;
                            currOnuUniMacAddressEntryVo.onuUniMacAddress = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMacAddress.ToLower();
                            currOnuUniMacAddressEntryVo.onuUniVid = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniVid ;
                            currOnuUniMacAddressEntryVo.onuUniStatic = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniStatic;
                            currOnuUniMacAddressEntryVo.onuUniMulticast = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMulticast ;
                           
                            isSetSuccessFlag = true;
                        }
                    }
                }
                else
                {
                    currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.SNMP_NOT_REPONSE_MESSAGE;
                    currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.SNMP_NOT_REPONSE_MESSAGE);
                }
            }
            catch (Exception ex)
            {
                currResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.SNMP_ERROR_GETNEXT_REQUEST;
                currResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.SNMP_ERROR_GETNEXT_REQUEST) + "[Error:" + ex.Message + "]";
            }
            finally
            {
                if (target != null)
                {
                    target.Dispose();
                }
            }
            return isSetSuccessFlag;
        }
    }
}
