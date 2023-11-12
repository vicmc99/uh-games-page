using System.Runtime.CompilerServices;

namespace Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Commentator
{
    public int Id { get; set; }
    //Unique
    [Required]
    public string NickName { get; set; }
    //Unique
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    public ICollection<PostComment> Comments { get; set; }
}

