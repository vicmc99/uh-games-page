using Bogus;
using Data.Model;

namespace InitialData.FakerSeeds;

public static class AdmisFakerSeed
{
    #region Administrators Domain


    private static Faker<User> GetFakerUser()
    {

        return new Faker<User>()
            .RuleFor(u=>u.Email,f=>f.Internet.Email())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(y => y.LastName, f => f.Name.LastName())
            .RuleFor(u => u.BornDate, f => f.Date.Past(2, new DateTime(2020, 2, 1)));

    }

    public static List<User> GetUsers(int count =1)=>  GetFakerUser().Generate(count);



    private static Faker<SuperUser>GetFakerSuperUser()=> Helpers<SuperUser>.GetFakerUser<SuperUser>();

    public static List<SuperUser> GetSuperUsers(int count = 1) => GetFakerSuperUser().Generate(count);


    private static Faker<Journalist>GetFakerJournalist=> Helpers<Journalist>.GetFakerUser<Journalist>();
    public static List<Journalist> GetJournalists(int count = 1) => GetFakerJournalist.Generate(count);



    private static Faker<Moderator> GetFakerModerator() => Helpers<Moderator>.GetFakerUser<Moderator>();
   
    public static List<Moderator> GetModerators(int count = 1) => GetFakerModerator().Generate(count);


    private static Faker<BanUser> GetFakerBanUser()
    {
        return new Faker<BanUser>()
            .RuleFor(b=>b.NoAccessDate,f=>f.Date.Between(new DateTime(2023, 1, 1)
                                                         , new DateTime(2023, 12, 31)));
    }

    public static List<BanUser> GetBanUsers(int count = 1) => GetFakerBanUser().Generate(count);


  #endregion
   
}