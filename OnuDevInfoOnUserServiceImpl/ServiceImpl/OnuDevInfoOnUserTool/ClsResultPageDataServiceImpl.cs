using OnuDevInfoOnUserServiceInterface.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserDaoImpl.DaoImpl;
using OnuDevInfoOnUserDaoInterface.DaoInterfaces;
using OnuDevInfoOnUserModel.VoClass;
using System.Collections.Concurrent;

namespace OnuDevInfoOnUserServiceImpl.ServiceImpl
{
    [Serializable]
    public class ClsResultPageDataServiceImpl : IResultPageDataService
    {
        private IResultPageDataDao m_resultPageDataDao = new ClsResultPageDataDaoImpl();

        public ConcurrentDictionary<string, ClsResultInfoTableBo> GetAllResultDataFromService()
        {
            return m_resultPageDataDao.GetAllResultDataFromDB();
        }

        public ClsResultInfoTableBo GetResultDataListByOltIpFromService(ClsOltInfoVo currOltInfoVo, ClsOnuInfoEntryVo currOnuInfoEntryVo)
        {
            if (currOltInfoVo != null)
            {
                ConcurrentDictionary<string, ClsResultInfoTableBo> currResultInfoDictionary = m_resultPageDataDao.GetAllResultDataFromDB();
                string currOptKey = currOltInfoVo.ipAddress + "+" + currOnuInfoEntryVo.onuMacAddress;
                if (currResultInfoDictionary.ContainsKey(currOptKey))
                {
                    return currResultInfoDictionary[currOptKey];
                }
            }
            return null;
        }

        public ClsResultInfoTableBo GetResultDataByOltIpAndMacFromService(ClsOltInfoVo currOltInfoVo, ClsOnuInfoEntryVo currOnuInfoEntryVo)
        {
            if (currOltInfoVo!=null && currOnuInfoEntryVo!=null)
            {
                ConcurrentDictionary<string, ClsResultInfoTableBo> currResultInfoDictionary = m_resultPageDataDao.GetAllResultDataFromDB();
                string currOptKey = currOltInfoVo.ipAddress + "+" + currOnuInfoEntryVo.onuMacAddress;
                if (currResultInfoDictionary.ContainsKey(currOptKey))
                {
                    return currResultInfoDictionary[currOptKey];
                }
            }
            return null;
        }
    }
}
