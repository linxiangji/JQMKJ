using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserModel.EventClass;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    public partial class UctrlHeaderLayout : UserControl
    {
        #region 变量
        public Button btnBeginSnmpOptFind;
        public ToolStripComboBox tspCboxAppSleepTime;
        public ToolStripComboBox tspCboxSNMPTimeoutTime;
        public ToolStripComboBox tspCboxWordThreadNum;
        public ProgressBar progressBarSNMPOpt;
        public Label lblSNMPOptPercentage;
        #endregion

        public UctrlHeaderLayout()
        {
            InitializeComponent();
            btnBeginSnmpOptFind=this.btnBeginFind;
            tspCboxAppSleepTime=this.tspcbxAppSleepTime;
            tspCboxSNMPTimeoutTime=this.tspboxSNMPTimoutTime;
            tspCboxWordThreadNum = this.tspcboxWordThreadValue;
            progressBarSNMPOpt =this.progressBarSnmpOpt;
            lblSNMPOptPercentage = this.lblSnmpOptPercentage;
        }

        private void TSMItemExportTemplate_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.ExcelTemplateExportClickEvent != null)
            {
                ClsHeaderItemOptEvent.ExcelTemplateExportClickEvent(sender, e);
            }
        }

        private void TSMItemImportTemplate_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.ExcelTemplateDataImportDgvClickEvent != null)
            {
                ClsHeaderItemOptEvent.ExcelTemplateDataImportDgvClickEvent(sender, e);
            }
        }

        private void TSMItemExportResult_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.LvwResultExportExcelClickEvent != null)
            {
                ClsHeaderItemOptEvent.LvwResultExportExcelClickEvent(sender, e);
            }
        }

        private void TSMItemApplicationExit_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.ApplicationExitClickEvent != null)
            {
                ClsHeaderItemOptEvent.ApplicationExitClickEvent(sender, e);
            }
        }

        private void TSMItemFormatChecks_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.FormatChecksClickEvent != null)
            {
                ClsHeaderItemOptEvent.FormatChecksClickEvent(sender, e);
            }
        }

        private void btnBeginFind_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.BtnBeginFindClickEvent != null)
            {
                ClsHeaderItemOptEvent.BtnBeginFindClickEvent(sender, e);
            }
        }

        private void TSMItemAddRecord_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.BtnAddClickOpenFrmAddDataEvent != null)
            {
                ClsHeaderItemOptEvent.BtnAddClickOpenFrmAddDataEvent(sender, e);
            }
        }

        private void TSMItemDelRecord_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.BtnDeleteCheckedDataClickEvent != null)
            {
                ClsHeaderItemOptEvent.BtnDeleteCheckedDataClickEvent(sender, e);
            }
        }
        private void TSMItemUpdateRecord_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.BtnUpdateClickOpenFrmUpdateDataEvent != null)
            {
                ClsHeaderItemOptEvent.BtnUpdateClickOpenFrmUpdateDataEvent(sender, e);
            }
        }

        private void TSMItemVersion_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.BtnVersionClickOpenFrmVersionEvent != null)
            {
                ClsHeaderItemOptEvent.BtnVersionClickOpenFrmVersionEvent(sender, e);
            }
        }

        private void tspcboxWordThreadValue_TextChanged(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.CboxWorkThreadNumTextChangeEvent != null)
            {
                ClsHeaderItemOptEvent.CboxWorkThreadNumTextChangeEvent(sender, e);
            }
        }

        private void tspboxSNMPTimoutTime_TextChanged(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.CboxSNMPTimeoutTimeTextChangeEvent != null)
            {
                ClsHeaderItemOptEvent.CboxSNMPTimeoutTimeTextChangeEvent(sender, e);
            }
        }

        private void tspcbxAppSleepTime_TextChanged(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.CboxAppSleepTimeTextChangeEvent != null)
            {
                ClsHeaderItemOptEvent.CboxAppSleepTimeTextChangeEvent(sender, e);
            }
        }

        private void tspItemBeginSerachUserInfo_Click(object sender, EventArgs e)
        {
            if (ClsHeaderItemOptEvent.tspItemBeginSerachUserInfoEvent != null)
            {
                ClsHeaderItemOptEvent.tspItemBeginSerachUserInfoEvent(sender, e);
            }
        }

       
    }
}
