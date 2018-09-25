using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserViewInterface.ViewInterfaces
{
    public interface IFrmUpdateDataView
    {
        void BtnSaveDataClick(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo);
        void BtnCancelClick();
    }
}
