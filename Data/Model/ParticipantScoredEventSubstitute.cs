namespace Data.Model;

public class ParticipantScoredEventSubstitute
{
    public int TeamId { get; set; }

    public NormalTeam Team { get; set; }

    public int EventId { get; set; }

    public ParticipantScoredEvent Event { get; set; }

    public int SubstituteId { get; set; }
    public TeamMember Substitute { get; set; }
}