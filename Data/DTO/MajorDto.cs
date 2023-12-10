using Data.Model;

namespace Data.DTO;

public class MajorDto
{
    public string Name { get; set; }
    public int Years { get; set; }
    public int FacultyId { get; set; }

    public static MajorDto FromEntity(Major major)
    {
        return new MajorDto
        {
            Years = major.Years,
            Name = major.Name,
            FacultyId = major.FacultyId
        };
    }
}