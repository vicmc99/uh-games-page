using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;


public class Moderator:Role
{
    public IEnumerable<PostComment> AceptedComments { get; set; }
}