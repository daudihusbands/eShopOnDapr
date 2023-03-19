using static NewApps.Domain.Entities.ACORD.Acord;

namespace NewApps.Domain.Entities.ACORD
{
    public class Annuity : AcordModel
    {

        public static string GetAcord103IRSQualCodeTranslation(string dtccIRSQualificationCode)
        {
            switch (dtccIRSQualificationCode)
            {
                case "1030":
                    {
                        return "OLI_QUALPLN_401K";
                    }
                case "1040":
                    {
                        return "OLI_QUALPLN_401K";
                    }
                case "1075":
                    {
                        return "OLI_QUALPLN_501";
                    }
                case "1080":
                    {
                        return "OLI_QUALPLN_457";
                    }
                case "1090":
                    {
                        return "OLI_QUALPLN_KEO";
                    }
                case "1314":
                    {
                        return "OLI_QUALPLN_IRA";
                    }
                case "1315":
                    {
                        return "OLI_QUALPLN_NONE";
                    }
                case "1316":
                    {
                        return "OLI_QUALPLN_ROTHIRA";
                    }
                case "2000":
                    {
                        return "OLI_QUALPLN_IRA";
                    }
                case "2005":
                    {
                        return "OLI_QUALPLN_IRA";
                    }
                case "2010":
                    {
                        return "OLI_QUALPLN_NONE";
                    }
                case "2040":
                    {
                        return "OLI_QUALPLN_PENSION";
                    }
                case "2050":
                    {
                        return "OLI_QUALPLN_SARSEP";
                    }
                case "2060":
                    {
                        return "OLI_QUALPLN_SEP";
                    }
                case "2070":
                    {
                        return "OLI_QUALPLN_IRASPOUSAL";
                    }
                case "2075":
                    {
                        return "OLI_QUALPLN_IRA";
                    }
                case "2090":
                    {
                        return "OLI_QUALPLN_CASHDEFCONT";
                    }
                case "3000":
                    {
                        return "OLI_QUALPLN_CASHDEFBEN";
                    }
                case "3010":
                    {
                        return "OLI_QUALPLN_CASHDEFBEN";
                    }
                case "3045":
                    {
                        return "OLI_QUALPLN_403B";
                    }
                case "3050":
                    {
                        return "OLI_QUALPLN_401G";
                    }
                case "3055":
                    {
                        return "OLI_QUALPLN_412I";
                    }
                case "3210":
                    {
                        return "OLI_QUALPLN_IRA";
                    }
                case "3215":
                    {
                        return "OLI_QUALPLN_ROTHIRA";
                    }
                case "3216":
                    {
                        return "OLI_QUALPLN_ROTH401K";
                    }
                case "3217":
                    {
                        return "OLI_QUALPLN_ROTH403B";
                    }
                case "3220":
                    {
                        return "OLI_QUALPLN_EDIRA";
                    }
                case "3230":
                    {
                        return "OLI_QUALPLN_PROFITSHARING";
                    }
                case "3235":
                    {
                        return "OLI_QUALPLN_MONEYPURCH";
                    }
                case "3300":
                    {
                        return "OLI_QUALPLN_419";
                    }
                case "3400":
                    {
                        return "OLI_QUALPLN_STRUCSTL";
                    }
                case "4000":
                    {
                        return "OLI_QUALPLN_FOREIGN";
                    }
                case "56":
                    {
                        return "OLI_QUALPLN_403B";
                    }
                case "80":
                    {
                        return "OLI_QUALPLN_ROTH457";
                    }
                default:
                    {
                        return "OLI_QUALPLN_NONE";
                    }
            }
        }
        public WithTC QualPlanType { get; set; }
        public WithTC QualPlanSubType { get; set; }
        public Rider Rider { get; set; }
        public class AnnuityRepository : Repository<DTCCToAcordMapping>
        {
            public override ICollection<DTCCToAcordMapping> List => new List<DTCCToAcordMapping> {
                new DTCCToAcordMapping { DTCCCode="1030", AcordValue="OLI_QUALPLN_401K", TC=2, Description="401(k)" },
                new DTCCToAcordMapping { DTCCCode="1040", AcordValue="OLI_QUALPLN_401K", TC=2, Description="401(k)"  },
                new DTCCToAcordMapping { DTCCCode="1075", AcordValue="OLI_QUALPLN_501", TC=48, Description= "501(c)"},
                new DTCCToAcordMapping { DTCCCode="1080", AcordValue="OLI_QUALPLN_457", TC=4, Description= "457 Deferred Compensation Plan" },
                new DTCCToAcordMapping { DTCCCode="1090", AcordValue="OLI_QUALPLN_KEO", TC=50, Description= "Keogh / HR10" },
                new DTCCToAcordMapping { DTCCCode="1314", AcordValue="OLI_QUALPLN_IRA" , TC=5, Description= "IRA - Traditional (408(b))"},
                new DTCCToAcordMapping { DTCCCode="1315", AcordValue="OLI_QUALPLN_NONE" , TC=1, Description="Non-Qualified" },
                new DTCCToAcordMapping { DTCCCode="1316", AcordValue="OLI_QUALPLN_ROTHIRA", TC=6, Description="IRA - Roth"  },
                new DTCCToAcordMapping { DTCCCode="2040", AcordValue="OLI_QUALPLN_PENSION", TC=106, Description=  "Pension Fund" },
                new DTCCToAcordMapping { DTCCCode="2000", AcordValue="OLI_QUALPLN_IRA" , TC=5, Description="IRA - Traditional (408(b))" },
                new DTCCToAcordMapping { DTCCCode="2005", AcordValue="OLI_QUALPLN_IRA", TC=5, Description="IRA - Traditional (408(b))"  },
                new DTCCToAcordMapping { DTCCCode="2010", AcordValue="OLI_QUALPLN_NONE", TC=1, Description="Non-Qualified" },
                new DTCCToAcordMapping { DTCCCode="2045", AcordValue="OLI_QUALPLN_SARSEP", TC=40, Description= "408(k) - SARSEP" },
                new DTCCToAcordMapping { DTCCCode="2060", AcordValue="OLI_QUALPLN_SEP",TC=8, Description= "408(k) - SEP" },
                new DTCCToAcordMapping { DTCCCode="2070", AcordValue="OLI_QUALPLN_IRASPOUSAL",TC=33, Description= "IRA - Spousal"  },
                new DTCCToAcordMapping { DTCCCode="2075", AcordValue="OLI_QUALPLN_IRA", TC=5, Description= "IRA - Traditional (408(b))" },
                new DTCCToAcordMapping { DTCCCode="2090", AcordValue="OLI_QUALPLN_CASHDEFCONT",TC=34, Description= "Defined Contribution" },

                new DTCCToAcordMapping { DTCCCode="3000", AcordValue="OLI_QUALPLN_CASHDEFBEN",TC=35, Description=  "Defined Benefit" },
                new DTCCToAcordMapping { DTCCCode="3045", AcordValue="OLI_QUALPLN_403B",TC=3, Description= "403(b) - Tax Sheltered Annuity" },
                new DTCCToAcordMapping { DTCCCode="3050", AcordValue="OLI_QUALPLN_401G",TC=43, Description= "401(g) - Non-transferable Qualified Annuity" },
                new DTCCToAcordMapping { DTCCCode="3055", AcordValue="OLI_QUALPLN_412I",TC=69, Description= "412(i)" },
                new DTCCToAcordMapping { DTCCCode="3210", AcordValue="OLI_QUALPLN_IRA", TC=5, Description= "IRA - Traditional (408(b))" },
                new DTCCToAcordMapping { DTCCCode="3215", AcordValue="OLI_QUALPLN_ROTHIRA",TC=6, Description= "IRA - Roth" },
                new DTCCToAcordMapping { DTCCCode="3216", AcordValue="OLI_QUALPLN_ROTH401K",TC=77, Description= "Roth 401 (k)" },
                new DTCCToAcordMapping { DTCCCode="3217", AcordValue="OLI_QUALPLN_ROTH403B",TC=78, Description= "Roth 403 (b)" },
                new DTCCToAcordMapping { DTCCCode="3220", AcordValue="OLI_QUALPLN_EDIRA",TC=7, Description= "IRA - Education" },
                new DTCCToAcordMapping { DTCCCode="3230", AcordValue="OLI_QUALPLN_PROFITSHARING",TC=38, Description= "Profit Sharing Plan" },
                new DTCCToAcordMapping { DTCCCode="3235", AcordValue="OLI_QUALPLN_MONEYPURCH",TC=39, Description= "Money Purchase" },
                new DTCCToAcordMapping { DTCCCode="3300", AcordValue="OLI_QUALPLN_419",TC=70, Description="419 - Welfare Benefit Plan"  },
                new DTCCToAcordMapping { DTCCCode="3400", AcordValue="OLI_QUALPLN_STRUCSTL",TC=61, Description= "04(a) - Structured Settlement, Subsection Unspecified" },

                new DTCCToAcordMapping { DTCCCode="4000", AcordValue="OLI_QUALPLN_FOREIGN",TC=37, Description= "Foreign National" },
                new DTCCToAcordMapping { DTCCCode="56", AcordValue="OLI_QUALPLN_403B",TC=3, Description=  "403(b) - Tax Sheltered Annuity"},
                new DTCCToAcordMapping { DTCCCode="80", AcordValue="OLI_QUALPLN_ROTH457",TC=80, Description= "ROTH 457" },
                new DTCCToAcordMapping { DTCCCode="", AcordValue="OLI_QUALPLN_NONE", IsDefault=true,TC=1, Description="Non-Qualified" },





            };
        }

        public class CDSCRepository : Repository<DTCCToAcordMapping>
        {
            public override ICollection<DTCCToAcordMapping> List => new List<DTCCToAcordMapping> {
                new DTCCToAcordMapping { DTCCCode="SC02O05", AcordValue="5" },
                new DTCCToAcordMapping { DTCCCode="SC02O05A", AcordValue="5" },
                new DTCCToAcordMapping { DTCCCode="SC02O07", AcordValue="7" },
                new DTCCToAcordMapping { DTCCCode="SC02O07A", AcordValue="7" },
                new DTCCToAcordMapping { DTCCCode="SC02O05", AcordValue="5" },
            };
        }
    }
    [Owned]
    public class Rider
    {
        public Rider()
        {

        }
        public string RiderCode { get; set; }

        public Rider(string riderCode)
        {
            RiderCode = riderCode;
        }
    }
}
