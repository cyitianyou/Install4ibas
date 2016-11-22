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
            this.ShellControl.installService.UpdateInstallationScheduleEvent += installService_UpdateInstallationScheduleEvent;
            this.ShellControl.installService.Excute();
            this.ShellControl.SetCurrentControl(ControlTypes.Finish);
        }

        void installService_UpdateInstallationScheduleEvent(object sender, Tools.Services.Core.ServiceEventArgs e)
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
