using Install4ibas.Tools.Core.InstallInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.FileOperation
{
    class DataStructureItem
    {
        public static DataStructureItem New(emPlatform platform, emDSItemType type, string file, string group = "")
        {
            var item = new DataStructureItem();
            item.Platform = platform;
            item.ItemType = type;
            item.FilePath = file;
            item.Group = group;
            return item;
        }

        public bool Selected
        {
            set;
            get;
        }

        public emPlatform Platform
        {
            set;
            get;
        }

     

        public emDSItemType ItemType
        {
            set;
            get;
        }

        public emDatabaseType DatabaseType
        {
            get
            {
                if (this.FileName.IndexOf(emDatabaseType.hana.ToString()) >= 0)
                    return emDatabaseType.hana;
                if (this.FileName.IndexOf(emDatabaseType.mssql.ToString()) >= 0)
                    return emDatabaseType.mssql;
                if (this.FileName.IndexOf(emDatabaseType.mysql.ToString()) >= 0)
                    return emDatabaseType.mysql;
                if (this.FileName.IndexOf(emDatabaseType.oracle.ToString()) >= 0)
                    return emDatabaseType.oracle;
                if (this.FileName.IndexOf(emDatabaseType.pgsql.ToString()) >= 0)
                    return emDatabaseType.pgsql;
                return emDatabaseType.all;
            }
        }

   

        public string Group
        {
            set;
            get;
        }

        public string FileName
        {
            get { return System.IO.Path.GetFileName(this.FilePath); }
        }

        public string FilePath
        {
            set;
            get;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.FileName);
        }
    }
}
