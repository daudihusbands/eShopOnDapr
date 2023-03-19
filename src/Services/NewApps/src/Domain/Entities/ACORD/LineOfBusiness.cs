namespace NewApps.Domain.Entities.ACORD
{
    public class LineOfBusiness
    {


        private static readonly IDictionary<string, WithTC> dict = new Dictionary<string, WithTC>{
                    { ProductPlanCode.LTRSSelect_Single, WithTC.Create("1", "Life") },
                    { ProductPlanCode.LTRSSelect_5Pay, WithTC.Create("1", "Life") },
                    { ProductPlanCode.LTRSSelect_10Pay, WithTC.Create("1", "Life") },
                    { ProductPlanCode.ChoiceOptimizer, WithTC.Create("2", "Annuity") },
                    { ProductPlanCode.BlueChip, WithTC.Create("2", "Annuity") },
                    { ProductPlanCode.IPPlus, WithTC.Create("2", "Annuity") },
                };

        public static WithTC Get(string productPlanCode) => dict[productPlanCode] ?? dict[ProductPlanCode.BlueChip];


    }
}
