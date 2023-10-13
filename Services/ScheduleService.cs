using Data.DTO;
using Data.Model;
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
        
    }
}