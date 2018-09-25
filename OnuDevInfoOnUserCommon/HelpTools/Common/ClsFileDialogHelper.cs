using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsFileDialogHelper
    {
        public static SaveFileDialog GetSaveFileDialogOnExcel(string saveFileName)
        {
            SaveFileDialog currOptSaveFileDialog = new SaveFileDialog();
            //定义打开的默认文件夹位置 
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            currOptSaveFileDialog.DefaultExt = "xls";
            currOptSaveFileDialog.Filter = "Excel 2003格式|*.xls";
            currOptSaveFileDialog.FileName = saveFileName + DateTime.Now.ToString("yyyyMMddHHmmss");
            //保存对话框是否记忆上次打开的目录  
            currOptSaveFileDialog.RestoreDirectory = true;
            if (currOptSaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            return currOptSaveFileDialog;
        }
    }
}
