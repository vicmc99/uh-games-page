namespace Data.DTO;

public class TeamMemberDto
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public AthleteDto Athlete { get; set; }
    public string Role { get; set; }
}