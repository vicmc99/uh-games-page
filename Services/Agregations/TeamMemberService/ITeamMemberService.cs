using Data.DTO.In.Teams;

namespace Services.Agregations.TeamMemberService;

public interface ITeamMemberService
{
    public void PostTeamMemberService(CreateTeamMemberDto createTeamMemberDto);
}