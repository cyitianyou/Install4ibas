using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Plugin
{
    public static class Serializer
    {
        public static T FromXmlFile<T>(string fileName)
        {
            T result = default(T);
            try
            {
                if (!File.Exists(fileName)) throw new Exception();
                var stream = File.OpenRead(fileName);
                if (stream == null) throw new Exception();
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
                result = (T)serializer.ReadObject(stream);
            }
            catch (Exception)
            {
                
            }
            return result;
        }

        public static string ToXmlString<T>(this T model)
        {
            var result = String.Empty;
            try
            {
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
                var stringbuilder = new StringBuilder();
                var xml = System.Xml.XmlWriter.Create(stringbuilder);
                serializer.WriteObject(xml, model);
                xml.Flush();
                result = stringbuilder.ToString();
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
