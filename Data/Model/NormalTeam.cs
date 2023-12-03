namespace Data.Model;

public class NormalTeam : Team
{
    public IEnumerable<TeamMember> Members { get; set; }
}