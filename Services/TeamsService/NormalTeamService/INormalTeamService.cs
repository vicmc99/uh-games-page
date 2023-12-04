using Data.DTO.In.Teams;

namespace Services.Domain.TeamsService.NormalTeamService;

public interface INormalTeamService
{
    public void PostNormalTeamService(CreateNormalTeamDto createNormalTeamDto);
}