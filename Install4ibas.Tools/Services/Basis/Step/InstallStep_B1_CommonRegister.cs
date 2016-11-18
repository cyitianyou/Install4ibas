using BTulz.ModelsTransformer.Transformer;
using Install4ibas.Tools.Common.InstallInformation;
using Install4ibas.Tools.Plugin.DbManager;
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
                if ((this.GetCurrentDBType() == emDatabaseType.mssql || this.GetCurrentDBType() == emDatabaseType.hana) && !string.IsNullOrEmpty(this.AppSetting.B1User))
                    this.CreateAddonConfig();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        emDatabaseType GetCurrentDBType()
        {
            if (this.AppSetting.DatabaseType != null)
            {
                if (this.AppSetting.DatabaseType.StartsWith("HANA"))
                    return emDatabaseType.hana;
                if (this.AppSetting.DatabaseType.StartsWith("MSSQL"))
                    return emDatabaseType.mssql;
                if (this.AppSetting.DatabaseType.StartsWith("MYSQL"))
                    return emDatabaseType.mysql;
                if (this.AppSetting.DatabaseType.StartsWith("ORACLE"))
                    return emDatabaseType.oracle;
                if (this.AppSetting.DatabaseType.StartsWith("PostgreSQL"))
                    return emDatabaseType.pgsql;

            }
            return emDatabaseType.all;
        }

        private void CreateAddonConfig()
        {
            try
            {
                var sqlTrans = new SqlTransformer();
                sqlTrans.DBTypeSign = this.AppSetting.DatabaseType;
                var sqlMap = new SQLMapFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, "SBO-COMMON").GetSQLMap(sqlTrans.DBTypeSign);
                sqlMap.DefaultDatabase = string.Empty;
                sqlTrans.SetDB(new dbConnectionFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, "SBO-COMMON").GetDBConnection(sqlMap));
                var encoding = System.Text.Encoding.UTF8;
                string sqlStr;
                if (string.IsNullOrEmpty(this.AppSetting.IISAddress) || string.IsNullOrEmpty(this.AppSetting.IISPort))
                    sqlStr = string.Format(@"delete from ""AVA_ADDON_CONFIG"" where ""dbName""='BSUi.BusinessSystemCenter.B1Addon.exe.config'");
                else
                    sqlStr = string.Format(@"delete from ""AVA_ADDON_CONFIG"" where ""dbName""='{0}.{1}.BSUi.BusinessSystemCenter.B1Addon.exe.config'", this.AppSetting.DBName, this.AppSetting.DBServer);
                sqlTrans.AddScriptString(sqlStr);

                string AddonConfig = string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
                                                                                    <configuration>
                                                                                        <appSettings>
                                                                                            <!-- 开启业务仓库服务路由-->
                                                                                            <add key=""BOServiceRouting"" value=""true"" />
                                                                                        </appSettings>
                                                                                        <system.serviceModel>
                                                                                            <bindings>
                                                                                                <basicHttpBinding>
                                                                                                    <binding name=""BasicHttpBinding"" closeTimeout=""00:59:59"" openTimeout=""00:59:59"" receiveTimeout=""00:59:59"" sendTimeout=""00:59:59"" maxBufferSize=""2147483647"" maxReceivedMessageSize=""2147483647"" textEncoding=""utf-8"" transferMode=""Buffered"">
                                                                                                    </binding>
                                                                                                </basicHttpBinding>
                                                                                            </bindings>
                                                                                            <client>
                                                                                                <endpoint address=""{0}:{1}/SystemCenter/DataService/SystemCenter.svc"" binding=""basicHttpBinding"" bindingConfiguration=""BasicHttpBinding"" contract=""BORep.BusinessSystemCenter.BORepository.IBORepBusinessSystemCenterService"" name=""BasicHttpBinding_BORepBusinessSystemCenter"" />
                                                                                            </client>
                                                                                        </system.serviceModel>
                                                                                    </configuration>", this.AppSetting.IISAddress, this.AppSetting.IISPort);
                if (string.IsNullOrEmpty(this.AppSetting.IISAddress) || string.IsNullOrEmpty(this.AppSetting.IISPort))
                    sqlStr = string.Format(@"insert into ""AVA_ADDON_CONFIG"" values ('BSUi.BusinessSystemCenter.B1Addon.exe.config',N'{2}',GETDATE())");
                else
                    sqlStr = string.Format(@"insert into ""AVA_ADDON_CONFIG"" values ('{0}.{1}.BSUi.BusinessSystemCenter.B1Addon.exe.config',N'{2}',GETDATE())", this.AppSetting.DBName, this.AppSetting.DBServer, AddonConfig);
                sqlTrans.AddScriptString(sqlStr);
                sqlTrans.Run();
            }
            catch (Exception err)
            {
                throw new Exception(string.Format("配置AddonConfig失败.{0}", err.Message));
            }
        }
    }
}
