using System.Xml;
using System.Xml.Serialization;
using MimeTypes;

namespace NewApps.Domain.Entities.ACORD
{
    public class OLifE
    {

        public SourceInfo SourceInfo { get; set; }
        public string STATUS { get; set; }
        public Holding Holding { get; set; }


        [XmlArray("EXTENSIONS")]
        [XmlArrayItem("EXTENSION")]
        public List<Extension> Extensions { get; set; }

        [XmlElement("Party")]
        public List<Party> Parties { get; set; } = new List<Party>();

        [XmlElement("Relation")]
        public List<Relation> Relations { get; set; } = new List<Relation>();

        [XmlElement("FormInstance")]
        public List<FormInstance> FormInstances { get; set; } = new List<FormInstance>();


    }


    public class SourceInfo
    {
        private SourceInfo() { }
        public SourceInfo(string keyName, string keyValue)
        {
            KeyedValue = new KeyedValue(keyName, keyValue);
        }
        public KeyedValue KeyedValue { get; set; }
    }
    public class KeyedValue
    {
        private KeyedValue() { }
        public KeyedValue(string keyName, string keyValue)
        {
            KeyName = keyName;
            KeyValue = keyValue;
        }

        public string KeyName { get; set; }
        public string KeyValue { get; set; }
    }
    public class FormInstance : WithID
    {
        private string? formInstanceVersion;
        private string? providerFormNumber;

        [XmlAttribute()]
        public string ProviderPartyID { get; set; }

        [XmlAttribute()]
        public string ReceiverPartyID { get; set; }

        public string? FormName { get; set; }
        public string? ProviderFormNumber
        {
            get => providerFormNumber; set
            {
                var split = value?.Split("|", StringSplitOptions.RemoveEmptyEntries);
                if (split?.Length > 1)
                {
                    providerFormNumber = split[0];
                    if (string.IsNullOrEmpty(FormInstanceVersion))
                        FormInstanceVersion = split[1];
                }
                else
                    providerFormNumber = value;

                // if ProviderFormNumber == "ApplicationKit"
                // split the FormName field, then drop the file extension


            }
        }
        public string? FormInstanceVersion { get; set; }

        public string? DocumentControlNumber { get; set; }
        public WithTC DocumentControlType { get; set; }
        public WithTC OriginatingTransType { get; set; }

        public Attachment Attachment { get; set; }

        public string Extension
        {
            get
            {
                var mediaType = Attachment.MimeTypeTC?.TC;

                try
                {
                    if (!string.IsNullOrEmpty(mediaType))
                    {
                        if (mediaType == "17")
                            return "pdf";
                        else if (mediaType == "11")
                            return "tiff";
                    }
                    return MimeTypeMap.GetExtension(mediaType);
                }
                catch { }
                return "unknown";
            }
        }

        public Include GetInclude() => Attachment?.AttachmentData64Binary?.Include;
        public byte[] GetFileData() => GetInclude()?.XopData;
    }
    public class Attachment : WithID
    {
        public DateTime DateCreated { get; set; }
        public WithTC AttachmentBasicType { get; set; }

        public AttachmentData64Binary AttachmentData64Binary { get; set; } = new AttachmentData64Binary();
        public AttachmentData64 AttachmentData64 { get; set; }
        public WithTC AttachmentType { get; set; }
        public WithTC MimeTypeTC { get; set; }
        public WithTC TransferEncodingTypeTC { get; set; }
        public WithTC AttachmentLocation { get; set; }
        public string AttachmentHashValue { get; set; }
        public WithTC AttachmentHashType { get; set; }

    }
    public class AttachmentData64Binary
    {
        [XmlElement(Namespace = "http://www.w3.org/2004/08/xop/include")]
        public Include Include { get; set; } = new Include();

    }
    public class AttachmentData64
    {
        [XmlElement(Namespace = "http://www.w3.org/2004/08/xop/include")]
        public Include Include { get; set; }

    }
    public class Include
    {
        [XmlAttribute("href")]
        public string HRef { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public byte[] XopData { get; set; }

        [XmlIgnore]
        public string FileName { get; set; }
    }
}
