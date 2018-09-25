using OnuDevInfoOnUserModel.BoClass;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserDaoInterface.DaoInterfaces
{
    public interface IResultPageDataDao
    {
        ConcurrentDictionary<string, ClsResultInfoTableBo> GetAllResultDataFromDB();
    }
}
