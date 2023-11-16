
using Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
public class Journalist : User
{
    public ICollection<NewsPost> NewsPosts { get; set; }
}