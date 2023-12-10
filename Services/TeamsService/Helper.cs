using Data.DTO.In.Teams;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.TeamsService;

internal static class Helper
{
    //This method is used for all classes that inherit from Team to avoid repeating the queries.
    public static Team GetTeam(IDataRepository repository, CreateTeamDto createTeamDto)
    {
        return new Team
        {
            //
            Name = createTeamDto.Name,
            Faculty = repository.Set<Faculty>()
                .FirstOrDefault(e => e.Id == createTeamDto.FacultyId)
        };
    }
}