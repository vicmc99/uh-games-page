
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Data.Model;



namespace DataAccess;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){}


    public DbSet<Faculty> Faculties {get; set;}
    public DbSet<Major> Majors {get; set;}
    public DbSet<Athlete> Athletes {get; set;}
    public DbSet<Team> Teams {get; set;}
    public DbSet<TeamMember> TeamMembers {get; set;}
    public DbSet<Representative> Representatives { get; set; }
    public DbSet<Leaderboard> Leaderboards { get; set; }
    public DbSet<LeaderboardLine> LeaderboardLines { get; set; }

    //public DbSet<Category> Categories { get; set; }
    //public DbSet<Competition> Competitions { get; set; }
    //public DbSet<Discipline> Disciplines { get; set; }
    //public DbSet<Event> Events { get; set; }
    //public DbSet<EventParticipant> EventParticipants { get; set; }
    //public DbSet<Group> Groups { get; set; }
    //public DbSet<GroupEvent> GroupEvents { get; set; }
    //public DbSet<GroupLine> GroupLines { get; set; }
    //public DbSet<League> Leagues { get; set; }
    //public DbSet<Location> Locations { get; set; }
    //public DbSet<Modality> Modalities { get; set; }
    //public DbSet<Sport> Sports { get; set; }
    //public DbSet<Tournament> Tournamets { get; set; }
    //public DbSet<TournamentEvent> TournamentEvents { get; set; }

}