using LibrarySystem.Common;

namespace LibrarySystem.Items;

public class Magazine : LibraryItem
{
    public Magazine(string title, decimal baseLateFee)
        : base("MG-" + Guid.NewGuid().ToString(), title, baseLateFee, LibraryPolicy.Instance.MagazineLoanPeriod,
            LibraryPolicy.Instance.MagazineChargesFee) { }
}