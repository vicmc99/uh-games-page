
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Model;

public class EventTeamParticipant
{
    public int Id { get; set; }
    [ForeignKey("NormalTeam")]
    public int TeamId { get; set; }
    [Required]
    public NormalTeam Team { get; set; }
    [ForeignKey("Event")]
    public int EventId { get; set; }
    [NotMapped]
    public Event Event { get; set; }
    [ForeignKey("TeamMember")]
    public int ParticipantId { get; set; }
    [Required]
    public TeamMember Participant { get; set; }
    [ForeignKey("TeamEvent")]
    public int TeamEventId { get; set; }
    
    public TeamEvent TeamEvent { get; set; }
}