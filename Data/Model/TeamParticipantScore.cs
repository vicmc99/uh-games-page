namespace Data.Model;

public class TeamParticipantScore
{
    public int EventId { get; set; }
    public ParticipantScoredEvent Event { get; set; }
    public int TeamId { get; set; }
    public NormalTeam Team { get; set; }
    public int ParticipantId { get; set; }
    public TeamMember Participant { get; set; }
    public int ScoreId { get; set; }
    public Score Score { get; set; }
}