using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System.ComponentModel.DataAnnotations;

public class PostComment
{
    public int Id { get; set; }

   
    public string Contents { get; set; }
    
    public int NewsPostId { get; set; }
    
    public NewsPost NewsPost { get; set; }
    public int ReviewById { get; set; }
    
    public Moderator ReviewBy { get; set; }
    
   

    public DateTime CommentDate { get; set; }
    
    public DateTime ReviewDate { get; set; }

}