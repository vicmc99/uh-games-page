
using Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("journalits")]
public class Journalist : User
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    [Required]
    public User User { get; set; }
    public ICollection<NewsPost> NewsPosts { get; set; }
}