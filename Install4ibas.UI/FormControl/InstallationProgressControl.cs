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
        private delegate void BetweenThreadsDelegate(Tools.Core.ServiceEventArgs e);
        BetweenThreadsDelegate callBack ;
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
            callBack = new BetweenThreadsDelegate(Control_Event);
            this.ShellControl.installService.MessageManager.UpdateInstallationScheduleEvent += MessageManager_Event;
            this.ShellControl.installService.MessageManager.WriteMessageLogEvent += MessageManager_Event;
            this.ShellControl.installService.AppSetting.isSuccess = ExcuteService();
            this.ShellControl.SetCurrentControl(ControlTypes.Finish);
        }
        
        void MessageManager_Event(object sender, Tools.Core.ServiceEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(callBack, e);
                    Application.DoEvents();
                }
                else
                {
                    Control_Event(e);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        void Control_Event(Tools.Core.ServiceEventArgs e)
        {
            Application.DoEvents();
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            if (e.EventType == Tools.Core.EventType.WriteMessageLog)
            {
                this.lab_Msg.Text = e.Message;
            }
            else if (e.EventType == Tools.Core.EventType.UpdateInstallationSchedule)
            {
                if (e.ScheduleValue > 0 && e.ScheduleValue <= 100) this.progressBar.Value = e.ScheduleValue;
                this.lab_Schedule.Text = e.Message;
            }
            Application.DoEvents();
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


    }
}
