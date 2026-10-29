namespace SrpLab.NewClasses;

public class AcademicPolicy
{
    public static string Letter(string studentId,decimal average)
    {
        // Academic policy bands change with faculty senate — not with CSV layout.
        if (average >= 90) return "A";
        if (average >= 80) return "B";
        if (average >= 70) return "C";
        if (average >= 60) return "D";
        return "F";
    }

    public static bool MeetsHonorRoll(string studentId, string letter, decimal average)
    {
        // Extra academic rule set embedded beside averaging.
        return average >= 85 && letter is "A" or "B";
    }
}
