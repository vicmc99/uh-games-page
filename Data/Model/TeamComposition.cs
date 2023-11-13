namespace Data.Model;

public class TeamComposition
{
    public int Id { get; set; }
    public IEnumerable<TeamMember> Participants { get; set; }
}