using Data.Model;

namespace Data.DTO;

public class TeamDto
{
    public int Id { get; set; }
    public int FacultyId { get; set; }

    public static TeamDto FromEntity(Team team)
    {
        return new TeamDto
        {
            Id = team.Id,
            FacultyId = team.FacultyId
        };
    }
}