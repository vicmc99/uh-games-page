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

    public bool CheckFaculty(CreateFacultyDto createFacultyDto)
    {
        var faculty = _repository.Set<Faculty>().FirstOrDefault(f => f.Name == createFacultyDto.Name);
        return faculty != null;
    }

    public Task<IEnumerable<FacultyDto>> GetAllFaculties(int year)
    {
        var faculties = _repository.Set<Faculty>();
        if (!faculties.Any())
            return Task.FromResult<IEnumerable<FacultyDto>>(Array.Empty<FacultyDto>());

        var leaderboard = _repository.Set<Leaderboard>().FirstOrDefault(l => l.Year == year);

        if (leaderboard is null)
            return Task.FromResult(_repository.Set<Faculty>().Select(f => new FacultyDto
            {
                Id = f.Id,
                Name = f.Name,
                Mascot = f.Mascot,
                Acronym = f.Acronym,
                Athletes = Array.Empty<AthleteDto>(),
                GoldMedals = 0,
                SilverMedals = 0,
                BronzeMedals = 0,
                Ranking = -1,
                Logo = f.Logo
            }).AsEnumerable());

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
            let goldMedals = leaderboardLine != null ? leaderboardLine.GoldMedals : 0
            let silverMedals = leaderboardLine != null ? leaderboardLine.SilverMedals : 0
            let bronzeMedals = leaderboardLine != null ? leaderboardLine.BronzeMedals : 0
            let ranking = leaderboardLine != null ? leaderboardLine.Ranking : -1
            select new FacultyDto
            {
                Id = f.Id,
                Name = f.Name,
                Mascot = f.Mascot,
                Acronym = f.Acronym,
                Athletes = actualAthletes.Select(
                    a => new AthleteDto { Id = a.Athlete.Id, Name = a.Athlete.Name }),
                GoldMedals = goldMedals,
                SilverMedals = silverMedals,
                BronzeMedals = bronzeMedals,
                Ranking = ranking,
                Logo = f.Logo
            };

        return Task.FromResult(facultyDtos.AsEnumerable());
    }

    public Task<FacultyDto?> GetFaculty(int id)
    {
        var faculty = _repository.Set<Faculty>().FirstOrDefault(f => f.Id == id);

        if (faculty is null) return Task.FromResult<FacultyDto?>(null);

        var leaderboardLine =
            _repository.Set<LeaderboardLine>().FirstOrDefault(l => l.FacultyId == id);
        var athletes =
            (from representative in _repository.Set<Representative>()
                join athlete in _repository.Set<Athlete>() on representative.AthleteId equals athlete.Id
                where representative.FacultyId == id
                select athlete).ToList();

        var goldMedals = leaderboardLine?.GoldMedals ?? 0;
        var silverMedals = leaderboardLine?.SilverMedals ?? 0;
        var bronzeMedals = leaderboardLine?.BronzeMedals ?? 0;
        var ranking = leaderboardLine?.Ranking ?? null;

        var facultyDto = new FacultyDto
        {
            Id = faculty.Id,
            Name = faculty.Name,
            Mascot = faculty.Mascot,
            Acronym = faculty.Acronym,
            Athletes = athletes.Select(a => new AthleteDto { Id = a.Id, Name = a.Name }),
            GoldMedals = goldMedals,
            SilverMedals = silverMedals,
            BronzeMedals = bronzeMedals,
            Ranking = ranking,
            Logo = faculty.Logo
        };

        return Task.FromResult<FacultyDto?>(facultyDto);
    }

    public async Task<int> PostFaculty(CreateFacultyDto createFacultyDto)
    {
        var newFaculty = new Faculty
        {
            Acronym = createFacultyDto.Acronym,
            Name = createFacultyDto.Name,
            Mascot = createFacultyDto.Mascot,
            Logo = createFacultyDto.Logo,
            Majors = _repository.Set<Major>().Where(m => createFacultyDto.MajorsId.Contains(m.Id)).ToList(),
            Representatives = _repository.Set<Representative>()
                .Where(r => createFacultyDto.RepresentativesId.Contains(r.Id)).ToList()
        };

        if (CheckFaculty(createFacultyDto))
            throw new Exception("The faculty already exists");

        await _repository.Set<Faculty>().Create(newFaculty);
        await _repository.Save(default);

        return newFaculty.Id;
    }

    public Task UpdateFaculty(int id, CreateFacultyDto updateFacultyDto)
    {
        var faculty = _repository.Set<Faculty>().FirstOrDefault(f => f.Id == id);
        if (faculty == null)
            throw new Exception("The faculty does not exist");

        faculty.Name = updateFacultyDto.Name;
        faculty.Acronym = updateFacultyDto.Acronym;
        faculty.Mascot = updateFacultyDto.Mascot;
        faculty.Logo = updateFacultyDto.Logo;
        faculty.Majors = _repository.Set<Major>().Where(m => updateFacultyDto.MajorsId.Contains(m.Id)).ToList();
        faculty.Representatives = _repository.Set<Representative>()
            .Where(r => updateFacultyDto.RepresentativesId.Contains(r.Id)).ToList();

        _repository.Set<Faculty>().Update(faculty);
        return _repository.Save(default);
    }

    public async Task DeleteFaculty(int id)
    {
        var faculty = _repository.Set<Faculty>().FirstOrDefault(f => f.Id == id);
        if (faculty == null)
            throw new Exception("The faculty does not exist");

        _repository.Set<Faculty>().Remove(faculty);
        await _repository.Save(default);
    }
}