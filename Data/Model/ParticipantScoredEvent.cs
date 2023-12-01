using Microsoft.Extensions.Logging;

namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class ParticipantScoredEvent : Event
{
    [ForeignKey("Event")]
    public int EventId { get; set; }
    [Required]
    public Event Event { get; set; }
    public IEnumerable<NormalTeam> ParticipantScoredTeams { get; set; }
    public IEnumerable<TeamParticipantScore> ParticipantScores { get; set; }
    public IEnumerable<EventTeamParticipant> TeamSubstitutes { get; set; }
}