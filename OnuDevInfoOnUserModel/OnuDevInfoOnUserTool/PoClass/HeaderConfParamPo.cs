using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.PoClass
{
    /// <summary>
    /// 程序运行的内部各种参数配置类
    /// </summary>
    [Serializable]
    public class HeaderConfParamPo
    {
        public int id;
        //缓冲时间，每次Set且Get指令后的请求，怕设备忙不过来
        public int appSleepTime;
        public int pingTimeOutTime;
        public int snmpTimeOutTime;
        public int workThreadNum;
        public string createTime;
    }
}
