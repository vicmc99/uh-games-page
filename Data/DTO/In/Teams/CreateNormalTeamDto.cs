using Data.Model;

namespace Data.DTO.In.Teams;

public class CreateNormalTeamDto: CreateTeamDto
{
    public IEnumerable<int> Members { get; set; }
}