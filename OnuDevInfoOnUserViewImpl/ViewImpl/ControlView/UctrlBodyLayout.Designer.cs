namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    partial class UctrlBodyLayout
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctrlBodyLayout));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.listViewDataTable = new System.Windows.Forms.ListView();
            this.colHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderIpAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderMacAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderReadCommunity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderWriteCommunity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tspOptDataMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tspBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tspBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tspBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tspResultMenu = new System.Windows.Forms.ToolStrip();
            this.tspBtnSort = new System.Windows.Forms.ToolStripButton();
            this.tspTxtOltIPOrOnuMac = new System.Windows.Forms.ToolStripTextBox();
            this.tspBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.treeViewResult = new System.Windows.Forms.TreeView();
            this.imageListTreeViewMenu = new System.Windows.Forms.ImageList(this.components);
            this.listViewResultTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tspOptDataMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tspResultMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1102, 590);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkAll);
            this.tabPage1.Controls.Add(this.listViewDataTable);
            this.tabPage1.Controls.Add(this.tspOptDataMenu);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1094, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAll.Location = new System.Drawing.Point(17, 8);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 1;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // listViewDataTable
            // 
            this.listViewDataTable.CheckBoxes = true;
            this.listViewDataTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderId,
            this.colHeaderIpAddress,
            this.colHeaderMacAddress,
            this.colHeaderReadCommunity,
            this.colHeaderWriteCommunity});
            this.listViewDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDataTable.FullRowSelect = true;
            this.listViewDataTable.GridLines = true;
            this.listViewDataTable.Location = new System.Drawing.Point(3, 28);
            this.listViewDataTable.Name = "listViewDataTable";
            this.listViewDataTable.Size = new System.Drawing.Size(1088, 533);
            this.listViewDataTable.TabIndex = 1;
            this.listViewDataTable.UseCompatibleStateImageBehavior = false;
            this.listViewDataTable.View = System.Windows.Forms.View.Details;
            // 
            // colHeaderId
            // 
            this.colHeaderId.Text = "选择";
            this.colHeaderId.Width = 48;
            // 
            // colHeaderIpAddress
            // 
            this.colHeaderIpAddress.Text = "OLT-Ip地址";
            this.colHeaderIpAddress.Width = 188;
            // 
            // colHeaderMacAddress
            // 
            this.colHeaderMacAddress.Text = "ONU-Mac地址";
            this.colHeaderMacAddress.Width = 200;
            // 
            // colHeaderReadCommunity
            // 
            this.colHeaderReadCommunity.Text = "读共同体";
            this.colHeaderReadCommunity.Width = 159;
            // 
            // colHeaderWriteCommunity
            // 
            this.colHeaderWriteCommunity.Text = "写共同体";
            this.colHeaderWriteCommunity.Width = 206;
            // 
            // tspOptDataMenu
            // 
            this.tspOptDataMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspOptDataMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripLabel3,
            this.tspBtnAdd,
            this.toolStripLabel1,
            this.tspBtnUpdate,
            this.toolStripLabel2,
            this.tspBtnDelete});
            this.tspOptDataMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tspOptDataMenu.Location = new System.Drawing.Point(3, 3);
            this.tspOptDataMenu.Name = "tspOptDataMenu";
            this.tspOptDataMenu.Size = new System.Drawing.Size(1088, 25);
            this.tspOptDataMenu.TabIndex = 0;
            this.tspOptDataMenu.Text = "toolStrip2";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel4.Text = "     ";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel3.Text = "   ";
            // 
            // tspBtnAdd
            // 
            this.tspBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspBtnAdd.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_add;
            this.tspBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnAdd.Name = "tspBtnAdd";
            this.tspBtnAdd.Size = new System.Drawing.Size(23, 22);
            this.tspBtnAdd.Text = "增加记录";
            this.tspBtnAdd.Click += new System.EventHandler(this.tspBtnAdd_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel1.Text = "   ";
            // 
            // tspBtnUpdate
            // 
            this.tspBtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspBtnUpdate.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_update;
            this.tspBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnUpdate.Name = "tspBtnUpdate";
            this.tspBtnUpdate.Size = new System.Drawing.Size(23, 22);
            this.tspBtnUpdate.Text = "编辑记录";
            this.tspBtnUpdate.Click += new System.EventHandler(this.tspBtnUpdate_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel2.Text = "   ";
            // 
            // tspBtnDelete
            // 
            this.tspBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspBtnDelete.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_delete;
            this.tspBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnDelete.Name = "tspBtnDelete";
            this.tspBtnDelete.Size = new System.Drawing.Size(23, 22);
            this.tspBtnDelete.Text = "删除选中记录";
            this.tspBtnDelete.Click += new System.EventHandler(this.tspBtnDelete_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1094, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "结果信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewResultTable);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 558);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tspResultMenu);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeViewResult);
            this.splitContainer2.Size = new System.Drawing.Size(260, 558);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.TabIndex = 1;
            // 
            // tspResultMenu
            // 
            this.tspResultMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspResultMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspBtnSort,
            this.tspTxtOltIPOrOnuMac,
            this.tspBtnSearch});
            this.tspResultMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tspResultMenu.Location = new System.Drawing.Point(0, 0);
            this.tspResultMenu.Name = "tspResultMenu";
            this.tspResultMenu.Size = new System.Drawing.Size(260, 25);
            this.tspResultMenu.TabIndex = 3;
            this.tspResultMenu.Text = "toolStrip1";
            // 
            // tspBtnSort
            // 
            this.tspBtnSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspBtnSort.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.sort_ascending;
            this.tspBtnSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnSort.Name = "tspBtnSort";
            this.tspBtnSort.Size = new System.Drawing.Size(23, 22);
            this.tspBtnSort.Tag = "asc";
            this.tspBtnSort.Text = "Ip正序排序";
            this.tspBtnSort.Click += new System.EventHandler(this.tspBtnSort_Click);
            // 
            // tspTxtOltIPOrOnuMac
            // 
            this.tspTxtOltIPOrOnuMac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tspTxtOltIPOrOnuMac.Name = "tspTxtOltIPOrOnuMac";
            this.tspTxtOltIPOrOnuMac.Size = new System.Drawing.Size(192, 25);
            // 
            // tspBtnSearch
            // 
            this.tspBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspBtnSearch.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_search;
            this.tspBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnSearch.Name = "tspBtnSearch";
            this.tspBtnSearch.Size = new System.Drawing.Size(23, 22);
            this.tspBtnSearch.Text = "查找";
            this.tspBtnSearch.Click += new System.EventHandler(this.tspBtnSearch_Click);
            // 
            // treeViewResult
            // 
            this.treeViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResult.ImageIndex = 0;
            this.treeViewResult.ImageList = this.imageListTreeViewMenu;
            this.treeViewResult.Location = new System.Drawing.Point(0, 0);
            this.treeViewResult.Name = "treeViewResult";
            this.treeViewResult.SelectedImageIndex = 0;
            this.treeViewResult.Size = new System.Drawing.Size(260, 524);
            this.treeViewResult.TabIndex = 0;
            this.treeViewResult.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewResult_NodeMouseClick);
            // 
            // imageListTreeViewMenu
            // 
            this.imageListTreeViewMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeViewMenu.ImageStream")));
            this.imageListTreeViewMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeViewMenu.Images.SetKeyName(0, "home_green.png");
            this.imageListTreeViewMenu.Images.SetKeyName(1, "olt.png");
            this.imageListTreeViewMenu.Images.SetKeyName(2, "arrow_status.png");
            this.imageListTreeViewMenu.Images.SetKeyName(3, "arrow_right.png");
            this.imageListTreeViewMenu.Images.SetKeyName(4, "box.png");
            // 
            // listViewResultTable
            // 
            this.listViewResultTable.CheckBoxes = true;
            this.listViewResultTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listViewResultTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResultTable.FullRowSelect = true;
            this.listViewResultTable.GridLines = true;
            this.listViewResultTable.Location = new System.Drawing.Point(0, 0);
            this.listViewResultTable.Name = "listViewResultTable";
            this.listViewResultTable.Size = new System.Drawing.Size(824, 558);
            this.listViewResultTable.TabIndex = 3;
            this.listViewResultTable.UseCompatibleStateImageBehavior = false;
            this.listViewResultTable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "选择";
            this.columnHeader1.Width = 48;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "OLT-Ip地址";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ONU-Mac地址";
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ONU设备索引";
            this.columnHeader4.Width = 126;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "用户设备编号";
            this.columnHeader5.Width = 95;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "用户设备MAC地址";
            this.columnHeader6.Width = 130;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "用户设备Vid";
            this.columnHeader7.Width = 78;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "用户设备Status";
            this.columnHeader8.Width = 86;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "用户设备Multicast";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "执行状态";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "执行描述";
            this.columnHeader11.Width = 200;
            // 
            // UctrlBodyLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl1);
            this.Name = "UctrlBodyLayout";
            this.Size = new System.Drawing.Size(1102, 590);
            this.Load += new System.EventHandler(this.UctrlBodyLayout_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tspOptDataMenu.ResumeLayout(false);
            this.tspOptDataMenu.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tspResultMenu.ResumeLayout(false);
            this.tspResultMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewResultTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView listViewDataTable;
        private System.Windows.Forms.ColumnHeader colHeaderId;
        private System.Windows.Forms.ColumnHeader colHeaderIpAddress;
        private System.Windows.Forms.ToolStrip tspOptDataMenu;
        private System.Windows.Forms.ToolStripButton tspBtnAdd;
        private System.Windows.Forms.ToolStripButton tspBtnUpdate;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tspBtnDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip tspResultMenu;
        private System.Windows.Forms.ToolStripButton tspBtnSort;
        private System.Windows.Forms.ToolStripTextBox tspTxtOltIPOrOnuMac;
        private System.Windows.Forms.ToolStripButton tspBtnSearch;
        private System.Windows.Forms.TreeView treeViewResult;
        private System.Windows.Forms.ImageList imageListTreeViewMenu;
        private System.Windows.Forms.ColumnHeader colHeaderMacAddress;
        private System.Windows.Forms.ColumnHeader colHeaderReadCommunity;
        private System.Windows.Forms.ColumnHeader colHeaderWriteCommunity;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}
