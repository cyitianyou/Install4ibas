using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Common.InstallInformation
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
    /// <summary>
    /// 模块类型
    /// </summary>
    public enum emModuleType
    {
        /// <summary>
        /// 不确定
        /// </summary>
        all, 
        /// <summary>
        /// 壳
        /// </summary>
        shell,
        /// <summary>
        /// 基础模块
        /// </summary>
        basic, 
        /// <summary>
        /// 标准模块
        /// </summary>
        standard, 
        /// <summary>
        /// 其他模块
        /// </summary>
        other
    }
    /// <summary>
    /// 安装状态
    /// </summary>
    public enum emInstallStatus
    {
        /// <summary>
        /// 未安装
        /// </summary>
        notInstalled,
        /// <summary>
        /// 已安装
        /// </summary>
        Installed,
        /// <summary>
        /// 可更新
        /// </summary>
        canUpdate
    }
}
