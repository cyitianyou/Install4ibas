using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.IISManager
{
    public interface IIISManager
    {
        ApplicationPool CreateApplicationPool(string appPoolName, string runtimeVersion, ManagedPipelineMode mode);

        Site CreateSite(string siteName, int port, string physicsPath, string protocolName);

        IList<string> GetSiteNames(bool onlyIbas = true);

        Site GetSite(string siteName);

        Application CreateApplication(string appName, Site site, string Path, string physicsPath, string appPoolName);

        string ShowLastMessage();
    }
}
