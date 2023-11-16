using Data.Model;

namespace Data.DTO;

public class SportModalityDto
{
    public int Id {get; set;}
    public Sport Sport {get; set;}
    public Discipline Discipline {get; set;}
    public Category Category {get; set;}
    public string Sex {get; set;}
}