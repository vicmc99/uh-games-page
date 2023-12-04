using Data.DTO.In.Teams;

namespace Services.Domain.TeamsService.TeamService;

public interface ITeamService
{
    public void PostTeamService(CreateTeamDto createTeamDto);
}