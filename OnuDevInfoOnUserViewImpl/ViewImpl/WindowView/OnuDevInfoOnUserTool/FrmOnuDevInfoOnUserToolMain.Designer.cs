namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    partial class FrmOnuDevInfoOnUserToolMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOnuDevInfoOnUserToolMain));
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uctrlHeaderLayout1 = new OnuDevInfoOnUserViewImpl.ViewImpl.ControlView.UctrlHeaderLayout();
            this.uctrlBodyLayout1 = new OnuDevInfoOnUserViewImpl.ViewImpl.ControlView.UctrlBodyLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.IsSplitterFixed = true;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.uctrlHeaderLayout1);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.uctrlBodyLayout1);
            this.mainSplitContainer.Size = new System.Drawing.Size(1084, 612);
            this.mainSplitContainer.SplitterDistance = 55;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // uctrlHeaderLayout1
            // 
            this.uctrlHeaderLayout1.AutoSize = true;
            this.uctrlHeaderLayout1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uctrlHeaderLayout1.Location = new System.Drawing.Point(0, 0);
            this.uctrlHeaderLayout1.Name = "uctrlHeaderLayout1";
            this.uctrlHeaderLayout1.Size = new System.Drawing.Size(1084, 53);
            this.uctrlHeaderLayout1.TabIndex = 0;
            // 
            // uctrlBodyLayout1
            // 
            this.uctrlBodyLayout1.AutoSize = true;
            this.uctrlBodyLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctrlBodyLayout1.Location = new System.Drawing.Point(0, 0);
            this.uctrlBodyLayout1.Name = "uctrlBodyLayout1";
            this.uctrlBodyLayout1.Size = new System.Drawing.Size(1084, 553);
            this.uctrlBodyLayout1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 612);
            this.Controls.Add(this.mainSplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ONU用户信息查询工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private ControlView.UctrlHeaderLayout uctrlHeaderLayout1;
        private ControlView.UctrlBodyLayout uctrlBodyLayout1;
    }
}