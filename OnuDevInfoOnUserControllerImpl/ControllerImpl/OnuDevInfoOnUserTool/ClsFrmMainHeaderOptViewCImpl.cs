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
    public class ClsFrmMainHeaderOptViewCImpl : IFrmMainHeaderOptView
    {

        private IFrmMainHeaderOptViewCallBack m_frmMainHeaderOptViewCallBack = null;

        public ClsFrmMainHeaderOptViewCImpl(Form thisOptFrm)
        {
            if (thisOptFrm != null)
            {
                this.m_frmMainHeaderOptViewCallBack = (IFrmMainHeaderOptViewCallBack)thisOptFrm;
            }
        }
        public void ShowFrmVersion(ClsVersionVo versionVo)
        {
            if (versionVo!=null&& m_frmMainHeaderOptViewCallBack!=null)
            {
                m_frmMainHeaderOptViewCallBack.ShowFrmVersionCallBack(versionVo);
            }
        }
    }
}
