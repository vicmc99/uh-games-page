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

    public IEnumerable<EventDto> Get()
    {
        var events = _repository.Set<Event>()
            .Include(e => e.Location);

        if (!events.Any())
            return Array.Empty<EventDto>();

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
                let normalTeamDto = CreateNormalTeamDto(teamMembers, teamParticipants, teamSubstitutes, s.TeamId,
                    s.Team.FacultyId)
                select new TeamScoreDto
                {
                    Team = normalTeamDto, Score = new ScoreDto { Id = s.ScoreId, NumberScore = s.Score.NumberScore }
                },
            SportModality = SportModalityDto.FromEntity(e.SportModality),
            SportModalityId = e.SportModalityId
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
            SportModality = SportModalityDto.FromEntity(e.SportModality),
            SportModalityId = e.SportModalityId
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
                select CreateNormalTeamDto(teamMembers, teamParticipants, teamSubstitutes, t.Id,
                    t.FacultyId),
            ParticipantScores = from s in e.ParticipantScores
                select new TeamParticipantScoreDto
                {
                    ParticipantId = s.ParticipantId,
                    Score = ScoreDto.FromEntity(s.Score)
                },
            SportModality = SportModalityDto.FromEntity(e.SportModality),
            SportModalityId = e.SportModalityId
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
                select CreateNormalTeamDto(members, participants, null, t.Id, t.FacultyId),
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
            SportModality = SportModalityDto.FromEntity(e.SportModality),
            SportModalityId = e.SportModalityId
        }));

        return eventDtos.OrderBy(e => e.DateTime);
    }

    public async void PostEvent(CreateEventDto eventDto)
    {
        var location = _repository.Set<Location>().FirstOrDefault(l => l.Id == eventDto.LocationId);
        switch (eventDto.Type)
        {
            case "TeamScored":
                if (eventDto is not CreateTeamEventDto teamEvent)
                    throw new ArgumentException("Invalid event type");

                var teamScoredScore = new Score { NumberScore = 0 };

                var team = new TeamEvent
                {
                    Type = teamEvent.Type,
                    LocationId = teamEvent.LocationId,
                    Location = location,
                    DateTime = teamEvent.DateTime,
                    SportModalityId = teamEvent.SportModalityId,
                    SportModality = _repository.Set<Modality>().FirstOrDefault(m => m.Id == teamEvent.SportModalityId)
                };

                await _repository.Set<Score>().Create(teamScoredScore);
                await _repository.Set<Event>().Create(team);

                team.TeamScores = teamEvent.TeamIds.Select(t => new TeamEventScore
                {
                    EventId = team.Id,
                    Event = team,
                    TeamId = t,
                    Team = _repository.Set<NormalTeam>().FirstOrDefault(n => n.Id == t),
                    ScoreId = teamScoredScore.Id,
                    Score = teamScoredScore
                });
                team.TeamParticipants = teamEvent.TeamParticipantTupleId.Select(p =>
                    CreateEventTeamParticipant(team.Id, p.Item1, p.Item2));
                team.TeamSubstitutes = teamEvent.TeamSubstitutesTupleId.Select(s =>
                    CreateEventTeamSubstitute(team.Id, s.Item1, s.Item2));

                await _repository.Set<TeamEvent>().Create(team);
                break;
            case "Composed":
                if (eventDto is not CreateComposedTeamsEventDto composedTeams)
                    throw new ArgumentException("Invalid event type");

                var composedScore = new Score { NumberScore = 0 };

                await _repository.Set<Score>().Create(composedScore);

                var composedTeamsEvent = new ComposedTeamsEvent
                {
                    Type = composedTeams.Type,
                    LocationId = composedTeams.LocationId,
                    Location = location,
                    DateTime = eventDto.DateTime,
                    ComposedTeams = _repository.Set<ComposedTeam>()
                        .Where(t => composedTeams.ComposedTeamsId.Contains(t.Id)),
                    ComposedTeamScores = composedTeams.CompositionId.Select(c => new TeamCompositionScore
                    {
                        CompositionId = c,
                        Composition = _repository.Set<TeamComposition>().FirstOrDefault(t => t.Id == c),
                        ScoreId = composedScore.Id,
                        Score = composedScore
                    }),
                    SportModalityId = composedTeams.SportModalityId,
                    SportModality = _repository.Set<Modality>()
                        .FirstOrDefault(m => m.Id == composedTeams.SportModalityId)
                };

                await _repository.Set<ComposedTeamsEvent>().Create(composedTeamsEvent);
                break;
            case "ParticipantScored":
                if (eventDto is not CreateParticipantScoredEventDto participantScored)
                    throw new ArgumentException("Invalid event type");

                var participantScoredEvent = new ParticipantScoredEvent
                {
                    Type = participantScored.Type,
                    LocationId = participantScored.LocationId,
                    Location = location,
                    DateTime = eventDto.DateTime,
                    ParticipantScoredTeams = _repository.Set<NormalTeam>()
                        .Where(t => participantScored.ParticipantScoredId.Any(p => p == t.Id)),
                    SportModalityId = participantScored.SportModalityId,
                    SportModality = _repository.Set<Modality>()
                        .FirstOrDefault(m => m.Id == participantScored.SportModalityId)
                };
                await _repository.Set<Event>().Create(participantScoredEvent);

                var teamScore = new Score { NumberScore = 0 };
                await _repository.Set<Score>().Create(teamScore);


                participantScoredEvent.ParticipantScores = participantScored.TeamParticipantTupleId.Select(p =>
                    new TeamParticipantScore
                    {
                        EventId = participantScoredEvent.Id,
                        TeamId = p.Item1,
                        ParticipantId = p.Item2,
                        Participant = _repository.Set<TeamMember>().FirstOrDefault(t => t.Id == p.Item2),
                        ScoreId = teamScore.Id,
                        Score = teamScore
                    });
                participantScoredEvent.TeamSubstitutes = participantScored.TeamSubstitutesTupleId.Select(s =>
                    new ParticipantScoredEventSubstitute
                    {
                        EventId = participantScoredEvent.Id,
                        TeamId = s.Item1,
                        SubstituteId = s.Item2,
                        Substitute = _repository.Set<TeamMember>().FirstOrDefault(t => t.Id == s.Item2)
                    });

                await _repository.Set<ParticipantScoredEvent>().Create(participantScoredEvent);
                break;
            case "MatchEvent":
                if (eventDto is not CreateMatchEventDto matchEvent)
                    throw new ArgumentException("Invalid event type");
                var match = new MatchEvent
                {
                    Type = matchEvent.Type,
                    LocationId = matchEvent.LocationId,
                    Location = location,
                    DateTime = eventDto.DateTime,
                    MatchedTeams = _repository.Set<NormalTeam>()
                        .Where(t => matchEvent.TeamIds.Any(p => p == t.Id)),
                    Matches = _repository.Set<Match>().Where(m => matchEvent.MatchIds.Any(p => p == m.Id)),
                    SportModalityId = matchEvent.SportModalityId,
                    SportModality = _repository.Set<Modality>().FirstOrDefault(m => m.Id == matchEvent.SportModalityId)
                };

                await _repository.Set<MatchEvent>().Create(match);
                break;
        }

        await _repository.Save(default);
    }

    private static NormalTeamDto CreateNormalTeamDto(IEnumerable<TeamMember> members,
        IEnumerable<TeamMember> participants,
        IEnumerable<TeamMember> substitutes,
        int id, int facultyId)
    {
        return new NormalTeamDto
        {
            Id = id,
            FacultyId = facultyId,
            Members = members?.Select(TeamMemberDto.FromEntity),
            Participants = participants?.Select(TeamMemberDto.FromEntity),
            Substitutes = substitutes?.Select(TeamMemberDto.FromEntity)
        };
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