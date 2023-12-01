using Data.DTO;

namespace Services.Domain;

public interface IEventService
{
    IEnumerable<EventDto> Get();
}