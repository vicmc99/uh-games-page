using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.ModalityService;

public class ModalityService:IModalityService
{
    private readonly IDataRepository _repository;

    public ModalityService(IDataRepository repository)
    {
        _repository = repository;
    }


    public async void PostModality(CreateModalityDto createModalityDto)
    {
        var modality = new Modality()
        {
            Sex = createModalityDto.Sex,
            Category = _repository.Set<Category>()
                .FirstOrDefault(e => e.Id==createModalityDto.CategoryId),
            Sport = _repository.Set<Sport>()
                .FirstOrDefault(e=>e.Id==createModalityDto.SportId),
            Discipline = _repository.Set<Discipline>()
                .FirstOrDefault(e=>e.Id==createModalityDto.DisciplineId)
            
        };
        await _repository.Set<Modality>().Create(modality);
        await _repository.Save(default);
    }
}