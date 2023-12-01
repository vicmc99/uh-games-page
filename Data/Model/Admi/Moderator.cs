using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;


[Table("Moderators")]
public class Moderator:User
{
    //public int ModeratorId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [Required]
    public User User { get; set; }
    
    public IEnumerable<PostComment> AceptedComments { get; set; }
}