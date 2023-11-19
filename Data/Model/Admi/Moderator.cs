using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;


[Table("users")]
public class Moderator:User
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    [Required]
    public User User { get; set; }
    
    public IEnumerable<PostComment> AceptedComments { get; set; }
}