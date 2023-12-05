using Data.DTO;
using Data.DTO.In;

namespace Services.Domain.AthleteService;

public interface IAthleteService
{
    public void PostAthlete(CreateAthleteDto createAthleteDto);
}