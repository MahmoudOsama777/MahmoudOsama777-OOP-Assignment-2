namespace SrpLab.NewClasses;

public class WelcomeMarkdownService
{
    public static string WelcomePacketMarkdown(string studentEmail, string studentName,string courseCode,bool isContains,int waitlistPosition)
    {
        // Content design changes with academy marketing — not with seat algorithms.
        var status = isContains ? "confirmed seat" : $"waitlist #{waitlistPosition}";
        return $"# Welcome to {courseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}
