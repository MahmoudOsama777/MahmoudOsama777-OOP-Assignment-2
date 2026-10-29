using SrpLab.NewClasses;

namespace SrpLab;

/// <summary>
/// Kitchen ticket: allergen scan from ingredients, cook ETA heuristics, and printed ticket layout.
/// </summary>
public sealed class KitchenTicket
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();
    public IReadOnlyList<string> Ingredients => _items.SelectMany(s => s.Ingredients).ToList();

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        _items.Add((item, ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(), prepMinutes));
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        // Kitchen ops model ≠ printing.
        if (openStations <= 0) openStations = 1;
        var sequential = _items.Sum(i => i.PrepMinutes);
        var parallel = (int)Math.Ceiling(sequential / (double)openStations);
        var detectAllergeens = FoodClassification.DetectAllergens(_items.SelectMany(s => s.Ingredients));
        if (detectAllergeens.Count > 0) parallel += 3; // allergy protocol delay mixed in
        var longest = _items.Count == 0 ? 0 : _items.Max(i => i.PrepMinutes);
        return Math.Max(parallel, longest);
    }

    public string ExpoLaneHint()
    {
        var detectAllergeens = FoodClassification.DetectAllergens(_items.SelectMany(s => s.Ingredients));
        return detectAllergeens.Count > 0 ? "LANE-ALLERGY" : EstimatedReadyMinutes(2) > 20 ? "LANE-SLOW" : "LANE-FAST";
    }
}
