using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_B1_CommonRegister : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "B1_CommonRegister";
        const string STEPNAME = "B1_Common库中注册";

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
