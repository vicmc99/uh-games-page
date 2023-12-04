namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Index(nameof(Name), IsUnique = true)]
public class Sport {
    public int Id {get; set;}
    [Required]
    public string Name {get; set;}
    public string Description {get; set;}
    public string Rules {get; set;}
    public string Pictogram {get; set;}
    
    [ForeignKey("Category")]
    public int CategoryId {get; set;}
    [Required]
    public Category Category {get; set;}
 
    
    //TODO: Add the type of sport (individual or team)
}