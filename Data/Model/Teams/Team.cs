using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Model;

[Table("Teams")]
public class Team
{
    
    public int Id { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}