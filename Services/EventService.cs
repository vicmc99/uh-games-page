using Data.DTO;
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
            Location = LocationToDto(e.Location),
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
                }
        }));

        eventDtos.AddRange(composedEvents.Select(e => new EventDto
        {
            Id = e.Id,
            Type = "Composed",
            DateTime = e.DateTime,
            Location = LocationToDto(e.Location),
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
                                select TeamMemberToDto(participant)
                        }
                },
            CompositionScores = from s in e.ComposedTeamScores
                select new TeamCompositionScoreDto
                {
                    Score = ScoreToDto(s.Score),
                    CompositionId = s.CompositionId
                }
        }));

        eventDtos.AddRange(participantScoredEvents.Select(e => new EventDto
        {
            Id = e.Id,
            Type = "ParticipantScored",
            DateTime = e.DateTime,
            Location = LocationToDto(e.Location),
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
                    Score = ScoreToDto(s.Score)
                }
        }));

        eventDtos.AddRange(matchEvents.Select(e => new EventDto
        {
            Id = e.Id,
            Type = "MatchEvent",
            DateTime = e.DateTime,
            Location = LocationToDto(e.Location),
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
                            Score = ScoreToDto(p.Score)
                        }
                }
        }));

        return eventDtos.OrderBy(e => e.DateTime);
    }

    private static LocationDto LocationToDto(Location l)
    {
        return new LocationDto
        {
            Id = l.Id,
            Address = l.Address,
            GoogleMapsUrl = l.GoogleMapsURL,
            Name = l.Name
        };
    }

    private static ScoreDto ScoreToDto(Score s)
    {
        return new ScoreDto
        {
            Id = s.Id,
            NumberScore = s.NumberScore
        };
    }

    private static TeamMemberDto TeamMemberToDto(TeamMember m)
    {
        return new TeamMemberDto
        {
            Id = m.Id,
            TeamId = m.TeamId,
            Role = m.Role,
            Athlete = new AthleteDto
            {
                Id = m.Athlete.Id,
                Name = m.Athlete.Name,
                Nick = m.Athlete.Nick,
                Photo = m.Athlete.Photo,
                DateOfBirth = m.Athlete.DateOfBirth
            }
        };
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
            Members = members?.Select(TeamMemberToDto),
            Participants = participants?.Select(TeamMemberToDto),
            Substitutes = substitutes?.Select(TeamMemberToDto)
        };
    }
}