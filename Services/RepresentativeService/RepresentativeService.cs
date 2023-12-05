using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.RepresentativeService;

public class RepresentativeService : IRepresentativeService

{
    private readonly IDataRepository _repository;

    public RepresentativeService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async void PostRepresentative(CreateRepresentativeDto createRepresentativeDto)
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
    }
}