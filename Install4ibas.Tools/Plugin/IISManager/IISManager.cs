using Microsoft.Web.Administration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.IISManager
{
    public class IISManager : IIISManager
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
            set
            {
                _serverManager = value;
            }
        }
        /// <summary>
        /// 配置提交后,需要重新实例化才能再次提交
        /// </summary>
        private void serverManager_CommitChanges()
        {
            serverManager.CommitChanges();
            serverManager.Dispose();
            _serverManager =null;
            GC.Collect();
        }
        private string msg;
        public string ShowLastMessage()
        {
            return msg;
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
                if (!Environment.Is64BitProcess)
                    newPool.Enable32BitAppOnWin64 = true;
                else
                    newPool.Enable32BitAppOnWin64 = false;
                serverManager_CommitChanges();
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
                Site site = serverManager.Sites.FirstOrDefault(c => c.Name == siteName);
                if (site != null)
                {
                    serverManager.Sites.Remove(site);
                }
                site = serverManager.Sites.Add(siteName, protocolName, string.Format("*:{0}:", port), physicsPath);
                site.Applications[0].ApplicationPoolName = siteName;
                serverManager_CommitChanges();
                return site;
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("创建网站时出错:{0}", error.Message));
            }
        }
        public IList<string> GetSiteNames(bool onlyIbas = true)
        {
            var result = new List<string>();
            foreach (var item in serverManager.Sites)
            {
                if (!onlyIbas || item.Applications.Count(c => c.Path.Equals("/SystemCenter", StringComparison.InvariantCultureIgnoreCase)) == 1)
                {
                    result.Add(item.Name);
                }
            }
            return result;
        }
        public Site GetSite(string siteName)
        {
            return serverManager.Sites[siteName];
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
                serverManager_CommitChanges();
                return newApp;
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("创建应用程序[{0}]时出错:{1}", appName, error.Message));
            }
        }
    }
}
