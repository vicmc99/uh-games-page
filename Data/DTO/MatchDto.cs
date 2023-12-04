using Data.Model;

namespace Data.DTO;

public class MatchDto
{
    public int Id { get; set; }
    public IEnumerable<TeamParticipantScoreDto> ParticipantScores { get; set; }

    public static MatchDto FromEntity(Match match)
    {
        return new MatchDto
        {
            Id = match.Id,
            ParticipantScores = match.ParticipantScores.Select(TeamParticipantScoreDto.FromEntity)
        };
    }
}