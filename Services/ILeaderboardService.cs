using Data.DTO;
using Data.DTO.In;

namespace Services.Domain;

public interface ILeaderboardService
{
    public LeaderboardDto Get(int year);
    void Post(CreateLeaderboardDto createLeaderboardDto);
}