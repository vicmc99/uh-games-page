namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class ParticipantScoredEvent : Event
{
    public IEnumerable<NormalTeam> ParticipantScoredTeams { get; set; }
    public IEnumerable<TeamParticipantScore> ParticipantScores { get; set; }
    public IEnumerable<EventTeamParticipant> TeamSubstitutes { get; set; }
}