using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Model;
[Index(nameof(Name), IsUnique = true)]

public class Faculty {
    
    public int Id {get; set;}

    public string Name {get; set;}

    public string Acronym {get; set;}

    public string Mascot {get; set;}

    public string Logo {get; set;}

    public ICollection<Major> Majors {get; set;}

    public ICollection<Representative> Representatives {get; set;}
}
