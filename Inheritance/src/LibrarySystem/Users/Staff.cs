namespace LibrarySystem.Users;

public class Staff : Person
{

    public DateTime HireDate { get; }
    public decimal MonthlyPay { get; private set; }

    protected Staff(string fullName, string phoneNumber, decimal monthlyPay)
    : base(fullName, phoneNumber)
    {
        HireDate = DateTime.Now;
        MonthlyPay = monthlyPay;
    }

    public void GiveRaise(decimal percentage)
    {
        if(percentage <= 0) 
            throw new ArgumentException("The percentage must be positive");
        
        MonthlyPay += MonthlyPay * percentage;
    }
    
}
