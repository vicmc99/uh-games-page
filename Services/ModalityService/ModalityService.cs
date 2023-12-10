using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services.Domain.ModalityService;

public class ModalityService : ISportModalityService
{
    private readonly IDataRepository _repository;

    public ModalityService(IDataRepository repository)
    {
        _repository = repository;
    }


    public Task<SportModalityDto?> GetSportModality(int id)
    {
        var modality = _repository.Set<Modality>().Where(s => s.Id == id).Include(s => s.Sport)
            .Include(s => s.Discipline).Include(s => s.Category).FirstOrDefault();
        if (modality == null)
            return Task.FromResult<SportModalityDto?>(null);
        return Task.FromResult<SportModalityDto?>(SportModalityDto.FromEntity(modality));
    }

    public async Task<int> PostSportModality(CreateSportModalityDto createModalityDto)
    {
        var sport = _repository.Set<Sport>()
            .FirstOrDefault(e => e.Id == createModalityDto.SportId);
        var discipline = _repository.Set<Discipline>()
            .FirstOrDefault(e => e.Id == createModalityDto.DisciplineId);
        var category = _repository.Set<Category>()
            .FirstOrDefault(e => e.Id == createModalityDto.CategoryId);
        var modality = new Modality
        {
            SportId = createModalityDto.SportId,
            Sport = sport,
            DisciplineId = createModalityDto.DisciplineId,
            Discipline = discipline,
            CategoryId = createModalityDto.CategoryId,
            Category = category,
            Sex = createModalityDto.Sex
        };
        await _repository.Set<Modality>().Create(modality);
        await _repository.Save(default);
        return modality.Id;
    }

    public Task DeleteSportModality(int id)
    {
        var modalityRep = _repository.Set<Modality>();
        var modality = modalityRep.FirstOrDefault(a => a.Id == id);
        if (modality == null) return Task.CompletedTask;
        modalityRep.Remove(modality);
        return _repository.Save(default);
    }

    public Task UpdateSportModality(int id, CreateSportModalityDto updateSportModalityDto)
    {
        var modality = _repository.Set<Modality>().FirstOrDefault(m => m.Id == id);
        if (modality == null)
            return Task.CompletedTask;

        var sport = _repository.Set<Sport>()
            .FirstOrDefault(e => e.Id == updateSportModalityDto.SportId);
        var discipline = _repository.Set<Discipline>()
            .FirstOrDefault(e => e.Id == updateSportModalityDto.DisciplineId);
        var category = _repository.Set<Category>()
            .FirstOrDefault(e => e.Id == updateSportModalityDto.CategoryId);

        modality.SportId = updateSportModalityDto.SportId;
        modality.Sport = sport;
        modality.DisciplineId = updateSportModalityDto.DisciplineId;
        modality.Discipline = discipline;
        modality.CategoryId = updateSportModalityDto.CategoryId;
        modality.Category = category;
        modality.Sex = updateSportModalityDto.Sex;

        _repository.Save(default);
        return Task.CompletedTask;
    }
}