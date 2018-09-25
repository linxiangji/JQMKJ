namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    partial class UctrlHeaderLayout
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
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemExportTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemImportTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemFormatChecks = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemAddRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemDelRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemUpdateRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tspItemBeginSerachUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItemExportResult = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSubMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tspcbxAppSleepTime = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tspboxSNMPTimoutTime = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.tspcboxWordThreadValue = new System.Windows.Forms.ToolStripComboBox();
            this.progressBarSnmpOpt = new System.Windows.Forms.ProgressBar();
            this.lblSnmpOptPercentage = new System.Windows.Forms.Label();
            this.btnBeginFind = new System.Windows.Forms.Button();
            this.menuStripTop.SuspendLayout();
            this.toolStripSubMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.BackColor = System.Drawing.SystemColors.Control;
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(1000, 25);
            this.menuStripTop.TabIndex = 0;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMItemExportTemplate,
            this.TSMItemImportTemplate});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.文件ToolStripMenuItem.Text = "数据操作";
            // 
            // TSMItemExportTemplate
            // 
            this.TSMItemExportTemplate.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.template_export;
            this.TSMItemExportTemplate.Name = "TSMItemExportTemplate";
            this.TSMItemExportTemplate.Size = new System.Drawing.Size(177, 22);
            this.TSMItemExportTemplate.Text = "导出模板（Excel）";
            this.TSMItemExportTemplate.Click += new System.EventHandler(this.TSMItemExportTemplate_Click);
            // 
            // TSMItemImportTemplate
            // 
            this.TSMItemImportTemplate.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.template_import;
            this.TSMItemImportTemplate.Name = "TSMItemImportTemplate";
            this.TSMItemImportTemplate.Size = new System.Drawing.Size(177, 22);
            this.TSMItemImportTemplate.Text = "导入数据（Excel）";
            this.TSMItemImportTemplate.Click += new System.EventHandler(this.TSMItemImportTemplate_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMItemFormatChecks,
            this.TSMItemAddRecord,
            this.TSMItemDelRecord,
            this.TSMItemUpdateRecord,
            this.tspItemBeginSerachUserInfo,
            this.TSMItemExportResult});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.编辑ToolStripMenuItem.Text = "编辑操作";
            // 
            // TSMItemFormatChecks
            // 
            this.TSMItemFormatChecks.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_checks;
            this.TSMItemFormatChecks.Name = "TSMItemFormatChecks";
            this.TSMItemFormatChecks.Size = new System.Drawing.Size(177, 22);
            this.TSMItemFormatChecks.Text = "格式校验";
            this.TSMItemFormatChecks.Click += new System.EventHandler(this.TSMItemFormatChecks_Click);
            // 
            // TSMItemAddRecord
            // 
            this.TSMItemAddRecord.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_add;
            this.TSMItemAddRecord.Name = "TSMItemAddRecord";
            this.TSMItemAddRecord.Size = new System.Drawing.Size(177, 22);
            this.TSMItemAddRecord.Text = "增加记录";
            this.TSMItemAddRecord.Click += new System.EventHandler(this.TSMItemAddRecord_Click);
            // 
            // TSMItemDelRecord
            // 
            this.TSMItemDelRecord.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_delete;
            this.TSMItemDelRecord.Name = "TSMItemDelRecord";
            this.TSMItemDelRecord.Size = new System.Drawing.Size(177, 22);
            this.TSMItemDelRecord.Text = "删除记录";
            this.TSMItemDelRecord.Click += new System.EventHandler(this.TSMItemDelRecord_Click);
            // 
            // TSMItemUpdateRecord
            // 
            this.TSMItemUpdateRecord.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_update;
            this.TSMItemUpdateRecord.Name = "TSMItemUpdateRecord";
            this.TSMItemUpdateRecord.Size = new System.Drawing.Size(177, 22);
            this.TSMItemUpdateRecord.Text = "修改记录";
            this.TSMItemUpdateRecord.Click += new System.EventHandler(this.TSMItemUpdateRecord_Click);
            // 
            // tspItemBeginSerachUserInfo
            // 
            this.tspItemBeginSerachUserInfo.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_search;
            this.tspItemBeginSerachUserInfo.Name = "tspItemBeginSerachUserInfo";
            this.tspItemBeginSerachUserInfo.Size = new System.Drawing.Size(177, 22);
            this.tspItemBeginSerachUserInfo.Text = "开始查询";
            this.tspItemBeginSerachUserInfo.Click += new System.EventHandler(this.tspItemBeginSerachUserInfo_Click);
            // 
            // TSMItemExportResult
            // 
            this.TSMItemExportResult.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_save;
            this.TSMItemExportResult.Name = "TSMItemExportResult";
            this.TSMItemExportResult.Size = new System.Drawing.Size(177, 22);
            this.TSMItemExportResult.Text = "结果导出（Excel）";
            this.TSMItemExportResult.Click += new System.EventHandler(this.TSMItemExportResult_Click);
            // 
            // toolStripSubMenu
            // 
            this.toolStripSubMenu.AllowDrop = true;
            this.toolStripSubMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSubMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.tspcbxAppSleepTime,
            this.toolStripLabel5,
            this.toolStripLabel1,
            this.tspboxSNMPTimoutTime,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripLabel6,
            this.tspcboxWordThreadValue});
            this.toolStripSubMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripSubMenu.Location = new System.Drawing.Point(0, 25);
            this.toolStripSubMenu.Name = "toolStripSubMenu";
            this.toolStripSubMenu.Size = new System.Drawing.Size(1000, 25);
            this.toolStripSubMenu.TabIndex = 1;
            this.toolStripSubMenu.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel4.Text = " 缓冲时间";
            // 
            // tspcbxAppSleepTime
            // 
            this.tspcbxAppSleepTime.Items.AddRange(new object[] {
            "10",
            "20",
            "40",
            "60",
            "80",
            "100"});
            this.tspcbxAppSleepTime.Name = "tspcbxAppSleepTime";
            this.tspcbxAppSleepTime.Size = new System.Drawing.Size(75, 25);
            this.tspcbxAppSleepTime.Tag = "appSleepTime";
            this.tspcbxAppSleepTime.Text = "10";
            this.tspcbxAppSleepTime.TextChanged += new System.EventHandler(this.tspcbxAppSleepTime_TextChanged);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel5.Text = "毫秒    ";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel1.Text = "SNMP超时时间";
            // 
            // tspboxSNMPTimoutTime
            // 
            this.tspboxSNMPTimoutTime.Items.AddRange(new object[] {
            "15",
            "30",
            "45",
            "60",
            "75",
            "90",
            "100"});
            this.tspboxSNMPTimoutTime.Name = "tspboxSNMPTimoutTime";
            this.tspboxSNMPTimoutTime.Size = new System.Drawing.Size(75, 25);
            this.tspboxSNMPTimoutTime.Tag = "snmpTimeoutTime";
            this.tspboxSNMPTimoutTime.Text = "15";
            this.tspboxSNMPTimoutTime.TextChanged += new System.EventHandler(this.tspboxSNMPTimoutTime_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel2.Text = "秒";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel3.Text = "   ";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel6.Text = "线程数";
            // 
            // tspcboxWordThreadValue
            // 
            this.tspcboxWordThreadValue.Items.AddRange(new object[] {
            "10",
            "20",
            "40",
            "60",
            "80",
            "100"});
            this.tspcboxWordThreadValue.Name = "tspcboxWordThreadValue";
            this.tspcboxWordThreadValue.Size = new System.Drawing.Size(75, 25);
            this.tspcboxWordThreadValue.Tag = "workThreadNum";
            this.tspcboxWordThreadValue.Text = "10";
            this.tspcboxWordThreadValue.TextChanged += new System.EventHandler(this.tspcboxWordThreadValue_TextChanged);
            // 
            // progressBarSnmpOpt
            // 
            this.progressBarSnmpOpt.Location = new System.Drawing.Point(679, 27);
            this.progressBarSnmpOpt.Name = "progressBarSnmpOpt";
            this.progressBarSnmpOpt.Size = new System.Drawing.Size(209, 23);
            this.progressBarSnmpOpt.TabIndex = 4;
            this.progressBarSnmpOpt.Visible = false;
            // 
            // lblSnmpOptPercentage
            // 
            this.lblSnmpOptPercentage.AutoSize = true;
            this.lblSnmpOptPercentage.Location = new System.Drawing.Point(894, 32);
            this.lblSnmpOptPercentage.Name = "lblSnmpOptPercentage";
            this.lblSnmpOptPercentage.Size = new System.Drawing.Size(29, 12);
            this.lblSnmpOptPercentage.TabIndex = 5;
            this.lblSnmpOptPercentage.Text = "进度";
            this.lblSnmpOptPercentage.Visible = false;
            // 
            // btnBeginFind
            // 
            this.btnBeginFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBeginFind.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.action_play;
            this.btnBeginFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBeginFind.Location = new System.Drawing.Point(590, 26);
            this.btnBeginFind.Name = "btnBeginFind";
            this.btnBeginFind.Size = new System.Drawing.Size(83, 23);
            this.btnBeginFind.TabIndex = 3;
            this.btnBeginFind.Text = "   开始查询";
            this.btnBeginFind.UseVisualStyleBackColor = true;
            this.btnBeginFind.Click += new System.EventHandler(this.btnBeginFind_Click);
            // 
            // UctrlHeaderLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblSnmpOptPercentage);
            this.Controls.Add(this.progressBarSnmpOpt);
            this.Controls.Add(this.btnBeginFind);
            this.Controls.Add(this.toolStripSubMenu);
            this.Controls.Add(this.menuStripTop);
            this.Name = "UctrlHeaderLayout";
            this.Size = new System.Drawing.Size(1000, 60);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.toolStripSubMenu.ResumeLayout(false);
            this.toolStripSubMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMItemExportTemplate;
        private System.Windows.Forms.ToolStripMenuItem TSMItemImportTemplate;
        private System.Windows.Forms.ToolStrip toolStripSubMenu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripMenuItem TSMItemAddRecord;
        private System.Windows.Forms.ToolStripMenuItem TSMItemDelRecord;
        private System.Windows.Forms.ToolStripMenuItem TSMItemUpdateRecord;
        private System.Windows.Forms.ToolStripMenuItem tspItemBeginSerachUserInfo;
        private System.Windows.Forms.ToolStripMenuItem TSMItemExportResult;
        private System.Windows.Forms.Button btnBeginFind;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem TSMItemFormatChecks;
        private System.Windows.Forms.ProgressBar progressBarSnmpOpt;
        private System.Windows.Forms.Label lblSnmpOptPercentage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripComboBox tspcbxAppSleepTime;
        private System.Windows.Forms.ToolStripComboBox tspboxSNMPTimoutTime;
        private System.Windows.Forms.ToolStripComboBox tspcboxWordThreadValue;
    }
}
