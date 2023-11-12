namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
public class User
{
    public virtual int Id { get; set; }

    [Required]
    public string NickName { get; set; }
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required]
    [Display(Name = "First Last Name")]
    public string FistLastName { get; set; }
    [Display(Name = "Second Last Name")]
    public string SecondLastName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Sign Up Date")]
    public DateTime SignUpDate { get; set; }

    [Required]
    public string Email { get; set; }
}