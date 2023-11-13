namespace Data.Model;

public class ComposedTeamsEvent : Event
{
    public IEnumerable<ComposedTeam> ComposedTeams { get; set; }
    public IEnumerable<TeamCompositionScore> ComposedTeamScores { get; set; }
}