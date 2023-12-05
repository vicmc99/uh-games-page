using Data.DTO.In.Teams;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.TeamsService.NormalTeamService;

public class NormalTeamService : INormalTeamService
{
    private readonly IDataRepository _repository;

    public NormalTeamService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async void PostNormalTeamService(CreateNormalTeamDto createNormalTeamDto)
    {
            var temp= Helper.GetTeam(_repository, createNormalTeamDto);
        var normalTeam = new NormalTeam()
        {
            Name = temp.Name,
            Faculty = temp.Faculty,
            Members = _repository.Set<TeamMember>()
                .Where(e => createNormalTeamDto.Members.Contains(e.Id)),
        };
        await _repository.Set<NormalTeam>().Create(normalTeam);
        await _repository.Save(default);
    }
    
}