using Data.DTO.In.LeaderBoard;

namespace Services.Domain.LeaderBoardService.LeaderBoardLineService;

public interface ILeaderboardLineService
{
    public void PostLeaderboardLineService(CreateLeaderboardLineDto createLeaderboardLineDto);
}