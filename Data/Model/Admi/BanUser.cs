
namespace Data.Model;

using System;
using System.ComponentModel.DataAnnotations;
public class BanUser :User
{
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "No access Date")]
    public DateTime NoAccessDate { get; set; }
    
 
    
}