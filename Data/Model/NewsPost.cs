namespace Data.Model;

public class NewsPost
{
    public int PostId { get; set; }
    public string PostTitle { get; set; }
    public DateTime PostDate { get; set; }
    public Journalist Creator { get; set; }
    public string Contents { get; set; } // Maybe a file instead of plain text?
    public IEnumerable<PostComment> Comments { get; set; }
}