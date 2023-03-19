namespace NewApps.Domain.Entities.ACORD
{
    public partial class Acord
    {
        public abstract class Repository<T> where T : DTCCToAcordMapping
        {
            public abstract ICollection<T> List { get; }
            public virtual T ByDTCCCode(string dtccCode) => List.FirstOrDefault(x => x.DTCCCode == dtccCode);
            public virtual T ByAcordValue(string value) => List.FirstOrDefault(x => x.AcordValue == value);
            public virtual T Default => List.FirstOrDefault(x => x.IsDefault.GetValueOrDefault());
            public virtual T ByCodeOrDefault(string dtccCode) => List.FirstOrDefault(x => x.DTCCCode == dtccCode) ?? Default;



        }

        public class DTCCToAcordMapping
        {
            public int? TC { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string DTCCCode { get; set; }
            public string AcordValue { get; set; }
            public bool? IsDefault { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }


        public class Node
        {
            public const string TXLife = "TXLife";
            public const string OLifEExtension = "OLifEExtension";


            public const string Additional = "Additional";
            public const string SameAddressAgent = "SameAddressAgent";
            public const string SameAddressApplicant = "SameAddressApplicant";
            public const string SameAddressApplicantDetails = "SameAddressApplicantDetails";
            public const string SameAddressAgentDetails = "SameAddressAgentDetails";


            public const string Party = "Party";
            public const string PartyTypeCode = "PartyTypeCode";
            public const string Person = "Person";
            public const string BirthDate = "BirthDate";
            public const string Age = "Age";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string FullName = "FullName";

            public const string Employment = "Employment";
            public const string EmploymentOther = "EmploymentOther";
            public const string EmployerName = "EmployerName";
            public const string Occupation = "Occupation";
            public const string EmploymentStatusTC = "EmploymentStatusTC";

            public const string DriversLicenseNum = "DriversLicenseNum";
            public const string DriversLicenseState = "DriversLicenseState";
            public const string Phone = "Phone";
            public const string PhoneTypeCode = "PhoneTypeCode";



            public const string MarStat = "MarStat";
            public const string EdeliveryOptIn = "EdeliveryOptIn";
            public const string ExistingPolicies = "ExistingPolicies";
            public const string ChangePolicies = "ChangePolicies";
            public const string PolicyChange = "PolicyChange";

            public const string Verification_Of_Identity = "Verification_Of_Identity";
            public const string EdeliveryDeliverTo = "EdeliveryDeliverTo";
            public const string Producer = "Producer";
            public const string CarrierAppointment = "CarrierAppointment";
            public const string CompanyProducerID = "CompanyProducerID";
            public const string License = "License";
            public const string LicenseNum = "LicenseNum";
            public const string CommissionOption = "CommissionOption";


            public const string OriginatingObjectType = "OriginatingObjectType";
            public const string RelatedObjectType = "RelatedObjectType";
            public const string Relation = "Relation";
            public const string InterestPercent = "InterestPercent";
            public const string RelatedRefID = "RelatedRefID";
            public const string IrrevokableInd = "IrrevokableInd";

            public const string Organization = "Organization";
            public const string AbbrName = "AbbrName";

            public const string GovtID = "GovtID";
            public const string GovtIDTC = "GovtIDTC";


            public const string EstabDate = "EstabDate";
            public const string TrustType = "TrustType";
            public const string TrustTypeDesc = "TrustTypeDesc";


            public const string Holding = "Holding";
            public const string AccountDesignation = "AccountDesignation";
        }
        public class Attribute
        {
            public const string ID = "id";
            public const string TC = "tc";
            public const string OriginatingObjectID = "OriginatingObjectID";
            public const string RelatedObjectID = "RelatedObjectID";
            public const string RelationRoleCode = "RelationRoleCode";
        }

        public class OriginatingObjectTypeCode
        {
            public const string Holding = "4";
            public const string Party = "6";
        }
        public class OriginatingObjectType
        {
            public const string Holding = "Holding";
            public const string Party = "Party";
        }

    }
}
