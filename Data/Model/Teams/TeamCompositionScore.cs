using System.ComponentModel.DataAnnotations;

namespace Data.Model;

public class TeamCompositionScore
{
    [Key]
    public int CompositionId { get; set; }
    public TeamComposition Composition { get; set; }
    public int ScoreId { get; set; }
    public Score Score { get; set; }
}