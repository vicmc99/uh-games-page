using Data.DTO.In.Compositions;

namespace Services.Domain.CompositionsService.TeamCompositionService;

public interface ITeamCompositionService
{
    public void PostTeamCompositionService(CreateTeamCompositonDto createTeamCompositionDto);
}

