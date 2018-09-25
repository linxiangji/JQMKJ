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
    public partial class UctrlAddDataLayout : UserControl
    {
        public IPAddressControl CurrUctrlOltIpAddress;
        public TextBox CurrTxtMacAddress;
        public ComboBox CurrCboxReadCommunity;
        public ComboBox CurrCboxWriteCommunity;

        public UctrlAddDataLayout()
        {
            InitializeComponent();
            CurrUctrlOltIpAddress = this.UctrlOltIpAddress;
            CurrTxtMacAddress = this.txtOnuMacAddress;
            CurrCboxReadCommunity = this.CboxReadCommunity;
            CurrCboxWriteCommunity = this.CboxWriteCommunity;
        }

        private void UctrlAddDataLayout_Load(object sender, EventArgs e)
        {
          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ClsFrmAddDataEvent.BtnAddDataClickEvent!=null)
            {
                ClsFrmAddDataEvent.BtnAddDataClickEvent(sender,e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ClsFrmAddDataEvent.BtnCancelDataClickEvent!= null)
            {
                ClsFrmAddDataEvent.BtnCancelDataClickEvent(sender, e);
            }
        }
    }
}
