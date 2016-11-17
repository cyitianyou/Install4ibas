using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_IIsWebsiteCreate : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "IIsWebsiteCreate";
        const string STEPNAME = "创建网站和应用程序池";

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
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

    }
}
