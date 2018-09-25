using OnuDevInfoOnUserDaoInterface.DaoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.DBClass;
using System.Collections.Concurrent;

namespace OnuDevInfoOnUserDaoImpl.DaoImpl
{
    [Serializable]
    public class ClsResultPageDataDaoImpl : IResultPageDataDao
    {
        public ConcurrentDictionary<string,ClsResultInfoTableBo> GetAllResultDataFromDB()
        {
            return ClsFrmResultPageDataDB.resultInfoDictionaryDataDB;
        }
    }
}
