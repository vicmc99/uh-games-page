using Data.DTO;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain;

public class EventService : IEventService
{
    private readonly IDataRepository _repository;

    public EventService(IDataRepository repository)
    {
        _repository = repository;
    }

    public EventDto[] Get()
    {
        var events = _repository.Set<Event>().ToArray();
        if (events.Length == 0)
            return Array.Empty<EventDto>();
        var eventDtos = new EventDto[events.Length];
        for (var i = 0; i < events.Length; i++)
        {
            eventDtos[i] = new EventDto
            {
                Id = events[i].Id,
                Type = events[i].Type,
                DateTime = events[i].DateTime,
                Location = new LocationDto
                {
                    Id = events[i].Location.Id,
                    Name = events[i].Location.Name,
                    Address = events[i].Location.Address,
                    GoogleMapsUrl = events[i].Location.GoogleMapsURL
                }
            };
            switch (eventDtos[i].Type)
            {
                //TODO: Set Where LINQ to match from ID's. Review ID's en DB. EventDTO have not way to connect with other clases.
                case "Composed":

                    //Fill ComposedTeams param
                    var composedTeams = _repository.Set<ComposedTeam>().ToArray();
                    eventDtos[i].ComposedTeams = composedTeams.Select(composedTeam => new ComposedTeamDto
                    {
                        Id = composedTeam.Id,
                        FacultyId = composedTeam.FacultyId,
                        Compositions = composedTeam.Compositions.Select(composition => new CompositionDto
                        {
                            Id = composition.Id,
                            Participant = composition.Participants.Select(participant => new TeamMemberDto
                            {
                                Id = participant.Id,
                                Team = new TeamDto
                                {
                                    //Id = participant.Team.Id,
                                    FacultyId =5
                                },
                                Athlete = new AthleteDto
                                {
                                    Id = participant.AthleteId,
                                    Name = participant.Athlete.Name,
                                    Nick = participant.Athlete.Nick,
                                    Photo = participant.Athlete.Photo,
                                    DateOfBirth = participant.Athlete.DateOfBirth
                                },
                                Role = participant.Role
                            })
                        })
                    });

                    //Fill CompositionScores params
                    var compositionScores = _repository.Set<TeamCompositionScore>().ToArray();
                    eventDtos[i].CompositionScores = compositionScores.Select(compositionScore =>
                        new TeamCompositionScoreDto
                        {
                            CompositionId = compositionScore.CompositionId,
                            Score = new ScoreDto
                            {
                                Id = compositionScore.ScoreId,
                                NumberScore = compositionScore.Score.NumberScore
                            }
                        });

                    break;
                case "ParticipantScored":
                    var participantScoredTeam = _repository.Set<NormalTeam>().ToArray();
                    eventDtos[i].ParticipantScoredTeams = participantScoredTeam.Select(normalTeam =>
                        new NormalTeamDto
                        {
                            Id = normalTeam.Id,
                            FacultyId = normalTeam.FacultyId,
                            Members = normalTeam.Members.Where(m => m.Role == "Member").Select(member =>
                                new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                }),
                            Participants = normalTeam.Members.Where(member => member.Role == "Participant")
                                .Select(member => new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                }),
                            Substitutes = normalTeam.Members.Where(member => member.Role == "Substitute")
                                .Select(member => new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                })
                        });
                    var participantScoredScores = _repository.Set<TeamParticipantScore>().ToArray();
                    eventDtos[i].ParticipantScores = participantScoredScores.Select(participantScore =>
                        new TeamParticipantScoreDto
                        {
                            ParticipantId = participantScore.ParticipantId,
                            Score = new ScoreDto
                            {
                                Id = participantScore.ScoreId,
                                NumberScore = participantScore.Score.NumberScore
                            }
                        });
                    break;
                case "TeamScored":
                    var teamScores = _repository.Set<TeamScore>().ToArray();
                    eventDtos[i].TeamScores = teamScores.Select(teamScore => new TeamScoreDto
                    {
                        Team = new NormalTeamDto
                        {
                            FacultyId = teamScore.Team.FacultyId,
                            Id = teamScore.Team.Id,
                            Members = teamScore.Team.Members.Where(t => t.Role == "Member").Select(member =>
                                new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                }),
                            Participants = teamScore.Team.Members.Where(t => t.Role == "Participant").Select(member =>
                                new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                }),
                            Substitutes = teamScore.Team.Members.Where(t => t.Role == "Substitute").Select(member =>
                                new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                })
                        },
                        Score = new ScoreDto
                        {
                            Id = teamScore.ScoreId,
                            NumberScore = teamScore.Score.NumberScore
                        }
                    });
                    break;
                case "MatchEvent":
                    var matchEventTeams = _repository.Set<NormalTeam>().ToArray();
                    eventDtos[i].MatchEventTeams = matchEventTeams.Select(normalTeam =>
                        new NormalTeamDto
                        {
                            Id = normalTeam.Id,
                            FacultyId = normalTeam.FacultyId,
                            Members = normalTeam.Members.Where(m => m.Role == "Member").Select(member =>
                                new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                }),
                            Participants = normalTeam.Members.Where(member => member.Role == "Participant")
                                .Select(member => new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                }),
                            Substitutes = normalTeam.Members.Where(member => member.Role == "Substitute")
                                .Select(member => new TeamMemberDto
                                {
                                    Id = member.Id,
                                    Team = new TeamDto
                                    {
                                        Id = member.Team.Id,
                                        FacultyId = member.Team.FacultyId
                                    },
                                    Athlete = new AthleteDto
                                    {
                                        Id = member.AthleteId,
                                        Name = member.Athlete.Name,
                                        Nick = member.Athlete.Nick,
                                        Photo = member.Athlete.Photo,
                                        DateOfBirth = member.Athlete.DateOfBirth
                                    },
                                    Role = member.Role
                                })
                        });
                    var matches = _repository.Set<Match>().ToArray();
                    eventDtos[i].Matches = matches.Select(match => new MatchDto
                    {
                        Id = match.MatchId,
                        ParticipantScores = match.ParticipantScores.Select(participantScore =>
                            new TeamParticipantScoreDto
                            {
                                ParticipantId = participantScore.ParticipantId,
                                Score = new ScoreDto
                                {
                                    Id = participantScore.ScoreId,
                                    NumberScore = participantScore.Score.NumberScore
                                }
                            })
                    });
                    break;
            }
        }

        var sortedList = eventDtos.ToList();
        sortedList.Sort((x, y) => x.DateTime.CompareTo(y.DateTime));
        return sortedList.ToArray();
    }
}