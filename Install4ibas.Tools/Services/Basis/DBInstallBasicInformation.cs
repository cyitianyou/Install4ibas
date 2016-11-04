using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    class DBInstallBasicInformation
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public emDatabaseType DatabaseType
        {
            set;
            get;
        }
        /// <summary>
        /// 平台
        /// </summary>
        public emPlatform Platform
        {
            set;
            get;
        }
    }
}
