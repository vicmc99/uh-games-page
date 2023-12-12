using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Representative
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public int AthleteId { get; set; }
    public Athlete Athlete { get; set; }

    // public int MajorId { get; set; }
    // public Major Major { get; set; }
    public int Year { get; set; }
}