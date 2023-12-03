
namespace Data.Model;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BanUser
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
   
    public DateTime NoAccessDate { get; set; }
    #region Roles
    
    public int? ModeratorId { get; set; }

    public Moderator? Moderator { get; set; }
    
    public int? JournalistId { get; set; }
    
    public Journalist? Journalist { get; set; }
    
    public int? SuperUserId { get; set; }
    
    public SuperUser? SuperUser { get; set; }
    
    

    #endregion
    
}