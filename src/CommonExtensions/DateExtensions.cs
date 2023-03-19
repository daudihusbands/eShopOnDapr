namespace CommonExtensions
{
    public static class DateExtensions
    {
        public static int GetDifferenceInYears(this DateTime startDate, DateTime endDate)
        {
            //Excel documentation says "COMPLETE calendar years in between dates"
            int years = endDate.Year - startDate.Year;

            if (startDate.Month == endDate.Month &&// if the start month and the end month are the same
                endDate.Day < startDate.Day// AND the end day is less than the start day
                || endDate.Month < startDate.Month)// OR if the end month is less than the start month
            {
                years--;
            }

            return years;
        }
    }
}
