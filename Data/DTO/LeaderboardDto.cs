using Data.Model;

namespace Data.DTO;

public class LeaderboardDto
{
    public int Id { get; set; }
    public int Year { get; set; }
    public IEnumerable<LeaderboardLineDto> LeaderboardLines { get; set; }

    public static LeaderboardDto FromEntity(Leaderboard leaderboard)
    {
        return new LeaderboardDto
        {
            Id = leaderboard.Id,
            Year = leaderboard.Year,
            LeaderboardLines = leaderboard.LeaderboardLines.Select(LeaderboardLineDto.FromEntity)
        };
    }
}