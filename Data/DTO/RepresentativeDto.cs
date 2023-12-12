using Data.Model;

namespace Data.DTO;

public class RepresentativeDto
{
    public int Id { get; set; }

    public int FacultyId { get; set; }

    public int AthleteId { get; set; }

    // public int MajorId { get; set; }
    public int Year { get; set; }

    public static RepresentativeDto FromEntity(Representative representative)
    {
        return new RepresentativeDto
        {
            Id = representative.Id,
            FacultyId = representative.FacultyId,
            AthleteId = representative.AthleteId,
            // MajorId = representative.MajorId,
            Year = representative.Year
        };
    }
}