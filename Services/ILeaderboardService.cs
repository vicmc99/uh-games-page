using Data.DTO;

namespace Services.Domain;

public interface ILeaderboardService
{
    public LeaderboardDto Get(int year);
}