using System.Data.Common;
using System.Runtime.CompilerServices;
using Data.Model;

namespace Data.DTO.In;

public class CreateSportDto
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string Rules { get; set; }
    public string Pictogram { get; set; }

    public static Sport FromEntity(CreateSportDto sport)
    {
        return new Sport()
        {
            Id = sport.Id,
            Name = sport.Name,
            Description = sport.Description,
            Rules = sport.Rules,
            Pictogram = sport.Pictogram

        };
    }
}