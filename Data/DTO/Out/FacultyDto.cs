namespace Data.DTO.Out;

public class FacultyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Acronym { get; set; }
    public string Mascot { get; set; }
    public string Logo { get; set; }
    public IEnumerable<AthleteDto> Athletes { get; set; }
    public int? GoldMedals { get; set; }
    public int? SilverMedals { get; set; }
    public int? BronzeMedals { get; set; }
    public int? Ranking { get; set; }
}