namespace SrpLab.NewClasses;

public class CheckoutCalculator
{
    public static decimal DiscountAmount(string? _couponRaw, decimal subTotal)
    {
        // Parsing marketing strings is a different reason to change than pricing math.
        if (string.IsNullOrWhiteSpace(_couponRaw)) return 0m;
        var t = _couponRaw.Trim().ToUpperInvariant();
        if (t.StartsWith("SAVE") && int.TryParse(t[4..], out var pct) && pct is > 0 and <= 50)
            return Math.Round(subTotal * pct / 100m, 2);
        if (t.Contains("FREESHIP")) return 0m; // ship is elsewhere — still parsed here
        if (t == "WELCOME10") return Math.Min(10m, subTotal);
        return 0m;
    }

    public static decimal GrandTotal(string? _couponRaw, decimal subTotal, bool giftWrap)
    {
        var total = subTotal - DiscountAmount(_couponRaw, subTotal);
        if (giftWrap) total += 4.99m; // packaging fee policy ≠ cart math
        return Math.Max(0m, total);
    }
}
