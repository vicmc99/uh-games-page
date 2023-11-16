using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class TeamScore
{
    public Score Score { get; set; }
    public int ScoreId { get; set; }
    public NormalTeam Team { get; set; }
    [Key]
    public int TeamId { get; set; }
}