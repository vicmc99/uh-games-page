namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class NormalTeam : Team
{
    public ICollection<TeamMember> Members { get; set; }
}