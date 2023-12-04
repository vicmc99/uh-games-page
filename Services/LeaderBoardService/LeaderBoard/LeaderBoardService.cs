using Data.DTO.In.LeaderBoard;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.LeaderBoardService.LeaderBoard;

public class LeaderBoardService:ILeaderBoardService
{
    private readonly IDataRepository _repository;

    public  LeaderBoardService (IDataRepository repository)
    {
        _repository = repository;
    }
    public async void PostLeaderBoardService(CreateLeaderBoardDto createLeaderBoardDto)
    {
        var toSave = new Leaderboard()
        {
            Year = createLeaderBoardDto.Year,
            LeaderboardLines =  _repository.Set<LeaderboardLine>()
                .Where(e=>createLeaderBoardDto.LeaderboardLines.Contains(e.Id)),
               
        };
        
        
        
        await _repository.Set<Leaderboard>().Create(toSave);
        await _repository.Save(default);
    }
}