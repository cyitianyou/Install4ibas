using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Configuration.Configuration cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/","ibas_DistributorApplication");
            var group = cfg.GetSectionGroup("system.serviceModel");
            var services = group.Sections["services"] as System.ServiceModel.Configuration.ServicesSection;
            var service = new System.ServiceModel.Configuration.ServiceElement();
          
            AppSettingsSection appSetting = cfg.AppSettings;
            appSetting.Settings["a"].Value = "changed by application";
            
            cfg.Save(); 
        }
    }
}
