namespace NewApps.Domain.Entities.ACORD
{
    public class AcordSuitabilityQuestion
    {
        public AcordSuitabilityQuestion(string questionName, string questionValue)
        {
            QuestionName = questionName;
            QuestionValue = questionValue;
        }

        public class Questions
        {

            public const string Agent_ChangePolicies = "Agent_ChangePolicies";
            public const string Agent_ExistingPolicies = "Agent_ExistingPolicies";
            public const string Verification_Of_Identity = "Verification_Of_Identity";
            public const string Agent_DeliverPolicy = "Agent_DeliverPolicy";

            public const string Agent_Recommended_Suitable_Annuity = "Agent_Recommended_Suitable_Annuity";
            public const string Agent_Same_Address_Explain = "Agent_Same_Address_Explain";
            public const string Agent_SameAddress = "Agent_SameAddress";
            public const string Agent_Sold_Policies = "Agent_Sold_Policies";
            public const string Agent_IDNumber = "Agent_IDNumber";
            public const string License_Number = "License_Number";


            public const string Agent_Sold_Policies_Number = "Agent_Sold_Policies_Number";
            public const string Agent_Sold_Policies_Number_InForce = "Agent_Sold_Policies_Number_InForce";
            public const string Same_Address_Agent = "Same_Address_Agent";
            public const string Same_Address_Explain = "Same_Address_Explain";


            public const string Annuitant_Consulted_HealthCare_Advisor = "Annuitant_Consulted_HealthCare_Advisor";
            public const string Annuitant_Consulted_HealthCare_Advisor_Explain = "Annuitant_Consulted_HealthCare_Advisor_Explain";
            public const string Annuitant_Reside_NursingHome_Facility = "Annuitant_Reside_NursingHome_Facility";
            public const string Annuitant_Reside_NursingHome_Facility_Explain = "Annuitant_Reside_NursingHome_Facility_Explain";
            public const string Annuity_Purchase_Other_Info_Explain = "Annuity_Purchase_Other_Info_Explain";
            public const string Surrender_Policy_Early = "Surrender_Policy_Early";
            public const string Interest_Credits_Fluctuate = "Interest_Credits_Fluctuate";



            public const string Annuity_Annuitization = "Annuity_Annuitization";
            public const string Annuity_Leave_Beneficiary = "Annuity_Leave_Beneficiary";
            public const string Annuity_LifeTime_Withdrawal = "Annuity_LifeTime_Withdrawal";
            public const string Annuity_Loans = "Annuity_Loans";
            public const string Annuity_Partial_Surrenders = "Annuity_Partial_Surrenders";
            public const string Annuity_PenaltyFree_Withdrawals = "Annuity_PenaltyFree_Withdrawals";
            public const string Annuity_RMDs = "Annuity_RMDs";
            public const string Annuity_Single_Lump_Sum = "Annuity_Single_Lump_Sum";
            public const string Annuity_Systematic_IntWithdrawals = "Annuity_Systematic_IntWithdrawals";

            public const string SourceOfFunds_CD = "SourceOfFunds_CD";
            public const string SourceOfFunds_CheckingAccount = "SourceOfFunds_CheckingAccount";
            public const string SourceOfFunds_DeathBenefit = "SourceOfFunds_DeathBenefit";
            public const string SourceOfFunds_DeathBenefit_Details = "SourceOfFunds_DeathBenefit_Details";
            public const string SourceOfFunds_FA = "SourceOfFunds_FA";
            public const string SourceOfFunds_LifeInsurance = "SourceOfFunds_LifeInsurance";
            public const string SourceOfFunds_MoneyMarket = "SourceOfFunds_MoneyMarket";
            public const string SourceOfFunds_MutualFunds = "SourceOfFunds_MutualFunds";
            public const string SourceOfFunds_Other = "SourceOfFunds_Other";
            public const string SourceOfFunds_Other_Details = "SourceOfFunds_Other_Details";
            public const string SourceOfFunds_ReverseMortgage = "SourceOfFunds_ReverseMortgage";
            public const string SourceOfFunds_VA = "SourceOfFunds_VA";


            public const string Annuity_FirstDistribution = "Annuity_FirstDistribution";
            public const string Annuity_InForceNWL = "Annuity_InForceNWL";

            public const string FinInfo_Assets_Investments = "FinInfo_Assets_Investments";
            public const string FinInfo_Assets_LiquidNetWorth = "FinInfo_Assets_LiquidNetWorth";
            public const string FinInfo_Assets_Other = "FinInfo_Assets_Other";
            public const string FinInfo_Assets_Other_Details = "FinInfo_Assets_Other_Details";
            public const string FinInfo_Assets_Pension = "FinInfo_Assets_Pension";
            public const string FinInfo_Assets_SocialSecurity = "FinInfo_Assets_SocialSecurity";
            public const string FinInfo_Assets_Wages = "FinInfo_Assets_Wages";
            public const string FinInfo_Expenses_Annual = "FinInfo_Expenses_Annual";
            public const string FinInfo_Expenses_ExpectedChanges = "FinInfo_Expenses_ExpectedChanges";
            public const string FinInfo_Expenses_ExpectedChanges_Details = "FinInfo_Expenses_ExpectedChanges_Details";
            public const string FinInfo_Expenses_Sufficient = "FinInfo_Expenses_Sufficient";


            public const string FinInfo_LiquidAssets_StocksBonds = "FinInfo_LiquidAssets_StocksBonds";
            public const string FinInfo_LiquidAssets_Annuities = "FinInfo_LiquidAssets_Annuities";
            public const string FinInfo_LiquidAssets_MutualFunds = "FinInfo_LiquidAssets_MutualFunds";
            public const string FinInfo_LiquidAssets_CDs = "FinInfo_LiquidAssets_CDs";
            public const string FinInfo_LiquidAssets_MoneyMarket = "FinInfo_LiquidAssets_MoneyMarket";
            public const string FinInfo_LiquidAssets_CheckingSavings = "FinInfo_LiquidAssets_CheckingSavings";
            public const string FinInfo_LiquidAssets_Pension401k = "FinInfo_LiquidAssets_Pension401k";
            public const string FinInfo_LiquidAssets_LifeInsCashSurr = "FinInfo_LiquidAssets_LifeInsCashSurr";
            public const string FinInfo_LiquidAssets_Other = "FinInfo_LiquidAssets_Other";
            public const string FinInfo_LiquidAssets_Total = "FinInfo_LiquidAssets_Total";


            public const string FinInfo_NonLiquidAssets_RealEstate = "FinInfo_NonLiquidAssets_RealEstate";
            public const string FinInfo_NonLiquidAssets_Annuities = "FinInfo_NonLiquidAssets_Annuities";
            public const string FinInfo_NonLiquidAssets_Pension401k = "FinInfo_NonLiquidAssets_Pension401k";
            public const string FinInfo_NonLiquidAssets_LimitedPartnership = "FinInfo_NonLiquidAssets_LimitedPartnership";
            public const string FinInfo_NonLiquidAssets_Other = "FinInfo_NonLiquidAssets_Other";
            public const string FinInfo_NonLiquidAssets_Total = "FinInfo_NonLiquidAssets_Total";


            public const string FinInfo_ExistingAssets_Amount = "FinInfo_ExistingAssets_Amount";
            public const string FinInfo_ProductsOwn = "FinInfo_ProductsOwn";
            public const string FinInfo_ProductsOwn_CD = "FinInfo_ProductsOwn_CD";
            public const string FinInfo_ProductsOwn_FIA = "FinInfo_ProductsOwn_FIA";
            public const string FinInfo_ProductsOwn_FIA_Amount = "FinInfo_ProductsOwn_FIA_Amount";
            public const string FinInfo_ProductsOwn_LifeInsurance = "FinInfo_ProductsOwn_LifeInsurance";
            public const string FinInfo_ProductsOwn_LifeInsurance_Amount = "FinInfo_ProductsOwn_LifeInsurance_Amount";
            public const string FinInfo_ProductsOwn_MoneyMarket = "FinInfo_ProductsOwn_MoneyMarket";
            public const string FinInfo_ProductsOwn_Other = "FinInfo_ProductsOwn_Other";
            public const string FinInfo_ProductsOwn_Other_Details = "FinInfo_ProductsOwn_Other_Details";
            public const string FinInfo_ProductsOwn_RealEstate = "FinInfo_ProductsOwn_RealEstate";
            public const string FinInfo_ProductsOwn_ReverseMortgage = "FinInfo_ProductsOwn_ReverseMortgage";
            public const string FinInfo_ProductsOwn_Stocks = "FinInfo_ProductsOwn_Stocks";
            public const string FinInfo_ProductsOwn_VA = "FinInfo_ProductsOwn_VA";
            public const string FinInfo_ProductsOwn_VA_Amount = "FinInfo_ProductsOwn_VA_Amount";
            public const string Portion_Penalty = "Portion_Penalty";


            public const string FinInfo_RiskTolerance = "FinInfo_RiskTolerance";



            public const string FinObj_Purchase_Deferral = "FinObj_Purchase_Deferral";
            public const string FinObj_Purchase_EstatePlanning = "FinObj_Purchase_EstatePlanning";
            public const string FinObj_Purchase_GeneralSavings = "FinObj_Purchase_GeneralSavings";
            public const string FinObj_Purchase_Growth = "FinObj_Purchase_Growth";
            public const string FinObj_Purchase_ImmediateIncome = "FinObj_Purchase_ImmediateIncome";
            public const string FinObj_Purchase_LifetimeIncome = "FinObj_Purchase_LifetimeIncome";
            public const string FinObj_Purchase_Other = "FinObj_Purchase_Other";
            public const string FinObj_Purchase_Other_Details = "FinObj_Purchase_Other_Details";
            public const string FinObj_Purchase_Qualification = "FinObj_Purchase_Qualification";
            public const string FinObj_Purchase_RetirementIncome = "FinObj_Purchase_RetirementIncome";
            public const string FinObj_Purchase_Safety_Principal = "FinObj_Purchase_Safety_Principal";
            public const string FinObj_Purchase_Save_Emergencies = "FinObj_Purchase_Save_Emergencies";


            public const string Payments_Beneficiary = "Payments_Beneficiary";


            public const string Replacement_Company_Annuitize_IncomeRider = "Replacement_Company_Annuitize_IncomeRider";
            public const string Replacement_Company_Annuitize_IncomeRider_Explain = "Replacement_Company_Annuitize_IncomeRider_Explain";
            public const string Replacement_Company_Annuity_Enhancements = "Replacement_Company_Annuity_Enhancements";
            public const string Replacement_Company_Another_Annuity = "Replacement_Company_Another_Annuity";
            public const string Replacement_Company_Another_Annuity_TimeFrame1 = "Replacement_Company_Another_Annuity_TimeFrame1";
            public const string Replacement_Company_Current_Benefit_BaseValue = "Replacement_Company_Current_Benefit_BaseValue";
            public const string Replacement_Company_Current_Rider_BPS = "Replacement_Company_Current_Rider_BPS";
            public const string Replacement_Company_LivingBeneRider = "Replacement_Company_LivingBeneRider";
            public const string Replacement_Company_Rider_Estimated_Payout = "Replacement_Company_Rider_Estimated_Payout";
            public const string Replacement_Company_Tax_Consequences = "Replacement_Company_Tax_Consequences";
            public const string Replacement_Company_Tax_Consequences_Explain = "Replacement_Company_Tax_Consequences_Explain";
            public const string Same_Agent_Recommend = "Same_Agent_Recommend";
            public const string Replacement_Annuity_Life_Contract = "Replacement_Annuity_Life_Contract";
            public const string Replacement_Company_1035_PenaltyFree = "Replacement_Company_1035_PenaltyFree";
            public const string Replacement_Company_1035_PartialExchange = "Replacement_Company_1035_PartialExchange";
            public const string Replacement_Company_1035_FullExchange = "Replacement_Company_1035_FullExchange";
            public const string Replacement_Company_Name1 = "Replacement_Company_Name1";
            public const string Replacement_Company_Name2 = "Replacement_Company_Name2";
            public const string Replacement_Company_Name3 = "Replacement_Company_Name3";
            public const string Replacement_Company_Product_Name = "Replacement_Company_Product_Name";
            public const string Replacement_Company_Product_Name2 = "Replacement_Company_Product_Name2";
            public const string Replacement_Company_Product_Name3 = "Replacement_Company_Product_Name3";
            public const string Replacement_Company_1035_Partial_Amount = "Replacement_Company_1035_Partial_Amount";
            public const string Replacement_Company_Surrender_Charge_Amount = "Replacement_Company_Surrender_Charge_Amount";
            public const string Replacement_Company_Market_Value = "Replacement_Company_Market_Value";
            public const string Replacement_Company_Guaranteed_Interest_Rate = "Replacement_Company_Guaranteed_Interest_Rate";
            public const string Replacement_Company_Surrender_Charge_Period = "Replacement_Company_Surrender_Charge_Period";
            public const string Replacement_Company_Purchase_Date = "Replacement_Company_Purchase_Date";
            public const string Replacement_Company_Purchase_Date2 = "Replacement_Company_Purchase_Date2";
            public const string Replacement_Company_Purchase_Date3 = "Replacement_Company_Purchase_Date3";
            public const string Replacement_Company_1035_Partial_Amount2 = "Replacement_Company_1035_Partial_Amount2";
            public const string Replacement_Company_Surrender_Charge_Amount2 = "Replacement_Company_Surrender_Charge_Amount2";
            public const string Replacement_Company_Market_Value2 = "Replacement_Company_Market_Value2";
            public const string Replacement_Company_Guaranteed_Interest_Rate2 = "Replacement_Company_Guaranteed_Interest_Rate2";
            public const string Replacement_Company_Surrender_Charge_Period2 = "Replacement_Company_Surrender_Charge_Period2";
            public const string Replacement_Company_1035_Partial_Amount3 = "Replacement_Company_1035_Partial_Amount3";
            public const string Replacement_Company_Surrender_Charge_Amount3 = "Replacement_Company_Surrender_Charge_Amount3";
            public const string Replacement_Company_Market_Value3 = "Replacement_Company_Market_Value3";
            public const string Replacement_Company_Guaranteed_Interest_Rate3 = "Replacement_Company_Guaranteed_Interest_Rate3";
            public const string Replacement_Company_Surrender_Charge_Period3 = "Replacement_Company_Surrender_Charge_Period3";
            public const string Replacement_Company_PolicyNumber = "Replacement_Company_PolicyNumber";
            public const string Replacement_Company_PolicyNumber2 = "Replacement_Company_PolicyNumber2";
            public const string Replacement_Company_PolicyNumber3 = "Replacement_Company_PolicyNumber3";
            public const string Replacement_Company_Annuity_Type = "Replacement_Company_Annuity_Type";
            public const string Replacement_Company_Annuity_Type2 = "Replacement_Company_Annuity_Type2";
            public const string Replacement_Company_Annuity_Type3 = "Replacement_Company_Annuity_Type3";
            public const string Replacement_Company_Another_Annuity_Date1 = "Replacement_Company_Another_Annuity_Date1";
            public const string Replacement_Company_Another_Annuity_TimeFrame2 = "Replacement_Company_Another_Annuity_TimeFrame2";
            public const string Replacement_Company_Another_Annuity_Date2 = "Replacement_Company_Another_Annuity_Date2";
            public const string Replacement_Company_Another_Annuity_TimeFrame3 = "Replacement_Company_Another_Annuity_TimeFrame3";
            public const string Replacement_Company_Another_Annuity_Date3 = "Replacement_Company_Another_Annuity_Date3";



            public const string Employment_Other = "Employment_Other";
            public const string Owner_EmpDetails_EmployerName = "Owner_EmpDetails_EmployerName";
            public const string Owner_EmpDetails_Occupation = "Owner_EmpDetails_Occupation";
            public const string Owner_Employment_Status = "Owner_Employment_Status";

            public const string Owner_ID_Number = "Owner_ID_Number";
            public const string Owner_ID_State = "Owner_ID_State";
            public const string Owner_MaritalStatus = "Owner_MaritalStatus";
            public const string OwnerEDelivery = "OwnerEDelivery";
            public const string Owner_ExistingPolicies = "Owner_ExistingPolicies";
            public const string Owner_PhoneNumber_PhoneType = "Owner_PhoneNumber_PhoneType";

            public const string Annuitant_ID_Number = "Annuitant_ID_Number";
            public const string Annuitant_ID_State = "Annuitant_ID_State";
            public const string Annuitant_PhoneNumber_PhoneType = "Annuitant_PhoneNumber_PhoneType";
            public const string Annuitant_MaritalStatus = "Annuitant_MaritalStatus";


            public const string JointAnnuitant_ID_Number = "JointAnnuitant_ID_Number";
            public const string JointAnnuitant_ID_State = "JointAnnuitant_ID_State";
            public const string JointAnnuitant_PhoneNumber_PhoneType = "JointAnnuitant_PhoneNumber_PhoneType";
            public const string JointAnnuitant_MaritalStatus = "JointAnnuitant_MaritalStatus";


            public const string JointOwner_ID_Number = "JointOwner_ID_Number";
            public const string JointOwner_ID_State = "JointOwner_ID_State";
            public const string JointOwner_PhoneNumber_PhoneType = "JointOwner_PhoneNumber_PhoneType";
            public const string JointOwner_MaritalStatus = "JointOwner_MaritalStatus";

        }





        public string QuestionName { get; set; }
        public string QuestionValue { get; set; }
        public override string ToString() => $"{QuestionName}:{QuestionValue}";
    }
}