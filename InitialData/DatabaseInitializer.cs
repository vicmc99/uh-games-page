using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Data.Model;
using DataAccess;
using InitialData.FakerSeeds;
using InitialData.SeedBuilder;


namespace InitialData;

public interface IDatabaseInitializer
{
    void EnsureInitialData();
}

public class DatabaseInitializer: IDatabaseInitializer
{
    ApplicationDbContext context;

    public DatabaseInitializer(ApplicationDbContext context)
    {
        this.context = context;
    }

    public void EnsureInitialData()
    {
        if (!AllMigrationsApplied())
        {
            throw new Exception("Not all migrations applied before seeding");
        }

        SeedData();
    }


    private bool AllMigrationsApplied()
    {
        var applied = context.GetService<IHistoryRepository>().GetAppliedMigrations().Select(m => m.MigrationId);
        var total = context.GetService<IHistoryRepository>().GetAppliedMigrations().Select(m => m.MigrationId);
        return !total.Except(applied).Any();
    }


    private void SeedData()
    {
        var date=new DateTime(2023,1,1);
          var seed = new Factory();
        Helpers<Faculty>.SetSeed(context, Seed.GetFaculties());

        /*var u = new User()
        {
            Email = "kjcjnunununudjddkd", FirstName = "Juanijdjnuununuudto", LastName = "Mejnununudjdndc" ,BornDate = date
            
        };
       var news= seed._newsPosts;
        var j = new Journalist() { User = u, NickName = "jjbnununununudjd", Password = "kdjdjnununuuunudjdk", SignUpDate = date };
        j.NewsPosts = news;
        Helpers<Journalist>.SetSeed(context, new List<Journalist>() { j });
       */
       //news.Journalist = j;
//       Helpers<NewsPost>.SetSeed(context, new List<NewsPost>() { news });

     
       Helpers<User>.SetSeed(context,seed.GetUsers);
        Helpers<Moderator>.SetSeed(context, seed.GetModerators);
        Helpers<Journalist>.SetSeed(context, seed.GetJournalist);
        
    
        
      
        
        
        
      
        
        Helpers<SuperUser>.SetSeed(context,seed.GetSuperUsers);
        
        //Helpers<NewsPost>.SetSeed(context,news);
      //  var user=j.Select(x=>x.User).ToList();

        

        

    }


}