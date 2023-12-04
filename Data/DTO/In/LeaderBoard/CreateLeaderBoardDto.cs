namespace Data.DTO.In.LeaderBoard;

public class CreateLeaderBoardDto
{
    public int Year { get; set; }
    public ICollection<int> LeaderboardLines { get; set; }
}