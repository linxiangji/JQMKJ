using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnuDevInfoOnUserModel.UctrlJqmkjMainApplication.EventClass;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    public partial class UctrlFrmMainApplicationHeader : UserControl
    {
        public UctrlFrmMainApplicationHeader()
        {
            InitializeComponent();
        }
        private void UctrlFrmMainApplicationHeader_Load(object sender, EventArgs e)
        {

        }
        private void TSMItemApplicationExit_Click(object sender, EventArgs e)
        {
            if (ClsFrmMainApplicationHeaderEvent.ApplicationExitClickEvent!=null)
            {
                ClsFrmMainApplicationHeaderEvent.ApplicationExitClickEvent(sender, e);
            }
        }

        private void TSMItemVersion_Click(object sender, EventArgs e)
        {
            if (ClsFrmMainApplicationHeaderEvent.BtnVersionClickOpenFrmVersionEvent != null)
            {
                ClsFrmMainApplicationHeaderEvent.BtnVersionClickOpenFrmVersionEvent(sender, e);
            }
        }

    }
}
