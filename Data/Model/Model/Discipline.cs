namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Index(nameof(Name), IsUnique = true)]
public class Discipline
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name {get; set;}
    [ForeignKey("Sport")]
    public int SportId {get; set;}
    public Sport Sport {get; set;}

    // TODO: Put the type (individiual or team sport)  
   
}