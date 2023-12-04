namespace Data.Model;

public class TeamCompositionScore
{
    public int CompositionId { get; set; }
    public TeamComposition Composition { get; set; }

    public int ScoreId { get; set; }
    public Score Score { get; set; }
    
}

