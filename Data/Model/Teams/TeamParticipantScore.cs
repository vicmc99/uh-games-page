using System.ComponentModel.DataAnnotations;

namespace Data.Model;

public class TeamParticipantScore
{
    public int EventId { get; set; }
    [Key] public int TeamId { get; set; }

    public int ParticipantId { get; set; }
    public int ScoreId { get; set; }
    public EventTeamParticipant Participant { get; set; }
    public Score Score { get; set; }
}