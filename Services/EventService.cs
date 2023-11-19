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
                case "Composed":

                    //Fill ComposedTeams param
                    var composedTeams = _repository.Set<ComposedTeam>().Where(ct => ct.Id == events[i].Id).ToArray();
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
                                    Id = participant.Team.Id,
                                    FacultyId = participant.Team.FacultyId
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
                    var compositionScores = _repository.Set<TeamCompositionScore>()
                        .Where(tcs => tcs.CompositionId == events[i].Id).ToArray();
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

                    break;
            }
        }

        var sortedList = eventDtos.ToList();
        sortedList.Sort((x, y) => x.DateTime.CompareTo(y.DateTime));
        return sortedList.ToArray();
    }
}