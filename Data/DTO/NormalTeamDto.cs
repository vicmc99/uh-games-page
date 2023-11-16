namespace Data.DTO;

public class NormalTeamDto : TeamDto
{
    public IEnumerable<TeamMemberDto> Members { get; set; }

    // Changes in a per-event basis.
    public IEnumerable<TeamMemberDto> Participants { get; set; }
    public IEnumerable<TeamMemberDto> Substitutes { get; set; }
}