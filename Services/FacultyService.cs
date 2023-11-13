using Data.DTO;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain;

public class FacultyService : IFacultyService
{
    private readonly IDataRepository repository;

    public FacultyService(IDataRepository repository)
    {
        this.repository = repository;
    }

    public FacultyDto Get(int id, int year)
    {
        var faculty = repository.Set<Faculty>().FirstOrDefault(f => f.Id == id);
        var leaderboardline =
            repository.Set<LeaderboardLine>().FirstOrDefault(l => l.FacultyId == id && l.Year == year);
        var athletes =
            (from representative in repository.Set<Representative>()
                join athlete in repository.Set<Athlete>() on representative.AthleteId equals athlete.Id
                where representative.Year == DateTime.Today.Year
                where representative.FacultyId == id
                select athlete).ToList();

        return new FacultyDto
        {
            Id = faculty.Id,
            Name = faculty.Name,
            Mascot = faculty.Mascot,
            Acronym = faculty.Acronym,
            Athletes = athletes.Select(
                a => new AthleteDto { Id = int.Parse(a.Id), Name = a.Name }),
            GoldMedals = leaderboardline?.GoldMedals,
            SilverMedals = leaderboardline?.SilverMedals,
            BronzeMedals = leaderboardline?.BronzeMedals,
            Ranking = leaderboardline?.Ranking
        };
    }

    public IEnumerable<FacultyDto> GetAllFaculties(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FacultyDto> GetParticipantFaculties(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}