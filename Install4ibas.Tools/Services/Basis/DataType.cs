using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    public enum emPlatform
    {
        ibas, b1
    }

    public enum emDSItemType
    {
        data_structure, sql_script
    }

    public enum emDatabaseType
    {
        all, hana, mssql, mysql, oracle, pgsql
    }
}
