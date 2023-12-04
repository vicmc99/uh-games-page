using Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Faculties Domain
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
    public DbSet<TeamEventScore> TeamScores { get; set; }
    public DbSet<TeamParticipantScore> TeamParticipantScores { get; set; }

    //Users Domain
    // public DbSet<User> Users { get; set; }
    // public DbSet<SuperUser> SuperUsers { get; set; }
    // public DbSet<Moderator> Moderators { get; set; }
    // public DbSet<Journalist> Journalists { get; set; }
    // public DbSet<BanUser> BanUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region EventTeamParticipant and Substitute

        modelBuilder.Entity<EventTeamParticipant>()
            .HasKey(t => new { t.EventId, t.TeamId, t.ParticipantId });

        modelBuilder.Entity<EventTeamSubstitute>()
            .HasKey(t => new { t.EventId, t.TeamId, t.SubstituteId });

        modelBuilder.Entity<EventTeamParticipant>()
            .HasOne(t => t.Team)
            .WithMany()
            .HasForeignKey(t => t.TeamId);

        modelBuilder.Entity<EventTeamParticipant>()
            .HasOne(t => t.Event)
            .WithMany()
            .HasForeignKey(t => t.EventId);

        modelBuilder.Entity<EventTeamParticipant>()
            .HasOne(t => t.Participant)
            .WithMany()
            .HasForeignKey(t => t.ParticipantId);

        modelBuilder.Entity<EventTeamSubstitute>()
            .HasOne(t => t.Team)
            .WithMany()
            .HasForeignKey(t => t.TeamId);

        modelBuilder.Entity<EventTeamSubstitute>()
            .HasOne(t => t.Event)
            .WithMany()
            .HasForeignKey(t => t.EventId);

        modelBuilder.Entity<EventTeamSubstitute>()
            .HasOne(t => t.Substitute)
            .WithMany()
            .HasForeignKey(t => t.SubstituteId);

        #endregion

        #region TeamEvent and Score

        modelBuilder.Entity<TeamEvent>()
            .HasMany(e => e.TeamParticipants)
            .WithOne(p => p.Event)
            .HasForeignKey(e => e.EventId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<TeamEvent>()
            .HasMany(e => e.TeamSubstitutes)
            .WithOne(p => p.Event)
            .HasForeignKey(e => e.EventId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<TeamEventScore>()
            .HasKey(e => new { e.TeamId, e.EventId, e.ScoreId });

        modelBuilder.Entity<TeamEventScore>()
            .HasOne(e => e.Event)
            .WithMany(e => e.TeamScores)
            .HasForeignKey(e => e.EventId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<TeamEventScore>()
            .HasOne(e => e.Score)
            .WithOne()
            .HasForeignKey<TeamEventScore>(e => e.ScoreId)
            .HasPrincipalKey<Score>(s => s.Id);

        modelBuilder.Entity<TeamEventScore>()
            .HasOne(e => e.Team)
            .WithMany()
            .HasForeignKey(e => e.TeamId)
            .HasPrincipalKey(t => t.Id);

        #endregion

        #region GroupEvent

        modelBuilder.Entity<GroupEvent>()
            .HasKey(ge => new { ge.EventId, ge.GroupId });

        modelBuilder.Entity<GroupEvent>()
            .HasOne(ge => ge.Group)
            .WithMany()
            .HasForeignKey(ge => ge.GroupId)
            .HasPrincipalKey(g => g.Id);

        modelBuilder.Entity<GroupEvent>()
            .HasOne(ge => ge.Event)
            .WithMany()
            .HasForeignKey(ge => ge.EventId)
            .HasPrincipalKey(e => e.Id);

        #endregion

        #region GroupLine

        modelBuilder.Entity<GroupLine>()
            .HasKey(gl => new { gl.GroupId, gl.TeamId, gl.AthleteId });

        modelBuilder.Entity<GroupLine>()
            .HasOne(gl => gl.Group)
            .WithMany()
            .HasForeignKey(gl => gl.GroupId)
            .HasPrincipalKey(g => g.Id);

        modelBuilder.Entity<GroupLine>()
            .HasOne(gl => gl.Athlete)
            .WithMany()
            .HasForeignKey(gl => gl.AthleteId)
            .HasPrincipalKey(a => a.Id);

        modelBuilder.Entity<GroupLine>()
            .HasOne(gl => gl.Team)
            .WithMany()
            .HasForeignKey(gl => gl.TeamId)
            .HasPrincipalKey(t => t.Id);

        #endregion

        #region TeamCompositionScore

        modelBuilder.Entity<TeamCompositionScore>()
            .HasKey(tcs => new { tcs.CompositionId, tcs.ScoreId });

        modelBuilder.Entity<TeamCompositionScore>()
            .HasOne(tcs => tcs.Composition)
            .WithMany()
            .HasForeignKey(tcs => tcs.CompositionId)
            .HasPrincipalKey(c => c.Id);

        modelBuilder.Entity<TeamCompositionScore>()
            .HasOne(tcs => tcs.Score)
            .WithOne()
            .HasForeignKey<TeamCompositionScore>(tcs => tcs.ScoreId)
            .HasPrincipalKey<Score>(s => s.Id);

        #endregion

        #region TeamParticipantScore

        modelBuilder.Entity<TeamParticipantScore>()
            .HasKey(tps => new { tps.ParticipantId, tps.EventId, tps.ScoreId, tps.TeamId });

        modelBuilder.Entity<TeamParticipantScore>()
            .HasOne(tcs => tcs.Participant)
            .WithOne()
            .HasForeignKey<TeamParticipantScore>(tcs => tcs.ParticipantId)
            .HasPrincipalKey<TeamMember>(p => p.Id);

        modelBuilder.Entity<TeamParticipantScore>()
            .HasOne(tcs => tcs.Event)
            .WithMany()
            .HasForeignKey(tcs => tcs.EventId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<TeamParticipantScore>()
            .HasOne(tcs => tcs.Team)
            .WithMany()
            .HasForeignKey(tcs => tcs.TeamId)
            .HasPrincipalKey(t => t.Id);

        modelBuilder.Entity<TeamParticipantScore>()
            .HasOne(tcs => tcs.Score)
            .WithOne()
            .HasForeignKey<TeamParticipantScore>(tcs => tcs.ScoreId)
            .HasPrincipalKey<Score>(s => s.Id);

        #endregion
    }
}