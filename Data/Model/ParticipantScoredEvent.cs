namespace Data.Model;

public class ParticipantScoredEvent : Event
{
    public IEnumerable<NormalTeam> ParticipantScoredTeams { get; set; }
    public IEnumerable<TeamParticipantScore> ParticipantScores { get; set; }
    public IEnumerable<ParticipantScoredEventSubstitute> TeamSubstitutes { get; set; }
}