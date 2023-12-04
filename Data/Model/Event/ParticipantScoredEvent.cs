using Microsoft.Extensions.Logging;

namespace Data.Model;
using Microsoft.EntityFrameworkCore;

public class ParticipantScoredEvent : Event
{
    public IEnumerable<NormalTeam> ParticipantScoredTeams { get; set; }
    public IEnumerable<TeamParticipantScore> ParticipantScores { get; set; }
    public IEnumerable<EventTeamParticipant> TeamSubstitutes { get; set; }
}