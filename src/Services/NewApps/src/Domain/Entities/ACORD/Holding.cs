namespace NewApps.Domain.Entities.ACORD
{
    public class Holding : BaseAuditableEntity
    {
        private Holding() { }
        public Holding(WithTC holdingTypeCode)
        {
            HoldingTypeCode = holdingTypeCode;
        }

        public Policy Policy { get; set; }
        public WithTC HoldingTypeCode { get; set; }
        public WithTC HoldingStatus { get; set; }
        public string CarrierAdminSystem { get; set; }
        public WithTC CurrencyTypeCode { get; set; }
        public WithTC AccountDesignation { get; set; }
        public string DistributorClientAcctNum { get; set; }
    }

    public class HoldingTypeCode : WithTC
    {
        public HoldingTypeCode(int TC, string Value)
        {
            this.TC = TC.ToString();
            this.Value = Value;
        }

        public static HoldingTypeCode Policy() => new HoldingTypeCode(TC: 2, Value: "Policy");
    }
}
