using Data.DTO.In;
using Data.DTO.Out;

namespace Services.Domain;

public interface IEventService
{
    IEnumerable<EventDto> Get();
    void PostEvent(CreateEventDto eventDto);
}