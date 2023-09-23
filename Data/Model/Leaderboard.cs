namespace Data.Model;

public class Leaderboard
{
    public int Id { get; set; }
    public int Year { get; set; }
    public ICollection<LeaderboardLine> LeaderboardLines { get; set; }
}