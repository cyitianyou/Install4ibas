using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Install4ibas.Tools.Plugin.IISManager;

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

        void InstallationOptionsControl_NextEvent(object sender, EventArgs e)
        {
            //this.ShellControl.SetCurrentControl(ControlTypes.LicenseAccept);
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
