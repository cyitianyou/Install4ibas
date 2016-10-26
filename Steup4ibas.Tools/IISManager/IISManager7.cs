
namespace Steup4ibas.Tools.IISManager
{
    internal class IISManager7 : IISManager
    {
        /// <summary>
        /// 设置IIS文件路径
        /// </summary>
        public IISManager7()
        {
            this.SysocmgrCmd = "start /w pkgmgr /norestart /[option]:" +
"IIS-WebServerRole;" +
"IIS-WebServer;" +
"IIS-CommonHttpFeatures;" +
"IIS-StaticContent;" +
"IIS-DefaultDocument;" +
"IIS-DirectoryBrowsing;" +
"IIS-HttpErrors;" +
"IIS-HttpRedirect;" +
"IIS-ApplicationDevelopment;" +
"IIS-ASPNET;" +
"IIS-NetFxExtensibility;" +
"IIS-ASP;" +
"IIS-ISAPIExtensions;" +
"IIS-ISAPIFilter;" +
"IIS-ServerSideIncludes;" +
"IIS-HealthAndDiagnostics;" +
"IIS-HttpLogging;" +
"IIS-LoggingLibraries;" +
"IIS-RequestMonitor;" +
"IIS-HttpTracing;" +
"IIS-CustomLogging;" +
"IIS-ODBCLogging;" +
"IIS-Security;" +
"IIS-BasicAuthentication;" +
"IIS-WindowsAuthentication;" +
"IIS-DigestAuthentication;" +
"IIS-ClientCertificateMappingAuthentication;" +
"IIS-IISCertificateMappingAuthentication;" +
"IIS-URLAuthorization;" +
"IIS-RequestFiltering;" +
"IIS-IPSecurity;" +
"IIS-Performance;" +
"IIS-WebServerManagementTools;" +
"IIS-ManagementConsole;" +
"IIS-ManagementScriptingTools;" +
"IIS-ManagementService;" +
"IIS-IIS6ManagementCompatibility;" +
"IIS-Metabase;" +
"IIS-WMICompatibility;" +
"IIS-LegacyScripts;" +
"IIS-LegacySnapIn;" +
"WAS-WindowsActivationService;" +
"WAS-ProcessModel;" +
"WAS-NetFxEnvironment;" +
"WAS-ConfigurationAPI";
        }

        #region Methods
        #region Install&UnInstall
        /// <summary>
        /// 开始安装IIS
        /// </summary>
        internal override void InstallIIS()
        {
            ExecuteCmd(SysocmgrCmd.Replace("[option]", "iu"));
            RegIISForAspnet();
        }
        /// <summary>
        /// 开始卸载IIS
        /// </summary>
        internal override void UnInstallIIS()
        {
            ExecuteCmd(SysocmgrCmd.Replace("[option]", "uu"));
        }
        #endregion
        #endregion
    }
}
