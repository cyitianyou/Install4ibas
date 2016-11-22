using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Install4ibas.Tools.Plugin.DbManager;
using System.IO;
using Install4ibas.Tools.Core;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Reflection;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            AppSetting setting = new AppSetting();
            setting.Steps.Add(new InstallInformationStep());
            setting.Steps[0].StepCode = "sdf";
            //var knownTypes = new List<Type>() { typeof(AppSetting), typeof(IList<InstallInformationStep>) };
            //Assembly assembly = Assembly.GetAssembly(typeof(AppSetting));
            //var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(AppSetting), null, int.MaxValue, false, true, null, new MyDataContractResolver(assembly));
            var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(AppSetting));
            var stringbuilder = new StringBuilder();
            var xml = System.Xml.XmlWriter.Create(stringbuilder);
            serializer.WriteObject(xml, setting);
            xml.Flush();
            var str = stringbuilder.ToString();
        }
    }

    public class MyDataContractResolver : DataContractResolver
    {
        private Dictionary<string, XmlDictionaryString> dictionary = new Dictionary<string, XmlDictionaryString>();
        Assembly assembly;

        public MyDataContractResolver(Assembly assembly)
        {
            this.assembly = assembly;
        }

        // Used at serialization
        // Maps any Type to a new xsi:type representation
        public void ResolveType(Type dataContractType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            string name = dataContractType.Name;
            string namesp = dataContractType.Namespace;
            typeName = new XmlDictionaryString(XmlDictionary.Empty, name, 0);
            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, namesp, 0);
            if (!dictionary.ContainsKey(dataContractType.Name))
            {
                dictionary.Add(name, typeName);
            }
            if (!dictionary.ContainsKey(dataContractType.Namespace))
            {
                dictionary.Add(namesp, typeNamespace);
            }
        }

        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            XmlDictionaryString tName;
            XmlDictionaryString tNamespace;
            if (dictionary.TryGetValue(typeName, out tName) && dictionary.TryGetValue(typeNamespace, out tNamespace))
            {
                return this.assembly.GetType(tNamespace.Value + "." + tName.Value);
            }
            else
            {
                return null;
            }
        }

        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {


            string name = type.Name;
            string namesp = type.Namespace;
            typeName = new XmlDictionaryString(XmlDictionary.Empty, name, 0);
            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, namesp, 0);
            try
            {
                if (!dictionary.ContainsKey(type.Name))
                {
                    dictionary.Add(name, typeName);
                }
                if (!dictionary.ContainsKey(type.Namespace))
                {
                    dictionary.Add(namesp, typeNamespace);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
