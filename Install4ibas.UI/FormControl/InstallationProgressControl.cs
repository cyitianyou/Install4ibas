using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Install4ibas.Tools.Plugin.Messages;
using System.IO;

namespace Install4ibas.UI
{
    public partial class InstallationProgressControl : ChildControl
    {
        private delegate void BetweenThreadsDelegate(Tools.Core.ServiceEventArgs e);
        BetweenThreadsDelegate callBack;
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
            this.ShellControl.installService.MessageManager.WriteFileLogEvent += MessageManager_WriteFileLogEvent;
            this.ShellControl.installService.AppSetting.isSuccess = ExcuteService();
            this.ShellControl.SetCurrentControl(ControlTypes.Finish);
        }
        private FileMessageRecorder FileRecorder
        {
            get
            {
                return FileMessageRecorder.Instance;
            }
            set
            {
                FileMessageRecorder.Instance = value;
            }
        }
        void MessageManager_WriteFileLogEvent(object sender, Tools.Core.ServiceEventArgs args)
        {
            if (args.Error != null)
                FileRecorder.Recording(args.Error);
            else
                FileRecorder.Recording(args.MessageType, args.Message);
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
            catch (Exception ex)
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


        int count;
        string dateString;
        bool ExcuteService(bool isFirstRun = true)
        {
            if (isFirstRun)
            {
                count = 1;
                dateString=DateTime.Now.ToString("yyyyMMdd_HHmmss");
            }
            else
                count++;
            try
            {
                this.FileRecorder.WorkFileName = string.Format("deploy_ibas_log_{0}_{1}.log", dateString,count);
                this.FileRecorder.WorkFolder = Path.Combine(this.ShellControl.installService.AppSetting.InstallDiraddress, "~packages","Log");
                this.ShellControl.installService.Excute(isFirstRun);
                return true;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(string.Format("{0}\n是否重新安装?", ex.Message), "出错了!", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                    return ExcuteService(false);
                else
                    return false;
            }
        }


    }
}
