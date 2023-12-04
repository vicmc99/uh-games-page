using Data.DTO.In.LeaderBoard;

namespace Services.Domain.LeaderBoardService.LeaderBoard;

public interface ILeaderBoardService
{
    public void PostLeaderBoardService(CreateLeaderBoardDto createLeaderBoardDto);
}