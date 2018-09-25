
using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserControllerImpl.ControllerImpl;
using OnuDevInfoOnUserModel.Constant;
using OnuDevInfoOnUserModel.EventClass;
using OnuDevInfoOnUserViewImpl.ViewImpl.ControlView;
using OnuDevInfoOnUserViewImpl.ViewInterface;
using OnuDevInfoOnUserViewInterface.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OnuDevInfoOnUserCommon.HelpTools.ClsWriteExcel;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.WindowView
{
    public partial class FrmOnuDevInfoOnUserToolMain : Form
    {
        #region 变量
        private log4net.ILog m_log = log4net.LogManager.GetLogger("FrmOnuDevInfoOnUserToolMain");
        private IFrmMainDataPageView m_frmMainDataPageView = null;
        private IFrmMainHeaderOptView m_frmMainHeaderOptView = null;
        private IFrmMainResultPageView m_frmMainResultPageVIew = null;

        #endregion

        #region 构造方法与加载方法
        public FrmOnuDevInfoOnUserToolMain()
        {
            InitializeComponent();
            //初始化方法加载
            m_frmMainDataPageView = new ClsFrmMainDataPageViewCImpl(this);
            m_frmMainHeaderOptView = new ClsFrmMainHeaderOptViewCImpl(this);
            m_frmMainResultPageVIew = new ClsFrmMainResultPageViewCImpl(this);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //头部导航菜单事件加载
            FrmMainHeaderMenuEventLoad();
            //数据页面操作事件加载
            FrmMainDataPageEventLoad();
            //结果信息页面操作事件加载
            FrmMainResultPageEventLoad();
        }
        #endregion

        #region 各种控件的执行方法
        /// <summary>
        /// 监听主程序FrmMain窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
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
        #endregion


    }
}
