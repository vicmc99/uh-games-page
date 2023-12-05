using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Model;

public class Athlete
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    
    //TODO: La tupla {Name, Nick, DateOfBirth} es única???
    public string Name { get; set; }
    public string Nick { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Photo { get; set; }
}