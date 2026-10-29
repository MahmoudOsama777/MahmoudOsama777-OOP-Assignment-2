namespace SrpLab.NewClasses;

public class RenderThermal
{
    public static string RenderThermalTicket(int orderNumber, int estimatedReadyMinutes, IEnumerable<string> ingredients)
    {
        // Hardware/formatting concerns — width, separators — change with printer vendor.
        var width = 32;
        var line = new string('=', width);
        var body = string.Join('\n', ingredients);
        var allergens = FoodClassification.DetectAllergens(ingredients);
        var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
        return $"{line}\nORDER #{orderNumber}\nETA {estimatedReadyMinutes} MIN\n{body}\n{allergyLine}\n{line}\n";
    }
}
