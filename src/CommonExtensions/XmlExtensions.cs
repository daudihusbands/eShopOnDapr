using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CommonExtensions
{
    public static class XmlExtensions
    {
        public static string PrettyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            //settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }


        public static XmlDocument ToXml<T>(this T tXLife) where T : IXmlRoot
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            //xmlSerializer.UnknownElement += Reader_UnknownElement;

            using (var stream = new MemoryStream())
            {

                XmlWriter writer = XmlWriter.Create(stream);
                xmlSerializer.Serialize(writer, tXLife);
                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                var doc = new XmlDocument();
                doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                doc.Load(stream);
                return doc;
            }
        }
        public static T FromXml<T>(this XmlDocument xmlDocument)
        {
            var stringReader = new StringReader(xmlDocument.OuterXml);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }

        public static XmlDocument XmlSerialize<T>(this T obj)
        {
            var doc = new XDocument();
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = doc.CreateWriter())
                serializer.Serialize(writer, obj);
            doc.Descendants()
                .Where(x => string.IsNullOrEmpty(x.Value) || (bool?)x.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance")) == true)
                .Remove();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(doc.Root.CreateReader());
            return xmlDoc;
        }

    }

    public interface IXmlRoot { }
}
