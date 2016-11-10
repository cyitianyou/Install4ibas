using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Install4ibas.Tools.Plugin.IISManager;
using Install4ibas.Tools.Services.NewInstall;
using Install4ibas.Tools.Services.AppendInstall;
using Install4ibas.Tools.Services.License;

namespace Install4ibas.UI
{
    public partial class InstallationOptionsControl : ChildControl
    {
        public InstallationOptionsControl()
        {
            InitializeComponent();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = ButtonsVisibleStyle.Cancel | ButtonsVisibleStyle.NextEnable;
        }
        protected override void InitializeEvent()
        {
            this.NextEvent += InstallationOptionsControl_NextEvent;
        }
        public override void LoadAppSetting()
        {
            if (this.ShellControl.installService != null)
            {
                switch (this.ShellControl.installService.ServiceCode)
                {
                    case NewInstallService.SERVICECODE:
                        this.radio_New.Checked = true;
                        break;
                    case AppendInstallService.SERVICECODE:
                        this.radio_Append.Checked = true;
                        break;
                    case LicenseInstallService.SERVICECODE:
                        this.radio_License.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public override void SaveAppSetting()
        {
            var code = this.radio_New.Checked ? NewInstallService.SERVICECODE :
                       this.radio_Append.Checked ? AppendInstallService.SERVICECODE :
                       this.radio_License.Checked ? LicenseInstallService.SERVICECODE : "";
            if (this.ShellControl.installService == null //服务未创建
                || !this.ShellControl.installService.ServiceCode.Equals(code)) //上一步至此页面,服务被更改
                this.ShellControl.installService = Install4ibas.Tools.Services.ServicesFactory.New().GetService(code);
            if (!this.ShellControl.installService.ServiceCode.Equals(NewInstallService.SERVICECODE))
            {
                this.ShellControl.installService.AppSetting.SiteName = Convert.ToString(this.cmb_Sites.SelectedItem);
                this.ShellControl.installService.AppSetting.LoadSiteName();
            }
        }

        void InstallationOptionsControl_NextEvent(object sender, EventArgs e)
        {
            try
            {
                var type = ControlTypes.ModulesChoose;
                if (!(this.radio_New.Checked
                        | this.radio_Append.Checked
                        | this.radio_License.Checked)
                    ) throw new Exception("请选择要执行的操作。");  //都没选中
                if (!this.radio_New.Checked && String.IsNullOrEmpty(Convert.ToString(this.cmb_Sites.SelectedItem)))
                    throw new Exception("请选择已安装的ibas网站。");
                if (this.radio_License.Checked) ;//TODO:此处跳转到License管理后续流程

                this.ShellControl.SetCurrentControl(type);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var radio = sender as RadioButton;
                if (radio == null) return;
                if (!radio.Checked) return;
                if (radio.Name == this.radio_New.Name)
                {
                    this.editSitesControls(false);
                }
                else
                {
                    this.editSitesControls(true, radio.Top);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void editSitesControls(bool visible, int top = 190)
        {
            if (visible)
            {
                this.label_Sites.Top = top + 2;
                this.cmb_Sites.Top = top - 2;
                if (this.cmb_Sites.Items.Count <= 1)
                    loadSitesInfo();
            }
            this.label_Sites.Visible = visible;
            this.cmb_Sites.Visible = visible;

        }

        private void loadSitesInfo()
        {
            this.cmb_Sites.Items.Clear();
            this.cmb_Sites.Items.Add("");
            var manager = IISManagerFactory.New().CreateIISManager();
            var list = manager.GetSiteNames();
            foreach (var item in list)
            {
                this.cmb_Sites.Items.Add(item);
            }
            if (this.cmb_Sites.Items.Count == 1)
                throw new Exception("当前服务器未找到已部署的ibas网站,无法执行此操作.");
        }
    }
}
