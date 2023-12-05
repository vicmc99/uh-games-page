using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Data.Model;
using DataAccess;

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
        if (context.Set<Faculty>().Count() == 0)
            context.Set<Faculty>().AddRange(InitialDomainData.GetFaculties());

        //if (context.Set<LeaderboardLine>().Count() == 0)
         //   context.Set<LeaderboardLine>().AddRange(InitialDomainData.GetLeaderboardLines());
        if (context.Set<Leaderboard>().Count() == 0)
            context.Set<Leaderboard>().AddRange(InitialDomainData.GetLeaderBoard());

        
        context.SaveChanges();
    }


}