﻿using BTulz.ModelsTransformer.Transformer;
using Install4ibas.Tools.Plugin.DbManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_ServicesInforEdit : BasicInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "ServicesInforEdit";
        const string STEPNAME = "安装ServicesInformation配置文件";

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
                var dbTrans = new DbTransformer();
                dbTrans.DBTypeSign = this.AppSetting.DatabaseType;
                dbTrans.SetMySQLMap(new SQLMapFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetSQLMap(dbTrans.DBTypeSign));
                dbTrans.SetDB(new dbConnectionFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetDBConnection(dbTrans.MySQLMap));
                DataTable moduleinfor = SQLExecute.RunSQLGetTable("", dbTrans);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

    }
}
