using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.PoClass
{
    /// <summary>
    /// 自定义的OLT设备信息类
    /// </summary>
    [Serializable]
    public class OltInfoPo
    {
        //编号
        public int id;
        //名称
        public string name;
        //Ip地址
        public string ipAddress;
        //端口号
        public int port;
        //Mac地址
        public string macAddress;
        //读共同体
        public string readCommunity;
        //写共同体
        public string writeCommunity;
        //板卡号
        public int optCardNum;
        //创建时间
        public string createTime;

    }
}
