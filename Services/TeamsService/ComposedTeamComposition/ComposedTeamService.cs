using Data.DTO.In.Teams;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.TeamsService.ComposedTeamComposition;

public class ComposedTeamService : IComposedTeamService
{
    private readonly IDataRepository _repository;

    public ComposedTeamService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async void PostComposedTeam(CreateComposedTeamDto createComposedTeamDto)
    {
        var temp = Helper.GetTeam(_repository, createComposedTeamDto);
        var newcComposedTeam = new ComposedTeam
        {
            Faculty = temp.Faculty,
            Name = temp.Name,
            Compositions = _repository.Set<TeamComposition>()
                .Where(e => createComposedTeamDto.Compositions.Contains(e.Id)),
            FacultyId = temp.FacultyId
        };
        await _repository.Set<ComposedTeam>().Create(newcComposedTeam);
        await _repository.Save(default);
    }
}