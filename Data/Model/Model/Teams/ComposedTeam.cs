using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
[Table("ComposedTeams")]
public class ComposedTeam : Team
{
    [ForeignKey("Team")]
   public int TeamId { get; set; }
    
    public IEnumerable<TeamComposition> Compositions { get; set; }
}