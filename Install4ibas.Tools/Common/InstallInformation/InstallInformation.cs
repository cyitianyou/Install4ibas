using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Common.InstallInformation
{
    public class InstallInformation
    {
       public IList<InstallInformationStep> Steps;
    }

    public class InstallInformationStep
    {
        public bool Completed;
        public string StepCode;
        public string StepName;
    }
}
