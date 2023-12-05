using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.MajorsService;

public class MajorsService : IMajorsService
{
    private IDataRepository _repository;

    public MajorsService(IDataRepository repository)
    {
        _repository = repository;
    }
    
    public async void Create(CreateMajorDto majorDto)
    {
        var major = new Major()
        {
            Faculty = _repository.Set<Faculty>()
                .FirstOrDefault(f => f.Id == majorDto.FacultyId),
            Name = majorDto.Name,
            Years = majorDto.Years
        };

        await _repository.Set<Major>().Create(major);
        await _repository.Save(default);
    }
}