using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    public partial class UctrlFrmVersionLayout : UserControl
    {
        public Label LblApplicationName = null;
        public Label LblVersionNum = null;
        public Label LblCompileTime = null;
        public Label LblCopyright = null;
        public Label LblCompanyName = null;
        public Label LblWebsiteAddress = null;

        public UctrlFrmVersionLayout()
        {
            InitializeComponent();

            LblApplicationName = this.lblMainApplicationName;
            LblVersionNum = this.lblMainVersionNum;
            LblCompileTime = this.lblCompileTime;
            LblCopyright = this.lblCopyright;
            LblCompanyName = this.lblCompanyName;
            LblWebsiteAddress = this.lblWebsiteAddress;
        }

        private void UctrlFrmVersionLayout_Load(object sender, EventArgs e)
        {

        }
    }
}
