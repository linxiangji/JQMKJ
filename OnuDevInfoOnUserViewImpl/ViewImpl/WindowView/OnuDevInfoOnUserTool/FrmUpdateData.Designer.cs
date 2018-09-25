namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    partial class FrmUpdateData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdateData));
            this.uctrlUpdateDataLayoutcs1 = new OnuDevInfoOnUserViewImpl.ViewImpl.ControlView.UctrlUpdateDataLayoutcs();
            this.SuspendLayout();
            // 
            // uctrlUpdateDataLayoutcs1
            // 
            this.uctrlUpdateDataLayoutcs1.Location = new System.Drawing.Point(2, -3);
            this.uctrlUpdateDataLayoutcs1.Name = "uctrlUpdateDataLayoutcs1";
            this.uctrlUpdateDataLayoutcs1.Size = new System.Drawing.Size(420, 253);
            this.uctrlUpdateDataLayoutcs1.TabIndex = 0;
            // 
            // FrmUpdateData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 251);
            this.Controls.Add(this.uctrlUpdateDataLayoutcs1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUpdateData";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlView.UctrlUpdateDataLayoutcs uctrlUpdateDataLayoutcs1;
    }
}