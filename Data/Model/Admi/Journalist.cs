
using Data.Model;

public class Journalist : User
{
    public SuperUser Elevatedby { get; set; }
    public ICollection<NewsPost> NewsPosts { get; set; }
}