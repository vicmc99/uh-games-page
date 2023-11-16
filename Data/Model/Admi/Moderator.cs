using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;


[Table("users")]
public class Moderator:User
{
    public IEnumerable<PostComment> AceptedComments { get; set; }
}