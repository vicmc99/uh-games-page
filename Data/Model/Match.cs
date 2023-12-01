namespace Data.Model;

public class Match
{
    public int Id { get; set; }
    public IEnumerable<TeamParticipantScore> ParticipantScores { get; set; }
}