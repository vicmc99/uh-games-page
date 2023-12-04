using Data.DTO.In.Teams;
using Data.Model;
using DataAccess.Repository;

namespace Services.Relations.TeamMemberService;

public class TeamMemberService:ITeamMemberService
{
    private readonly IDataRepository _repository;

    public TeamMemberService(IDataRepository repository)
    {
        _repository = repository;
    }
    public async void PostTeamMemberService(CreateTeamMemberDto createTeamMemberDto)
    {
        var teamMember = new TeamMember()
        {
            Role = createTeamMemberDto.Role,
            Athlete = _repository.Set<Athlete>()
                .FirstOrDefault(e => e.Id == createTeamMemberDto.AthleteId),
            Team = _repository.Set<Team>()
                .FirstOrDefault(e => e.Id == createTeamMemberDto.TeamId)
        };
       await _repository.Set<TeamMember>().Create(teamMember);
       await  _repository.Save(default);
    }
}