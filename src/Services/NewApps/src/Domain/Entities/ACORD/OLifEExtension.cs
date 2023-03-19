using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NewApps.Domain.Entities.ACORD
{
    public class OLifEExtension : BaseEntity
    {
        private DateTime? dateOfDeath;
        public OLifEExtension()
        {

        }
        public OLifEExtension(string extensionCode, string vendorCode = "25")
        {
            VendorCode = vendorCode;
            ExtensionCode = extensionCode;
        }


        [XmlAttribute]
        public string VendorCode { get; set; } = "25";

        [XmlAttribute]
        public string ExtensionCode { get; set; }



        public string DateOfDeath { get => dateOfDeath.HasValue ? dateOfDeath.Value.ToString("yyyy-MM-dd") : ""; set => dateOfDeath = DateTime.Parse(value); }
        public bool ShouldSerializeDateOfDeath() => dateOfDeath != null;



        public bool ShouldSerializeOptionBBenefitPct() => OptionBBenefitPct != null;
        public double? OptionBBenefitPct { get; set; }

        public bool ShouldSerializeOptionHBenefitPct() => OptionHBenefitPct != null;
        public double? OptionHBenefitPct { get; set; }

        public bool ShouldSerializeOptionIBenefitPct() => OptionIBenefitPct != null;
        public double? OptionIBenefitPct { get; set; }



        public bool ShouldSerializeOptionLBenefitPct() => OptionLBenefitPct != null;
        public double? OptionLBenefitPct { get; set; }



        public bool ShouldSerializeOptionJBenefitPct() => OptionJBenefitPct != null;
        public double? OptionJBenefitPct { get; set; }


        public bool ShouldSerializeOptionEBenefitPct() => OptionEBenefitPct != null;
        public double? OptionEBenefitPct { get; set; }


        public bool ShouldSerializeOptionFBenefitPct() => OptionFBenefitPct != null;
        public double? OptionFBenefitPct { get; set; }



        public string CDSCPeriodElection { get; set; }

        public string AnnuityWithdrawalChargePeriod { get; set; }
        public string OwnerFullName { get; set; }
        public string DistributorTransactionIdNumber { get; set; }
        public string PremiumControlNumber { get; set; }

        public Suitability Suitability { get; set; }
        public DistributionOption DistributionOption { get; set; }
        public FinancialTimeHorizon FinancialTimeHorizon { get; set; }
        public SourceOfFunds SourceOfFunds { get; set; }

        public FinancialInfo FinancialInfo { get; set; }
        public FinancialExperience FinancialExperience { get; set; }
        public string EmploymentOther { get; set; }
        public string EdeliveryOptIn { get; set; }
        public string ExistingPolicies { get; set; }
        public string ChangePolicies { get; set; }
        public string Verification_Of_Identity { get; set; }
        public string EdeliveryDeliverTo { get; set; }
        public NonLiquidAssets NonLiquidAssets { get; set; }
        public LiquidAssets LiquidAssets { get; set; }
        public FinancialObjective FinancialObjective { get; set; }
        public DeathBenefitPaymentOptions DeathBenefitPaymentOptions { get; set; }
        public string PriorYearAmt { get; set; }
        public string FormNumber { get; set; }
        public string PolicyChange { get; set; }
        public ExchangeOrReplacement ExchangeorReplacement { get; set; }
        public string CommissionOption { get; set; }
    }
    [Owned]
    public class SourceOfFunds
    {
        public string CD { get; set; }
        public string CheckingAccount { get; set; }
        public string DeathBenefit { get; set; }
        public string DeathBenefitInfo { get; set; }
        public string FixedIndexedAnnuity { get; set; }
        public string LifeInsurance { get; set; }
        public string MoneyMarket { get; set; }
        public string MutualFunds { get; set; }
        public string Other { get; set; }
        public string OtherInfo { get; set; }
        public string ReverseMortgage { get; set; }
        public string VariableAnnuity { get; set; }
    }

    [Owned]
    public class SourceOfIncome
    {
        public string Wages { get; set; }
        public string Investments { get; set; }
        public string Other { get; set; }
        public string OtherDetails { get; set; }
        public string Pension { get; set; }
        public string SocialSecurity { get; set; }
    }
    [Owned]
    public class FinancialInfo
    {
        public string AnnualExpenses { get; set; }
        public SourceOfIncome SourceOfIncome { get; set; }
        public LiquidityNeeds LiquidityNeeds { get; set; }


    }
    [Owned]
    public class LiquidityNeeds
    {
        //[XmlElement(DataType = "currency")]
        public string LiquidNetWorth { get; set; }
        public string ExpectedChanges { get; set; }
        public string Sufficient { get; set; }
        public string ExpectedChangesDetails { get; set; }
    }
    [Owned]
    public class LiquidAssets
    {
        public string StocksBonds { get; set; }
        public string Annuities { get; set; }
        public string MutualFunds { get; set; }
        public string CDs { get; set; }
        public string MoneyMarket { get; set; }
        public string CheckingSavings { get; set; }
        public string Pension401k { get; set; }
        public string LifeInsCashSurr { get; set; }
        public string Other { get; set; }
        public string Total { get; set; }

    }
    [Owned]
    public class NonLiquidAssets
    {
        public string RealEstate { get; set; }
        public string Annuities { get; set; }
        public string Pension401k { get; set; }
        public string LimitedPartnership { get; set; }
        public string Other { get; set; }
        public string Total { get; set; }
    }
    [Owned]
    public class FinancialExperience
    {
        public string RiskTolerance { get; set; }
        public ProductsOwn ProductsOwn { get; set; }
        public string ExistingAssetsAmount { get; set; }
    }
    [Owned]
    public class ProductsOwn
    {
        public string None { get; set; }
        public string CertificatesofDeposit { get; set; }
        public string VariableAnnuity { get; set; }
        public string FixedorFIA { get; set; }
        public string FixedorFIAAmount { get; set; }
        public string LifeInsuranceAmount { get; set; }
        public string MoneyMarket_BrokerageAccount { get; set; }
        public string Other { get; set; }
        public string OtherDetails { get; set; }
        public string RealEstate { get; set; }
        public string ReverseMortgage { get; set; }
        public string Stocks_Bonds_MutualFunds { get; set; }
        public string VariableAnnuityAmount { get; set; }
        public string PortionOfAnnuitiesWithOutPenalty { get; set; }
    }

    [Owned]
    public class DistributionOption
    {
        public string Annuitization { get; set; }
        public string LeaveToBeneficiary { get; set; }
        public string LifetimeWithdrawalPayments { get; set; }
        public string Loans { get; set; }
        public string PartialSurrenders { get; set; }
        public string PenaltyFreeWithdrawals { get; set; }
        public string RMDs { get; set; }
        public string SingleLumpSum { get; set; }
        public string SystematicInterestWithdrawals { get; set; }

    }
    [Owned]
    public class FinancialObjective
    {
        public string TaxDeferral { get; set; }
        public string EstatePlanning { get; set; }
        public string GeneralSavings { get; set; }
        public string GrowthForFuture { get; set; }
        public string ImmediateIncome { get; set; }
        public string LifetimeIncome { get; set; }
        public string Other { get; set; }
        public string Qualification { get; set; }
        public string RetirementIncome { get; set; }
        public string SafetyOfPrincipal { get; set; }
        public string SaveForEmergencies { get; set; }
        public string OtherDetails { get; set; }
    }

    [Owned]
    public class DeathBenefitPaymentOptions
    {
        public string LifetimeWithdrawalPayments { get; set; }
    }

    [Owned]
    public class ExchangeOrReplacement
    {
        public string IncomeRider { get; set; }
        public string IncomeRiderDetails { get; set; }
        public string CompanyEnhancementsDetails { get; set; }
        public string AnotherAnnuityorLifeExchange { get; set; }
        public string AnotherAnnuityTimeFrame1 { get; set; }
        public string LivingBenefitRiderBaseValue { get; set; }
        public string LivingBenefitRiderBPS { get; set; }
        public string LivingBenefitRiderPayoutAmount { get; set; }
        public string LivingBenefitRider { get; set; }
        public string TaxConsequences { get; set; }
        public string TaxConsequencesDetail { get; set; }
        public string SameAgentRecommend { get; set; }
        public string Exchange_AnnuityOrLifeContract { get; set; }
        public string PenaltyFree { get; set; }
        public string PartialExchange { get; set; }
        public string FullExchange { get; set; }
        public string ReplacmentCompanyName1 { get; set; }
        public string ReplacmentCompanyName2 { get; set; }
        public string ReplacmentCompanyName3 { get; set; }
        public string ReplacmentProductName { get; set; }
        public string ReplacmentProductName2 { get; set; }
        public string ReplacmentProductName3 { get; set; }
        public string ExchangeAmount { get; set; }
        public string SurrenderChargeAmount { get; set; }
        public string MVA { get; set; }
        public string MinGuaranteedIntRate { get; set; }
        public string SurrenderChargePeriod { get; set; }
        public string PurchaseDate { get; set; }
        public string PurchaseDate2 { get; set; }
        public string PurchaseDate3 { get; set; }
        public string ExchangeAmount2 { get; set; }
        public string SurrenderChargeAmount2 { get; set; }
        public string MVA2 { get; set; }
        public string MinGuaranteedIntRate2 { get; set; }
        public string SurrenderChargePeriod2 { get; set; }
        public string ExchangeAmount3 { get; set; }
        public string SurrenderChargeAmount3 { get; set; }
        public string MVA3 { get; set; }
        public string MinGuaranteedIntRate3 { get; set; }
        public string SurrenderChargePeriod3 { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyNumber2 { get; set; }
        public string PolicyNumber3 { get; set; }
        public string AnnuityType { get; set; }
        public string AnnuityType3 { get; set; }
        public string AnnuityType2 { get; set; }
        public string AnotherAnnuityDate1 { get; set; }
        public string AnotherAnnuityTimeFrame2 { get; set; }
        public string AnotherAnnuityDate2 { get; set; }
        public string AnotherAnnuityTimeFrame3 { get; set; }
        public string AnotherAnnuityDate3 { get; set; }
    }

    [Owned]
    public class FinancialTimeHorizon
    {
        public string FirstDistributionLessThan1Year { get; set; }
        public string FirstDistribution1to3Years { get; set; }
        public string FirstDistribution4to6Years { get; set; }
        public string FirstDistribution7to9Years { get; set; }
        public string FirstDistribution10to12Years { get; set; }
        public string FirstDistribution13to15Years { get; set; }
        public string FirstDistribution16PlusYears { get; set; }
        public string Inforce16PlusYears { get; set; }
        public string Inforce13to15Years { get; set; }
        public string Inforce7to9Years { get; set; }
        public string Inforce4to6Years { get; set; }
        public string Inforce1to3Years { get; set; }
        public string Inforce10to12Years { get; set; }
    }

}
