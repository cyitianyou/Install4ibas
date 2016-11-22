using BTulz.ModelsTransformer.Transformer.SQLs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.DbManager
{
    class dbConnectionFactory
    {
        public dbConnectionFactory(string dbServer, string dbUser, string dbPasswrod, string dbName)
        {
            this.DBServer = dbServer;
            this.DBName = dbName;
            this.DBUser = dbUser;
            this.DBPassword = dbPasswrod;
        }

        public string DBServer
        {
            set;
            get;
        }

        public string DBUser
        {
            set;
            get;
        }

        public string DBPassword
        {
            set;
            get;
        }

        public string DBName
        {
            set;
            get;
        }

        public IDbConnection GetDBConnection(SQLMap map)
        {
            if (map.MyMapSign.StartsWith(BTulz.ModelsTransformer.Transformer.SQLs.SQLMapFactory.DEFAULT_DB_TYPE_SIGN))
            {
                var constrBuider = new SqlConnectionStringBuilder();
                constrBuider.DataSource = this.DBServer;
                constrBuider.UserID = this.DBUser;
                constrBuider.Password = this.DBPassword;
                constrBuider.InitialCatalog = this.DBName;
                constrBuider.ConnectTimeout = 600;
                //if (!string.IsNullOrEmpty(map.DefaultDatabase))
                //    constrBuider.InitialCatalog = map.DefaultDatabase;

                return new SqlConnection(constrBuider.ConnectionString);
            }
            else
            {
                var conBuilder = new System.Data.Common.DbConnectionStringBuilder();
                DbConnectionItem dbNameItem = map.DbConnectionItems.FirstOrDefault(c => c.ItemName == DbConnectionItem.DB_CONNECTION_ITEM_DB_NAME);
                //如果设置了默认数据库，使用默认数据库为打开数据库
                if (!string.IsNullOrEmpty(map.DefaultDatabase))
                {
                    if (dbNameItem != null)
                        dbNameItem.ItemValue = map.DefaultDatabase;
                }
                //构建连接字符串项目
                foreach (var dbItem in map.DbConnectionItems)
                {
                    conBuilder.Add(dbItem.StringBuilderKey, dbItem.ItemValue);
                }
                if (!string.IsNullOrEmpty(map.DefaultDatabase))
                {
                    //修正回原始数据库
                    dbNameItem.ItemValue = this.DBName;
                }

                var tmps = map.DbConnetionClassName.Split(';');
                if (tmps.Length != 2)
                    throw new Exception("无效的连接类设置。参考格式[Dbconnection.dll;Dbconnnection]");
                var dllFile = tmps[0];
                var className = tmps[1];
                foreach (System.Reflection.Assembly itemAbly in System.AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (!string.Equals(dllFile, itemAbly.ManifestModule.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        continue;
                    var dbCon = itemAbly.CreateInstance(className) as System.Data.IDbConnection;
                    if (dbCon != null)
                    {
                        if (map.MyMapSign == "HANA")
                            dbCon.ConnectionString = string.Format(@"{0};CS=""{1}""", conBuilder.ToString(), dbNameItem.ItemValue);
                        else if (map.MyMapSign == "MYSQL")
                            dbCon.ConnectionString = conBuilder.ToString() + ";Allow User Variables = True";
                        else
                            dbCon.ConnectionString = conBuilder.ToString();
                        return dbCon;
                    }
                }
            }
            throw new Exception("无法获取的数据库连接。");
        }

    }
}
