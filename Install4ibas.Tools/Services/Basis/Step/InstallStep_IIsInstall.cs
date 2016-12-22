using Install4ibas.Tools.Plugin.IISManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            if (System.Environment.Is64BitProcess)
            {
                IIISManager manager = IISManagerFactory.New().CreateIISManager();
                if (!manager.IsFullyInstalled())
                    manager.InstallIIS();
            }
            else
            {
              var  proc = new Process();
              proc.StartInfo.FileName = Path.Combine(System.Environment.CurrentDirectory, "Install4IIS.exe");
              proc.StartInfo.WorkingDirectory = System.Environment.CurrentDirectory;
              // proc.StartInfo.Arguments = string.Format("10");//this is argument
              proc.StartInfo.CreateNoWindow = false;
              proc.StartInfo.UseShellExecute = true;
            }
        }

    }
}
