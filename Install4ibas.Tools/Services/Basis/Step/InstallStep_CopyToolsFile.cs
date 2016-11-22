using Install4ibas.Tools.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_CopyToolsFile : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "CopyToolsFile";
        const string STEPNAME = "拷贝工具文件";

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
                FileOperation.CopyToolsFiles(this.AppSetting.InstallDiraddress);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

    }
}
