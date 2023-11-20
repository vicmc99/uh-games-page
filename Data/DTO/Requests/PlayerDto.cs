namespace Data.DTO;

public class PlayerDto
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Faculty { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Record { get; set; }
    public int GoldMedals { get; set; }
    public int SilverMedals { get; set; }
    public int BronzeMedals { get; set; }
    public IEnumerable<SportModalityDto> Sports { get; set; }
    public IEnumerable<string> GalleryImages { get; set; }
}