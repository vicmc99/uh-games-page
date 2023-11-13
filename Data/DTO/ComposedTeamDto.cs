namespace Data.DTO;

public class ComposedTeamDto : TeamDto
{
    public IEnumerable<CompositionDto> Compositions { get; set; }
}