using LibrarySystem.Common;

namespace LibrarySystem.Users;

public class PremiumMember : Member
{
    public int ReadingPoints => 
        Loans.Count(s => s.Status == LoanStatus.Returned) 
        * LibraryPolicy.Instance.PremiumMemberReadingPointsPerReturn;

    public PremiumMember(string fullName, string phoneNumber, decimal discount)
        : base(fullName, phoneNumber, LibraryPolicy.Instance.MaxPremiumMemberItemOnLoan, discount) { }
}
