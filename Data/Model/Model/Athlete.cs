
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Model;
[Index(nameof(Name), IsUnique = true)]
public class Athlete
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nick { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Photo { get; set; }
}