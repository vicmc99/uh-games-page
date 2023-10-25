namespace Data.Model;

public class EventTeamParticipant
{
    public int TeamId { get; set; }
    public NormalTeam Team { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }
    public int ParticipantId { get; set; }
    public TeamMember Participant { get; set; }
}