using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserModel.BoClass
{
    [Serializable]
    public class ClsTreeDataBO<T>
    {
        public T dataObj;
        public List<T> dataList;
    }
}
