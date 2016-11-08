using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.IISManager
{
    public interface IIISManager
    {
        /// <summary>
        /// 检测是否已完全安装
        /// </summary>
        /// <returns></returns>
        bool IsFullyInstalled();
        /// <summary>
        /// 安装IIS
        /// </summary>
        void InstallIIS();
        /// <summary>
        /// 在ASP.NET中注册IIS
        /// </summary>
        void RegIISForAspnet();
        /// <summary>
        /// 卸载IIS
        /// </summary>
        void UninstallIIS();

        ApplicationPool CreateApplicationPool(string appPoolName, string runtimeVersion, ManagedPipelineMode mode);

        Site CreateSite(string siteName, int port, string physicsPath, string protocolName);

        Application CreateApplication(string appName, Site site, string Path, string physicsPath, string appPoolName);

        string ShowLastMessage();
    }
}
