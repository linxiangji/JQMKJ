using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserViewInterface.ViewInterfaces
{
    public interface IFrmMainResultPageView
    {
        void GetAllResultDataFromController();
        void GetResultDataByOltIpFromController(ClsOltInfoVo currOltInfoVo, ClsOnuInfoEntryVo currOnuInfoEntryVo);
        void GetResultDataByOltIpAndMacFromController(ClsOltInfoVo currOltInfoVo,ClsOnuInfoEntryVo currOnuInfoEntryVo);
        
    }
}
