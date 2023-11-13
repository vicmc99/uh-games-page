namespace Data.DTO;

public class TeamMemberDto
{
    public int Id { get; set; }
    public TeamDto Team { get; set; }
    public AthleteDto Athlete { get; set; }
    public string Role { get; set; }
}