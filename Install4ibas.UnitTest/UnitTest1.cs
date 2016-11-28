using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Install4ibas.Tools.Plugin.DbManager;
using System.IO;
using Install4ibas.Tools.Plugin;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileOperation.RunBatFile(@"E:\WebSite\SBO_TEST\deploy_ibas_web_services.bat");
                // string[] fileList = System.IO.Directory.GetFileSystemEntries(@"F:\奥维科技\发布\1111\~packages");
                // string[] fileList2 = System.IO.Directory.GetFiles(@"F:\奥维科技\发布\1111\~packages");
                //// 遍历所有的文件和目录
                //foreach (string file in fileList)
                //{
                //   string filename=  Path.GetFileName(file);
                //   if (filename.StartsWith("ibas_4_modules_published") && filename.EndsWith("zip"))
                //   {
                //       string modulename = filename.Substring(filename.LastIndexOf("_BizSys") + 8, filename.Length - filename.LastIndexOf("_BizSys") -12);
                //   }
                //}
        }
    }
}
