using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Install4ibas.Tools.Common.InstallInformation
{
    [DataContract(Namespace = "http://ibas.club/install")]
    public class AppSetting
    {
        [DataMember]
        public IList<InstallInformationStep> Steps;

        public IList<ibasModule> InstallModules;
    }
    [DataContract]
    public class InstallInformationStep
    {
        [DataMember]
        public bool Completed;
        [DataMember]
        public string StepCode;
        [DataMember]
        public string StepName;
    }

}
