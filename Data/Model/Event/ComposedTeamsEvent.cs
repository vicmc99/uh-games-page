using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

[Table("ComposedTeamsEvents")]
public class ComposedTeamsEvent : Event
{
    
    [ForeignKey("Event")]
    public int EventId { get; set; }
    
    public Event Event { get; set; }
    
    
    public IEnumerable<ComposedTeam> ComposedTeams { get; set; }
    public IEnumerable<TeamCompositionScore> ComposedTeamScores { get; set; }
}