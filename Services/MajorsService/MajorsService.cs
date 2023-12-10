using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services.MajorsService;

public class MajorsService : IMajorsService
{
    private readonly IDataRepository _repository;

    public MajorsService(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<MajorDto?> GetMajor(int id)
    {
        var major = _repository.Set<Major>()
            .Include(m => m.Faculty)
            .FirstOrDefault(m => m.Id == id);
        if (major == null)
            return Task.FromResult<MajorDto?>(null);
        return Task.FromResult<MajorDto?>(new MajorDto
        {
            Years = major.Years,
            Name = major.Name,
            FacultyId = major.FacultyId
        });
    }

    public async Task<int> PostMajor(CreateMajorDto majorDto)
    {
        var major = new Major
        {
            Faculty = _repository.Set<Faculty>()
                .FirstOrDefault(f => f.Id == majorDto.FacultyId),
            Name = majorDto.Name,
            Years = majorDto.Years
        };

        await _repository.Set<Major>().Create(major);
        await _repository.Save(default);
        return major.Id;
    }

    public Task UpdateMajor(int id, CreateMajorDto majorDto)
    {
        var major = _repository.Set<Major>().FirstOrDefault(m => m.Id == id);
        if (major == null)
            throw new KeyNotFoundException("Major not found");

        major.Name = majorDto.Name;
        major.Years = majorDto.Years;
        major.Faculty = _repository.Set<Faculty>().FirstOrDefault(f => f.Id == majorDto.FacultyId);

        return _repository.Save(default);
    }

    public Task DeleteMajor(int id)
    {
        var major = _repository.Set<Major>().FirstOrDefault(m => m.Id == id);
        if (major == null)
            throw new KeyNotFoundException("Major not found");

        _repository.Set<Major>().Remove(major);
        return _repository.Save(default);
    }
}