using System.Xml.Serialization;

namespace NewApps.Domain.Entities.ACORD
{
    public class Party : WithID
    {
        public Party()
        {

        }
        public Party(string partyId, string contractEntityID)
        {
            Id = partyId;
            ContractEntityID = contractEntityID;
        }
        [XmlIgnore]
        public string ContractEntityID { get; set; }
        public WithTC PartyTypeCode { get; set; }
        public string FullName { get; set; }
        public string GovtID { get; set; }
        public WithTC GovtIDTC { get; set; }

        [XmlElement("Address")]
        public List<Address> Addresses { get; set; } = new List<Address>();

        [XmlElement("EMailAddress")]
        public List<EMailAddress> EmailAddresses { get; set; } = new List<EMailAddress>();


        [XmlElement("Phone")]
        public List<Phone> Phones { get; set; } = new List<Phone>();


        public Person Person { get; set; }

        public Organization Organization { get; set; }

        public Employment Employment { get; set; }
        public Producer Producer { get; set; } = new Producer();


        [XmlIgnore]
        public string BirthDate => Person?.BirthDate ?? "";
        public override string ToString() => $"{FullName} ({PartyTypeCode?.TC}:{PartyTypeCode.Value})";
    }
    public class Phone
    {
        public Phone()
        {

        }
        public Phone(string areaCode, string dialNumber, string? extension = null, WithTC? phoneTypeCode = null)
        {
            AreaCode = areaCode;
            DialNumber = dialNumber;
            Extension = extension;
            PhoneTypeCode = phoneTypeCode;
        }

        public WithTC PhoneTypeCode { get; set; }
        public string AreaCode { get; set; }
        public string DialNumber { get; set; }
        public string Extension { get; set; }
    }
    public class Person
    {
        public Person()
        {

        }
        private DateTime? birthDate;



        public string BirthDate { get => birthDate.HasValue ? birthDate.Value.ToString("yyyy-MM-dd") : ""; set => birthDate = DateTime.Parse(value); }
        public bool ShouldSerializeBirthDate() => !string.IsNullOrWhiteSpace(BirthDate);
        public int? Age { get; set; }
        public bool ShouldSerializeAge() => Age.HasValue;
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public WithTC Gender { get; set; }
        [XmlElement("MarStat")]
        public WithTC MaritalStatus { get; set; }
        public string DriversLicenseNum { get; set; }
        public WithTC DriversLicenseState { get; set; }
        public string MiddleName { get; set; }
        public WithTC Citizenship { get; set; }
    }
    public class Producer
    {
        public CarrierAppointment CarrierAppointment { get; set; } = new CarrierAppointment();
        public License License { get; set; } = new License();
        public OLifEExtension OLifEExtension { get; set; }
    }
    public class License
    {
        public string LicenseNum { get; set; }
    }
    public class CarrierAppointment
    {
        public string CompanyProducerID { get; set; }
    }
    public class Employment : AcordModel
    {
        public string EmployerName { get; set; }
        public WithTC EmploymentStatusTC { get; set; }
        public string Occupation { get; set; }
    }
    public class Organization
    {
        public string AbbrName { get; set; }
        public string DTCCMemberCode { get; set; }
        public string DTCCAssociatedMemberCode { get; set; }
        public string EstabDate { get; set; }
        public WithTC TrustType { get; set; }
        public string TrustTypeDesc { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Line5 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public WithTC AddressStateTC { get; set; }
        public WithTC AddressTypeCode { get; set; }
    }

    public class EMailAddress
    {
        public EMailAddress()
        {

        }
        public WithTC EMailType { get; set; }
        public string AddrLine { get; set; }
        public EMailAddress(string addrLine, WithTC? eMailType = null)
        {
            AddrLine = addrLine;
            EMailType = eMailType;
        }
    }

}
