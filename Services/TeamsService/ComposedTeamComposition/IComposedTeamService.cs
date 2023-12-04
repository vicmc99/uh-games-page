using Data.DTO.In.Teams;

namespace Services.Domain.TeamsService.ComposedTeamComposition;

public interface IComposedTeamService

{
    public void PostComposedTeamService(CreateComposedTeamDto createComposedTeamDto);
}