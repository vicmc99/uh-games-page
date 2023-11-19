using Data.DTO;

namespace Services.Domain;

public interface IEventService
{
    EventDto[] Get();
}