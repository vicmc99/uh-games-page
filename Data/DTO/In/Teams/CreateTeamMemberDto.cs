namespace Data.DTO.In.Teams;

public class CreateTeamMemberDto
{
    public int TeamId { get; set; }
    public int AthleteId { get; set; }
    public string Role { get; set; }
}