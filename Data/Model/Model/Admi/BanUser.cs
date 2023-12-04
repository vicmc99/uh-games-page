
namespace Data.Model;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BanUser
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public  int RoleId { get; set; }
    public Role Role { get; set; }
    public DateTime NoAccessDate { get; set; }
    
    
}