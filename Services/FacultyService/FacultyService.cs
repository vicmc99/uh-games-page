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
        //Get repository data
        var faculties = _repository.Set<Faculty>().ToList();
        var leaderboard = _repository.Set<Leaderboard>().Include(l => l.LeaderboardLines)
            .FirstOrDefault(l => l.Year == DateTime.Now.Year);
        var representative = _repository.Set<Representative>().Include(r => r.Athlete).ToList();

        //Map to DTO
        var facultyDtos = faculties.Select(faculty =>
        {
            var leaderboardLine = leaderboard?.LeaderboardLines.FirstOrDefault(l => l.FacultyId == faculty.Id);
            var goldMedals = leaderboardLine?.GoldMedals ?? 0;
            var silverMedals = leaderboardLine?.SilverMedals ?? 0;
            var bronzeMedals = leaderboardLine?.BronzeMedals ?? 0;
            var ranking = leaderboardLine?.Ranking ?? null;

            var facultyAthletes = representative.Where(a => a.FacultyId == faculty.Id).Select(a => a.Athlete);

            return new FacultyDto
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Mascot = faculty.Mascot,
                Acronym = faculty.Acronym,
                Athletes = facultyAthletes.Select(AthleteDto.FromEntity),
                GoldMedals = goldMedals,
                SilverMedals = silverMedals,
                BronzeMedals = bronzeMedals,
                Ranking = ranking
            };
        });

        return Task.FromResult(facultyDtos.AsEnumerable());
    }

    public Task<(byte[]?, string?)> GetFacultyImage(int id)
    {
        var faculty = _repository.Set<Faculty>().FirstOrDefault(f => f.Id == id);
        return faculty == null
            ? Task.FromResult<(byte[]?, string?)>((null, null))!
            : Task.FromResult<(byte[]?, string?)>((faculty.Logo, faculty.PhotoMimeType));
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
            Ranking = ranking
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
            PhotoMimeType = createFacultyDto.PhotoMimeType
        };
        if (createFacultyDto.Logo != null)
        {
            using var memoryStream = new MemoryStream();
            await createFacultyDto.Logo.CopyToAsync(memoryStream);
            newFaculty.Logo = memoryStream.ToArray();
        }

        if (CheckFaculty(createFacultyDto))
            throw new Exception("The faculty already exists");

        await _repository.Set<Faculty>().Create(newFaculty);
        await _repository.Save(default);

        return newFaculty.Id;
    }

    public async Task UpdateFaculty(int id, CreateFacultyDto updateFacultyDto)
    {
        var faculty = _repository.Set<Faculty>().FirstOrDefault(f => f.Id == id);
        if (faculty == null)
            throw new Exception("The faculty does not exist");

        faculty.Name = updateFacultyDto.Name;
        faculty.Acronym = updateFacultyDto.Acronym;
        faculty.Mascot = updateFacultyDto.Mascot;
        faculty.PhotoMimeType = updateFacultyDto.PhotoMimeType;

        if (updateFacultyDto.Logo != null)
        {
            using var memoryStream = new MemoryStream();
            await updateFacultyDto.Logo.CopyToAsync(memoryStream);
            faculty.Logo = memoryStream.ToArray();
        }

        if (updateFacultyDto.MajorsId != null)
            faculty.Majors = _repository.Set<Major>().Where(m => updateFacultyDto.MajorsId.Contains(m.Id)).ToList();
        if (updateFacultyDto.RepresentativesId != null)
            faculty.Representatives = _repository.Set<Representative>()
                .Where(r => updateFacultyDto.RepresentativesId.Contains(r.Id)).ToList();

        _repository.Set<Faculty>().Update(faculty);
        await _repository.Save(default);
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