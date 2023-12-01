namespace Data.DTO;

public class CompositionDto
{
    public int Id { get; set; }
    public IEnumerable<TeamMemberDto> Participants { get; set; }
}