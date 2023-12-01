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

        if (context.Set<LeaderboardLine>().Count() == 0)
            context.Set<LeaderboardLine>().AddRange(InitialDomainData.GetLeaderboardLines());  
        
      
         //TODO: delete after testing
        
        //New data
        InitialDomainData.Start();

        #region Admins    
        
        if (context.Set<User>().Count() == 0)
            context.Set<User>().AddRange(InitialDomainData.GetUsers());
        
        if (context.Set<SuperUser>().Count() == 0)
            context.Set<SuperUser>().AddRange(InitialDomainData.GetSuperUsers());
        
        
        if (context.Set<Moderator>().Count() == 0)
            context.Set<Moderator>().AddRange(InitialDomainData.GetModerators());
        
        if (context.Set<Journalist>().Count() == 0)
            context.Set<Journalist>().AddRange(InitialDomainData.GetJournalists());
        
        #endregion
        
        if(context.Set<Leaderboard>().Count()==0)
            context.Set<Leaderboard>().AddRange(InitialDomainData. GetLeaderboards());
        
        if (context.Set<Score>().Count() == 0)
            context.Set<Score>().AddRange(InitialDomainData. GetScores());
        if (context.Set<Location>().Count() == 0)
            context.Set<Location>().AddRange(InitialDomainData.GetLocations());
        if (context.Set<Sport>().Count() == 0)
            context.Set<Sport>().AddRange(InitialDomainData.GetSports());
        if (context.Set<Category>().Count() == 0)
            context.Set<Category>().AddRange(InitialDomainData.GetCategories());
        if (context.Set<Discipline>().Count() == 0)
            context.Set<Discipline>().AddRange(InitialDomainData.GetDisciplines());
        if (context.Set<Modality>().Count() == 0)
            context.Set<Modality>().AddRange(InitialDomainData.GetModalities()); 
        
        if (context.Set<Competition>().Count() == 0)
            context.Set<Competition>().AddRange(InitialDomainData.GetCompetitions());
        
        if (context.Set<Event>().Count() == 0)
            context.Set<Event>().AddRange(InitialDomainData.GetEvents());
        
        if (context.Set<Team>().Count() == 0)
            context.Set<Team>().AddRange(InitialDomainData.   GetTeams());
        /*
        if (context.Set<TeamMember>().Count() == 0)
            context.Set<TeamMember>().AddRange(InitialDomainData. GetTeamMembers());
        
        if (context.Set<NormalTeam>().Count() == 0)
            context.Set<NormalTeam>().AddRange(InitialDomainData. GetNormalTeams());
        
        if (context.Set<EventTeamParticipant>().Count() == 0)
            context.Set<EventTeamParticipant>().AddRange(InitialDomainData.  GetEventTeamParticipants());
        
        if (context.Set<TeamParticipantScore>().Count() == 0)
            context.Set<TeamParticipantScore>().AddRange(InitialDomainData.  GetTeamParticipantScores());
        
        if (context.Set<TeamComposition>().Count() == 0)
            context.Set<TeamComposition>().AddRange(InitialDomainData. GetTeamCompositions());
        
        if (context.Set<Competition>().Count() == 0)
            context.Set<Competition>().AddRange(InitialDomainData. GetCompetitions());
        
        if (context.Set<Event>().Count() == 0)
            context.Set<Event>().AddRange(InitialDomainData. GetEvents());
        
        if (context.Set<Team>().Count() == 0)
            context.Set<Team>().AddRange(InitialDomainData. GetTeams());
       //
        if (context.Set<TeamMember>().Count() == 0)
            context.Set<TeamMember>().AddRange(InitialDomainData. GetTeamMembers());
        
        if (context.Set<NormalTeam>().Count() == 0)
            context.Set<NormalTeam>().AddRange(InitialDomainData. GetNormalTeams());
        
        if (context.Set<EventTeamParticipant>().Count() == 0)
            context.Set<EventTeamParticipant>().AddRange(InitialDomainData. GetEventTeamParticipants());
        
        if (context.Set<TeamParticipantScore>().Count() == 0)
            context.Set<TeamParticipantScore>().AddRange(InitialDomainData.GetTeamParticipantScores());
        
        if (context.Set<TeamComposition>().Count() == 0)
            context.Set<TeamComposition>().AddRange(InitialDomainData.GetTeamCompositions());
        
        
         if (context.Set<TeamCompositionScore>().Count() == 0)
                 context.Set<TeamCompositionScore>().AddRange(InitialDomainData. GetTeamCompositionScores());
       
         
         if (context.Set<TeamScore>().Count() == 0)
                context.Set<TeamScore>().AddRange(InitialDomainData. GetTeamScores());
         
         if (context.Set<TeamEvent>().Count() == 0)
                 context.Set<TeamEvent>().AddRange(InitialDomainData. GetTeamEvents());
         */
         if (context.Set<League>().Count() == 0)
             context.Set<League>().AddRange(InitialDomainData.GetLeagues());
         
         if (context.Set<Group>().Count() == 0)
             context.Set<Group>().AddRange(InitialDomainData. GetGroups());
         
         if (context.Set<GroupEvent>().Count() == 0)
             context.Set<GroupEvent>().AddRange(InitialDomainData. GetGroupsEvents());
         
         if (context.Set<GroupLine>().Count() == 0)
             context.Set<GroupLine>().AddRange(InitialDomainData.   GetGroupLines());
         
         if (context.Set<Leaderboard>().Count() == 0) 
             context.Set<Leaderboard>().AddRange(InitialDomainData.  GetLeaderboards());
        
        
        
        
      
       
        
        
        
        
        
         
         if (context.Set<Major>().Count() == 0)
                    context.Set<Major>().AddRange(InitialDomainData. GetMajors());
         
         if (context.Set<ParticipantScoredEvent>().Count() == 0)
                    context.Set<ParticipantScoredEvent>().AddRange(InitialDomainData. GetParticipantScoredEvents());
         
         if (context.Set<Representative>().Count() == 0)
                    context.Set<Representative>().AddRange(InitialDomainData. GetRepresentatives());
         
         if (context.Set<Tournament>().Count() == 0)
                    context.Set<Tournament>().AddRange(InitialDomainData. GetTournaments());
         
        if (context.Set<TournamentEvent>().Count() == 0)
                    context.Set<TournamentEvent>().AddRange(InitialDomainData. GetTournamentEvents());
        
     

       
       
      
        
       

        #region Athletes

        
        if (context.Set<Athlete>().Count() == 0)
            context.Set<Athlete>().AddRange(InitialDomainData.GetAthletes());
        

        #endregion

        
       
        context.SaveChanges();
    }


}