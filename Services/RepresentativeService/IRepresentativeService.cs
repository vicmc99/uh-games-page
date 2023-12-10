using Data.DTO;
using Data.DTO.In;

namespace Services.Domain.RepresentativeService;

public interface IRepresentativeService
{
    Task<int> PostRepresentative(CreateRepresentativeDto createRepresentativeDto);
    Task<IEnumerable<RepresentativeDto>> GetRepresentatives(int facultyId);
    Task UpdateRepresentative(int id, CreateRepresentativeDto updateRepresentativeDto);
    Task<RepresentativeDto?> GetRepresentative(int id);
    Task DeleteRepresentative(int id);
}