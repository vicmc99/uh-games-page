using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class TeamMember
{
    public int Id { get; set; }
    [ForeignKey("Team")]
    public int TeamId { get; set; }
    [NotMapped]
    public Team Team { get; set; }
   
    [ForeignKey("Athlete")]
    public int AthleteId { get; set; }
    public Athlete Athlete { get; set; }
    public string Role { get; set; } // TODO: normalize this to another table
    
}