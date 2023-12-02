namespace Data.Model;

public class Team
{
    public int Id { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}