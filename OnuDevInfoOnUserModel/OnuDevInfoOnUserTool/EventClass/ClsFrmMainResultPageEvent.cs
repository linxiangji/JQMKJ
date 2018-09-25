using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserModel.EventClass
{
    [Serializable]
    public class ClsFrmMainResultPageEvent
    {
        public static TreeNodeMouseClickEventHandler TreeViewMenuNodeMouseClickEvent;
        public static EventHandler SearchTreeViewMenuNodeClickEvent;
        public static EventHandler SortTreeViewMenuNodeClickEvent;
    }
}
