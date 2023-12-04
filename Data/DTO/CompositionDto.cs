using Data.Model;

namespace Data.DTO;

public class CompositionDto
{
    public int Id { get; set; }
    public IEnumerable<TeamMemberDto> Participants { get; set; }

    public static CompositionDto FromEntity(TeamComposition composition)
    {
        return new CompositionDto
        {
            Id = composition.Id,
            Participants = composition.Participants.Select(TeamMemberDto.FromEntity)
        };
    }
}