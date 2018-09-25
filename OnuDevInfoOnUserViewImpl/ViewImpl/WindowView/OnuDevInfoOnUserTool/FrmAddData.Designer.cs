namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    partial class FrmAddData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddData));
            this.uctrlAddDataLayout1 = new OnuDevInfoOnUserViewImpl.ViewImpl.ControlView.UctrlAddDataLayout();
            this.SuspendLayout();
            // 
            // uctrlAddDataLayout1
            // 
            this.uctrlAddDataLayout1.Location = new System.Drawing.Point(5, 0);
            this.uctrlAddDataLayout1.Name = "uctrlAddDataLayout1";
            this.uctrlAddDataLayout1.Size = new System.Drawing.Size(414, 246);
            this.uctrlAddDataLayout1.TabIndex = 0;
            // 
            // FrmAddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 251);
            this.Controls.Add(this.uctrlAddDataLayout1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddData";
            this.Text = "增加";
            this.Load += new System.EventHandler(this.FrmAddData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlView.UctrlAddDataLayout uctrlAddDataLayout1;
    }
}