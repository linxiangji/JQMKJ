using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserCommon.HelpTools.Common.NpoiExcel;
using OnuDevInfoOnUserControllerInterface.ControllerInterfaces;
using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.Constant;
using OnuDevInfoOnUserModel.DBClass;
using OnuDevInfoOnUserModel.EventClass;
using OnuDevInfoOnUserModel.VoClass;
using OnuDevInfoOnUserViewImpl.ViewImpl.DelegateMethodClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OnuDevInfoOnUserCommon.HelpTools.ClsWriteExcel;
using static OnuDevInfoOnUserViewImpl.ViewImpl.DelegateMethodClass.ClsDelegateUpdateProgressOptVo;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    public partial class FrmOnuDevInfoOnUserToolMain: IFrmMainHeaderOptViewCallBack
    {
     
    /// <summary>
    /// 顶部导航菜单：各种操作事件绑定具体方法的逻辑代码
    /// </summary>
    public void FrmMainHeaderMenuEventLoad()
        {
            ClsHeaderItemOptEvent.ExcelTemplateExportClickEvent = ExcelTemplateExportClickEventImpl;
            ClsHeaderItemOptEvent.ExcelTemplateDataImportDgvClickEvent = ExcelTemplateDataImportDgvClickEvent;
            ClsHeaderItemOptEvent.LvwResultExportExcelClickEvent = LvwResultExportExcelClickEventImpl;
            ClsHeaderItemOptEvent.ApplicationExitClickEvent = ApplicationExitClickEventImpl;
            ClsHeaderItemOptEvent.FormatChecksClickEvent = FormatChecksClickEventImpl;
            ClsHeaderItemOptEvent.BtnAddClickOpenFrmAddDataEvent = BtnAddClickOpenFrmAddDataEventImpl;
            ClsHeaderItemOptEvent.BtnUpdateClickOpenFrmUpdateDataEvent = BtnUpdateClickOpenFrmUpdateDataEventImpl;
            ClsHeaderItemOptEvent.BtnDeleteCheckedDataClickEvent = BtnDeleteCheckedDataClickEventImpl;
            ClsHeaderItemOptEvent.BtnVersionClickOpenFrmVersionEvent = BtnVersionClickOpenFrmVersionEventImpl;
            //顶部缓冲时间、snmp超时时间、线程数验证
            ClsHeaderItemOptEvent.CboxAppSleepTimeTextChangeEvent = CboxAppSleepTimeTextChangeEventImpl;
            ClsHeaderItemOptEvent.CboxSNMPTimeoutTimeTextChangeEvent = CboxSNMPTimeoutTimeTextChangeEventImpl;
            ClsHeaderItemOptEvent.CboxWorkThreadNumTextChangeEvent = CboxWorkThreadNumTextChangeEventImpl;
            //开始查询的核心方法
            ClsHeaderItemOptEvent.BtnBeginFindClickEvent = BtnBeginFindUserOnuInfoClickEventImpl;
            ClsHeaderItemOptEvent.tspItemBeginSerachUserInfoEvent = BtnBeginFindUserOnuInfoClickEventImpl;
        }

        #region 事件方法的实现
        /// <summary>
        /// 顶部导航菜单：验证线程数输入框是否临时存放输入的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxWorkThreadNumTextChangeEventImpl(object sender, EventArgs e)
        {
            try
            {
                ToolStripWorkThreadNumTextChangeRegexMethod(this.uctrlHeaderLayout1.tspCboxWordThreadNum);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：验证SNMP超时时间输入框是否临时存放输入的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxSNMPTimeoutTimeTextChangeEventImpl(object sender, EventArgs e)
        {
            try
            {
                ToolStripSnmpTimeoutTimeTextChangeRegexMethod(this.uctrlHeaderLayout1.tspCboxSNMPTimeoutTime);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：验证缓冲时间输入框是否临时存放输入的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboxAppSleepTimeTextChangeEventImpl(object sender, EventArgs e)
        {
            try
            {
                ToolStripAppSleepTimeTextChangeRegexMethod(this.uctrlHeaderLayout1.tspCboxAppSleepTime);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 顶部导航菜单：打开版本窗体逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVersionClickOpenFrmVersionEventImpl(object sender, EventArgs e)
        {
            try
            {
                string currNowCopyrightCompany = ClsConfigHelper.readCofigValueByKey("NowCopyrightCompany");
                string currNowToolVersionNum = ClsConfigHelper.readCofigValueByKey("NowToolVersionNum");
                ClsVersionVo versionVo = new ClsVersionVo();
                versionVo.compangyName = currNowCopyrightCompany != null ? currNowCopyrightCompany : "";
                versionVo.versionNum = currNowToolVersionNum != null ? currNowToolVersionNum : "";
                if (m_frmMainHeaderOptView != null)
                {
                    m_frmMainHeaderOptView.ShowFrmVersion(versionVo);
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 控制层方法回调逻辑：显示版本情况窗体
        /// </summary>
        public void ShowFrmVersionCallBack(ClsVersionVo versionVo)
        {
            try
            {
                if (versionVo != null)
                {
                    FrmVersion currFrmVersion = new FrmVersion(versionVo);
                    currFrmVersion.StartPosition = FormStartPosition.CenterParent;
                    currFrmVersion.ShowDialog();
                    currFrmVersion.Dispose();
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：打开增加记录窗体逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClickOpenFrmAddDataEventImpl(object sender, EventArgs e)
        {
            try
            {
                BtnAddClickOpenFrmAddDataMethod();
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：打开编辑记录窗体逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateClickOpenFrmUpdateDataEventImpl(object sender, EventArgs e)
        {
            try
            {
                BtnUpdateClickOpenFrmUpdateDataMethod(this.uctrlBodyLayout1.lvwDataInfoTable);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：选中记录删除逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteCheckedDataClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                BtnDeleteCheckedDataClickMethod(this.uctrlBodyLayout1.lvwDataInfoTable);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：开启snmp用户信息查询的逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBeginFindUserOnuInfoClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                ProgressBar currSnmpOptProgressBar = this.uctrlHeaderLayout1.progressBarSNMPOpt;
                if (currSnmpOptProgressBar.Visible == true)
                {
                    ClsMessageBoxHelper.ShowInfoMsg("程序正在查询中，请稍等。。。");
                    return;
                }
                //清空上一次查找的结果
                ClsTreeViewHelper.ClearLastSearchDataMethod();
                string currTxtAppSleepTime = this.uctrlHeaderLayout1.tspCboxAppSleepTime.Text.Trim();
                string currTxtSNMPTimeoutTime = this.uctrlHeaderLayout1.tspCboxSNMPTimeoutTime.Text.Trim();
                string currTetWorkThreadNum = this.uctrlHeaderLayout1.tspCboxWordThreadNum.Text.Trim();
                if (RegexHeaderConfParamMethod(currTxtAppSleepTime, currTxtSNMPTimeoutTime, currTetWorkThreadNum) == false)
                {
                    return;
                }
                ListView currLvwDataInfoTable = this.uctrlBodyLayout1.lvwDataInfoTable;
                //格式校验
                if (ListViewContentFormatCheckOptMethod(currLvwDataInfoTable, true) == false)
                {
                    return;
                }
                //界面按钮控制与进度提示
                this.uctrlHeaderLayout1.btnBeginSnmpOptFind.Enabled = false;
                this.uctrlHeaderLayout1.lblSNMPOptPercentage.Visible = true;
                this.uctrlBodyLayout1.lvwResultInfoTable.Items.Clear();
                this.uctrlBodyLayout1.tspTxtSearchCondition.Text = "";

                ClsHeaderConfParamVo currHeaderConfParamVo = new ClsHeaderConfParamVo();
                currHeaderConfParamVo.appSleepTime = Convert.ToInt32(currTxtAppSleepTime);
                currHeaderConfParamVo.snmpTimeOutTime = Convert.ToInt32(currTxtSNMPTimeoutTime);
                currHeaderConfParamVo.workThreadNum = Convert.ToInt32(currTetWorkThreadNum);
                int oltCommonMacNumValue = 0;
                Dictionary<string, List<ClsResultInfoTableBo>> currOptDataDictionary = ClsListViewHelper.ListViewData2Dictionary(currLvwDataInfoTable, currHeaderConfParamVo, ref oltCommonMacNumValue);
                Func<TreeNode> createTreeViewRootNodeTask = new Func<TreeNode>(delegate ()
                {
                    //返回任务结果
                    return ClsTreeViewHelper.DictionaryDataCreateRootNode(currOptDataDictionary); ;
                });
                // 发起一次异步调用，实际上就是在.net线程池中执行当前Task任务
                // 这时由于是其它线程在工作，UI线程未被阻塞，所以窗体不会假死
                createTreeViewRootNodeTask.BeginInvoke(currTaskAsyncResult =>
                {
                    //使用EndInvoke获取到任务结果
                    TreeNode rootNodeResult = createTreeViewRootNodeTask.EndInvoke(currTaskAsyncResult);
                    //使用Control.Invoke方法操作控件属性，如果没有Invoke，将会抛出跨线程访问UI控件的异常
                    Invoke(new Action(() => {
                        this.uctrlBodyLayout1.treeViewOptMenu.Nodes.Clear();
                        this.uctrlBodyLayout1.treeViewOptMenu.Nodes.Add(rootNodeResult);
                        this.uctrlBodyLayout1.treeViewOptMenu.ExpandAll();
                    }));
                }, null);
                //以下为snmp请求的相关操作代码逻辑
                int snmpRequestOptTaskCount = currLvwDataInfoTable.Items.Count - oltCommonMacNumValue;
                currSnmpOptProgressBar.Value = ClsConstant.NUM_VALUE_ZERO;
                currSnmpOptProgressBar.Maximum = snmpRequestOptTaskCount;
                currSnmpOptProgressBar.Visible = true;

                ClsDelegateUpdateProgressOptVo snmpOptUpdateProgressVo = new ClsDelegateUpdateProgressOptVo(currOptDataDictionary, snmpRequestOptTaskCount, currHeaderConfParamVo.workThreadNum);//实例化一个写入数据的类
                snmpOptUpdateProgressVo.UpdateMainProgressUIDelegate += BeginUpdateMainUIStatus;//绑定更新任务状态的委托
                snmpOptUpdateProgressVo.SnmpTaskAllAccomplishCallBack += SnmpRequestAllAccomplish;//绑定完成任务要调用的委托
                Thread thread = new Thread(new ThreadStart(snmpOptUpdateProgressVo.SnmpTaskRunMethod));
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
                //错误的处理逻辑
                SnmpRequestOptIfErrorMethod();
            }
        }
        /// <summary>
        /// 更新UI：进度条的进度值变更
        /// </summary>
        /// <param name="nowProgressValue"></param>
        private void BeginUpdateMainUIStatus(int nowProgressValue)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate (int progressValue)
                {
                    ProgressBar currSnmpOptProgressBar = this.uctrlHeaderLayout1.progressBarSNMPOpt;
                    currSnmpOptProgressBar.Value += progressValue;
                    this.uctrlHeaderLayout1.lblSNMPOptPercentage.Text = currSnmpOptProgressBar.Value.ToString() + "/" + currSnmpOptProgressBar.Maximum.ToString();
                }), nowProgressValue);
            }
            else
            {
                ProgressBar currSnmpOptProgressBar = this.uctrlHeaderLayout1.progressBarSNMPOpt;
                currSnmpOptProgressBar.Value += nowProgressValue;
                this.uctrlHeaderLayout1.lblSNMPOptPercentage.Text = currSnmpOptProgressBar.Value.ToString() + "/" + currSnmpOptProgressBar.Maximum.ToString();
            }
        }
        /// <summary>
        /// Snmp请求任务全部完成任务时需要调用,且没有异常产生时调用
        /// </summary>
        private void SnmpRequestAllAccomplish()
        {
            Invoke(new Action(() => {
                //还可以进行其他的一些完任务完成之后的逻辑处理
                ClsMessageBoxHelper.ShowInfoMsg("查询操作执行完毕，请到结果信息页查询");
                this.uctrlHeaderLayout1.progressBarSNMPOpt.Visible = false;
                this.uctrlHeaderLayout1.lblSNMPOptPercentage.Visible = false;
                this.uctrlHeaderLayout1.btnBeginSnmpOptFind.Enabled = true;
            }));
        }
        /// <summary>
        /// Snmp请求查询任务如果产生错误时需要调用
        /// </summary>
        private void SnmpRequestOptIfErrorMethod()
        {
            Invoke(new Action(() => {
                //还可以进行其他的一些完任务完成之后的逻辑处理
                ClsMessageBoxHelper.ShowInfoMsg("查询操作失败，请查看程序错误日志或重试。");
                this.uctrlHeaderLayout1.progressBarSNMPOpt.Visible = false;
                this.uctrlHeaderLayout1.lblSNMPOptPercentage.Visible = false;
                this.uctrlHeaderLayout1.btnBeginSnmpOptFind.Enabled = true;
            }));
        }
        /// <summary>
        /// 顶部导航菜单：数据格式校验的逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatChecksClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                ListViewContentFormatCheckOptMethod(this.uctrlBodyLayout1.lvwDataInfoTable, false);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：退出程序的逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationExitClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                DialogResult currDialogResult = ClsMessageBoxHelper.ShowOKCancelMsg("确定退出此程序吗？");
                if (currDialogResult == DialogResult.OK)
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：最终结果信息导出Excel的逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvwResultExportExcelClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = ClsFileDialogHelper.GetSaveFileDialogOnExcel(ClsConstant.EXCEL_FILE_NAME);
                if (saveFileDialog == null)
                {
                    return;
                }
                string fileName = saveFileDialog.FileName;
                string sheetName = ClsConstant.EXCEL_FILE_NAME;
                ClsNpoiExcelHelper.ResultToExcel(this.uctrlBodyLayout1.lvwResultInfoTable, sheetName, fileName, ClsFrmResultPageDataDB.resultInfoDictionaryDataDB);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：从外部Excel文件数据导入到数据信息表的逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelTemplateDataImportDgvClickEvent(object sender, EventArgs e)
        {
            try
            {
                if (ClsFrmResultPageDataDB.resultInfoDictionaryDataDB.Count > 0 || this.uctrlBodyLayout1.treeViewOptMenu.Nodes.Count > 0)
                {
                    DialogResult reImportDataFileOpt = ClsMessageBoxHelper.ShowOKCancelMsg("重新将数据导入会导致结果信息表的临时数据清空，则无法找回，请确认是否继续操作？");
                    if (reImportDataFileOpt == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                //清空之前的数据
                ClsFrmResultPageDataDB.resultInfoDictionaryDataDB.Clear();
                this.uctrlBodyLayout1.lvwResultInfoTable.Items.Clear();
                this.uctrlBodyLayout1.treeViewOptMenu.Nodes.Clear();
                this.uctrlBodyLayout1.tspTxtSearchCondition.Text = "";
                //清空上一次查找的结果,恢复初始值
                ClsTreeViewHelper.ClearLastSearchDataMethod();

                string currExcelFileNamePath = ClsReadExcel.getOpenFileDialogFileName();
                if (!"".Equals(currExcelFileNamePath))
                {
                    //1、判断是否导入的Excel文件是否被打开
                    bool isExcelOpen = ClsReadExcel.isExcelOpen(currExcelFileNamePath);
                    if (isExcelOpen == true)
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("数据导入失败，此Excel文件被打开，请先关闭再导入。");
                        return;
                    }
                    ListView currOptListView = this.uctrlBodyLayout1.lvwDataInfoTable;
                    DataTable currDataTable = null;
                    using (FileStream excelFileStream = File.OpenRead(currExcelFileNamePath))
                    {
                        string fileName = currExcelFileNamePath;
                        string sheetName = ClsConstant.EXCEL_FILE_NAME;
                        bool isFirstRowColumn = true;
                        currDataTable = ClsNpoiExcelHelper.ExcelToDataTable(fileName, sheetName, isFirstRowColumn);
                    }
                    if (currDataTable == null)
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("当前Excel文件数据读取失败，请重试。");
                        return;
                    }
                    //2、比较列名称判断是否是规定的模板文件
                    if (ClsNpoiExcelHelper.IsCorrectExcelTemplateMethod(currDataTable) == false)
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("数据导入失败，此Excel文件不是规定的模板。");
                        return;
                    }
                    //3、将从Excel文件读取到的数据添加到数据表格中
                    bool isExcelImportSuccessFlag = ClsListViewHelper.DataTable2Listview(currDataTable, currOptListView);
                    if (isExcelImportSuccessFlag)
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("当前Excel文件数据全部导入成功。");
                    }
                    else
                    {
                        ClsMessageBoxHelper.ShowInfoMsg("数据数据填充表格数据失败，请重试。");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMessageBoxHelper.ShowErrorMsg("数据导入失败！" + ex.ToString());
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 顶部导航菜单：Excel模板导出到本地电脑的逻辑代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelTemplateExportClickEventImpl(object sender, EventArgs e)
        {
            try
            {
                string filePath = ClsNpoiExcelHelper.GetSaveFilePathMethod("数据模板");
                if (filePath == null)
                {
                    return;
                }
                string sheetName = ClsConstant.EXCEL_FILE_NAME;
                ClsNpoiExcelHelper.ExportTemplateToExcel(sheetName, filePath);
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }

        #region 封装的帮助方法
        /// <summary>
        /// 顶部导航参数的验证方法
        /// </summary>
        /// <param name="currTxtAppSleepTime"></param>
        /// <param name="currTxtSNMPTimeoutTime"></param>
        /// <returns></returns>
        public bool RegexHeaderConfParamMethod(string currTxtAppSleepTime, string currTxtSNMPTimeoutTime, string currTetWorkThreadNum)
        {
            if (string.IsNullOrEmpty(currTxtAppSleepTime))
            {
                ClsMessageBoxHelper.ShowInfoMsg("缓冲时间不能为空。");
                return false;
            }
            if (string.IsNullOrEmpty(currTxtSNMPTimeoutTime))
            {
                ClsMessageBoxHelper.ShowInfoMsg("SNMP超时时间不能为空。");
                return false;
            }
            if (string.IsNullOrEmpty(currTetWorkThreadNum))
            {
                ClsMessageBoxHelper.ShowInfoMsg("线程数不能为空。");
                return false;
            }
            if (ClsRegexHelper.IsNumeric(currTxtAppSleepTime) == false)
            {
                ClsMessageBoxHelper.ShowInfoMsg("缓冲时间格式错误，只能是正整数类型。");
                return false;
            }
            if (ClsRegexHelper.IsNumeric(currTxtSNMPTimeoutTime) == false)
            {
                ClsMessageBoxHelper.ShowInfoMsg("SNMP超时时间格式错误，只能是正整数类型。");
                return false;
            }
            if (ClsRegexHelper.IsNumeric(currTetWorkThreadNum) == false)
            {
                ClsMessageBoxHelper.ShowInfoMsg("线程数格式错误，只能是正整数类型。");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 格式校验的统一调用方法
        /// </summary>
        /// <param name="currDataListView"></param>
        public bool ListViewContentFormatCheckOptMethod(ListView currDataListView, bool isBeginBtnOptFlag)
        {
            if (ClsListViewHelper.IsListViewDataItemsGtZero(currDataListView) == false)
            {
                ClsMessageBoxHelper.ShowInfoMsg("数据信息表没有数据，请添加数据后再操作。");
                return false;
            }
            if (ClsListViewHelper.ListViewContentFormatCheck(currDataListView) == false)
            {
                ClsMessageBoxHelper.ShowInfoMsg("格式校验未通过，错误行已经被标记红色，请先修改。");
                return false;
            }
            if (isBeginBtnOptFlag == false)
            {
                ClsMessageBoxHelper.ShowInfoMsg("格式校验成功，未发现错误格式。");
            }
            return true;
        }
        /// <summary>
        /// 信息表格中的数据导出到本地电脑Excel文件中的统一调用方法
        /// </summary>
        /// <param name="currOptListView"></param>
        public void ExportExcelCommonMethod(ListView currOptListView, bool isExportTemlateTitle)
        {
            SaveFileDialog saveFileDialog = ClsFileDialogHelper.GetSaveFileDialogOnExcel(ClsConstant.EXCEL_FILE_NAME);
            if (saveFileDialog == null)
            {
                return;
            }
            else
            {
                bool isLock = true;
                ClsExcelLockRange clsExcelLockRange = new ClsExcelLockRange(1, 1, 5, 5);
                List<ClsExcelLockRange> unLockRanges = new List<ClsExcelLockRange>();
                string passWord = "jqmkj";
                ClsWriteExcel.WriteExcel(saveFileDialog, ClsConstant.EXCEL_FILE_NAME, currOptListView, isLock, isExportTemlateTitle, unLockRanges, passWord);
            }
        }
        /// <summary>
        /// 结果信息表格中的数据导出到本地电脑Excel文件中的统一调用方法
        /// </summary>
        /// <param name="currOptListView"></param>
        public void ResultInfoExportExcelCommonMethod(ListView currOptListView)
        {
            if (ClsFrmResultPageDataDB.resultInfoDictionaryDataDB.Count == 0)
            {
                ClsMessageBoxHelper.ShowInfoMsg("当前结果信息没有数据，无法进行导出操作。");
                return;
            }
            SaveFileDialog saveFileDialog = ClsFileDialogHelper.GetSaveFileDialogOnExcel(ClsConstant.EXCEL_FILE_NAME);
            if (saveFileDialog == null)
            {
                return;
            }
            Func<bool> currResultExportTask = new Func<bool>(delegate ()
            {
                bool isResultExport = false;
                bool isLock = true;
                ClsExcelLockRange clsExcelLockRange = new ClsExcelLockRange(1, 1, 5, 5);
                List<ClsExcelLockRange> unLockRanges = new List<ClsExcelLockRange>();
                string passWord = "jqmkj";
                isResultExport = ClsWriteExcel.WriteExcel(saveFileDialog, ClsConstant.EXCEL_FILE_NAME, currOptListView, ClsFrmResultPageDataDB.resultInfoDictionaryDataDB, isLock, unLockRanges, passWord);
                //返回任务结果
                return isResultExport;
            });
            // 发起一次异步调用，实际上就是在.net线程池中执行当前Task任务
            // 这时由于是其它线程在工作，UI线程未被阻塞，所以窗体不会假死
            currResultExportTask.BeginInvoke(currTaskAsyncResult =>
            {
                //使用EndInvoke获取到任务结果
                bool isResultExportResult = currResultExportTask.EndInvoke(currTaskAsyncResult);
                if (isResultExportResult)
                {
                    //ClsMessageBoxHelper.ShowInfoMsg("结果导出操作执行成功。");
                }
            }, null);
        }
        #endregion

        /// <summary>
        /// 下拉框控件验证是否将输入的值临时保存到下拉框集合中。
        /// </summary>
        public void ToolStripAppSleepTimeTextChangeRegexMethod(ToolStripComboBox currOptTspcboxCtrl)
        {
            string currOptTspcboxCtrlText = currOptTspcboxCtrl.Text.Trim();
            if (string.IsNullOrEmpty(currOptTspcboxCtrlText))
            {
                ClsMessageBoxHelper.ShowInfoMsg("输入的值不能为空，只能是正整数类型。");
                currOptTspcboxCtrl.SelectedIndex = 0;
                return;
            }
            if (ClsRegexHelper.IsNumeric(currOptTspcboxCtrlText) ==false)
            {
                currOptTspcboxCtrl.SelectedIndex = 0;
                return;
            }
            if (currOptTspcboxCtrl.Items.Contains(currOptTspcboxCtrlText) == false)
            {
                currOptTspcboxCtrl.Items.Add(currOptTspcboxCtrlText);
            }
        }
        public void ToolStripSnmpTimeoutTimeTextChangeRegexMethod(ToolStripComboBox currOptTspcboxCtrl)
        {
            string currOptTspcboxCtrlText = currOptTspcboxCtrl.Text.Trim();
            if (string.IsNullOrEmpty(currOptTspcboxCtrlText))
            {
                ClsMessageBoxHelper.ShowInfoMsg("输入的值不能为空，只能是正整数类型。");
                currOptTspcboxCtrl.SelectedIndex = 0;
                return;
            }
            if (ClsRegexHelper.IsNumeric(currOptTspcboxCtrlText) == false)
            {
                currOptTspcboxCtrl.SelectedIndex = 0;
                return;
            }
            if (currOptTspcboxCtrl.Items.Contains(currOptTspcboxCtrlText) == false)
            {
                currOptTspcboxCtrl.Items.Add(currOptTspcboxCtrlText);
            }
        }
        public void ToolStripWorkThreadNumTextChangeRegexMethod(ToolStripComboBox currOptTspcboxCtrl)
        {
            string currOptTspcboxCtrlText = currOptTspcboxCtrl.Text.Trim();
            if (string.IsNullOrEmpty(currOptTspcboxCtrlText))
            {

                ClsMessageBoxHelper.ShowInfoMsg("输入的值不能为空，只能是正整数类型。");
                currOptTspcboxCtrl.SelectedIndex = 0;
                return;
            }
            if (ClsRegexHelper.IsNumeric(currOptTspcboxCtrlText) == false)
            {
                currOptTspcboxCtrl.SelectedIndex = 0;
                return;
            }
            if (currOptTspcboxCtrl.Items.Contains(currOptTspcboxCtrlText) == false)
            {
                currOptTspcboxCtrl.Items.Add(currOptTspcboxCtrlText);
            }
        }
        #endregion
    }
}
