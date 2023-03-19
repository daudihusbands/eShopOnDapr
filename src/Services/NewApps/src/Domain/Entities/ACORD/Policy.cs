using System.Xml;
using System.Xml.Serialization;

namespace NewApps.Domain.Entities.ACORD
{
    public class Policy : AcordModel
    {
        [XmlAttribute]
        public string CarrierPartyID { get; set; }
        public string CusipNum { get; set; }

        public List<SERVICE_PROGRAM> SERVICE_PROGRAMS { get; set; }

        public string TRANSACTION_IDS { get; set; }
        public string STATE_CODE { get; set; }


        [XmlArray("WORKFLOW_STEPS")]
        [XmlArrayItem("WORKFLOW_STEP")]
        public List<WorkflowStep> WorkflowSteps { get; set; }
        public WithTC LineOfBusiness { get; set; }

        //public string InitDepositAmt => {get

        private decimal initDepositAmt;
        private decimal annualPaymentAmt;
        private decimal paymentAmt;

        public string InitDepositAmt
        {
            get { return initDepositAmt.ToString(Constants.CurrencyFormat); }
            set { initDepositAmt = Convert.ToDecimal(value); }
        }

        public string AnnualPaymentAmt { get => annualPaymentAmt.ToString(Constants.CurrencyFormat); set => annualPaymentAmt = Convert.ToDecimal(value); }
        public string PaymentAmt { get => paymentAmt.ToString(Constants.CurrencyFormat); set => paymentAmt = Convert.ToDecimal(value); }


        [XmlElement("FinancialActivity")]
        public List<FinancialActivity> FinancialActivities { get; set; } = new List<FinancialActivity>();
        public string ProductCode { get; set; }
        public Annuity Annuity { get; set; }
        public string PolNumber { get; set; }
        public string PlanName { get; set; }
        public string ShortName { get; set; }

        public WithTC Jurisdiction { get; set; }
        public ApplicationInfo ApplicationInfo { get; set; }



    }
}
