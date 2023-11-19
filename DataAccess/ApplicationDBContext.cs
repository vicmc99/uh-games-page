
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Data.Model;



namespace DataAccess;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Faculies Domain
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Major> Majors { get; set; }
    public DbSet<Athlete> Athletes { get; set; }
    public DbSet<Representative> Representatives { get; set; }
    public DbSet<Leaderboard> Leaderboards { get; set; }
    public DbSet<LeaderboardLine> LeaderboardLines { get; set; }

    // Sport Modalities Domain
    public DbSet<Category> Categories { get; set; }
    public DbSet<Modality> Modalities { get; set; }
    public DbSet<Sport> Sports { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }

    //Tournamet Domain
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<TournamentEvent> TournamentEvents { get; set; }

    // Competitions Domain
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventTeamParticipant> EventParticipants { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupEvent> GroupEvents { get; set; }
    public DbSet<GroupLine> GroupLines { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Tournament> Tournamets { get; set; }

    //Teams Domain
    public DbSet<Team> Teams { get; set; }
    public DbSet<ComposedTeamsEvent> ComposedTeamsEvents { get; set; }
    public DbSet<ComposedTeam> ComposedTeams { get; set; }
    public DbSet<TeamComposition> TeamCompositions { get; set; }
    public DbSet<TeamCompositionScore> TeamCompositionScores { get; set; }
    public DbSet<TeamEvent> TeamEvents { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<TeamScore> TeamScores { get; set; }
    public DbSet<TeamParticipantScore> TeamParticipantScores { get; set; }

    //Users Domain
    public DbSet<User> Users { get; set; }
    public DbSet<SuperUser> SuperUsers { get; set; }
    public DbSet<Moderator> Moderators { get; set; }
    public DbSet<Journalist> Journalists { get; set; }
    public DbSet<BanUser> BanUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<BanUser>().ToTable("BanUsers");
    

     
    }

}
   
