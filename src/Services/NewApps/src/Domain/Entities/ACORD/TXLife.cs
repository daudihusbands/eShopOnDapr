using System.Xml;
using System.Xml.Serialization;

namespace NewApps.Domain.Entities.ACORD
{
    [Serializable, XmlRoot(ElementName = "TXLife", Namespace = "http://ACORD.org/Standards/Life/2", IsNullable = false)]
    public class TXLife : IXmlRoot
    {

        private static readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(TXLife));
        public TXLife()
        {
            xmlSerializer.UnknownElement += Reader_UnknownElement;
        }

        public static TXLife FromXml(Stream stream)
        {
            //var reader = new XmlSerializer(typeof(TXLife));

            //reader.UnknownElement += Reader_UnknownElement;
            var res = (TXLife)xmlSerializer.Deserialize(stream);
            return res;
        }

        private static void Reader_UnknownElement(object sender, XmlElementEventArgs e)
        {
            if (e.Element.LocalName == "Additional")
            {
                var suitability = (Suitability)e.ObjectBeingDeserialized;
                var additional = suitability.Additional ?? new Suitability.SuitabilityAdditional();
                foreach (var el in e.Element.ChildNodes.OfType<XmlElement>())
                {
                    //var intVal = Convert.ToBoolean(int.Parse(el.InnerText));
                    additional.Items.Add(el.LocalName, el.InnerText);
                }
            }
        }



        public TXLifeRequest TXLifeRequest { get; set; }
        public TXLifeResponse TXLifeResponse { get; set; }


        [XmlAttribute]
        public string Version { get; set; }

        [XmlIgnore]
        public string PolicyNumber => Policy?.PolNumber;


        [XmlIgnore]
        public string TransRefGUID => TXLifeRequest.TransRefGUID;

        [XmlIgnore]
        [JsonIgnore]
        public Policy Policy => TXLifeRequest?.OLifE?.Holding?.Policy;
    }
}
