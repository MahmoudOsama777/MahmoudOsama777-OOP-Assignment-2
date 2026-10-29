namespace SrpLab;

/// <summary>
/// Subscription billing: proration math, invoice number minting, and dunning email bodies.
/// </summary>
public sealed class SubscriptionBilling
{
    private static int _invoiceSeq = 1000;

    public string CustomerId { get; }
    public decimal MonthlyPrice { get; }
    public DateOnly PeriodStart { get; }
    public DateOnly PeriodEnd { get; }
    public int FailedPayments { get; private set; }

    public SubscriptionBilling(string customerId, decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd)
    {
        CustomerId = customerId;
        MonthlyPrice = monthlyPrice;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }

    public string NextInvoiceNumber()
    {
        // Numbering scheme / fiscal prefixes — ops concern, not pricing.
        var n = ++_invoiceSeq;
        return $"INV-{PeriodStart:yyyyMM}-{n:D5}";
    }

    public void RegisterFailedPayment() => FailedPayments++;
}
