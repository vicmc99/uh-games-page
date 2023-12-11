using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Leaderboard
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    //TODO:Year deberia ser unico
    public int Year { get; set; }
    public List<LeaderboardLine> LeaderboardLines { get; set; }
}