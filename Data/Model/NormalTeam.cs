namespace Data.Model;

public class NormalTeam : Team
{
    public ICollection<TeamMember> Members { get; set; }
}