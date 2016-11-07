using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Install4ibas.Tools.Common.InstallInformation
{
    [DataContract(Namespace = "http://ibas.club/install")]
    public class AppSetting
    {
        #region 初始化
        public AppSetting()
        {
            this.Steps = new List<InstallInformationStep>();
            this.InstallModules = new List<ibasModule>();
        }
        #endregion
        #region 数据库相关
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
        #endregion
        #region IIS相关

        #endregion
        #region ibas模块
        public IList<ibasModule> InstallModules;
        #endregion
        #region 安装步骤
        [DataMember]
        public IList<InstallInformationStep> Steps;
        #endregion
    }
    [DataContract]
    public class InstallInformationStep
    {
        [DataMember]
        public bool Completed;
        [DataMember]
        public string StepCode;
        [DataMember]
        public string StepName;
    }

}
