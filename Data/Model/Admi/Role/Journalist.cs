
using Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Journalist :Role
{
    public IEnumerable<NewsPost> NewsPosts { get; set; }
}