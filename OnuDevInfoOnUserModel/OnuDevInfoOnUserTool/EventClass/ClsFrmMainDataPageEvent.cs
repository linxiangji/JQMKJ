using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.EventClass
{
    [Serializable]
    public class ClsFrmMainDataPageEvent
    {
        public static EventHandler TspBtnAddClickEvent;
        public static EventHandler TspBtnUpdateClickEvent;
        public static EventHandler TspBtnDeleteClickEvent;
        public static EventHandler ChkAllClickEvent;
    }
}
