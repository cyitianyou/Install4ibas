using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Services.Basis.Step
{
    public class BasicInstallStep : IInstallStep
    {
        public virtual string StepCode
        {
            get { return ""; }
        }

        public virtual string StepName
        {
            get { return ""; }
        }

        public Tools.Core.AppSetting AppSetting
        {
            get;
            set;
        }

        public virtual void Excute()
        {
        }
        
        public Plugin.MessageManager MessageManager
        {
            get
            {
                return Plugin.MessageManager.Instance;
            }
            
        }
    }
}
