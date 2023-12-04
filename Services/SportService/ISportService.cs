using Data.DTO.In;

namespace Services.Domain.SportService;

public interface ISportService
{
    public void PostSport(CreateSportDto createSportDto);
}