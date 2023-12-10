using Data.DTO;
using Data.DTO.In;

namespace Services.Domain;

public interface ILeaderboardService
{
    Task<LeaderboardDto?> GetLeaderboard(int year);
    Task<int> PostLeaderboard(CreateLeaderboardDto createLeaderboardDto);
    Task UpdateLeaderboard(int id, CreateLeaderboardDto createLeaderboardDto);
    Task DeleteLeaderboard(int id);
}