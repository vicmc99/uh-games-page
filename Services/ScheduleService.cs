using Data.DTO;
using DataAccess.Repository;

namespace Services.Domain;

public class ScheduleService : IScheduleService
{
    private readonly IDataRepository repository;

    public ScheduleService(IDataRepository repository)
    {
        this.repository = repository;
    }

    public EventDTO[] Get()
    {
        return Array.Empty<EventDTO>();
    }
}