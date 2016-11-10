using System;
using Install4ibas.Tools.Plugin.IISManager;
using Install4ibas.Tools.Services.NewInstall;

namespace Install4ibas.UI
{
    public partial class LicenseAcceptControl : ChildControl
    {
        public LicenseAcceptControl()
        {
            InitializeComponent();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Cancel | ButtonsVisibleStyle.NextEnable;
        }
        public override void Initialize()
        {
            this.NextEvent += LicenseAcceptControl_NextEvent;
        }

        void LicenseAcceptControl_NextEvent(object sender, EventArgs e)
        {
            #region 判断服务器上是否存在ibas网站(IIS未安装,同样认为是不存在ibas网站)
            bool existsIbasSite = false;
            try
            {
                var manager = IISManagerFactory.New().CreateIISManager();
                var list = manager.GetSiteNames();
                if (list.Count > 0)
                    existsIbasSite = true;
            }
            catch (Exception)
            {
            }
            #endregion
            if (existsIbasSite)
            {
                this.ShellControl.SetCurrentControl(ControlTypes.InstallationOptions);
            }
            else
            {
                var code = NewInstallService.SERVICECODE;
                if (this.ShellControl.installService == null //服务未创建
               || !this.ShellControl.installService.ServiceCode.Equals(code)) //上一步至此页面,服务被更改
                    this.ShellControl.installService = Install4ibas.Tools.Services.ServicesFactory.New().GetService(code);
                this.ShellControl.SetCurrentControl(ControlTypes.ModulesChoose);
            }
        }
    }
}
