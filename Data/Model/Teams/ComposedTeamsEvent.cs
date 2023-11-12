namespace Data.Model;

public class ComposedTeamsEvent : Event
{
    public IEnumerable<ComposedTeam> Teams { get; set; }
    public IEnumerable<TeamCompositionScore> Scores { get; set; }
}