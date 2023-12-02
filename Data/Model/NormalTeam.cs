namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("NormalTeams")]
public class NormalTeam : Team
{
    [ForeignKey("Team")]
    public ICollection<TeamMember> Members { get; set; }
}