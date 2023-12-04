namespace Data.Model;

public class TeamEvent : Event
{
    public IEnumerable<TeamEventScore> TeamScores { get; set; }
    public IEnumerable<EventTeamParticipant> TeamParticipants { get; set; }
    public IEnumerable<EventTeamParticipant> TeamSubstitutes { get; set; }
}