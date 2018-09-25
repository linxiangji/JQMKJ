using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.PoClass
{
    /// <summary>
    /// 结合MIB文件定义的ONU设备用户相关信息类
    /// </summary>
    [Serializable]
    public class OnuUniMacAddressEntryPo
    {
        //编号
        public int id;
        public string onuUniDeviceIndex;
        public string onuUniIndex;
        public string onuUniMacAddress;
        public string onuUniMacAddressType;
        public string onuUniVid;
        public string onuUniStatic;
        public string onuUniMulticast;
        //创建时间
        public string createTime;
    }
}
