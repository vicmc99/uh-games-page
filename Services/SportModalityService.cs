using Data.DTO;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain;

public class SportModalityService : ISportModalityService
{
    private readonly IDataRepository repository;

    public SportModalityService(IDataRepository repository)
    {
        this.repository = repository;
    }

    public SportModalityDTO Get(int id)
    {
        var modality = repository.Set<Modality>().FirstOrDefault(m => m.Id == id);

        var sport = repository.Set<Sport>().FirstOrDefault(s => s.Id == modality.SportId);

        return new SportModalityDTO
        {
            Id = id,
            Sport = modality.Sport,
            Category = modality.Category,
            Discipline = modality.Discipline,
            Sex = modality.Sex
        };
    }
}