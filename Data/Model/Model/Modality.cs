namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Modality
{
    public int Id {get; set;}
    [ForeignKey("Sport")]
    public int SportId {get; set;}
    [Required]
    public Sport Sport {get; set;}
    [ForeignKey("Discipline")]
    public int DisciplineId {get; set;}
    [Required]
    public Discipline Discipline {get; set;}
    [ForeignKey("Category")]
    public int CategoryId {get; set;}
    [Required]
    public Category Category {get; set;}
    public string Sex {get; set;}
    
    //public Sex Sex { get; set; }
}

public enum Sex
{
    Male,
    Female,
 
}