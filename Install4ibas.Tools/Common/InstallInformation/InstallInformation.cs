using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Install4ibas.Tools.Common.InstallInformation
{
    [DataContract(Namespace = "http://ibas.club/install")]
    public class InstallInformation
    {
        [DataMember]
       public IList<InstallInformationStep> Steps;

        public IList<ibasModule> InstallModules;
    }

    public class InstallInformationStep
    {
        public bool Completed;
        public string StepCode;
        public string StepName;
    }
    
}
