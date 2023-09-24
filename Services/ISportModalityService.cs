using Data.DTO;

namespace Services.Domain;

public interface ISportModalityService
{
    SportModalityDTO Get(int id);
}