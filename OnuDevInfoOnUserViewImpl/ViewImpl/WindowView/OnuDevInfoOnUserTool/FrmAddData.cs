using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserControllerImpl.ControllerImpl;
using OnuDevInfoOnUserControllerInterface.ControllerInterfaces;
using OnuDevInfoOnUserModel.EventClass;
using OnuDevInfoOnUserModel.VoClass;
using OnuDevInfoOnUserViewInterface.ViewInterfaces;
using System;
using System.Threading;
using System.Windows.Forms;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    public partial class FrmAddData : Form, IFrmAddDataViewCallBack
    {
        #region 变量
        private log4net.ILog m_log = log4net.LogManager.GetLogger("FrmMain");
        private IFrmAddDataView m_frmAddDataView = null;
        private ListView m_currOptListView = null;
        #endregion

        #region 构造方法与加载方法
        public FrmAddData(ListView currOptListView)
        {
            InitializeComponent();
            this.m_frmAddDataView = new ClsFrmAddDataViewCImpl(this);
            this.m_currOptListView = currOptListView;
        }

        private void FrmAddData_Load(object sender, EventArgs e)
        {
            ClsFrmAddDataEvent.BtnAddDataClickEvent = BtnAddDataClickEventImpl;
            ClsFrmAddDataEvent.BtnCancelDataClickEvent = BtnCancelDataClickEventImpl;
        }
        #endregion

        #region 各种事件的具体逻辑方法
        /// <summary>
        /// 增加记录窗体中的增加按钮的点击逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddDataClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                string currOltIpAddress = this.uctrlAddDataLayout1.CurrUctrlOltIpAddress.Text.Trim();
                string currOnuMacAddress = this.uctrlAddDataLayout1.CurrTxtMacAddress.Text.Trim();
                string currCboxReadCommunity = this.uctrlAddDataLayout1.CurrCboxReadCommunity.Text.Trim();
                string currCboxWriteCommunity = this.uctrlAddDataLayout1.CurrCboxWriteCommunity.Text.Trim();
                if (string.IsNullOrEmpty(currOltIpAddress) || string.IsNullOrEmpty(currOnuMacAddress))
                {
                    ClsMessageBoxHelper.ShowInfoMsg("OLT-Ip地址或者Mac地址为空，请重新输入。");
                    return;
                }
                if (ClsRegexHelper.IsIpAddress(currOltIpAddress) == false)
                {
                    ClsMessageBoxHelper.ShowInfoMsg("OLT-IP地址格式不对，请重新输入。");
                    return;
                }
                if (ClsRegexHelper.IsMacAddress(currOnuMacAddress) == false)
                {
                    ClsMessageBoxHelper.ShowInfoMsg("ONU-Mac地址格式不对，请重新输入。");
                    return;
                }
                if (string.IsNullOrEmpty(currCboxReadCommunity))
                {
                    ClsMessageBoxHelper.ShowInfoMsg("OLT-读共同体不能为空。");
                    return;
                }
                if (ClsRegexHelper.IsCommunity(currCboxReadCommunity) == false)
                {
                    ClsMessageBoxHelper.ShowInfoMsg("OLT-读共同体格式错误，请重新选择。");
                    return;
                }
                if (string.IsNullOrEmpty(currCboxWriteCommunity))
                {
                    ClsMessageBoxHelper.ShowInfoMsg("OLT-写共同体不能为空。");
                    return;
                }
                if (ClsRegexHelper.IsCommunity(currCboxWriteCommunity) == false)
                {
                    ClsMessageBoxHelper.ShowInfoMsg("OLT-写共同体格式错误，请重新选择。");
                    return;
                }
                DialogResult dialogResult = ClsMessageBoxHelper.ShowOKCancelMsg("确定添加此记录？");
                if (dialogResult == DialogResult.OK)
                {
                    ClsOltInfoVo oltInfoVo = new ClsOltInfoVo();
                    oltInfoVo.ipAddress = currOltIpAddress;
                    oltInfoVo.readCommunity = currCboxReadCommunity;
                    oltInfoVo.writeCommunity = currCboxWriteCommunity;
                    ClsOnuInfoEntryVo onuInfoEntryVo = new ClsOnuInfoEntryVo();
                    onuInfoEntryVo.onuMacAddress = currOnuMacAddress;
                    m_frmAddDataView.BtnAddDataClick(oltInfoVo, onuInfoEntryVo);
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 增加记录窗体中的取消按钮的点击逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelDataClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                m_frmAddDataView.BtnCancelClick();
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 控制层方法回调逻辑：增加一条记录到数据信息表中的逻辑
        /// </summary>
        /// <param name="oltInfoVo"></param>
        /// <param name="onuInfoEntryVo"></param>
        public void BtnAddDataClickCallBack(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            try
            {
                if (oltInfoVo != null && onuInfoEntryVo != null && m_currOptListView != null)
                {
                    if (ClsListViewHelper.ListViewDataAddOneItems(this.m_currOptListView, oltInfoVo, onuInfoEntryVo) == true)
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("增加记录成功。");
                        this.Close();
                    }
                    else
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("增加记录失败。");
                    }
                }
                else
                {
                    ClsMessageBoxHelper.ShowInfoMsg("增加记录失败。");
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 控制层方法回调逻辑：关闭当前窗体
        /// </summary>
        public void BtnCancelClickCallBack()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        #endregion
    }
}
