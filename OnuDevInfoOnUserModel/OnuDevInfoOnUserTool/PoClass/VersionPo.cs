using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.PoClass
{
    /// <summary>
    /// 程序版本信息类
    /// </summary>
    [Serializable]
    public class VersionPo
    {
        //编号
        public int id;
        //主程序名称
        public string applicationName;
        //版本号
        public string versionNum;
        //编译时间
        public string compileTime;
        //版权
        public string copyright;
        //公司名称
        public string compangyName;
        //主页
        public string websiteAddress;
        //创建时间
        public string createTime;
    }
}
