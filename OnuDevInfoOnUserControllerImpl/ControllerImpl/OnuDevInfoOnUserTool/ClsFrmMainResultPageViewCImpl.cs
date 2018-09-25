using OnuDevInfoOnUserControllerInterface.ControllerInterfaces;
using OnuDevInfoOnUserViewInterface.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserServiceInterface.ServiceInterfaces;
using OnuDevInfoOnUserServiceImpl.ServiceImpl;
using OnuDevInfoOnUserModel.VoClass;

namespace OnuDevInfoOnUserControllerImpl.ControllerImpl
{
    [Serializable]
    public class ClsFrmMainResultPageViewCImpl: IFrmMainResultPageView
    {
        private IFrmMainResultPageViewCallBack m_frmMainResultPageViewCallBack = null;
        private IResultPageDataService m_resultPageDataService = new ClsResultPageDataServiceImpl();

        public ClsFrmMainResultPageViewCImpl(Form thisOptFrm)
        {
            if (thisOptFrm != null)
            {
                this.m_frmMainResultPageViewCallBack = (IFrmMainResultPageViewCallBack)thisOptFrm;
            }
        }

        public void GetAllResultDataFromController()
        {
            if (m_frmMainResultPageViewCallBack != null)
            {
                m_frmMainResultPageViewCallBack.GetAllResultDataCallBack(m_resultPageDataService.GetAllResultDataFromService());
            }
        }

        public void GetResultDataByOltIpAndMacFromController(ClsOltInfoVo currOltInfoVo, ClsOnuInfoEntryVo currOnuInfoEntryVo)
        {
            if (m_frmMainResultPageViewCallBack != null)
            {
                ClsResultInfoTableBo currResultInfoTableBo = m_resultPageDataService.GetResultDataByOltIpAndMacFromService(currOltInfoVo, currOnuInfoEntryVo);
                m_frmMainResultPageViewCallBack.GetResultDataByOltIpAndMacCallBack(currResultInfoTableBo);
            }
        }

        public void GetResultDataByOltIpFromController(ClsOltInfoVo currOltInfoVo, ClsOnuInfoEntryVo currOnuInfoEntryVo)
        {
            if (m_frmMainResultPageViewCallBack != null)
            {
                ClsResultInfoTableBo currResultInfoTableBo = m_resultPageDataService.GetResultDataListByOltIpFromService(currOltInfoVo, currOnuInfoEntryVo);
                m_frmMainResultPageViewCallBack.GetResultDataListByOltIpCallBack(currResultInfoTableBo);
            }
        }
    }
}
