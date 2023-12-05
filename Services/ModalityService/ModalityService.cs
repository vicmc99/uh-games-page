using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.ModalityService;

public class ModalityService : ISportModalityService
{
    private readonly IDataRepository _repository;

    public ModalityService(IDataRepository repository)
    {
        _repository = repository;
    }


    public SportModalityDto Get(int id)
    {
        var sportModality = _repository.Set<Modality>().FirstOrDefault(m => m.Id == id);
        return SportModalityDto.FromEntity(sportModality);
    }

    public async void Post(CreateSportModalityDto createModalityDto)
    {
        var sport = _repository.Set<Sport>()
            .FirstOrDefault(e => e.Id == createModalityDto.SportId);
        var discipline = _repository.Set<Discipline>()
            .FirstOrDefault(e => e.Id == createModalityDto.DisciplineId);
        var category = _repository.Set<Category>()
            .FirstOrDefault(e => e.Id == createModalityDto.CategoryId);
        var modality = new Modality
        {
            SportId = createModalityDto.SportId,
            Sport = sport,
            DisciplineId = createModalityDto.DisciplineId,
            Discipline = discipline,
            CategoryId = createModalityDto.CategoryId,
            Category = category,
            Sex = createModalityDto.Sex
        };
        await _repository.Set<Modality>().Create(modality);
        await _repository.Save(default);
    }
}