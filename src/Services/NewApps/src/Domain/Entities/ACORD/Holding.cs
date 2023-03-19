namespace NewApps.Domain.Entities.ACORD
{
    public class Holding : BaseAuditableEntity
    {
        private Holding() { }
        public Holding(HoldingTypeCode holdingTypeCode)
        {
            HoldingTypeCode = holdingTypeCode;
        }

        public Policy Policy { get; set; }
        public HoldingTypeCode HoldingTypeCode { get; set; }
        public int? HoldingTypeCodeId { get; set; }
        public HoldingStatusTC HoldingStatus { get; set; }
        public int? HoldingStatusId { get; set; }
        public string CarrierAdminSystem { get; set; }
        public CurrencyTypeCodeTC CurrencyTypeCode { get; set; }
        public int? CurrencyTypeCodeId { get; set; }
        public AccountDesignationTC AccountDesignation { get; set; }
        public int? AccountDesignationId { get; set; }
        public string DistributorClientAcctNum { get; set; }
    }
    public class HoldingStatusTC : WithTC { }
    public class CurrencyTypeCodeTC : WithTC { }
    public class AccountDesignationTC : WithTC { }
    public class HoldingTypeCode : WithTC
    {
        private HoldingTypeCode() { }
        public HoldingTypeCode(int TC, string Value)
        {
            this.TC = TC.ToString();
            this.Value = Value;
        }

        public static HoldingTypeCode Policy() => new HoldingTypeCode(TC: 2, Value: "Policy");
    }
}
