using OnuDevInfoOnUserModel.BoClass;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.DBClass
{
    [Serializable]
    public class ClsFrmResultPageDataDB
    {
        //最终ONU用户信息结果字典
        public static ConcurrentDictionary<string, ClsResultInfoTableBo> resultInfoDictionaryDataDB = new ConcurrentDictionary<string, ClsResultInfoTableBo>();
    }
}
