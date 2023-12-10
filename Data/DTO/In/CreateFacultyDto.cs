namespace Data.DTO.In;

public class CreateFacultyDto
{
    public string Name { get; set; }

    public string Acronym { get; set; }

    public string Mascot { get; set; }

    public byte[] Logo { get; set; }

    public IEnumerable<int> MajorsId { get; set; }
    public IEnumerable<int> RepresentativesId { get; set; }
}