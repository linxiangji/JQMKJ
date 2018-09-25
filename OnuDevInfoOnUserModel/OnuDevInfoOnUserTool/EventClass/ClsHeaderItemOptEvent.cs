using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.EventClass
{
    [Serializable]
    public class ClsHeaderItemOptEvent
    {
        public static EventHandler ExcelTemplateExportClickEvent;
        public static EventHandler ExcelTemplateDataImportDgvClickEvent;
        public static EventHandler LvwResultExportExcelClickEvent;
        public static EventHandler ApplicationExitClickEvent;
        public static EventHandler FormatChecksClickEvent;
        public static EventHandler BtnBeginFindClickEvent;
        public static EventHandler BtnAddClickOpenFrmAddDataEvent;
        public static EventHandler BtnUpdateClickOpenFrmUpdateDataEvent;
        public static EventHandler BtnDeleteCheckedDataClickEvent;
        public static EventHandler BtnVersionClickOpenFrmVersionEvent;
        public static EventHandler tspItemBeginSerachUserInfoEvent;

        public static EventHandler CboxWorkThreadNumTextChangeEvent;
        public static EventHandler CboxSNMPTimeoutTimeTextChangeEvent;
        public static EventHandler CboxAppSleepTimeTextChangeEvent;
    }
}
