using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Install4ibas.Tools.Plugin.DbManager;
using System.IO;
using Install4ibas.Tools.Plugin;
using Install4ibas.Tools.Plugin.IISManager;
using Microsoft.Web.Administration;
using Install4ibas.Tools.Core;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AppSetting appSetting = new AppSetting();
            appSetting.SiteName = "SBO_TEST";
            appSetting.LoadSiteInfo();
            var str = appSetting.Licenses.ToString();
        }
    }
}
