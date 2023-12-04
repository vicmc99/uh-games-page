using Data.Model;

namespace Data.DTO;

public class TeamCompositionScoreDto
{
    public int CompositionId { get; set; }
    public ScoreDto Score { get; set; }

    public static TeamCompositionScoreDto FromEntity(TeamCompositionScore entity)
    {
        return new TeamCompositionScoreDto
        {
            CompositionId = entity.CompositionId,
            Score = ScoreDto.FromEntity(entity.Score)
        };
    }
}