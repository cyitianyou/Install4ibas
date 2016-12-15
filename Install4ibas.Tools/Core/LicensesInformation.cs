using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Install4ibas.Tools.Core
{
    public class LicensesInformation
    {
        public LicensesInformation()
        {
            this.ExpirationDate = DateTime.MinValue;
        }

        /// <summary>
        /// 公司/组织
        /// </summary>
        [DataMember(Order = 1)]
        public string Company
        {
            set;
            get;
        }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember(Order = 2)]
        public string Contacts
        {
            set;
            get;
        }
        /// <summary>
        /// 邮件地址
        /// </summary>
        [DataMember(Order = 3)]
        public string eMail
        {
            set;
            get;
        }
        /// <summary>
        /// 过期日
        /// </summary>
        [DataMember(Order = 4)]
        public DateTime ExpirationDate
        {
            set;
            get;
        }
        /// <summary>
        /// 用户数量
        /// </summary>
        [DataMember(Order = 5)]
        public int UserCount
        {
            set;
            get;
        }
        /// <summary>
        /// 授权的机器码
        /// </summary>
        [DataMember(Order = 6)]
        public string[] LicensedComputerCodes
        {
            set;
            get;
        }
        /// <summary>
        /// 授权的数据库
        /// </summary>
        [DataMember(Order = 7)]
        public string[] LicensedDataBases
        {
            set;
            get;
        }
        /// <summary>
        /// 授权的模块
        /// </summary>
        [DataMember(Order = 8)]
        public string[] LicensedModules
        {
            set;
            get;
        }

        public override string ToString()
        {
            var tmp = new StringBuilder();
            tmp.AppendLine(string.Format("公司名称：{0}", this.Company));
            tmp.AppendLine(string.Format("联系人：{0}", this.Contacts));
            tmp.AppendLine(string.Format("Email：{0}", this.eMail));
            tmp.AppendLine(string.Format("到期日：{0}", this.ExpirationDate.ToString("yyyy/MM/dd")));
            tmp.AppendLine(string.Format("用户数：{0}", this.UserCount.ToString()));
            tmp.AppendLine(string.Format("机器码："));
            if (this.LicensedComputerCodes != null && this.LicensedComputerCodes.Length > 0)
            {
                for (int i = 0; i < this.LicensedComputerCodes.Length; i++)
                {
                    var item = this.LicensedComputerCodes[i];
                    tmp.AppendLine(string.Format("--{0};", item));
                }
            }
            tmp.AppendLine(string.Format("DataBases:"));
            if (this.LicensedDataBases != null && this.LicensedDataBases.Length > 0)
            {
                for (int i = 0; i < this.LicensedDataBases.Length; i++)
                {
                    var item = this.LicensedDataBases[i];
                    tmp.AppendLine(string.Format("--{0};", item));
                }
            }
            tmp.AppendLine(string.Format("Modules:"));
            if (this.LicensedModules != null && this.LicensedModules.Length > 0)
            {
                for (int i = 0; i < this.LicensedModules.Length; i++)
                {
                    var item = this.LicensedModules[i];
                    tmp.AppendLine(string.Format("--{0};", item));
                }
            }
            return tmp.ToString();
        }
    }
}
