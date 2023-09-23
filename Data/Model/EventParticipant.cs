namespace Data.Model;

public class EventParticipant
{
    public int Id {get; set;}
    public int EventId {get; set;}
    public Event Event {get; set;}
    public int TeamId {get; set;}
    public Team Team {get; set;}
    public int AthleteId {get; set;}
    public Athlete Athlete {get; set;}
    public int Result {get; set;}
    public string Statistics {get; set;}
}