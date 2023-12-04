namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class TournamentEvent
{
    public int Id {get; set;}
    [ForeignKey("Tournament")]
    public int TournamentId {get; set;}
    [Required]
    public Tournament Tournament {get; set;}
    [ForeignKey("Event")]
    public int EventId {get; set;}
    [Required]
    public Event Event {get; set;}
    public int Round {get; set;}
}