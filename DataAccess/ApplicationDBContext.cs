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

    //Tournament Domain
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<TournamentEvent> TournamentEvents { get; set; }

    // Competitions Domain
    public DbSet<Event> Events { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<TeamEventParticipant> EventParticipants { get; set; }
    public DbSet<EventTeamSubstitute> EventSubstitutes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupEvent> GroupEvents { get; set; }
    public DbSet<GroupLine> GroupLines { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Location> Locations { get; set; }

    //Teams Domain
    public DbSet<ParticipantScoredEventSubstitute> ParticipantScoredEventSubstitutes { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<ComposedTeamsEvent> ComposedTeamsEvents { get; set; }
    public DbSet<ComposedTeam> ComposedTeams { get; set; }
    public DbSet<TeamComposition> TeamCompositions { get; set; }
    public DbSet<TeamCompositionScore> TeamCompositionScores { get; set; }
    public DbSet<TeamEvent> TeamEvents { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<TeamEventScore> TeamScores { get; set; }
    public DbSet<TeamParticipantScore> TeamParticipantScores { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<MatchEvent> MatchEvents { get; set; }
    public DbSet<NormalTeam> NormalTeams { get; set; }
    public DbSet<ParticipantScoredEvent> ParticipantScoredEvents { get; set; }
    public DbSet<Score> Scores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Many- relations
        //.
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Sports)
            .WithOne(e=>e.Category)
            .HasForeignKey(e=>e.CategoryId);
        //.
        modelBuilder.Entity<ComposedTeam>()
            .HasMany(ct => ct.Compositions)
            .WithOne()
            .HasForeignKey("ComposedTeamId");
                //.
        modelBuilder.Entity<ComposedTeamsEvent>()
            .HasMany(e => e.ComposedTeams)
            .WithMany();
            //.
        modelBuilder.Entity<ComposedTeamsEvent>()
            .HasMany(e => e.ComposedTeamScores)
            .WithOne()
            .HasForeignKey("EventId");
            //.
        modelBuilder.Entity<Faculty>()
            .HasMany(f => f.Majors)
            .WithOne(m => m.Faculty)
            .HasForeignKey(m => m.FacultyId);
            //.
        modelBuilder.Entity<Faculty>()
            .HasMany(f => f.Representatives)
            .WithOne(r => r.Faculty)
            .HasForeignKey(r => r.FacultyId);
            //.
        modelBuilder.Entity<Leaderboard>()
            .HasMany(l => l.LeaderboardLines)
            .WithOne()
            .HasForeignKey("LeaderboardId");
        //.
        modelBuilder.Entity<League>()
            .HasMany(l => l.Locations)
            .WithMany();
            //.
        modelBuilder.Entity<Match>()
            .HasMany(m => m.ParticipantScores)
            .WithOne()
            .HasForeignKey("MatchId");
            //.
        modelBuilder.Entity<MatchEvent>()
            .HasMany(m => m.MatchedTeams)
            .WithMany();
           //.
        modelBuilder.Entity<MatchEvent>()
            .HasMany(m => m.Matches)
            .WithOne()
            .HasForeignKey("EventId");
            //.
        modelBuilder.Entity<ParticipantScoredEvent>()
            .HasMany(e => e.ParticipantScoredTeams)
            .WithMany();
            //.
        modelBuilder.Entity<TeamComposition>()
            .HasMany(c => c.Participants)
            .WithMany();
            //.
        modelBuilder.Entity<Tournament>()
            .HasMany(t => t.Locations)
            .WithMany();

        #endregion

        #region ParticipantScoredEventSubstitute
        //.
        modelBuilder.Entity<ParticipantScoredEventSubstitute>()
            .HasKey(t => new { t.EventId, t.TeamId, t.SubstituteId });
        //.
        modelBuilder.Entity<ParticipantScoredEventSubstitute>()
            .HasOne(t => t.Team)
            .WithMany()
            .HasForeignKey(t => t.TeamId);
        //.
        modelBuilder.Entity<ParticipantScoredEventSubstitute>()
            .HasOne(t => t.Event)
            .WithMany()
            .HasForeignKey(t => t.EventId);
        //.
        modelBuilder.Entity<ParticipantScoredEventSubstitute>()
            .HasOne(t => t.Substitute)
            .WithMany()
            .HasForeignKey(t => t.SubstituteId);

        #endregion

        #region EventTeamParticipant and Substitute
            //.
        modelBuilder.Entity<EventTeamSubstitute>()
            .HasKey(t => new { t.EventId, t.TeamId, t.SubstituteId });
            //.
        modelBuilder.Entity<TeamEventParticipant>()
            .HasOne(t => t.Team)
            .WithMany()
            .HasForeignKey(t => t.TeamId);
            //.
        modelBuilder.Entity<TeamEventParticipant>()
            .HasOne(t => t.Event)
            .WithMany()
            .HasForeignKey(t => t.EventId);
            //.
        modelBuilder.Entity<TeamEventParticipant>()
            .HasOne(t => t.Participant)
            .WithMany()
            .HasForeignKey(t => t.ParticipantId);
        //.
        modelBuilder.Entity<EventTeamSubstitute>()
            .HasOne(t => t.Team)
            .WithMany()
            .HasForeignKey(t => t.TeamId);
        //.
        modelBuilder.Entity<EventTeamSubstitute>()
            .HasOne(t => t.Event)
            .WithMany()
            .HasForeignKey(t => t.EventId);
        //.
        modelBuilder.Entity<EventTeamSubstitute>()
            .HasOne(t => t.Substitute)
            .WithMany()
            .HasForeignKey(t => t.SubstituteId);

        #endregion

        #region TeamEvent and Score
        //.
        modelBuilder.Entity<TeamEvent>()
            .HasMany(e => e.TeamParticipants)
            .WithOne(p => p.Event)
            .HasForeignKey(e => e.EventId);
        //.
        modelBuilder.Entity<TeamEvent>()
            .HasMany(e => e.TeamSubstitutes)
            .WithOne(p => p.Event)
            .HasForeignKey(e => e.EventId);
        //.
        modelBuilder.Entity<TeamEventScore>()
            .HasKey(e => new { e.TeamId, e.EventId, e.ScoreId });
        //.
        modelBuilder.Entity<TeamEventScore>()
            .HasOne(e => e.Event)
            .WithMany(e => e.TeamScores)
            .HasForeignKey(e => e.EventId);
        //.
        modelBuilder.Entity<TeamEventScore>()
            .HasOne(e => e.Score)
            .WithOne()
            .HasForeignKey<TeamEventScore>(e => e.ScoreId);
        //.
        modelBuilder.Entity<TeamEventScore>()
            .HasOne(e => e.Team)
            .WithMany()
            .HasForeignKey(e => e.TeamId);

        #endregion

        #region GroupEvent
        //.
        modelBuilder.Entity<GroupEvent>()
            .HasKey(ge => new { ge.EventId, ge.GroupId });
        //.
        modelBuilder.Entity<GroupEvent>()
            .HasOne(ge => ge.Group)
            .WithMany()
            .HasForeignKey(ge => ge.GroupId);
        //.
        modelBuilder.Entity<GroupEvent>()
            .HasOne(ge => ge.Event)
            .WithMany()
            .HasForeignKey(ge => ge.EventId);

        #endregion

        #region GroupLine
        //.
        modelBuilder.Entity<GroupLine>()
            .HasKey(gl => new { gl.GroupId, gl.TeamId, gl.AthleteId });
        //.
        modelBuilder.Entity<GroupLine>()
            .HasOne(gl => gl.Group)
            .WithMany()
            .HasForeignKey(gl => gl.GroupId);
        //.
        modelBuilder.Entity<GroupLine>()
            .HasOne(gl => gl.Athlete)
            .WithMany()
            .HasForeignKey(gl => gl.AthleteId);
        //.
        modelBuilder.Entity<GroupLine>()
            .HasOne(gl => gl.Team)
            .WithMany()
            .HasForeignKey(gl => gl.TeamId);

        #endregion

        #region TeamCompositionScore
        //.
        modelBuilder.Entity<TeamCompositionScore>()
            .HasKey(tcs => new { tcs.CompositionId, tcs.ScoreId });
        //.
        modelBuilder.Entity<TeamCompositionScore>()
            .HasOne(tcs => tcs.Composition)
            .WithMany()
            .HasForeignKey(tcs => tcs.CompositionId);
        //.
        modelBuilder.Entity<TeamCompositionScore>()
            .HasOne(tcs => tcs.Score)
            .WithOne()
            .HasForeignKey<TeamCompositionScore>(tcs => tcs.ScoreId);

        #endregion

        #region TeamParticipantScore
        //.
        modelBuilder.Entity<TeamParticipantScore>()
            .HasKey(tps => new { tps.ParticipantId, tps.EventId, tps.ScoreId, tps.TeamId });
        //.
        modelBuilder.Entity<TeamParticipantScore>()
            .HasOne(tcs => tcs.Participant)
            .WithOne()
            .HasForeignKey<TeamParticipantScore>(tcs => tcs.ParticipantId);
        //.
        modelBuilder.Entity<TeamParticipantScore>()
            .HasOne(tcs => tcs.Event)
            .WithMany(e => e.ParticipantScores)
            .HasForeignKey(tcs => tcs.EventId);
        //.
        modelBuilder.Entity<TeamParticipantScore>()
            .HasOne(tcs => tcs.Team)
            .WithMany()
            .HasForeignKey(tcs => tcs.TeamId);
        //.
        modelBuilder.Entity<TeamParticipantScore>()
            .HasOne(tcs => tcs.Score)
            .WithOne()
            .HasForeignKey<TeamParticipantScore>(tcs => tcs.ScoreId);

        #endregion
        //TODO: Uncomment to use the configuration in the Config files.
       // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        
        
    }
}