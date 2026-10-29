namespace SrpLab.NewClasses;

public class FinanceRules
{
    public static decimal Prorate(DateOnly periodStart, DateOnly periodEnd, DateOnly activeFrom, decimal monthlyPrice)
    {
        // Finance calendar rules change independently of email copy.
        if (activeFrom <= periodStart) return monthlyPrice;
        if (activeFrom >= periodEnd) return 0m;
        var totalDays = periodEnd.DayNumber - periodStart.DayNumber;
        if (totalDays <= 0) return monthlyPrice;
        var used = periodEnd.DayNumber - activeFrom.DayNumber;
        return Math.Round(monthlyPrice * used / totalDays, 2);
    }
}
