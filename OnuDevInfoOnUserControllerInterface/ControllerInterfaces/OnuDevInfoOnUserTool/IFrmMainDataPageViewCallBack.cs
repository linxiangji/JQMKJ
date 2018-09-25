using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserControllerInterface.ControllerInterfaces
{
    public interface IFrmMainDataPageViewCallBack
    {
         void ShowFrmAddDataCallBack();
         void ShowFrmUpdateDataCallBack(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo);
    }
}
