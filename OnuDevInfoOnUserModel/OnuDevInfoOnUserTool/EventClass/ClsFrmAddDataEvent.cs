using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.EventClass
{
    [Serializable]
    public class ClsFrmAddDataEvent
    {
        public static EventHandler BtnAddDataClickEvent;
        public static EventHandler BtnCancelDataClickEvent;
    }
}
