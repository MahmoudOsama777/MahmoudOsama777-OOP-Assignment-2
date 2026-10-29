namespace SrpLab;

/// <summary>
/// Warehouse pick list: naive path order, stock allocation, and picker instruction prose.
/// </summary>
public sealed class WarehousePickList
{
    private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();
    public IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> Lines => _lines;

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
    {
        _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
    }

    public IReadOnlyList<(string Sku, int Allocated)> Allocate()
    {
        // Allocation/backorder policy ≠ walking path ≠ human instructions.
        var result = new List<(string, int)>();
        foreach (var line in _lines)
        {
            var alloc = Math.Min(line.QtyNeeded, line.QtyOnHand);
            result.Add((line.Sku, alloc));
        }
        return result;
    }

    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
    {
        // Path heuristic will change with warehouse layout tech.
        return _lines
            .OrderBy(l => l.Aisle)
            .ThenBy(l => l.Bin)
            .Select(l => (l.Aisle, l.Bin, l.Sku, Math.Min(l.QtyNeeded, l.QtyOnHand)))
            .Where(x => x.Item4 > 0)
            .ToList();
    }

}
