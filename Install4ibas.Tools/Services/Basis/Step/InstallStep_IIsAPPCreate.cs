using Install4ibas.Tools.Plugin.IISManager;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_IIsAPPCreate : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "IIsAPPCreate";
        const string STEPNAME = "创建应用程序";

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
            try
            {
                //TODO:添加逻辑代码
                var manager = IISManagerFactory.New().CreateIISManager();
                Site site = manager.GetSite(this.AppSetting.SiteName);
                if (site == null) throw new Exception("网站未找到");
                foreach (var item in this.AppSetting.InstallModules
                                                        .Where(c=>c.Checked 
                                                            && c.Status==Tools.Core.emInstallStatus.notInstalled
                                                            && !string.IsNullOrEmpty( c.ModuleInstallPath)))
                {
                    manager.CreateApplication(item.ModuleName, site, string.Format("/{0}", item.ModuleName), Path.Combine(this.AppSetting.InstallDiraddress, item.ModuleName), this.AppSetting.SiteName);
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
