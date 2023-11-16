namespace Data.Model;
using System.ComponentModel.DataAnnotations;
public class NewsPost
{
    public int Id { get; set; }
    public string PostTitle { get; set; }
    public DateTime PostDate { get; set; }
    public Event RelatedEvent { get; set; }
    public Journalist Creator { get; set; }
    public IEnumerable<Fragment> fragments { get; set; } // Only fragments to 2k characters.
    public IEnumerable<PostComment> Coments { get; set; }
}