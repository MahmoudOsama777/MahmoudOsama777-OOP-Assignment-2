using LibrarySystem.Common;

namespace LibrarySystem.Items;

public class DVD : LibraryItem
{
    public DVD(string title, decimal baseLateFee)
        : base("DVD-" + Guid.NewGuid().ToString(), title, baseLateFee, LibraryPolicy.Instance.DVDLoanPeriod,
            LibraryPolicy.Instance.DVDChargesFee) { }
}
