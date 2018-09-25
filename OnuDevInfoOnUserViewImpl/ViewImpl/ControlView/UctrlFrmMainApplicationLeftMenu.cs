using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections.ObjectModel;
using OnuDevInfoOnUserModel.VoClass;
using OnuDevInfoOnUserCommon.HelpTools;
using OnuDevInfoOnUserViewImpl.ViewImpl.UctrlJqmkjMainApplication;
using OnuDevInfoOnUserModel.UctrlJqmkjMainApplication.EventClass;

namespace OnuDevInfoOnUserViewImpl.ViewImpl.ControlView
{
    public partial class UctrlFrmMainApplicationLeftMenu : UserControl
    {
        //用于存放具体的子菜单对象
       private ObservableCollection<ClsMainMenuVo> m_allClsMainMenuVoXmlList = new ObservableCollection<ClsMainMenuVo>();
        //存放分组的对象
       private ObservableCollection<ClsMainMenuVo> m_mainMenuGroupXmlList = new ObservableCollection<ClsMainMenuVo>();

        public UctrlFrmMainApplicationLeftMenu()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            m_allClsMainMenuVoXmlList=ClsCustomMainMenuXmlHelper.GetAllClsMainMenuVoXml();
            m_mainMenuGroupXmlList = ClsCustomMainMenuXmlHelper.GetMenuGroupXml();

            #region 初始化 OutLookBar
            outlookBarLeftMenu.BorderStyle = BorderStyle.FixedSingle;
            outlookBarLeftMenu.Initialize();
            int mainMenuGroupNum = 0;
            if (m_mainMenuGroupXmlList!=null && m_mainMenuGroupXmlList.Count>0)
            {
                foreach (ClsMainMenuVo currClsMainMenuVoGroup in m_mainMenuGroupXmlList)
                {
                    IconPanel currIconPanel = new IconPanel();
                    currIconPanel.outlookBar = outlookBarLeftMenu;
                    foreach (ClsMainMenuVo currClsMainMenuVo in m_allClsMainMenuVoXmlList)
                    {
                        if (currClsMainMenuVo!=null)
                        {
                            if (currClsMainMenuVoGroup.menuGroup.Equals(currClsMainMenuVo.menuGroup))
                            {

                                string currImagePath = System.IO.Directory.GetCurrentDirectory() + currClsMainMenuVo.image;
                                if (currImagePath.IndexOf(".") == -1)
                                {
                                    currIconPanel.AddIcon(currClsMainMenuVo.name, null, null);
                                    break;
                                }
                                //第一组ONU工具集，绑定OnePanelMenuGroupEvent方法
                                if (mainMenuGroupNum == 0)
                                {
                                    currIconPanel.AddIcon(currClsMainMenuVo.name, Image.FromFile(currImagePath), new EventHandler(OnePanelMenuGroupEvent));
                                }
                                //第二组其他工具集，绑定TwoPanelMenuGroupEvent方法，
                                if (mainMenuGroupNum == 1)
                                {
                                    currIconPanel.AddIcon(currClsMainMenuVo.name, Image.FromFile(currImagePath), new EventHandler(TwoPanelMenuGroupEvent));
                                }
                                //如果有第三组工具集，绑定ThreePanelMenuGroupEvent方法，此方法预留，当前版本就只有上面两个工具集
                                if (mainMenuGroupNum == 2)
                                {
                                    currIconPanel.AddIcon(currClsMainMenuVo.name, Image.FromFile(currImagePath), new EventHandler(ThreePanelMenuGroupEvent));
                                }
                            }
                        }
                    }
                    outlookBarLeftMenu.AddBand(currClsMainMenuVoGroup.menuGroup, currIconPanel);
                    mainMenuGroupNum++;
                }
                outlookBarLeftMenu.SelectBand(0);
                this.Controls.Add(outlookBarLeftMenu);
            }
            
            #endregion
        }
        /// <summary>
        /// 第一组ONU工具集子菜单的点击逻辑，比如有第一组Panel下有三个子菜单，则顺序对应的点击索引为0、1、2，然后添加点击事件的具体逻辑代码即可
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnePanelMenuGroupEvent(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            PanelIcon panelIcon = ctrl.Tag as PanelIcon;
            string clickInfo = string.Empty;
            switch (panelIcon.Index)
            {
                case 0:
                    clickInfo = "ONU设备用户信息查询";
                    if (ClsFrmMainApplicationLeftMenuEvent.LeftMenuClick2OnuDevInfoOnUserTool != null)
                    {
                        ClsFrmMainApplicationLeftMenuEvent.LeftMenuClick2OnuDevInfoOnUserTool(sender,e);
                    }
                    break;
                case 1:
                    clickInfo = "其他";
                    break;
            }
        }
        /// <summary>
        /// 第二组其他工具集的子菜单点击逻辑，比如有第一组Panel下有三个子菜单，则顺序对应的点击索引为0、1、2，然后添加点击事件的具体逻辑代码即可
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TwoPanelMenuGroupEvent(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            PanelIcon panelIcon = ctrl.Tag as PanelIcon;
            string clickInfo = string.Empty;
            switch (panelIcon.Index)
            {
                case 0:
                    clickInfo = "其他1";
                    break;
                case 1:
                    clickInfo = "其他2";
                    break;
            }
        }
        /// <summary>
        /// 第三组其他工具集的子菜单点击逻辑，当前此方法为预留方法，便于后续维护
        /// 比如有第一组Panel下有三个子菜单，则顺序对应的点击索引为0、1、2，然后添加点击事件的具体逻辑代码即可
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ThreePanelMenuGroupEvent(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            PanelIcon panelIcon = ctrl.Tag as PanelIcon;
            string clickInfo = string.Empty;
            switch (panelIcon.Index)
            {
                case 0:
                    clickInfo = "其他1";
                    break;
                case 1:
                    clickInfo = "其他2";
                    break;
            }
        }
    }
}
