using Install4ibas.Tools.Core.InstallInformation;
using Install4ibas.Tools.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    public interface IInstallService
    {
        string ServiceCode { get; }
        AppSetting AppSetting { get; }

        bool Excute();

        event ServiceEventHandle UpdateInstallationScheduleEvent;
    }
}
