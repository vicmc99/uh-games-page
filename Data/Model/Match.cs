namespace Data.Model;

public class Match
{
    public int MatchId { get; set; }
    public IEnumerable<TeamParticipantScore> ParticipantScores { get; set; }
}