using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Faculty
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Acronym { get; set; }

    public string Mascot { get; set; }

    public string Logo { get; set; }

    public ICollection<Major> Majors { get; set; }

    public ICollection<Representative> Representatives { get; set; }
}