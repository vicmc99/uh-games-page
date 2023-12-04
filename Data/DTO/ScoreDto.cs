using Data.Model;

namespace Data.DTO;

public class ScoreDto
{
    public int Id { get; set; }
    public float NumberScore { get; set; }

    public static ScoreDto FromEntity(Score s)
    {
        return new ScoreDto
        {
            Id = s.Id,
            NumberScore = s.NumberScore
        };
    }
}