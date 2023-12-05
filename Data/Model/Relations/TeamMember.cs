using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class TeamMember
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }
    public int AthleteId { get; set; }
    public Athlete Athlete { get; set; }
    public string Role { get; set; }
}