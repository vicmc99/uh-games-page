namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
public class BanCommentator : Commentator
{
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Ban Date")]
    public DateTime BanDate { get; set; }
    public PostComment banComment{get; set;}
    public Administrator BanBy { get; set; }
}