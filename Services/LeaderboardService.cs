using Data.DTO;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain;

public class LeaderboardService
{
    private readonly IDataRepository repository;

    public LeaderboardService(IDataRepository repository)
    {
        this.repository = repository;
    }

    public LeaderboardDto Get(int year)
    {
        var leaderboard = repository.Set<Leaderboard>().FirstOrDefault(l => l.Year == year);
        if (leaderboard is null)
            return null;
        return new LeaderboardDto
        {
            Id = leaderboard.Id,
            Year = leaderboard.Year,
            LeaderboardLines = leaderboard.LeaderboardLines.Select(
                l => new LeaderboardLineDto
                {
                    Id = l.Id,
                    Year = l.Year,
                    BronzeMedals = l.BronzeMedals,
                    SilverMedals = l.SilverMedals,
                    GoldMedals = l.GoldMedals,
                    Ranking = l.Ranking,
                    FacultyId = l.FacultyId
                }).ToList()
        };
    }
}