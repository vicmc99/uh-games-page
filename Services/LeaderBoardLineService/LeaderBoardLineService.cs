using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.LeaderBoardLineService;

public class LeaderBoardLineService:ILeaderBoardLineService
{
    private readonly IDataRepository _repository;

    public LeaderBoardLineService(IDataRepository repository)
    {
        _repository = repository;
    }
    public async void PostLeaderBoardLine(CreateLeaderBoardLineDto createLeaderBoardLineDto)
    {
        var r = new LeaderboardLine()
        {
            Year = createLeaderBoardLineDto.Year,
            BronzeMedals = createLeaderBoardLineDto.Year,
            GoldMedals = createLeaderBoardLineDto.GoldMedals,
            SilverMedals = createLeaderBoardLineDto.SilverMedals,
            Ranking = createLeaderBoardLineDto.Ranking,
            Faculty = _repository.Set<Faculty>().FirstOrDefault(x => x.Id == createLeaderBoardLineDto.FacultyId)
        };
      await   _repository.Set<LeaderboardLine>().Create(r);
      await  _repository.Save(default);
    }
}