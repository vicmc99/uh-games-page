using Data.DTO;
using Data.DTO.In;

namespace Services.Domain;

public interface IAthleteService
{
    Task<int> PostAthlete(CreateAthleteDto createAthleteDto);
    Task<AthleteDto?> GetAthlete(int id);
    Task DeleteAthlete(int id);
    Task UpdateAthlete(int id, CreateAthleteDto updateAthleteDto);
}