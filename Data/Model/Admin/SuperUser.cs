using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

[Table("SuperUser")]
public class SuperUser:User
{
   // public int SuperUserId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [Required]
    public User User { get; set; }
}