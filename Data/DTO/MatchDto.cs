namespace Data.DTO;

public class MatchDto
{
    public int Id { get; set; }
    public IEnumerable<TeamParticipantScoreDto> ParticipantScores { get; set; }
}