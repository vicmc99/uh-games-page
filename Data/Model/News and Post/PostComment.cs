using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System.ComponentModel.DataAnnotations;

public class PostComment
{
    public int Id { get; set; }

    [StringLength(2000, ErrorMessage = "The comment value cannot exceed 2000 characters. ")]
    public string Contents { get; set; }
    
    public int NewsPostId { get; set; }
    
    
    public int ReviewById { get; set; }
    
    public Moderator ReviewBy { get; set; }
    
    public NewsPost NewsPost { get; set; }

    public DateTime CommentDate { get; set; }
    
    public DateTime ReviewDate { get; set; }

}