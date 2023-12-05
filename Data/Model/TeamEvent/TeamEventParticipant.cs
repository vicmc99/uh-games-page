namespace Data.Model;

public class TeamEventParticipant
{
    public int TeamId { get; set; }

    public NormalTeam Team { get; set; }

    public int EventId { get; set; }

    public TeamEvent Event { get; set; }

    public int ParticipantId { get; set; }
    public TeamMember Participant { get; set; }
}