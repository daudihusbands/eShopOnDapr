using System.Xml;
using System.Xml.Serialization;

namespace NewApps.Domain.Entities.ACORD;

public class FinancialActivity : WithID
{
    public FinancialActivity() { }

    public FinancialActivity(string id) : base(id)
    {
    }

    private decimal commissionAmt;
    private decimal finActivityGrossAmt;
    private decimal finActivityNetAmt;

    public string CommissionAmt { get => commissionAmt.ToString(Constants.CurrencyFormat); set => commissionAmt = Convert.ToDecimal(value); }
    public string FinActivityGrossAmt { get => finActivityGrossAmt.ToString(Constants.CurrencyFormat); set => finActivityGrossAmt = Convert.ToDecimal(value); }
    public string FinActivityNetAmt { get => finActivityNetAmt.ToString(Constants.CurrencyFormat); set => finActivityNetAmt = Convert.ToDecimal(value); }

    public WithTC FinActivityType { get; set; }
    public string ReferenceNo { get; set; }

    [XmlElement("Payment")]
    public List<Payment> Payments { get; set; } = new List<Payment>();
}

public class Payment : WithID
{
    public Payment() { }
    private decimal paymentAmt;

    public string PaymentAmt { get => paymentAmt > 0 ? paymentAmt.ToString(Constants.CurrencyFormat) : null; set => paymentAmt = Convert.ToDecimal(value); }
    public WithTC PaymentForm { get; set; }
    public WithTC SourceOfFundsTC { get; set; }
    public string SourceOfFundsDetails { get; set; }

}
