using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Model;

[Index(nameof(Name), IsUnique = true)]
public class Sport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string Rules { get; set; }
    public string Pictogram { get; set; }
    
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
    
    //TODO:{Name,CategoryId} is unique???
}