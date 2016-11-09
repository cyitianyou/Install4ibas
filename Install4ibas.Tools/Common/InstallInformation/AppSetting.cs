using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Install4ibas.Tools.Common.InstallInformation
{

    [DataContract(Namespace = "http://ibas.club/install")]
    [KnownType(typeof(AppSetting))]
    [KnownType(typeof(InstallInformationStep))]
    public class AppSetting
    {
        #region 初始化
        public AppSetting()
        {
            this.Steps = new List<InstallInformationStep>();
            this.InstallModules = new List<ibasModule>();
        }

        #endregion
        #region 基础信息
        /// <summary>
        /// 安装包文件夹
        /// </summary>
        public string SourcePackageDir
        {
            set;
            get;
        }
        /// <summary>
        /// 安装文件夹
        /// </summary>
        public string InstallDiraddress
        {
            set;
            get;
        }
        #endregion
        #region 数据库相关

        /// <summary>
        /// IIS地址
        /// </summary>
        public string IISAddress
        {
            set;
            get;
        }
        /// <summary>
        /// IIS端口号
        /// </summary>
        public string IISPort
        {
            set;
            get;
        }
        /// <summary>
        /// 数据库类型("HANA","MSSQL""MYSQL""ORACLE""PostgreSQL")
        /// </summary>
        public string DatabaseType
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
         /// <summary>
        /// 数据库地址
        /// </summary>
        public string DBServer
        {
            set;
            get;
        }
        /// <summary>
        /// 数据库登陆用户名
        /// </summary>
        public string DBUser
        {
            set;
            get;
        }
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public string DBPassword
        {
            set;
            get;
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DBName
        {
            set;
            get;
        }
         /// <summary>
        /// B1类型
        /// </summary>
        public string B1Type
        {
            set;
            get;
        }
           /// <summary>
        /// B1用户
        /// </summary>
        public string B1User
        {
            set;
            get;
        }
        /// <summary>
        /// B1密码
        /// </summary>
        public string B1Password
        {
            set;
            get;
        }
         /// <summary>
        /// B1许可证
        /// </summary>
        public string B1Server
        {
            set;
            get;
        }
        
            /// <summary>
        /// B1语言
        /// </summary>
        public string cmbLanguage
        {
            set;
            get;
        }
        
        
        #endregion
        #region IIS相关
        /// <summary>
        /// 网站名
        /// </summary>
        public string SiteName
        {
            set;
            get;
        }
        #endregion
        #region ibas模块
        public IList<ibasModule> InstallModules;
        #endregion
        #region Licenses相关
        #endregion
        #region 安装步骤
        [DataMember(Name = "Steps")]
        public IList<InstallInformationStep> Steps;
        #endregion
    }
    #region InstallInformationStep
    [DataContract(Namespace = "http://ibas.club/install", Name = "anyType")]
    public class InstallInformationStep
    {
        [DataMember(Name = "StepCode")]
        public string StepCode;
        [DataMember(Name = "StepName")]
        public string StepName;
        [DataMember(Name = "Completed")]
        public bool Completed;
    }
    #endregion

}
