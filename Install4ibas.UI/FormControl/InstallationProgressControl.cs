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
    public partial class InstallationProgressControl : ChildControl
    {
        public InstallationProgressControl()
        {
            InitializeComponent();
        }
        protected override void SetButtonsVisibleStyle()
        {
            this.ButtonsVisibleStyle = UI.ButtonsVisibleStyle.Cancel;
        }

        public override void Initialize()
        {
            this.ShellControl.installService.MessageManager.UpdateInstallationScheduleEvent += installService_UpdateInstallationScheduleEvent;
            this.ShellControl.installService.AppSetting.isSuccess = ExcuteService();
            this.ShellControl.SetCurrentControl(ControlTypes.Finish);
        }

        bool ExcuteService()
        {
            try
            {
                this.ShellControl.installService.Excute();
                return true;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(string.Format("{0}\n是否重新安装?", ex.Message), "出错了!", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                    return ExcuteService();
                else
                    return false;
            }
        }

        void installService_UpdateInstallationScheduleEvent(object sender, Tools.Core.ServiceEventArgs e)
        {
            Application.DoEvents();
            if(e.Error!=null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            if (e.ScheduleValue > 0 && e.ScheduleValue <= 100) this.progressBar.Value = e.ScheduleValue;
            this.lab_Msg.Text = e.Message;
            Application.DoEvents();
        }

    }
}
