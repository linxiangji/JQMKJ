using I18NHelper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    public class ClsMessageBoxHelper
    {
       
        public static void ShowCodeMsg(int code , string info)
        {
            MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage(info+"(错误码："+code+")"));
        }

        public static void ShowInfoMsg(string info)
        {
            MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage(info), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowWaringMsg(string info)
        {
            MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage(info), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult ShowYesNoMsg(string info)
        {
            return MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage(info), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult ShowOKCancelMsg(string info)
        {
            return MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage(info), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        public static void ShowErrorMsg(string info)
        {
            MessageBox.Show(ClsI18NMng.GetI18NMng().ChangeLanguage(info), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
