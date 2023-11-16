
using Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("journalits")]
public class Journalist : User
{
    public ICollection<NewsPost> NewsPosts { get; set; }
}