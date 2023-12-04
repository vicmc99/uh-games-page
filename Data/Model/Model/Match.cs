namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Match
{
    public int MatchId { get; set; }
    public IEnumerable<TeamParticipantScore> ParticipantScores { get; set; }
}