namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    partial class UctrlUpdateDataLayoutcs
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboxWriteCommunity = new System.Windows.Forms.ComboBox();
            this.CboxReadCommunity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UctrlOltIpAddress = new IPAddressControlLib.IPAddressControl();
            this.txtOnuMacAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOnuMacAddress = new System.Windows.Forms.Label();
            this.lblOltIpAddress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboxWriteCommunity);
            this.groupBox1.Controls.Add(this.CboxReadCommunity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UctrlOltIpAddress);
            this.groupBox1.Controls.Add(this.txtOnuMacAddress);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.lblOnuMacAddress);
            this.groupBox1.Controls.Add(this.lblOltIpAddress);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 245);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // CboxWriteCommunity
            // 
            this.CboxWriteCommunity.FormattingEnabled = true;
            this.CboxWriteCommunity.Items.AddRange(new object[] {
            "public",
            "private",
            "ocn"});
            this.CboxWriteCommunity.Location = new System.Drawing.Point(145, 143);
            this.CboxWriteCommunity.Name = "CboxWriteCommunity";
            this.CboxWriteCommunity.Size = new System.Drawing.Size(194, 20);
            this.CboxWriteCommunity.TabIndex = 16;
            // 
            // CboxReadCommunity
            // 
            this.CboxReadCommunity.FormattingEnabled = true;
            this.CboxReadCommunity.Items.AddRange(new object[] {
            "public",
            "private"});
            this.CboxReadCommunity.Location = new System.Drawing.Point(144, 105);
            this.CboxReadCommunity.Name = "CboxReadCommunity";
            this.CboxReadCommunity.Size = new System.Drawing.Size(194, 20);
            this.CboxReadCommunity.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "OLT-写共同体：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "OLT-读共同体：";
            // 
            // UctrlOltIpAddress
            // 
            this.UctrlOltIpAddress.AllowInternalTab = false;
            this.UctrlOltIpAddress.AutoHeight = true;
            this.UctrlOltIpAddress.BackColor = System.Drawing.SystemColors.Window;
            this.UctrlOltIpAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UctrlOltIpAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UctrlOltIpAddress.Location = new System.Drawing.Point(145, 30);
            this.UctrlOltIpAddress.MinimumSize = new System.Drawing.Size(96, 21);
            this.UctrlOltIpAddress.Name = "UctrlOltIpAddress";
            this.UctrlOltIpAddress.ReadOnly = false;
            this.UctrlOltIpAddress.Size = new System.Drawing.Size(194, 21);
            this.UctrlOltIpAddress.TabIndex = 6;
            this.UctrlOltIpAddress.Text = "...";
            // 
            // txtOnuMacAddress
            // 
            this.txtOnuMacAddress.Location = new System.Drawing.Point(145, 67);
            this.txtOnuMacAddress.Name = "txtOnuMacAddress";
            this.txtOnuMacAddress.Size = new System.Drawing.Size(194, 21);
            this.txtOnuMacAddress.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(176, 188);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(266, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblOnuMacAddress
            // 
            this.lblOnuMacAddress.AutoSize = true;
            this.lblOnuMacAddress.Location = new System.Drawing.Point(54, 71);
            this.lblOnuMacAddress.Name = "lblOnuMacAddress";
            this.lblOnuMacAddress.Size = new System.Drawing.Size(83, 12);
            this.lblOnuMacAddress.TabIndex = 3;
            this.lblOnuMacAddress.Text = "ONU-Mac地址：";
            // 
            // lblOltIpAddress
            // 
            this.lblOltIpAddress.AutoSize = true;
            this.lblOltIpAddress.Location = new System.Drawing.Point(61, 33);
            this.lblOltIpAddress.Name = "lblOltIpAddress";
            this.lblOltIpAddress.Size = new System.Drawing.Size(77, 12);
            this.lblOltIpAddress.TabIndex = 2;
            this.lblOltIpAddress.Text = "OLT-IP地址：";
            // 
            // UctrlUpdateDataLayoutcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UctrlUpdateDataLayoutcs";
            this.Size = new System.Drawing.Size(420, 253);
            this.Load += new System.EventHandler(this.UctrlUpdateDataLayoutcs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private IPAddressControlLib.IPAddressControl UctrlOltIpAddress;
        private System.Windows.Forms.TextBox txtOnuMacAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOnuMacAddress;
        private System.Windows.Forms.Label lblOltIpAddress;
        private System.Windows.Forms.ComboBox CboxWriteCommunity;
        private System.Windows.Forms.ComboBox CboxReadCommunity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
