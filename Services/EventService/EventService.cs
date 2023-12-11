using Data.DTO;
using Data.DTO.In;
using Data.DTO.Out;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services.Domain;

public class EventService : IEventService
{
    private readonly IDataRepository _repository;

    public EventService(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<EventDto>> GetAllEvents()
    {
        var events = _repository.Set<Event>()
            .Include(e => e.Location)
            .Include(e => e.SportModality);

        if (!events.Any())
            return Task.FromResult<IEnumerable<EventDto>>(Array.Empty<EventDto>());

        var teamEvents = events.OfType<TeamEvent>()
            .Include(e => e.TeamScores)
            .ThenInclude(s => s.Team)
            .ThenInclude(t => t.Members)
            .ThenInclude(m => m.Athlete)
            .Include(e => e.TeamScores)
            .ThenInclude(s => s.Score)
            .Include(e => e.TeamParticipants)
            .ThenInclude(p => p.Participant)
            .Include(e => e.TeamSubstitutes)
            .ThenInclude(p => p.Substitute);

        var composedEvents = events.OfType<ComposedTeamsEvent>()
            .Include(e => e.ComposedTeams)
            .ThenInclude(t => t.Compositions)
            .ThenInclude(c => c.Participants)
            .ThenInclude(p => p.Athlete)
            .Include(e => e.ComposedTeamScores)
            .ThenInclude(s => s.Score);

        var participantScoredEvents = events.OfType<ParticipantScoredEvent>()
            .Include(e => e.ParticipantScoredTeams)
            .ThenInclude(t => t.Members)
            .ThenInclude(m => m.Athlete)
            .Include(e => e.ParticipantScores)
            .ThenInclude(s => s.Score)
            .Include(e => e.ParticipantScores)
            .ThenInclude(s => s.Participant)
            .ThenInclude(p => p.Athlete)
            .Include(e => e.TeamSubstitutes)
            .ThenInclude(s => s.Substitute)
            .ThenInclude(p => p.Athlete);

        var matchEvents = events.OfType<MatchEvent>();

        var eventDtos = new List<EventDto>();

        eventDtos.AddRange(teamEvents.Select(e => new EventDto
        {
            Id = e.Id,
            Type = "TeamScored",
            DateTime = e.DateTime,
            Location = LocationDto.FromEntity(e.Location),
            TeamScores = from s in e.TeamScores
                let teamMembers = s.Team.Members
                let teamParticipants = e.TeamParticipants.Where(p => p.TeamId == s.TeamId)
                    .Select(p => p.Participant)
                let teamSubstitutes = e.TeamSubstitutes.Where(p => p.TeamId == s.TeamId)
                    .Select(p => p.Substitute)
                let normalTeamDto = NormalTeamDto.FromEntity(teamMembers, teamParticipants, teamSubstitutes, s.TeamId,
                    s.Team.FacultyId)
                select new TeamScoreDto
                {
                    Team = normalTeamDto, Score = new ScoreDto { Id = s.ScoreId, NumberScore = s.Score.NumberScore }
                },
            SportModality = SportModalityDto.FromEntity(e.SportModality)
        }));

        eventDtos.AddRange(composedEvents.Select(e => new EventDto
        {
            Id = e.Id,
            Type = "Composed",
            DateTime = e.DateTime,
            Location = LocationDto.FromEntity(e.Location),
            ComposedTeams = from c in e.ComposedTeams
                select new ComposedTeamDto
                {
                    Id = c.Id,
                    FacultyId = c.FacultyId,
                    Compositions = from composition in c.Compositions
                        let participants = composition.Participants
                        select new CompositionDto
                        {
                            Id = composition.Id,
                            Participants = from participant in participants
                                select TeamMemberDto.FromEntity(participant)
                        }
                },
            CompositionScores = from s in e.ComposedTeamScores
                select new TeamCompositionScoreDto
                {
                    Score = ScoreDto.FromEntity(s.Score),
                    CompositionId = s.CompositionId
                },
            SportModality = SportModalityDto.FromEntity(e.SportModality)
        }));

        eventDtos.AddRange(participantScoredEvents.Select(e => new EventDto
        {
            Id = e.Id,
            Type = "ParticipantScored",
            DateTime = e.DateTime,
            Location = LocationDto.FromEntity(e.Location),
            ParticipantScoredTeams = from t in e.ParticipantScoredTeams
                let teamMembers = t.Members
                let teamParticipants = e.ParticipantScores.Where(s => s.TeamId == t.Id)
                    .Select(s => s.Participant)
                let teamSubstitutes = e.TeamSubstitutes.Where(s => s.TeamId == t.Id)
                    .Select(s => s.Substitute)
                select NormalTeamDto.FromEntity(teamMembers, teamParticipants, teamSubstitutes, t.Id, t.FacultyId),
            ParticipantScores = from s in e.ParticipantScores
                select new TeamParticipantScoreDto
                {
                    ParticipantId = s.ParticipantId,
                    Score = ScoreDto.FromEntity(s.Score)
                },
            SportModality = SportModalityDto.FromEntity(e.SportModality)
        }));

        eventDtos.AddRange(matchEvents.Select(e => new EventDto
        {
            Id = e.Id,
            Type = "MatchEvent",
            DateTime = e.DateTime,
            Location = LocationDto.FromEntity(e.Location),
            MatchEventTeams = from t in e.MatchedTeams
                let members = t.Members
                let participants =
                    from m in e.Matches
                    from p in m.ParticipantScores
                    where p.TeamId == t.Id
                    select p.Participant
                select NormalTeamDto.FromEntity(members, participants, null, t.Id, t.FacultyId),
            Matches = from m in e.Matches
                select new MatchDto
                {
                    Id = m.Id,
                    ParticipantScores = from p in m.ParticipantScores
                        select new TeamParticipantScoreDto
                        {
                            ParticipantId = p.ParticipantId,
                            Score = ScoreDto.FromEntity(p.Score)
                        }
                },
            SportModality = SportModalityDto.FromEntity(e.SportModality)
        }));

        return Task.FromResult<IEnumerable<EventDto>>(eventDtos.OrderBy(e => e.DateTime));
    }

//TODO: check for members,participant and substitutes
    public Task<EventDto?> GetEvent(int id)
    {
        var @event = _repository.Set<Event>()
            .Include(e => e.Location)
            .Include(e => e.SportModality)
            .FirstOrDefault(e => e.Id == id);

        if (@event == null)
            return Task.FromResult<EventDto?>(null);

        switch (@event.Type)
        {
            case "TeamScored":
                var teamEvent = _repository.Set<TeamEvent>()
                    .Include(e => e.TeamScores)
                    .ThenInclude(s => s.Team)
                    .ThenInclude(t => t.Members)
                    .ThenInclude(m => m.Athlete)
                    .Include(e => e.TeamScores)
                    .ThenInclude(s => s.Score)
                    .Include(e => e.TeamParticipants)
                    .ThenInclude(p => p.Participant)
                    .Include(e => e.TeamSubstitutes)
                    .ThenInclude(p => p.Substitute)
                    .FirstOrDefault(e => e.Id == id);
                if (teamEvent == null)
                    return Task.FromResult<EventDto?>(null);

                return Task.FromResult<EventDto?>(new EventDto
                {
                    Id = teamEvent.Id,
                    Type = "TeamScored",
                    DateTime = teamEvent.DateTime,
                    Location = LocationDto.FromEntity(teamEvent.Location),
                    TeamScores = teamEvent.TeamScores.Select(s =>
                        TeamScoreDto.FromEntity(NormalTeamDto.FromEntity(s.Team.Members, teamEvent.TeamParticipants
                                .Where(p => p.TeamId == s.TeamId)
                                .Select(p => p.Participant), teamEvent.TeamSubstitutes.Where(p => p.TeamId == s.TeamId)
                                .Select(p => p.Substitute), s.TeamId, s.Team.FacultyId),
                            ScoreDto.FromEntity(s.Score))),
                    SportModality = SportModalityDto.FromEntity(teamEvent.SportModality)
                });
            case "Composed":
                var composedEvent = _repository.Set<ComposedTeamsEvent>()
                    .Include(e => e.ComposedTeams)
                    .ThenInclude(t => t.Compositions)
                    .ThenInclude(c => c.Participants)
                    .ThenInclude(p => p.Athlete)
                    .Include(e => e.ComposedTeamScores)
                    .ThenInclude(s => s.Score)
                    .FirstOrDefault(e => e.Id == id);

                if (composedEvent == null)
                    return Task.FromResult<EventDto?>(null);

                return Task.FromResult<EventDto?>(new EventDto
                {
                    Id = composedEvent.Id,
                    Type = "Composed",
                    DateTime = composedEvent.DateTime,
                    Location = LocationDto.FromEntity(composedEvent.Location),
                    ComposedTeams = composedEvent.ComposedTeams.Select(ComposedTeamDto.FromEntity)
                });
            case "ParticipantScored":
                var participantScoredEvent = _repository.Set<ParticipantScoredEvent>()
                    .Include(e => e.ParticipantScoredTeams)
                    .ThenInclude(t => t.Members)
                    .ThenInclude(m => m.Athlete)
                    .Include(e => e.ParticipantScores)
                    .ThenInclude(s => s.Score)
                    .Include(e => e.ParticipantScores)
                    .ThenInclude(s => s.Participant)
                    .ThenInclude(p => p.Athlete)
                    .Include(e => e.TeamSubstitutes)
                    .ThenInclude(s => s.Substitute)
                    .ThenInclude(p => p.Athlete)
                    .FirstOrDefault(e => e.Id == id);

                if (participantScoredEvent == null)
                    return Task.FromResult<EventDto?>(null);

                return Task.FromResult<EventDto?>(new EventDto
                {
                    Id = participantScoredEvent.Id,
                    Type = "ParticipantScored",
                    DateTime = participantScoredEvent.DateTime,
                    Location = LocationDto.FromEntity(participantScoredEvent.Location),
                    ParticipantScoredTeams = participantScoredEvent.ParticipantScoredTeams.Select(t =>
                        NormalTeamDto.FromEntity(t.Members, participantScoredEvent.ParticipantScores
                            .Where(s => s.TeamId == t.Id)
                            .Select(s => s.Participant), participantScoredEvent.TeamSubstitutes
                            .Where(s => s.TeamId == t.Id)
                            .Select(s => s.Substitute), t.Id, t.FacultyId)),
                    ParticipantScores =
                        participantScoredEvent.ParticipantScores.Select(TeamParticipantScoreDto.FromEntity),
                    SportModality = SportModalityDto.FromEntity(participantScoredEvent.SportModality)
                });
            case "MatchEvent":
                var matchEvent = _repository.Set<MatchEvent>()
                    .Include(e => e.MatchedTeams)
                    .ThenInclude(t => t.Members)
                    .ThenInclude(m => m.Athlete)
                    .Include(e => e.Matches)
                    .ThenInclude(m => m.ParticipantScores)
                    .ThenInclude(s => s.Score)
                    .Include(e => e.Matches)
                    .ThenInclude(m => m.ParticipantScores)
                    .ThenInclude(s => s.Participant)
                    .ThenInclude(p => p.Athlete)
                    .FirstOrDefault(e => e.Id == id);

                if (matchEvent == null)
                    return Task.FromResult<EventDto?>(null);

                return Task.FromResult<EventDto?>(new EventDto
                {
                    Id = matchEvent.Id,
                    Type = "MatchEvent",
                    DateTime = matchEvent.DateTime,
                    Location = LocationDto.FromEntity(matchEvent.Location),
                    MatchEventTeams = matchEvent.MatchedTeams.Select(t =>
                        NormalTeamDto.FromEntity(t.Members, null, null, t.Id, t.FacultyId)),
                    Matches = matchEvent.Matches.Select(MatchDto.FromEntity),
                    SportModality = SportModalityDto.FromEntity(matchEvent.SportModality)
                });
            default:
                return Task.FromException<EventDto?>(new ArgumentException("Invalid event type"));
        }
    }

    public async Task<int> PostEvent(CreateEventDto eventDto)
    {
        var location = _repository.Set<Location>().FirstOrDefault(l => l.Id == eventDto.LocationId);
        var id = -1;
        switch (eventDto.Type)
        {
            case "TeamScored":
                var teamScoredScore = new Score { NumberScore = 0 };

                var team = new TeamEvent
                {
                    Type = eventDto.Type,
                    LocationId = eventDto.LocationId,
                    Location = location,
                    DateTime = eventDto.DateTime,
                    SportModalityId = eventDto.SportModalityId,
                    SportModality = _repository.Set<Modality>()
                        .FirstOrDefault(m => m.Id == eventDto.SportModalityId)
                };

                await _repository.Set<Score>().Create(teamScoredScore);
                await _repository.Set<Event>().Create(team);

                team.TeamScores = eventDto.TeamEventTeamIds.Select(t => new TeamEventScore
                {
                    EventId = team.Id,
                    Event = team,
                    TeamId = t,
                    Team = _repository.Set<NormalTeam>().FirstOrDefault(n => n.Id == t),
                    ScoreId = teamScoredScore.Id,
                    Score = teamScoredScore
                });
                team.TeamParticipants = eventDto.TeamEventTeamParticipantTupleId.Select(p =>
                    CreateEventTeamParticipant(team.Id, p.Item1, p.Item2));
                team.TeamSubstitutes = eventDto.TeamEventTeamSubstitutesTupleId.Select(s =>
                    CreateEventTeamSubstitute(team.Id, s.Item1, s.Item2));

                await _repository.Set<TeamEvent>().Create(team);
                id = team.Id;
                break;
            case "Composed":

                var composedScore = new Score { NumberScore = 0 };

                await _repository.Set<Score>().Create(composedScore);

                var composedTeamsEvent = new ComposedTeamsEvent
                {
                    Type = eventDto.Type,
                    LocationId = eventDto.LocationId,
                    Location = location,
                    DateTime = eventDto.DateTime,
                    ComposedTeams = _repository.Set<ComposedTeam>()
                        .Where(t => eventDto.ComposedTeamsId.Contains(t.Id)),
                    ComposedTeamScores = eventDto.ComposedTeamCompositionId.Select(c => new TeamCompositionScore
                    {
                        CompositionId = c,
                        Composition = _repository.Set<TeamComposition>().FirstOrDefault(t => t.Id == c),
                        ScoreId = composedScore.Id,
                        Score = composedScore
                    }),
                    SportModalityId = eventDto.SportModalityId,
                    SportModality = _repository.Set<Modality>()
                        .FirstOrDefault(m => m.Id == eventDto.SportModalityId)
                };

                await _repository.Set<ComposedTeamsEvent>().Create(composedTeamsEvent);
                id = composedTeamsEvent.Id;
                break;
            case "ParticipantScored":

                var participantScoredEvent = new ParticipantScoredEvent
                {
                    Type = eventDto.Type,
                    LocationId = eventDto.LocationId,
                    Location = location,
                    DateTime = eventDto.DateTime,
                    ParticipantScoredTeams = _repository.Set<NormalTeam>()
                        .Where(t => eventDto.ParticipantScoredId.Any(p => p == t.Id)),
                    SportModalityId = eventDto.SportModalityId,
                    SportModality = _repository.Set<Modality>()
                        .FirstOrDefault(m => m.Id == eventDto.SportModalityId)
                };
                await _repository.Set<Event>().Create(participantScoredEvent);

                var teamScore = new Score { NumberScore = 0 };
                await _repository.Set<Score>().Create(teamScore);


                participantScoredEvent.ParticipantScores = eventDto.ParticipantScoredTeamParticipantTupleId.Select(p =>
                    new TeamParticipantScore
                    {
                        EventId = participantScoredEvent.Id,
                        TeamId = p.Item1,
                        ParticipantId = p.Item2,
                        Participant = _repository.Set<TeamMember>().FirstOrDefault(t => t.Id == p.Item2),
                        ScoreId = teamScore.Id,
                        Score = teamScore
                    });
                participantScoredEvent.TeamSubstitutes = eventDto.ParticipantScoredTeamSubstitutesTupleId.Select(s =>
                    new ParticipantScoredEventSubstitute
                    {
                        EventId = participantScoredEvent.Id,
                        TeamId = s.Item1,
                        SubstituteId = s.Item2,
                        Substitute = _repository.Set<TeamMember>().FirstOrDefault(t => t.Id == s.Item2)
                    });

                await _repository.Set<ParticipantScoredEvent>().Create(participantScoredEvent);
                id = participantScoredEvent.Id;
                break;
            case "MatchEvent":
                var match = new MatchEvent
                {
                    Type = eventDto.Type,
                    LocationId = eventDto.LocationId,
                    Location = location,
                    DateTime = eventDto.DateTime,
                    MatchedTeams = _repository.Set<NormalTeam>()
                        .Where(t => eventDto.MatchTeamIds.Any(p => p == t.Id)),
                    Matches = _repository.Set<Match>().Where(m => eventDto.MatchIds.Any(p => p == m.Id)),
                    SportModalityId = eventDto.SportModalityId,
                    SportModality = _repository.Set<Modality>()
                        .FirstOrDefault(m => m.Id == eventDto.SportModalityId)
                };
                await _repository.Set<MatchEvent>().Create(match);
                id = match.Id;
                break;
        }

        await _repository.Save(default);
        return id;
    }

    public Task DeleteEvent(int id)
    {
        var existingEvent = _repository.Set<Event>().FirstOrDefault(e => e.Id == id);

        if (existingEvent == null)
            throw new ArgumentException("Event not found");

        _repository.Set<Event>().Remove(existingEvent);
        return _repository.Save(default);
    }

    public Task UpdateEvent(int id, CreateEventDto eventDto)
    {
        var existingEvent = _repository.Set<Event>().FirstOrDefault(e => e.Id == id);

        if (existingEvent == null)
            throw new ArgumentException("Event not found");

        existingEvent.Type = eventDto.Type;
        existingEvent.DateTime = eventDto.DateTime;
        existingEvent.LocationId = eventDto.LocationId;
        existingEvent.SportModalityId = eventDto.SportModalityId;

        switch (eventDto.Type)
        {
            case "TeamScored":
                if (existingEvent is TeamEvent teamEvent)
                {
                    teamEvent.TeamScores = eventDto.TeamEventTeamIds.Select(t => new TeamEventScore
                    {
                        EventId = teamEvent.Id,
                        TeamId = t,
                        ScoreId = _repository.Set<Score>().FirstOrDefault(s => s.Id == t).Id
                    }).ToList();
                    teamEvent.TeamParticipants = eventDto.TeamEventTeamParticipantTupleId.Select(p =>
                        CreateEventTeamParticipant(teamEvent.Id, p.Item1, p.Item2)).ToList();
                    teamEvent.TeamSubstitutes = eventDto.TeamEventTeamSubstitutesTupleId.Select(s =>
                        CreateEventTeamSubstitute(teamEvent.Id, s.Item1, s.Item2)).ToList();
                }

                break;
            case "Composed":
                if (existingEvent is ComposedTeamsEvent composedEvent)
                {
                    composedEvent.ComposedTeams = _repository.Set<ComposedTeam>()
                        .Where(t => eventDto.ComposedTeamsId.Contains(t.Id)).ToList();
                    composedEvent.ComposedTeamScores = eventDto.ComposedTeamCompositionId.Select(c =>
                        new TeamCompositionScore
                        {
                            CompositionId = c,
                            ScoreId = _repository.Set<Score>().FirstOrDefault(s => s.Id == c).Id
                        }).ToList();
                }

                break;
            case "ParticipantScored":
                if (existingEvent is ParticipantScoredEvent participantScoredEvent)
                {
                    participantScoredEvent.ParticipantScoredTeams = _repository.Set<NormalTeam>()
                        .Where(t => eventDto.ParticipantScoredId.Contains(t.Id)).ToList();
                    participantScoredEvent.ParticipantScores = eventDto.ParticipantScoredTeamParticipantTupleId.Select(
                        p =>
                            new TeamParticipantScore
                            {
                                EventId = participantScoredEvent.Id,
                                TeamId = p.Item1,
                                ParticipantId = p.Item2,
                                ScoreId = _repository.Set<Score>().FirstOrDefault(s => s.Id == p.Item1).Id
                            }).ToList();
                    participantScoredEvent.TeamSubstitutes = eventDto.ParticipantScoredTeamSubstitutesTupleId.Select(
                        s =>
                            new ParticipantScoredEventSubstitute
                            {
                                EventId = participantScoredEvent.Id,
                                TeamId = s.Item1,
                                SubstituteId = s.Item2
                            }).ToList();
                }

                break;
            case "MatchEvent":
                if (existingEvent is MatchEvent matchEvent)
                {
                    matchEvent.MatchedTeams = _repository.Set<NormalTeam>()
                        .Where(t => eventDto.MatchTeamIds.Contains(t.Id)).ToList();
                    matchEvent.Matches = _repository.Set<Match>().Where(m => eventDto.MatchIds.Contains(m.Id)).ToList();
                }

                break;
            default:
                throw new ArgumentException("Invalid event type");
        }

        _repository.Set<Event>().Update(existingEvent);
        return _repository.Save(default);
    }

    private TeamEventParticipant CreateEventTeamParticipant(int eventId, int teamId, int participantId)
    {
        var team = _repository.Set<NormalTeam>().FirstOrDefault(t => t.Id == teamId);
        var @event = _repository.Set<TeamEvent>().FirstOrDefault(e => e.Id == eventId);
        var participant = _repository.Set<TeamMember>().FirstOrDefault(p => p.Id == participantId);
        return new TeamEventParticipant
        {
            EventId = eventId,
            TeamId = teamId,
            ParticipantId = participantId,
            Event = @event,
            Team = team,
            Participant = participant
        };
    }

    private EventTeamSubstitute CreateEventTeamSubstitute(int eventId, int teamId, int substituteId)
    {
        var team = _repository.Set<NormalTeam>().FirstOrDefault(t => t.Id == teamId);
        var @event = _repository.Set<TeamEvent>().FirstOrDefault(e => e.Id == eventId);
        var substitute = _repository.Set<TeamMember>().FirstOrDefault(p => p.Id == substituteId);
        return new EventTeamSubstitute
        {
            EventId = eventId,
            TeamId = teamId,
            SubstituteId = substituteId,
            Event = @event,
            Team = team,
            Substitute = substitute
        };
    }
}