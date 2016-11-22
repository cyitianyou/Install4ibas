using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Install4ibas.Tools.Plugin.FileOperation;
using System.IO;
using Install4ibas.Tools.Core.InstallInformation;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Reflection;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class TestIbasModules
    {
        [TestMethod]
        public void TestMethod1()
        {
            ibasModules modules = new ibasModules();
            var module=new ibasModule();
            module.ModuleId = "nihao"; 
            module.Type = emModuleType.basic;
            modules.Add(module);
            //var knownTypes = new List<Type>() { typeof(AppSetting), typeof(IList<InstallInformationStep>) };
            //Assembly assembly = Assembly.GetAssembly(typeof(AppSetting));
            //var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(AppSetting), null, int.MaxValue, false, true, null, new MyDataContractResolver(assembly));
            var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ibasModules));
            var stringbuilder = new StringBuilder();
            var xml = System.Xml.XmlWriter.Create(stringbuilder);
            serializer.WriteObject(xml, modules);
            xml.Flush();
            var str = stringbuilder.ToString();
        }
    }

}
