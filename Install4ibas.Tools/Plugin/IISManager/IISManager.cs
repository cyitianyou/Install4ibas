﻿using Microsoft.Web.Administration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.IISManager
{
    public class IISManager : IIISManager
    {
        protected ServerManager serverManager;
        public IISManager()
        {
            RegistryModules = new List<KeyValuePair<bool, string>>();
        }
        public virtual bool IsFullyInstalled()
        {
            try
            {
                RegistryModules.Clear();
                foreach (var module in modules)
                {
                    RegistryModules.Add(new KeyValuePair<bool, string>(GetConfigurationData(module), module));
                }
                msg = String.Join(";", RegistryModules.Where(c => !c.Key).Select(c => c.Value));
                return RegistryModules.Sum(c => c.Key ? 0 : 1) == 0;
            }
            catch (Exception error)
            {

            }
            return false;
        }

        [System.Security.Permissions.RegistryPermission(System.Security.Permissions.SecurityAction.PermitOnly,
            Read = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\Notifications\OptionalFeatures")]
        public bool GetConfigurationData(string key, string namedValue = "Selection")
        {
            try
            {
                RegistryKey pRegKey = Registry.LocalMachine.OpenSubKey(RegistryPath);
                pRegKey = pRegKey.OpenSubKey(key);
                if (pRegKey == null) return false;
                int value = -1;
                Int32.TryParse(Convert.ToString(pRegKey.GetValue(namedValue, -1)), out value);
                return value == 1;
            }
            catch (Exception error)
            {

            }
            return false;
        }
        private string msg;
        public string ShowLastMessage()
        {
            return msg;
        }
        public virtual void InstallIIS()
        {
            throw new NotImplementedException();
        }

        public virtual void RegIISForAspnet()
        {
            throw new NotImplementedException();
        }

        public virtual void UninstallIIS()
        {
            throw new NotImplementedException();
        }
        public virtual ApplicationPool CreateApplicationPool(string appPoolName, string runtimeVersion = "v4.0", ManagedPipelineMode mode = ManagedPipelineMode.Integrated)
        {
            try
            {
                ApplicationPool newPool = serverManager.ApplicationPools[appPoolName];
                Microsoft.Web.Administration.Configuration config = serverManager.GetApplicationHostConfiguration();
                if (newPool != null)
                {
                    serverManager.ApplicationPools.Remove(newPool);
                }
                newPool = serverManager.ApplicationPools.Add(appPoolName);
                newPool.ManagedRuntimeVersion = runtimeVersion;
                newPool.ManagedPipelineMode = mode;
                newPool.Enable32BitAppOnWin64 = true;
                return newPool;
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("创建应用程序池时出错:{0}", error.Message));
            }
        }
        public virtual Site CreateSite(string siteName, int port, string physicsPath, string protocolName = "http")
        {
            try
            {
                Site site = serverManager.Sites[siteName];
                if (site != null)
                {
                    serverManager.Sites.Remove(site);
                }
                site = serverManager.Sites.Add(siteName, protocolName, string.Format("*:{0}:", port), physicsPath);
                site.Applications[0].ApplicationPoolName = siteName;
                return site;
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("创建网站时出错:{0}", error.Message));
            }
        }
        public virtual Application CreateApplication(string appName, Site site, string Path, string physicsPath, string appPoolName)
        {
            try
            {
                Microsoft.Web.Administration.Configuration config = serverManager.GetApplicationHostConfiguration();
                Application newApp = site.Applications[Path];
                if (newApp != null)
                {
                    site.Applications.Remove(newApp);  //delete this application
                    config.RemoveLocationPath(string.Format("{0}{1}", site.Name, Path)); //delete the node of the applicationHostConfig.config file with this application
                }
                newApp = site.Applications.Add(Path, physicsPath);
                newApp.ApplicationPoolName = appPoolName;

                //开启目录浏览
                string path = "system.webServer/directoryBrowse";//the attribue path in the applictionHostConfig.config file.
                Microsoft.Web.Administration.ConfigurationSection dbS = config.GetSection(path, string.Format("{0}{1}", site.Name, Path));
                dbS.Attributes["enabled"].Value = true;
                return newApp;
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("创建应用程序[{0}]时出错:{1}", appName, error.Message));
            }
        }
        #region 属性及常量
        List<KeyValuePair<bool, string>> RegistryModules;
        //const string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\Notifications\OptionalFeatures";
        const string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\Notifications\OptionalFeatures";
        //string[] RegistryPath = new string[] {"SOFTWARE","Microsoft","Windows","CurrentVersion","Component Based Servicing","Notifications","OptionalFeatures"};
        string[] modules = new string[] {
                                "IIS-WebServerRole" ,
                                "IIS-WebServer" ,
                                "IIS-CommonHttpFeatures" ,
                                "IIS-StaticContent" ,
                                "IIS-DefaultDocument" ,
                                "IIS-DirectoryBrowsing" ,
                                "IIS-HttpErrors" ,
                                "IIS-HttpRedirect" ,
                                "IIS-ApplicationDevelopment" ,
                                "IIS-ASPNET" ,
                                "IIS-NetFxExtensibility" ,
                                "IIS-ASP" ,
                                "IIS-ISAPIExtensions" ,
                                "IIS-ISAPIFilter" ,
                                "IIS-ServerSideIncludes" ,
                                "IIS-HealthAndDiagnostics" ,
                                "IIS-HttpLogging" ,
                                "IIS-LoggingLibraries" ,
                                "IIS-RequestMonitor" ,
                                "IIS-HttpTracing" ,
                                "IIS-CustomLogging" ,
                                //"IIS-ODBCLogging" ,
                                "IIS-Security" ,
                                "IIS-BasicAuthentication" ,
                                //"IIS-WindowsAuthentication" ,
                                //"IIS-DigestAuthentication" ,
                                //"IIS-ClientCertificateMappingAuthentication" ,
                                //"IIS-IISCertificateMappingAuthentication" ,
                                "IIS-URLAuthorization" ,
                                "IIS-RequestFiltering" ,
                                "IIS-IPSecurity" ,
                                "IIS-Performance" ,
                                "IIS-WebServerManagementTools" ,
                                "IIS-ManagementConsole" ,
                                "IIS-ManagementScriptingTools" ,
                                "IIS-ManagementService" ,
                                "IIS-IIS6ManagementCompatibility" ,
                                "IIS-Metabase" ,
                                "IIS-WMICompatibility" ,
                                "IIS-LegacyScripts" ,
                                "IIS-LegacySnapIn" ,
                                "WAS-WindowsActivationService" ,
                                "WAS-ProcessModel" ,
                                "WAS-NetFxEnvironment" ,
                                "WAS-ConfigurationAPI"
    };
        #endregion




        
    }
}
