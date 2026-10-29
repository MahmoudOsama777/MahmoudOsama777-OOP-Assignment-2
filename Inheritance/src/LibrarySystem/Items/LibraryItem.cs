namespace LibrarySystem.Items;

public class LibraryItem
{

    public string CatalogNumber { get; init; }
    public string Title { get; init; }
    public decimal BaseLateFee { get; private set; }
    public bool IsWithdrawn { get; private set; }
    public bool IsOnLoan { get; private set; }
    public int LoanPeriod { get; init; }
    public decimal LateFeeMultiplier { get; private set; }

    protected LibraryItem(string catalogNumber, string title, decimal baseLateFee, int loanPeriod, decimal lateFeeMultiplier)
    {
        CatalogNumber = catalogNumber;
        Title = title;
        BaseLateFee = baseLateFee;
        LoanPeriod = loanPeriod;
        LateFeeMultiplier = lateFeeMultiplier;
    }

    public void ChangeLateFee(decimal fee)
    {
        if (fee < 0)
            throw new ArgumentException("The fee must be positive");

        BaseLateFee = fee;
    }

    public decimal CalculateFee() => BaseLateFee * LateFeeMultiplier;

    public void Withdraw()
    {
        if (IsWithdrawn)
            throw new ArgumentException("Cannot withdraw item already was withdrawn.");

        IsWithdrawn = true;
    }

    public void Restore()
    {
        if (!IsWithdrawn)
            throw new ArgumentException("Cannot restore item already was restored.");

        IsWithdrawn = false;
    }

    public void Borrow()
    {
        if (IsWithdrawn)
            throw new ArgumentException("Cannot borrow withdrawn item.");

        if (IsOnLoan)
            throw new ArgumentException("Cannot borrow item already borrowed by someone.");

        IsOnLoan = true;
    }

    public void Return()
    {
        if (!IsOnLoan)
            throw new ArgumentException("Cannot return already returned item.");

        IsOnLoan = false;
    }

}
