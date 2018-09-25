using OnuDevInfoOnUserModel.UctrlJqmkjMainApplication.EventClass;
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
        /// 事件加载的方法
        /// </summary>
        public void FrmMainApplicationLeftMenuEventMethodLoad()
        {
            ClsFrmMainApplicationLeftMenuEvent.LeftMenuClick2OnuDevInfoOnUserTool = LeftMenuClick2OnuDevInfoOnUserToolEventImpl;
        }

        #region 事件方法的具体实现
        /// <summary>
        /// 左侧菜单：ONU设备用户侧信息工具 点击逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftMenuClick2OnuDevInfoOnUserToolEventImpl(object sender, EventArgs e)
        {
            FrmOnuDevInfoOnUserToolMain frmOnuDevInfoOnUserToolMain = new FrmOnuDevInfoOnUserToolMain();
            PanelMainPageShowOptFrmMethod(frmOnuDevInfoOnUserToolMain);
        }
        #endregion

        #region 窗体中控件的方法实现
        /// <summary>
        /// 隐藏与显示左侧菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboxIsShow_Click(object sender, EventArgs e)
        {
            try
            {
                if ("hideMenu".Equals(this.pboxIsShow.Tag))
                {
                    this.pboxIsShow.Text = "显示菜单";
                    this.pboxIsShow.Tag = "showMenu";
                    this.pboxIsShow.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.menu_show;
                    this.uctrlFrmMainApplicationLeftMenu1.Hide();
                    return;
                }
                if ("showMenu".Equals(this.pboxIsShow.Tag))
                {
                    this.pboxIsShow.Text = "隐藏菜单";
                    this.pboxIsShow.Tag = "hideMenu";
                    this.pboxIsShow.Image = global::OnuDevInfoOnUserViewImpl.Properties.Resources.menu_hide;
                    this.uctrlFrmMainApplicationLeftMenu1.Show();
                    return;
                }
            }
            catch (Exception ex)
            {
                m_log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 左侧Panel的点击事件，判断是否隐藏菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMenuShowHide_Click(object sender, EventArgs e)
        {
            pboxIsShow_Click(sender, e);
        }
        #endregion

        #region 辅助方法
        /// <summary>
        ///左侧菜单各个子菜单统一点击显示页面方法逻辑
        /// </summary>
        /// <param name="thisShowOptFrm"></param>
        public void PanelMainPageShowOptFrmMethod(Form thisShowOptFrm)
        {
            //不是同一个窗体页面则当前工具主窗体页面销毁释放资源
            if (m_lastShowOptFrm != null)
            {
                //判断是否是同一个窗体页面,是则不用再做任何操作
                if (thisShowOptFrm.Name.Equals(m_lastShowOptFrm.Name) == true)
                {
                    return;
                }
                m_lastShowOptFrm.Dispose();
                m_lastShowOptFrm = null;
            }
            this.panelMainRight.Controls.Clear();
            thisShowOptFrm.FormBorderStyle = FormBorderStyle.None; //隐藏子窗体边框（去除最小花，最大化，关闭等按钮）
            thisShowOptFrm.TopLevel = false; //指示子窗体非顶级窗体
            thisShowOptFrm.Dock = DockStyle.Fill;//最大化显示窗体
            this.panelMainRight.Controls.Add(thisShowOptFrm);//将子窗体载入panel
            //记录当前打开的窗体,用于释放资源
            m_lastShowOptFrm = thisShowOptFrm;
            thisShowOptFrm.Show();
        }
        #endregion
    }
}
