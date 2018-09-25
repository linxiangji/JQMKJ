using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserModel.UctrlJqmkjMainApplication.EventClass;
using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    public partial class FrmMainApplication
    {
        /// <summary>
        /// 事件方法的初始化
        /// </summary>
        public void FrmMainApplicationHeaderEventMethodLoad()
        {
            ClsFrmMainApplicationHeaderEvent.ApplicationExitClickEvent = ApplicationExitClickEventImpl;
            ClsFrmMainApplicationHeaderEvent.BtnVersionClickOpenFrmVersionEvent = BtnVersionClickOpenFrmVersionEventImpl;
        }

        #region 事件方法的具体实现
        /// <summary>
        ///  JQMKJ集成工具顶部菜单：版本 逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVersionClickOpenFrmVersionEventImpl(object sender, EventArgs e)
        {
            try
            {
                string currNowApplicationName = ClsConfigHelper.readCofigValueByKey("NowApplicationName");
                string currNowVersionNum = ClsConfigHelper.readCofigValueByKey("NowVersionNum");
                string currNowCompileTime = ClsConfigHelper.readCofigValueByKey("NowCompileTime");
                string currNowCopyright = ClsConfigHelper.readCofigValueByKey("NowCopyright");
                string currNowCompangyName = ClsConfigHelper.readCofigValueByKey("NowCompangyName");
                string currWebsiteAddress = ClsConfigHelper.readCofigValueByKey("NowWebsiteAddress");

                ClsVersionVo versionVo = new ClsVersionVo();
                versionVo.applicationName = currNowApplicationName != null ? currNowApplicationName : "";
                versionVo.versionNum = currNowVersionNum != null ? currNowVersionNum : "";
                versionVo.compileTime = currNowCompileTime != null ? currNowCompileTime : "";
                versionVo.copyright = currNowCopyright != null ? currNowCopyright : "";
                versionVo.compangyName = currNowCompangyName != null ? currNowCompangyName : "";
                versionVo.websiteAddress = currWebsiteAddress != null ? currWebsiteAddress : "";

                FrmVersion currFrmVersion = new FrmVersion(versionVo);
                currFrmVersion.StartPosition = FormStartPosition.CenterParent;
                currFrmVersion.ShowDialog();
                currFrmVersion.Dispose();
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// JQMKJ集成工具顶部菜单：退出 逻辑
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
        #endregion
    }
}
