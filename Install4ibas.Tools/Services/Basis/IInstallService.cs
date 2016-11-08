using Install4ibas.Tools.Common.InstallInformation;
using Install4ibas.Tools.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    public interface IInstallService
    {
        AppSetting AppSetting { get; }

        bool Excute();

        event ServiceEventHandle UpdateInstallationScheduleEvent;
    }
}
