namespace SrpLab.NewClasses;

public class DocumentationService
{
    public static string TranscriptStudentGrade(string studentId, string fullName,decimal average ,string letter,bool IsMeetHonorRoll)
    {
        // Registrar document format ≠ grading policy.
        return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {average}\nLetter: {letter}\nHonor: {IsMeetHonorRoll}\n";
    }

    public static IReadOnlyList<string> RequiredDeskDocuments(LoanDesk loanDesk)
    {
        // Compliance checklist changes with regulation, independently of risk formula.
        var docs = new List<string> { "National ID", "Proof of income (3 months)" };
        if (loanDesk.RequestedAmount > 40_000m) docs.Add("Bank statements (6 months)");
        if (loanDesk.HasCollateral) docs.Add("Collateral ownership deed");
        if (loanDesk.EmploymentMonths < 12) docs.Add("Employer letter");
        if (!loanDesk.IsEligible()) docs.Add("Manual underwriter referral form");
        return docs;
    }

    public static string WareHousePickerScript(IReadOnlyList<(string Sku, int Allocated)> allocate, IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> walkingOrder
        , IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
    {
        // UX wording for handheld devices — separate owners.
        var steps = walkingOrder
            .Select((s, i) => $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");
        var shortfalls = allocate.Where(a =>
        {
            var need = lines.First(l => l.Sku == a.Sku).QtyNeeded;
            return a.Allocated < need;
        });
        var warn = shortfalls.Any()
            ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
            : "SHORTAGES: none";
        return string.Join('\n', steps) + "\n" + warn;
    }
}
