using Data.Model;
using InitialData.FakerSeeds;

namespace InitialData.SeedBuilder;

public static class NewsPostCommenstSeed
{
    
        public static List<NewsPost> GetNewsPost(int newPostCount = 5, int fragmentsCount = 5, int postCommentsCount = 5,
            int toReviewCommentscount = 5)
        {
            var lis = NewsPostFakerSeed.GetNewsPosts(newPostCount);

            foreach (var e in lis)
            {
                e.fragments =
                    NewsPostFakerSeed
                        .GetFragments(fragmentsCount);
                e.Coments =
                    NewsPostFakerSeed
                        .GetPostComments(postCommentsCount);
                e.CommentsToReview =
                    NewsPostFakerSeed
                        .GetToReviewComments(toReviewCommentscount);
                        
            }

            return lis;


        }
    

}