﻿using Data.Model;

namespace InitialData;

public class InitialDomainData
{

    private static DateTime _dateTime = new DateTime(2023, 1, 1);

    public static List<Faculty> GetFaculties()
    {
        return new List<Faculty>()
        {
            new Faculty { Id = 1, Name = "Facultad de Artes y Letras", Acronym = "FAyL", Mascot = "Elefantes" },
            new Faculty { Id = 2, Name = "Facultad de Biología", Acronym = "Bio", Mascot = "Gavilanes" },
            new Faculty { Id = 3, Name = "Facultad de Comunicación", Acronym = "FCOM", Mascot = "Vikingos" },
            new Faculty { Id = 4, Name = "Facultad Contabilidad y Finanzas", Acronym = "CONFIN", Mascot = "Lobos" },
            new Faculty { Id = 5, Name = "Facultad de Derecho", Acronym = "Lex", Mascot = "Zorros" },
            new Faculty { Id = 6, Name = "Facultad de Economía", Acronym = "EKO", Mascot = "Leones" },
            new Faculty { Id = 7, Name = "Español para no Hispanohablantes", Mascot = "Aplanadoras" },
            new Faculty
            {
                Id = 8, Name = "Facultad de Filosofía, Historia y Sociología", Acronym = "FHS", Mascot = "Buhos"
            },
            new Faculty { Id = 9, Name = "Facultad de Física", Acronym = "Fis", Mascot = "Tigres" },
            new Faculty { Id = 10, Name = "Facultad de Geografía", Acronym = "GEO", Mascot = "Tiburones" },
            new Faculty
            {
                Id = 11, Name = "Instituto de Farmacia y Alimentos", Acronym = "IFAL", Mascot = "Serpientes"
            },
            new Faculty
            {
                Id = 12, Name = "Instituto de Ciencias y Tecnologías Aplicadas", Acronym = "INSTEC", Mascot = "Gatos"
            },
            new Faculty { Id = 13, Name = "Instituto Superior de Diseño", Acronym = "ISDi", Mascot = "Mapaches" },
            new Faculty { Id = 14, Name = "Facultad de Lenguas Extranjeras", Acronym = "FLEX", Mascot = "Panteras" },
            new Faculty
            {
                Id = 15, Name = "Facultad de Matemática y Computación", Acronym = "MATCOM", Mascot = "Cuervos"
            },
            new Faculty { Id = 16, Name = "Facultad de Psicología", Acronym = "Psico", Mascot = "Fenix" },
            new Faculty { Id = 17, Name = "Facultad de Química", Acronym = "Qui", Mascot = "Pumas" },
            new Faculty { Id = 18, Name = "Facultad de Turismo", Acronym = "FTur", Mascot = "Aviones" }
        };
    }

    public static List<LeaderboardLine> GetLeaderboardLines()
    {
        return new List<LeaderboardLine>()
        {
            new LeaderboardLine
            {
                Id = 1, FacultyId = 15, GoldMedals = 12, SilverMedals = 5, BronzeMedals = 3, Ranking = 1, Year = 2023
            }
        };
    }

//New Implementation
    private static Faculty _faculty = GetFaculties()[0];
  

    private static Score _score = new Score()
    {
        NumberScore = 3.2f,
        ScoreId = 1,
        
        
        
    };

    public static List<Score> GetScores()
    {
        return new List<Score>()
        {
            _score
        };
    }

    
    private static Athlete _athlete = new Athlete()
    {
        Id = 1, Nick = "Paco ",
        Name = "Francisco Suarez",
        Photo = "kmvkm",
        DateOfBirth = new DateTime(1, 1, 1)

    };

    public static List<Athlete> GetAthletes()
    {
        return new List<Athlete>()
        {
            _athlete
        };
    }

    private static Category _category = new Category()
        { Id = 1,
            Name = "Acuaticos",
            Sports = new List<Sport>() /*Add in GetSports*/ };

    public static List<Category> GetCategories()
    {
        return new List<Category>()
        {
            _category
        };
    }

    private static Sport _sport = new Sport()
    {
        Id = 1,
        Name = "Natación",
        Description = "Natación normal",
        Pictogram = "kmvkv",
        Rules = "Reglas",
        CategoryId = 1,
        //Category = _category

    };

    public static List<Sport> GetSports()
    {
        var result = new List<Sport>()
        {
            _sport
        };
        
        return result;

    }

    private static Discipline _discipline = new Discipline()
    {
        SportId = 1,
       // Sport = _sport,
        Name = "Acuatica",
        Id = 1
    };

    public static List<Discipline> GetDisciplines()
    {
        return new List<Discipline>()
        {
            _discipline
        };
    }

    private static Modality _modality = new Modality()
    {
        CategoryId = 1,
        //Category = _category, 
       // Sport = _sport,
        SportId = 1,
       // Discipline = _discipline,
        DisciplineId = 1,
        Sex = "Mas", Id = 1
        

    };

    public static List<Modality> GetModalities()
    {
        return new List<Modality>()
        {
            _modality
        };

    }

    private static Competition _competition = new Competition()
    {
        Id = 1,
        Year = 2023,
        ModalityId = _modality.Id,
        //Modality = _modality
    };

    public static List<Competition> GetCompetitions()
    {
        return new List<Competition>()
        {
            _competition
        };
    }

    private static Location _location = new Location()
    {
        Id = 1,
        Name = "Ceder",
        Address = "Universidad de la Habana",
        GoogleMapsURL = "kckdkdk"
    };

    public static List<Location> GetLocations()
    {
        return new List<Location>()
        {
            _location
        };
    }

    private static Event _event = new Event()
    {
        Id = 1,
        Type = "Evento normal",
        DateTime = _dateTime,
        LocationId = _location.Id,
        //Location = _location
    };

    public static List<Event> GetEvents()
    {
        return new List<Event>()
        {
            _event
        };
    }

    #region Teams Domain




    private static Team _team = new Team()
    {
        Id = 10,
        FacultyId = _faculty.Id,
        //Faculty = _faculty,
        
    };

    public static List<Team> GetTeams()
    {
        return new List<Team>()
        {
            _team
        };
    }

    private static TeamMember _teamMember = new TeamMember()
    {
        //Athlete = _athlete,
        AthleteId = _athlete.Id,
        Id = 1, //Team = _team,
        TeamId = _team.Id,
        Role = "Campeón"
    };

    public static List<TeamMember> GetTeamMembers()
    {
        return new List<TeamMember>()
        {
            _teamMember


        };
    }

    private static NormalTeam _normalTeam = new NormalTeam()
    {
        Id = 2,
        FacultyId = _faculty.Id,
        //Faculty = _faculty,
        Members = GetTeamMembers()
    };

    public static List<NormalTeam> GetNormalTeams()
    {
        return new List<NormalTeam>()
        {
            _normalTeam
        };
    }

    private static EventTeamParticipant _eventTeamParticipant = new EventTeamParticipant()
    {
       
        //Event = _event,
        EventId = _event.Id,
        TeamId = _team.Id,
       // Team = _normalTeam, 
        //Participant = _teamMember,
        ParticipantId = _teamMember.Id
    };

    public static List<EventTeamParticipant> GetEventTeamParticipants()
    {
        return new List<EventTeamParticipant>()
        {
            _eventTeamParticipant
        };
    }

    private static TeamParticipantScore _teamParticipantScore = new TeamParticipantScore()
    {
       
       // Participant = _eventTeamParticipant,
        ParticipantId = _eventTeamParticipant.Id,
        TeamId = _normalTeam.Id,
       // Team = _normalTeam,
        EventId = _event.Id,
       // Event = _event,
       // Score = _score,
        ScoreId = _score.ScoreId,


    };

    public static List<TeamParticipantScore> GetTeamParticipantScores()
    {
        return new List<TeamParticipantScore>()
        {

            _teamParticipantScore
        };
    }

    private static TeamComposition _teamComposition = new TeamComposition()
    {
        
        Participants =new List<TeamMember>() //GetTeamMembers(),

      
    };

    public static List<TeamComposition> GetTeamCompositions()
    {
        return new List<TeamComposition>()
        {
            _teamComposition
        };
    }

    private static ComposedTeam _composedTeam = new ComposedTeam()
    {
        Id = 85,
        FacultyId = _faculty.Id,
        //Faculty = _faculty,
        Compositions =new List<TeamComposition>() //GetTeamCompositions(),


    };

    public static List<ComposedTeam> GetComposedTeams()
    {
        return new List<ComposedTeam>()
        {
            _composedTeam
        };
    }


    private static TeamCompositionScore _teamCompositionScore = new TeamCompositionScore()
    {
       // Composition = _teamComposition,
        CompositionId = 85,
        ScoreId = 1,
       // Score = _score,


    };

    public static List<TeamCompositionScore> GetTeamCompositionScores()
    {
        return new List<TeamCompositionScore>()
        {

            _teamCompositionScore
        };
    }


    private static TeamScore _teamScore = new TeamScore()
    {
      //  Score = _score,
        ScoreId = _score.ScoreId,
      //  Team = _normalTeam,
        TeamId = _normalTeam.Id,
    };

    public static List<TeamScore> GetTeamScores()
    {
        return new List<TeamScore>()
        {
            _teamScore
        };
    }




    private static TeamEvent _teamEvent = new TeamEvent()
    {
       
       // Location = _location,
        LocationId = _location.Id,
        Type = "Ninguno",
        DateTime = _dateTime,
        TeamSubstitutes = GetEventTeamParticipants(),
        TeamParticipants = GetEventTeamParticipants(),
        TeamScores = GetTeamScores(),

    };

    public static List<TeamEvent> GetTeamEvents()
    {
        return new List<TeamEvent>()
        {

            _teamEvent
        };
    }










    #endregion

   

    private static League _league = new League()
    {
        Id = 1,
        Locations = new List<Location>(),//GetLocations(),
        Rounds = 1, StartDate = _dateTime,
        EndDate = _dateTime
    };

    public static List<League> GetLeagues()
    {
        return new List<League>()
        {
            _league
        };
    }


    private static Group _group = new Group()
    {
        Id = 1, 
        //League = _league,
        LeagueId = _league.Id,
        Round = 1
    };

    public static List<Group> GetGroups()
    {
        return new List<Group>()
        {
            _group
        };
    }

    private static GroupEvent _groupEvent = new GroupEvent()
    {
        Id = 1,
        EventId = _event.Id,
        //Event = _event,
       // Group = _group,
        GroupId = _group.Id,


    };

    public static List<GroupEvent> GetGroupsEvents()
    {
        return new List<GroupEvent>()
        {
            _groupEvent
        };
    }

    private static GroupLine _groupLine = new GroupLine()
    {
        Id = 1,
       // Group = _group,
        GroupId = _group.Id,
       // Team = _normalTeam,
        TeamId = _normalTeam.Id,
        Position = 1,
        AthleteId = _athlete.Id,
       // Athlete = _athlete,
        Round = 1,
        Statistics = "Ninguna",
        Status = "Ninguno",


    };

    public static List<GroupLine> GetGroupLines()
    {
        return new List<GroupLine>()
        {
            _groupLine
        };
    }

    private static Leaderboard _leaderboard = new Leaderboard()
    {
        Id = 20,
        Year = 2023,
        LeaderboardLines = new List<LeaderboardLine>()//GetLeaderboardLines(),
    };

    public static List<Leaderboard> GetLeaderboards()
    {
        return new List<Leaderboard>()
        {
            _leaderboard,


        };
    }

    private static void UpdateLeaderBoard()
    {
        _leaderboard.LeaderboardLines= GetLeaderboardLines();
    }
    private static Major _major = new Major()
    {
        Id = 1,
        FacultyId = _faculty.Id,
       // Faculty = _faculty,
        Name = "Ciencias de la Computación",
        Years = 4,

    };

    public static List<Major> GetMajors()
    {
        return new List<Major>()
        {

            _major
        };
    }

    #region Match

    private static Match _match = new Match()
    {
        MatchId = 1,
        ParticipantScores = new List<TeamParticipantScore>()//GetTeamParticipantScores(),


    };

    public static List<Match> GetMatches()
    {
        return new List<Match>()
        {
            _match
        };
    }

    private static MatchEvent _matchEvent = new MatchEvent()
    {
        Id = 1,
        //Location = _location,
        DateTime = _dateTime,
        Matches =new List<Match>() ,//GetMatches(),
        LocationId = _location.Id,
        Type = "Ninguno",
        Teams =new List<NormalTeam>() //GetNormalTeams(),

    };

    public static List<MatchEvent> GetMatchEvents()
    {
        return new List<MatchEvent>()
        {
            _matchEvent
        };
    }
    private static void UpdateMatchEvent()
    {
        //match
        _match.ParticipantScores = GetTeamParticipantScores();
        
        //matchEvent
        _matchEvent.Teams = GetNormalTeams();
        _matchEvent.Matches = GetMatches();
    }
    #endregion

    private static ParticipantScoredEvent _participantScoredEvent = new ParticipantScoredEvent()
    {
        Id = 11,
        //Location = _location,
        DateTime = _dateTime,
        Type = "Ninguno",
        LocationId = _location.Id,
        ParticipantScores = GetTeamParticipantScores(),
        TeamSubstitutes = GetEventTeamParticipants(),
        ParticipantScoredTeams = GetNormalTeams(),
        //Event = _event,
        EventId = _event.Id
    };

    public static List<ParticipantScoredEvent> GetParticipantScoredEvents()
    {
        return new List<ParticipantScoredEvent>()
        {
            _participantScoredEvent
        };
    }


    private static Representative _representative = new Representative()
    {
        Id = 1,
        FacultyId = _faculty.Id,
       // Athlete = _athlete,
        AthleteId = _athlete.Id,
     //   Faculty = _faculty,
        Year = 2023,
        //Major = _major,
        MajorId = _major.Id

    };

    public static List<Representative> GetRepresentatives()
    {
        return new List<Representative>()
        {

            _representative

        };
    }



    #region Tournament Domain

    private static Tournament _tournament = new Tournament()
    {
        Id = 1,
        Locations =new List<Location>(), //GetLocations(),
        Rounds = 3,
        EndDate = _dateTime,
        StartDate = _dateTime,
    };

    public static List<Tournament> GetTournaments()
    {
        return new List<Tournament>()
        {
            _tournament
        };
    }


    private static TournamentEvent _tournamentEvent = new TournamentEvent()
    {
        Id = 1,
       // Event = _event,
        EventId = _event.Id,
        Round = 3,
       // Tournament = _tournament,
        TournamentId = _tournament.Id
    };

    public static List<TournamentEvent> GetTournamentEvents()
    {
        return new List<TournamentEvent>()
        {
            _tournamentEvent
        };
    }

    #endregion
#region Administrators Domain

    private static User _user = new User()
    {
        Id = 1,
        Email = "Miguelito.uh.cu",
        Password = "Encriptada",
        FirstName = "Miguel",
        LastName = "Gonzalez",
        NickName = "MiguelGonzalez",
        SignUpDate = _dateTime,
        


    };

    public static List<User> GetUsers()
    {
        return new List<User>()
        {
            _user
        };
    }


    private static SuperUser _superUser = new SuperUser()
    {
        Id = 2,
        Email = "Miguelito.uh.cu",
        Password = "Encriptada",
        FirstName = "Miguel",
        LastName = "Gonzalez",
        NickName = "MiguelGonzalez",
        SignUpDate = _dateTime,
        User = _user,
         UserId = _user.Id,
         
    };

    public static List<SuperUser> GetSuperUsers()
    {
        return new List<SuperUser>()
        {
            _superUser
        };
    }

    private static Journalist _journalist = new Journalist()
    {
        Id = 3,
        Email = "Miguelito.uh.cu",
        Password = "Encriptada",
        FirstName = "Miguel",
        LastName = "Gonzalez",
        NickName = "MiguelGonzalez",
        SignUpDate = _dateTime,
        User = _user,
        UserId = _user.Id,
        NewsPosts = new List<NewsPost>(),//Add in GetNewsPosts
        


    };

    public static List<Journalist> GetJournalists()
    {  
        return new List<Journalist>()
        {
            _journalist
        };
    }

    private static Moderator _moderator = new Moderator()
    {
        Id = 444,
        Email = "Miguelidvrsvto.uh.cu",
        Password = "Encriptada",
        FirstName = "Miguedvfdl",
        LastName = "Gonzalez",
        NickName = "MiguelGonzalez",
        SignUpDate = _dateTime,
        User = _user,
        UserId = _user.Id,
        AceptedComments = new List<PostComment>(),//Add in GetPostComments
        
        

    };

public static List<Moderator> GetModerators()
{
    GetFragments();
    
      // _moderator.AceptedComments = GetPostComments();
       return new List<Moderator>()
       {
           _moderator
       };
   }


private static BanUser _banUser = new BanUser()
{
    Id = 10,
    Email = "Miguelito.uh.cu",
    Password = "Encriptada",
    FirstName = "Miguel",
    LastName = "Gonzalez",
    NickName = "MiguelGonzalez",
    SignUpDate = _dateTime,
    User = _user,
    UserId = _user.Id,
    NoAccessDate = _dateTime,
    

};

public static List<BanUser>GetBanUsers()
   {
       return new List<BanUser>()
       {
           _banUser
       };
   }

private static void UpdateAdministrators()
{
     _journalist.NewsPosts = GetNewsPosts();
     _moderator.AceptedComments = GetPostComments();
}
  #endregion

  #region News and Post Domain
    // DEVS:Primero crear el fragmento despues actulizar su noticia correspondiente 
    private static Fragment _fragment = new Fragment()
    {
        Id = 1,
        fragment = "Esto es un fragmento",
        NewsPost = new NewsPost() ,//_newsPost,
        NewsPostId =-1, //_newsPost.Id,
        
    };
    public static List<Fragment> GetFragments()
    {
        return new List<Fragment>()
        {
            _fragment
        };
    }

    private static NewsPost _newsPost = new NewsPost()
    {
        Id = 1,
        fragments = new List<Fragment>(),// GetFragments(),
        Coments = new List<PostComment>(), // GetPostComments() Add in GetPostComments,
        PostDate = _dateTime,
        //Creator = _journalist,
        CreatorId = _journalist.Id,
        PostTitle = "Titulo de prueba",
       // RelatedEvent = _event,
        RelatedEventId = _event.Id,

    };

    public static List<NewsPost> GetNewsPosts()
    {
        _newsPost.Coments = GetPostComments();
        return new List<NewsPost>()
        {
            _newsPost
        };
    }
    
    private static PostComment _postComment = new PostComment()
    {
        Id = 1,
       // NewsPost = _newsPost,
        NewsPostId = _newsPost.Id,
        Contents = "Esto es un comentario de prueba",
        CommentDate = _dateTime,
       // ReviewBy = _moderator,
        ReviewById = _moderator.Id,
        ReviewDate = _dateTime,



    };

    public static List<PostComment> GetPostComments()
    {
        return new List<PostComment>()
        {
            _postComment
        };
    }





    private static void UpdateNewsPost()
    {
        //fragments
        _fragment.NewsPost = _newsPost;
        _fragment.NewsPostId = _newsPost.Id;
        
        //newsPost
        _newsPost.fragments = GetFragments();
        //Hacer primero los fragmentos
        _newsPost.Coments = GetPostComments();
        
    }

    #endregion





    #region Update Methods

    public static void Start()
    {
        //Update Category
        _category.Sports = GetSports();
        
        UpdateNewsPost();
        UpdateAdministrators();
       // UpdateLeaderBoard();
        UpdateMatchEvent();
        CallAllGets();
        
    }

    private static void CallAllGets()
    {
        GetLeaderboards();
        GetScores();
        GetLocations();
        GetFaculties();
        GetAthletes();
        GetSports();
        GetCategories();
        GetDisciplines();
        GetModalities();
        GetCompetitions();
        GetEvents();
        GetTeams();
        GetTeamMembers();
        GetNormalTeams();
        GetEventTeamParticipants();
        GetTeamParticipantScores();
        GetTeamCompositions();
        GetComposedTeams();
        GetTeamCompositionScores();
        GetTeamScores();
        GetTeamEvents();
        GetLeagues();
        GetGroups();
        GetGroupsEvents();
        GetGroupLines();
        GetMajors();
        GetParticipantScoredEvents();
        GetRepresentatives();
        GetTournaments();
        GetTournamentEvents();
    }

    #endregion
}




