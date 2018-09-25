using OnuDevInfoOnUserControllerInterface.ControllerInterfaces;
using OnuDevInfoOnUserModel.VoClass;
using OnuDevInfoOnUserViewInterface.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserControllerImpl.ControllerImpl
{
    [Serializable]
    public class ClsFrmUpdateDataViewCImpl : IFrmUpdateDataView
    {
        private IFrmUpdateDataViewCallBack m_frmUpdateDataViewCallBack = null;

        public ClsFrmUpdateDataViewCImpl(Form thisOptFrm)
        {
            if (thisOptFrm != null)
            {
                this.m_frmUpdateDataViewCallBack = (IFrmUpdateDataViewCallBack)thisOptFrm;
            }
        }

        public void BtnCancelClick()
        {
            if (m_frmUpdateDataViewCallBack != null)
            {
                m_frmUpdateDataViewCallBack.BtnCancelClickCallBack();
            }
        }

        public void BtnSaveDataClick(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            if (m_frmUpdateDataViewCallBack != null)
            {
                m_frmUpdateDataViewCallBack.BtnSaveDataClickCallBack(oltInfoVo, onuInfoEntryVo);
            }
        }
    }
}
