namespace PatternsLab.Problems.Builder;

public sealed class CourseRegistration
{
    public string StudentEmail { get; }
    public string CourseCode { get; }
    public string AccessMode { get; }
    public string? GroupCode { get; }
    public string? DiscountCode { get; }
    public bool SendWhatsApp { get; }
    public bool SendEmailWelcome { get; }
    public string? MentorNote { get; }
    public DateOnly? PreferredStart { get; }

    public CourseRegistration(
        string studentEmail,
        string courseCode,
        string accessMode,
        string? groupCode,
        string? discountCode,
        bool sendWhatsApp,
        bool sendEmailWelcome,
        string? mentorNote,
        DateOnly? preferredStart)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

        if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
        GroupCode = groupCode;
        DiscountCode = discountCode;
        SendWhatsApp = sendWhatsApp;
        SendEmailWelcome = sendEmailWelcome;
        MentorNote = mentorNote;
        PreferredStart = preferredStart;
    }

    public override string ToString()
        => $"{StudentEmail} → {CourseCode} [{AccessMode}] group={GroupCode ?? "-"} discount={DiscountCode ?? "-"} wa={SendWhatsApp} mail={SendEmailWelcome}";
}

public sealed class CourseRegistrationBuilder
{
    // Required
    public string StudentEmail { get; }
    public string CourseCode { get; }
    public string AccessMode { get; }


    // Optional
    public string? GroupCode { get; private set; }
    public string? DiscountCode { get; private set; }
    public bool SendWhatsApp { get; private set; }
    public bool SendEmailWelcome { get; private set; }
    public string? MentorNote { get; private set; }
    public DateOnly? PreferredStart { get; private set; }

    public CourseRegistrationBuilder(string studentEmail, string courseCode, string accessMode)
    {
        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
    }

    public CourseRegistrationBuilder WithGroupCode(string groupCode)
    {
        GroupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder WithDiscountCode(string discountCode)
    {
        DiscountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder CanSendWhatsApp(bool canSendWhatsApp)
    {
        SendWhatsApp = canSendWhatsApp;
        return this;
    }

    public CourseRegistrationBuilder CanSendEmail(bool canSendEmail)
    {
        SendEmailWelcome = canSendEmail;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string mentorNote)
    {
        MentorNote = mentorNote;
        return this;
    }

    public CourseRegistrationBuilder OnStart(DateOnly preferedStart)
    {
        PreferredStart = preferedStart;
        return this;
    }

    public CourseRegistration Build()
    {
        return new CourseRegistration(StudentEmail, CourseCode, AccessMode, GroupCode,
            DiscountCode, SendWhatsApp, SendEmailWelcome, MentorNote, PreferredStart);
    }
}

public static class RegistrationCallSites
{
    public static CourseRegistration CreateLiveStudentUgly()
    {
        return new CourseRegistration(
            "sara@mail.com",
            "SEF-101",
            "LiveGroup",
            "G1",
            "EARLY10",
            true,
            true,
            "Needs evening slot",
            new DateOnly(2026, 10, 1));
    }

    public static CourseRegistration CreateLiveStudent()
    {
        return new CourseRegistrationBuilder(
            "sara@mail.com",
            "SEF-101",
            "LiveGroup")
            .WithGroupCode("G1")
            .WithDiscountCode("EARLY10")
            .CanSendWhatsApp(true)
            .CanSendEmail(true)
            .WithMentorNote("Needs evening slot")
            .OnStart(new DateOnly(2026, 10, 1))
            .Build();
    }

    public static CourseRegistration CreateVideosOnlyUgly()
    {
        return new CourseRegistration(
            "ali@mail.com",
            "SEF-101",
            "VideosOnly",
            null,
            null,
            false,
            true,
            null,
            null);
    }

    public static CourseRegistration CreateVideosOnly()
    {
        return new CourseRegistrationBuilder(
            "ali@mail.com",
            "SEF-101",
            "VideosOnly")
            .CanSendEmail(true)
            .Build();
    }
}
