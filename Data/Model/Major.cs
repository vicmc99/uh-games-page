using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Model;

[Index(nameof(Name), IsUnique = true)]
public class Major
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
//TODO:{Name,FacultyId} is unique??
    public string Name { get; set; }
    public int Years { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}