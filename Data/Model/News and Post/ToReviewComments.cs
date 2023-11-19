using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System.ComponentModel.DataAnnotations;
public class ToReviewComments
{
    public int Id { get; set; }
    [ForeignKey("NewsPost")]
    public int NewsPostId { get; set; }
    [Required]
    public NewsPost NewsPost { get; set; }
    
    [StringLength(2000, ErrorMessage = "The comment value cannot exceed 2000 characters. ")]
    public string Contents { get; set; }
    public DateTime CommentDate { get; set; }
}