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
        //

     
          var seed = new Factory();
        Helpers<Faculty>.SetSeed(context, Seed.GetFaculties());

     
       Helpers<User>.SetSeed(context,seed.GetUsers);
       // Obtén todos los usuarios y sus Journalist asociados
       var usersWithJournalists = context.Users
           .Include(u => u.Journalist)
           .ToList();

// usersWithJournalists contendrá todos los User y sus Journalist asociados


     var users=  context.Users;
    
     
     
       
       
        
   
        

    }


}