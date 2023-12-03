namespace Data.DTO.Out;

public class NewsDto
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Author { get; set; }
    public string Contents { get; set; }
    public IEnumerable<CommentDto> Comments { get; set; }
}