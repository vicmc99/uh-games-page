namespace Data.Model;

public class ComposedTeam : Team
{

    public IEnumerable<TeamComposition> Compositions { get; set; }
}