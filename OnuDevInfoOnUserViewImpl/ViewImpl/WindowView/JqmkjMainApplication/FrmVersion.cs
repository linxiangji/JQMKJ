using OnuDevInfoOnUserModel.VoClass;
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
    public partial class FrmVersion : Form
    {
        #region 变量
        private ClsVersionVo m_versionVo = null;
        #endregion

        #region 加载与构造方法
        public FrmVersion(ClsVersionVo versionVo)
        {
            InitializeComponent();
            this.m_versionVo = versionVo;
        }

        private void FrmVersion_Load(object sender, EventArgs e)
        {
            this.uctrlFrmVersionLayout1.LblApplicationName.Text = m_versionVo.applicationName;
            this.uctrlFrmVersionLayout1.LblVersionNum.Text = m_versionVo.versionNum;
            this.uctrlFrmVersionLayout1.LblCompileTime.Text = m_versionVo.compileTime;
            this.uctrlFrmVersionLayout1.LblCopyright.Text = m_versionVo.copyright;
            this.uctrlFrmVersionLayout1.LblCompanyName.Text = m_versionVo.compangyName;
            this.uctrlFrmVersionLayout1.LblWebsiteAddress.Text = m_versionVo.websiteAddress;

        }
        #endregion

        #region 方法的实现

        #endregion
    }
}
