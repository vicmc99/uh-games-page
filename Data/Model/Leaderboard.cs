namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Leaderboard
{
    public int Id { get; set; }
    public int Year { get; set; }
    public ICollection<LeaderboardLine> LeaderboardLines { get; set; }
}