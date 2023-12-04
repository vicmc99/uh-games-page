using Data.Model;

namespace Data.DTO;

public class TeamMemberDto
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public AthleteDto Athlete { get; set; }
    public string Role { get; set; }

    public static TeamMemberDto FromEntity(TeamMember teamMember)
    {
        return new TeamMemberDto
        {
            Id = teamMember.Id,
            TeamId = teamMember.TeamId,
            Athlete = new AthleteDto
            {
                Id = teamMember.Athlete.Id,
                Name = teamMember.Athlete.Name,
                DateOfBirth = teamMember.Athlete.DateOfBirth,
                Photo = teamMember.Athlete.Photo,
                Nick = teamMember.Athlete.Nick
            },
            Role = teamMember.Role
        };
    }
}