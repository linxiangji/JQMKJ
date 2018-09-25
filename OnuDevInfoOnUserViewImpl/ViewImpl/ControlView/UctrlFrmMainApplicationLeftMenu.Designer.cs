using OnuDevInfoOnUserViewImpl.ViewImpl.UctrlJqmkjMainApplication;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    partial class UctrlFrmMainApplicationLeftMenu
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
            this.outlookBarLeftMenu = new OnuDevInfoOnUserViewImpl.ViewImpl.UctrlJqmkjMainApplication.OutlookBar();
            this.SuspendLayout();
            // 
            // outlookBarLeftMenu
            // 
            this.outlookBarLeftMenu.ButtonHeight = 25;
            this.outlookBarLeftMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookBarLeftMenu.Location = new System.Drawing.Point(0, 0);
            this.outlookBarLeftMenu.Name = "outlookBarLeftMenu";
            this.outlookBarLeftMenu.SelectedBand = 0;
            this.outlookBarLeftMenu.Size = new System.Drawing.Size(250, 600);
            this.outlookBarLeftMenu.TabIndex = 0;
            // 
            // UctrlFrmMainApplicationLeftMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outlookBarLeftMenu);
            this.Name = "UctrlFrmMainApplicationLeftMenu";
            this.Size = new System.Drawing.Size(250, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private OutlookBar outlookBarLeftMenu;
    }
}
