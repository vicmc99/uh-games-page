using Data.DTO.In;

namespace Services.Domain.DisciplineService;

public interface IDisciplineService
{
    public void PostDiscipline(CreateDisciplineDto createDisciplineDto);

}