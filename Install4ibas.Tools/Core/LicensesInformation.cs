using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Install4ibas.Tools.Core
{
    class LicensesInformation
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

        public byte[] GetKeyBytes(int toLength)
        {
            var tmp = new StringBuilder();
            tmp.Append(this.Company);
            tmp.Append(this.ExpirationDate.ToString("yyyy/MM/dd"));
            tmp.Append(this.UserCount.ToString());
            //if (this.LicensedComputerCodes != null)
            //    foreach (var item in this.LicensedComputerCodes)
            //    {
            //        tmp.Append(item);
            //    }
            //if (this.LicensedDataBases != null)
            //    foreach (var item in this.LicensedDataBases)
            //    {
            //        tmp.Append(item);
            //    }
            var tmpDatas = System.Text.Encoding.Default.GetBytes(tmp.ToString());
            byte[] datas = new byte[toLength];
            if (tmpDatas.Length > toLength)
                for (int i = 0; i < toLength; i++)
                {
                    datas[i] = tmpDatas[i];
                }
            else
            {
                for (int i = 0; i < tmpDatas.Length; i++)
                {
                    datas[i] = tmpDatas[i];
                }
                for (int i = tmpDatas.Length; i < toLength; i++)
                {
                    datas[i] = 0x01;
                }
            }
            return datas;
        }
    }
}
