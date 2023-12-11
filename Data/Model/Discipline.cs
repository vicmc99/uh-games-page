using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Discipline
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    //TODO:El {Name,SportId} es único???
    public string Name { get; set; }
    public int SportId { get; set; }
    public Sport Sport { get; set; }
    public string Sex { get; set; }
}