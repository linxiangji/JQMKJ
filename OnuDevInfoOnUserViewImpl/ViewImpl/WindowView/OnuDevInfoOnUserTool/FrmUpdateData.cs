using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserControllerImpl.ControllerImpl;
using OnuDevInfoOnUserControllerInterface.ControllerInterfaces;
using OnuDevInfoOnUserModel.EventClass;
using OnuDevInfoOnUserModel.VoClass;
using OnuDevInfoOnUserViewInterface.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    public partial class FrmUpdateData : Form, IFrmUpdateDataViewCallBack
    {
        #region 变量
        private log4net.ILog m_log = log4net.LogManager.GetLogger("FrmMain");
        private IFrmUpdateDataView m_frmUpdateDataView = null;
        private ClsOltInfoVo m_oltInfoVo = null;
        private ClsOnuInfoEntryVo m_onuInfoEntryVo = null;
        private ListView m_currOptListView = null;
        #endregion

        #region 构造方法与加载方法
        public FrmUpdateData(ListView currOptListView,ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            InitializeComponent();
            this.m_frmUpdateDataView = new ClsFrmUpdateDataViewCImpl(this);
            this.m_currOptListView = currOptListView;
            this.m_oltInfoVo = oltInfoVo;
            this.m_onuInfoEntryVo = onuInfoEntryVo;
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            ClsFrmUpdateDataEvent.BtnSaveDataClickEvent = BtnSaveDataClickEventImpl;
            ClsFrmUpdateDataEvent.BtnCancelDataClickEvent = BtnCancelDataClickEventImpl;
            this.uctrlUpdateDataLayoutcs1.CurrUctrlOltIpAddress.Text = m_oltInfoVo.ipAddress;
            this.uctrlUpdateDataLayoutcs1.CurrTxtMacAddress.Text = m_onuInfoEntryVo.onuMacAddress;
            this.uctrlUpdateDataLayoutcs1.CurrCboxReadCommunity.Text = m_oltInfoVo.readCommunity;
            this.uctrlUpdateDataLayoutcs1.CurrCboxWriteCommunity.Text = m_oltInfoVo.writeCommunity;
        }
        #endregion

        #region 各种事件方法的具体逻辑代码
        /// <summary>
        ///  编辑窗体中的保存按钮的点击逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveDataClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                string currOltIpAddress = this.uctrlUpdateDataLayoutcs1.CurrUctrlOltIpAddress.Text.Trim();
                string currOnuMacAddress = this.uctrlUpdateDataLayoutcs1.CurrTxtMacAddress.Text.Trim();
                string currCboxReadCommunity = this.uctrlUpdateDataLayoutcs1.CurrCboxReadCommunity.Text.Trim();
                string currCboxWriteCommunity = this.uctrlUpdateDataLayoutcs1.CurrCboxWriteCommunity.Text.Trim();
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
                DialogResult dialogResult = ClsMessageBoxHelper.ShowOKCancelMsg("确定保存修改的记录？");
                if (dialogResult == DialogResult.OK)
                {
                    ClsOltInfoVo oltInfoVo = new ClsOltInfoVo();
                    oltInfoVo.ipAddress = currOltIpAddress;
                    oltInfoVo.readCommunity = currCboxReadCommunity;
                    oltInfoVo.writeCommunity = currCboxWriteCommunity;
                    ClsOnuInfoEntryVo onuInfoEntryVo = new ClsOnuInfoEntryVo();
                    onuInfoEntryVo.onuMacAddress = currOnuMacAddress;
                    m_frmUpdateDataView.BtnSaveDataClick(oltInfoVo, onuInfoEntryVo);
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 编辑窗体中的取消按钮的点击逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelDataClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                m_frmUpdateDataView.BtnCancelClick();
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        ///  控制层方法回调逻辑：修改数据信息表中的数据逻辑
        /// </summary>
        /// <param name="oltInfoVo"></param>
        /// <param name="onuInfoEntryVo"></param>
        public void BtnSaveDataClickCallBack(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            try
            {
                if (oltInfoVo != null && onuInfoEntryVo != null)
                {
                    if (ClsListViewHelper.ListViewDataUpdateOneItems(this.m_currOptListView, oltInfoVo, onuInfoEntryVo) == true)
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("修改记录成功。");
                        this.Close();
                    }
                    else
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("修改记录失败。");
                    }
                }
                else
                {
                    ClsMessageBoxHelper.ShowInfoMsg("修改记录失败。");
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        ///  控制层方法回调逻辑：关闭当前窗体
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
