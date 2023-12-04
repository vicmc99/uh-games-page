namespace Data.Model;

public class EventTeamSubstitute
{
    public int TeamId { get; set; }

    public NormalTeam Team { get; set; }

    public int EventId { get; set; }

    public TeamEvent Event { get; set; }

    public int SubstituteId { get; set; }
    public TeamMember Substitute { get; set; }
}