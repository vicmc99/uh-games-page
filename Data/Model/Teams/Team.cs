using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Team
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //TODO:{Name,FacultyID} deberia ser llave
    public string Name { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}