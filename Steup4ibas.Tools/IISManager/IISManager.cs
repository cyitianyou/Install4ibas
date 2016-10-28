using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steup4ibas.Tools.IISManager
{
    public class IISManager : IIISManager
    {
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
                return RegistryModules.Sum(c => c.Key ? 1 : 0) == 0;
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
