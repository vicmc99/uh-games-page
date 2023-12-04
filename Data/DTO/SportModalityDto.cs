using Data.Model;

namespace Data.DTO;

public class SportModalityDto
{
    public int Id { get; set; }
    public SportDto Sport { get; set; }
    public DisciplineDto Discipline { get; set; }
    public CategoryDto Category { get; set; }
    public string Sex { get; set; }

    public static SportModalityDto FromEntity(Modality modality)
    {
        return new SportModalityDto
        {
            Id = modality.Id,
            Sport = SportDto.FromEntity(modality.Sport),
            Discipline = DisciplineDto.FromEntity(modality.Discipline),
            Category = CategoryDto.FromEntity(modality.Category),
            Sex = modality.Sex
        };
    }
}