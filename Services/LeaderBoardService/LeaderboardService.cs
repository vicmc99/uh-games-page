using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services.Domain;

public class LeaderboardService : ILeaderboardService
{
    private readonly IDataRepository _repository;

    public LeaderboardService(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<LeaderboardDto?> GetLeaderboard(int id)
    {
        var leaderboard = _repository.Set<Leaderboard>().Include(l => l.LeaderboardLines)
            .FirstOrDefault(l => l.Id == id);
        if (leaderboard is null)
            return Task.FromResult<LeaderboardDto?>(null);

        var leaderboardDto = new LeaderboardDto
        {
            Id = leaderboard.Id,
            Year = leaderboard.Year,
            LeaderboardLines = leaderboard.LeaderboardLines.Select(LeaderboardLineDto.FromEntity)
        };

        return Task.FromResult<LeaderboardDto?>(leaderboardDto);
    }

    public async Task<int> PostLeaderboard(CreateLeaderboardDto createLeaderboardDto)
    {
        var newLeaderboard = new Leaderboard
        {
            Year = createLeaderboardDto.Year,
            LeaderboardLines = new List<LeaderboardLine>()
        };

        await _repository.Set<Leaderboard>().Create(newLeaderboard);
        await _repository.Save(default);

        return newLeaderboard.Id;
    }

    public Task UpdateLeaderboard(int id, CreateLeaderboardDto createLeaderboardDto)
    {
        var leaderboard = _repository.Set<Leaderboard>().FirstOrDefault(l => l.Id == id);
        if (leaderboard == null) return Task.CompletedTask;

        leaderboard.Year = createLeaderboardDto.Year;

        _repository.Set<Leaderboard>().Update(leaderboard);
        return _repository.Save(default);
    }

    public Task DeleteLeaderboard(int id)
    {
        var leaderboard = _repository.Set<Leaderboard>().FirstOrDefault(l => l.Id == id);
        if (leaderboard == null) return Task.CompletedTask;

        _repository.Set<Leaderboard>().Remove(leaderboard);
        return _repository.Save(default);
    }
}