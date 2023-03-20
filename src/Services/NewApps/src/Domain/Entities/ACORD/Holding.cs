namespace NewApps.Domain.Entities.ACORD
{
    public class Holding : BaseAuditableEntity
    {
        private Holding() { }
        public Holding(
            HoldingTypeTC holdingTypeCode,
            string? distributorClientAcctNum,
            string? carrierAdminSystem = "DTCC")
        {
            HoldingTypeCode = holdingTypeCode ?? throw new ArgumentNullException(nameof(holdingTypeCode), "Cannot instantiate Holding with empty HoldingTypeCode");
            CarrierAdminSystem = carrierAdminSystem;
            DistributorClientAcctNum = distributorClientAcctNum;
        }

        public Policy Policy { get; private set; }
        public int? PolicyId { get; private set; }
        public HoldingTypeTC HoldingTypeCode { get; private set; }
        public int? HoldingTypeCodeId { get; private set; }
        public HoldingStatusTC HoldingStatus { get; private set; }
        public int? HoldingStatusId { get; private set; }
        public string CarrierAdminSystem { get; private set; }
        public CurrencyTypeCodeTC CurrencyTypeCode { get; private set; }
        public int? CurrencyTypeCodeId { get; private set; }
        public AccountDesignationTC AccountDesignation { get; private set; }
        public int? AccountDesignationId { get; private set; }
        public string? DistributorClientAcctNum { get; private set; }
    }
    public class HoldingStatusTC : WithTC { }
    public class CurrencyTypeCodeTC : WithTC { }
    public class AccountDesignationTC : WithTC { }
    public class HoldingTypeTC : WithTC
    {
        private HoldingTypeTC() { }
        public HoldingTypeTC(int TC, string Value)
        {
            this.TC = TC.ToString();
            this.Value = Value;
        }

        public static HoldingTypeTC Policy() => new HoldingTypeTC(TC: 2, Value: "Policy");
    }
}
