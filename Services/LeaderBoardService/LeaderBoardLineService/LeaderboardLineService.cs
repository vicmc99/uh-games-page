using Data.DTO.In.LeaderBoard;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.LeaderBoardService.LeaderBoardLineService;

public class LeaderboardLineService:ILeaderboardLineService
{
    private readonly IDataRepository _repository;

    public LeaderboardLineService(IDataRepository repository)=>        _repository = repository;

    

    public async void PostLeaderboardLineService(CreateLeaderboardLineDto createLeaderboardLineDto)
    {
        var toSave = new LeaderboardLine()
        {
            GoldMedals = createLeaderboardLineDto.GoldMedals,
            SilverMedals = createLeaderboardLineDto.SilverMedals,
            BronzeMedals = createLeaderboardLineDto.BronzeMedals,
            Ranking = createLeaderboardLineDto.Ranking,
            Year = createLeaderboardLineDto.Year,
            Faculty = _repository.Set<Faculty>()
                .FirstOrDefault(e => e.Id == createLeaderboardLineDto.FacultyId)
        };

        await _repository.Set<LeaderboardLine>().Create(toSave);
        await _repository.Save(default);
    }
}