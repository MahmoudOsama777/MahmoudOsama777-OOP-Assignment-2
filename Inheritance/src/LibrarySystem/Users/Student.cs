using LibrarySystem.Common;

namespace LibrarySystem.Users;

public class Student : Member
{
    public Student(string fullName, string phoneNumber)
        : base(fullName, phoneNumber, LibraryPolicy.Instance.MaxStudentItemOnLoan, 0) { }
}
