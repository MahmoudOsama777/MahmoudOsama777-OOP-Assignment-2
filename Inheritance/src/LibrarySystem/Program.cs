using LibrarySystem.Items;
using LibrarySystem.Users;


namespace LibrarySystem;

public class Program
{
    static void Main(string[] args)
    {
        //Person person = new Person();
        //Member member = new Member();
        //Staff staff = new Staff();
        //LibraryItem libraryItem = new LibraryItem();

        //member.Loans.Add();

        //libraryItem.IsOnLoan = true;

        LibraryItem book = new Book("Inheritance", 100.00m);
        book.Withdraw();

        try
        {book.Borrow();}
        catch (Exception ex)
        {Console.WriteLine(ex.Message);}

        LibraryItem dvd = new DVD("Intersteller", 50.00m);
        dvd.Borrow();

        try
        { dvd.Borrow(); }
        catch (Exception ex)
        { Console.WriteLine(ex.Message); }

        Member student = new Student("Mahmoud Osama", "01270290993");

        LibraryItem book1 = new Book("The Great Gatsby", 12.50m);
        LibraryItem book2 = new Book("The Hobbit", 5.50m);
        LibraryItem dvd1 = new DVD("Pickaxe", 18.00m);
        LibraryItem magazine1 = new Magazine("Fashion", 13.00m);


        student.AddLoan(new Loan(new DateTime(2026, 9, 10), student.Discount, ref book1));
        student.AddLoan(new Loan(new DateTime(2026, 9, 15), student.Discount, ref dvd1));
        student.AddLoan(new Loan(new DateTime(2026, 9, 16), student.Discount, ref magazine1));

        try
        { student.AddLoan(new Loan(new DateTime(2026, 9, 10), student.Discount, ref book2)); }
        catch(Exception ex) 
        { Console.WriteLine(ex.Message); }


        Librarian librarian = new Librarian("Ahmed Abbas", "0123284214", 2000m);
        HeadLibrarian headLibrarian = new HeadLibrarian("Mohmed Ahmed", "011232345214");
        Shelver shelver = new Shelver("Ali Osama", "015321284214", 4000m, "Drama");

        var staffs = new List<Staff>
        {
            librarian,
            headLibrarian,
            shelver
        };

        foreach (var staff in staffs)
        {
            Console.WriteLine($"{staff.MonthlyPay:C}");
        }

        var items = new List<LibraryItem>
        {
            book1,
            dvd1,
            magazine1
        };

        foreach (var item in items)
        {
            Console.WriteLine($"\nLoan period: {item.LoanPeriod} \nFee: {item.CalculateFee():C}");
        }

        PremiumMember premiumMember = new PremiumMember("Assem Fathy", "0112473284", 100m);
        LibraryItem dvd2 = new DVD("Break Prison", 10.20m);

        Loan loan = new Loan(new DateTime(2026, 9, 16), premiumMember.Discount, ref dvd2);

        premiumMember.AddLoan(loan);
        librarian.ProcessReturn(loan, new DateTime(2026, 9, 28));
        Console.WriteLine($"\nDue date: {loan.DueDate}");
        Console.WriteLine($"Late fees: {loan.LateFee():c}");
        Console.WriteLine($"Reading points: {premiumMember.ReadingPoints}\n");

        try { librarian.ProcessReturn(loan, new DateTime(2026, 9, 28)); }
        catch(Exception ex) { Console.WriteLine(ex.Message); }

        try { librarian.MarkItemAsLost(loan); }
        catch(Exception ex) { Console.WriteLine(ex.Message); }


    }
}
