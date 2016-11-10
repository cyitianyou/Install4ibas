using Install4ibas.Tools.Plugin.FileOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_CopyModuleFile: IInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "CopyModuleFile";
        const string STEPNAME = "复制模块安装文件";

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
            FileOperation.CopyModules(this.AppSetting.SourcePackageDir, this.AppSetting.InstallDiraddress, this.AppSetting.InstallModules);
            return true;
        }
    
    }
}
