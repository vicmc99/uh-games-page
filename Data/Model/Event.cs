namespace Data.Model;

public class Event
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public Location Location { get; set; }
    public string Type { get; set; }
}