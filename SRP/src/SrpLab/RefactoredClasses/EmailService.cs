namespace SrpLab.NewClasses;

public class EmailService
{
    public static string DunningEmail(string customerName, DateOnly asOf, decimal amount, string? invoice,int failedPayment)
    {
        // Collections tone & legal boilerplate ≠ proration formula.
        var severity = failedPayment switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };
        return $"Subject: {severity} {invoice}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({failedPayment} failures).\n";
    }
}
