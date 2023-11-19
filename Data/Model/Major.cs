namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Index(nameof(Name),IsUnique=true)]
public class Major
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Years { get; set; }
    [ForeignKey("Faculty")]
    public int FacultyId { get; set; }
    [Required]
    public Faculty Faculty { get; set; }
}