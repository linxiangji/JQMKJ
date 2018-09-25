using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.Enum;
using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsListViewHelper
    {
        /// <summary>
        /// 为ListView绑定DataTable数据项
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="currListView">ListView控件</param>
        public static bool DataTable2Listview(DataTable dataTable, ListView currListView)
        {
            bool isSussessFlag = false;
            if (dataTable != null)
            {
                currListView.View = View.Details;
                currListView.GridLines = true;//显示网格线
                currListView.Items.Clear();//所有的row清空
                currListView.Columns.Clear();//标题
                currListView.BeginUpdate();//数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    currListView.Columns.Add(dataTable.Columns[i].ColumnName.ToString());//增加标题
                }
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    //这个是从第二列开始填充值
                    ListViewItem listViewItem = new ListViewItem();
                    //这个是从第一列开始填充值
                    //ListViewItem listViewItem = new ListViewItem(dataTable.Rows[i][0].ToString());
                    for (int j = 1; j < dataTable.Columns.Count; j++)
                    {
                        listViewItem.SubItems.Add(dataTable.Rows[i][j].ToString());
                    }
                    currListView.Items.Add(listViewItem);
                }
                currListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);//调整列的宽度
                currListView.EndUpdate();//结束数据处理，UI界面一次性绘制。
                isSussessFlag = true;
            }
            return isSussessFlag;
        }
        /// <summary>
        /// 将结果信息填充到结果信息ListView中进行展示
        /// </summary>
        /// <param name="currResultInfoList"></param>
        /// <param name="currListView"></param>
        public static void ListData2ListView(ClsResultInfoTableBo currResultInfoTableBo, ListView currListView)
        {
            currListView.Items.Clear();//所有的row清空
            currListView.BeginUpdate();//数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            if (currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR)
            {
                foreach (ClsOnuUniMacAddressEntryVo crrrOnuUniMacAddressEntryVo in currResultInfoTableBo.onuUniMacAddressEntryVoList)
                {
                    //这个是从第二列开始填充值
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.SubItems.Add(currResultInfoTableBo.oltInfoVo.ipAddress);
                    listViewItem.SubItems.Add(currResultInfoTableBo.onuInfoEntryVo.onuMacAddress);
                    listViewItem.SubItems.Add(crrrOnuUniMacAddressEntryVo.onuUniDeviceIndex);
                    listViewItem.SubItems.Add(crrrOnuUniMacAddressEntryVo.onuUniIndex);
                    listViewItem.SubItems.Add(crrrOnuUniMacAddressEntryVo.onuUniMacAddress);
                    listViewItem.SubItems.Add(crrrOnuUniMacAddressEntryVo.onuUniVid);
                    listViewItem.SubItems.Add(crrrOnuUniMacAddressEntryVo.onuUniStatic);
                    listViewItem.SubItems.Add(crrrOnuUniMacAddressEntryVo.onuUniMulticast);
                    EnumSnmpOptStatus currOptStatus = currResultInfoTableBo.optMsgInfoVo.optStatus;
                    if (currOptStatus == EnumSnmpOptStatus.NO_ERROR)
                    {
                        listViewItem.SubItems.Add("成功");
                        listViewItem.SubItems.Add("");
                    }
                    else if (currOptStatus == EnumSnmpOptStatus.NO_ERROR_BUT_NO_USER_DEV)
                    {
                        listViewItem.SubItems.Add("成功");
                        listViewItem.SubItems.Add(currResultInfoTableBo.optMsgInfoVo.optMsg );
                    }
                    else
                    {
                        listViewItem.SubItems.Add("失败");
                        listViewItem.SubItems.Add(currResultInfoTableBo.optMsgInfoVo.optMsg);
                    }
                    currListView.Items.Add(listViewItem);
                }
            }
            else
            {
                //这个是从第二列开始填充值
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.SubItems.Add(currResultInfoTableBo.oltInfoVo.ipAddress);
                listViewItem.SubItems.Add(currResultInfoTableBo.onuInfoEntryVo.onuMacAddress);
                listViewItem.SubItems.Add(currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniDeviceIndex);
                listViewItem.SubItems.Add(currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniIndex);
                listViewItem.SubItems.Add(currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMacAddress);
                listViewItem.SubItems.Add(currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniVid);
                listViewItem.SubItems.Add(currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniStatic);
                listViewItem.SubItems.Add(currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMulticast);
                EnumSnmpOptStatus currOptStatus = currResultInfoTableBo.optMsgInfoVo.optStatus;
                if (currOptStatus == EnumSnmpOptStatus.NO_ERROR)
                {
                    listViewItem.SubItems.Add("成功");
                    listViewItem.SubItems.Add("");
                }
                else if (currOptStatus == EnumSnmpOptStatus.NO_ERROR_BUT_NO_USER_DEV)
                {
                    listViewItem.SubItems.Add("成功");
                    listViewItem.SubItems.Add(currResultInfoTableBo.optMsgInfoVo.optMsg);
                }
                else
                {
                    listViewItem.SubItems.Add("失败");
                    listViewItem.SubItems.Add(currResultInfoTableBo.optMsgInfoVo.optMsg);
                }
                currListView.Items.Add(listViewItem);
            }
            currListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);//调整列的宽度
            currListView.EndUpdate();//结束数据处理，UI界面一次性绘制。
        }
        /// <summary>
        /// ListView反向填充DataTable数据项
        /// </summary>
        /// <param name="currListView">ListView控件</param>
        /// <param name="dataTable">DataTable</param>
        public static void ListViewToDataTable(DataTable dataTable, ListView currListView)
        {
            DataRow dr;
            dataTable.Clear();
            dataTable.Columns.Clear();
            for (int k = 0; k < currListView.Columns.Count; k++)
            {
                dataTable.Columns.Add(currListView.Columns[k].Text.Trim().ToString());//生成DataTable列头
            }
            for (int i = 0; i < currListView.Items.Count; i++)
            {
                dr = dataTable.NewRow();
                for (int j = 0; j < currListView.Columns.Count; j++)
                {
                    dr[j] = currListView.Items[i].SubItems[j].Text.Trim();
                }
                dataTable.Rows.Add(dr);//每行内容
            }
        }
        /// <summary>
        /// listview中内容格式的校验
        /// </summary>
        /// <param name="currListView"></param>
        public static bool ListViewContentFormatCheck(ListView currListView)
        {
            bool isSuccessFlag = true;
            int lvwCurrRow = 0;
            int lvwRows = currListView.Items.Count;
            for (lvwCurrRow = 0; lvwCurrRow < lvwRows; lvwCurrRow++)//遍历listView1的每一行
            {
                int lvwCurrCol = 0;
                int lvwCols = currListView.Columns.Count;
                for (lvwCurrCol = 1; lvwCurrCol < lvwCols; lvwCurrCol++)//每一行中的每一项
                {
                    string currRowColValue = currListView.Items[lvwCurrRow].SubItems[lvwCurrCol].Text.Trim();

                    if (string.IsNullOrEmpty(currRowColValue))
                    {
                        currListView.Items[lvwCurrRow].BackColor = Color.Red;
                        isSuccessFlag = false;
                        continue;
                    }
                    if (lvwCurrCol == 1)
                    {
                        if (ClsRegexHelper.IsIpAddress(currRowColValue) == false)
                        {
                            currListView.Items[lvwCurrRow].BackColor = Color.Red;
                            isSuccessFlag = false;
                            continue;
                        }
                    }
                    if (lvwCurrCol == 2)
                    {
                        if (ClsRegexHelper.IsMacAddress(currRowColValue) == false)
                        {
                            currListView.Items[lvwCurrRow].BackColor = Color.Red;
                            isSuccessFlag = false;
                            continue;
                        }
                    }
                    if (lvwCurrCol == 3 || lvwCurrCol == 4)
                    {
                        if (ClsRegexHelper.IsCommunity(currRowColValue) == false)
                        {
                            currListView.Items[lvwCurrRow].BackColor = Color.Red;
                            isSuccessFlag = false;
                            continue;
                        }
                    }
                }
            }
            return isSuccessFlag;
        }
     
        /// <summary>
        /// 全选或全不选
        /// </summary>
        /// <param name="currListView"></param>
        public static void ListViewCheckAll(ListView currListView)
        {
            foreach (ListViewItem item in currListView.Items)
            {
                if (item.Checked)
                {
                    item.Checked = false;
                }
                else
                {
                    item.Checked = true;
                }
            }
        }
        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="currListView"></param>
        /// <returns></returns>
        public static bool ListViewDelOneItems(ListView currListView)
        {
            if (currListView.CheckedItems.Count > 0)//判断currListView有被选中项
            {
                currListView.Items.Remove(currListView.CheckedItems[0]);
                //currListView.Items.RemoveAt(lv.CheckedItems[0].Index); //按索引移除，与上一条语句作用一样
                return true;
            }
            return false;
        }
        /// <summary>
        /// checkbox列选中后，多条记录删除
        /// </summary>
        /// <param name="currListView"></param>
        /// <returns></returns>
        public static bool ListViewDelCheckedItems(ListView currListView)
        {
            if (currListView.CheckedItems.Count > 0)
            {
                int n = currListView.CheckedItems.Count;
                ListView.CheckedListViewItemCollection CheckedItems = currListView.CheckedItems;
                for (int i = n; i >0; i--)
                {
                    CheckedItems[0].Remove();
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 指定行列后更新值
        /// </summary>
        /// <param name="currListView"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool ListViewUpdateOneItems(ListView currListView, int row, int col,string content)
        {
            if (row > 0 && col > 0 && row <= currListView.Items.Count && col <= currListView.Columns.Count)
            {
                currListView.Items[row - 1].SubItems[col - 1].Text = content;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 清除所有项，不包括标题栏
        /// </summary>
        /// <param name="currListView"></param>
        /// <returns></returns>
        public static bool ListViewDelAllItems(ListView currListView)
        {
            currListView.Items.Clear();   //清除所有项，不包括标题栏
            //currListView.Clear();       //清除标题栏及所有项
            return true;
        }
        /// <summary>
        /// 增加一行记录值
        /// </summary>
        /// <param name="currListView"></param>
        /// <param name="oltInfoVo"></param>
        /// <param name="onuInfoEntryVo"></param>
        /// <returns></returns>
        public static bool ListViewDataAddOneItems(ListView currListView, ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            if (oltInfoVo!=null&& onuInfoEntryVo!=null)
            {
                ListViewItem currNewItem = new ListViewItem();
                currNewItem.SubItems.Add(oltInfoVo.ipAddress);//第二列
                currNewItem.SubItems.Add(onuInfoEntryVo.onuMacAddress);//第三列
                currNewItem.SubItems.Add(oltInfoVo.readCommunity);//第四列
                currNewItem.SubItems.Add(oltInfoVo.writeCommunity);//第五列
                currListView.Items.Add(currNewItem);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 编辑一条记录的值
        /// </summary>
        /// <param name="currListView"></param>
        /// <param name="oltInfoVo"></param>
        /// <param name="onuInfoEntryVo"></param>
        /// <returns></returns>
        public static bool ListViewDataUpdateOneItems(ListView currListView, ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            if (currListView.CheckedItems.Count > 0)
            {
                if (oltInfoVo != null && onuInfoEntryVo != null)
                {
                    currListView.CheckedItems[0].SubItems[1].Text = oltInfoVo.ipAddress;
                    currListView.CheckedItems[0].SubItems[2].Text = onuInfoEntryVo.onuMacAddress;
                    currListView.CheckedItems[0].SubItems[3].Text = oltInfoVo.readCommunity;
                    currListView.CheckedItems[0].SubItems[4].Text = oltInfoVo.writeCommunity;
                    currListView.CheckedItems[0].BackColor = Color.White;
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 判断Checkbox选中的数量是否等于1
        /// </summary>
        /// <param name="currListView"></param>
        /// <returns></returns>
        public static bool IsListViewDataCheckedItemsEqOne(ListView currListView)
        {
            return currListView.CheckedItems.Count == 1;
        }
        /// <summary>
        /// 判断Checkbox选中的数量是否大于0
        /// </summary>
        /// <param name="currListView"></param>
        /// <returns></returns>
        public static bool IsListViewDataCheckedItemsGtZero(ListView currListView)
        {
            return currListView.CheckedItems.Count >0;
        }
        /// <summary>
        /// 判断Checkbox选中的数量是否大于0
        /// </summary>
        /// <param name="currListView"></param>
        /// <returns></returns>
        public static bool IsListViewDataItemsGtZero(ListView currListView)
        {
            return currListView.Items.Count > 0;
        }
        /// <summary>
        /// 获取一行记录值并赋值到对象里
        /// </summary>
        /// <param name="currListView"></param>
        /// <param name="oltInfoVo"></param>
        /// <param name="onuInfoEntryVo"></param>
        /// <returns></returns>
        public static bool ListViewDataGetOneItems(ListView currListView, ClsOltInfoVo oltInfoVo, ClsOnuInfoEntryVo onuInfoEntryVo)
        {
            if (currListView.CheckedItems.Count > 0)
            {
                if (oltInfoVo != null && onuInfoEntryVo != null)
                {
                    oltInfoVo.ipAddress = currListView.CheckedItems[0].SubItems[1].Text.ToString();
                    onuInfoEntryVo.onuMacAddress = currListView.CheckedItems[0].SubItems[2].Text.ToString();
                    oltInfoVo.readCommunity = currListView.CheckedItems[0].SubItems[3].Text.ToString();
                    oltInfoVo.writeCommunity = currListView.CheckedItems[0].SubItems[4].Text.ToString();
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// ListView控件中的数据添加到Dictionary<string, List<ClsOnuInfoEntryVo>>，便于后续遍历树节点
        /// </summary>
        /// <param name="currListView"></param>
        /// <param name="currTreeView"></param>
        /// <returns></returns>
        public static Dictionary<string, List<ClsResultInfoTableBo>> ListViewData2Dictionary(ListView currListView, ClsHeaderConfParamVo currHeaderConfParamVo,ref int oltCommonMacNum)
        {
            Dictionary<string, List<ClsResultInfoTableBo>> currOptDataDictionary = new Dictionary<string, List<ClsResultInfoTableBo>>();
            
            int rowCount = currListView.Items.Count;
            int colCount= currListView.Columns.Count;
            for (int row = 0; row < rowCount; row++)
            {
                string oltIpAddressKey = currListView.Items[row].SubItems[1].Text.Trim();
                string currOnuMacAddress = currListView.Items[row].SubItems[2].Text.Trim();
                string currReadCommunity = currListView.Items[row].SubItems[3].Text.Trim();
                string currWriteCommunity = currListView.Items[row].SubItems[4].Text.Trim();
                if (string.IsNullOrEmpty(oltIpAddressKey)|| string.IsNullOrEmpty(currOnuMacAddress))
                {
                    continue;
                }
                string currPingTimeoutTime = ClsConfigHelper.readCofigValueByKey("PingTimeoutTime");
                string currSnmpPortNum = ClsConfigHelper.readCofigValueByKey("SnmpPortNum");
                string currSnmpReqRetryConnection = ClsConfigHelper.readCofigValueByKey("SnmpReqRetryConnection");
                string currOltIpAddMacDictionaryKey = oltIpAddressKey + "+" + currOnuMacAddress;

                ClsResultInfoTableBo currResultInfoTableBo = new ClsResultInfoTableBo()
                {
                    oltInfoVo = new ClsOltInfoVo()
                    {
                        ipAddress = oltIpAddressKey,
                        readCommunity = currReadCommunity,
                        writeCommunity = currWriteCommunity
                    },
                    onuInfoEntryVo = new ClsOnuInfoEntryVo()
                    {
                        onuMacAddress = currOnuMacAddress
                    },
                    onuUniMacAddressEntryVo = new ClsOnuUniMacAddressEntryVo(),
                    snmpPduInfoVo = new ClsSnmpPduInfoVo()
                    {
                        readCommunity = currReadCommunity,
                        writeCommunity = currWriteCommunity,
                        ipAddress = oltIpAddressKey,
                        port = Convert.ToInt32(currSnmpPortNum),
                        onuDevIndexOid = ClsSnmpOptHelper.GetOnuMacAddressSubTreeOID,
                        setOnuDevIndexOid = ClsSnmpOptHelper.SetOnuDevIndexOID,
                        //用户表侧信息所需字段OID
                        onuUniDeviceIndexOid = ClsSnmpOptHelper.GetOnuUniDeviceIndexOid,
                        onuUniIndexOid = ClsSnmpOptHelper.GetOnuUniIndexOid,
                        onuUniMacAddressOid = ClsSnmpOptHelper.GetOnuUniMacAddressOid,
                        onuUniVidOid= ClsSnmpOptHelper.GetOnuUniVidOid,
                        onuUniStaticOid= ClsSnmpOptHelper.GetOnuUniStaticOid,
                        onuUniMulticastOid= ClsSnmpOptHelper.GetOnuUniMulticastOid,

                        timeOut = currHeaderConfParamVo.snmpTimeOutTime*1000,
                        snmpReTry = Convert.ToInt32(currSnmpReqRetryConnection)
                    },
                    optMsgInfoVo = new ClsOptMsgInfoVo(),
                    currHeaderConfParamVo = new ClsHeaderConfParamVo() {
                        appSleepTime = currHeaderConfParamVo.appSleepTime,
                        pingTimeOutTime = Convert.ToInt32(currPingTimeoutTime),
                        workThreadNum = currHeaderConfParamVo.workThreadNum
                    },
                    onuUniMacAddressEntryVoList = new List<ClsOnuUniMacAddressEntryVo>()
                };
                if (currOptDataDictionary.ContainsKey(oltIpAddressKey))
                {
                    List<ClsResultInfoTableBo> currResultInfoTableBoValueList = currOptDataDictionary[oltIpAddressKey];
                    //去除同一个OLT相同的MacAddress地址，每个mac地址都是唯一的
                    ClsResultInfoTableBo currFindResultInfoTableBo = currResultInfoTableBoValueList.Find(
                          delegate (ClsResultInfoTableBo nowResultInfoTableBo)
                          {
                              return currOnuMacAddress.Equals(nowResultInfoTableBo.onuInfoEntryVo.onuMacAddress);
                          }
                     );
                    if (currFindResultInfoTableBo == null)
                    {
                        currResultInfoTableBoValueList.Add(currResultInfoTableBo);
                    }
                    else
                    {
                        oltCommonMacNum ++;
                    }
                }
                else
                {
                    List<ClsResultInfoTableBo> newResultInfoTableBoList = new List<ClsResultInfoTableBo>();
                    newResultInfoTableBoList.Add(currResultInfoTableBo);
                    currOptDataDictionary.Add(oltIpAddressKey, newResultInfoTableBoList);
                }
            }
            return currOptDataDictionary;
        }
    }
}
