using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
//TODO:{Name,Address} is unique???
    public string Name { get; set; }
    public string Address { get; set; }
    public string GoogleMapsURL { get; set; }
}