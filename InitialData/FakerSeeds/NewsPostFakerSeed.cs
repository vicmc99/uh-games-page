using Bogus;
using Data.Model;

namespace InitialData.FakerSeeds;

public class NewsPostFakerSeed
{
    #region News and Post Domain
    // DEVS:Primero crear el fragmento despues actulizar su noticia correspondiente 
    private static Faker<Fragment> GetFakerFragment()
    {
       
        return new Faker<Fragment>()
            .RuleFor(r => r.fragment, f => f.Lorem.Paragraph(5));
    }

    public static List<Fragment> GetFragments(int count = 1) => GetFakerFragment().Generate(count);
   

    private static Faker<NewsPost> GetFakerNewsPost()
    {
       
       return new Faker<NewsPost>()
           .RuleFor(n => n.PostTitle, f => f.Lorem.Lines(1))
           .RuleFor(p => p.PostDate,
                    f => f.Date.Between(new DateTime(2023, 1, 1)
                                        , new DateTime(2023, 12, 31)));
    }

    
    public static List<NewsPost> GetNewsPosts(int count = 1) => GetFakerNewsPost().Generate(count);

    private static Faker<ToReviewComments> GetFakerToReviewComment()
    {

        return new Faker<ToReviewComments>()
            .RuleFor(c => c.Contents, f => f.Lorem.Text())
            .RuleFor(c=>c.CommentDate,f=>f.Date.Between(new DateTime(2023, 1, 1)
                                                     , new DateTime(2023, 12, 31)));

    }

    public static List<ToReviewComments> GetToReviewComments(int count = 1) =>
        GetFakerToReviewComment().Generate(count);

    private static Faker<PostComment> GetFakerPostComment()
    {

        return new Faker<PostComment>()
            .RuleFor(p => p.CommentDate,
                     f => f.Date.Between(new DateTime(2023, 1, 1)
                                         , new DateTime(2023, 12, 31)))
            .RuleFor(p => p.ReviewDate,
                     f => f.Date.Between(new DateTime(2023, 1, 1)
                                         , new DateTime(2023, 12, 31)))
            .RuleFor(p => p.Contents, f => f.Lorem.Paragraph(5));


    }

    public static List<PostComment> GetPostComments(int count = 1) => GetFakerPostComment().Generate(count);
           




   

    #endregion




}