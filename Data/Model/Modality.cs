using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Modality
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int SportId { get; set; }
    public Sport Sport { get; set; }
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }
    public int CategoryId { get; set; }

    public Category Category { get; set; }

}