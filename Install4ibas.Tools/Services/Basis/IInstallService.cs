using Install4ibas.Tools.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    public interface IInstallService
    {
        InstallInformation AppSetting { get; }

        bool Excute();

        event ServiceEventHandle UpdateInstallationScheduleEvent;
    }
}
