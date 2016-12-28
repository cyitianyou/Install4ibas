using Microsoft.Web.Administration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.IISManager
{
    public class IISInstaller : IIISInstaller
    {
        protected ServerManager _serverManager;
        protected ServerManager serverManager
        {
            get
            {
                if (_serverManager == null)
                    _serverManager = new ServerManager();
                return _serverManager;
            }
        }
        /// <summary>
        /// 配置提交后,需要重新实例化才能再次提交
        /// </summary>
        private void serverManager_CommitChanges()
        {
            serverManager.CommitChanges();
            serverManager.Dispose();
            _serverManager = new ServerManager();
        }
        protected bool checkedFullyInstalled;
        public IISInstaller()
        {
            RegistryModules = new List<KeyValuePair<bool, string>>();
        }
        public virtual bool IsFullyInstalled()
        {
            try
            {
                checkedFullyInstalled = true;
                RegistryModules.Clear();
                foreach (var module in modules)
                {
                    RegistryModules.Add(new KeyValuePair<bool, string>(GetConfigurationData(module), module));
                }
                return RegistryModules.Sum(c => c.Key ? 0 : 1) == 0;
            }
            catch (Exception error)
            {

            }
            return false;
        }

        //  [System.Security.Permissions.RegistryPermission(System.Security.Permissions.SecurityAction.PermitOnly,
        //     Read = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\Notifications\OptionalFeatures")]
        public bool GetConfigurationData(string key, string namedValue = "Selection")
        {
            try
            {
                RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey pRegKey = localKey.OpenSubKey(RegistryPath);
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
        public virtual void InstallIIS()
        {
            if (!checkedFullyInstalled)
                this.IsFullyInstalled();
            StringBuilder sb = new StringBuilder();
            sb.Append(SysocmgrCmd);
            foreach (var item in RegistryModules.Where(c => !c.Key))
            {
                sb.Append(item.Value).Append(";");
            }
            FileOperation.ExecuteCmd(sb.ToString().Replace("[option]", "iu"));
            RegIISForAspnet();
            this.UpdateSvcConfig();
        }
        public virtual void UninstallIIS()
        {
            if (!checkedFullyInstalled)
                this.IsFullyInstalled();
            StringBuilder sb = new StringBuilder();
            sb.Append(SysocmgrCmd);
            foreach (var item in RegistryModules.Where(c => c.Key))
            {
                sb.Append(item.Value).Append(";");
            }
            FileOperation.ExecuteCmd(sb.ToString().Replace("[option]", "uu"));
        }
        public virtual void RegIISForAspnet()
        {
            if (CheckOSBitness.Is64BitOperatingSystem())
                FileOperation.ExecuteCmd(Path.Combine(System.Environment.GetEnvironmentVariable("windir"), @"Microsoft.Net\Framework64\v4.0.30319\aspnet_regiis -i"));
            else
                FileOperation.ExecuteCmd(Path.Combine(System.Environment.GetEnvironmentVariable("windir"), @"Microsoft.Net\Framework\v4.0.30319\aspnet_regiis -i"));
        }

        public virtual void UpdateSvcConfig()
        {
            ServerManager sm = new ServerManager();
            #region 添加MIEI
            ConfigurationElementCollection staticContentCollection = sm.GetApplicationHostConfiguration()
                                                                                                                                    .GetSection("system.webServer/staticContent")
                                                                                                                                    .GetCollection();
            ConfigurationElement mimeTypeEl = staticContentCollection.FirstOrDefault(a => (string)a.Attributes["fileExtension"].Value == ".svc");
            if (mimeTypeEl != null)
                staticContentCollection.Remove(mimeTypeEl);
            ConfigurationElement mimeMapElement = staticContentCollection.CreateElement("mimeMap");
            mimeMapElement["fileExtension"] = ".svc";
            mimeMapElement["mimeType"] = "application/octet-stream";
            staticContentCollection.Add(mimeMapElement);
            #endregion
            #region 添加处理程序映射
            ConfigurationElementCollection handlersCollection = sm.GetApplicationHostConfiguration()
                                                                                                                                    .GetSection("system.webServer/handlers")
                                                                                                                                    .GetCollection();
            ConfigurationElement handleEl = handlersCollection.FirstOrDefault(a => (string)a.Attributes["path"].Value == "*.svc"
                                                                                                                                        && (string)a.Attributes["name"].Value == "svc-Integrated");
            if (handleEl != null)
                handlersCollection.Remove(handleEl);
            ConfigurationElement addElement = handlersCollection.CreateElement("add");
            addElement["path"] = "*.svc";
            addElement["name"] = "svc-Integrated";
            addElement["verb"] = "*";
            addElement["type"] = "System.ServiceModel.Activation.HttpHandler";
            handlersCollection.Add(addElement);
            #endregion
            sm.CommitChanges();
        }
        #region 属性及常量
        List<KeyValuePair<bool, string>> RegistryModules;
        const string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\Notifications\OptionalFeatures";
        const string SysocmgrCmd = "start /w pkgmgr /norestart /[option]:";
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
