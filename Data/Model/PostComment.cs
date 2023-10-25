namespace Data.Model;

public class PostComment
{
    public int CommentId { get; set; }
    public string Contents { get; set; }
    public DateTime CommentDate { get; set; }


    // TODO : Include commenter data
}