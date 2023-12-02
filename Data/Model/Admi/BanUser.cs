
namespace Data.Model;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("BanUsers")]
public class BanUser :User
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    [Required]
    public User User { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "No access Date")]
    public DateTime NoAccessDate { get; set; }
    
 
    
}