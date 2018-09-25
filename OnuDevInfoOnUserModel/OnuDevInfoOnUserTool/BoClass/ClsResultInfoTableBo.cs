using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.BoClass
{
    [Serializable]
    public class ClsResultInfoTableBo
    {
        public ClsOltInfoVo oltInfoVo;
        public ClsOnuInfoEntryVo onuInfoEntryVo;
        public ClsOnuUniMacAddressEntryVo onuUniMacAddressEntryVo;
        public ClsSnmpPduInfoVo snmpPduInfoVo;
        public ClsOptMsgInfoVo optMsgInfoVo;
        public ClsHeaderConfParamVo currHeaderConfParamVo;
        public List<ClsOnuUniMacAddressEntryVo> onuUniMacAddressEntryVoList;
    }
}
