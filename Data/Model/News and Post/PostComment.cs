namespace Data.Model;
using System.ComponentModel.DataAnnotations;
public class PostComment
{
    public int CommentId { get; set; }
    [StringLength(2000, ErrorMessage = "The comment value cannot exceed 2000 characters. ")]
    public string Contents { get; set; }
    
    public DateTime CommentDate { get; set; }
    
    public Moderator ReviewBy { get; set; }
    
    public DateTime ReviewDate { get; set; }
    
    // TODO : Include commenter data
}