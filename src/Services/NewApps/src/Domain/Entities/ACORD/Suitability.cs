using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NewApps.Domain.Entities.ACORD
{
    [Owned]
    public class Suitability// : SerialisableDictionary<string, bool?>
    {
        public SuitabilityAdditional Additional { get; set; } = new SuitabilityAdditional();
        public SuitabilityAgent Agent { get; set; }

        public string OwnAnnuities { get; set; }
        public string OwnLifeInsurance { get; set; }
        public string SOPIncome { get; set; }
        public string SOPGrowth { get; set; }
        public string PassAssetsBeneficiary { get; set; }
        public string ProposedAnnuityReplaceProduct { get; set; }
        public string ProposedAnnuityPayPenalty { get; set; }
        public string ProvideInfoRefuse { get; set; }
        public string ProvideInfoLimited { get; set; }
        public string ProvideInfoNotBased { get; set; }
        public string ProvideInfoBased { get; set; }



        [Owned]
        public class SuitabilityAgent
        {
            public string AgentRecommendSuitableAnnuityDetails { get; set; }
        }
        [Owned]
        public class SuitabilityAdditional //: SerialisableDictionary<string, int>//, IXmlSerializable
        {

            [XmlIgnore]
            public string Name { get; set; }

            [NotMapped]
            public Dictionary<string, string> Items { get; set; } = new Dictionary<string, string>();

            public string ResideNursingHomeFacility { get; set; }
            public string ConsultedHealthCareAdvisor { get; set; }
            public string SurrenderPolicyEarly { get; set; }
            public string InterestCreditsFluctuate { get; set; }
            public string AcceptNonGuaranteeElements { get; set; }
            public string AgentSoldPolicies { get; set; }
            public string SameAddressAgent { get; set; }
            public string SameAddressAgentDetails { get; set; }
            public string AgentSoldPoliciesNumber { get; set; }
            public string AgentSoldPoliciesNumberInforce { get; set; }
            public string ConsultedHealthCareAdvisorDetails { get; set; }
            public string ResideNursingHomeFacilityDetails { get; set; }
            public string AnnuityPurchaseOtherInfoDetails { get; set; }
            public string SameAddressApplicantDetails { get; set; }
            public string SameAddressApplicant { get; set; }
        }

    }
}
