using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.DBClass;
using OnuDevInfoOnUserModel.Enum;
using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.DelegateMethodClass
{
    [Serializable]
    public class ClsDelegateUpdateProgressOptVo
    {
        private log4net.ILog m_log = log4net.LogManager.GetLogger("ClsDelegateUpdateProgressOptVo");

        public delegate void AsynUpdateUI(int nowProgressVlaue);//同步更新UI控件
        public delegate void UpdateMainThreadUI(int nowProgressVlaue);//声明一个更新主线程的委托
        public delegate void AccomplishAllTask();//声明一个在完成任务时通知主线程的委托

        public UpdateMainThreadUI UpdateMainProgressUIDelegate = null;
        public AccomplishAllTask SnmpTaskAllAccomplishCallBack = null;

        private Dictionary<string, List<ClsResultInfoTableBo>> m_currOptDataDictionary;
        private int m_currOptTaskCount;
        private int m_currThreadPoolNum;
        private static object currLockObj = new object();
        public static object addLockObj = new object();

        public ClsDelegateUpdateProgressOptVo(Dictionary<string, List<ClsResultInfoTableBo>> currOptDataDictionary, int currOptTaskCount, int currThreadPoolNum)
        {
            this.m_currOptTaskCount = currOptTaskCount;
            this.m_currOptDataDictionary = currOptDataDictionary;
            this.m_currThreadPoolNum = currThreadPoolNum;
        }
        public void SnmpTaskRunMethod()
        {
            MainSnmpRequestOptMethod(m_currOptDataDictionary, m_currOptTaskCount,m_currThreadPoolNum);
        }
        //主要的SNMP核心请求任务逻辑
        public void MainSnmpRequestOptMethod(Dictionary<string, List<ClsResultInfoTableBo>> currOptDataDictionary, int currOptTaskCount,int currThreadPoolNum)
        {
            //<1>判断结果信息字典容器resultInfoDataDictionary元素是否为空，每次执行此逻辑都要清空之前数据
            if (!ClsFrmResultPageDataDB.resultInfoDictionaryDataDB.IsEmpty)
            {
                ClsFrmResultPageDataDB.resultInfoDictionaryDataDB.Clear();
            }
            //<2>采用线程池异步操作，加快操作效率
            ThreadPool.SetMinThreads(currThreadPoolNum, currThreadPoolNum);
            ThreadPool.SetMaxThreads(currThreadPoolNum, currThreadPoolNum);
            foreach (KeyValuePair<string, List<ClsResultInfoTableBo>> currOptObj in currOptDataDictionary)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(oltSearchOnuUserMacaddressThreadMethod), currOptObj.Value);
            }
            //<3>任务完成回调
            SnmpTaskAllAccomplishCallBackMethod();
        }
        public void oltSearchOnuUserMacaddressThreadMethod(object currOptParam)
        {
            foreach (ClsResultInfoTableBo currNewResultInfoTableBo in (List<ClsResultInfoTableBo>)currOptParam)
            {
                StringBuilder currResultInfoTableBoKey = new StringBuilder();
                currResultInfoTableBoKey.Append(currNewResultInfoTableBo.oltInfoVo.ipAddress);
                currResultInfoTableBoKey.Append("+");
                currResultInfoTableBoKey.Append(currNewResultInfoTableBo.onuInfoEntryVo.onuMacAddress);
                try
                {
                    //（1）先执行ping指令看看是否能远程连接到olt设备
                    if (ClsPingOptHelper.IsPingOLTDevSuccessConnect(currNewResultInfoTableBo) == false)
                    {
                        continue;
                    }
                    //（2）获取当前OLT设备下所有的ONU设备索引,没有找到则数据为 0 
                    Dictionary<string, ClsOnuInfoEntryVo> currOnuInfoEntryDictionary = new Dictionary<string, ClsOnuInfoEntryVo>();
                    currOnuInfoEntryDictionary = ClsSnmpOptHelper.GetSubTreeOnuMacAddressInfo(currNewResultInfoTableBo);
                    if (currOnuInfoEntryDictionary.Count == 0)
                    {
                        currNewResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.OLT_ERROR_NO_FIND_DEV_INDEX;
                        currNewResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.OLT_ERROR_NO_FIND_DEV_INDEX);
                        continue;
                    }
                    StringBuilder currTrueMacAddressKey = new StringBuilder();
                    currTrueMacAddressKey.Append(ClsRegexHelper.GetOptMacAddressKey(currNewResultInfoTableBo.onuInfoEntryVo.onuMacAddress));

                    if (currOnuInfoEntryDictionary.ContainsKey(currTrueMacAddressKey.ToString()) == false)
                    {
                        //所有SNMP操作都正确，但是没有用户设备连接的处理
                        currNewResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMacAddress = "";
                        currNewResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.ONU_DEV_CANNNOT_FIND_MAC;
                        currNewResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.ONU_DEV_CANNNOT_FIND_MAC);
                        continue;
                    }
                    currNewResultInfoTableBo.onuInfoEntryVo.onuDeviceIndex = Convert.ToInt32(currOnuInfoEntryDictionary[currTrueMacAddressKey.ToString()].onuDeviceIndex);
                    //（3）SNMP 的set操作设置ONU mac地址,失败则进入下一个记录请求
                    if (ClsSnmpOptHelper.SetOptOnuDevIndexMethod(currNewResultInfoTableBo) == false)
                    {
                        continue;
                    }
                    //（4）SNMP 的getNext操作得到ONU的用户Mac地址信息
                    Dictionary<string, ClsOnuUniMacAddressEntryVo> currOnuUniMacAddressEntryVoDictionary = new Dictionary<string, ClsOnuUniMacAddressEntryVo>();
                    currOnuUniMacAddressEntryVoDictionary = ClsSnmpOptHelper.GetSubTreeOnuUserMacAddressInfo(currNewResultInfoTableBo);
                    if (currOnuUniMacAddressEntryVoDictionary.Count > 0)
                    {
                        //有用户设备连接的处理
                        foreach (KeyValuePair<string, ClsOnuUniMacAddressEntryVo> currOptKey in currOnuUniMacAddressEntryVoDictionary)
                        {
                            currNewResultInfoTableBo.onuUniMacAddressEntryVoList.Add(currOptKey.Value);
                        }
                    }
                    else
                    {
                        //所有SNMP操作都正确，但是没有用户设备连接的处理
                        currNewResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMacAddress = "";
                        currNewResultInfoTableBo.optMsgInfoVo.optStatus = EnumSnmpOptStatus.NO_ERROR_BUT_NO_USER_DEV;
                        currNewResultInfoTableBo.optMsgInfoVo.optMsg = ClsEnumHelper.GetEnumDescription(EnumSnmpOptStatus.NO_ERROR_BUT_NO_USER_DEV);
                    }
                }
                catch (Exception ex)
                {
                    m_log.Error(ex.ToString());
                }
                finally
                {
                    //（6）最终结果添加到容器
                    if (ClsFrmResultPageDataDB.resultInfoDictionaryDataDB.ContainsKey(currResultInfoTableBoKey.ToString()) == false)
                    {
                        if (currNewResultInfoTableBo != null && !string.IsNullOrEmpty(currResultInfoTableBoKey.ToString()))
                        {
                            //最终结果添加到容器
                            ClsFrmResultPageDataDB.resultInfoDictionaryDataDB[currResultInfoTableBoKey.ToString()] = currNewResultInfoTableBo;
                        }
                    }
                    //更新一次UI进度
                    UpdateMainProgressValueMethod();
                    //每一次完整操作好后缓冲时间，以免机器不响应。
                    Thread.Sleep(currNewResultInfoTableBo.currHeaderConfParamVo.appSleepTime);
                }
            }
        }
        /// <summary>
        /// 调用更新主线程进度条状态的委托,无论执行成功与失败，进度条都要加 1
        /// </summary>
        public void UpdateMainProgressValueMethod()
        {
            if (UpdateMainProgressUIDelegate != null)
            {
                lock (currLockObj)
                {
                    UpdateMainProgressUIDelegate(1);
                }
            }
        }
        /// <summary>
        /// 所有的任务都完成了，则执行提示并结束此此操作
        /// </summary>
        public void SnmpTaskAllAccomplishCallBackMethod()
        {
            //等待所有的线程池任务都完成的判断
            while (true)
            {
                Thread.Sleep(100);
                int maxWorkerThreads, workerThreads;
                int portThreads;
                ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                if (maxWorkerThreads - workerThreads == 0)
                {
                    //Console.WriteLine("任务全部完成了，退出到主程序线程操作。");
                    break;
                }
            }
            if (SnmpTaskAllAccomplishCallBack != null)
            {
                //任务完成时通知主线程作出相应的处理
                SnmpTaskAllAccomplishCallBack();
            }
        }
    }
}
