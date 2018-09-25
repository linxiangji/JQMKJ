using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserControllerInterface.ControllerInterfaces
{
    public interface IFrmAddDataViewCallBack
    {
        void BtnAddDataClickCallBack(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo);
        void BtnCancelClickCallBack();
    }
}
