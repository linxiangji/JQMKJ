
using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserModel.UctrlJqmkjMainApplication.EventClass;
using SkinSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    public partial class FrmMainApplication : Form
    {
        #region 变量
        private log4net.ILog m_log = log4net.LogManager.GetLogger("FrmMainApplication");
        private SkinH_Net currSkinHNet = null;
        private static Form m_lastShowOptFrm = null;
        #endregion

        #region 加载与构造方法
        public FrmMainApplication()
        {
            try
            {
                //得到当前电脑操作版本，判断是否是window7及以上版本，是则加载皮肤插件
                OperatingSystem currOperatingSystem = Environment.OSVersion;
                if (currOperatingSystem.Platform == PlatformID.Win32NT && currOperatingSystem.Version.Major >= 6)
                {
                    //皮肤加载
                    currSkinHNet = new SkinH_Net();
                    currSkinHNet.Attach();//加载运行目录下的skinh.she
                                          //currSkinHNet.AttachEx("Skins\\skinh10.she", "");//加载指定目录下的she皮肤
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }

            InitializeComponent();
        }

        private void FrmMainApplication_Load(object sender, EventArgs e)
        {
            string currNowApplicationName = ClsConfigHelper.readCofigValueByKey("NowApplicationName");
            this.Text = currNowApplicationName != null ? currNowApplicationName : "";
            //事件统一加载
            FrmMainApplicationHeaderEventMethodLoad();
            FrmMainApplicationLeftMenuEventMethodLoad();
            FrmMainApplicationMainPageEventMethodLoad();

        }
        #endregion

        #region 各种控件的执行方法

        /// <summary>
        /// 监听主程序FrmMainApplication窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMainApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult currDialogResult = ClsMessageBoxHelper.ShowOKCancelMsg("确定退出此程序？");
                    if (currDialogResult != DialogResult.OK)
                    {
                        e.Cancel = true;//阻止关闭窗口
                    }
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }

        #endregion

        #region 辅助方法
        public string GetCurrSystemOSVersionMethod()
        {
            string osVersion = null;
            OperatingSystem os = Environment.OSVersion;
            switch (os.Platform)
            {
                case PlatformID.Win32Windows:
                    switch (os.Version.Minor)
                    {
                        case 0:
                            osVersion  =  "Windows   95 ";
                            break;
                        case 10:
                            if (os.Version.Revision.ToString() == "2222A ")
                                osVersion = "Windows   98   第二版 ";
                            else
                                osVersion = "Windows   98 ";
                            break;
                        case 90:
                            osVersion = "Windows   Me ";
                            break;
                    }
                    break;
                case PlatformID.Win32NT:
                    switch (os.Version.Major)
                    {
                        case 3:
                            osVersion = "Windows   NT   3.51 ";
                            break;
                        case 4:
                            osVersion = "Windows   NT   4.0 ";
                            break;
                        case 5:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    osVersion = "Windows   200 ";
                                    break;
                                case 1:
                                    osVersion = "Windows   XP ";
                                    break;
                                case 2:
                                    osVersion = "Windows   2003 ";
                                    break;
                            }
                            break;
                        case 6:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    osVersion = "Windows  Vista ";
                                    break;
                                case 1:
                                    osVersion = "Windows   7 ";
                                    break;
                            }
                            break;
                    }
                    break;
            }
            return osVersion;
        }
        #endregion
    }
}
