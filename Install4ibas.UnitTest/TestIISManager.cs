using Microsoft.VisualStudio.TestTools.UnitTesting;
using Install4ibas.Tools.Plugin.IISManager;
using Install4ibas.Tools.Plugin.FileOperation;
using Install4ibas.Tools.Services.NewInstall;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class TestIISManager
    {
        [TestMethod]
        public void TestMethod1()
        {
            //FileOperation.CopyResourceFiles("");
            var service = new NewInstallService();
            //service.GetPresetInstallInformation();
        }
    }
}
