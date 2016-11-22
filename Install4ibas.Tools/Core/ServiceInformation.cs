using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Core
{
    public class ServiceInformation
    {
        public string ServiceName
        {
            set;
            get;
        }

        public string ModuleID
        {
            set;
            get;
        }

        public string ServiceDescription
        {
            set;
            get;
        }

        public string BOServiceContract
        {
            set;
            get;
        }

        public string BOServiceBindingConfiguration
        {
            set;
            get;
        }

        public string ServicePath
        {
            set;
            get;
        }

        public void SetInformations(string info)
        {
            if (string.IsNullOrEmpty(info))
                return;
            var tmps = info.Split('.');
            if (tmps.Length > 1)
            {
                this.ServiceName = tmps[1];
                this.ServicePath = this.ServiceName;
                this.BOServiceContract = string.Format("BORep.{0}.BORepository.IBORep{0}Service", this.ServiceName);
                this.BOServiceBindingConfiguration = "BasicHttpBinding";
                if (this.ServiceName == "SystemApplicationCenter"
                    || this.ServiceName == "ApprovalProcess")
                {
                    this.ServicePath = "SystemCenter";
                    this.BOServiceContract = string.Format("BORep.{0}.BORepository.IBORep{0}Service", "BusinessSystemCenter");
                }
            }
        }
    }
}
