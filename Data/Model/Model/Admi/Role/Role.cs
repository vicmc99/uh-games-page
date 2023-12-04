namespace Data.Model;

public abstract class Role
{
    
    public int Id { get; set; }
  /*  
    public int UserId { get; set; }
    public User User { get; set; }*/
    public string Email { get; set; }
    public string NickName { get; set; }
    
    public string Password { get; set; } //Hash SHA-256
   
    public DateTime SignUpDate { get; set; }
    
    public int BanUserId { get; set; }
    public BanUser BanUser { get; set; }
}