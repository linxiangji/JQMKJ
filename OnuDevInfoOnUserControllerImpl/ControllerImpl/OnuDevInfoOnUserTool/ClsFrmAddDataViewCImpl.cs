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
    public class ClsFrmAddDataViewCImpl : IFrmAddDataView
    {
        private IFrmAddDataViewCallBack m_frmAddDataViewCallBack = null;

        public ClsFrmAddDataViewCImpl(Form thisOptFrm)
        {
            if (thisOptFrm != null)
            {
                this.m_frmAddDataViewCallBack = (IFrmAddDataViewCallBack)thisOptFrm;
            }
        }

        public void BtnAddDataClick(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            if (m_frmAddDataViewCallBack!=null&&oltInfoVo!=null&&onuInfoEntryVo!=null)
            {
                m_frmAddDataViewCallBack.BtnAddDataClickCallBack(oltInfoVo, onuInfoEntryVo);
            }
        }

        public void BtnCancelClick()
        {
            if (m_frmAddDataViewCallBack != null)
            {
                m_frmAddDataViewCallBack.BtnCancelClickCallBack();
            }
        }
    }
}
