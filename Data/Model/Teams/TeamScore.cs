using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class TeamScore
{
    
    public int Id { get; set; }
    public Score Score { get; set; }
    public int ScoreId { get; set; }
    public NormalTeam Team { get; set; }

   
}