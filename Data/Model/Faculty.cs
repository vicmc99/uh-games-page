using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Faculty
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    //TODO: Name is unique???
    public string Name { get; set; }

    public string Acronym { get; set; }

    public string Mascot { get; set; }

    public byte[] Logo { get; set; }
    public string PhotoMimeType { get; set; }

    public List<Major> Majors { get; set; }

    public List<Representative> Representatives { get; set; }
}