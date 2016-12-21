using Install4ibas.Tools.Core;
using Install4ibas.Tools.Plugin;
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

        void Excute();

        MessageManager MessageManager { get; }
    }
}
