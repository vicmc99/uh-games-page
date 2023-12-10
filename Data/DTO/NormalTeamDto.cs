using Data.Model;

namespace Data.DTO;

public class NormalTeamDto : TeamDto
{
    public IEnumerable<TeamMemberDto> Members { get; set; }

    // Changes in a per-event basis.
    public IEnumerable<TeamMemberDto> Participants { get; set; }
    public IEnumerable<TeamMemberDto> Substitutes { get; set; }

    public static NormalTeamDto FromEntity(IEnumerable<TeamMember> members,
        IEnumerable<TeamMember> participants,
        IEnumerable<TeamMember> substitutes,
        int id, int facultyId)
    {
        return new NormalTeamDto
        {
            Id = id,
            FacultyId = facultyId,
            Members = members?.Select(TeamMemberDto.FromEntity),
            Participants = participants?.Select(TeamMemberDto.FromEntity),
            Substitutes = substitutes?.Select(TeamMemberDto.FromEntity)
        };
    }
}