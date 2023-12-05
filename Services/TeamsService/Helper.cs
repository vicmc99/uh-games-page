using Data.DTO.In.Teams;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.TeamsService;

internal static class Helper
{
    //This method is used for all classes that inherit from Team to avoid repeating the queries.
    public static Team GetTeam(IDataRepository _repository, CreateTeamDto createTeamDto)
    {
        return new Team
        {
            //
            Name = createTeamDto.Name,
            Faculty = _repository.Set<Faculty>()
                .FirstOrDefault(e => e.Id == createTeamDto.FacultyId)
        };
    }
}