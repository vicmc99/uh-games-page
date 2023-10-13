using Data.DTO;

namespace Services.Domain;

public interface IScheduleService
{
    EventDTO[] Get();
}