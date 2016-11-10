using BTulz.ModelsTransformer.Transformer;
using Install4ibas.Tools.Plugin.DbManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_ServicesInforEdit : IInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "ServicesInforEdit";
        const string STEPNAME = "安装ServicesInformation配置文件";

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
            var dbTrans = new DbTransformer();
            dbTrans.DBTypeSign = this.AppSetting.DatabaseType;
            dbTrans.SetMySQLMap(new SQLMapFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetSQLMap(dbTrans.DBTypeSign));
            dbTrans.SetDB(new dbConnectionFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetDBConnection(dbTrans.MySQLMap));
            DataTable moduleinfor = SQLExecute.RunSQLGetTable("", dbTrans);
            return true;
        }
    }
}
