
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Model;

public class EventTeamParticipant
{
    public int Id { get; set; }
   
    public int TeamId { get; set; }
    
    public NormalTeam Team { get; set; }
 
    public int EventId { get; set; }
  
    public Event Event { get; set; }
  
    public int ParticipantId { get; set; }
   
    public TeamMember Participant { get; set; }
 
    public int TeamEventId { get; set; }
    
    public TeamEvent TeamEvent { get; set; }
}