namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Group
{
    public int Id { get; set; }
    [ForeignKey("League")]
    public int LeagueId {get; set;}
    [Required]
    public League League {get; set;}
    public int Round {get; set;}
}