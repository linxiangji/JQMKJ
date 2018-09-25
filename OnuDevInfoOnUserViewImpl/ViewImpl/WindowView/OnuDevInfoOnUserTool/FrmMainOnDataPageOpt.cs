using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserControllerImpl.ControllerImpl;
using OnuDevInfoOnUserControllerInterface.ControllerInterfaces;
using OnuDevInfoOnUserModel.EventClass;
using OnuDevInfoOnUserModel.VoClass;
using OnuDevInfoOnUserViewImpl.ViewInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    public partial class FrmOnuDevInfoOnUserToolMain: IFrmMainDataPageViewCallBack
    {
        /// <summary>
        /// 数据信息页面菜单：各种操作事件绑定具体方法的逻辑代码
        /// </summary>
        public void FrmMainDataPageEventLoad()
        {
            ClsFrmMainDataPageEvent.TspBtnAddClickEvent = TspBtnAddClickEventImpl;
            ClsFrmMainDataPageEvent.TspBtnUpdateClickEvent = TspBtnUpdateClickEventImpl;
            ClsFrmMainDataPageEvent.TspBtnDeleteClickEvent = TspBtnDeleteClickEventImpl;
            ClsFrmMainDataPageEvent.ChkAllClickEvent = ChkAllClickEventImpl;
        }

        #region 事件方法的实现
        /// <summary>
        /// 全选与反选的主逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkAllClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                ClsListViewHelper.ListViewCheckAll(this.uctrlBodyLayout1.lvwDataInfoTable);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 打开增加记录窗体主逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TspBtnAddClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                BtnAddClickOpenFrmAddDataMethod();
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 控制层方法回调逻辑：显示增加记录窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowFrmAddDataCallBack()
        {
            FrmAddData frmAddData = new FrmAddData(this.uctrlBodyLayout1.lvwDataInfoTable);
            frmAddData.StartPosition = FormStartPosition.CenterParent;
            frmAddData.ShowDialog();
            frmAddData.Dispose();
        }
        /// <summary>
        /// 打开编辑记录窗体主逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TspBtnUpdateClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                BtnUpdateClickOpenFrmUpdateDataMethod(this.uctrlBodyLayout1.lvwDataInfoTable);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 控制层方法回调逻辑：显示编辑记录窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowFrmUpdateDataCallBack(ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            FrmUpdateData frmUpdateData = new FrmUpdateData(this.uctrlBodyLayout1.lvwDataInfoTable, oltInfoVo, onuInfoEntryVo);
            frmUpdateData.StartPosition = FormStartPosition.CenterParent;
            frmUpdateData.ShowDialog();
            frmUpdateData.Dispose();
        }
        /// <summary>
        /// 数据信息表中选中数据删除的主逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TspBtnDeleteClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                BtnDeleteCheckedDataClickMethod(this.uctrlBodyLayout1.lvwDataInfoTable);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }

        #endregion

        #region 封装的统一帮助方法
        /// <summary>
        /// 打开增加记录窗体的统一方法
        /// </summary>
        /// <param name="currOptListView"></param>
        public  void BtnAddClickOpenFrmAddDataMethod()
        {
            if (m_frmMainDataPageView != null)
            {
                m_frmMainDataPageView.ShowFrmAddData();
            }
        }
        /// <summary>
        /// 打开编辑记录窗体的统一方法
        /// </summary>
        /// <param name="currOptListView"></param>
        public void BtnUpdateClickOpenFrmUpdateDataMethod(ListView currOptListView)
        {
            if (ClsListViewHelper.IsListViewDataCheckedItemsEqOne(currOptListView))
            {
                ClsOltInfoVo oltInfoVo = new ClsOltInfoVo();
                ClsOnuInfoEntryVo onuInfoEntryVo = new ClsOnuInfoEntryVo();
                if (ClsListViewHelper.ListViewDataGetOneItems(currOptListView, oltInfoVo, onuInfoEntryVo) == true)
                {
                    if (m_frmMainDataPageView != null)
                    {
                        m_frmMainDataPageView.ShowFrmUpdateData(oltInfoVo, onuInfoEntryVo);
                    }
                }
                else
                {
                    ClsMessageBoxHelper.ShowInfoMsg("请在数据信息页选择所要编辑的记录。");
                }
            }
            else
            {
                ClsMessageBoxHelper.ShowWaringMsg("请在数据信息页选择一条记录编辑。");
            }
        }
        /// <summary>
        /// 打开选中删除的统一方法
        /// </summary>
        /// <param name="currOptListView"></param>
        public void BtnDeleteCheckedDataClickMethod(ListView currOptListView)
        {
            if (ClsListViewHelper.IsListViewDataCheckedItemsGtZero(currOptListView) == true)
            {
                DialogResult dialogResult = ClsMessageBoxHelper.ShowOKCancelMsg("确定删除所选择的记录？");
                if (dialogResult == DialogResult.OK)
                {
                    if (ClsListViewHelper.ListViewDelCheckedItems(currOptListView) == true)
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("删除成功。");
                    }
                }
            }
            else
            {
                ClsMessageBoxHelper.ShowWaringMsg("请先在数据信息页选择所要删除的记录。");
            }
        }
        #endregion
    }
}
