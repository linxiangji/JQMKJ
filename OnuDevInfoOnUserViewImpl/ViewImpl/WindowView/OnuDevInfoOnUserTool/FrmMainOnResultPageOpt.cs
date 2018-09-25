using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserControllerInterface.ControllerInterfaces;
using OnuDevInfoOnUserModel.EventClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.VoClass;
using System.Collections.Concurrent;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    public partial class FrmOnuDevInfoOnUserToolMain: IFrmMainResultPageViewCallBack
    {
        /// <summary>
        /// 结果信息页面事件初始化方法
        /// </summary>
        public void FrmMainResultPageEventLoad()
        {
            ClsFrmMainResultPageEvent.TreeViewMenuNodeMouseClickEvent = TreeViewMenuNodeMouseClickEventImpl;
            ClsFrmMainResultPageEvent.SearchTreeViewMenuNodeClickEvent = SearchTreeViewMenuNodeClickEventImpl;
            ClsFrmMainResultPageEvent.SortTreeViewMenuNodeClickEvent = SortTreeViewMenuNodeClickEventImpl;
        }

        #region 事件方法的实现
        /// <summary>
        /// 排序方法实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortTreeViewMenuNodeClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                if (this.uctrlBodyLayout1.treeViewOptMenu.Nodes.Count > 0)
                {
                    ToolStripButton tspbtnSort = sender as ToolStripButton;
                    if ("asc".Equals(tspbtnSort.Tag))
                    {
                        ClsTreeViewHelper.AscSortTreeViewNodesMethod(this.uctrlBodyLayout1.treeViewOptMenu);
                        tspbtnSort.Tag = "desc";
                        tspbtnSort.Text = "Ip倒序排序";
                        tspbtnSort.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.sort_descending;
                        return;
                    }
                    if ("desc".Equals(tspbtnSort.Tag))
                    {
                        ClsTreeViewHelper.DescSortTreeViewNodesMethod(this.uctrlBodyLayout1.treeViewOptMenu);
                        tspbtnSort.Tag = "asc";
                        tspbtnSort.Text = "Ip正序排序";
                        tspbtnSort.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.sort_ascending;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 左边菜单树搜索符合条件的节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTreeViewMenuNodeClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                string currSearchText = this.uctrlBodyLayout1.tspTxtSearchCondition.Text.Trim();
                if (string.IsNullOrEmpty(currSearchText))
                {
                    ClsMessageBoxHelper.ShowInfoMsg("请输入需要查找的条件。");
                    return;
                }
                ClsTreeViewHelper.SearchTreeViewNodesByTxtValue(this.uctrlBodyLayout1.treeViewOptMenu, currSearchText);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 左边菜单树的节点点击事件逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewMenuNodeMouseClickEventImpl(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string currNodeText = e.Node.Text.Trim();
                if (e.Node.Level == 2)
                {
                    ClsOltInfoVo currOltInfoVo = new ClsOltInfoVo();
                    currOltInfoVo.ipAddress = e.Node.Parent.Text.Trim();
                    ClsOnuInfoEntryVo currOnuInfoEntryVo = new ClsOnuInfoEntryVo();
                    currOnuInfoEntryVo.onuMacAddress = currNodeText;
                    m_frmMainResultPageVIew.GetResultDataByOltIpAndMacFromController(currOltInfoVo, currOnuInfoEntryVo);
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        #endregion

        #region 控制层的回调方法
        /// <summary>
        /// 得到用户的最终所有结果信息
        /// </summary>
        /// <param name="resultInfoDictionary"></param>
        public void GetAllResultDataCallBack(ConcurrentDictionary<string, ClsResultInfoTableBo> resultInfoDictionary)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        public void GetResultDataByOltIpAndMacCallBack(ClsResultInfoTableBo currResultInfoTableBo)
        {
            try
            {
                if (currResultInfoTableBo != null)
                {
                    ClsListViewHelper.ListData2ListView(currResultInfoTableBo, this.uctrlBodyLayout1.lvwResultInfoTable);
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }

        public void GetResultDataListByOltIpCallBack(ClsResultInfoTableBo currResultInfoTableBo)
        {
            try
            {
                if (currResultInfoTableBo != null)
                {
                    ClsListViewHelper.ListData2ListView(currResultInfoTableBo, this.uctrlBodyLayout1.lvwResultInfoTable);
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        #endregion

        #region 当前类的帮助方法
        
        #endregion
    }
}
