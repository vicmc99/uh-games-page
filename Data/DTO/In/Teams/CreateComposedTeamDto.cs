namespace Data.DTO.In.Teams;

public class CreateComposedTeamDto:CreateTeamDto
{
    public IEnumerable<int>Compositions { get; set; }
}