using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using I18NHelper.Base;
using OnuDevInfoOnUserModel.BoClass;
using OnuDevInfoOnUserModel.Enum;
using OnuDevInfoOnUserModel.VoClass;
using System.Collections.Concurrent;

namespace OnuDevInfoOnUserCommon.HelpTools.Common.NpoiExcel
{
    /// <summary>
    ///  此类方法只能操作使用2003的版本Excel
    /// </summary>
    public class ClsNpoiExcelHelper : IDisposable
    {
        #region 私有方法

        /// <summary>
        /// 获取要保存的文件名称（含完整路径）
        /// </summary>
        /// <returns></returns>
        public static string GetSaveFilePathMethod(string saveFileName)
        {
            SaveFileDialog saveFileDig = new SaveFileDialog();
            saveFileDig.Filter = "Excel Office97-2003(*.xls)|*.xls";
            //saveFileDig.Filter = "Excel Office97-2003(*.xls)|*.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            saveFileDig.FileName = saveFileName + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDig.FilterIndex = 0;
            saveFileDig.Title = "导出到";
            saveFileDig.OverwritePrompt = true;
            string filePath = null;
            if (saveFileDig.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDig.FileName;
            }

            return filePath;
        }

        /// <summary>
        /// 获取要保存的文件名称（含完整路径）
        /// </summary>
        /// <returns></returns>
        public static string GetSaveFilePath()
        {
            SaveFileDialog saveFileDig = new SaveFileDialog();
            saveFileDig.Filter = "Excel Office97-2003(*.xls)|*.xls";
            //saveFileDig.Filter = "Excel Office97-2003(*.xls)|*.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            saveFileDig.FileName =  "数据"+ DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDig.FilterIndex = 0;
            saveFileDig.Title = "导出到";
            saveFileDig.OverwritePrompt = true;
            string filePath = null;
            if (saveFileDig.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDig.FileName;
            }

            return filePath;
        }

        /// <summary>
        /// 获取要打开要导入的文件名称（含完整路径）
        /// </summary>
        /// <returns></returns>
        public static string GetOpenFilePath()
        {
            OpenFileDialog openFileDig = new OpenFileDialog();
            openFileDig.Filter = "Excel Office97-2003(*.xls)|*.xls";
            //openFileDig.Filter = "Excel Office97-2003(*.xls)|*.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            openFileDig.FilterIndex = 0;
            openFileDig.Title = "打开";
            openFileDig.CheckFileExists = true;
            openFileDig.CheckPathExists = true;
            string filePath = null;
            if (openFileDig.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDig.FileName;
            }
            return filePath;
        }

        /// <summary>
        /// 判断是否为兼容模式
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static bool GetIsCompatible(string filePath)
        {
            return filePath.EndsWith(".xls", StringComparison.OrdinalIgnoreCase);
        }



        /// <summary>
        /// 创建工作薄
        /// </summary>
        /// <param name="isCompatible"></param>
        /// <returns></returns>
        private static IWorkbook CreateWorkbook(bool isCompatible)
        {
            if (isCompatible)
            {
                return new HSSFWorkbook();
            }
            else
            {
                return new XSSFWorkbook();
            }
        }

        /// <summary>
        /// 创建工作薄(依据文件流)
        /// </summary>
        /// <param name="isCompatible"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static IWorkbook CreateWorkbook(bool isCompatible, dynamic stream)
        {
            if (isCompatible)
            {
                return new HSSFWorkbook(stream);
            }
            else
            {
                return new XSSFWorkbook(stream);
            }
        }

        /// <summary>
        /// 创建表格头单元格
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static ICellStyle GetCellStyle(IWorkbook workbook)
        {
            ICellStyle style = workbook.CreateCellStyle();
            style.FillPattern = FillPattern.SolidForeground;
            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;

            return style;
        }


        /// <summary>
        /// 从工作表中生成DataTable
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="headerRowIndex"></param>
        /// <returns></returns>
        private static System.Data.DataTable GetDataTableFromSheet(ISheet sheet, int headerRowIndex)
        {
            System.Data.DataTable table = new System.Data.DataTable();

            IRow headerRow = sheet.GetRow(headerRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
              
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (int i = (headerRowIndex + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                //如果遇到某行的第一个单元格的值为空，则不再继续向下读取
                if (row != null && !string.IsNullOrEmpty(row.GetCell(0).ToString()))
                {
                    DataRow dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        dataRow[j] = row.GetCell(j).ToString();
                    }

                    table.Rows.Add(dataRow);
                }
            }

            return table;
        }

        #endregion

        #region 公共导出方法
        //导出模板
        public static void ExportTemplateToExcel(string sheetName,string filePath)
        {
            IWorkbook excel = new HSSFWorkbook();//创建.xls文件
            ISheet sheet = excel.CreateSheet(sheetName); //创建sheet
            IRow row = sheet.CreateRow(0);//创建行对象，填充表头
            for (int i=0;i<5;i++)
            {
                row.CreateCell(0).SetCellValue("选择");
                row.CreateCell(1).SetCellValue("OLT-Ip地址");
                row.CreateCell(2).SetCellValue("ONU-Mac地址");
                row.CreateCell(3).SetCellValue("读共同体");
                row.CreateCell(4).SetCellValue("写共同体");
            }
            //设置列宽
            int columnWidth = 20;
            sheet.SetColumnWidth(0, 10 * 256);
            sheet.SetColumnWidth(1, columnWidth * 256);
            sheet.SetColumnWidth(2, columnWidth * 256);
            sheet.SetColumnWidth(3, columnWidth * 256);
            sheet.SetColumnWidth(4, columnWidth * 256);
            //写入文件
            //string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\ONU设备用户侧信息Excel" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            FileStream xlsfile = new FileStream(filePath, FileMode.Create);
            excel.Write(xlsfile);
            xlsfile.Close();

            if (MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("成功导出,是否直接打开？"), ClsI18NMng.GetI18NMng().ChangeLanguage("询问"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }
        /// <summary>
        /// 由DataSet导出Excel
        /// </summary>
        /// <param name="sourceTable">要导出数据的DataTable</param>
        /// <returns>Excel工作表</returns>
        public static string ExportToExcel(DataSet sourceDs, string filePath = null)
        {

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = GetSaveFilePath();
            }

            if (string.IsNullOrEmpty(filePath)) return null;

            bool isCompatible = GetIsCompatible(filePath);

            IWorkbook workbook = CreateWorkbook(isCompatible);
            ICellStyle cellStyle = GetCellStyle(workbook);

            for (int i = 0; i < sourceDs.Tables.Count; i++)
            {
                System.Data.DataTable table = sourceDs.Tables[i];
                string sheetName = "result" + i.ToString();
                ISheet sheet = workbook.CreateSheet(sheetName);
                IRow headerRow = sheet.CreateRow(0);
                // handling header.
                foreach (DataColumn column in table.Columns)
                {
                    ICell cell = headerRow.CreateCell(column.Ordinal);
                    cell.SetCellValue(column.ColumnName);
                    cell.CellStyle = cellStyle;
                }

                // handling value.
                int rowIndex = 1;

                foreach (DataRow row in table.Rows)
                {
                    IRow dataRow = sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in table.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((row[column] ?? "").ToString());
                    }

                    rowIndex++;
                }
            }

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();
            workbook = null;

            return filePath;

        }


        /// <summary>
        /// 由DataTable导出Excel
        /// </summary>
        /// <param name="sourceTable">要导出数据的DataTable</param>
        /// <returns>Excel工作表</returns>
        public static string ExportToExcel(System.Data.DataTable sourceTable, string sheetName = "result", string filePath = null)
        {
            if (sourceTable.Rows.Count <= 0) return null;

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = GetSaveFilePath();
            }

            if (string.IsNullOrEmpty(filePath)) return null;

            bool isCompatible = GetIsCompatible(filePath);

            IWorkbook workbook = CreateWorkbook(isCompatible);
            ICellStyle cellStyle = GetCellStyle(workbook);

            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow headerRow = sheet.CreateRow(0);
            // handling header.
            foreach (DataColumn column in sourceTable.Columns)
            {
                ICell headerCell = headerRow.CreateCell(column.Ordinal);
                headerCell.SetCellValue(column.ColumnName);
                headerCell.CellStyle = cellStyle;
            }

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in sourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue((row[column] ?? "").ToString());
                }

                rowIndex++;
            }
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            return filePath;
        }

        /// <summary>
        /// 由List导出Excel
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="data">在导出的List</param>
        /// <param name="sheetName">sheet名称</param>
        /// <returns></returns>
        public static string ExportToExcel<T>(List<T> data, IList<KeyValuePair<string, string>> headerNameList, string sheetName = "result", string filePath = null) where T : class
        {
            if (data.Count <= 0) return null;

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = GetSaveFilePath();
            }

            if (string.IsNullOrEmpty(filePath)) return null;

            bool isCompatible = GetIsCompatible(filePath);

            IWorkbook workbook = CreateWorkbook(isCompatible);
            ICellStyle cellStyle = GetCellStyle(workbook);
            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow headerRow = sheet.CreateRow(0);

            for (int i = 0; i < headerNameList.Count; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(headerNameList[i].Value);
                cell.CellStyle = cellStyle;
            }

            Type t = typeof(T);
            int rowIndex = 1;
            foreach (T item in data)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                for (int n = 0; n < headerNameList.Count; n++)
                {
                    object pValue = t.GetProperty(headerNameList[n].Key).GetValue(item, null);
                    dataRow.CreateCell(n).SetCellValue((pValue ?? "").ToString());
                }
                rowIndex++;
            }
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            return filePath;
        }

        /// <summary>
        /// 由DataGridView导出
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="sheetName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ExportToExcel(DataGridView grid, string sheetName = "result", string filePath = null)
        {
            if (grid.Rows.Count <= 0) return null;

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = GetSaveFilePath();
            }

            if (string.IsNullOrEmpty(filePath)) return null;

            bool isCompatible = GetIsCompatible(filePath);

            IWorkbook workbook = CreateWorkbook(isCompatible);
            ICellStyle cellStyle = GetCellStyle(workbook);
            ISheet sheet = workbook.CreateSheet(sheetName);

            IRow headerRow = sheet.CreateRow(0);

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(grid.Columns[i].HeaderText);
                cell.CellStyle = cellStyle;
            }

            int rowIndex = 1;
            foreach (DataGridViewRow row in grid.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                for (int n = 0; n < grid.Columns.Count; n++)
                {
                    dataRow.CreateCell(n).SetCellValue((row.Cells[n].Value ?? "").ToString());
                }
                rowIndex++;
            }

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            return filePath;
        }
        /// <summary>
        /// 结果信息导出
        /// </summary>
        /// <param name="currListView"></param>
        /// <param name="sheetName"></param>
        /// <param name="filePath"></param>
        /// <param name="resultInfoDictionary"></param>
        public static void ResultToExcel(ListView currListView, string sheetName, string filePath, ConcurrentDictionary<string, ClsResultInfoTableBo> resultInfoDictionary)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = GetSaveFilePath();
            }

            if (string.IsNullOrEmpty(filePath)) return;

            bool isCompatible = GetIsCompatible(filePath);

            IWorkbook workbook = CreateWorkbook(isCompatible);
            ICellStyle cellStyle = GetCellStyle(workbook);
            ISheet sheet = workbook.CreateSheet(sheetName);

            IRow headerRow = sheet.CreateRow(0);

            for (int i = 0; i < currListView.Columns.Count; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(currListView.Columns[i].Text);
                cell.CellStyle = cellStyle;
            }

            int rowIndex = 1;
            int resultInfoDictionaryCount = resultInfoDictionary.Count;
            if (resultInfoDictionaryCount > 0)
            {
                IRow dataRow = null;
                foreach (KeyValuePair<string, ClsResultInfoTableBo> resultInfoObj in resultInfoDictionary)
                {
                    ClsResultInfoTableBo currResultInfoTableBo = resultInfoObj.Value;
                    if (currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR)
                    {
                        foreach (ClsOnuUniMacAddressEntryVo currOnuUniMacAddressEntryVo in currResultInfoTableBo.onuUniMacAddressEntryVoList)
                        {
                            dataRow = sheet.CreateRow(rowIndex);
                            dataRow.CreateCell(0).SetCellValue((rowIndex.ToString() ?? "").ToString());
                            dataRow.CreateCell(1).SetCellValue((currResultInfoTableBo.oltInfoVo.ipAddress).ToString());
                            dataRow.CreateCell(2).SetCellValue((currResultInfoTableBo.onuInfoEntryVo.onuMacAddress ).ToString());
                            dataRow.CreateCell(3).SetCellValue((currOnuUniMacAddressEntryVo.onuUniDeviceIndex).ToString());
                            dataRow.CreateCell(4).SetCellValue((currOnuUniMacAddressEntryVo.onuUniIndex).ToString());
                            dataRow.CreateCell(5).SetCellValue((currOnuUniMacAddressEntryVo.onuUniMacAddress).ToString());
                            dataRow.CreateCell(6).SetCellValue((currOnuUniMacAddressEntryVo.onuUniVid ).ToString());
                            dataRow.CreateCell(7).SetCellValue((currOnuUniMacAddressEntryVo.onuUniStatic).ToString());
                            dataRow.CreateCell(8).SetCellValue((currOnuUniMacAddressEntryVo.onuUniMulticast).ToString());
                            dataRow.CreateCell(9).SetCellValue(currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR || currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR_BUT_NO_USER_DEV ? "成功" : "失败");
                            dataRow.CreateCell(10).SetCellValue("");
                            rowIndex++;
                        }
                    }
                    else
                    {
                        dataRow = sheet.CreateRow(rowIndex);
                        dataRow.CreateCell(0).SetCellValue((rowIndex.ToString() ?? "").ToString());
                        dataRow.CreateCell(1).SetCellValue((currResultInfoTableBo.oltInfoVo.ipAddress ?? "").ToString());
                        dataRow.CreateCell(2).SetCellValue((currResultInfoTableBo.onuInfoEntryVo.onuMacAddress ?? "").ToString());
                        dataRow.CreateCell(3).SetCellValue((currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniDeviceIndex ?? "").ToString());
                        dataRow.CreateCell(4).SetCellValue((currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniIndex ?? "").ToString());
                        dataRow.CreateCell(5).SetCellValue((currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMacAddress ?? "").ToString());
                        dataRow.CreateCell(6).SetCellValue((currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniVid ?? "").ToString());
                        dataRow.CreateCell(7).SetCellValue((currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniStatic ?? "").ToString());
                        dataRow.CreateCell(8).SetCellValue((currResultInfoTableBo.onuUniMacAddressEntryVo.onuUniMulticast ?? "").ToString());
                        dataRow.CreateCell(9).SetCellValue(currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR || currResultInfoTableBo.optMsgInfoVo.optStatus == EnumSnmpOptStatus.NO_ERROR_BUT_NO_USER_DEV ? "成功" : "失败");
                        dataRow.CreateCell(10).SetCellValue((currResultInfoTableBo.optMsgInfoVo.optMsg ?? "").ToString());
                        rowIndex++;
                    }
                }
            }

            //列宽自动适应
            //列宽自适应，只对英文和数字有效
            for (int i = 0; i <= currListView.Items.Count; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            int columnWidth = 17;
            sheet.SetColumnWidth(0, 10 * 256);
            sheet.SetColumnWidth(1, columnWidth * 256);
            sheet.SetColumnWidth(2, columnWidth * 256);
            sheet.SetColumnWidth(3, columnWidth * 256);
            sheet.SetColumnWidth(4, columnWidth * 256);
            sheet.SetColumnWidth(5, columnWidth * 256);
            sheet.SetColumnWidth(6, columnWidth * 256);
            sheet.SetColumnWidth(7, columnWidth * 256);
            sheet.SetColumnWidth(8, columnWidth * 256);
            sheet.SetColumnWidth(9, columnWidth * 256);
            sheet.SetColumnWidth(10, columnWidth * 256 * 5);

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            if (MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("成功导出,是否直接打开？"), ClsI18NMng.GetI18NMng().ChangeLanguage("询问"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }
        /// <summary>
        /// 由ListView导出
        /// </summary>
        /// <param name="currListView"></param>
        /// <param name="sheetName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static void ExportToExcel(ListView currListView, string sheetName, string filePath = null)
        {
            if (currListView.Items.Count <= 0) return;

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = GetSaveFilePath();
            }

            if (string.IsNullOrEmpty(filePath)) return;

            bool isCompatible = GetIsCompatible(filePath);

            IWorkbook workbook = CreateWorkbook(isCompatible);
            ICellStyle cellStyle = GetCellStyle(workbook);
            ISheet sheet = workbook.CreateSheet(sheetName);

            IRow headerRow = sheet.CreateRow(0);

            for (int i = 0; i < currListView.Columns.Count; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(currListView.Columns[i].Text);
                cell.CellStyle = cellStyle;
            }

            int rowIndex = 1;
            foreach (ListViewItem row in currListView.Items)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                for (int n = 0; n < currListView.Columns.Count; n++)
                {
                    dataRow.CreateCell(n).SetCellValue((row.SubItems[n].Text ?? "").ToString());
                }
                rowIndex++;
            }
            //列宽自动适应
            //列宽自适应，只对英文和数字有效
            for (int i = 0; i <= currListView.Items.Count; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            //获取当前列的宽度，然后对比本列的长度，取最大值
            for (int columnNum = 0; columnNum <= currListView.Items.Count; columnNum++)
            {
                int columnWidth = sheet.GetColumnWidth(columnNum) / 256;
                for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                {
                    IRow currentRow;
                    //当前行未被使用过
                    if (sheet.GetRow(rowNum) == null)
                    {
                        currentRow = sheet.CreateRow(rowNum);
                    }
                    else
                    {
                        currentRow = sheet.GetRow(rowNum);
                    }

                    if (currentRow.GetCell(columnNum) != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                        if (columnWidth < length)
                        {
                            columnWidth = length;
                        }
                    }
                }
                sheet.SetColumnWidth(columnNum, columnWidth * 256);
            }

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            if (MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage("成功导出,是否直接打开？"), ClsI18NMng.GetI18NMng().ChangeLanguage("询问"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }
        #endregion

        #region 公共导入方法

        /// <summary>
        /// 由Excel导入DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="sheetName">Excel工作表名称</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <param name="isCompatible">是否为兼容模式</param>
        /// <returns>DataTable</returns>
        public static System.Data.DataTable ImportFromExcel(Stream excelFileStream, string sheetName, int headerRowIndex, bool isCompatible)
        {
            IWorkbook workbook = CreateWorkbook(isCompatible, excelFileStream);
            ISheet sheet = null;
            int sheetIndex = -1;
            if (int.TryParse(sheetName, out sheetIndex))
            {
                sheet = workbook.GetSheetAt(sheetIndex);
            }
            else
            {
                sheet = workbook.GetSheet(sheetName);
            }

            System.Data.DataTable table = GetDataTableFromSheet(sheet, headerRowIndex);

            excelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        /// 由Excel导入DataTable
        /// </summary>
        /// <param name="excelFilePath">Excel文件路径，为物理路径。</param>
        /// <param name="sheetName">Excel工作表名称</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataTable</returns>
        public static System.Data.DataTable ImportFromExcel(string excelFilePath, string sheetName, int headerRowIndex)
        {
            if (string.IsNullOrEmpty(excelFilePath))
            {
                excelFilePath = GetOpenFilePath();
            }

            if (string.IsNullOrEmpty(excelFilePath))
            {
                return null;
            }

            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                bool isCompatible = GetIsCompatible(excelFilePath);
                return ImportFromExcel(stream, sheetName, headerRowIndex, isCompatible);
            }
        }

        /// <summary>
        /// 由Excel导入DataSet，如果有多个工作表，则导入多个DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <param name="isCompatible">是否为兼容模式</param>
        /// <returns>DataSet</returns>
        public static DataSet ImportFromExcel(Stream excelFileStream, int headerRowIndex, bool isCompatible)
        {
            DataSet ds = new DataSet();
            IWorkbook workbook = CreateWorkbook(isCompatible, excelFileStream);
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ISheet sheet = workbook.GetSheetAt(i);
                System.Data.DataTable table = GetDataTableFromSheet(sheet, headerRowIndex);
                ds.Tables.Add(table);
            }

            excelFileStream.Close();
            workbook = null;

            return ds;
        }

        /// <summary>
        /// 由Excel导入DataSet，如果有多个工作表，则导入多个DataTable
        /// </summary>
        /// <param name="excelFilePath">Excel文件路径，为物理路径。</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataSet</returns>
        public static DataSet ImportFromExcel(string excelFilePath, int headerRowIndex)
        {
            if (string.IsNullOrEmpty(excelFilePath))
            {
                excelFilePath = GetOpenFilePath();
            }

            if (string.IsNullOrEmpty(excelFilePath))
            {
                return null;
            }

            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                bool isCompatible = GetIsCompatible(excelFilePath);
                return ImportFromExcel(stream, headerRowIndex, isCompatible);
            }
        }

        #endregion

        #region 公共转换方法

        /// <summary>
        /// 将Excel的列索引转换为列名，列索引从0开始，列名从A开始。如第0列为A，第1列为B...
        /// </summary>
        /// <param name="index">列索引</param>
        /// <returns>列名，如第0列为A，第1列为B...</returns>
        public static string ConvertColumnIndexToColumnName(int index)
        {
            index = index + 1;
            int system = 26;
            char[] digArray = new char[100];
            int i = 0;
            while (index > 0)
            {
                int mod = index % system;
                if (mod == 0) mod = system;
                digArray[i++] = (char)(mod - 1 + 'A');
                index = (index - 1) / 26;
            }
            StringBuilder sb = new StringBuilder(i);
            for (int j = i - 1; j >= 0; j--)
            {
                sb.Append(digArray[j]);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 转化日期
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public static DateTime ConvertToDate(object date)
        {
            string dtStr = (date ?? "").ToString();

            DateTime dt = new DateTime();

            if (DateTime.TryParse(dtStr, out dt))
            {
                return dt;
            }

            try
            {
                string spStr = "";
                if (dtStr.Contains("-"))
                {
                    spStr = "-";
                }
                else if (dtStr.Contains("/"))
                {
                    spStr = "/";
                }
                string[] time = dtStr.Split(spStr.ToCharArray());
                int year = Convert.ToInt32(time[2]);
                int month = Convert.ToInt32(time[0]);
                int day = Convert.ToInt32(time[1]);
                string years = Convert.ToString(year);
                string months = Convert.ToString(month);
                string days = Convert.ToString(day);
                if (months.Length == 4)
                {
                    dt = Convert.ToDateTime(date);
                }
                else
                {
                    string rq = "";
                    if (years.Length == 1)
                    {
                        years = "0" + years;
                    }
                    if (months.Length == 1)
                    {
                        months = "0" + months;
                    }
                    if (days.Length == 1)
                    {
                        days = "0" + days;
                    }
                    rq = "20" + years + "-" + months + "-" + days;
                    dt = Convert.ToDateTime(rq);
                }
            }
            catch
            {
                throw new Exception("日期格式不正确，转换日期类型失败！");
            }
            return dt;
        }

        /// <summary>
        /// 转化数字
        /// </summary>
        /// <param name="d">数字字符串</param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(object d)
        {
            string dStr = (d ?? "").ToString();
            decimal result = 0;
            if (decimal.TryParse(dStr, out result))
            {
                return result;
            }
            else
            {
                throw new Exception("数字格式不正确，转换数字类型失败！");
            }

        }


        /// <summary>
        /// 转化布尔
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ConvertToBoolen(object b)
        {
            string bStr = (b ?? "").ToString().Trim();
            bool result = false;
            if (bool.TryParse(bStr, out result))
            {
                return result;
            }
            else if (bStr == "0" || bStr == "1")
            {
                return (bStr == "0");
            }
            else
            {
                throw new Exception("布尔格式不正确，转换布尔类型失败！");
            }
        }

        #endregion



        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        public void ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(System.Data.DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public static DataTable ExcelToDataTable(string fileName,string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            IWorkbook workbook = null;
            FileStream fs = null;
            System.Data.DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                //workbook = new XSSFWorkbook(fs);
                if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }

        /// <summary>
        /// 判断是否是规定的模板，字段没有被任何修改
        /// </summary>
        /// <param name="currDataTable"></param>
        public static bool IsCorrectExcelTemplateMethod(DataTable currDataTable)
        {
            if (currDataTable.Columns.Count > 5
                             || !"选择".Equals(currDataTable.Columns[0].ColumnName.Trim())
                             || !"OLT-Ip地址".Equals(currDataTable.Columns[1].ColumnName.Trim())
                             || !"ONU-Mac地址".Equals(currDataTable.Columns[2].ColumnName.Trim())
                             || !"读共同体".Equals(currDataTable.Columns[3].ColumnName.Trim())
                             || !"写共同体".Equals(currDataTable.Columns[4].ColumnName.Trim())
                             )
            {
                return false;
            }
            return true;
        }
    }
}
