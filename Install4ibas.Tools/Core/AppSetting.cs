﻿using Install4ibas.Tools.Plugin.IISManager;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
namespace Install4ibas.Tools.Core
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
            this.InstallModules = new ibasModules();
            this.LoadDefaultModules();
        }

        #endregion
        #region 是否成功安装
        public bool isSuccess
        {
            set;
            get;
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
        #endregion
        #region ibas模块
        public ibasModules InstallModules { get; set; }
        #endregion
        #region Licenses相关
        /// <summary>
        /// 当前机器机器码 BTulz.LicensesManager.Licenses.ComputerCode.GetCode();
        /// </summary>
        public string CmpCode { get; set; }
        #endregion
        #region 安装步骤
        [DataMember(Name = "Steps")]
        public IList<InstallInformationStep> Steps;
        #endregion
        #region 加载数据
        /// <summary>
        /// 模块列表先恢复默认值
        /// 然后读取本地模块,更新列表
        /// </summary>
        /// <param name="folderPath"></param>
        public void GetLocalModulesInfo(string folderPath)
        {
            this.LoadDefaultModules();
            this.InstallModules.GetLocalInfo(folderPath);
        }
        private void LoadDefaultModules()
        {
            try
            {
                var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "ibasStandardModules.xml");
                if (File.Exists(path))
                {
                    var xml = System.Xml.XmlReader.Create(path);
                    var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ibasModules));
                    var model = serializer.ReadObject(xml) as ibasModules;
                    if (model != null)
                        this.InstallModules = model;
                }
            }
            catch (Exception error)
            {

            }
        }
        public void LoadSiteName()
        {
            if (String.IsNullOrEmpty(this.SiteName)) return;
            Site site = IISManagerFactory.New().CreateIISManager().GetSite(this.SiteName); ;
            if (site == null) return;
            System.Configuration.Configuration cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", this.SiteName);
            //设置appsetting
            AppSettingsSection appSetting = cfg.AppSettings;
            //使用Site信息对AppSetting赋值
            #region 数据库相关
             //public emPlatform Platform
             //public string B1User
            //public string B1Password
            this.DatabaseType = GetValue(appSetting, "DatabaseType");
            this.DBServer = GetValue(appSetting, "DataSource");
            this.DBName = GetValue(appSetting, "InitialCatalog");
            this.DBUser = GetValue(appSetting, "UserID");
            this.DBPassword = GetValue(appSetting, "Password");
            this.B1Type = GetValue(appSetting, "B1Type");
            this.B1Server = GetValue(appSetting, "B1Server");
            this.cmbLanguage = SAPbobsCOM.BoSuppLangs.ln_Chinese.ToString();
            #endregion
            #region IIS相关
            this.InstallDiraddress = site.Applications["/"].VirtualDirectories["/"].PhysicalPath;
            if (site.Bindings.Count > 0)
            {
                var binding = site.Bindings[0];
                var endPoint = binding.EndPoint;
                //public string IISAddress
                this.IISAddress = endPoint.Address.ToString();
                //public string IISPort
                this.IISAddress = endPoint.Port.ToString();
            }
            
        #endregion
        }

        private string GetValue(AppSettingsSection appSetting, string key)
        {
            if (appSetting.Settings[key] != null)
                return appSetting.Settings[key].Value;
            else
                return "";
        }
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
