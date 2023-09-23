namespace Data.Model;

public class Category
{
    public int Id {get; set;}
    public string Name {get; set;}
    public IEnumerable<Sport> Sports {get; set;}
}