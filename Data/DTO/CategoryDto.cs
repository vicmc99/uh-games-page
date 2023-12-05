using Data.Model;

namespace Data.DTO;

public class CategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    public IEnumerable<SportDto> Sports { get; set; }
    public static CategoryDto FromEntity(Category sport)
    {
        return new CategoryDto
        {
            Id = sport.Id,
            Name = sport.Name,
            Sports = sport.Sports.Select(SportDto.FromEntity)
        };
    }
}