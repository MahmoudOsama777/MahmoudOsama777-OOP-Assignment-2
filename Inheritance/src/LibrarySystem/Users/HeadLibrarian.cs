using LibrarySystem.Common;
using LibrarySystem.Items;

namespace LibrarySystem.Users;

public class HeadLibrarian : Staff
{
    public HeadLibrarian(string fullName, string phoneNumber)
        : base(fullName, phoneNumber, LibraryPolicy.Instance.HeadLibrarianAllowance) { }

    public void ChangeItemLateFee(LibraryItem item,decimal lateFee)
    {
        item.ChangeLateFee(lateFee);
    }

    public void RestoreItem(LibraryItem item)
    {
        item.Restore();
    }

    public void WithdrawItem(LibraryItem item)
    {
        item.Withdraw();
    }

}
