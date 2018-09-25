namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    partial class FrmMainApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainApplication));
            this.panelMainPage = new System.Windows.Forms.Panel();
            this.panelMainRight = new System.Windows.Forms.Panel();
            this.pboxMainPageBg = new System.Windows.Forms.PictureBox();
            this.panelMenuShowHide = new System.Windows.Forms.Panel();
            this.pboxIsShow = new System.Windows.Forms.PictureBox();
            this.uctrlFrmMainApplicationLeftMenu1 = new OnuDevInfoOnUserViewImpl.ViewImpl.ControlView.UctrlFrmMainApplicationLeftMenu();
            this.uctrlFrmMainApplicationHeader1 = new OnuDevInfoOnUserViewImpl.ViewImpl.ControlView.UctrlFrmMainApplicationHeader();
            this.panelMainPage.SuspendLayout();
            this.panelMainRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMainPageBg)).BeginInit();
            this.panelMenuShowHide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIsShow)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMainPage
            // 
            this.panelMainPage.Controls.Add(this.panelMainRight);
            this.panelMainPage.Controls.Add(this.panelMenuShowHide);
            this.panelMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainPage.Location = new System.Drawing.Point(250, 53);
            this.panelMainPage.Name = "panelMainPage";
            this.panelMainPage.Size = new System.Drawing.Size(762, 562);
            this.panelMainPage.TabIndex = 4;
            // 
            // panelMainRight
            // 
            this.panelMainRight.Controls.Add(this.pboxMainPageBg);
            this.panelMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainRight.Location = new System.Drawing.Point(13, 0);
            this.panelMainRight.Name = "panelMainRight";
            this.panelMainRight.Size = new System.Drawing.Size(749, 562);
            this.panelMainRight.TabIndex = 12;
            // 
            // pboxMainPageBg
            // 
            this.pboxMainPageBg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pboxMainPageBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxMainPageBg.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.mainPageBg;
            this.pboxMainPageBg.Location = new System.Drawing.Point(0, 0);
            this.pboxMainPageBg.Name = "pboxMainPageBg";
            this.pboxMainPageBg.Size = new System.Drawing.Size(749, 562);
            this.pboxMainPageBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxMainPageBg.TabIndex = 10;
            this.pboxMainPageBg.TabStop = false;
            // 
            // panelMenuShowHide
            // 
            this.panelMenuShowHide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMenuShowHide.Controls.Add(this.pboxIsShow);
            this.panelMenuShowHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelMenuShowHide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuShowHide.Location = new System.Drawing.Point(0, 0);
            this.panelMenuShowHide.Name = "panelMenuShowHide";
            this.panelMenuShowHide.Size = new System.Drawing.Size(13, 562);
            this.panelMenuShowHide.TabIndex = 11;
            this.panelMenuShowHide.Tag = "";
            this.panelMenuShowHide.Click += new System.EventHandler(this.panelMenuShowHide_Click);
            // 
            // pboxIsShow
            // 
            this.pboxIsShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxIsShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboxIsShow.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.menu_hide;
            this.pboxIsShow.Location = new System.Drawing.Point(-3, 264);
            this.pboxIsShow.Name = "pboxIsShow";
            this.pboxIsShow.Size = new System.Drawing.Size(16, 19);
            this.pboxIsShow.TabIndex = 6;
            this.pboxIsShow.TabStop = false;
            this.pboxIsShow.Tag = "hideMenu";
            this.pboxIsShow.Click += new System.EventHandler(this.pboxIsShow_Click);
            // 
            // uctrlFrmMainApplicationLeftMenu1
            // 
            this.uctrlFrmMainApplicationLeftMenu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uctrlFrmMainApplicationLeftMenu1.Location = new System.Drawing.Point(0, 53);
            this.uctrlFrmMainApplicationLeftMenu1.Name = "uctrlFrmMainApplicationLeftMenu1";
            this.uctrlFrmMainApplicationLeftMenu1.Size = new System.Drawing.Size(250, 562);
            this.uctrlFrmMainApplicationLeftMenu1.TabIndex = 3;
            // 
            // uctrlFrmMainApplicationHeader1
            // 
            this.uctrlFrmMainApplicationHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uctrlFrmMainApplicationHeader1.Location = new System.Drawing.Point(0, 0);
            this.uctrlFrmMainApplicationHeader1.Name = "uctrlFrmMainApplicationHeader1";
            this.uctrlFrmMainApplicationHeader1.Size = new System.Drawing.Size(1012, 53);
            this.uctrlFrmMainApplicationHeader1.TabIndex = 0;
            // 
            // FrmMainApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 615);
            this.Controls.Add(this.panelMainPage);
            this.Controls.Add(this.uctrlFrmMainApplicationLeftMenu1);
            this.Controls.Add(this.uctrlFrmMainApplicationHeader1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMainApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统名称";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainApplication_FormClosing);
            this.Load += new System.EventHandler(this.FrmMainApplication_Load);
            this.panelMainPage.ResumeLayout(false);
            this.panelMainRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxMainPageBg)).EndInit();
            this.panelMenuShowHide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxIsShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlView.UctrlFrmMainApplicationHeader uctrlFrmMainApplicationHeader1;
        private ControlView.UctrlFrmMainApplicationLeftMenu uctrlFrmMainApplicationLeftMenu1;
        private System.Windows.Forms.Panel panelMainPage;
        private System.Windows.Forms.Panel panelMenuShowHide;
        private System.Windows.Forms.PictureBox pboxIsShow;
        private System.Windows.Forms.Panel panelMainRight;
        private System.Windows.Forms.PictureBox pboxMainPageBg;
    }
}