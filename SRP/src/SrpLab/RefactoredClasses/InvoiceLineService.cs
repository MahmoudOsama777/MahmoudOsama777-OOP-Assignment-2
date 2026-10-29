namespace SrpLab.NewClasses;

public class InvoiceLineService
{
    public static string TuitionInvoiceLine(string studentEmail, string courseCode, HashSet<string> seated, decimal tuition)
    {
        // Finance formatting / tax later — separate from enrollment capacity.
        if (!seated.Contains(studentEmail)) return $"{courseCode},WAITLIST,0.00";
        var vat = Math.Round(tuition * 0.14m, 2);
        return $"{courseCode},TUITION,{tuition:0.00},VAT,{vat:0.00},TOTAL,{(tuition + vat):0.00}";
    }
}
