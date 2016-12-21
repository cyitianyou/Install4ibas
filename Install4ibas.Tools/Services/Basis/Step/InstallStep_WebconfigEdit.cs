﻿using Install4ibas.Tools.Plugin;
using Install4ibas.Tools.Plugin.DbManager;
using System;
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
        public override void Excute()
        {
            var sqlmap = new SQLMapFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetSQLMap(this.AppSetting.DatabaseType);
            var connection = new dbConnectionFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetDBConnection(sqlmap);
            ServiceInformationCreator ServiceInforC = new ServiceInformationCreator();
            ServiceInforC.SetDBConnection(connection);
            ServiceInforC.MyAppsetting = this.AppSetting;
            ServiceInforC.RootAddress = this.AppSetting.IISAddress + ":" + this.AppSetting.IISPort;
            ServiceInforC.WorkFolder = this.AppSetting.InstallDiraddress;
            ServiceInforC.CreateWebConfig();
        }

    }
}
