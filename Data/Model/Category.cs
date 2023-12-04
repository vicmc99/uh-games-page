using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
  //TODO: Name is unique???
    public string Name { get; set; }
    public IEnumerable<Sport> Sports { get; set; }
}