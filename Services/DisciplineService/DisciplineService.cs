using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.DisciplineService;

public class DisciplineService:IDisciplineService
{
    private readonly IDataRepository _repository;

    public DisciplineService(IDataRepository repository)=>_repository = repository;
    
    public void PostDiscipline(CreateDisciplineDto createDisciplineDto)
    {
        var discipline=new Discipline()
        {
            Name = createDisciplineDto.Name,
            Sport=_repository.Set<Sport>()
                .FirstOrDefault(e=>e.Id==createDisciplineDto.SportId)
        }
    }
}