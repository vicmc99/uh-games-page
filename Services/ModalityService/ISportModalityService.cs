using Data.DTO;
using Data.DTO.In;

namespace Services.Domain;

public interface ISportModalityService
{
    Task<SportModalityDto?> GetSportModality(int id);
    Task<int> PostSportModality(CreateSportModalityDto sportModalityDto);
    Task DeleteSportModality(int id);
    Task UpdateSportModality(int id, CreateSportModalityDto updateSportModalityDto);
}