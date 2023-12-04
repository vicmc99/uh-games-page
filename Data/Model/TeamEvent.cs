namespace Data.Model;

public class TeamEvent : Event
{
    public IEnumerable<TeamEventScore> TeamScores { get; set; }
    public IEnumerable<TeamEventParticipant> TeamParticipants { get; set; }
    public IEnumerable<EventTeamSubstitute> TeamSubstitutes { get; set; }
}