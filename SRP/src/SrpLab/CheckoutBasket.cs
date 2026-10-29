namespace SrpLab;

/// <summary>
/// Online checkout basket: totals, coupon linguistics, gift-wrap copy, and a faux payment auth code.
/// </summary>
public sealed class CheckoutBasket
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();

    public IReadOnlyList<(string Sku, decimal Price, int Qty)> Lines => _lines;
    public string? CouponRaw { get; private set; }
    public bool GiftWrap { get; private set; }

    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _lines.Add((sku, price, qty));
    }

    public void ApplyCouponText(string? couponText) => CouponRaw = couponText;
    public void EnableGiftWrap() => GiftWrap = true;
    public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);
}
