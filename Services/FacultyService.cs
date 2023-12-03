using Data.DTO;
using Data.DTO.In;
using Data.DTO.Out;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

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

        if (faculty is null) return null;

        var leaderboardLine =
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
            GoldMedals = leaderboardLine?.GoldMedals ?? 0,
            SilverMedals = leaderboardLine?.SilverMedals ?? 0,
            BronzeMedals = leaderboardLine?.BronzeMedals ?? 0,
            Ranking = leaderboardLine?.Ranking
        };
    }

    public IEnumerable<FacultyDto> GetAllFaculties(int year)
    {
        var faculties = _repository.Set<Faculty>();
        if (!faculties.Any())
            return Array.Empty<FacultyDto>();

        var leaderboard = _repository.Set<Leaderboard>().FirstOrDefault(l => l.Year == year);

        if (leaderboard is null) return Array.Empty<FacultyDto>();

        var leaderboardLines = leaderboard.LeaderboardLines;

        var athletes = _repository.Set<Representative>()
            .Where(r => r.Year == year)
            .Include(r => r.Athlete)
            .Select(r => new
            {
                r.Athlete, r.FacultyId
            });


        var facultyDtos = from f in faculties
            let actualAthletes = athletes.Where(a => a.FacultyId == f.Id)
            let leaderboardLine = leaderboardLines.FirstOrDefault(l => l.FacultyId == f.Id)
            select new FacultyDto
            {
                Id = f.Id,
                Name = f.Name,
                Mascot = f.Mascot,
                Acronym = f.Acronym,
                Athletes = actualAthletes.Select(
                    a => new AthleteDto { Id = a.Athlete.Id, Name = a.Athlete.Name }),
                GoldMedals = leaderboardLine?.GoldMedals ?? 0,
                SilverMedals = leaderboardLine?.SilverMedals ?? 0,
                BronzeMedals = leaderboardLine?.BronzeMedals ?? 0,
                Ranking = leaderboardLine?.Ranking,
                Logo = f.Logo
            };

        return facultyDtos;
    }

    public async void CreateFaculty(CreateFacultyDto createFacultyDto)
    {
        var newFaculty = new Faculty
        {
            Acronym = createFacultyDto.Acronym,
            Name = createFacultyDto.Name,
            Mascot = createFacultyDto.Mascot,
            Logo = createFacultyDto.Logo
        };

        await _repository.Set<Faculty>().Create(newFaculty);
        await _repository.Save(default);
    }
}