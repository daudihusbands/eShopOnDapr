using System.Xml;
using System.Xml.Serialization;

namespace NewApps.Domain.Entities.ACORD
{
    public class WithTC : BaseEntity
    {
        protected WithTC() { }
        protected WithTC(string tC, string value)
        {
            TC = tC;
            Value = value;
        }
        public static WithTC Create(int TC, string? Value = null) => new WithTC(TC.ToString(), Value);
        public static WithTC Create(string TC, string? Value = null) => new WithTC(TC, Value);


        [XmlAttribute("tc")]
        public string TC { get; set; }

        [XmlText]
        public string Value { get; set; }

    }

    //public abstract class Repository<T> where T : DTCCToAcordMapping
    //{
    //    public abstract ICollection<T> List { get; }
    //    public virtual T ByDTCCCode(string dtccCode) => List.FirstOrDefault(x => x.DTCCCode == dtccCode);
    //    public virtual T ByAcordValue(string value) => List.FirstOrDefault(x => x.AcordValue == value);
    //    public virtual T Default => List.FirstOrDefault(x => x.IsDefault.GetValueOrDefault());

    //    public virtual T ByCodeOrDefault(string dtccCode) => List.FirstOrDefault(x => x.DTCCCode == dtccCode) ?? Default;

    //}

}
