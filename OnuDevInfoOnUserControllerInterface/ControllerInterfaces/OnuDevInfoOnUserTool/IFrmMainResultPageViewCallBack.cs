using OnuDevInfoOnUserModel.BoClass;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserControllerInterface.ControllerInterfaces
{
    public interface IFrmMainResultPageViewCallBack
    {
        void GetAllResultDataCallBack(ConcurrentDictionary<string, ClsResultInfoTableBo> resultInfoDictionary);
        void GetResultDataListByOltIpCallBack(ClsResultInfoTableBo currResultInfoTableBo);
        void GetResultDataByOltIpAndMacCallBack(ClsResultInfoTableBo currResultInfoTableBo);
    }
}
