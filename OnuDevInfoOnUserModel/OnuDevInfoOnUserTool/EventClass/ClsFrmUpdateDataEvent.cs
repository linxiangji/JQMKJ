using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.EventClass
{
    [Serializable]
    public class ClsFrmUpdateDataEvent
    {
        public static EventHandler BtnSaveDataClickEvent;
        public static EventHandler BtnCancelDataClickEvent;
    }
}
