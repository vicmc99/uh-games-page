namespace Data.Model;

public class Modality
{
    public int Id {get; set;}
    public int SportId {get; set;}
    public Sport Sport {get; set;}
    public int DisciplineId {get; set;}
    public Discipline Discipline {get; set;}
    public int CategoryId {get; set;}
    public Category Category {get; set;}
    public string Sex {get; set;}
}