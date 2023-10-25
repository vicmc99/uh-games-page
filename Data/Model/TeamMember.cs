namespace Data.Model;

public class TeamMember
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
    public int AthleteId { get; set; }
    public Athlete Athlete { get; set; }
    public string Role { get; set; } // TODO: normalize this to another table
}