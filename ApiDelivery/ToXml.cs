using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ApiDelivery
{
    public static class SerializeToXml
    {
        public static string ToXml<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var xmlserializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings();
            //settings.Indent = true;
            //settings.OmitXmlDeclaration = true;
            var stringWriter = new StringWriter();
            try
            {
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static T ConvertXml<T>(this string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new StringReader(xml));
        }
    }
}
