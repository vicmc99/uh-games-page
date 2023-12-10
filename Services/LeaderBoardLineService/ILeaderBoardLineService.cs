using Data.DTO;
using Data.DTO.In;

namespace Services.LeaderBoardLineService;

public interface ILeaderBoardLineService
{
    Task<int> PostLeaderboardLine(CreateLeaderBoardLineDto createLeaderBoardLineDto);
    Task<LeaderboardLineDto?> GetLeaderboardLine(int id);
    Task UpdateLeaderboardLine(int id, CreateLeaderBoardLineDto createLeaderBoardLineDto);
    Task DeleteLeaderboardLine(int id);
}