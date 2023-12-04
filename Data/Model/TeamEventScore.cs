namespace Data.Model;

public class TeamEventScore
{
    public TeamEvent Event { get; set; }
    public int EventId { get; set; }
    public Score Score { get; set; }
    public int ScoreId { get; set; }
    public NormalTeam Team { get; set; }
    public int TeamId { get; set; }
}