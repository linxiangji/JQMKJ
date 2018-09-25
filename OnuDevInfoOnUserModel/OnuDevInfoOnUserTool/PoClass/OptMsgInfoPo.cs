using OnuDevInfoOnUserModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.PoClass
{
    /// <summary>
    /// 自定义的操作结果信息提示类,操作状态为optStatus==200即操作成功
    /// </summary>
    [Serializable]
    public class OptMsgInfoPo
    {
        //编号
        public int id;
        //操作用户Id
        public int optUserId;
        //操作方法
        public string optMethod;
        //操作指令
        public string optCommand;
        //操作状态
        public EnumSnmpOptStatus optStatus;
        //操作索引
        public int optIndex;
        //操作消息
        public string optMsg;
        //创建时间
        public string createTime;

    }
}
