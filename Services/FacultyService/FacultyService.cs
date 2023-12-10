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

    public Task<IEnumerable<FacultyDto>> GetAllFaculties()
    {
        var year = DateTime.Now.Year;
        var faculties = _repository.Set<Faculty>();
        if (!faculties.Any())
            return Task.FromResult<IEnumerable<FacultyDto>>(Array.Empty<FacultyDto>());

        var leaderboard = _repository.Set<Leaderboard>().Include(l => l.LeaderboardLines)
            .FirstOrDefault(l => l.Year == year);

        var leaderboardLines = leaderboard?.LeaderboardLines.ToList();
        if (leaderboardLines == null)
            return Task.FromResult<IEnumerable<FacultyDto>>(Array.Empty<FacultyDto>());
        var representatives = _repository.Set<Representative>()
            .Where(r => r.Year == year)
            .Include(r => r.Athlete);

        return Task.FromResult((from faculty in faculties
            let actualAthletes = representatives.Where(a => a.FacultyId == faculty.Id).Select(r => r.Athlete)
            let leaderboardLine = leaderboardLines.FirstOrDefault(l => l.FacultyId == faculty.Id)
            let goldMedals = leaderboardLine != null ? leaderboardLine.GoldMedals : 0
            let silverMedals = leaderboardLine != null ? leaderboardLine.SilverMedals : 0
            let bronzeMedals = leaderboardLine != null ? leaderboardLine.BronzeMedals : 0
            let ranking = leaderboardLine != null ? leaderboardLine.Ranking : -1
            select new FacultyDto
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Mascot = faculty.Mascot,
                Acronym = faculty.Acronym,
                Athletes = actualAthletes.AsEnumerable().Select(AthleteDto.FromEntity),
                GoldMedals = goldMedals,
                SilverMedals = silverMedals,
                BronzeMedals = bronzeMedals,
                Ranking = ranking,
                Logo = faculty.Logo
            }).AsEnumerable());
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
            Athletes = athletes.Select(AthleteDto.FromEntity),
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
            Logo = createFacultyDto.Logo
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