namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class GroupLine
{
    public int Id {get; set;}
    [ForeignKey("Group")]
    public int GroupId {get; set;}
    [Required]
    public Group Group {get; set;}
    [ForeignKey("Team")]
    public int TeamId {get; set;}
    [Required]
    public Team Team {get; set;}
    [ForeignKey("Athlete")]
    public int AthleteId {get; set;}
    [Required]
    public Athlete Athlete {get; set;}
    public int Position {get; set;}
    public string Statistics {get; set;}
    public string Status {get; set;}
    public int Round {get; set;}
}
