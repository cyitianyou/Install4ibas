using Install4ibas.Tools.Common.InstallInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    public interface IInstallStep
    {
        string StepCode { get; }
        string StepName { get; }
        AppSetting AppSetting { get; set; }

        bool Excute();

        event Common.ServiceEventHandle UpdateInstallationScheduleEvent;
    }
}
