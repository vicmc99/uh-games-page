using Data.DTO;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain;

public class FacultyService : IFacultyService
{
    private readonly IDataRepository _repository;

    public FacultyService(IDataRepository repository)
    {
        _repository = repository;
    }

    public FacultyDto Get(int id, int year)
    {
        var faculty = _repository.Set<Faculty>().FirstOrDefault(f => f.Id == id);
        var leaderboardline =
            _repository.Set<LeaderboardLine>().FirstOrDefault(l => l.FacultyId == id && l.Year == year);
        var athletes =
            (from representative in _repository.Set<Representative>()
                join athlete in _repository.Set<Athlete>() on representative.AthleteId equals athlete.Id
                where representative.Year == year
                where representative.FacultyId == id
                select athlete).ToList();

        return new FacultyDto
        {
            Id = faculty.Id,
            Name = faculty.Name,
            Mascot = faculty.Mascot,
            Acronym = faculty.Acronym,
            Athletes = athletes.Select(
                a => new AthleteDto { Id = a.Id, Name = a.Name }),
            GoldMedals = leaderboardline?.GoldMedals,
            SilverMedals = leaderboardline?.SilverMedals,
            BronzeMedals = leaderboardline?.BronzeMedals,
            Ranking = leaderboardline?.Ranking
        };
    }

    public FacultyDto[] GetAllFaculties(int year)
    {
        var faculties = _repository.Set<Faculty>().ToArray();
        if (faculties.Length == 0)
            return Array.Empty<FacultyDto>();
        var leaderboard = _repository.Set<Leaderboard>().FirstOrDefault(l => l.Year == year);
        if (leaderboard is null)
            return Array.Empty<FacultyDto>();
        var leaderboardLines = leaderboard.LeaderboardLines;
        var athletes =
            (from representative in _repository.Set<Representative>()
                join athlete in _repository.Set<Athlete>() on representative.AthleteId equals athlete.Id
                where representative.Year == year
                select new { Athlete = athlete, FacultyId = representative.FacultyId }).ToList();



        var length = faculties.Length;
        var facultyDtos = new FacultyDto[length];


        for (var i = 0; i < length; i++)
        {
            var i1 = i;
            var actualAthletes = athletes.Where(a => a.FacultyId == faculties[i1].Id);
            var actualLeaderBoardLine = leaderboardLines.FirstOrDefault(l => l.FacultyId == faculties[i1].Id);
            facultyDtos[i] = new FacultyDto
            {   
                Id = faculties[i].Id,
                Name = faculties[i].Name,
                Mascot = faculties[i].Mascot,
                Acronym = faculties[i].Acronym,
                Athletes = actualAthletes.Select(
                    a => new AthleteDto { Id = a.Athlete.Id, Name = a.Athlete.Name }),
                GoldMedals = actualLeaderBoardLine?.GoldMedals,
                SilverMedals = actualLeaderBoardLine?.SilverMedals,
                BronzeMedals = actualLeaderBoardLine?.BronzeMedals,
                Ranking = actualLeaderBoardLine?.Ranking
            };
        }

        return facultyDtos;
    }

    public IEnumerable<FacultyDto> GetParticipantFaculties(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}