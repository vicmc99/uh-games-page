using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services.Domain.RepresentativeService;

public class RepresentativeService : IRepresentativeService

{
    private readonly IDataRepository _repository;

    public RepresentativeService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> PostRepresentative(CreateRepresentativeDto createRepresentativeDto)
    {
        var newRepresentative = new Representative
        {
            Athlete = _repository.Set<Athlete>()
                .FirstOrDefault(e => e.Id == createRepresentativeDto.AthleteId),
            Major = _repository.Set<Major>()
                .FirstOrDefault(e => e.Id == createRepresentativeDto.MajorId),
            Faculty = _repository.Set<Faculty>()
                .FirstOrDefault(e => e.Id == createRepresentativeDto.FacultyId),
            Year = createRepresentativeDto.Year,
            FacultyId = createRepresentativeDto.FacultyId,
            AthleteId = createRepresentativeDto.AthleteId,
            MajorId = createRepresentativeDto.MajorId
        };

        await _repository.Set<Representative>().Create(newRepresentative);
        await _repository.Save(default);
        return newRepresentative.Id;
    }

    public Task<IEnumerable<RepresentativeDto>> GetRepresentatives(int facultyId)
    {
        var faculty = _repository.Set<Faculty>().FirstOrDefault(e => e.Id == facultyId);
        if (faculty == null)
            return Task.FromException<IEnumerable<RepresentativeDto>>(
                new ArgumentNullException(nameof(facultyId), "Faculty not found"));
        var representatives = _repository.Set<Representative>().Where(e => e.Faculty == faculty);
        return Task.FromResult(representatives.AsEnumerable().Select(RepresentativeDto.FromEntity));
    }

    public async Task UpdateRepresentative(int id, CreateRepresentativeDto updateRepresentativeDto)
    {
        var representative = await _repository.Set<Representative>().FirstOrDefaultAsync(e => e.Id == id);
        if (representative != null)
        {
            representative.AthleteId = updateRepresentativeDto.AthleteId;
            representative.MajorId = updateRepresentativeDto.MajorId;
            representative.FacultyId = updateRepresentativeDto.FacultyId;
            representative.Year = updateRepresentativeDto.Year;
            await _repository.Save(default);
        }
    }

    public Task<RepresentativeDto?> GetRepresentative(int id)
    {
        var representative = _repository.Set<Representative>().FirstOrDefault(e => e.Id == id);
        return representative == null
            ? Task.FromResult<RepresentativeDto?>(null)
            : Task.FromResult<RepresentativeDto?>(RepresentativeDto.FromEntity(representative));
    }

    public Task DeleteRepresentative(int id)
    {
        var representative = _repository.Set<Representative>().FirstOrDefault(e => e.Id == id);
        if (representative == null) return Task.CompletedTask;
        _repository.Set<Representative>().Remove(representative);
        return _repository.Save(default);

    }
}