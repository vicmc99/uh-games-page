using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class TeamParticipantScore
{
    public int Id { get; set; }
    
    [ForeignKey("Event")]
    public int EventId { get; set; }
    
    [Required]
    public Event Event { get; set; }
    
    [ForeignKey("NormalTeam")] 
    public int TeamId { get; set; }
    [Required]
    public NormalTeam Team { get; set; }
   
    [ForeignKey("EventTeamParticipant")]
    public int ParticipantId { get; set; }
    [Required]
    public EventTeamParticipant Participant { get; set; }
    
    [ForeignKey("Score")]
    public int ScoreId { get; set; }
    [Required]
    public Score Score { get; set; }
}