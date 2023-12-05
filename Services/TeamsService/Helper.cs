using Data.DTO.In.Teams;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.TeamsService;

internal static class Helper
{
    public static Team GetTeam(IDataRepository _repository, CreateTeamDto createTeamDto)
    {
        return new Team
        {
            Name = createTeamDto.Name,
            Faculty = _repository.Set<Faculty>()
                .FirstOrDefault(e => e.Id == createTeamDto.FacultyId)
        };
    }
}