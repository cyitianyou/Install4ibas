using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Install4ibas.Tools.Plugin.DbManager;
using System.IO;
using Install4ibas.Tools.Plugin;
using Install4ibas.Tools.Plugin.IISManager;
using Microsoft.Web.Administration;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Site site = IISManagerFactory.New().CreateIISManager().GetSite("SBO_TEST"); ;
            var path = site.Applications["/"].VirtualDirectories["/"].PhysicalPath;
            var binding = site.Bindings[0];
        }
    }
}
