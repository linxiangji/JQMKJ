using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.Enum
{
    /// <summary>
    /// 错误码枚举
    /// (1) 0 - 5 错误码为snmp请求得到的错误码情况
    /// (2) 50错误码及以上的为程序自定义的错误码与描述
    /// </summary>
    public enum EnumSnmpOptStatus
    {
        [Description("成功")]
        NO_ERROR=0,
        [Description("说明：代理无法将回答装入到一个SNMP报文之中(状态码：1)")]
        TOO_BIG = 1,
        [Description("说明：操作指明了一个不存在的变量(状态码：2)")]
        NO_SUCH_NAME = 2,
        [Description("说明：一个set操作指明了一个无效值或无效语法(状态码：3)")]
        BAD_VALUE = 3,
        [Description("说明：管理进程试图修改一个只读变量(状态码：4)")]
        READ_ONLY = 4,
        [Description("说明：其他错误(状态码：5)")]
        OTHER_ERROR = 5,

        [Description("成功：OLT设备连接正常(状态码：50)")]
        PING_NO_ERROR = 50,
        [Description("说明：无法连接到OLT设备(状态码：51)")]
        PING_CANNOT_CONNECT = 51,
        [Description("说明：无法获取SNMP返回报文信息，请确认各个设备连接是否正常。(状态码：52)")]
        SNMP_NOT_REPONSE_MESSAGE = 52,
        [Description("说明：SNMP请求报文发送失败，请检查Mac地址是否存在(状态码：53)")]
        SNMP_NOT_REQUEST_SEND = 53,
        [Description("说明：SET操作OLT报文异常,请核实参数与线路是否正常(状态码：54)")]
        SNMP_ERROR_SET_REQUEST = 54,
        [Description("说明：GETNEXT操作OLT报文异常,请核实参数与线路是否正常(状态码：55)")]
        SNMP_ERROR_GETNEXT_REQUEST = 55,
        [Description("说明：此ONU设备没有连接任何用户设备(状态码：56)")]
        NO_ERROR_BUT_NO_USER_DEV = 56,
        [Description("说明：不能查找到此Mac地址的ONU设备，请确认OLT设备是否连接此ONU设备(状态码：57)")]
        ONU_DEV_CANNNOT_FIND_MAC = 57,
        [Description("说明：OLT设备没有查到当前ONU设备索引，请确认此ONU设备是否与OLT正常连接(状态码：58)")]
        OLT_ERROR_NO_FIND_DEV_INDEX = 58,
    }
}
