using Install4ibas.Tools.Plugin.FileOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_ExecuteBat : IInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "ExecuteBat";
        const string STEPNAME = "执行发布脚本";

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
            FileOperation.RunBatFile(this.AppSetting.InstallDiraddress + "deploy_ibas_web_services.bat");
            return true;
        }
    }
}
