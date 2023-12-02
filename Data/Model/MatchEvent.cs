namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class MatchEvent : Event
{
    public IEnumerable<NormalTeam> Teams { get; set; }
    public IEnumerable<Match> Matches { get; set; }
}