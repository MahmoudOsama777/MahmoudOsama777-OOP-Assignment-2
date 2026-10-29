namespace SrpLab.NewClasses;

public class MessageCardService
{
    public string GiftMessageCard(string fromName, decimal grandTotal, IEnumerable<string> skus)
    {
        // Customer-facing copy will change with marketing, not with totals.
        var items = string.Join(", ", skus);
        return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal:C}\n";
    }
}
