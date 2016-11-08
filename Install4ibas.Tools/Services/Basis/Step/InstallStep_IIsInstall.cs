using Install4ibas.Tools.Plugin.IISManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_IIsInstall : IInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "";
        const string STEPNAME = "";

        public string StepCode
        {
            get { return STEPCODE; }
        }

        public string StepName
        {
            get { return STEPNAME; }
        }

        public Tools.Common.InstallInformation.AppSetting AppSetting
        {
            get;
            set;
        }
        #endregion
        public bool Excute()
        {
            try
            {
                IIISManager manager = IISManagerFactory.New().CreateIISManager();
                if (!manager.IsFullyInstalled())
                    manager.InstallIIS();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }
    }
}
