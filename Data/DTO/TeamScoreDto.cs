namespace Data.DTO;

public class TeamScoreDto
{
    public NormalTeamDto Team { get; set; }
    public ScoreDto Score { get; set; }

    public static TeamScoreDto FromEntity(NormalTeamDto team, ScoreDto score)
    {
        return new TeamScoreDto
        {
            Team = team,
            Score = score
        };
    }
}