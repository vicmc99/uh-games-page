using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.AthleteService;

public class AthleteService : IAthleteService
{
    private readonly IDataRepository _repository;
    
    public AthleteService(IDataRepository repository)
    {
        _repository = repository;
    }


   
    public async void PostAthlete(CreateAthleteDto createAthleteDto)
    {
        var newAthete = new Athlete
        {
            Name = createAthleteDto.Name,
            Nick = createAthleteDto.Nick,
            Photo = createAthleteDto.Photo,
            DateOfBirth = createAthleteDto.DateOfBirth
        };
        await _repository.Set<Athlete>().Create(newAthete);

        //Why are you creating a representative every time you create an Athlete?????

        // var major = _repository.Set<Major>()
        //     .FirstOrDefault(r => r.Id == createAthleteDto.MajorId);
        // var faculty = _repository.Set<Faculty>()
        //     .FirstOrDefault(x => x.Id == major.FacultyId);
        //
        // var newRepresentative = new Representative
        // {
        //     Athlete = newAthete,
        //     Year = createAthleteDto.Year,
        //     Major = major,
        //     Faculty = faculty
        // };
        // await _repository.Set<Representative>().Create(newRepresentative);
        await _repository.Save(default);
    }
}