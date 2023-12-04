using Data.DTO.In;

namespace Services.Domain.RepresentativeService;

public interface IRepresentativeService
{
    void PostRepresentative(CreateRepresentativeDto createRepresentativeDto);
}