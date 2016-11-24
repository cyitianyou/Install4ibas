using Install4ibas.Tools.Core;
using Install4ibas.Tools.Plugin;
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

        bool Excute(bool isFirstRun=true);

        MessageManager MessageManager { get; set; }
    }
}
