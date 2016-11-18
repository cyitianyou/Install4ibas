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
    class InstallStep_DbCreate : BasicInstallStep
    {
        public InstallStep_DbCreate()
        {
            //System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Interop.SAPbobsCOM.x86.dll"));
            //System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Interop.SAPbouiCOM.x86.dll"));
        }
        #region 常量,变量
        const string STEPCODE = "DbCreate";
        const string STEPNAME = "创建数据库";

        public override string StepCode
        {
            get { return STEPCODE; }
        }

        public override string StepName
        {
            get { return STEPNAME; }
        }

        #endregion
        bool B1Included { get { return string.IsNullOrEmpty(this.AppSetting.B1User) ? false : true; } }

        public override bool Excute()
        {
            var shell = this.AppSetting.InstallModules.Where(c => c.Type == emModuleType.shell).FirstOrDefault();
            if (shell != null)
            {
                try
                {
                    this.ModuleToDB(shell);
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("创建模块{0}时发生错误，错误信息：{1}", shell.ModuleName, e.Message));
                }
            }
            foreach (var item in this.AppSetting.InstallModules.Where(c => !(c.Type == emModuleType.shell)))
            {
                try
                {
                    this.ModuleToDB(item);
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("创建模块{0}时发生错误，错误信息：{1}", item.ModuleName, e.Message));
                }

            }
            return true;
        }
        private void ModuleToDB(ibasModule module)
        {
            try
            {
                var dsGetter = new DataStructuresGetter();
                dsGetter.WorkFolder = module.ModuleInstallPath;
                var dsItems = dsGetter.Get();
                dsGetter.AutoSelected(this.B1Included, this.GetCurrentDBType(), dsItems);
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
        SAPbobsCOM.Company GetNewCompany()
        {
            try
            {
                SAPbobsCOM.Company Company = new SAPbobsCOM.Company();
                Company.DbServerType = (SAPbobsCOM.BoDataServerTypes)System.Enum.Parse(typeof(SAPbobsCOM.BoDataServerTypes), this.AppSetting.B1Type);
                Company.Server = this.AppSetting.DBServer;
                Company.DbUserName = this.AppSetting.DBUser;
                Company.DbPassword = this.AppSetting.DBPassword;
                Company.CompanyDB = this.AppSetting.DBName;
                Company.UserName = this.AppSetting.B1User;
                Company.Password = this.AppSetting.B1Password;
                Company.LicenseServer = this.AppSetting.B1Server;
                Company.language = (SAPbobsCOM.BoSuppLangs)System.Enum.Parse(typeof(SAPbobsCOM.BoSuppLangs), this.AppSetting.cmbLanguage);

                int ret = Company.Connect();
                if (ret != 0)
                    throw new Exception(string.Format("连接B1失败，{0}", Company.GetLastErrorDescription()));
                return Company;
            }
            catch (Exception ex)
            {
                string message = string.Format("[DI API]初始化失败");
                if ((ex) is System.IO.FileNotFoundException & ex.Message.IndexOf("632F4591-AA62-4219-8FB6-22BCF5F60090") > 0)
                {
                    string msg_no_di = string.Format("{0}，{1}", message, "可能是此计算机没有安装匹配的{0}位版本DI。");
                    if ((System.Environment.Is64BitProcess))
                        //'64位客户端
                        message = string.Format(msg_no_di, "64");
                    else
                        //'32位客户端
                        message = string.Format(msg_no_di, "32");
                }
                else
                    message = string.Format("{0}，{1}", message, ex.Message);
                throw new Exception(message, ex);
            }

        }


    }
}
