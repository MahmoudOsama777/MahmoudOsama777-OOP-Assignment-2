using LibrarySystem.Items;

namespace LibrarySystem.Users;

public class Member : Person
{
    public int MaxLoans { get; init; }
    public decimal Discount { get; init; }
    private readonly List<Loan> _loans = new List<Loan>();
    public IReadOnlyList<Loan> Loans => _loans;
    public int CurrentLoanedItems => Loans.Count(n => n.Status == LoanStatus.Borrowed);
    public bool CanLoanItem => CurrentLoanedItems < MaxLoans;

    protected Member(string fullName, string phoneNumber,int maxLoans,decimal discount)
        : base(fullName, phoneNumber)
    {
        MaxLoans = maxLoans;
        Discount = discount;
    }   

    public void AddLoan(Loan loan)
    {
        if (!CanLoanItem)
            throw new ArgumentException("Can't loan more items you reached to the maximum");

        _loans.Add(loan);
    }
}
