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
            .ThenInclude(p => p.Participant);

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
            .ThenInclude(p => p.Participant)
            .ThenInclude(p => p.Athlete)
            .Include(e => e.TeamSubstitutes)
            .ThenInclude(s => s.Participant)
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
                    .Select(p => p.Participant)
                let normalTeamDto = CreateNormalTeamDto(teamMembers, teamParticipants, teamSubstitutes, s.TeamId,
                    s.Team.FacultyId)
                select new TeamScoreDto
                {
                    Team = normalTeamDto, Score = new ScoreDto { Id = s.ScoreId, NumberScore = s.Score.NumberScore }
                }
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
                }
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
                    .Select(s => s.Participant.Participant)
                let teamSubstitutes = e.TeamSubstitutes.Where(s => s.TeamId == t.Id)
                    .Select(s => s.Participant)
                select CreateNormalTeamDto(teamMembers, teamParticipants, teamSubstitutes, t.Id,
                    t.FacultyId),
            ParticipantScores = from s in e.ParticipantScores
                select new TeamParticipantScoreDto
                {
                    ParticipantId = s.ParticipantId,
                    Score = ScoreDto.FromEntity(s.Score)
                }
        }));

        eventDtos.AddRange(matchEvents.Select(e => new EventDto
        {
            Id = e.Id,
            Type = "MatchEvent",
            DateTime = e.DateTime,
            Location = LocationDto.FromEntity(e.Location),
            MatchEventTeams = from t in e.Teams
                let members = t.Members
                let participants =
                    from m in e.Matches
                    from p in m.ParticipantScores
                    where p.TeamId == t.Id
                    select p.Participant.Participant
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
                }
        }));

        return eventDtos.OrderBy(e => e.DateTime);
    }

    public async void PostEvent(CreateEventDto eventDto)
    {
        var location = _repository.Set<Location>().FirstOrDefault(l => l.Id == eventDto.LocationId);
        switch (eventDto.Type)
        {
            case "TeamScored":
                if (eventDto is not CreateTeamEventDto teamScored)
                    throw new ArgumentException("Invalid event type");

                var participantScoredEvent = new ParticipantScoredEvent
                {
                    Type = teamScored.Type,
                    LocationId = teamScored.LocationId,
                    Location = location,
                    DateTime = eventDto.DateTime,
                    ParticipantScoredTeams = _repository.Set<NormalTeam>()
                        .Where(t => teamScored.TeamId.Contains(t.Id))
                };
                await _repository.Set<Event>().Create(participantScoredEvent);

                var teamScore = new Score { NumberScore = 0 };

                break;
            case "Composed":
                if (eventDto is not CreateComposedTeamsEventDto composedTeams)
                    throw new ArgumentException("Invalid event type");

                var composedScore = new Score { NumberScore = 0 };

                await _repository.Set<Score>().Create(composedScore);
                await _repository.Save(default);

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
                    })
                };
                await _repository.Set<Event>().Create(composedTeamsEvent);
                break;
            case "ParticipantScored":
                break;
            case "MatchEvent":
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
}