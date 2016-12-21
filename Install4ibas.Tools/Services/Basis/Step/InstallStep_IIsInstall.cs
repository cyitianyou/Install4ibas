using Install4ibas.Tools.Plugin.IISManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_IIsInstall : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "IIsInstall";
        const string STEPNAME = "安装IIS";

        public override string StepCode
        {
            get { return STEPCODE; }
        }

        public override string StepName
        {
            get { return STEPNAME; }
        }

        #endregion
         public override void Excute()
        {
            try
            {
                IIISManager manager = IISManagerFactory.New().CreateIISManager();
                if (!manager.IsFullyInstalled())
                    manager.InstallIIS();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
