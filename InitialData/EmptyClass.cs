using Data.Model;

namespace InitialData;

public class InitialDomainData
{

    private static DateTime _dateTime = new DateTime(1, 1, 2023);
    
    public static List<Faculty> GetFaculties()
    {
        return new List<Faculty>()
        {
            new Faculty {Id = 1, Name="Facultad de Artes y Letras", Acronym="FAyL", Mascot="Elefantes"},
            new Faculty {Id = 2, Name="Facultad de Biología", Acronym="Bio", Mascot="Gavilanes"},
            new Faculty {Id = 3, Name="Facultad de Comunicación", Acronym="FCOM", Mascot="Vikingos"},
            new Faculty {Id = 4, Name="Facultad Contabilidad y Finanzas", Acronym="CONFIN", Mascot="Lobos"},
            new Faculty {Id = 5, Name="Facultad de Derecho", Acronym="Lex", Mascot="Zorros"},
            new Faculty {Id = 6, Name="Facultad de Economía", Acronym="EKO", Mascot="Leones"},
            new Faculty {Id = 7, Name="Español para no Hispanohablantes", Mascot="Aplanadoras"},
            new Faculty {Id = 8, Name="Facultad de Filosofía, Historia y Sociología", Acronym="FHS", Mascot="Buhos"},
            new Faculty {Id = 9, Name="Facultad de Física", Acronym="Fis", Mascot="Tigres"},
            new Faculty {Id = 10, Name="Facultad de Geografía", Acronym="GEO", Mascot="Tiburones"},
            new Faculty {Id = 11, Name="Instituto de Farmacia y Alimentos", Acronym="IFAL", Mascot="Serpientes"},
            new Faculty {Id = 12, Name="Instituto de Ciencias y Tecnologías Aplicadas", Acronym="INSTEC", Mascot="Gatos"},
            new Faculty {Id = 13, Name="Instituto Superior de Diseño", Acronym="ISDi", Mascot="Mapaches"},
            new Faculty {Id = 14, Name="Facultad de Lenguas Extranjeras", Acronym="FLEX", Mascot="Panteras"},
            new Faculty {Id = 15, Name="Facultad de Matemática y Computación", Acronym="MATCOM", Mascot="Cuervos"},
            new Faculty {Id = 16, Name="Facultad de Psicología", Acronym="Psico", Mascot="Fenix"},
            new Faculty {Id= 17, Name="Facultad de Química", Acronym="Qui", Mascot="Pumas"},
            new Faculty {Id = 18, Name="Facultad de Turismo", Acronym="FTur", Mascot="Aviones"}
        };
    }

    public static List<LeaderboardLine> GetLeaderboardLines()
    {
        return new List<LeaderboardLine>()
        {
            new LeaderboardLine {Id = 1, FacultyId = 15, GoldMedals=12, SilverMedals=5, BronzeMedals =3, Ranking = 1, Year = 2023}
        };
    }

//New Implementation
    private static Faculty _faculty = GetFaculties()[0];
    private static LeaderboardLine _leaderboardLine = GetLeaderboardLines()[0];
    private static Athlete _athlete = new Athlete()
    {
        Id = 1, Nick = "Paco ", Name = "Francisco Suarez", Photo = "kmvkm", DateOfBirth = new DateTime(1, 1, 1)
        
    };
    public static List<Athlete> GetAthletes()
    {
        return new List<Athlete>()
        {
            
        };
    }

    private static Category _categrory = new Category()
        { Id = 1, Name = "Acuaticos", Sports = null /*Add in GetSports*/ };
    public static List<Category> GetCategories()
    {
        return new List<Category>()
        {
           _categrory
        };
    }

    private static Sport _sport = new Sport()
    {
        Id = 1, Name = "Natación", Description = "Natación normal",
        Pictogram = "kmvkv", Rules = "Reglas", CategoryId = 1, Category = GetCategories().Find(e => e.Id == 1)

    };
    public static List<Sport> GetSports()
    {
        var result = new List<Sport>()
        {
            _sport
        };
        _categrory.Sports = result;
        return result;
       
    }

    private static Discipline _discipline = new Discipline() { SportId = 1, Sport = _sport, Name = "Acuatica",Id = 1};
    public static List<Discipline> GetDisciplines()
    {
        return new List<Discipline>()
        {
           _discipline
        };
    }

    private static Modality _modality = new Modality()
    {
        CategoryId = 1, Category = _categrory, Sport = _sport, SportId = 1, Discipline = _discipline, DisciplineId = 1,
        Sex = "Mas",Id = 1

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
        Id = 1, Year = 2023, ModalityId = _modality.Id, Modality = _modality
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
        Id = 1, Name = "Ceder", Address = "Universidad de la Habana", GoogleMapsURL = "kckdkdk"
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
        Id = 1, Type = "Evento normal", DateTime = new DateTime(1, 1, 2023),
        LocationId = _location.Id,
        Location = _location
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
        Id = 1, FacultyId = _faculty.Id, Faculty = _faculty
    };
    public static List<Team>GetTeams()
    {
        return new List<Team>()
        {
           _team
        };
    }
    
    private static TeamMember _teamMember= new TeamMember(){Athlete = _athlete,AthleteId = _athlete.Id,Id = 1,Team = _team,TeamId = _team.Id,Role = "Campeón"
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
        Id = 1, FacultyId = _faculty.Id, Faculty = _faculty,
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
        Id = 1, Event = _event, EventId = _event.Id, TeamId = _team.Id, Team = _normalTeam, Participant = _teamMember,
        ParticipantId = _teamMember.Id
    };
public static List<EventTeamParticipant>GetEventTeamParticipants()
    {
        return new List<EventTeamParticipant>()
        {
           _eventTeamParticipant
        };
    }

private static TeamParticipantScore _teamParticipantScore = new TeamParticipantScore()
{
    Id = 1,
 Participant = _eventTeamParticipant,
 ParticipantId = _eventTeamParticipant.Id,
 TeamId = _normalTeam.Id,
 Team = _normalTeam,
 
 EventId = _event.Id,
 Event = _event,
 Score = _score,
 ScoreId = _score.ScoreId,
 
 
};
public static List<TeamParticipantScore> GetTeamParticipantScores()
{
    return new List<TeamParticipantScore>()
    {
        
        _teamParticipantScore
    };
}

private static TeamComposition? _teamComposition = new TeamComposition()
{
    Id = 1,
    Participants = GetTeamMembers(),


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
    Id = 1,
    FacultyId = _faculty.Id,
    Faculty = _faculty,
    Compositions = GetTeamCompositions(),
    

};
public static List<ComposedTeam>GetComposedTeams()
{
    return new List<ComposedTeam>()
    {
        _composedTeam
    };
}


private static TeamCompositionScore _teamCompositionScore=new TeamCompositionScore()
{
    Composition=_teamComposition,
    CompositionId = _teamComposition.Id,
    ScoreId = _score.ScoreId,
    Score = _score,
    

};

public static List<TeamCompositionScore>_TeamCompositionScores()
{
    return new List<TeamCompositionScore>()
    {
        
        _teamCompositionScore
    };
}


private static TeamScore _teamScore=new TeamScore()
{
    Score = _score,
    ScoreId = _score.ScoreId,
    Team = _normalTeam,
    TeamId = _normalTeam.Id,
}
public static List<TeamScore>GetTeamScores()
{
    return new List<TeamScore>()
    {
        _teamScore
    };
}




private static TeamEvent _teamEvent = new TeamEvent()
{
    Id = 1,
    Location = _location,
    LocationId = _location.Id,
    Type = "Ninguno",
    DateTime = _dateTime,
    TeamSubstitutes = GetEventTeamParticipants(),
    TeamParticipants = GetEventTeamParticipants(),
    TeamScores = GetTeamScores(),
    
};
public static List<TeamEvent>GetTeamEvents()
{
    return new List<TeamEvent>()
    {
        
        _teamEvent
    };
}










#endregion

private static Score _score = new Score()
{
    NumberScore = 3.2f,
    ScoreId = 1
   
};
public static List<Score> GetScores()
{
    return new List<Score>()
    {
        _score
    };
}


private static League _league = new League()
{
    Id = 1, Locations = GetLocations(), Rounds = 1, StartDate = _dateTime,
    EndDate =_dateTime
};
private static List<League> GetLeagues()
{
    return new List<League>()
    {
        _league
    };
}


private static Group _group = new Group()
{
    Id = 1,League = _league,LeagueId = _league.Id,Round = 1
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
   Event = _event,
   Group = _group,
   GroupId = _group.Id,
   

  };
  public static List<GroupEvent>GetGroupsEvents()
  {
      return new List<GroupEvent>()
      {
         _groupEvent
      };
  }
  
  private static GroupLine _groupLine= new GroupLine()
  {
      Id = 1,
      Group = _group,
      GroupId = _group.Id,
      Team = _normalTeam,
      TeamId = _normalTeam.Id,
      Position = 1,
      AthleteId = _athlete.Id,
      Athlete = _athlete,
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

  private static Leaderboard? _leaderboard = new Leaderboard()
  {
      Id = 1,
      Year = 2023,
      LeaderboardLines = GetLeaderboardLines(),
  };
  public static List<Leaderboard> GetLeaderboards()
  {
      return new List<Leaderboard>()
      {
        _leaderboard,
        
        
      };
  }

  private static Major _major = new Major()
  {
    Id = 1,
    FacultyId = _faculty.Id,
    Faculty = _faculty,
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
      ParticipantScores = GetTeamParticipantScores(),


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
    Location = _location,
    DateTime = _dateTime,
    Matches = GetMatches(),
    LocationId = _location.Id,
    Type = "Ninguno",
    Teams = GetNormalTeams(),
    
  };
  public static List<MatchEvent> GetMatchEvents()
  {
      return new List<MatchEvent>()
      {
        _matchEvent
      };
  }
  
  #endregion

  private static ParticipantScoredEvent _participantScoredEvent = new ParticipantScoredEvent()
  {
   Id = 1,
   Location = _location,
   DateTime = _dateTime,
   Type = "Ninguno",
   LocationId = _location.Id,
   ParticipantScores = GetTeamParticipantScores(),
   TeamSubstitutes = GetEventTeamParticipants(),
   ParticipantScoredTeams = GetNormalTeams(),
   
  };
  public static List<ParticipantScoredEvent>GetParticipantScoredEvents()
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
      Athlete = _athlete,
      AthleteId = _athlete.Id,
      Faculty = _faculty,
      Year = 2023,
      Major = _major,
      MajorId = _major.Id

  };
  
  public static List<Representative>GetRepresentatives()
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
      Locations = GetLocations(),
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
      Event = _event,
      EventId = _event.Id,
      Round = 3,
      Tournament = _tournament,
      TournamentId = _tournament.Id
  };
  public static List<TournamentEvent>GetTournamentEvents()
  {
      return new List<TournamentEvent>()
      {
          _tournamentEvent
      };
  }
  #endregion
  
  
  
}




