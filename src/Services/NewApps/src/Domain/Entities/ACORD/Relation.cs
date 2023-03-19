using System.Xml.Serialization;

namespace NewApps.Domain.Entities.ACORD
{
    public class Relation : WithID
    {
        public Relation()
        {

        }

        public Relation(string id, string originatingObjectID, WithTC originatingObjectType, string relatedObjectID, WithTC relationRoleCode, WithTC relatedObjectType) : base(id)
        {
            OriginatingObjectID = originatingObjectID;
            OriginatingObjectType = originatingObjectType;
            RelatedObjectID = relatedObjectID;
            RelationRoleCode = relationRoleCode;
            RelatedObjectType = relatedObjectType;
        }

        [XmlAttribute]
        public string OriginatingObjectID { get; set; }
        public WithTC OriginatingObjectType { get; set; }


        [XmlAttribute]
        public string RelatedObjectID { get; set; }


        public WithTC RelationRoleCode { get; set; }
        public WithTC RelatedObjectType { get; set; }


        public WithTC IrrevokableInd { get; set; }
        public string InterestPercent { get; set; }
        public string RelatedRefID { get; set; }

    }

    public class RelationRoleCode
    {
        public const string ContingentBeneficiary = "OLI_REL_CONTGNTBENE";
        public const string Aunt = "OLI_REL_AUNT";
    }

}
