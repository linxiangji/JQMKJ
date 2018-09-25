namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    partial class UctrlAddDataLayout
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOltIpAddress = new System.Windows.Forms.Label();
            this.lblOnuMacAddress = new System.Windows.Forms.Label();
            this.txtOnuMacAddress = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboxWriteCommunity = new System.Windows.Forms.ComboBox();
            this.CboxReadCommunity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UctrlOltIpAddress = new IPAddressControlLib.IPAddressControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(179, 189);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(268, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblOltIpAddress
            // 
            this.lblOltIpAddress.AutoSize = true;
            this.lblOltIpAddress.Location = new System.Drawing.Point(65, 37);
            this.lblOltIpAddress.Name = "lblOltIpAddress";
            this.lblOltIpAddress.Size = new System.Drawing.Size(77, 12);
            this.lblOltIpAddress.TabIndex = 2;
            this.lblOltIpAddress.Text = "OLT-IP地址：";
            // 
            // lblOnuMacAddress
            // 
            this.lblOnuMacAddress.AutoSize = true;
            this.lblOnuMacAddress.Location = new System.Drawing.Point(59, 74);
            this.lblOnuMacAddress.Name = "lblOnuMacAddress";
            this.lblOnuMacAddress.Size = new System.Drawing.Size(83, 12);
            this.lblOnuMacAddress.TabIndex = 3;
            this.lblOnuMacAddress.Text = "ONU-Mac地址：";
            // 
            // txtOnuMacAddress
            // 
            this.txtOnuMacAddress.Location = new System.Drawing.Point(149, 70);
            this.txtOnuMacAddress.Name = "txtOnuMacAddress";
            this.txtOnuMacAddress.Size = new System.Drawing.Size(194, 21);
            this.txtOnuMacAddress.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboxWriteCommunity);
            this.groupBox1.Controls.Add(this.CboxReadCommunity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UctrlOltIpAddress);
            this.groupBox1.Controls.Add(this.txtOnuMacAddress);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.lblOnuMacAddress);
            this.groupBox1.Controls.Add(this.lblOltIpAddress);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 245);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // CboxWriteCommunity
            // 
            this.CboxWriteCommunity.FormattingEnabled = true;
            this.CboxWriteCommunity.Items.AddRange(new object[] {
            "public",
            "private",
            "ocn"});
            this.CboxWriteCommunity.Location = new System.Drawing.Point(149, 145);
            this.CboxWriteCommunity.Name = "CboxWriteCommunity";
            this.CboxWriteCommunity.Size = new System.Drawing.Size(194, 20);
            this.CboxWriteCommunity.TabIndex = 12;
            this.CboxWriteCommunity.Text = "private";
            // 
            // CboxReadCommunity
            // 
            this.CboxReadCommunity.FormattingEnabled = true;
            this.CboxReadCommunity.Items.AddRange(new object[] {
            "public",
            "private"});
            this.CboxReadCommunity.Location = new System.Drawing.Point(149, 108);
            this.CboxReadCommunity.Name = "CboxReadCommunity";
            this.CboxReadCommunity.Size = new System.Drawing.Size(194, 20);
            this.CboxReadCommunity.TabIndex = 11;
            this.CboxReadCommunity.Text = "public";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "OLT-写共同体：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "OLT-读共同体：";
            // 
            // UctrlOltIpAddress
            // 
            this.UctrlOltIpAddress.AllowInternalTab = false;
            this.UctrlOltIpAddress.AutoHeight = true;
            this.UctrlOltIpAddress.BackColor = System.Drawing.SystemColors.Window;
            this.UctrlOltIpAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UctrlOltIpAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UctrlOltIpAddress.Location = new System.Drawing.Point(149, 33);
            this.UctrlOltIpAddress.MinimumSize = new System.Drawing.Size(96, 21);
            this.UctrlOltIpAddress.Name = "UctrlOltIpAddress";
            this.UctrlOltIpAddress.ReadOnly = false;
            this.UctrlOltIpAddress.Size = new System.Drawing.Size(194, 21);
            this.UctrlOltIpAddress.TabIndex = 6;
            this.UctrlOltIpAddress.Text = "...";
            // 
            // UctrlAddDataLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UctrlAddDataLayout";
            this.Size = new System.Drawing.Size(414, 246);
            this.Load += new System.EventHandler(this.UctrlAddDataLayout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOltIpAddress;
        private System.Windows.Forms.Label lblOnuMacAddress;
        private System.Windows.Forms.TextBox txtOnuMacAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private IPAddressControlLib.IPAddressControl UctrlOltIpAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboxWriteCommunity;
        private System.Windows.Forms.ComboBox CboxReadCommunity;
    }
}
