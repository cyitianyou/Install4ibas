using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Install4ibas.UnitTest
{
    [TestClass]
    public class WebConfigTest
    {
        [TestMethod]
        public void WebConfigTestMethod()
        {
            if (!System.IO.File.Exists(@"F:\IbasTest\ibas_DistributorApplication\Web.config"))
                throw new Exception("配置文件不存在。");
            var config = new System.Xml.XmlDocument();
            config.Load(@"F:\IbasTest\ibas_DistributorApplication\Web.config");
            var appSettings = config.DocumentElement.GetElementsByTagName("appSettings");
            System.Xml.XmlNode appsettingNote;
            foreach (System.Xml.XmlNode item in appSettings)
            {
                appsettingNote = item;
            }
        }
        public System.Xml.XmlAttribute getValueAttributebyKey(string keyname,System.Xml.XmlNode appsettingNote)
        {
            System.Xml.XmlAttribute ValueAttribute=null;
            System.Xml.XmlNode rightnode = null;
            foreach (System.Xml.XmlNode item in appsettingNote.ChildNodes)
            {
                foreach (System.Xml.XmlAttribute Attribute in item.Attributes)
                {
                    if (!string.Equals(Attribute.Name, "Key", StringComparison.InvariantCultureIgnoreCase))
                        continue;
                    if (!string.Equals(Attribute.InnerText, keyname, StringComparison.InvariantCultureIgnoreCase))
                        continue;
                    rightnode = item;
                    break;
                }
                if (rightnode != null)
                    break;
            }
            if (rightnode==null)
            {
                rightnode = appsettingNote.OwnerDocument.CreateElement("add");
                var keyatt = rightnode.OwnerDocument.CreateAttribute("key");
                keyatt.InnerText = keyname;
                rightnode.Attributes.Append(keyatt);
                var valueatt = rightnode.OwnerDocument.CreateAttribute("value");
                rightnode.Attributes.Append(valueatt);
                appsettingNote.AppendChild(rightnode);
            }
            foreach (System.Xml.XmlAttribute Attribute in rightnode.Attributes)
            {
                if (!string.Equals(Attribute.Name, "value", StringComparison.InvariantCultureIgnoreCase))
                    continue;

                ValueAttribute = Attribute;
                break;
            }
            return ValueAttribute;
        }
    }
}
