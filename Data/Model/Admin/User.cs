using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;

[Table("Userds")]
public  class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NickName { get; set; }
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required]
    [Display(Name = " Last Name")]
    public string LastName { get; set; }
    [Required]
    public string Password { get; set; } //Hash SHA-256
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Sign Up Date")]
    public DateTime SignUpDate { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
 
}
