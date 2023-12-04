using Data.DTO;
using Data.DTO.In;
using Data.DTO.Out;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
namespace Services.Domain.RepresentativeService;

public class RepresentativeService:IRepresentativeService

{
    private readonly IDataRepository _repository;

    public RepresentativeService(IDataRepository repository)
    {
        _repository = repository;
    }
    public async void PostRepresentative(CreateRepresentativeDto createRepresentativeDto)
    {
        var major = _repository.Set<Major>()
            .FirstOrDefault(e => e.Id == createRepresentativeDto.MajorId);
        
        var newRepresentative = new Representative()
        {
            Athlete = _repository.Set<Athlete>()
                .FirstOrDefault(e=>e.Id==createRepresentativeDto.AthleteId),
            Major =major,
            Faculty = _repository.Set<Faculty>()
                .FirstOrDefault(e=>e.Id==major.FacultyId),
            Year = createRepresentativeDto.Year,
            
        };
        
        await _repository.Set<Representative>().Create(newRepresentative);
        await _repository.Save(default);

    }
}