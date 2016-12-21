﻿using Install4ibas.Tools.Plugin.DbManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_CopyModuleFile : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "CopyModuleFile";
        const string STEPNAME = "复制模块包";

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
            //TODO:添加逻辑代码
            var InstallDiraddress = Path.Combine(this.AppSetting.InstallDiraddress, "~packages");
            var Modules = this.AppSetting.InstallModules;
            var SourcePath = this.AppSetting.SourcePackageDir;
            if (!Directory.Exists(InstallDiraddress))
                Directory.CreateDirectory(InstallDiraddress);
            foreach (var module in Modules.Where(c => c.Checked))
            {
                if (File.Exists(Path.Combine(SourcePath, module.PackageFileName)))
                {
                    module.ModuleInstallPath = Path.Combine(this.AppSetting.InstallDiraddress, module.ModuleName);
                    File.Copy(Path.Combine(SourcePath, module.PackageFileName), Path.Combine(InstallDiraddress, module.PackageFileName));
                }
            }
        }

    }
}
