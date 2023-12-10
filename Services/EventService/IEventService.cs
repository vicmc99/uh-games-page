using Data.DTO.In;
using Data.DTO.Out;

namespace Services.Domain;

public interface IEventService
{
    Task<IEnumerable<EventDto>> GetAllEvents();
    Task<EventDto?> GetEvent(int id);
    Task<int> PostEvent(CreateEventDto eventDto);

    Task DeleteEvent(int id);
    Task UpdateEvent(int id, CreateEventDto eventDto);
}