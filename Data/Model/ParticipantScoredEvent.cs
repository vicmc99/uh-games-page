namespace Data.Model;

public class ParticipantScoredEvent : Event
{
    public IEnumerable<NormalTeam> Teams { get; set; }
    public IEnumerable<TeamParticipantScore> ParticipantScores { get; set; }
    public IEnumerable<EventTeamParticipant> TeamSubstitutes { get; set; }
}