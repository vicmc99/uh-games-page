using Microsoft.AspNetCore.Http;

namespace Data.DTO.In;

public class CreateAthleteDto
{
    public string Name { get; set; }
    public string Nick { get; set; }
    public string DateOfBirth { get; set; }
    public IFormFile Photo { get; set; }
    public string PhotoMimeType { get; set; }

    public int MajorId { get; set; }
    public int Year { get; set; }
}