namespace Data.Model;

public class Tournament
{
    public int Id {get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public IEnumerable<Location> Locations {get; set;}
    public int Rounds;

}