using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.SportService;

public class SportService:ISportService

{
    private readonly IDataRepository _repository;

    public SportService(IDataRepository repository) => this._repository = repository;
    
    public async void PostSport(CreateSportDto createSportDto)
    {
        var sport = CreateSportDto.FromEntity(createSportDto);
        await _repository.Set<Sport>().Create(sport);
        await _repository.Save(default);

    }
}