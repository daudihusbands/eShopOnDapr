using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewApps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WithTC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithTC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Annuity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualPlanTypeId = table.Column<int>(type: "int", nullable: false),
                    QualPlanSubTypeId = table.Column<int>(type: "int", nullable: false),
                    RiderRiderCode = table.Column<string>(name: "Rider_RiderCode", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annuity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annuity_WithTC_QualPlanSubTypeId",
                        column: x => x.QualPlanSubTypeId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annuity_WithTC_QualPlanTypeId",
                        column: x => x.QualPlanTypeId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierPartyID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CusipNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANSACTIONIDS = table.Column<string>(name: "TRANSACTION_IDS", type: "nvarchar(max)", nullable: false),
                    STATECODE = table.Column<string>(name: "STATE_CODE", type: "nvarchar(max)", nullable: false),
                    LineOfBusinessId = table.Column<int>(type: "int", nullable: false),
                    InitDepositAmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualPaymentAmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnuityId = table.Column<int>(type: "int", nullable: false),
                    PolNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JurisdictionId = table.Column<int>(type: "int", nullable: false),
                    ApplicationInfoTrackingID = table.Column<string>(name: "ApplicationInfo_TrackingID", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_Annuity_AnnuityId",
                        column: x => x.AnnuityId,
                        principalTable: "Annuity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policy_WithTC_JurisdictionId",
                        column: x => x.JurisdictionId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policy_WithTC_LineOfBusinessId",
                        column: x => x.LineOfBusinessId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialActivity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommissionAmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinActivityGrossAmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinActivityNetAmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialActivity_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialActivity_WithTC_FinActivityTypeId",
                        column: x => x.FinActivityTypeId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holdings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    HoldingTypeCodeId = table.Column<int>(type: "int", nullable: false),
                    HoldingStatusId = table.Column<int>(type: "int", nullable: false),
                    CarrierAdminSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyTypeCodeId = table.Column<int>(type: "int", nullable: false),
                    AccountDesignationId = table.Column<int>(type: "int", nullable: false),
                    DistributorClientAcctNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holdings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holdings_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Holdings_WithTC_AccountDesignationId",
                        column: x => x.AccountDesignationId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Holdings_WithTC_CurrencyTypeCodeId",
                        column: x => x.CurrencyTypeCodeId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Holdings_WithTC_HoldingStatusId",
                        column: x => x.HoldingStatusId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Holdings_WithTC_HoldingTypeCodeId",
                        column: x => x.HoldingTypeCodeId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_PROGRAM",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleFrequency = table.Column<string>(name: "Schedule_Frequency", type: "nvarchar(max)", nullable: false),
                    ScheduleStartDate = table.Column<DateTime>(name: "Schedule_StartDate", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_PROGRAM", x => new { x.PolicyId, x.Id });
                    table.ForeignKey(
                        name: "FK_SERVICE_PROGRAM_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignatureInfo",
                columns: table => new
                {
                    ApplicationInfoPolicyId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignaturePartyID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignatureDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignatureOKId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureInfo", x => new { x.ApplicationInfoPolicyId, x.Id });
                    table.ForeignKey(
                        name: "FK_SignatureInfo_Policy_ApplicationInfoPolicyId",
                        column: x => x.ApplicationInfoPolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SignatureInfo_WithTC_SignatureOKId",
                        column: x => x.SignatureOKId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStep",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ASOFDATETIME = table.Column<DateTime>(name: "AS_OF_DATETIME", type: "datetime2", nullable: false),
                    ACTIONTAKEN = table.Column<string>(name: "ACTION_TAKEN", type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStep", x => new { x.PolicyId, x.Id });
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentAmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentFormId = table.Column<int>(type: "int", nullable: false),
                    SourceOfFundsTCId = table.Column<int>(type: "int", nullable: false),
                    SourceOfFundsDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialActivityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_FinancialActivity_FinancialActivityId",
                        column: x => x.FinancialActivityId,
                        principalTable: "FinancialActivity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_WithTC_PaymentFormId",
                        column: x => x.PaymentFormId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_WithTC_SourceOfFundsTCId",
                        column: x => x.SourceOfFundsTCId,
                        principalTable: "WithTC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionLink",
                columns: table => new
                {
                    SERVICEPROGRAMPolicyId = table.Column<int>(name: "SERVICE_PROGRAMPolicyId", type: "int", nullable: false),
                    SERVICEPROGRAMId = table.Column<int>(name: "SERVICE_PROGRAMId", type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionLink", x => new { x.SERVICEPROGRAMPolicyId, x.SERVICEPROGRAMId, x.Id });
                    table.ForeignKey(
                        name: "FK_OptionLink_SERVICE_PROGRAM_SERVICE_PROGRAMPolicyId_SERVICE_PROGRAMId",
                        columns: x => new { x.SERVICEPROGRAMPolicyId, x.SERVICEPROGRAMId },
                        principalTable: "SERVICE_PROGRAM",
                        principalColumns: new[] { "PolicyId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_PROGRAM_Extensions",
                columns: table => new
                {
                    SERVICEPROGRAMPolicyId = table.Column<int>(name: "SERVICE_PROGRAMPolicyId", type: "int", nullable: false),
                    SERVICEPROGRAMId = table.Column<int>(name: "SERVICE_PROGRAMId", type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_PROGRAM_Extensions", x => new { x.SERVICEPROGRAMPolicyId, x.SERVICEPROGRAMId, x.Id });
                    table.ForeignKey(
                        name: "FK_SERVICE_PROGRAM_Extensions_SERVICE_PROGRAM_SERVICE_PROGRAMPolicyId_SERVICE_PROGRAMId",
                        columns: x => new { x.SERVICEPROGRAMPolicyId, x.SERVICEPROGRAMId },
                        principalTable: "SERVICE_PROGRAM",
                        principalColumns: new[] { "PolicyId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_PROGRAM_IDs",
                columns: table => new
                {
                    SERVICEPROGRAMPolicyId = table.Column<int>(name: "SERVICE_PROGRAMPolicyId", type: "int", nullable: false),
                    SERVICEPROGRAMId = table.Column<int>(name: "SERVICE_PROGRAMId", type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTYID = table.Column<string>(name: "PARTY_ID", type: "nvarchar(max)", nullable: false),
                    PARTYNAME = table.Column<string>(name: "PARTY_NAME", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_PROGRAM_IDs", x => new { x.SERVICEPROGRAMPolicyId, x.SERVICEPROGRAMId, x.Id });
                    table.ForeignKey(
                        name: "FK_SERVICE_PROGRAM_IDs_SERVICE_PROGRAM_SERVICE_PROGRAMPolicyId_SERVICE_PROGRAMId",
                        columns: x => new { x.SERVICEPROGRAMPolicyId, x.SERVICEPROGRAMId },
                        principalTable: "SERVICE_PROGRAM",
                        principalColumns: new[] { "PolicyId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStep_Extensions",
                columns: table => new
                {
                    WorkflowStepPolicyId = table.Column<int>(type: "int", nullable: false),
                    WorkflowStepId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStep_Extensions", x => new { x.WorkflowStepPolicyId, x.WorkflowStepId, x.Id });
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Extensions_WorkflowStep_WorkflowStepPolicyId_WorkflowStepId",
                        columns: x => new { x.WorkflowStepPolicyId, x.WorkflowStepId },
                        principalTable: "WorkflowStep",
                        principalColumns: new[] { "PolicyId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OLifEExtension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtensionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionBBenefitPct = table.Column<double>(type: "float", nullable: true),
                    OptionHBenefitPct = table.Column<double>(type: "float", nullable: true),
                    OptionIBenefitPct = table.Column<double>(type: "float", nullable: true),
                    OptionLBenefitPct = table.Column<double>(type: "float", nullable: true),
                    OptionJBenefitPct = table.Column<double>(type: "float", nullable: true),
                    OptionEBenefitPct = table.Column<double>(type: "float", nullable: true),
                    OptionFBenefitPct = table.Column<double>(type: "float", nullable: true),
                    CDSCPeriodElection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnuityWithdrawalChargePeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributorTransactionIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PremiumControlNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalName = table.Column<string>(name: "Suitability_Additional_Name", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalResideNursingHomeFacility = table.Column<string>(name: "Suitability_Additional_ResideNursingHomeFacility", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalConsultedHealthCareAdvisor = table.Column<string>(name: "Suitability_Additional_ConsultedHealthCareAdvisor", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalSurrenderPolicyEarly = table.Column<string>(name: "Suitability_Additional_SurrenderPolicyEarly", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalInterestCreditsFluctuate = table.Column<string>(name: "Suitability_Additional_InterestCreditsFluctuate", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalAcceptNonGuaranteeElements = table.Column<string>(name: "Suitability_Additional_AcceptNonGuaranteeElements", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalAgentSoldPolicies = table.Column<string>(name: "Suitability_Additional_AgentSoldPolicies", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalSameAddressAgent = table.Column<string>(name: "Suitability_Additional_SameAddressAgent", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalSameAddressAgentDetails = table.Column<string>(name: "Suitability_Additional_SameAddressAgentDetails", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalAgentSoldPoliciesNumber = table.Column<string>(name: "Suitability_Additional_AgentSoldPoliciesNumber", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalAgentSoldPoliciesNumberInforce = table.Column<string>(name: "Suitability_Additional_AgentSoldPoliciesNumberInforce", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalConsultedHealthCareAdvisorDetails = table.Column<string>(name: "Suitability_Additional_ConsultedHealthCareAdvisorDetails", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalResideNursingHomeFacilityDetails = table.Column<string>(name: "Suitability_Additional_ResideNursingHomeFacilityDetails", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalAnnuityPurchaseOtherInfoDetails = table.Column<string>(name: "Suitability_Additional_AnnuityPurchaseOtherInfoDetails", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalSameAddressApplicantDetails = table.Column<string>(name: "Suitability_Additional_SameAddressApplicantDetails", type: "nvarchar(max)", nullable: false),
                    SuitabilityAdditionalSameAddressApplicant = table.Column<string>(name: "Suitability_Additional_SameAddressApplicant", type: "nvarchar(max)", nullable: false),
                    SuitabilityAgentAgentRecommendSuitableAnnuityDetails = table.Column<string>(name: "Suitability_Agent_AgentRecommendSuitableAnnuityDetails", type: "nvarchar(max)", nullable: false),
                    SuitabilityOwnAnnuities = table.Column<string>(name: "Suitability_OwnAnnuities", type: "nvarchar(max)", nullable: false),
                    SuitabilityOwnLifeInsurance = table.Column<string>(name: "Suitability_OwnLifeInsurance", type: "nvarchar(max)", nullable: false),
                    SuitabilitySOPIncome = table.Column<string>(name: "Suitability_SOPIncome", type: "nvarchar(max)", nullable: false),
                    SuitabilitySOPGrowth = table.Column<string>(name: "Suitability_SOPGrowth", type: "nvarchar(max)", nullable: false),
                    SuitabilityPassAssetsBeneficiary = table.Column<string>(name: "Suitability_PassAssetsBeneficiary", type: "nvarchar(max)", nullable: false),
                    SuitabilityProposedAnnuityReplaceProduct = table.Column<string>(name: "Suitability_ProposedAnnuityReplaceProduct", type: "nvarchar(max)", nullable: false),
                    SuitabilityProposedAnnuityPayPenalty = table.Column<string>(name: "Suitability_ProposedAnnuityPayPenalty", type: "nvarchar(max)", nullable: false),
                    SuitabilityProvideInfoRefuse = table.Column<string>(name: "Suitability_ProvideInfoRefuse", type: "nvarchar(max)", nullable: false),
                    SuitabilityProvideInfoLimited = table.Column<string>(name: "Suitability_ProvideInfoLimited", type: "nvarchar(max)", nullable: false),
                    SuitabilityProvideInfoNotBased = table.Column<string>(name: "Suitability_ProvideInfoNotBased", type: "nvarchar(max)", nullable: false),
                    SuitabilityProvideInfoBased = table.Column<string>(name: "Suitability_ProvideInfoBased", type: "nvarchar(max)", nullable: false),
                    DistributionOptionAnnuitization = table.Column<string>(name: "DistributionOption_Annuitization", type: "nvarchar(max)", nullable: false),
                    DistributionOptionLeaveToBeneficiary = table.Column<string>(name: "DistributionOption_LeaveToBeneficiary", type: "nvarchar(max)", nullable: false),
                    DistributionOptionLifetimeWithdrawalPayments = table.Column<string>(name: "DistributionOption_LifetimeWithdrawalPayments", type: "nvarchar(max)", nullable: false),
                    DistributionOptionLoans = table.Column<string>(name: "DistributionOption_Loans", type: "nvarchar(max)", nullable: false),
                    DistributionOptionPartialSurrenders = table.Column<string>(name: "DistributionOption_PartialSurrenders", type: "nvarchar(max)", nullable: false),
                    DistributionOptionPenaltyFreeWithdrawals = table.Column<string>(name: "DistributionOption_PenaltyFreeWithdrawals", type: "nvarchar(max)", nullable: false),
                    DistributionOptionRMDs = table.Column<string>(name: "DistributionOption_RMDs", type: "nvarchar(max)", nullable: false),
                    DistributionOptionSingleLumpSum = table.Column<string>(name: "DistributionOption_SingleLumpSum", type: "nvarchar(max)", nullable: false),
                    DistributionOptionSystematicInterestWithdrawals = table.Column<string>(name: "DistributionOption_SystematicInterestWithdrawals", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonFirstDistributionLessThan1Year = table.Column<string>(name: "FinancialTimeHorizon_FirstDistributionLessThan1Year", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonFirstDistribution1to3Years = table.Column<string>(name: "FinancialTimeHorizon_FirstDistribution1to3Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonFirstDistribution4to6Years = table.Column<string>(name: "FinancialTimeHorizon_FirstDistribution4to6Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonFirstDistribution7to9Years = table.Column<string>(name: "FinancialTimeHorizon_FirstDistribution7to9Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonFirstDistribution10to12Years = table.Column<string>(name: "FinancialTimeHorizon_FirstDistribution10to12Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonFirstDistribution13to15Years = table.Column<string>(name: "FinancialTimeHorizon_FirstDistribution13to15Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonFirstDistribution16PlusYears = table.Column<string>(name: "FinancialTimeHorizon_FirstDistribution16PlusYears", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonInforce16PlusYears = table.Column<string>(name: "FinancialTimeHorizon_Inforce16PlusYears", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonInforce13to15Years = table.Column<string>(name: "FinancialTimeHorizon_Inforce13to15Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonInforce7to9Years = table.Column<string>(name: "FinancialTimeHorizon_Inforce7to9Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonInforce4to6Years = table.Column<string>(name: "FinancialTimeHorizon_Inforce4to6Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonInforce1to3Years = table.Column<string>(name: "FinancialTimeHorizon_Inforce1to3Years", type: "nvarchar(max)", nullable: false),
                    FinancialTimeHorizonInforce10to12Years = table.Column<string>(name: "FinancialTimeHorizon_Inforce10to12Years", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsCD = table.Column<string>(name: "SourceOfFunds_CD", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsCheckingAccount = table.Column<string>(name: "SourceOfFunds_CheckingAccount", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsDeathBenefit = table.Column<string>(name: "SourceOfFunds_DeathBenefit", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsDeathBenefitInfo = table.Column<string>(name: "SourceOfFunds_DeathBenefitInfo", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsFixedIndexedAnnuity = table.Column<string>(name: "SourceOfFunds_FixedIndexedAnnuity", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsLifeInsurance = table.Column<string>(name: "SourceOfFunds_LifeInsurance", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsMoneyMarket = table.Column<string>(name: "SourceOfFunds_MoneyMarket", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsMutualFunds = table.Column<string>(name: "SourceOfFunds_MutualFunds", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsOther = table.Column<string>(name: "SourceOfFunds_Other", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsOtherInfo = table.Column<string>(name: "SourceOfFunds_OtherInfo", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsReverseMortgage = table.Column<string>(name: "SourceOfFunds_ReverseMortgage", type: "nvarchar(max)", nullable: false),
                    SourceOfFundsVariableAnnuity = table.Column<string>(name: "SourceOfFunds_VariableAnnuity", type: "nvarchar(max)", nullable: false),
                    FinancialInfoAnnualExpenses = table.Column<string>(name: "FinancialInfo_AnnualExpenses", type: "nvarchar(max)", nullable: false),
                    FinancialInfoSourceOfIncomeWages = table.Column<string>(name: "FinancialInfo_SourceOfIncome_Wages", type: "nvarchar(max)", nullable: false),
                    FinancialInfoSourceOfIncomeInvestments = table.Column<string>(name: "FinancialInfo_SourceOfIncome_Investments", type: "nvarchar(max)", nullable: false),
                    FinancialInfoSourceOfIncomeOther = table.Column<string>(name: "FinancialInfo_SourceOfIncome_Other", type: "nvarchar(max)", nullable: false),
                    FinancialInfoSourceOfIncomeOtherDetails = table.Column<string>(name: "FinancialInfo_SourceOfIncome_OtherDetails", type: "nvarchar(max)", nullable: false),
                    FinancialInfoSourceOfIncomePension = table.Column<string>(name: "FinancialInfo_SourceOfIncome_Pension", type: "nvarchar(max)", nullable: false),
                    FinancialInfoSourceOfIncomeSocialSecurity = table.Column<string>(name: "FinancialInfo_SourceOfIncome_SocialSecurity", type: "nvarchar(max)", nullable: false),
                    FinancialInfoLiquidityNeedsLiquidNetWorth = table.Column<string>(name: "FinancialInfo_LiquidityNeeds_LiquidNetWorth", type: "nvarchar(max)", nullable: false),
                    FinancialInfoLiquidityNeedsExpectedChanges = table.Column<string>(name: "FinancialInfo_LiquidityNeeds_ExpectedChanges", type: "nvarchar(max)", nullable: false),
                    FinancialInfoLiquidityNeedsSufficient = table.Column<string>(name: "FinancialInfo_LiquidityNeeds_Sufficient", type: "nvarchar(max)", nullable: false),
                    FinancialInfoLiquidityNeedsExpectedChangesDetails = table.Column<string>(name: "FinancialInfo_LiquidityNeeds_ExpectedChangesDetails", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceRiskTolerance = table.Column<string>(name: "FinancialExperience_RiskTolerance", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnNone = table.Column<string>(name: "FinancialExperience_ProductsOwn_None", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnCertificatesofDeposit = table.Column<string>(name: "FinancialExperience_ProductsOwn_CertificatesofDeposit", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnVariableAnnuity = table.Column<string>(name: "FinancialExperience_ProductsOwn_VariableAnnuity", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnFixedorFIA = table.Column<string>(name: "FinancialExperience_ProductsOwn_FixedorFIA", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnFixedorFIAAmount = table.Column<string>(name: "FinancialExperience_ProductsOwn_FixedorFIAAmount", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnLifeInsuranceAmount = table.Column<string>(name: "FinancialExperience_ProductsOwn_LifeInsuranceAmount", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnMoneyMarketBrokerageAccount = table.Column<string>(name: "FinancialExperience_ProductsOwn_MoneyMarket_BrokerageAccount", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnOther = table.Column<string>(name: "FinancialExperience_ProductsOwn_Other", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnOtherDetails = table.Column<string>(name: "FinancialExperience_ProductsOwn_OtherDetails", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnRealEstate = table.Column<string>(name: "FinancialExperience_ProductsOwn_RealEstate", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnReverseMortgage = table.Column<string>(name: "FinancialExperience_ProductsOwn_ReverseMortgage", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnStocksBondsMutualFunds = table.Column<string>(name: "FinancialExperience_ProductsOwn_Stocks_Bonds_MutualFunds", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnVariableAnnuityAmount = table.Column<string>(name: "FinancialExperience_ProductsOwn_VariableAnnuityAmount", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceProductsOwnPortionOfAnnuitiesWithOutPenalty = table.Column<string>(name: "FinancialExperience_ProductsOwn_PortionOfAnnuitiesWithOutPenalty", type: "nvarchar(max)", nullable: false),
                    FinancialExperienceExistingAssetsAmount = table.Column<string>(name: "FinancialExperience_ExistingAssetsAmount", type: "nvarchar(max)", nullable: false),
                    EmploymentOther = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdeliveryOptIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExistingPolicies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangePolicies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationOfIdentity = table.Column<string>(name: "Verification_Of_Identity", type: "nvarchar(max)", nullable: false),
                    EdeliveryDeliverTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NonLiquidAssetsRealEstate = table.Column<string>(name: "NonLiquidAssets_RealEstate", type: "nvarchar(max)", nullable: false),
                    NonLiquidAssetsAnnuities = table.Column<string>(name: "NonLiquidAssets_Annuities", type: "nvarchar(max)", nullable: false),
                    NonLiquidAssetsPension401k = table.Column<string>(name: "NonLiquidAssets_Pension401k", type: "nvarchar(max)", nullable: false),
                    NonLiquidAssetsLimitedPartnership = table.Column<string>(name: "NonLiquidAssets_LimitedPartnership", type: "nvarchar(max)", nullable: false),
                    NonLiquidAssetsOther = table.Column<string>(name: "NonLiquidAssets_Other", type: "nvarchar(max)", nullable: false),
                    NonLiquidAssetsTotal = table.Column<string>(name: "NonLiquidAssets_Total", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsStocksBonds = table.Column<string>(name: "LiquidAssets_StocksBonds", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsAnnuities = table.Column<string>(name: "LiquidAssets_Annuities", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsMutualFunds = table.Column<string>(name: "LiquidAssets_MutualFunds", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsCDs = table.Column<string>(name: "LiquidAssets_CDs", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsMoneyMarket = table.Column<string>(name: "LiquidAssets_MoneyMarket", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsCheckingSavings = table.Column<string>(name: "LiquidAssets_CheckingSavings", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsPension401k = table.Column<string>(name: "LiquidAssets_Pension401k", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsLifeInsCashSurr = table.Column<string>(name: "LiquidAssets_LifeInsCashSurr", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsOther = table.Column<string>(name: "LiquidAssets_Other", type: "nvarchar(max)", nullable: false),
                    LiquidAssetsTotal = table.Column<string>(name: "LiquidAssets_Total", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveTaxDeferral = table.Column<string>(name: "FinancialObjective_TaxDeferral", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveEstatePlanning = table.Column<string>(name: "FinancialObjective_EstatePlanning", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveGeneralSavings = table.Column<string>(name: "FinancialObjective_GeneralSavings", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveGrowthForFuture = table.Column<string>(name: "FinancialObjective_GrowthForFuture", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveImmediateIncome = table.Column<string>(name: "FinancialObjective_ImmediateIncome", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveLifetimeIncome = table.Column<string>(name: "FinancialObjective_LifetimeIncome", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveOther = table.Column<string>(name: "FinancialObjective_Other", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveQualification = table.Column<string>(name: "FinancialObjective_Qualification", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveRetirementIncome = table.Column<string>(name: "FinancialObjective_RetirementIncome", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveSafetyOfPrincipal = table.Column<string>(name: "FinancialObjective_SafetyOfPrincipal", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveSaveForEmergencies = table.Column<string>(name: "FinancialObjective_SaveForEmergencies", type: "nvarchar(max)", nullable: false),
                    FinancialObjectiveOtherDetails = table.Column<string>(name: "FinancialObjective_OtherDetails", type: "nvarchar(max)", nullable: false),
                    DeathBenefitPaymentOptionsLifetimeWithdrawalPayments = table.Column<string>(name: "DeathBenefitPaymentOptions_LifetimeWithdrawalPayments", type: "nvarchar(max)", nullable: false),
                    PriorYearAmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementIncomeRider = table.Column<string>(name: "ExchangeorReplacement_IncomeRider", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementIncomeRiderDetails = table.Column<string>(name: "ExchangeorReplacement_IncomeRiderDetails", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementCompanyEnhancementsDetails = table.Column<string>(name: "ExchangeorReplacement_CompanyEnhancementsDetails", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnotherAnnuityorLifeExchange = table.Column<string>(name: "ExchangeorReplacement_AnotherAnnuityorLifeExchange", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnotherAnnuityTimeFrame1 = table.Column<string>(name: "ExchangeorReplacement_AnotherAnnuityTimeFrame1", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementLivingBenefitRiderBaseValue = table.Column<string>(name: "ExchangeorReplacement_LivingBenefitRiderBaseValue", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementLivingBenefitRiderBPS = table.Column<string>(name: "ExchangeorReplacement_LivingBenefitRiderBPS", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementLivingBenefitRiderPayoutAmount = table.Column<string>(name: "ExchangeorReplacement_LivingBenefitRiderPayoutAmount", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementLivingBenefitRider = table.Column<string>(name: "ExchangeorReplacement_LivingBenefitRider", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementTaxConsequences = table.Column<string>(name: "ExchangeorReplacement_TaxConsequences", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementTaxConsequencesDetail = table.Column<string>(name: "ExchangeorReplacement_TaxConsequencesDetail", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementSameAgentRecommend = table.Column<string>(name: "ExchangeorReplacement_SameAgentRecommend", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementExchangeAnnuityOrLifeContract = table.Column<string>(name: "ExchangeorReplacement_Exchange_AnnuityOrLifeContract", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementPenaltyFree = table.Column<string>(name: "ExchangeorReplacement_PenaltyFree", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementPartialExchange = table.Column<string>(name: "ExchangeorReplacement_PartialExchange", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementFullExchange = table.Column<string>(name: "ExchangeorReplacement_FullExchange", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementReplacmentCompanyName1 = table.Column<string>(name: "ExchangeorReplacement_ReplacmentCompanyName1", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementReplacmentCompanyName2 = table.Column<string>(name: "ExchangeorReplacement_ReplacmentCompanyName2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementReplacmentCompanyName3 = table.Column<string>(name: "ExchangeorReplacement_ReplacmentCompanyName3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementReplacmentProductName = table.Column<string>(name: "ExchangeorReplacement_ReplacmentProductName", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementReplacmentProductName2 = table.Column<string>(name: "ExchangeorReplacement_ReplacmentProductName2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementReplacmentProductName3 = table.Column<string>(name: "ExchangeorReplacement_ReplacmentProductName3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementExchangeAmount = table.Column<string>(name: "ExchangeorReplacement_ExchangeAmount", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementSurrenderChargeAmount = table.Column<string>(name: "ExchangeorReplacement_SurrenderChargeAmount", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementMVA = table.Column<string>(name: "ExchangeorReplacement_MVA", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementMinGuaranteedIntRate = table.Column<string>(name: "ExchangeorReplacement_MinGuaranteedIntRate", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementSurrenderChargePeriod = table.Column<string>(name: "ExchangeorReplacement_SurrenderChargePeriod", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementPurchaseDate = table.Column<string>(name: "ExchangeorReplacement_PurchaseDate", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementPurchaseDate2 = table.Column<string>(name: "ExchangeorReplacement_PurchaseDate2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementPurchaseDate3 = table.Column<string>(name: "ExchangeorReplacement_PurchaseDate3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementExchangeAmount2 = table.Column<string>(name: "ExchangeorReplacement_ExchangeAmount2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementSurrenderChargeAmount2 = table.Column<string>(name: "ExchangeorReplacement_SurrenderChargeAmount2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementMVA2 = table.Column<string>(name: "ExchangeorReplacement_MVA2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementMinGuaranteedIntRate2 = table.Column<string>(name: "ExchangeorReplacement_MinGuaranteedIntRate2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementSurrenderChargePeriod2 = table.Column<string>(name: "ExchangeorReplacement_SurrenderChargePeriod2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementExchangeAmount3 = table.Column<string>(name: "ExchangeorReplacement_ExchangeAmount3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementSurrenderChargeAmount3 = table.Column<string>(name: "ExchangeorReplacement_SurrenderChargeAmount3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementMVA3 = table.Column<string>(name: "ExchangeorReplacement_MVA3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementMinGuaranteedIntRate3 = table.Column<string>(name: "ExchangeorReplacement_MinGuaranteedIntRate3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementSurrenderChargePeriod3 = table.Column<string>(name: "ExchangeorReplacement_SurrenderChargePeriod3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementPolicyNumber = table.Column<string>(name: "ExchangeorReplacement_PolicyNumber", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementPolicyNumber2 = table.Column<string>(name: "ExchangeorReplacement_PolicyNumber2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementPolicyNumber3 = table.Column<string>(name: "ExchangeorReplacement_PolicyNumber3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnnuityType = table.Column<string>(name: "ExchangeorReplacement_AnnuityType", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnnuityType3 = table.Column<string>(name: "ExchangeorReplacement_AnnuityType3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnnuityType2 = table.Column<string>(name: "ExchangeorReplacement_AnnuityType2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnotherAnnuityDate1 = table.Column<string>(name: "ExchangeorReplacement_AnotherAnnuityDate1", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnotherAnnuityTimeFrame2 = table.Column<string>(name: "ExchangeorReplacement_AnotherAnnuityTimeFrame2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnotherAnnuityDate2 = table.Column<string>(name: "ExchangeorReplacement_AnotherAnnuityDate2", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnotherAnnuityTimeFrame3 = table.Column<string>(name: "ExchangeorReplacement_AnotherAnnuityTimeFrame3", type: "nvarchar(max)", nullable: false),
                    ExchangeorReplacementAnotherAnnuityDate3 = table.Column<string>(name: "ExchangeorReplacement_AnotherAnnuityDate3", type: "nvarchar(max)", nullable: false),
                    CommissionOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnuityId = table.Column<int>(type: "int", nullable: true),
                    FinancialActivityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OLifEExtension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OLifEExtension_Annuity_AnnuityId",
                        column: x => x.AnnuityId,
                        principalTable: "Annuity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OLifEExtension_FinancialActivity_FinancialActivityId",
                        column: x => x.FinancialActivityId,
                        principalTable: "FinancialActivity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OLifEExtension_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OLifEExtension_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OptionLink_IDs",
                columns: table => new
                {
                    OptionLinkSERVICEPROGRAMPolicyId = table.Column<int>(name: "OptionLinkSERVICE_PROGRAMPolicyId", type: "int", nullable: false),
                    OptionLinkSERVICEPROGRAMId = table.Column<int>(name: "OptionLinkSERVICE_PROGRAMId", type: "int", nullable: false),
                    OptionLinkId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTYID = table.Column<string>(name: "PARTY_ID", type: "nvarchar(max)", nullable: false),
                    PARTYNAME = table.Column<string>(name: "PARTY_NAME", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionLink_IDs", x => new { x.OptionLinkSERVICEPROGRAMPolicyId, x.OptionLinkSERVICEPROGRAMId, x.OptionLinkId, x.Id });
                    table.ForeignKey(
                        name: "FK_OptionLink_IDs_OptionLink_OptionLinkSERVICE_PROGRAMPolicyId_OptionLinkSERVICE_PROGRAMId_OptionLinkId",
                        columns: x => new { x.OptionLinkSERVICEPROGRAMPolicyId, x.OptionLinkSERVICEPROGRAMId, x.OptionLinkId },
                        principalTable: "OptionLink",
                        principalColumns: new[] { "SERVICE_PROGRAMPolicyId", "SERVICE_PROGRAMId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_PROGRAM_Extensions_IDs",
                columns: table => new
                {
                    ExtensionSERVICEPROGRAMPolicyId = table.Column<int>(name: "ExtensionSERVICE_PROGRAMPolicyId", type: "int", nullable: false),
                    ExtensionSERVICEPROGRAMId = table.Column<int>(name: "ExtensionSERVICE_PROGRAMId", type: "int", nullable: false),
                    ExtensionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTYID = table.Column<string>(name: "PARTY_ID", type: "nvarchar(max)", nullable: false),
                    PARTYNAME = table.Column<string>(name: "PARTY_NAME", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_PROGRAM_Extensions_IDs", x => new { x.ExtensionSERVICEPROGRAMPolicyId, x.ExtensionSERVICEPROGRAMId, x.ExtensionId, x.Id });
                    table.ForeignKey(
                        name: "FK_SERVICE_PROGRAM_Extensions_IDs_SERVICE_PROGRAM_Extensions_ExtensionSERVICE_PROGRAMPolicyId_ExtensionSERVICE_PROGRAMId_Extens~",
                        columns: x => new { x.ExtensionSERVICEPROGRAMPolicyId, x.ExtensionSERVICEPROGRAMId, x.ExtensionId },
                        principalTable: "SERVICE_PROGRAM_Extensions",
                        principalColumns: new[] { "SERVICE_PROGRAMPolicyId", "SERVICE_PROGRAMId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_PROGRAM_Extensions_Parameters",
                columns: table => new
                {
                    ExtensionSERVICEPROGRAMPolicyId = table.Column<int>(name: "ExtensionSERVICE_PROGRAMPolicyId", type: "int", nullable: false),
                    ExtensionSERVICEPROGRAMId = table.Column<int>(name: "ExtensionSERVICE_PROGRAMId", type: "int", nullable: false),
                    ExtensionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_PROGRAM_Extensions_Parameters", x => new { x.ExtensionSERVICEPROGRAMPolicyId, x.ExtensionSERVICEPROGRAMId, x.ExtensionId, x.Id });
                    table.ForeignKey(
                        name: "FK_SERVICE_PROGRAM_Extensions_Parameters_SERVICE_PROGRAM_Extensions_ExtensionSERVICE_PROGRAMPolicyId_ExtensionSERVICE_PROGRAMId~",
                        columns: x => new { x.ExtensionSERVICEPROGRAMPolicyId, x.ExtensionSERVICEPROGRAMId, x.ExtensionId },
                        principalTable: "SERVICE_PROGRAM_Extensions",
                        principalColumns: new[] { "SERVICE_PROGRAMPolicyId", "SERVICE_PROGRAMId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStep_Extensions_IDs",
                columns: table => new
                {
                    ExtensionWorkflowStepPolicyId = table.Column<int>(type: "int", nullable: false),
                    ExtensionWorkflowStepId = table.Column<int>(type: "int", nullable: false),
                    ExtensionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTYID = table.Column<string>(name: "PARTY_ID", type: "nvarchar(max)", nullable: false),
                    PARTYNAME = table.Column<string>(name: "PARTY_NAME", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStep_Extensions_IDs", x => new { x.ExtensionWorkflowStepPolicyId, x.ExtensionWorkflowStepId, x.ExtensionId, x.Id });
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Extensions_IDs_WorkflowStep_Extensions_ExtensionWorkflowStepPolicyId_ExtensionWorkflowStepId_ExtensionId",
                        columns: x => new { x.ExtensionWorkflowStepPolicyId, x.ExtensionWorkflowStepId, x.ExtensionId },
                        principalTable: "WorkflowStep_Extensions",
                        principalColumns: new[] { "WorkflowStepPolicyId", "WorkflowStepId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStep_Extensions_Parameters",
                columns: table => new
                {
                    ExtensionWorkflowStepPolicyId = table.Column<int>(type: "int", nullable: false),
                    ExtensionWorkflowStepId = table.Column<int>(type: "int", nullable: false),
                    ExtensionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStep_Extensions_Parameters", x => new { x.ExtensionWorkflowStepPolicyId, x.ExtensionWorkflowStepId, x.ExtensionId, x.Id });
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Extensions_Parameters_WorkflowStep_Extensions_ExtensionWorkflowStepPolicyId_ExtensionWorkflowStepId_ExtensionId",
                        columns: x => new { x.ExtensionWorkflowStepPolicyId, x.ExtensionWorkflowStepId, x.ExtensionId },
                        principalTable: "WorkflowStep_Extensions",
                        principalColumns: new[] { "WorkflowStepPolicyId", "WorkflowStepId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annuity_QualPlanSubTypeId",
                table: "Annuity",
                column: "QualPlanSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Annuity_QualPlanTypeId",
                table: "Annuity",
                column: "QualPlanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialActivity_FinActivityTypeId",
                table: "FinancialActivity",
                column: "FinActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialActivity_PolicyId",
                table: "FinancialActivity",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_AccountDesignationId",
                table: "Holdings",
                column: "AccountDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_CurrencyTypeCodeId",
                table: "Holdings",
                column: "CurrencyTypeCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_HoldingStatusId",
                table: "Holdings",
                column: "HoldingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_HoldingTypeCodeId",
                table: "Holdings",
                column: "HoldingTypeCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_PolicyId",
                table: "Holdings",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_OLifEExtension_AnnuityId",
                table: "OLifEExtension",
                column: "AnnuityId");

            migrationBuilder.CreateIndex(
                name: "IX_OLifEExtension_FinancialActivityId",
                table: "OLifEExtension",
                column: "FinancialActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_OLifEExtension_PaymentId",
                table: "OLifEExtension",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OLifEExtension_PolicyId",
                table: "OLifEExtension",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_FinancialActivityId",
                table: "Payment",
                column: "FinancialActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentFormId",
                table: "Payment",
                column: "PaymentFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SourceOfFundsTCId",
                table: "Payment",
                column: "SourceOfFundsTCId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_AnnuityId",
                table: "Policy",
                column: "AnnuityId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_JurisdictionId",
                table: "Policy",
                column: "JurisdictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_LineOfBusinessId",
                table: "Policy",
                column: "LineOfBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureInfo_SignatureOKId",
                table: "SignatureInfo",
                column: "SignatureOKId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holdings");

            migrationBuilder.DropTable(
                name: "OLifEExtension");

            migrationBuilder.DropTable(
                name: "OptionLink_IDs");

            migrationBuilder.DropTable(
                name: "SERVICE_PROGRAM_Extensions_IDs");

            migrationBuilder.DropTable(
                name: "SERVICE_PROGRAM_Extensions_Parameters");

            migrationBuilder.DropTable(
                name: "SERVICE_PROGRAM_IDs");

            migrationBuilder.DropTable(
                name: "SignatureInfo");

            migrationBuilder.DropTable(
                name: "WorkflowStep_Extensions_IDs");

            migrationBuilder.DropTable(
                name: "WorkflowStep_Extensions_Parameters");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "OptionLink");

            migrationBuilder.DropTable(
                name: "SERVICE_PROGRAM_Extensions");

            migrationBuilder.DropTable(
                name: "WorkflowStep_Extensions");

            migrationBuilder.DropTable(
                name: "FinancialActivity");

            migrationBuilder.DropTable(
                name: "SERVICE_PROGRAM");

            migrationBuilder.DropTable(
                name: "WorkflowStep");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Annuity");

            migrationBuilder.DropTable(
                name: "WithTC");
        }
    }
}
