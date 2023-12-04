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
    
    public int CategoryId { get; set; }
    
    
}