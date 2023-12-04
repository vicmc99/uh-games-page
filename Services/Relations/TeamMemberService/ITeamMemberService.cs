using Data.DTO.In.Teams;

namespace Services.Relations.TeamMemberService;

public interface ITeamMemberService
{
    public void PostTeamMemberService(CreateTeamMemberDto createTeamMemberDto);
}