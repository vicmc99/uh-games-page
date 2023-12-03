using Data.DTO.Out;

namespace Services.Domain;

public interface IEventService
{
    IEnumerable<EventDto> Get();
}