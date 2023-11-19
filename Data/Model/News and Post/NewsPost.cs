using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;
using System.ComponentModel.DataAnnotations;
public class NewsPost
{
    public int Id { get; set; }
    [Required]
    public string PostTitle { get; set; }
    public DateTime PostDate { get; set; }
    [ForeignKey("Event")]
    public int RelatedEventId { get; set; }
    [Required]
    public Event RelatedEvent { get; set; }
    [ForeignKey("Journalist")]
    public int CreatorId { get; set; }
    [Required]
    public Journalist Creator { get; set; }
    public IEnumerable<Fragment> fragments { get; set; } // Only fragments to 2k characters.
    public IEnumerable<PostComment> Coments { get; set; }
}