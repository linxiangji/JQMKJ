using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserServiceInterface.ServiceInterfaces
{
    public interface IResultPageDataService
    {
        ConcurrentDictionary<string, ClsResultInfoTableBo> GetAllResultDataFromService();
        ClsResultInfoTableBo GetResultDataListByOltIpFromService(ClsOltInfoVo currOltInfoVo, ClsOnuInfoEntryVo currOnuInfoEntryVo);
        ClsResultInfoTableBo GetResultDataByOltIpAndMacFromService(ClsOltInfoVo currOltInfoVo, ClsOnuInfoEntryVo currOnuInfoEntryVo);
    }
}
