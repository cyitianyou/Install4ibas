using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Services.Basis.Step
{
    public class BasicInstallStep : IInstallStep
    {
        public virtual string StepCode
        {
            get { return ""; }
        }

        public virtual string StepName
        {
            get { return ""; }
        }

        public Tools.Common.InstallInformation.AppSetting AppSetting
        {
            get;
            set;
        }

        public virtual bool Excute()
        {
            return true;
        }

        public event Common.ServiceEventHandle UpdateInstallationScheduleEvent;
        private void OnUpdateInstallationSchedule(object sender, Install4ibas.Tools.Services.Common.ServiceEventArgs args)
        {
            if (this.UpdateInstallationScheduleEvent != null)
            {
                this.UpdateInstallationScheduleEvent.Invoke(sender, args);
            }
        }
    }
}
