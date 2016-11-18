using Install4ibas.Tools.Plugin.FileOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_ExecuteBat : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "ExecuteBat";
        const string STEPNAME = "执行发布脚本";

        public override string StepCode
        {
            get { return STEPCODE; }
        }

        public override string StepName
        {
            get { return STEPNAME; }
        }

        #endregion
        public override bool Excute()
        {
            try
            {
                //TODO:添加逻辑代码
                FileOperation.RunBatFile(System.IO.Path.Combine(this.AppSetting.InstallDiraddress, "deploy_ibas_web_services.bat"));
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

    }
}
