﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_WebconfigEdit : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "WebconfigEdit";
        const string STEPNAME = "编辑Webconfig";

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
