using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using I18NHelper.Base;
using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.Enum;
using OnuDevInfoOnUserModel.VoClass;
using System.Collections.Concurrent;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    /// <summary>
    /// 此版本要使用2007以上的版本Excel
    /// </summary>
    public class ClsWriteExcel
    {
        private static log4net.ILog m_log = log4net.LogManager.GetLogger("ClsWriteExcel");
        private static SaveFileDialog m_saveFileDialog = null;

        public class ClsExcelLockRange
        {
            public int BeginX = -1;//小于1 则使用1
            public int BeginY = -1;//小于1 则使用1
            public int EndX = -1;//小于1 则使用sheet.Rows.Count
            public int EndY = -1;//小于1 则使用sheet.Columns.Count
            public ClsExcelLockRange(int beginX, int beginY, int endX, int endY)
            {
                BeginX = beginX;
                BeginY = beginY;
                EndX = endX;
                EndY = endY;
            }
        }

        /// <summary>
        /// 生成excel
        /// </summary>
        /// <param name="saveFileDialog">过滤格式需为saveFileDialog1.Filter = "导成 Excel2003(*.xls)|*.xls|导成Excel2007(*.xlsx)|*.xlsx";需要参数FileName，FilterIndex</param>
        /// <param name="lsvInfo">数据源</param>
        /// <returns></returns>
        public static bool WriteExcel(SaveFileDialog saveFileDialog, ListView lsvInfo,bool isExportTemlateTitle)
        {
            return WriteExcel(saveFileDialog, "test", lsvInfo, false, isExportTemlateTitle, null, null);
        }
        public static bool WriteExcel(SaveFileDialog saveFileDialog, ListView lsvInfo, bool isLock,bool isExportTemlateTitle, List<ClsExcelLockRange> unLockRanges, string passWord)
        {
            return WriteExcel(saveFileDialog, "test", lsvInfo, isLock, isExportTemlateTitle, unLockRanges, passWord);
        }
        /// <summary>
        /// 生成excel
        /// </summary>
        /// <param name="saveFileDialog">过滤格式需为saveFileDialog1.Filter = "导成 Excel2003(*.xls)|*.xls|导成Excel2007(*.xlsx)|*.xlsx";需要参数FileName，FilterIndex</param>
        /// <param name="lsvInfo">数据源</param>
        /// <param name="isLock">是否对表加锁</param>
        /// <param name="isExportTemlateTitle">是否导的是模板，不导出数据</param>
        /// <param name="unLockRanges">对表中cell 部分cell不加锁的坐标,isLock==false该值不起作用，该值为空 全表加锁</param>
        /// <param name="passWord">为null 则用默认密码yourPassword</param>
        /// <returns></returns>
        public static bool WriteExcel(SaveFileDialog saveFileDialog,string sheetName, ListView lsvInfo, bool isLock,bool isExportTemlateTitle, List<ClsExcelLockRange> unLockRanges, string passWord)
        {
            m_saveFileDialog = saveFileDialog;
            bool flag = false;
            try
            {
                if (m_saveFileDialog.FileName.Length != 0)
                {
                    System.Reflection.Missing miss = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Application.Workbooks.Add(true);
                    excel.Visible = false;
                    if (excel == null)
                    {
                        MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("无法启动Excel"), ClsI18NMng.GetI18NMng().ChangeLanguage("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return flag;
                    }
                    if (excel.Version == "11.0")
                    {
                        //saveFileDialog1.Filter = "导成 Excel2003(*.xls)|*.xls|导成Excel2007(*.xlsx)|*.xlsx";
                        if (m_saveFileDialog.FilterIndex == 2)
                        {
                            MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("office版本太低不支持您选择的文件格式！"), ClsI18NMng.GetI18NMng().ChangeLanguage("提示"));
                            excel.Quit();
                            return flag;
                        }
                    }
                    Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)books.Add(miss);
                    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                    //Microsoft.Office.Interop.Excel.Range range = null;

                    sheet.Name = sheetName;

                    for (int i = 0; i < lsvInfo.Columns.Count; i++)
                    {
                        excel.Cells[1, i + 1] = lsvInfo.Columns[i].Text.ToString();
                    }
                    int rowCount = lsvInfo.Items.Count;
                    int colCount = lsvInfo.Columns.Count;
                    if (rowCount > 0 && !isExportTemlateTitle)
                    {
                        object[,] dataArray = new object[rowCount, colCount];
                        for (int i = 0; i < rowCount; i++)
                        {
                            if (lsvInfo.Items[i]!=null)
                            {
                                for (int j = 0; j < colCount; j++)
                                {
                                    if (lsvInfo.Items[i].SubItems[j] != null)
                                    {
                                        dataArray[i, j] = lsvInfo.Items[i].SubItems[j].Text;
                                    }
                                }
                            }
                        }
                        sheet.Range[sheet.Cells[2, 1], sheet.Cells[rowCount + 1, colCount]].Value = dataArray;
                    }
                    #region 效率低 注释
                    //for (int i = 0; i < lsvInfo.Items.Count; i++)
                    //{
                    //    for (int j = 0; j < lsvInfo.Columns.Count; j++)
                    //    {
                    //        lsvInfo.Items[i].SubItems[j].GetType();
                    //        if (lsvInfo.Items[i].SubItems[j].Text != null)
                    //        {
                    //            excel.Cells[i + 2, j + 1] = lsvInfo.Items[i].SubItems[j].Text;
                    //        }
                    //    }
                    //}
                    #endregion

                    excel.Cells.EntireColumn.AutoFit();

                    if (isLock == true)
                    {
                        //excel 默认 全表锁，即每个cell.locked 都等于true,sheet.Protect执行时locked=true的cell被锁。
                        if (unLockRanges != null && unLockRanges.Count() > 0)
                        {
                            foreach (ClsExcelLockRange range in unLockRanges)
                            {
                                sheet.Range[sheet.Cells[range.BeginX < 1 ? 1 : range.BeginX, range.BeginY < 1 ? 1 : range.BeginY],
                                    sheet.Cells[range.EndX < 1 ? sheet.Rows.Count : range.EndX, range.EndY < 1 ? sheet.Columns.Count : range.EndY]].Locked = false;
                            }
                            sheet.Protect(!string.IsNullOrEmpty(passWord) ? passWord : "yourPassword", Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, true, true, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, true, Type.Missing);
                        }
                    }

                    if (excel.Version == "12.0")
                    {
                        if (m_saveFileDialog.FilterIndex == 1)
                        {
                            if (isLock == false)
                                book.SaveAs(m_saveFileDialog.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            else
                                book.SaveAs(m_saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        else
                        {
                            book.SaveAs(m_saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                    }
                    else
                    {
                        book.SaveAs(m_saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
                    book.Close(false, miss, miss);
                    books.Close();
                    excel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    GC.Collect();

                    flag = true;
                    if (MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("成功导出,是否直接打开？"), ClsI18NMng.GetI18NMng().ChangeLanguage("询问"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(m_saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("导出出错，请查看日志"), ClsI18NMng.GetI18NMng().ChangeLanguage("提示"));
                m_log.Error(ex.ToString());
            }
            return flag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheetValueMap">key =sheetName(string),value= Info（ListView）</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool WriteExcel(string fileName, Hashtable sheetValueMap, out string msg)
        {
            bool flag = false;
            msg = "";
            if (sheetValueMap != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(fileName))
                    {


                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        excel.Application.Workbooks.Add(true);
                        excel.Visible = false;
                        if (excel == null)
                        {
                            msg = ClsI18NMng.GetI18NMng().ChangeLanguage("无法启动Excel");
                            return flag;
                        }
                        System.Reflection.Missing miss = System.Reflection.Missing.Value;
                        Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                        Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)books.Add(miss);
                        //Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                        int sheetIndex = 0;

                        foreach (DictionaryEntry de in sheetValueMap)
                        {
                            if (de.Value == null)
                                continue;
                            string sheetName = de.Key.ToString();
                            ListView lsvInfo = (ListView)de.Value;
                            Microsoft.Office.Interop.Excel.Worksheet wSheet = book.Worksheets[sheetIndex] as Microsoft.Office.Interop.Excel.Worksheet;

                            //sheet.Name = sheetName;
                            wSheet.Name = sheetName;

                            for (int i = 0; i < lsvInfo.Columns.Count; i++)
                            {
                                //excel.Cells[1, i + 1] = lsvInfo.Columns[i].Text.ToString();
                                wSheet.Cells[1, i + 1] = lsvInfo.Columns[i].Text.ToString();
                            }
                            #region 效率较高 未测试 暂注释（河北 相关功能会调用）
                            //int rowCount = lsvInfo.Items.Count;
                            //int colCount = lsvInfo.Columns.Count;
                            //object[,] dataArray = new object[rowCount, colCount];
                            //for (int i = 0; i < rowCount; i++)
                            //{
                            //    for (int j = 0; j < colCount; j++)
                            //    {
                            //        dataArray[i , j] = lsvInfo.Items[i].SubItems[j].Text;
                            //    }
                            //}
                            //wSheet.Range[wSheet.Cells[2, 1], wSheet.Cells[rowCount + 1, colCount]].Value = dataArray;
                            #endregion
                            #region 效率低
                            for (int i = 0; i < lsvInfo.Items.Count; i++)
                            {
                                for (int j = 0; j < lsvInfo.Columns.Count; j++)
                                {
                                    lsvInfo.Items[i].SubItems[j].GetType();
                                    if (lsvInfo.Items[i].SubItems[j].Text != null)
                                    {
                                        //excel.Cells[i + 2, j + 1] = lsvInfo.Items[i].SubItems[j].Text;
                                        wSheet.Cells[i + 2, j + 1] = lsvInfo.Items[i].SubItems[j].Text;
                                    }
                                }
                            }
                            #endregion
                            sheetIndex++;
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(wSheet);
                        }

                        //excel.Cells.EntireColumn.AutoFit();

                        if (excel.Version == "12.0")
                        {
                            book.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        else
                        {
                            book.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        book.Close(false, miss, miss);
                        books.Close();
                        excel.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                        flag = true;
                    }
                    else
                    {
                        m_log.Debug("WriteExcel: FileName is null");
                    }
                }
                catch (Exception ex)
                {
                    msg = ClsI18NMng.GetI18NMng().ChangeLanguage("请确定您的电脑是否安装office软件");
                    m_log.Error(ex.ToString());
                }
            }

            return flag;
        }

        /// <summary>
        /// 所有结果信息（成功与失败信息）生成excel到本地电脑
        /// </summary>
        /// <param name="saveFileDialog">过滤格式需为saveFileDialog1.Filter = "导成 Excel2003(*.xls)|*.xls|导成Excel2007(*.xlsx)|*.xlsx";需要参数FileName，FilterIndex</param>
        /// <param name="lsvInfo">数据源</param>
        /// <param name="isLock">是否对表加锁</param>
        /// <param name="unLockRanges">对表中cell 部分cell不加锁的坐标,isLock==false该值不起作用，该值为空 全表加锁</param>
        /// <param name="passWord">为null 则用默认密码yourPassword</param>
        /// <returns></returns>
        public static bool WriteExcel(SaveFileDialog saveFileDialog, string sheetName, ListView lsvInfo, ConcurrentDictionary<string, ClsResultInfoTableBo> resultInfoDictionary, bool isLock,List<ClsExcelLockRange> unLockRanges, string passWord)
        {
            m_saveFileDialog = saveFileDialog;
            bool flag = false;
            try
            {
                if (m_saveFileDialog.FileName.Length != 0)
                {
                    System.Reflection.Missing miss = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Application.Workbooks.Add(true);
                    excel.Visible = false;
                    if (excel == null)
                    {
                        MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("无法启动Excel"), ClsI18NMng.GetI18NMng().ChangeLanguage("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return flag;
                    }
                    if (excel.Version == "11.0")
                    {
                        //saveFileDialog1.Filter = "导成 Excel2003(*.xls)|*.xls|导成Excel2007(*.xlsx)|*.xlsx";
                        if (m_saveFileDialog.FilterIndex == 2)
                        {
                            MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("office版本太低不支持您选择的文件格式！"), ClsI18NMng.GetI18NMng().ChangeLanguage("提示"));
                            excel.Quit();
                            return flag;
                        }
                    }
                    Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)books.Add(miss);
                    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                    //Microsoft.Office.Interop.Excel.Range range = null;

                    sheet.Name = sheetName;

                    for (int i = 0; i < lsvInfo.Columns.Count; i++)
                    {
                        excel.Cells[1, i + 1] = lsvInfo.Columns[i].Text.ToString();
                    }
                    int rowCount = 2;
                    int resultInfoDictionaryCount = resultInfoDictionary.Count;
                    if (resultInfoDictionaryCount > 0 )
                    {
                        foreach (KeyValuePair<string, ClsResultInfoTableBo> resultInfoObj in resultInfoDictionary)
                        {
                            ClsResultInfoTableBo currResultInfoTableBo = resultInfoObj.Value;
                            if (currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR)
                            {
                                foreach (ClsOnuUniMacAddressEntryVo currOnuUniMacAddressEntryVo in currResultInfoTableBo.onuUniMacAddressEntryVoList)
                                {
                                    excel.Cells[rowCount, 1] = rowCount - 1;
                                    excel.Cells[rowCount, 2] = currResultInfoTableBo.oltInfoVo.ipAddress;
                                    excel.Cells[rowCount, 3] = currResultInfoTableBo.onuInfoEntryVo.onuMacAddress;
                                    excel.Cells[rowCount, 4] = currOnuUniMacAddressEntryVo.onuUniDeviceIndex;
                                    excel.Cells[rowCount, 5] = currOnuUniMacAddressEntryVo.onuUniIndex;
                                    excel.Cells[rowCount, 6] = currOnuUniMacAddressEntryVo.onuUniMacAddress;
                                    excel.Cells[rowCount, 7] = currOnuUniMacAddressEntryVo.onuUniVid;
                                    excel.Cells[rowCount, 8] = currOnuUniMacAddressEntryVo.onuUniStatic;
                                    excel.Cells[rowCount, 9] = currOnuUniMacAddressEntryVo.onuUniMulticast;
                                    excel.Cells[rowCount, 10] = currResultInfoTableBo.optMsgInfoVo.optMsg;
                                    excel.Cells[rowCount, 11] = "";
                                    rowCount++;
                                }
                            }
                            else
                            {
                                excel.Cells[rowCount, 1] = rowCount - 1;
                                excel.Cells[rowCount, 2] = currResultInfoTableBo.oltInfoVo.ipAddress;
                                excel.Cells[rowCount, 3] = currResultInfoTableBo.onuInfoEntryVo.onuMacAddress;
                                excel.Cells[rowCount, 4] = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniDeviceIndex;
                                excel.Cells[rowCount, 5] = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniIndex;
                                excel.Cells[rowCount, 6] = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMacAddress;
                                excel.Cells[rowCount, 7] = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniVid;
                                excel.Cells[rowCount, 8] = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniStatic;
                                excel.Cells[rowCount, 9] = currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMulticast;
                                excel.Cells[rowCount, 10] = currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR || currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR_BUT_NO_USER_DEV ? "成功" : "失败";
                                excel.Cells[rowCount, 11] = currResultInfoTableBo.optMsgInfoVo.optMsg;
                                rowCount++;
                            }
                        }
                    }
                    #region 效率低 注释
                    //for (int i = 0; i < lsvInfo.Items.Count; i++)
                    //{
                    //    for (int j = 0; j < lsvInfo.Columns.Count; j++)
                    //    {
                    //        lsvInfo.Items[i].SubItems[j].GetType();
                    //        if (lsvInfo.Items[i].SubItems[j].Text != null)
                    //        {
                    //            excel.Cells[i + 2, j + 1] = lsvInfo.Items[i].SubItems[j].Text;
                    //        }
                    //    }
                    //}
                    #endregion

                    excel.Cells.EntireColumn.AutoFit();

                    if (isLock == true)
                    {
                        //excel 默认 全表锁，即每个cell.locked 都等于true,sheet.Protect执行时locked=true的cell被锁。
                        if (unLockRanges != null && unLockRanges.Count() > 0)
                        {
                            foreach (ClsExcelLockRange range in unLockRanges)
                            {
                                sheet.Range[sheet.Cells[range.BeginX < 1 ? 1 : range.BeginX, range.BeginY < 1 ? 1 : range.BeginY],
                                    sheet.Cells[range.EndX < 1 ? sheet.Rows.Count : range.EndX, range.EndY < 1 ? sheet.Columns.Count : range.EndY]].Locked = false;
                            }
                            sheet.Protect(!string.IsNullOrEmpty(passWord) ? passWord : "yourPassword", Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, true, true, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, true, Type.Missing);
                        }
                    }

                    if (excel.Version == "12.0")
                    {
                        if (m_saveFileDialog.FilterIndex == 1)
                        {
                            if (isLock == false)
                                book.SaveAs(m_saveFileDialog.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            else
                                book.SaveAs(m_saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        else
                        {
                            book.SaveAs(m_saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                    }
                    else
                    {
                        book.SaveAs(m_saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
                    book.Close(false, miss, miss);
                    books.Close();
                    excel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    GC.Collect();

                    flag = true;
                    if (MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("成功导出,是否直接打开？"), ClsI18NMng.GetI18NMng().ChangeLanguage("询问"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(m_saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("导出出错，请查看日志"), ClsI18NMng.GetI18NMng().ChangeLanguage("提示"));
                m_log.Error(ex.ToString());
            }
            return flag;
        }

    }
}