using LibrarySystem.Common;

namespace LibrarySystem.Items;

public class Book : LibraryItem
{
    public Book(string title, decimal baseLateFee)
        : base("BK-" + Guid.NewGuid().ToString(), title, baseLateFee, LibraryPolicy.Instance.BookLoanPeriod,
            LibraryPolicy.Instance.BookChargesFee) { }           
}