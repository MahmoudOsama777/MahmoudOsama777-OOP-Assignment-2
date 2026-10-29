namespace LibrarySystem.Users;

public class Shelver : Staff
{
    public string Section { get; private set; }

    public Shelver(string fullName, string phoneNumber, decimal monthlyPay, string section)
    : base(fullName, phoneNumber, monthlyPay)
    {
        Section = section;
    }

    public void Reassign(string section)
    {
        if (string.IsNullOrWhiteSpace(section))
            throw new ArgumentNullException("Section cannot be empty or null");

        Section = section;
    }
}