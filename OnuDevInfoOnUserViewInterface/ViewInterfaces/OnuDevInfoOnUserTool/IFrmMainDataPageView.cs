using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserViewImpl.ViewInterface
{
    public interface IFrmMainDataPageView
    {
        void ShowFrmAddData();
        void ShowFrmUpdateData(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo);
    }
}
