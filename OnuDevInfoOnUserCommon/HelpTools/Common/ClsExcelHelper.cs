

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsExcelHelper
    {
        public static string getOpenFileDialogFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //定义打开的默认文件夹位置 
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            //获得选择的文件路径
            string openFileName = openFileDialog.FileName;
            //获得文件扩展名         
            string extendedName = Path.GetExtension(openFileName).ToLower();
            if ((extendedName.Length < 6) && (extendedName.Contains("xls") || extendedName.Contains("xlsx")))
            {
                return openFileName;
            }
            else
            {
                MessageBox.Show("不是Excel相关文件，无法导入到程序中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }
        }

       
        public static void DataGridViewToExcel(string fileName, DataGridView dgv)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //定义打开的默认文件夹位置 
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel 2003格式|*.xls|Excel 2007文件|*.xlsx";
            saveFileDialog.FileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
           string filePath = saveFileDialog.FileName;

            WriteToExcel(filePath,dgv);
            GC.Collect();
            MessageBox.Show("导出成功！", "导出提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void WriteToExcel(string saveFilePath ,DataGridView dataGridView)
        {
            try
            {
                //没有数据的话就不往下执行  
                if (dataGridView.Rows.Count == 0)
                {
                    //return;
                }
                // 列索引，行索引，总列数，总行数
                int ColIndex = 0;
                int RowIndex = 0;
                int ColCount = dataGridView.ColumnCount;
                int RowCount = dataGridView.RowCount;

                if (dataGridView.RowCount == 0)
                {
                    
                }

                // 创建Excel对象
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    
                }
                try
                {
                    // 创建Excel工作薄
                    Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                    Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[1];
                    // 设置标题
                    xlApp.ActiveCell.Font.Size = 20;
                    xlApp.ActiveCell.Font.Bold = true;
                    xlApp.ActiveCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    // 创建缓存数据
                    object[,] objData = new object[RowCount + 1, ColCount];
                    //获取列标题
                    foreach (DataGridViewColumn col in dataGridView.Columns)
                    {
                        objData[RowIndex, ColIndex++] = col.HeaderText;
                    }
                    // 获取数据
                    for (RowIndex = 1; RowIndex < RowCount; RowIndex++)
                    {
                        for (ColIndex = 0; ColIndex < ColCount; ColIndex++)
                        {
                            if (dataGridView[ColIndex, RowIndex - 1].ValueType == typeof(string)
                                || dataGridView[ColIndex, RowIndex - 1].ValueType == typeof(DateTime))//这里就是验证DataGridView单元格中的类型,如果是string或是DataTime类型,则在放入缓存时在该内容前加入" ";
                            {
                                objData[RowIndex, ColIndex] = "" + dataGridView[ColIndex, RowIndex - 1].Value;
                            }
                            else
                            {
                                objData[RowIndex, ColIndex] = dataGridView[ColIndex, RowIndex - 1].Value;
                            }
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    // 写入Excel
                    xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount, ColCount]);
                   

                    xlBook.Saved = true;
                    xlBook.SaveCopyAs(saveFilePath);
                }
                catch (Exception err)
                {
                  
                }
                finally
                {
                    xlApp.Quit();
                    GC.Collect(); //强制回收
                }
                MessageBox.Show( "文件已经成功导出！", "提示");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }

        }
        public static void readExcelMethod(string filePath,DataGridView dataGridView)
        {
           
                try
                {
                    string strCon = "provider=microsoft.jet.oledb.4.0;data source=" + filePath + ";extended properties=excel 8.0";//关键是红色区域
                    OleDbConnection Con = new OleDbConnection(strCon);//建立连接
                    string strSql = "select * from [用户信息表$]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
                    OleDbCommand Cmd = new OleDbCommand(strSql, Con);//建立要执行的命令
                    OleDbDataAdapter da = new OleDbDataAdapter(Cmd);//建立数据适配器
                    DataSet ds = new DataSet();//新建数据集
                    da.Fill(ds, "jqmkj");//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                                          //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]
                    dataGridView.DataSource = ds.Tables[0];
                    dataGridView.Update();
                    dataGridView.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//捕捉异常
                }
            
        
       }

        #region 私有方法
            //选择保存路径
        public static string SelectExportPath(string fileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出";
            saveFileDialog.FileName = fileName;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
                return saveFileDialog.FileName;
            else
                return null;
        }

        /// <summary>
        /// 获取要保存的文件名称（含完整路径）
        /// </summary>
        /// <returns></returns>
        private static string GetSaveFilePath()
        {
            SaveFileDialog saveFileDig = new SaveFileDialog();
            saveFileDig.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            saveFileDig.FilterIndex = 0;
            saveFileDig.OverwritePrompt = true;
            string filePath = null;
            if (saveFileDig.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDig.FileName;
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
        public static DateTime ConvertDate(object date)
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
                throw new Exception("日期格式不正确，转换日期失败！");
            }
            return dt;
        }

        /// <summary>
        /// 转化数字
        /// </summary>
        /// <param name="d">数字字符串</param>
        /// <returns></returns>
        public static decimal ConvertDecimal(object d)
        {
            string dStr = (d ?? "").ToString();
            decimal result = 0;
            if (decimal.TryParse(dStr, out result))
            {
                return result;
            }
            else
            {
                throw new Exception("数字格式不正确，转换数字失败！");
            }

        }

        #endregion
    }
}
