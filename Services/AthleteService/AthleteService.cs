using System.Globalization;
using Data.DTO;
using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services.Domain.AthleteService;

public class AthleteService : IAthleteService
{
    private readonly IDataRepository _repository;

    public AthleteService(IDataRepository repository)
    {
        _repository = repository;
    }


    public async Task<int> PostAthlete(CreateAthleteDto createAthleteDto)
    {
        //Create a new athlete using the data from the request
        var newAthlete = new Athlete
        {
            Name = createAthleteDto.Name,
            Nick = createAthleteDto.Nick,
            //Photo = createAthleteDto.Photo,
           // PhotoMimeType = createAthleteDto.PhotoMimeType,
            DateOfBirth = DateOnly.Parse(createAthleteDto.DateOfBirth, new CultureInfo("es"))
        };

        //Save the new athlete to the database
        await _repository.Set<Athlete>().Create(newAthlete);

        //Get the major and faculty from the database
        var major = _repository.Set<Major>()
            .FirstOrDefault(r => r.Id == createAthleteDto.MajorId);
        if (major == null) return -1;
        var faculty = _repository.Set<Faculty>()
            .FirstOrDefault(x => x.Id == major.FacultyId);


        if (faculty == null) return -1;

        //Create a new representative using the data from the request
        var newRepresentative = new Representative
        {
            Athlete = newAthlete,
            Year = createAthleteDto.Year,
            Major = major,
            Faculty = faculty
        };
        await _repository.Set<Representative>().Create(newRepresentative);

        //Save the new changes to the database
        await _repository.Save(default);
        return newAthlete.Id;
    }

    public Task DeleteAthlete(int id)
    {
        var athleteRepo = _repository.Set<Athlete>();
        var athlete = athleteRepo.FirstOrDefault(a => a.Id == id);
        if (athlete == null) return Task.CompletedTask;
        athleteRepo.Remove(athlete);
        return _repository.Save(default);
    }

    public async Task<AthleteDto?> GetAthlete(int id)
    {
        var athlete = await _repository.Set<Athlete>().FirstOrDefaultAsync(a => a.Id == id);
        return athlete == null ? null : AthleteDto.FromEntity(athlete);
    }

    public async Task UpdateAthlete(int id, CreateAthleteDto updateAthleteDto)
    {
        var athlete = await _repository.Set<Athlete>().FirstOrDefaultAsync(a => a.Id == id);
        if (athlete != null)
        {
            athlete.Name = updateAthleteDto.Name;
            athlete.Nick = updateAthleteDto.Nick;
           // athlete.Photo = updateAthleteDto.Photo;
            athlete.DateOfBirth = DateOnly.Parse(updateAthleteDto.DateOfBirth, new CultureInfo("es"));
            await _repository.Save(default);
        }
    }
}