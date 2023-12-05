using Data.DTO.In.Teams;
using Data.Model;
using DataAccess.Repository;

namespace Services.Agregations.TeamMemberService;

public class TeamMemberService : ITeamMemberService
{
    private readonly IDataRepository _repository;

    public TeamMemberService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async void PostTeamMemberService(CreateTeamMemberDto createTeamMemberDto)
    {
        var athlete = _repository.Set<Athlete>()
            .FirstOrDefault(e => e.Id == createTeamMemberDto.AthleteId);
        var team = _repository.Set<Team>()
            .FirstOrDefault(e => e.Id == createTeamMemberDto.TeamId);
        var teamMember = new TeamMember
        {
            Role = createTeamMemberDto.Role,
            Athlete = athlete,
            Team = team,
            AthleteId = createTeamMemberDto.AthleteId,
            TeamId = createTeamMemberDto.TeamId
        };
        await _repository.Set<TeamMember>().Create(teamMember);
        await _repository.Save(default);
    }
}