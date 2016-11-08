using BTulz.ModelsTransformer.Transformer.SQLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.DbManager
{
    class SQLMapFactory
    {
        public SQLMapFactory(string dbServer, string dbUser, string dbPasswrod, string dbName)
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

        public SQLMap GetSQLMap(string dbType)
        {
            var mapFactory = BTulz.ModelsTransformer.Transformer.SQLs.SQLMapFactory.New();
            var map = mapFactory.GetMap(dbType);
            if (map != null)
            {
                var conBuilder = new System.Data.Common.DbConnectionStringBuilder();
                if (map.DbConnectionItems.Count == 0)
                    throw new Exception("数据库映射关系未配置连接字符串映射。");

                DbConnectionItem item;
                item = map.DbConnectionItems.FirstOrDefault(c => c.ItemName == DbConnectionItem.DB_CONNECTION_ITEM_DB_SERVER);
                if (item == null) throw new Exception("未配置数据库地址的映射。");
                item.ItemValue = this.DBServer;

                item = map.DbConnectionItems.FirstOrDefault(c => c.ItemName == DbConnectionItem.DB_CONNECTION_ITEM_DB_NAME);
                if (item == null) throw new Exception("未配置数据库名称的映射。");
                item.ItemValue = this.DBName;
                //修正连接到默认数据库，以便能够创建数据库，脚本起始行应该有切换数据库语句（use dbName）             

                item = map.DbConnectionItems.FirstOrDefault(c => c.ItemName == DbConnectionItem.DB_CONNECTION_ITEM_DB_USER);
                if (item == null) throw new Exception("未配置数据库用户的映射。");
                item.ItemValue = this.DBUser;

                item = map.DbConnectionItems.FirstOrDefault(c => c.ItemName == DbConnectionItem.DB_CONNECTION_ITEM_DB_USER_PASSWORD);
                if (item == null) throw new Exception("未配置数据库用户密码的映射。");
                item.ItemValue = this.DBPassword;

                return map;
            }
            throw new Exception("无法解析的数据库类型。");
        }

    }
}
