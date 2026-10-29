namespace LibrarySystem.Common;

public class LibraryPolicy
{
    private static readonly Lazy<LibraryPolicy> _instance = new(() => new LibraryPolicy());

    public static LibraryPolicy Instance => _instance.Value;

    private LibraryPolicy() { }

    public int MaxStudentItemOnLoan { get; set; } = 3;
    public int MaxPremiumMemberItemOnLoan { get; set; } = 10;


    public decimal HeadLibrarianAllowance { get; set; } = 400;

    public int PremiumMemberReadingPointsPerReturn { get; set; } = 5;

    public int BookLoanPeriod { get; set; } = 21;
    public int DVDLoanPeriod { get; set; } = 7;
    public int MagazineLoanPeriod { get; set; } = 3;

    public decimal BookChargesFee { get; set; } = 1;
    public decimal DVDChargesFee { get; set; } = 2;
    public decimal MagazineChargesFee { get; set; } = 0.5m;
}
