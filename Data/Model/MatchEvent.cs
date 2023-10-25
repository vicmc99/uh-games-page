namespace Data.Model;

public class MatchEvent : Event
{
    public IEnumerable<NormalTeam> Teams { get; set; }
    public IEnumerable<Match> Matches { get; set; }
}