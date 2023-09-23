namespace Data.Model;

public class Major 
{
    public int Id {get; set;}
    public string Name {get; set;}
    public int Years {get; set;}
    public int FacultyId {get; set;}
    public Faculty Faculty {get; set;}
}