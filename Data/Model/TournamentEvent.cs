namespace Data.Model;

public class TournamentEvent
{
    public int Id {get; set;}
    public int TournamentId {get; set;}
    public Tournament Tournament {get; set;}
    public int EventId {get; set;}
    public Event Event {get; set;}
    public int Round {get; set;}
}