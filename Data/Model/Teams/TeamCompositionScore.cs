using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class TeamCompositionScore
{
    public int Id { get; set; }
    
    [ForeignKey("TeamComposition")]
    public int CompositionId { get; set; }
    
    public TeamComposition Composition { get; set; }
    
    public int ScoreId { get; set; }
    public Score Score { get; set; }
}