using Data.Model;

namespace Data.DTO;

public class SportDto
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string Rules { get; set; }
    public string Pictogram { get; set; }
    
    public int CategoryId { get; set; }
    public static SportDto FromEntity(Sport sport)
    {
        return new SportDto
        {
            Id = sport.Id,
            Name = sport.Name,
            Description = sport.Description,
            Rules = sport.Rules,
            Pictogram = sport.Pictogram,
            CategoryId = sport.CategoryId,
        };
    }
}