namespace Data.DTO;

public class CompositionDto
{
    public int Id { get; set; }
    public IEnumerable<TeamMemberDto> Participant { get; set; }
}