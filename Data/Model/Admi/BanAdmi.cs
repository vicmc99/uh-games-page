using System.ComponentModel.DataAnnotations;
namespace Data.Model;


public class BanAdmi : Administrator
{
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "No access Date")]
    public DateTime NoAccessDate { get; set; }
    [Required]
    [Display(Name = "Restricted By")]
    public SuperUser Restrictedby { get; set; }


}