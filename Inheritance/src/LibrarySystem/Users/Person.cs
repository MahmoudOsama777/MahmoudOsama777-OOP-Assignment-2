namespace LibrarySystem.Users;

public class Person
{
    private static int _nextId = 1;
    public int PersonId { get; init; }
    public string FullName { get; init; }
    public string PhoneNumber { get; init; }

    protected Person(string fullName, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentNullException("Fullname cannot be empty or null");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentNullException("Phone number cannot be empty or null");

        PersonId = _nextId++;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }
}
