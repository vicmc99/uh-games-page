using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System.ComponentModel.DataAnnotations;

public class PostComment
{
    public int Id { get; set; }

    [StringLength(2000, ErrorMessage = "The comment value cannot exceed 2000 characters. ")]
    public string Contents { get; set; }

    [ForeignKey("NewsPost")] public int NewsPostId { get; set; }
    [Required] public NewsPost NewsPost { get; set; }

    public DateTime CommentDate { get; set; }

    [ForeignKey("Moderator")] public int ReviewById { get; set; }
    [Required] public Moderator ReviewBy { get; set; }

    public DateTime ReviewDate { get; set; }

}