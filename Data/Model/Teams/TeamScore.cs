namespace Data.Model;

public class TeamScore
{
    public Score Score { get; set; }
    public int ScoreId { get; set; }
    public NormalTeam Team { get; set; }
    public int TeamId { get; set; }
}