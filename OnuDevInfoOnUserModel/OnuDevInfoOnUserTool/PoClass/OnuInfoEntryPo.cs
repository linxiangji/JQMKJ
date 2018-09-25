using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.PoClass
{
    /// <summary>
    /// 结合MIB文件定义的ONU设备信息类
    /// </summary>
    [Serializable]
    public class OnuInfoEntryPo
    {
        //编号
        public int id;
        public int onuDeviceIndex;
        public string onuName;
        public int onuType;
        public string onuIpAddress;
        public string onuIpSubnetMask;
        public string onuIpGateway;
        public string onuMacAddress;
        public int onuOperationStatus;
        public int onuAdminStatus;
        public string onuChipVendor;
        public string onuChipType;
        public string onuChipVersion;
        public string onuSoftwareVersion;
        public string onuFirmwareVersion;
        public int onuTestDistance;
        public int onuLlidId;
        public int resetONU;
        public int onuTimeSinceLastRegister;
        public string onuVendorId;
        public string onuModelId;
        public string onuHardwareVersion;
        public string onuSn;
        public string onuTimeLastRegister;
        //创建时间
        public string createTime;
    }
}
