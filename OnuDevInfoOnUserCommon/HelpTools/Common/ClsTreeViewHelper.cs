using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    [Serializable]
    public class ClsTreeViewHelper
    {
        //新的搜索文本内容
        private static string m_currLastSearchCondition = "";
        //记录上一次搜索的文本内容
        private static string m_currLastSearchNodeText = "";
        //当前显示的索引
        private static int m_currSearchNodeListIndex = -1;
        //用于文本条件搜索，存放搜索匹配到的treeNode节点
        private static List<TreeNode> m_currSearchNodeList = new List<TreeNode>();

        /// <summary>
        /// 清空之前查找的记录清空
        /// </summary>
        public static void ClearLastSearchDataMethod()
        {
            m_currLastSearchCondition = "";
            m_currLastSearchNodeText = "";
            m_currSearchNodeListIndex = -1;
            m_currSearchNodeList.Clear();
        }
        /// <summary>
        ///TreeView遍历节点显示： 数据从Dictionary<string, List<ClsOnuInfoEntryVo>> 中获取
        /// <param name="currOptDataDictionary"></param>
        /// <param name="currTreeView"></param>
        public static TreeNode DictionaryDataCreateRootNode(Dictionary<string, List<ClsResultInfoTableBo>> currOptDataDictionary)
        {
            TreeNode rootTreeNode = new TreeNode("结果信息树");
            rootTreeNode.ImageIndex = 0;
            rootTreeNode.SelectedImageIndex = 3;
            foreach (KeyValuePair<string, List<ClsResultInfoTableBo>> currOptTreeObj in currOptDataDictionary)
            {
                TreeNode firstTreeNode = new TreeNode(currOptTreeObj.Key);
                firstTreeNode.ImageIndex = 1;
                firstTreeNode.SelectedImageIndex = 3;
                List<ClsResultInfoTableBo> currValueDataList = currOptTreeObj.Value;
                if (currValueDataList != null && currValueDataList.Count > 0)
                {
                    foreach (ClsResultInfoTableBo optResultInfoTableBo in currValueDataList)
                    {
                        TreeNode twoTreeNode = new TreeNode(optResultInfoTableBo.onuInfoEntryVo.onuMacAddress);
                        twoTreeNode.ImageIndex = 2;
                        twoTreeNode.SelectedImageIndex = 3;
                        firstTreeNode.Nodes.Add(twoTreeNode);
                    }
                }
                rootTreeNode.Nodes.Add(firstTreeNode);
            }
            return rootTreeNode;
        }
        /// <summary>
        /// 递归搜索树节点，查找符合文本的节点
        /// </summary>
        /// <param name="currOptTreeView"></param>
        /// <param name="searchText"></param>
        public static void SearchTreeViewNodesByTxtValue(TreeView currOptTreeView,string searchText)
        {
            if (searchText.Equals(m_currLastSearchCondition)==false)
            {
                m_currSearchNodeList.Clear();
                m_currLastSearchCondition = searchText;
                m_currSearchNodeListIndex = -1;
                RecursionFindNodeMethod(currOptTreeView.Nodes[0], searchText);
            }
            int currSearchNodeListCount = m_currSearchNodeList.Count;
            for (int i= 0; i < currSearchNodeListCount; i++)
            {
                if (i<=m_currSearchNodeListIndex)
                {
                    continue;
                }
                if (m_currSearchNodeList[i] != null)
                {
                    if (m_currSearchNodeList[i].Nodes.Count == 0)
                    {
                        m_currSearchNodeList[i].Parent.Expand();
                    }
                    else
                    {
                        m_currSearchNodeList[i].Expand();
                    }
                    currOptTreeView.SelectedNode = m_currSearchNodeList[i];
                    m_currLastSearchNodeText = m_currSearchNodeList[i].Text;
                    m_currSearchNodeListIndex = i;
                    break;
                }
            }
            if ((m_currSearchNodeListIndex+1)== currSearchNodeListCount)
            {
                m_currSearchNodeListIndex = -1;
            }
            //没有任何匹配则提示
            if (currSearchNodeListCount == 0)
            {
                ClsMessageBoxHelper.ShowInfoMsg("查找结束，当前没有任何匹配项。");
            }
        }
        /// <summary>
        /// 递归算法：从树节点中查找一个符合的值
        /// </summary>
        /// <param name="rootTreeNodeParent"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private static void RecursionFindNodeMethod(TreeNode rootTreeNodeParent, string strValue)
        {
            if (rootTreeNodeParent == null) return;
            if (rootTreeNodeParent.Text.Contains(strValue))
            {
                //匹配的所有节点添加到搜索集合中
                m_currSearchNodeList.Add(rootTreeNodeParent);
            } 
            foreach (TreeNode currChilderNode in rootTreeNodeParent.Nodes)
            {
                RecursionFindNodeMethod(currChilderNode, strValue);
            }
        }
        /// <summary>
        /// 根据OLT - ip地址正序排序 treeView控件中的所有节点
        /// </summary>
        /// <param name="currOptTreeView"></param>
        public static void AscSortTreeViewNodesMethod(TreeView currOptTreeView)
        {
            List<TreeNode> currAllIpAddressNodesList = new List<TreeNode>();
            GetAllTreeViewNodesMethod(currOptTreeView.Nodes[0], currAllIpAddressNodesList);
            if (currAllIpAddressNodesList.Count>0)
            {
                currAllIpAddressNodesList.Sort((a, b) => a.Text.CompareTo(b.Text));
                currOptTreeView.Nodes.Clear();
                TreeNode rootNode = new TreeNode("结果信息树");
                foreach (TreeNode currOptTreeNode in currAllIpAddressNodesList)
                {
                    if (currOptTreeView != null)
                    {
                        rootNode.Nodes.Add(currOptTreeNode);
                    }
                }
                currOptTreeView.Nodes.Add(rootNode);
                currOptTreeView.ExpandAll();
            }
        }
        /// <summary>
        /// 根据OLT - ip地址倒序排序 treeView控件中的所有节点
        /// </summary>
        /// <param name="currOptTreeView"></param>
        public static void DescSortTreeViewNodesMethod(TreeView currOptTreeView)
        {
            List<TreeNode> currAllIpAddressNodesList = new List<TreeNode>();
            GetAllTreeViewNodesMethod(currOptTreeView.Nodes[0], currAllIpAddressNodesList);
            if (currAllIpAddressNodesList.Count > 0)
            {
                currAllIpAddressNodesList.Reverse();
                currOptTreeView.Nodes.Clear();
                TreeNode rootNode = new TreeNode("结果信息树");
                foreach (TreeNode currOptTreeNode in currAllIpAddressNodesList)
                {
                    if (currOptTreeView != null)
                    {
                        rootNode.Nodes.Add(currOptTreeNode);
                    }
                }
                currOptTreeView.Nodes.Add(rootNode);
                currOptTreeView.ExpandAll();
            }
        }
        /// <summary>
        /// 递归添加层级为1，即 OLT 设备 Ip地址节点到集合中，用于排序等其他操作
        /// </summary>
        /// <param name="rootTreeNodeParent"></param>
        /// <param name="AllTreeNodesList"></param>
        public static void GetAllTreeViewNodesMethod(TreeNode rootTreeNodeParent,List<TreeNode> AllTreeNodesList)
        {
            if (rootTreeNodeParent == null) return;
            {
                if (rootTreeNodeParent.Level==1)
                {
                    //所有节点添加到集合中
                    AllTreeNodesList.Add(rootTreeNodeParent);
                }
            }
            foreach (TreeNode currChilderNode in rootTreeNodeParent.Nodes)
            {
                GetAllTreeViewNodesMethod(currChilderNode,AllTreeNodesList);
            }
        }
    }
}
