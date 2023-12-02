namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Representative
{
    public int Id {get; set;}
    [ForeignKey("Faculty")]
    public int FacultyId {get; set;}
    [Required]
    public Faculty Faculty {get; set;}
    [ForeignKey("Athlete")]
    public int AthleteId {get; set;}
    [Required]
    public Athlete Athlete {get; set;}
    [ForeignKey("Major")]
    public int MajorId {get; set;}
    [Required]
    public Major Major {get; set;}
    public int Year {get; set;}
}