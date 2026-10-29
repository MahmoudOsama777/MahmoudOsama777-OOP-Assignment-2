namespace SrpLab;

/// <summary>
/// Loan desk: eligibility arithmetic, required-document lists, and rejection letter prose.
/// </summary>
public sealed class LoanDesk
{
    public decimal RequestedAmount { get; }
    public int CreditScore { get; }
    public int EmploymentMonths { get; }
    public bool HasCollateral { get; }

    public LoanDesk(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore()
    {
        // Risk model will change with risk committee — not with letter templates.
        decimal score = 100m;
        score -= Math.Max(0, 700 - CreditScore) * 0.15m;
        if (EmploymentMonths < 6) score -= 20m;
        if (RequestedAmount > 50_000m && !HasCollateral) score -= 25m;
        if (RequestedAmount > 150_000m) score -= 10m;
        return Math.Clamp(score, 0m, 100m);
    }

    public bool IsEligible() => RiskScore() >= 55m && CreditScore >= 580;





    public string UnderwriterCsvRow(string applicationId)
    {
        // Analytics export schema is yet another reason to change.
        return $"{applicationId},{CreditScore},{EmploymentMonths},{(HasCollateral ? 1 : 0)},{RiskScore():0.00},{(IsEligible() ? "Y" : "N")}";
    }
}
