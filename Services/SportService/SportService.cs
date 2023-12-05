using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.SportService;

public class SportService : ISportService

{
    private readonly IDataRepository _repository;

    public SportService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async void PostSport(CreateSportDto createSportDto)
    {
        var sport =
            new Sport
            {
                Name = createSportDto.Name,
                Description = createSportDto.Description,
                Rules = createSportDto.Rules,
                Pictogram = createSportDto.Pictogram,
                Category = _repository.Set<Category>()
                    .FirstOrDefault(e => e.Id == createSportDto.CategoryId),
                CategoryId = createSportDto.CategoryId
            };
        await _repository.Set<Sport>().Create(sport);
        await _repository.Save(default);
    }
}