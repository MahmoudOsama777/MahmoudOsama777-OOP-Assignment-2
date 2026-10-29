using LibrarySystem.Items;

namespace LibrarySystem.Users;

public class Librarian : Staff
{
    public Librarian(string fullName, string phoneNumber, decimal monthlyPay)
    : base(fullName, phoneNumber, monthlyPay) { }
    
    public void ProcessReturn(Loan loan,DateTime returnDate)
    {
        loan.ReturnItem(returnDate);
    }

    public void MarkItemAsLost(Loan loan)
    {
        loan.MarkAsLost();
    }
}
