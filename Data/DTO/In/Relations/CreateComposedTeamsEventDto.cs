namespace Data.DTO.In.Relations;

public class CreateComposedTeamsEventDto
{
    
    public IEnumerable<int> ComposedTeams { get; set; }
    public IEnumerable<int> ComposedTeamScores { get; set; }
}