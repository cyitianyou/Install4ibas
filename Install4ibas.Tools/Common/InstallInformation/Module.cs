using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Common.InstallInformation
{
  public  class ibasModule
    {
        public String ModuleName
        {
            set;
            get;
        }
        public String ModuleDescription
        {
            set;
            get;
        }
        public String ModuleId
        {
            set;
            get;
        }
        public String ModuleInstallPath
        {
            set;
            get;
        }
        public bool IsShell
        {
            set;
            get;
        }

        public bool IsInstalled
        {
            set;
            get;
        }
    }
}
