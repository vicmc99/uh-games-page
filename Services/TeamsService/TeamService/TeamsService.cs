using Data.DTO.In.Teams;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.TeamsService.TeamService;

public class TeamsService:ITeamService
{
    private readonly IDataRepository _repository;

    public TeamsService(IDataRepository repository)
    {
        _repository = repository;
    }
    public  async void PostTeamService(CreateTeamDto createTeamDto)
    {
        var team = Helper.GetTeam(_repository, createTeamDto);
        
        await _repository.Set<Team>().Create(team);
        await _repository.Save(default);
    }
}