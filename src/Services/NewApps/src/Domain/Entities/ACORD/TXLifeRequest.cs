using System.Xml;
using System.Xml.Serialization;
using CommonExtensions;

namespace NewApps.Domain.Entities.ACORD
{
    public class TXLifeRequest : WithID
    {
        private TXLifeRequest()
        {

        }
        public TXLifeRequest(string id) : base(id)
        {
        }

        [XmlAttribute]
        public string PrimaryObjectID { get; set; }

        public string TransRefGUID { get; set; } = Guid.NewGuid().ToString();
        public WithTC TransType { get; set; }
        public WithTC TransSubType { get; set; }
        public string TransExeDate { get; set; } = DateTimeOffset.Now.ToString(Constants.TransDateFormat);
        public string TransExeTime { get; set; } = DateTimeOffset.Now.ToString(Constants.TransTimeFormat);
        public WithTC PrimaryObjectType { get; set; }
        public WithTC TestIndicator { get; set; }

        public OLifE OLifE { get; set; }

    }

    public class TXLifeResponse
    {
        public TXLifeResponse()
        {

        }

        public TXLifeResponse(bool testMode, string transRefGuid, string resultCode, string resultDesc)
        {
            TestIndicator = WithTC.Create(testMode.ToBit(), testMode.ToTrueFalse());
            TransRefGUID = transRefGuid;
            TransType = WithTC.Create(510, "FormInstanceUpdate");
            TransSubType = WithTC.Create(1022500300, "Attachment");

            TransResult = new TransResult { ResultCode = WithTC.Create(resultCode, resultDesc) };

        }
        public string TransRefGUID { get; set; } = Guid.NewGuid().ToString();
        public WithTC TransType { get; set; }
        public WithTC TransSubType { get; set; }
        public string TransExeDate { get; set; } = DateTimeOffset.Now.ToString(Constants.TransDateFormat);
        public string TransExeTime { get; set; } = DateTimeOffset.Now.ToString(Constants.TransTimeFormat);
        public WithTC TestIndicator { get; set; }
        public TransResult TransResult { get; set; }
    }

    public class TransResult
    {
        public WithTC ResultCode { get; set; }
    }
}
