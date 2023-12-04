using Data.DTO;
using Data.DTO.In;

namespace Services.Domain;

public interface ISportModalityService
{
    SportModalityDto Get(int id);
    void Post(CreateSportModalityDto sportModalityDto);
}