using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// 未确定
        /// </summary>
        [Description("未确定")]
        all,
        /// <summary>
        /// 壳
        /// </summary>
        [Description("壳")]
        shell,
        /// <summary>
        /// 基础模块
        /// </summary>
        [Description("基础模块")]
        basic,
        /// <summary>
        /// 标准模块
        /// </summary>
        [Description("标准模块")]
        standard,
        /// <summary>
        /// 其他模块
        /// </summary>
        [Description("其他模块")]
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
        [Description("未安装")]
        notInstalled,
        /// <summary>
        /// 已安装
        /// </summary>
        [Description("已安装")]
        Installed,
        /// <summary>
        /// 可更新
        /// </summary>
        [Description("可更新")]
        canUpdate
    }

    public class Enumerator
    {
        #region 返回枚举的描述
        public static List<KeyValuePair<string,object>> GetValueAndDescriptions(Type enumType)
        {
            var array = Enum.GetValues(enumType);
            var list=new List<KeyValuePair<string,object>>();
            foreach (var item in array)
            {
                var description = GetDescription(item);
                list.Add(new KeyValuePair<string, object>(description, item));
            }
            return list;
        }
        /// <summary>
        /// 获取枚举标记[Description]的值
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="enumValue">枚举值</param>
        /// <returns>枚举值的描述</returns>
        static string GetDescription(Type enumType, string enumValue)
        {
            if (enumType != null && enumType.IsEnum)
            {
                string retValue = enumValue;
                foreach (var item in enumType.GetFields())
                {
                    if (string.Equals(item.Name, enumValue, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var atts = item.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;
                        if (atts != null)
                        {
                            retValue = Convert.ToString(atts.Description);
                        }
                    }
                }
                return retValue;
            }
            else
            {
                throw new NotSupportedException(string.Format("[{0}]不是枚举类型数据。", enumType.Name));
            }
        }

        public static string GetDescription<P>(P enumValue)
        {
            return GetDescription(typeof(P), enumValue.ToString());
        }

        public static string GetDescription(object enumValue)
        {
            return GetDescription(enumValue.GetType(), enumValue.ToString());
        }
        #endregion
    }
}
