using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.PoClass
{
    /// <summary>
    /// 自定义的SNMP请求发送的PDU报文信息类
    /// </summary>
    [Serializable]
    public class SnmpPduInfoPo
    {
        //编号
        public int id;
        //ip地址
        public string ipAddress;
        //端口号
        public int port;
        //读共同体
        public string readCommunity;
        //写共同体
        public string writeCommunity;
        //snmp版本号,如1、2、3
        public int snmpVersion;
        //操作指令：get 、get next、Bulk、get subTree 、 set 、walk
        public string snmpCommand;
        //得到ONU设备对应的索引
        public string onuDevIndexOid;
        //设置ONU的MacAddress地址请求的OID
        public string setOnuMacAddressOid;
        //设置ONU的设备索引的OID
        public string setOnuDevIndexOid;
        //以下为ONU用户信息查询所需的OID
        public string onuUniDeviceIndexOid;
        public string onuUniIndexOid;
        public string onuUniMacAddressOid;
        public string onuUniVidOid;
        public string onuUniStaticOid;
        public string onuUniMulticastOid;
        //snmp重新尝试请求数
        public int snmpReTry;
        //snmp超时时间
        public int timeOut;
        //创建时间
        public string createTime;
    }
}
