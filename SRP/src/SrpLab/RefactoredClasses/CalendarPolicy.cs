namespace SrpLab.NewClasses;

public class CalendarPolicy
{
    public static bool IsWithinBusinessHours(TimeOnly open, TimeOnly close, int slotMinutes, DateTimeOffset when)
    {
        // Clinic calendar policy — HR/ops — not the same as ICS serialization.
        if (when.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday) return false;
        var t = TimeOnly.FromDateTime(when.DateTime);
        return t >= open && t.AddMinutes(slotMinutes) <= close;
    }

    public static string ToIcs(DateTimeOffset slot, string patientName, string clinician,int slotMinutes)
    {
        // Calendar interoperability format changes with clients — not opening hours.
        var uid = Guid.NewGuid();
        var end = slot.AddMinutes(slotMinutes);
        return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
               $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
    }
}
