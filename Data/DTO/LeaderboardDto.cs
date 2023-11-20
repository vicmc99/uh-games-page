namespace Data.DTO;

public class LeaderboardDto
{
    public int Id { get; set; }
    public int Year { get; set; }
    public ICollection<LeaderboardLineDto> LeaderboardLines { get; set; }
}