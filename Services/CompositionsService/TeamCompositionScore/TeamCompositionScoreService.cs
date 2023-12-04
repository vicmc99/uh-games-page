using Data.DTO.In.Compositions;
using Data.Model;
using DataAccess.Repository;
using Services.Domain.CompositionsService.TeamCompositionScore;

namespace Services.CompositionsService.TeamCompositionScore;

public class TeamCompositionScoreService:ITeamCompositionScoreService
{
    private readonly IDataRepository _repository;

    public TeamCompositionScoreService(IDataRepository repository)
    {
        _repository = repository;
    }


    public async void PostTeamCompositionScoreService(CreateTeamCompositionScoreDto createTeamCompositionScoreDto)
    {
        var newTeamCompositonScore = new Data.Model.TeamCompositionScore()
        {
            Composition = _repository.Set<TeamComposition>()
                .FirstOrDefault(e => e.Id == createTeamCompositionScoreDto.CompositionId),
            Score = _repository.Set<Score>()
                .FirstOrDefault(e => e.Id == createTeamCompositionScoreDto.ScoreId)
        };
        await _repository.Set<Data.Model.TeamCompositionScore>().Create(newTeamCompositonScore);
        await _repository.Save(default);
    }
}
