using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Install4ibas.Tools.Plugin.FileOperation;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileOperation.RunBatFile(@"E:\aaa\deploy_ibas_web_services.bat");
        }
    }
}
