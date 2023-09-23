namespace Data.Model;

public class Group
{
    public int Id {get; set;}
    public int LeagueId {get; set;}
    public League League {get; set;}
    public int Round {get; set;}
}