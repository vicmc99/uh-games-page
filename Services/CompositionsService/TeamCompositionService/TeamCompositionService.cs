using Data.DTO.In.Compositions;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.CompositionsService.TeamCompositionService;

public class TeamCompositionService : ITeamCompositionService
{
    private readonly IDataRepository _repository;

    public TeamCompositionService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async void PostTeamCompositionService(CreateTeamCompositonDto createTeamCompositionDto)
    {
        var newTeamComposition = new TeamComposition
        {
            Participants = _repository.Set<TeamMember>()
                .Where(e => createTeamCompositionDto.TeamMemberParticipants.Contains(e.Id))
        };
        await _repository.Set<TeamComposition>().Create(newTeamComposition);
        await _repository.Save(default);
    }
}