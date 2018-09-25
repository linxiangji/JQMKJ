using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnuDevInfoOnUserModel.EventClass;
using IPAddressControlLib;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    public partial class UctrlUpdateDataLayoutcs : UserControl
    {
        public IPAddressControl CurrUctrlOltIpAddress;
        public TextBox CurrTxtMacAddress;
        public ComboBox CurrCboxReadCommunity;
        public ComboBox CurrCboxWriteCommunity;

        public UctrlUpdateDataLayoutcs()
        {
            InitializeComponent();
            CurrUctrlOltIpAddress = this.UctrlOltIpAddress;
            CurrTxtMacAddress = this.txtOnuMacAddress;
            CurrCboxReadCommunity = this.CboxReadCommunity;
            CurrCboxWriteCommunity = this.CboxWriteCommunity;
        }

        private void UctrlUpdateDataLayoutcs_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ClsFrmUpdateDataEvent.BtnSaveDataClickEvent != null)
            {
                ClsFrmUpdateDataEvent.BtnSaveDataClickEvent(sender,e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ClsFrmUpdateDataEvent.BtnCancelDataClickEvent != null)
            {
                ClsFrmUpdateDataEvent.BtnCancelDataClickEvent(sender, e);
            }
        }
    }
}
