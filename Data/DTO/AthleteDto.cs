namespace Data.DTO;

public class AthleteDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nick { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Photo { get; set; }
}