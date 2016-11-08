using BTulz.ModelsTransformer.Transformer;
using Install4ibas.Tools.Common.InstallInformation;
using Install4ibas.Tools.Plugin.DbManager;
using Install4ibas.Tools.Plugin.FileOperation;
using ModelTransformer.Transformer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    class InstallStep_DbCreate : IInstallStep
    {
        #region 常量,变量
        const string STEPCODE = "DbCreate";
        const string STEPNAME = "创建数据库";

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
        bool B1Included { get { return string.IsNullOrEmpty(this.AppSetting.B1User) ? false : true; } }
 
        public bool Excute()
        {
            var shell= this.AppSetting.InstallModules.Where(c => c.ModuleName == "shell").FirstOrDefault();
            var dsGetter = new DataStructuresGetter();
            dsGetter.WorkFolder = shell.ModuleInstallPath;
            var dsItems = dsGetter.Get();
            dsGetter.AutoSelected(this.B1Included, this.AppSetting.DatabaseType, dsItems);
            return true;
        }
        private void ModuleToDB(ibasModule module)
        {
            try
            {
                var dsGetter = new DataStructuresGetter();
                dsGetter.WorkFolder = module.ModuleInstallPath;
                var dsItems = dsGetter.Get();
                dsGetter.AutoSelected(this.B1Included, this.AppSetting.DatabaseType, dsItems);
                if (dsItems == null) return;
             
                var logPath = string.Format(@"{0}Log\data_structures_{1}.txt", System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMddhhmmss"));
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(logPath))) System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(logPath));

                var gpDSItems = new Dictionary<string, List<DataStructureItem>>();
                foreach (var item in dsItems.Where(c => c.Selected))
                {
                    if (gpDSItems.ContainsKey(item.Group))
                        gpDSItems[item.Group].Add(item);
                    else
                        gpDSItems.Add(item.Group, new List<DataStructureItem>() { item });
                }

                using (var logFile = System.IO.File.CreateText(logPath))
                {
                    logFile.WriteLine(string.Format("folder：{0}", this.AppSetting.InstallDiraddress));
                    foreach (var gpKey in gpDSItems.Keys)
                    {
                        List<string> files = null;
                        logFile.WriteLine(string.Format(" group：{0}", gpKey));
                        #region 数据结构创建
                        #region ibas
                        files = new List<string>();
                        foreach (var item in gpDSItems[gpKey].Where(c => c.ItemType == emDSItemType.data_structure
                            && c.Platform == emPlatform.ibas))
                        {
                            logFile.WriteLine(string.Format("  file：{0}", item.FilePath));
                            files.Add(item.FilePath);
                        }
                        if (files.Count > 0)
                        {
                            var xmlTrans = new XmlTransformer();
                            var ibasModel = xmlTrans.ToDomainModel(files.ToArray());
                            if (xmlTrans.HasError)
                                throw xmlTrans.ErrorLogs.FirstOrDefault();

                            var dbTrans = new DbTransformer();
                            dbTrans.DBTypeSign = this.AppSetting.DatabaseType;
                            dbTrans.SetMySQLMap(new SQLMapFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetSQLMap(dbTrans.DBTypeSign));
                            dbTrans.SetDB(new dbConnectionFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetDBConnection(dbTrans.MySQLMap));
                            dbTrans.ToDB(ibasModel);

                            if (dbTrans.HasError)
                                throw new Exception(dbTrans.Errors.ToString());
                        }
                        #endregion
                        #region b1
                        files = new List<string>();
                        foreach (var item in gpDSItems[gpKey].Where(c => c.ItemType == emDSItemType.data_structure
                            && c.Platform == emPlatform.b1))
                        {
                            logFile.WriteLine(string.Format("  file：{0}", item.FilePath));
                            files.Add(item.FilePath);
                        }
                        if (files.Count > 0)
                        {
                            var xmlTrans = new XmlTransformer();
                            var b1Model = xmlTrans.ToDomainModel(files.ToArray());
                            if (xmlTrans.HasError)
                                throw xmlTrans.ErrorLogs.FirstOrDefault();

                            var b1Company = this.GetNewCompany();
                            var b1Trans = new B1DBTransformer();
                            b1Trans.SetDB(b1Company);
                            b1Trans.ToDB(b1Model);
                            b1Company.Disconnect();
                            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(b1Company);
                            if (b1Trans.HasError)
                                throw new Exception(b1Trans.Errors.ToString());
                        }
                        #endregion
                        #endregion
                        #region sql脚本
                        files = new List<string>();
                        foreach (var item in gpDSItems[gpKey].Where(c => c.ItemType == emDSItemType.sql_script))
                        {
                            logFile.WriteLine(string.Format("  file：{0}", item.FilePath));
                            files.Add(item.FilePath);
                        }
                        if (files.Count > 0)
                        {
                            foreach (var item in files)
                            {
                                try
                                {
                                    var sqlTrans = new SqlTransformer();
                                    sqlTrans.DBTypeSign = this.AppSetting.DatabaseType;
                                    var sqlMap = new SQLMapFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetSQLMap(sqlTrans.DBTypeSign);
                                    sqlMap.DefaultDatabase = string.Empty;
                                    sqlTrans.SetDB(new dbConnectionFactory(this.AppSetting.DBServer, this.AppSetting.DBUser, this.AppSetting.DBPassword, this.AppSetting.DBName).GetDBConnection(sqlMap));
                                    sqlTrans.AddScriptFile(item);
                                    sqlTrans.Run();
                                }
                                catch (Exception error)
                                {
                                    throw new Exception(string.Format("执行[{0}]脚本，错误：{1}", item, error.ToString()));
                                }
                            }
                        }
                        #endregion
                        logFile.WriteLine();
                    }
                    if ((this.GetCurrentDBType() == emDatabaseType.mssql || this.GetCurrentDBType() == emDatabaseType.hana) && !string.IsNullOrEmpty(this.AppSetting.B1User))
                        this.CreateAddonConfig();
                    logFile.Close();
                }
              
            }
            catch (Exception ex)
            {
                throw;
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
                    sqlStr = string.Format(@"delete from ""AVA_ADDON_CONFIG"" where ""dbName""='{0}.{1}.BSUi.BusinessSystemCenter.B1Addon.exe.config'",this.AppSetting.DBName ,this.AppSetting.DBServer );
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
</configuration>", this.AppSetting.IISAddress,this.AppSetting.IISPort);
                if (string.IsNullOrEmpty(this.AppSetting.IISAddress) || string.IsNullOrEmpty(this.AppSetting.IISPort))
                    sqlStr = string.Format(@"insert into ""AVA_ADDON_CONFIG"" values ('BSUi.BusinessSystemCenter.B1Addon.exe.config',N'{2}',GETDATE())");
                else
                    sqlStr = string.Format(@"insert into ""AVA_ADDON_CONFIG"" values ('{0}.{1}.BSUi.BusinessSystemCenter.B1Addon.exe.config',N'{2}',GETDATE())", this.AppSetting.DBName,this.AppSetting.DBServer, AddonConfig);
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
