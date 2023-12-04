using Data.Model;
using InitialData.FakerSeeds;
using InitialData.SeedBuilder;

namespace InitialData;


public class Factory
{ private List<T> FilterUsers<T>(List<T> users, Predicate<T> filter) => users.FindAll(filter);
    
    private static DateTime _dateTime = new DateTime(2023, 1, 1);

    public List<NewsPost> _newsPosts { get; set; }= NewsPostCommenstSeed.GetNewsPost(5);
    
    private List<User> _users { get; set; } = AdmisFakerSeed.GetUsers();
    
    private Random   random { get; set; }= new Random();

    //private List<PostComment>_GetpostComments() =>_newsPosts.SelectMany(x => x.Coments).ToList();

    private List<PostComment> _GetpostComments()
    {
        var res = new List<PostComment>();
        foreach (var v in _newsPosts)
        {
            res.AddRange(v.Coments);
        }

        return res;
    }
    public List<PostComment> GetPostComments { get; set; } = new List<PostComment>();
    
    private List<User>GetUsersForMatch(float proportion = 5)=>FilterUsers<User>(_users, u => random.Next(0, 2) <= 1/proportion);
    
    /*
    private List<T> _GetUsersWithType<T>(Func<List<PostComment>,User,T> fun,int maxCount=5,float proportion=1.7f)
    {
        
        var i = 0;
        var result = new List<T>();
        foreach (var v in GetUsersForMatch())
        {
            
            if(i>maxCount+1){break;}
             result.Add(fun(_postComments.FindAll(x=>random.Next(0,5)<proportion),v)); 
        }
        if(maxCount>0&&result.Count<1){return _GetUsersWithType(fun,maxCount,proportion);}
        return result;
    }
*/
    public List<Moderator> GetModerators { get; private set; }

    public List<Journalist> GetJournalist { get; private set; }
    
    public List<SuperUser>GetSuperUsers { get; private set; }
    public List<User> GetUsers { get; private set; }
    public Factory()
    {
       this.GetUsers =AdmisFakerSeed.GetUsers(5);
        var x = GetUsersForMatch(2);
        this.GetModerators = _GetModerators(x[2]);
        this.GetJournalist = _GetJournalist(x[1]);
        this.GetSuperUsers=_GetSuperUsers(x[0]);
        

    }
    
    public List<List<User>> GetUsersForMatch(int n=2)
    {
        var res = new List<List<User>>();
        var users = this.GetUsers.ToList();
        var superUser = new List<User>() { users[0] };
        users.RemoveAt(0);
        res.Add(superUser);
        int i = 0;
        var moderator = new List<User>();
        for (; i < users.Count/n; i++)
        {
            moderator.Add(users[i]);
        }
        res.Add(moderator);
        var journalist = new List<User>();
        for (; i < users.Count; i++)
        {
            journalist.Add(users[i]);
        }
res.Add(journalist);
        return res;
        /* var divided = Helpers<User>.DivideEvenly(users, n);
         foreach (var v in divided)
         {
             res.Add(v.ToList());
         }

        */
    }
    
   
    private List<Moderator>_GetModerators(List<User>users,int maxCount=5,float proportion=1.7f)
        {
            var i = 0;
            var postComment = _GetpostComments();
                    var result = new List<Moderator>();
                    foreach (var v in users)
                    {
                      //  if(i>maxCount+1 ||postComment.Count<1){break;}
                       // var r = AdmisSeed.GetModerator(FilterUsers<PostComment>(postComment, u => random.Next(0, 2) <= 1/proportion).FindAll(x => random.Next(0, 5) < proportion),
                                                     //  v);
                                                     var r = AdmisSeed.GetModerator(postComment, v);
                       // postComment = postComment.Except(r.AceptedComments).ToList();
                         result.Add(r); 
                         
                    }

                    if (postComment.Count > 0)
                    {
                      //  this.GetPostComments = _GetpostComments().Except(postComment).ToList();
                    }

                    if(maxCount>0&&result.Count<1){return _GetModerators(users,maxCount,proportion);}
                    return result;
        }

    private List<Journalist>_GetJournalist(List<User>users,int maxCount=5,float proportion=1.7f)
    {
        var i = 0;
        var result = new List<Journalist>();
        foreach (var v in  users)
        {
            if(i>maxCount+1){break;}

           
               //t(FilterUsers<NewsPost>(_newsPosts, u => random.Next(0, 2) <= 1 / proportion),
              // v);
            var r = AdmisSeed.GetJournalist(_newsPosts, v);
            result.Add(r);
                         
        }
      // if(maxCount>0&&result.Count<1){return _GetJournalist(users,maxCount,proportion);}
        return result;
    }

    private List<SuperUser> _GetSuperUsers(List<User>users,int maxCount = 5, float proportion = 1.7f) 
    
    {
        //random.Next(0, 5) < proportion
        var i = 0;
        var result = new List<SuperUser>();
        foreach (var v in users) 
        {

            if (i > maxCount + 1)
            {
                break;
            }
    
            result.Add(AdmisSeed.GetSuperUser(v));
        }

        if (maxCount > 0 && result.Count < 1)
       {
            return _GetSuperUsers(users,maxCount, proportion);
        }

        return result;
    }

    
    
    
}

/*
 public static void Start()
    {
        
        var journalist = new JournalistFactory().GetJournalist(news);
        var commets = news.SelectMany(x => x.Coments).ToList();
        var moderator = new ModeratorFactory().GetModerator(commets);
        var superUser = new SuperUserFactory().GetSuperUser();
        var journalistUser = new UserFactory().GetUser(journalist);
        var moderatorUser = new UserFactory().GetUser(moderator);
        var SuperUserUser = new UserFactory().GetUser(superUser);
        
    }

*/



