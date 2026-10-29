namespace SrpLab.NewClasses;

public class LetterService
{
    public static string DecisionLetter(string applicantName, LoanDesk loanDesk)
    {
        // Legal/comms wording ≠ underwriting math.
        if (loanDesk.IsEligible())
        {
            return $"Dear {applicantName},\nYour request for {loanDesk.RequestedAmount:C} is pre-approved (risk {loanDesk.RiskScore():0}).\n" +
                   $"Please upload: {string.Join("; ", DocumentationService.RequiredDeskDocuments(loanDesk))}.\n";
        }

        return $"Dear {applicantName},\nWe are unable to approve {loanDesk.RequestedAmount:C} at this time.\n" +
               $"Reference risk={loanDesk.RiskScore():0}. You may reapply after improving documentation.\n";
    }

    public static string DraftPublicReply(string agentName ,string id, string priority, DateTimeOffset slaDeadline)
    {
        // Tone/templates owned by CX — not by SLA engineering.
        var apology = priority == "P1" ? "We are treating this as a critical incident." : "Thanks for reaching out.";
        return $"Hi,\n{apology}\nTicket {id} is with {agentName}. Next update before {slaDeadline:u}.\n";
    }
}
