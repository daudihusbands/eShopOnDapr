
using static AppProcessing.DTCC.Infrastructure.Services.Acord103.Converters.Acord.ContractEntities.ContractEntityHelper;
using static AppProcessing.DTCC.Infrastructure.Services.Acord103.Converters.PolicyHelper;
namespace AppProcessing.DTCC.Infrastructure.Services.Acord103.Converters
{
    public class SerializerBasedAcord103Converter : IAcord103Converter
    {
        private readonly Config config;

        public SerializerBasedAcord103Converter(Config config)
        {
            this.config = config;
        }

        public Acord103Result CreateAcord103FromDTCC(ApplicationRecord application, string policyNumber, DtccSubmitterInfo submitterInfo, string transRefGUID, ICollection<AcordSuitabilityQuestion> suitabilityQuestions = null, string outputFile = null)
        {
            SuitabilityHelper.SetSuitabilityQuestions(suitabilityQuestions);

            var txLifeRequestId = $"TXLifeRequest_{application.ApplicationControlNumber}";

            var txLife = new TXLife
            {
                Version = "2.39.00",
                TXLifeRequest = new TXLifeRequest(txLifeRequestId)
                {
                    TransType = new WithTC("103", "OLI_TRANS_NBSUB")
                }
            };

            var req = txLife.TXLifeRequest;

            // Create OLifE
            var oLife = new OLifE
            {
                SourceInfo = new SourceInfo("Source", "DTCC"),
                Holding = new Holding("Holding_1")
                {
                    HoldingTypeCode = new WithTC("2", "Policy"),
                    HoldingStatus = new WithTC("3", "Proposed - Pending - Not yet inforce"),
                    CarrierAdminSystem = "DTCC",
                    CurrencyTypeCode = new WithTC("840", "USD (United States Dollar)"),
                    DistributorClientAcctNum = application.ApplicationContracts.FirstOrDefault()?.DistributorClientAccountID,
                    AccountDesignation = new WithTC("3", "Owner"),
                }
            };
            req.OLifE = oLife;

            // Create Policy
            var policy = CreatePolicy(application, policyNumber, config);
            oLife.Holding.Policy = policy;


            // Add ContractEntities(Parties) and Relations
            AddContractEntitiesAndRelations(oLife, application, submitterInfo, suitabilityQuestions);



            // Done - Create xml document from mappings
            //var xmlDocument = TXLife.ToXml(txLife);
            var xmlDocument = txLife.XmlSerialize();

            // Save outputFile
            if (!string.IsNullOrEmpty(outputFile))
            {
                xmlDocument.Save(outputFile);
            }

            return new Acord103Result(xmlDocument, txLife);
        }

    }
}
