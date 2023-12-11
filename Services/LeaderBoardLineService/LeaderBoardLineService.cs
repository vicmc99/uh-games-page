using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services.LeaderBoardLineService;

public class LeaderBoardLineService : ILeaderBoardLineService
{
    private readonly IDataRepository _repository;

    public LeaderBoardLineService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> PostLeaderboardLine(CreateLeaderBoardLineDto createLeaderBoardLineDto)
    {
        var leaderboardLine = new LeaderboardLine
        {
            Year = createLeaderBoardLineDto.Year,
            BronzeMedals = createLeaderBoardLineDto.Year,
            GoldMedals = createLeaderBoardLineDto.GoldMedals,
            SilverMedals = createLeaderBoardLineDto.SilverMedals,
            Ranking = createLeaderBoardLineDto.Ranking,
            Faculty = _repository.Set<Faculty>().FirstOrDefault(x => x.Id == createLeaderBoardLineDto.FacultyId)
        };
        var leaderboard = _repository.Set<Leaderboard>().Include(l => l.LeaderboardLines)
            .FirstOrDefault(l => l.Year == createLeaderBoardLineDto.Year);
        leaderboard.LeaderboardLines.Add(leaderboardLine);
        await _repository.Set<LeaderboardLine>().Create(leaderboardLine);
        await _repository.Save(default);
        return leaderboardLine.Id;
    }

    public Task<LeaderboardLineDto?> GetLeaderboardLine(int id)
    {
        var leaderboardLine = _repository.Set<LeaderboardLine>().FirstOrDefault(l => l.Id == id);
        return leaderboardLine == null
            ? Task.FromResult<LeaderboardLineDto?>(null)
            : Task.FromResult<LeaderboardLineDto?>(LeaderboardLineDto.FromEntity(leaderboardLine));
    }

    public Task UpdateLeaderboardLine(int id, CreateLeaderBoardLineDto createLeaderBoardLineDto)
    {
        var leaderboardLine = _repository.Set<LeaderboardLine>().FirstOrDefault(l => l.Id == id);
        if (leaderboardLine == null) return Task.CompletedTask;

        leaderboardLine.Year = createLeaderBoardLineDto.Year;
        leaderboardLine.BronzeMedals = createLeaderBoardLineDto.BronzeMedals;
        leaderboardLine.SilverMedals = createLeaderBoardLineDto.SilverMedals;
        leaderboardLine.GoldMedals = createLeaderBoardLineDto.GoldMedals;
        leaderboardLine.Ranking = createLeaderBoardLineDto.Ranking;
        leaderboardLine.Faculty =
            _repository.Set<Faculty>().FirstOrDefault(x => x.Id == createLeaderBoardLineDto.FacultyId);

        _repository.Set<LeaderboardLine>().Update(leaderboardLine);
        return _repository.Save(default);
    }

    public Task DeleteLeaderboardLine(int id)
    {
        var leaderboardLine = _repository.Set<LeaderboardLine>().FirstOrDefault(l => l.Id == id);
        if (leaderboardLine == null) return Task.CompletedTask;

        _repository.Set<LeaderboardLine>().Remove(leaderboardLine);
        return _repository.Save(default);
    }
}