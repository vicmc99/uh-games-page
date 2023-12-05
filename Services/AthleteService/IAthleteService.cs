using Data.DTO;
using Data.DTO.In;

namespace Services.Domain;

public interface IAthleteService
{
    public void PostAthlete(CreateAthleteDto createAthleteDto);
}