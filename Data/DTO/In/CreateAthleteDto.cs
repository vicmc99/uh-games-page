namespace Data.DTO.In;

public class CreateAthleteDto
{
    public string Name { get; set; }
    public string Nick { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Photo { get; set; }
   
    public int MajorId { get; set; }
    public int Year { get; set; }
}