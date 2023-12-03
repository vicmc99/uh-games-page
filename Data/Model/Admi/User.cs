using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Data.Model;
using System;
using System.ComponentModel.DataAnnotations;


public  class User
{
    
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string Email { get; set; }
    public DateTime BornDate { get; set; }
    
    public ICollection<BanUser> BanUsers { get; set; }
    
    #region Roles
    
    public int? ModeratorId { get; set; }

    public Moderator? Moderator { get; set; }
    
    public int? JournalistId { get; set; }
    
    public Journalist? Journalist { get; set; }
    
    public int? SuperUserId { get; set; }
    
    public SuperUser? SuperUser { get; set; }
    
    

    #endregion
}
