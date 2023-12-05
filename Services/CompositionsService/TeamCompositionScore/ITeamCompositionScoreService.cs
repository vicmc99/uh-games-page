using Data.DTO.In.Compositions;

namespace Services.Domain.CompositionsService.TeamCompositionScore;

public interface ITeamCompositionScoreService
{
    public void PostTeamCompositionScoreService(CreateTeamCompositionScoreDto createTeamCompositionScoreDto);
}