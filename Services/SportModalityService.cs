using Data.DTO;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain;

public class SportModalityService : ISportModalityService
{
    private readonly IDataRepository _repository;

    public SportModalityService(IDataRepository repository)
    {
        _repository = repository;
    }

    public SportModalityDto Get(int id)
    {
        var modality = _repository.Set<Modality>().FirstOrDefault(m => m.Id == id);

        var sport = _repository.Set<Sport>().FirstOrDefault(s => s.Id == modality.SportId);

        return new SportModalityDto
        {
            Id = id,
            Sport = modality.Sport,
            Category = modality.Category,
            Discipline = modality.Discipline,
            Sex = modality.Sex
        };
    }
}