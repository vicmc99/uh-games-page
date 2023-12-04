namespace Data.Model;

public class MatchEvent : Event
{
    public IEnumerable<NormalTeam> MatchedTeams { get; set; }
    public IEnumerable<Match> Matches { get; set; }
}