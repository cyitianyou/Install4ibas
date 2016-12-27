using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Install4ibas.UI
{
    public partial class FinishControl : ChildControl
    {
        public FinishControl()
        {
            InitializeComponent();
        }
        public override void Initialize()
        {
            this.FinishEvent += FinishControl_FinishEvent;
        }

        void FinishControl_FinishEvent(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否现在创建License?", "", MessageBoxButtons.YesNo) == DialogResult.OK)
                this.ShellControl.SetCurrentControl(ControlTypes.LicenseCreateControl);
            else
                Application.Exit();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = UI.ButtonsVisibleStyle.Finish;
        }

        public override void LoadAppSetting()
        {
            if (!this.ShellControl.installService.AppSetting.isSuccess)
            {
                this.label1.Text = "安装失败！";
                this.link_License.Visible = false;
            }
        }

        private void link_License_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.ShellControl.installService.AppSetting.UpdateLicense();
                this.ShellControl.SetCurrentControl(ControlTypes.LicenseCreateControl);
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("获取网站信息生成License出错,错误如下:[{0}]", error.Message));
            }
            
        }
    }
}
