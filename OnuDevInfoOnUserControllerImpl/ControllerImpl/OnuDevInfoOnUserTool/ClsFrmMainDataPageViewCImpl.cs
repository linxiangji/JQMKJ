using OnuDevInfoOnUserControllerInterface.ControllerInterfaces;
using OnuDevInfoOnUserModel.VoClass;
using OnuDevInfoOnUserViewImpl.ViewInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserControllerImpl.ControllerImpl
{
    [Serializable]
    public class ClsFrmMainDataPageViewCImpl : IFrmMainDataPageView
    {
        private IFrmMainDataPageViewCallBack m_frmMainDataPageViewCallBack = null;

        public ClsFrmMainDataPageViewCImpl(Form thisOptFrm)
        {
            if (thisOptFrm != null)
            {
                this.m_frmMainDataPageViewCallBack = (IFrmMainDataPageViewCallBack)thisOptFrm;
            }
        }

        public void ShowFrmAddData()
        {
            if (m_frmMainDataPageViewCallBack != null)
            {
                m_frmMainDataPageViewCallBack.ShowFrmAddDataCallBack();
            }
        }

        public void ShowFrmUpdateData(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            if (m_frmMainDataPageViewCallBack!=null&& oltInfoVo!=null&& onuInfoEntryVo!=null)
            {
                m_frmMainDataPageViewCallBack.ShowFrmUpdateDataCallBack(oltInfoVo, onuInfoEntryVo);
            }
        }
    }
}
