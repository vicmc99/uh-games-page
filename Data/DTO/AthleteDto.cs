using Data.Model;

namespace Data.DTO;

public class AthleteDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nick { get; set; }
    public string DateOfBirth { get; set; }
    public byte[] Photo { get; set; }

    public static AthleteDto FromEntity(Athlete athlete)
    {
        return new AthleteDto
        {
            Id = athlete.Id,
            Name = athlete.Name,
            DateOfBirth = athlete.DateOfBirth.Year.ToString("dd/mm/yyyy"),
            Photo = athlete.Photo,
            Nick = athlete.Nick
        };
    }
}