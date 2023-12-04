using Data.Model;

namespace Data.DTO;

public class ComposedTeamDto : TeamDto
{
    public IEnumerable<CompositionDto> Compositions { get; set; }

    public static ComposedTeamDto FromEntity(ComposedTeam team)
    {
        return new ComposedTeamDto
        {
            Compositions = team.Compositions.Select(CompositionDto.FromEntity)
        };
    }
}