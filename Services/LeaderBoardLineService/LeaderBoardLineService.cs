using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

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
        await _repository.Set<LeaderboardLine>().Create(leaderboardLine);
        await _repository.Save(default);
        return leaderboardLine.Id;
    }

    public async Task<LeaderboardLineDto?> GetLeaderboardLine(int id)
    {
        var leaderboardLine = _repository.Set<LeaderboardLine>().FirstOrDefault(l => l.Id == id);
        if (leaderboardLine == null)
            return null;

        var leaderboardLineDto = new LeaderboardLineDto
        {
            Id = leaderboardLine.Id,
            Year = leaderboardLine.Year,
            BronzeMedals = leaderboardLine.BronzeMedals,
            SilverMedals = leaderboardLine.SilverMedals,
            GoldMedals = leaderboardLine.GoldMedals,
            Ranking = leaderboardLine.Ranking,
            FacultyId = leaderboardLine.Faculty.Id
        };

        return leaderboardLineDto;
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
        leaderboardLine.Faculty = _repository.Set<Faculty>().FirstOrDefault(x => x.Id == createLeaderBoardLineDto.FacultyId);

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