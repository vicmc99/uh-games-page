using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Score
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //TODO:NumberScore deberia ser unico
    public float NumberScore { get; set; }

    // TODO: Add score formats for every sport
}