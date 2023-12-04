using Data.Model;

namespace Data.DTO;

public class AthleteDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nick { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Photo { get; set; }

    public static AthleteDto FromEntity(Athlete a)
    {
        return new AthleteDto
        {
            Id = a.Id,
            Name = a.Name,
            Nick = a.Nick,
            DateOfBirth = a.DateOfBirth,
            Photo = a.Photo
        };
    }
}