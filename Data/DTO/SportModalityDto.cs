namespace Data.DTO;

public class SportModalityDto
{
    public int Id { get; set; }
    public SportDto Sport { get; set; }
    public DisciplineDto Discipline { get; set; }
    public CategoryDto Category { get; set; }
    public string Sex { get; set; }
}