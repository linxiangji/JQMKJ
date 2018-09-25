using System;
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

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsReadExcel
    {
        private static log4net.ILog m_log = log4net.LogManager.GetLogger("ClsReadExcel");
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);

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

        public static bool isExcelOpen(string filePath)
        {
            IntPtr excelHandle = new IntPtr();
            try
            {
                excelHandle = _lopen(filePath, OF_READWRITE | OF_SHARE_DENY_NONE);
                return excelHandle == HFILE_ERROR;
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
                return false;
            }
            finally
            {
                if (excelHandle!=null)
                {
                    CloseHandle(excelHandle);
                }
            }
        }
        public static System.Data.DataTable ReadExcelByOle(string filePath, string sheetName)
        {
            string connStr = "";
            System.Data.DataTable dtExcel = new System.Data.DataTable();
            string fileType = System.IO.Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType))
            {
                m_log.Debug("ClsImportEocTopoMng readExcelHeadName:GetExtension null");
            }
            else
            {
                //备注： "HDR=yes;"是说Excel文件的第一行是列名而不是数据，"HDR=No;"正好与前面的相反。
                //      "IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。 
                if (fileType == ".xls")
                    connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1\"";//此连接只能操作Excel2007之前(.xls)文件
                else
                    connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";//此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串)
                OleDbConnection conExcel = new OleDbConnection(connStr);
                OleDbDataAdapter daExcel = null;

                string strSqlExcel = string.Format("SELECT * FROM[{0}$]", sheetName);
                try
                {
                    conExcel.Open();
                    daExcel = new OleDbDataAdapter(strSqlExcel, conExcel);
                    daExcel.Fill(dtExcel);
                }
                catch (Exception ex)
                {
                    m_log.Error(ex.ToString());
                }
                finally
                {
                    if (conExcel != null)
                        conExcel.Close();
                    if (daExcel != null)
                    {
                        daExcel.Dispose();
                        daExcel = null;
                    }
                    if (conExcel != null)
                    {
                        conExcel.Dispose();
                        conExcel = null;
                    }
                }
            }
            return dtExcel;
        }
        public static System.Data.DataTable ReadExcelByOle(string filePath, ref string msg)
        {
            OleDbDataAdapter myCommand = null;
            System.Data.DataSet ds = null;
            System.Data.DataTable dt = null;
            OleDbConnection conn = null;
            try
            {
                if (string.IsNullOrEmpty(filePath) == false)
                {
                    //excel数据源连接地址
                    string fileType = System.IO.Path.GetExtension(filePath);
                    if (string.IsNullOrEmpty(fileType))
                    {
                        m_log.Debug("ClsImportEocTopoMng readExcelHeadName:GetExtension null");
                    }
                    else
                    {
                        string connStr = "";
                        if (fileType == ".xls")
                            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1\"";
                        else
                            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";
                        conn = new OleDbConnection(connStr);
                        conn.Open();
                        System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                        if (schemaTable != null && schemaTable.Rows.Count > 0 && schemaTable.Columns.Count >= 3)
                        {
                            string strTableName = schemaTable.Rows[0][2].ToString().Trim();
                            if (string.IsNullOrEmpty(strTableName) == false)
                            {
                                myCommand = new OleDbDataAdapter("select * from [" + strTableName + "]", connStr);
                                ds = new System.Data.DataSet();
                                myCommand.Fill(ds);
                                dt = ds.Tables[0];
                                if (dt != null)
                                    dt.TableName = strTableName.Substring(0, strTableName.LastIndexOf('$'));
                                else
                                    msg = "数据获取失败,请联系管理员!";
                            }
                        }
                    }
                }
                else
                {
                    msg = "Excel文件路径未获取到,请联系管理员!";
                }
            }
            catch (System.Exception ex)
            {
                msg = "读取Excel错误！";
                if (dt != null)
                    dt.Clear();
                m_log.Error(ex.ToString());
            }
            finally
            {
                if (conn != null)
                    conn.Close();
                if (myCommand != null)
                {
                    myCommand.Dispose();
                    myCommand = null;
                }
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            }
            return dt;
        }

        //将excel数据加载到DataTable里面;定死获取第一个sheet
        public static System.Data.DataTable ReadExcelByMS(string strFileName, ref string strMessage)
        {
            object missing = System.Reflection.Missing.Value;
            System.Data.DataTable dt = null;
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                if (excel == null)
                {
                    strMessage = "获取Excel对象失败,请联系管理员!";
                }
                else
                {
                    excel.Visible = false;
                    excel.UserControl = true;
                    // 以只读的形式打开EXCEL文件  
                    wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
                            missing, missing, missing, true, missing, missing, missing, missing, missing);
                    //取得第一个工作薄  
                    Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.get_Item(1);
                    //得到行数  
                    int rowsint = ws.UsedRange.Cells.Rows.Count;
                    //得到列数  
                    int columnsint = ws.UsedRange.Cells.Columns.Count;
                    //获取列的坐标名
                    string strColumName = getColumnCode(columnsint - 1);
                    if (rowsint > 1 && columnsint >= 1)
                    {
                        //取得数据范围区域 
                        Microsoft.Office.Interop.Excel.Range rng = ws.Cells.get_Range("A1", strColumName + rowsint);
                        if (rng != null)
                        {
                            object[,] arry = (object[,])rng.Value2;
                            dt = new System.Data.DataTable();    //新建对象
                            dt.TableName = ws.Name;
                            for (int i = 1; i <= columnsint; i++)
                            {
                                if (arry[1, i] != null)
                                {
                                    dt.Columns.Add(arry[1, i].ToString(), typeof(string));
                                }
                                else
                                {
                                    strMessage = "单元格对应有空列名或者数据间掺杂空列,请修改后在做操作!";
                                    return dt = null;
                                }
                            }
                            for (int i = 2; i <= rowsint; i++)
                            {
                                DataRow dr = dt.NewRow();
                                for (int j = 1; j <= columnsint; j++)
                                {
                                    object a = arry[i, j];
                                    dr[arry[1, j].ToString()] = arry[i, j];
                                }
                                dt.Rows.Add(dr);
                            }
                        }
                        else
                        {
                            strMessage = "表数据为空,不能导入!";
                        }
                    }
                    else
                    {
                        strMessage = "表数据为空,不能导入!";
                    }
                }
            }
            catch (System.Exception ex)
            {
                m_log.Error(ex.ToString());
            }
            finally
            {
                if (wb != null)
                    wb.Close();
                if (excel != null)
                    excel.Quit();
            }
            return dt;
        }
        //获取大写字母
        private static string getColumnCode(int column)
        {
            char ch = 'A';
            int index = (int)ch;
            ch = (char)(index + column);
            return ch.ToString(); ;
        }

    }
}
