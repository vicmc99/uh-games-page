using Data.Model;

namespace Data.DTO;

public class DisciplineDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SportId { get; set; }

    public static DisciplineDto FromEntity(Discipline sport)
    {
        return new DisciplineDto
        {
            Id = sport.Id,
            Name = sport.Name,
            SportId = sport.SportId,
        };
    }
}