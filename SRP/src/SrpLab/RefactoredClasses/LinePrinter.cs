namespace SrpLab.NewClasses;

public class LinePrinter
{
    public static string LedgerJournalLine(string customerId, string invoice, decimal prorate)
    {
        // Accounting export format is another axis of change.
        return $"{customerId},{invoice},{prorate:0.00},AR-SUB";
    }

    public static string InternalEscalationBlurb(string id, string priority, DateTimeOffset slaDeadline)
    {
        return $"ESCALATE {id} priority={priority} breachAt={slaDeadline:u} keywords-scanned=yes";
    }
}
