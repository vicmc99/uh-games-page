namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
public class Moderator:User
{
    public IEnumerable<PostComment> AceptedComments { get; set; }
}