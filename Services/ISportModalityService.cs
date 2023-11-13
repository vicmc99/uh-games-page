using Data.DTO;

namespace Services.Domain;

public interface ISportModalityService
{
    SportModalityDto Get(int id);
}