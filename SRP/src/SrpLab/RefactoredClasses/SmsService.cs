namespace SrpLab.NewClasses;

public class SmsService
{
    public static string SmsReminder(DateTimeOffset slot, string clinicPhone)
    {
        // Messaging channel copy — fourth concern hiding in the "scheduler".
        return $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
    }
}
