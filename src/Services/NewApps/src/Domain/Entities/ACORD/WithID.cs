using System.Xml;
using System.Xml.Serialization;

namespace NewApps.Domain.Entities.ACORD
{
    public abstract class WithID : AcordModel
    {
        public WithID()
        {

        }

        [XmlAttribute("id")]
        public string Id { get; set; }

        public WithID(string id)
        {
            Id = id;
        }
    }

    public abstract class AcordModel : BaseEntity, IHaveOLifEExtension
    {
        [XmlElement("OLifEExtension")]
        public List<OLifEExtension> OLifEExtensions { get; set; } = new List<OLifEExtension>();
    }
    public interface IHaveOLifEExtension
    {
        List<OLifEExtension> OLifEExtensions { get; set; }
    }
}
