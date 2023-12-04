namespace Data.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class LeaderboardLine
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public int Ranking { get; set; }
    public Leaderboard Leaderboard { get; set; }
    public int LeaderBoardId { get; set; }
    public int GoldMedals { get; set; }
    public int SilverMedals { get; set; }
    public int BronzeMedals { get; set; }
}