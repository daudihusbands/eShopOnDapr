using System.Collections.ObjectModel;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NewApps.Domain.Entities.ACORD
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class AcordAttachmentEnvelope : BaseEntity, IXmlRoot
    {
        public static AcordAttachmentEnvelope FromXml(Stream stream)
        {
            var reader = new XmlSerializer(typeof(AcordAttachmentEnvelope));
            return (AcordAttachmentEnvelope)reader.Deserialize(stream);
        }

        [XmlElement("HEADER")]
        public Header Header { get; set; }

        [XmlElement(ElementName = "attachmentRequestRequest")]
        public List<AttachmentRequestRequest> AttachmentRequestRequests { get; set; }

        [XmlElement(Type = typeof(Body), Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }

        public TXLife GetTXLifeResponse() => Body?.AttachmentRequestResponse?.TXLife;

    }
    public class Header
    {
        public string SENDING_PARTY_ID { get; set; }
        public string RECEIVING_PARTY_ID { get; set; }
        public int TRANSACTION_COUNT { get; set; }
        public bool TEST { get; set; }
        public DateTime CREATE_DATETIME { get; set; }
    }

    public class Body
    {
        [XmlElement(ElementName = "attachmentRequestResponse", Namespace = "http://service.attachments.dtcc.com")]
        public AttachmentRequestResponse AttachmentRequestResponse { get; set; }
    }

    public class AttachmentRequestResponse
    {
        [XmlElement(Type = typeof(TXLife), Namespace = "http://ACORD.org/Standards/Life/2")]
        public TXLife TXLife { get; set; }
    }

    public class AttachmentRequestRequest
    {
        public MessageHeader MessageHeader { get; set; }

        [XmlElement("attachmentRequest")]
        public AttachmentRequest AttachmentRequest { get; set; }
    }
    public class MessageHeader
    {
        public string MessageName { get; set; }
        public RouteInfo RouteInfo { get; set; }
        public string TRANSACTION_TYPE { get; set; }
    }
    public class RouteInfo
    {
        public string RECEIVING_PARTY_ID { get; set; }
        public string SENDING_PARTY_ID { get; set; }
        public int ORDER { get; set; }
        public DateTime? SEND_DATETIME { get; set; }

    }
    [XmlRoot(ElementName = "attachmentRequest", Namespace = "http://service.attachments.dtcc.com")]
    public class AttachmentRequest
    {
        [XmlElement(Type = typeof(TXLife), Namespace = "http://ACORD.org/Standards/Life/2")]
        //[XmlElement(Type = typeof(TXLife), Namespace = "http://www.w3.org/2004/08/xop/include")]
        //[XmlElement(Type = typeof(TXLife), Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        //[XmlElement(Type = typeof(TXLife), Namespace = "http://ACORD.org/Standards/Life/2 file:///Acord103ExampleWithEmptyFormData.xsd")]
        public TXLife TXLife { get; set; }

        public ICollection<FormInstance> GetFormInstances() =>
                TXLife?.TXLifeRequest?.OLifE?.FormInstances;
    }


    [Owned]
    public class ApplicationInfo
    {
        private ApplicationInfo() { }
        public ApplicationInfo(string trackingID)
        {
            TrackingID = trackingID;
        }

        public string TrackingID { get; set; }

        [XmlElement(nameof(SignatureInfo))]
        public List<SignatureInfo> SignatureInfos { get; set; } = new List<SignatureInfo>();
    }

    [Owned]
    public class SignatureInfo
    {
        [XmlAttribute]
        public string SignaturePartyID { get; set; }

        public string SignatureDate { get; set; }
        public WithTC SignatureOK { get; set; }
    }


    public class DynamicXml : DynamicObject
    {
        public DynamicXml()
        {

        }

        readonly XElement _root;
        public DynamicXml(XElement root)
        {
            _root = root;
        }

        public static DynamicXml Parse(string xmlString)
        {
            return new DynamicXml(RemoveNamespaces(XDocument.Parse(xmlString).Root));
        }

        public static DynamicXml Load(string filename)
        {
            return new DynamicXml(RemoveNamespaces(XDocument.Load(filename).Root));
        }

        private static XElement RemoveNamespaces(XElement xElem)
        {
            var attrs = xElem.Attributes()
                        .Where(a => !a.IsNamespaceDeclaration)
                        .Select(a => new XAttribute(a.Name.LocalName, a.Value))
                        .ToList();

            if (!xElem.HasElements)
            {
                XElement xElement = new XElement(xElem.Name.LocalName, attrs);
                xElement.Value = xElem.Value;
                return xElement;
            }

            var newXElem = new XElement(xElem.Name.LocalName, xElem.Elements().Select(e => RemoveNamespaces(e)));
            newXElem.Add(attrs);
            return newXElem;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            result = null;

            var att = _root.Attribute(binder.Name);
            if (att != null)
            {
                result = att.Value;
                return true;
            }

            var nodes = _root.Elements(binder.Name);
            if (nodes.Count() > 1)
            {
                result = nodes.Select(n => n.HasElements ? (object)new DynamicXml(n) : n.Value).ToList();
                return true;
            }

            var node = _root.Element(binder.Name);
            if (node != null)
            {
                result = node.HasElements || node.HasAttributes ? new DynamicXml(node) : node.Value;
                return true;
            }

            return true;
        }


    }

    public class SerialisableDictionary<T1, T2> : Dictionary<T1, T2>, IXmlSerializable
        where T1 : class
        where T2 : class

    {
        private static readonly DataContractSerializer serializer =
            new DataContractSerializer(typeof(Dictionary<T1, T2>));

        public void WriteXml(XmlWriter writer)
        {
            serializer.WriteObject(writer, this);
        }

        public void ReadXml(XmlReader reader)
        {
            Dictionary<T1, T2> deserialised =
                (Dictionary<T1, T2>)serializer.ReadObject(reader);

            foreach (KeyValuePair<T1, T2> kvp in deserialised)
            {
                Add(kvp.Key, kvp.Value);
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }
    }

    public class XmlSerializerForDictionary
    {

        public struct Pair<TKey, TValue>
        {

            public TKey Key;
            public TValue Value;

            public Pair(KeyValuePair<TKey, TValue> pair)
            {
                Key = pair.Key;
                Value = pair.Value;
            }//method

        }//struct

        public static void WriteXml<TKey, TValue>(XmlWriter writer, IDictionary<TKey, TValue> dict)
        {

            var list = new List<Pair<TKey, TValue>>(dict.Count);

            foreach (var pair in dict)
            {
                list.Add(new Pair<TKey, TValue>(pair));
            }//foreach

            var serializer = new XmlSerializer(list.GetType());
            serializer.Serialize(writer, list);

        }//method

        public static void ReadXml<TKey, TValue>(XmlReader reader, IDictionary<TKey, TValue> dict)
        {

            reader.Read();

            var serializer = new XmlSerializer(typeof(List<Pair<TKey, TValue>>));
            var list = (List<Pair<TKey, TValue>>)serializer.Deserialize(reader);

            foreach (var pair in list)
            {
                dict.Add(pair.Key, pair.Value);
            }//foreach

            reader.Read();

        }//method

    }//class


    [XmlRoot("SerializableDictionary")]
    public class SerializableDictionary : Dictionary<string, object>, IXmlSerializable
    {
        internal bool _ReadOnly = false;
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }

            set
            {
                CheckReadOnly();
                _ReadOnly = value;
            }
        }

        public new object this[string key]
        {
            get
            {
                object value;

                return TryGetValue(key, out value) ? value : null;
            }

            set
            {
                CheckReadOnly();

                if (value != null)
                {
                    base[key] = value;
                }
                else
                {
                    Remove(key);
                }
            }
        }

        internal void CheckReadOnly()
        {
            if (_ReadOnly)
            {
                throw new Exception("Collection is read only");
            }
        }

        public new void Clear()
        {
            CheckReadOnly();

            base.Clear();
        }

        public new void Add(string key, object value)
        {
            CheckReadOnly();

            base.Add(key, value);
        }

        public new void Remove(string key)
        {
            CheckReadOnly();

            base.Remove(key);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;

            reader.Read();

            if (wasEmpty)
            {
                return;
            }

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.Name == "Item")
                {
                    string key = reader.GetAttribute("Key");
                    Type type = Type.GetType(reader.GetAttribute("TypeName"));

                    reader.Read();
                    if (type != null)
                    {
                        Add(key, new XmlSerializer(type).Deserialize(reader));
                    }
                    else
                    {
                        reader.Skip();
                    }
                    reader.ReadEndElement();

                    reader.MoveToContent();
                }
                else
                {
                    reader.ReadToFollowing("Item");
                }

                reader.ReadEndElement();
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (KeyValuePair<string, object> item in this)
            {
                writer.WriteStartElement("Item");
                writer.WriteAttributeString("Key", item.Key);
                writer.WriteAttributeString("TypeName", item.Value.GetType().AssemblyQualifiedName);

                new XmlSerializer(item.Value.GetType()).Serialize(writer, item.Value);

                writer.WriteEndElement();
            }
        }

    }

    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {

        public virtual void WriteXml(XmlWriter writer)
        {
            XmlSerializerForDictionary.WriteXml(writer, this);
        }//method

        public virtual void ReadXml(XmlReader reader)
        {
            XmlSerializerForDictionary.ReadXml(reader, this);
        }//method

        public virtual XmlSchema GetSchema()
        {
            return null;
        }//method

    }//class


    /// <summary>
    /// Proxy class to permit XML Serialization of generic dictionaries
    /// </summary>
    /// <typeparam name="K">The type of the key</typeparam>
    /// <typeparam name="V">The type of the value</typeparam>
    public class DictionaryProxy<K, V>
    {
        #region Construction and Initialization
        public DictionaryProxy(IDictionary<K, V> original)
        {
            Original = original;
        }

        /// <summary>
        /// Default constructor so deserialization works
        /// </summary>
        public DictionaryProxy()
        {
        }

        /// <summary>
        /// Use to set the dictionary if necessary, but don't serialize
        /// </summary>
        [XmlIgnore]
        public IDictionary<K, V> Original { get; set; }
        #endregion

        #region The Proxy List
        /// <summary>
        /// Holds the keys and values
        /// </summary>
        public class KeyAndValue
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }

        // This field will store the deserialized list
        private Collection<KeyAndValue> _list;

        /// <remarks>
        /// XmlElementAttribute is used to prevent extra nesting level. It's
        /// not necessary.
        /// </remarks>
        [XmlElement]
        public Collection<KeyAndValue> KeysAndValues
        {
            get
            {
                if (_list == null)
                {
                    _list = new Collection<KeyAndValue>();
                }

                // On deserialization, Original will be null, just return what we have
                if (Original == null)
                {
                    return _list;
                }

                // If Original was present, add each of its elements to the list
                _list.Clear();
                foreach (var pair in Original)
                {
                    _list.Add(new KeyAndValue { Key = pair.Key, Value = pair.Value });
                }

                return _list;
            }
        }
        #endregion

        /// <summary>
        /// Convenience method to return a dictionary from this proxy instance
        /// </summary>
        /// <returns></returns>
        public Dictionary<K, V> ToDictionary()
        {
            return KeysAndValues.ToDictionary(key => key.Key, value => value.Value);
        }
    }

    public static class XmlDictionaryHelper
    {
        public static string Serialize<T>(this T obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            using (var writer = new StringWriter())
            using (var stm = new XmlTextWriter(writer))
            {
                serializer.WriteObject(stm, obj);
                return writer.ToString();
            }
        }
        public static T Deserialize<T>(this string serialized)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (var reader = new StringReader(serialized))
            using (var stm = new XmlTextReader(reader))
            {
                return (T)serializer.ReadObject(stm);
            }
        }
    }
    [Owned]
    public class SERVICE_PROGRAM
    {
        [XmlArray("IDS")]
        [XmlArrayItem("ID")]
        public List<SERVICE_PROGRAM_Id> IDs { get; set; }

        [XmlArray("EXTENSIONS")]
        [XmlArrayItem("EXTENSION")]
        public List<Extension> Extensions { get; set; }

        [XmlArray("OPTION_LINKS")]
        [XmlArrayItem("OPTION_LINK")]
        public List<OptionLink> OptionLinks { get; set; }

        [XmlElement("SCHEDULE")]
        public Schedule Schedule { get; set; }
    }
    [Owned]
    public class SERVICE_PROGRAM_Id
    {
        [XmlAttribute]
        public string PARTY_ID { get; set; }

        [XmlText]
        public string PARTY_NAME { get; set; }
    }

    [Owned]
    public class Extension
    {
        [XmlArray("IDS")]
        [XmlArrayItem("ID")]
        public List<SERVICE_PROGRAM_Id> IDs { get; set; }


        [XmlArray("PARAMETERS")]
        [XmlArrayItem("PARAMETER")]
        public List<Parameter> Parameters { get; set; }

    }
    [Owned]
    public class Parameter
    {
        [XmlElement("NAME")]
        public string Name { get; set; }
        [XmlElement("VALUE")]
        public string Value { get; set; }
    }
    [Owned]
    public class OptionLink
    {
        [XmlArray("IDS")]
        [XmlArrayItem("ID")]
        public List<SERVICE_PROGRAM_Id> IDs { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

    }

    [Owned]
    public class Schedule
    {
        [XmlElement("FREQUENCY")]
        public string Frequency { get; set; }
        [XmlElement("START_DATE")]
        public DateTime? StartDate { get; set; }
    }

    [Owned]
    public class WorkflowStep
    {
        public DateTime AS_OF_DATETIME { get; set; }
        public string ACTION_TAKEN { get; set; }
        public string STATUS { get; set; }

        [XmlArray("EXTENSIONS")]
        [XmlArrayItem("EXTENSION")]
        public List<Extension> Extensions { get; set; }

    }
}
