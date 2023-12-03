using Microsoft.EntityFrameworkCore;

namespace Data.Model;

[Index(nameof(Name), IsUnique = true)]
public class Athlete
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nick { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Photo { get; set; }
}