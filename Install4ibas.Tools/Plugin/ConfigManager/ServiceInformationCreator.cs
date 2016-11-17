using Install4ibas.Tools.Common.InstallInformation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Plugin.ConfigManager
{
    class ServiceInformationCreator
    {
        /*
         示例：
            <ServiceInformations xmlns="http://www.avatech.com.cn/ServiceRouting" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
              <ServiceInformation>
                <ServiceName>BusinessPartner</ServiceName>
                <ModuleID>ef7efd2a-d2b6-4c8e-a361-20c87db825b1</ModuleID>
                <ServiceDescription>业务伙伴服务</ServiceDescription>
                <RegisteredServiceProviders>
                  <ServiceProvider>
                    <RootAddress>http://localhost:2208</RootAddress>
                    <DataServiceAddress>/DataService/BusinessPartner.svc</DataServiceAddress>
                    <ApplicationPackageAddress></ApplicationPackageAddress>
                  </ServiceProvider>
                  <ServiceProvider>
                    <RootAddress>http://ibas-publish.avatech.com.cn:8000/BusinessPartner</RootAddress>
                    <DataServiceAddress>/DataService/BusinessPartner.svc</DataServiceAddress>
                    <ApplicationPackageAddress></ApplicationPackageAddress>
                  </ServiceProvider>
                </RegisteredServiceProviders>
              </ServiceInformation>
            </ServiceInformations>
         */

        public ServiceInformationCreator()
        {

        }
        public AppSetting MyAppsetting
        {
            set;
            get;
        }
        public string RootAddress
        {
            set;
            get;
        }

        public string WorkFolder
        {
            set;
            get;
        }

        public virtual string GetServiceConfigPath()
        {
            return string.Format(@"{0}\SystemCenter\ServiceInformations.config", this.WorkFolder).Replace(@"\\", @"\");
        }
        public virtual string GetWebConfigPath()
        {
            return string.Format(@"{0}\Web.config", this.WorkFolder).Replace(@"\\", @"\");
        }
        protected System.Data.IDbConnection DbConnection
        {
            set;
            get;
        }

        public void SetDBConnection(IDbConnection dbCon)
        {
            this.DbConnection = dbCon;
        }

        public void GO()
        {
            try
            {
                if (this.DbConnection == null)
                    throw new Exception("未设置有效的数据库连接。");
                if (!System.IO.File.Exists(this.GetServiceConfigPath()))
                    throw new Exception("配置文件不存在。");
                var config = new System.Xml.XmlDocument();
                config.Load(this.GetServiceConfigPath());
                var services = this.GetServiceInformations();
                System.Xml.XmlElement xmlElement = null;
                foreach (var item in services)
                {
                    var xmlService = this.GetServiceNode(item.ModuleID, config.DocumentElement);
                    if (xmlService == null) continue;
                    xmlElement = this.GetServiceElement("ServiceName", xmlService);
                    xmlElement.InnerText = item.ServiceName;
                    xmlElement = this.GetServiceElement("ModuleID", xmlService, xmlElement);
                    xmlElement.InnerText = item.ModuleID;
                    xmlElement = this.GetServiceElement("ServiceDescription", xmlService, xmlElement);
                    xmlElement.InnerText = item.ServiceDescription;
                    xmlElement = this.GetServiceElement("BOServiceContract", xmlService, xmlElement);
                    xmlElement.InnerText = item.BOServiceContract;
                    xmlElement = this.GetServiceElement("BOServiceBindingConfiguration", xmlService, xmlElement);
                    xmlElement.InnerText = item.BOServiceBindingConfiguration;
                    xmlElement = this.GetServiceElement("RegisteredServiceProviders", xmlService, xmlElement);
                    var provider = this.GetProviderNode(this.RootAddress, xmlElement);
                    xmlElement = this.GetServiceElement("RootAddress", provider);
                    //xmlElement.InnerText = string.Format(@"{0}/{1}", this.RootAddress, item.ServicePath);
                    xmlElement.InnerText = this.RootAddress;
                    xmlElement = this.GetServiceElement("DataServiceAddress", provider, xmlElement);
                    xmlElement.InnerText = string.Format(@"/DataService/{0}.svc", item.ServicePath);
                    xmlElement = this.GetServiceElement("ApplicationPackageAddress", provider, xmlElement);
                    //xmlElement.InnerText = string.Format(@"");


                }
                config.Save(this.GetServiceConfigPath());
                this.CreateClientConfig();
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("更新服务配置文件失败，{0}", error.Message), error);
            }
        }

        System.Xml.XmlNode GetServiceNode(string moduleId, System.Xml.XmlElement xmlElm)
        {
            System.Xml.XmlNode service = null;
            foreach (System.Xml.XmlNode item in xmlElm.GetElementsByTagName("ServiceInformation"))
            {
                foreach (System.Xml.XmlNode node in item.ChildNodes)
                {
                    if (node.Name != "ModuleID")
                        continue;
                    if (!string.Equals(moduleId, node.InnerText, StringComparison.InvariantCultureIgnoreCase))
                        continue;
                    service = item;
                    break;
                }
                if (service != null)
                    break;
            }
            if (service == null)
            {
                service = xmlElm.OwnerDocument.CreateElement("ServiceInformation", xmlElm.OwnerDocument.DocumentElement.NamespaceURI);

                var node = service.OwnerDocument.CreateElement("ServiceName", xmlElm.OwnerDocument.DocumentElement.NamespaceURI);
                service.AppendChild(node);
                node = service.OwnerDocument.CreateElement("ModuleID", xmlElm.OwnerDocument.DocumentElement.NamespaceURI);
                service.AppendChild(node);
                node = service.OwnerDocument.CreateElement("ServiceDescription", xmlElm.OwnerDocument.DocumentElement.NamespaceURI);
                service.AppendChild(node);
                node = service.OwnerDocument.CreateElement("BOServiceContract", xmlElm.OwnerDocument.DocumentElement.NamespaceURI);
                service.AppendChild(node);
                node = service.OwnerDocument.CreateElement("BOServiceBindingConfiguration", xmlElm.OwnerDocument.DocumentElement.NamespaceURI);
                service.AppendChild(node);
                node = service.OwnerDocument.CreateElement("RegisteredServiceProviders", xmlElm.OwnerDocument.DocumentElement.NamespaceURI);
                service.AppendChild(node);

                xmlElm.AppendChild(service);
            }
            return service;
        }

        System.Xml.XmlNode GetProviderNode(string rootAddress, System.Xml.XmlNode serviceNode)
        {
            System.Xml.XmlNode provider = null;
            if (serviceNode.HasChildNodes)
            {
                foreach (System.Xml.XmlNode item in serviceNode.ChildNodes)
                {
                    foreach (System.Xml.XmlNode node in item.ChildNodes)
                    {
                        if (node.Name != "RootAddress") continue;
                        var tmp = Convert.ToString(node.InnerText);
                        if (!tmp.StartsWith(this.RootAddress, StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(tmp))
                            continue;
                        provider = item;
                        break;
                    }
                    if (provider != null)
                        break;
                }
            }
            if (provider == null)
            {
                provider = serviceNode.OwnerDocument.CreateElement("ServiceProvider", serviceNode.OwnerDocument.DocumentElement.NamespaceURI);

                var node = provider.OwnerDocument.CreateElement("RootAddress", serviceNode.OwnerDocument.DocumentElement.NamespaceURI);
                provider.AppendChild(node);
                node = provider.OwnerDocument.CreateElement("DataServiceAddress", serviceNode.OwnerDocument.DocumentElement.NamespaceURI);
                provider.AppendChild(node);
                node = provider.OwnerDocument.CreateElement("ApplicationPackageAddress", serviceNode.OwnerDocument.DocumentElement.NamespaceURI);
                provider.AppendChild(node);

                if (serviceNode.HasChildNodes)
                    serviceNode.InsertBefore(provider, serviceNode.FirstChild);
                else
                    serviceNode.AppendChild(provider);
            }
            return provider;
        }

        System.Xml.XmlElement GetServiceElement(string name, System.Xml.XmlNode serviceNode, System.Xml.XmlNode orderNode = null)
        {
            System.Xml.XmlNode node = null;
            foreach (System.Xml.XmlNode item in serviceNode.ChildNodes)
            {
                if (item.Name != name)
                    continue;
                node = item;
                break;
            }
            if (node == null)
            {
                node = serviceNode.OwnerDocument.CreateElement(name, serviceNode.OwnerDocument.DocumentElement.NamespaceURI);
                if (orderNode == null)
                    serviceNode.AppendChild(node);
                else
                    serviceNode.InsertAfter(node, orderNode);
            }
            return (System.Xml.XmlElement)node;
        }

        IList<ServiceInformation> GetServiceInformations()
        {
            try
            {
                var sql_GetMoudles = @"SELECT * FROM ""AVA_APP_MODULE""";
                var sql_GetPackages = @"SELECT * FROM ""AVA_APP_PACKAGE"" WHERE ""PackageMainProgram"" LIKE 'BSApp.%' AND ""ApplicationModuleID"" = '{0}'";
                var services = new List<ServiceInformation>();
                if (this.DbConnection.State == ConnectionState.Broken ||
                           this.DbConnection.State == ConnectionState.Closed)
                    this.DbConnection.Open();
                var command = this.DbConnection.CreateCommand();
                command.CommandText = sql_GetMoudles;
                using (var dbReader = command.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        var service = new ServiceInformation();
                        service.ModuleID = Convert.ToString(dbReader["ModuleID"]);
                        service.ServiceDescription = Convert.ToString(dbReader["ModuleName"]);
                        if (services.FirstOrDefault(c => c.ModuleID == service.ModuleID) == null)
                            services.Add(service);
                    }
                    dbReader.Close();
                }
                command.Dispose();
                command = this.DbConnection.CreateCommand();
                foreach (var item in services)
                {
                    command.CommandText = string.Format(sql_GetPackages, item.ModuleID);
                    using (var dbReader = command.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            var info = Convert.ToString(dbReader["PackageMainProgram"]);
                            if (string.IsNullOrEmpty(info))
                                continue;
                            item.SetInformations(info);
                            break;
                        }
                        dbReader.Close();
                    }
                }
                return services;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (this.DbConnection != null)
                    this.DbConnection.Close();
            }
        }

        private class ServiceInformation
        {
            public string ServiceName
            {
                set;
                get;
            }

            public string ModuleID
            {
                set;
                get;
            }

            public string ServiceDescription
            {
                set;
                get;
            }

            public string BOServiceContract
            {
                set;
                get;
            }

            public string BOServiceBindingConfiguration
            {
                set;
                get;
            }

            public string ServicePath
            {
                set;
                get;
            }

            public void SetInformations(string info)
            {
                if (string.IsNullOrEmpty(info))
                    return;
                var tmps = info.Split('.');
                if (tmps.Length > 1)
                {
                    this.ServiceName = tmps[1];
                    this.ServicePath = this.ServiceName;
                    this.BOServiceContract = string.Format("BORep.{0}.BORepository.IBORep{0}Service", this.ServiceName);
                    this.BOServiceBindingConfiguration = "BasicHttpBinding";
                    if (this.ServiceName == "SystemApplicationCenter"
                        || this.ServiceName == "ApprovalProcess")
                    {
                        this.ServicePath = "SystemCenter";
                        this.BOServiceContract = string.Format("BORep.{0}.BORepository.IBORep{0}Service", "BusinessSystemCenter");
                    }
                }
            }
        }

        void CreateClientConfig()
        {
            var myAssembly = this.GetType().Assembly;
            var myNamespace = this.GetType().Namespace;
            System.IO.Stream setStream = null;
            foreach (var item in myAssembly.GetManifestResourceNames())
            {
                if (item.IndexOf(myNamespace) < 0) continue;
                if (!item.EndsWith("client.config", StringComparison.InvariantCultureIgnoreCase)) continue;
                setStream = myAssembly.GetManifestResourceStream(item);
            }
            if (setStream == null)
                throw new Exception(string.Format("没有找到预置文件资源。", ""));
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(setStream);
            foreach (System.Xml.XmlNode node in xmlDoc.GetElementsByTagName("endpoint"))
            {
                foreach (System.Xml.XmlAttribute item in node.Attributes)
                {
                    if (item.Name == "address")
                    {
                        if (string.IsNullOrEmpty(item.InnerText)) continue;
                        if (item.InnerText.StartsWith(this.RootAddress, StringComparison.InvariantCultureIgnoreCase)) continue;
                        item.InnerText = item.InnerText.Replace("http://localhost:3095", string.Format(@"{0}/SystemCenter", this.RootAddress));
                    }
                }
            }
            var folder = !this.WorkFolder.EndsWith(@"\") ? this.WorkFolder + @"\" : this.WorkFolder;
            xmlDoc.Save(string.Format(@"{0}SystemCenter\ClientBin\ServiceReferences.ClientConfig", folder));
            xmlDoc.Save(string.Format(@"{0}SystemCenter\ClientBin\BSUi.BusinessSystemCenter.B1Addon.x64.exe.config", folder));
            xmlDoc.Save(string.Format(@"{0}SystemCenter\ClientBin\BSUi.BusinessSystemCenter.B1Addon.x86.exe.config", folder));
            xmlDoc.Save(string.Format(@"{0}SystemCenter\ClientBin\BSUi.BusinessSystemCenter.WinCE.exe.config", folder));
        }
        void CreateWebConfig(IList<ServiceInformation> serviceinfors)
        {
            System.Configuration.Configuration cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", this.MyAppsetting.SiteName);
            //设置appsetting
            AppSettingsSection appSetting = cfg.AppSettings;
            appSettingHandle(appSetting, "DatabaseType", this.MyAppsetting.DatabaseType);
            appSettingHandle(appSetting, "DataSource", this.MyAppsetting.DBServer);
            appSettingHandle(appSetting, "InitialCatalog", this.MyAppsetting.DBName);
            appSettingHandle(appSetting, "UserID", this.MyAppsetting.DBUser);
            appSettingHandle(appSetting, "Password", this.MyAppsetting.DBPassword);
            appSettingHandle(appSetting, "B1Type", this.MyAppsetting.B1Type);
            appSettingHandle(appSetting, "B1Server", this.MyAppsetting.B1Server);
            var group = cfg.GetSectionGroup("system.serviceModel");
            var ServicesSection = group.Sections["services"] as System.ServiceModel.Configuration.ServicesSection;
            foreach (var item in serviceinfors)
            {
                System.ServiceModel.Configuration.ServiceElement targetser = null;
                foreach (System.ServiceModel.Configuration.ServiceElement Service in ServicesSection.Services)
                {
                    if (Service.Name.Contains(item.ServiceName))
                    {
                        targetser = Service;
                    }
                }
                if (targetser == null)
                {
                    targetser = new System.ServiceModel.Configuration.ServiceElement();
                    targetser.Name = string.Format("BizSys.{0}.Service.DataService.{1}JSON", item.ServicePath, item.ServiceName);
                    var sep = new System.ServiceModel.Configuration.ServiceEndpointElement();
                    sep.BehaviorConfiguration = "AjaxJSON";
                    sep.Binding = "webHttpBinding";
                    sep.Contract = string.Format("BORep.{0}.BORepository.IBORep{0}JSON", item.ServiceName);
                    targetser.Endpoints.Add(sep);
                    ServicesSection.Services.Add(targetser);
                }
                else
                {
                    targetser.Endpoints.Clear();
                    targetser.Name = string.Format("BizSys.{0}.Service.DataService.{1}JSON", item.ServicePath, item.ServiceName);
                    var sep1 = new System.ServiceModel.Configuration.ServiceEndpointElement();
                    sep1.BehaviorConfiguration = "AjaxJSON";
                    sep1.Binding = "webHttpBinding";
                    sep1.Contract = string.Format("BORep.{0}.BORepository.IBORep{0}JSON", item.ServiceName);
                    targetser.Endpoints.Add(sep1);
                }
            }
            cfg.Save();
        }
        private void appSettingHandle(AppSettingsSection appSetting, string key, string value)
        {
            if (appSetting.Settings[key] != null)
                appSetting.Settings[key].Value = value;
            else
            {
                var kve = new KeyValueConfigurationElement(key, value);
                appSetting.Settings.Add(kve);
            }
        }
    }
}
