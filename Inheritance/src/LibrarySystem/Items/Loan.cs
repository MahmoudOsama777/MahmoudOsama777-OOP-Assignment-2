namespace LibrarySystem.Items;

public class Loan
{
    private static int _nextId = 1;
    public int LoanId { get; }
    public DateTime BorrowDate {  get; }
    public LoanStatus Status { get; private set; }
    public DateTime? ReturnDate { get; set; }
    public decimal MemberDiscount { get; init; }
    public LibraryItem Item { get; set; }
    public DateTime DueDate => BorrowDate.AddDays(Item.LoanPeriod);

    public decimal LateFee()
    {
        if (!ReturnDate.HasValue || ReturnDate.Value <= DueDate)
            return 0;

        decimal fees = (decimal)(ReturnDate.Value - DueDate).TotalDays * Item.CalculateFee() - MemberDiscount;

        return fees > 0 ? fees : 0;
    }


    public Loan(DateTime borrowDate, decimal memberDiscount, ref LibraryItem item)
    {
        item.Borrow();
        LoanId = _nextId++;

        BorrowDate = borrowDate;
        Status = LoanStatus.Borrowed;
        MemberDiscount = memberDiscount;
        Item = item;
    }

    public void ReturnItem(DateTime returnDate)
    {
        if(Status == LoanStatus.Lost)
            throw new ArgumentException("Cannot return lost item.");

        if (Status == LoanStatus.Returned)
            throw new ArgumentException("Cannot return an already returned item.");

        if (returnDate < BorrowDate)
            throw new ArgumentException("Return date cannot be earlier than borrow date.");

        Item.Return();
        Status = LoanStatus.Returned;
        ReturnDate = returnDate; 
    }

    public void MarkAsLost()
    {
        if (Status == LoanStatus.Returned)
            throw new ArgumentException("Cannot mark as lost returned item.");

        Status = LoanStatus.Lost;
    }

    public void PrintDetails()
    {
        Console.WriteLine(new string('=', 45));
        Console.WriteLine($" LOAN RECEIPT (ID: {LoanId:D4})");
        Console.WriteLine(new string('=', 45));

        // Loan Information
        Console.WriteLine($"{"Status:",-18} {Status}");
        Console.WriteLine($"{"Borrow Date:",-18} {BorrowDate:MMM dd, yyyy}");
        Console.WriteLine($"{"Due Date:",-18} {DueDate:MMM dd, yyyy}");

        string returnDateStr = ReturnDate.HasValue ? ReturnDate.Value.ToString("MMM dd, yyyy") : "Pending Return";
        Console.WriteLine($"{"Return Date:",-18} {returnDateStr}");

        // Item Information
        Console.WriteLine(new string('-', 45));
        Console.WriteLine(" ITEM DETAILS");
        Console.WriteLine(new string('-', 45));
        Console.WriteLine($"{"Title:",-18} {Item.Title}");
        Console.WriteLine($"{"Catalog No:",-18} {Item.CatalogNumber}");
        Console.WriteLine($"{"Loan Period:",-18} {Item.LoanPeriod} days");
        Console.WriteLine($"{"Daily Late Fee:",-18} {Item.CalculateFee():C}");

        // Financial Information
        Console.WriteLine(new string('-', 45));
        Console.WriteLine(" FINANCIALS");
        Console.WriteLine(new string('-', 45));
        Console.WriteLine($"{"Member Discount:",-18} {MemberDiscount:C}");

        // Only calculate late fee if the item has actually been returned
        if (ReturnDate.HasValue)
        {
            Console.WriteLine($"{"Total Late Fee:",-18} {LateFee():C}");
        }
        else
        {
            Console.WriteLine($"{"Total Late Fee:",-18} (Calculated upon return)");
        }

        Console.WriteLine(new string('=', 45));
        Console.WriteLine();
    }
}
