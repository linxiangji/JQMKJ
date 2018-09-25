using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnuDevInfoOnUserCommon.HelpTools;
using static System.Windows.Forms.ListView;
using OnuDevInfoOnUserModel.EventClass;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    public partial class UctrlBodyLayout : UserControl
    {
        #region 变量
        public ListView lvwDataInfoTable;
        public ListView lvwResultInfoTable;
        public ToolStripTextBox tspTxtSearchCondition;
        public ToolStripButton tspBtnOptSort;
        public ToolStripButton tspBtnOptSearch;
        public TreeView treeViewOptMenu;
        #endregion

        #region 变量
        public UctrlBodyLayout()
        {
            InitializeComponent();
        }

        private void UctrlBodyLayout_Load(object sender, EventArgs e)
        {
            lvwDataInfoTable = this.listViewDataTable;
            lvwResultInfoTable = this.listViewResultTable;
            tspBtnOptSort = this.tspBtnSort;
            tspTxtSearchCondition = this.tspTxtOltIPOrOnuMac;
            tspBtnOptSearch =this.tspBtnSearch;
            treeViewOptMenu = this.treeViewResult;
            ToolTip currToolTip = new ToolTip();
            currToolTip.SetToolTip(this.chkAll,"全选");
        }
        #endregion

        #region 事件方法
        private void tspBtnAdd_Click(object sender, EventArgs e)
        {
            if (ClsFrmMainDataPageEvent.TspBtnAddClickEvent != null)
            {
                ClsFrmMainDataPageEvent.TspBtnAddClickEvent(sender, e);
            }
        }

        private void tspBtnUpdate_Click(object sender, EventArgs e)
        {
            if (ClsFrmMainDataPageEvent.TspBtnUpdateClickEvent != null)
            {
                ClsFrmMainDataPageEvent.TspBtnUpdateClickEvent(sender, e);
            }
        }

        private void tspBtnDelete_Click(object sender, EventArgs e)
        {
            if (ClsFrmMainDataPageEvent.TspBtnDeleteClickEvent != null)
            {
                ClsFrmMainDataPageEvent.TspBtnDeleteClickEvent(sender, e);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ClsFrmMainDataPageEvent.ChkAllClickEvent != null)
            {
                ClsFrmMainDataPageEvent.ChkAllClickEvent(sender, e);
            }
        }
       
        private void treeViewResult_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (ClsFrmMainResultPageEvent.TreeViewMenuNodeMouseClickEvent != null)
            {
                ClsFrmMainResultPageEvent.TreeViewMenuNodeMouseClickEvent(sender,e);
            }
        }

        private void tspBtnSearch_Click(object sender, EventArgs e)
        {
            if (ClsFrmMainResultPageEvent.SearchTreeViewMenuNodeClickEvent != null)
            {
                ClsFrmMainResultPageEvent.SearchTreeViewMenuNodeClickEvent(sender, e);
            }
        }

        private void tspBtnSort_Click(object sender, EventArgs e)
        {
            if (ClsFrmMainResultPageEvent.SortTreeViewMenuNodeClickEvent != null)
            {
                ClsFrmMainResultPageEvent.SortTreeViewMenuNodeClickEvent(sender, e);
            }
        }
        #endregion
    }
}
