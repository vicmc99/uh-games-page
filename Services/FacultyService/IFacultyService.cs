using Data.DTO.In;
using Data.DTO.Out;

namespace Services.Domain;

public interface IFacultyService
{
    Task<FacultyDto?> GetFaculty(int id);
    bool CheckFaculty(CreateFacultyDto createFacultyDto);
    Task<IEnumerable<FacultyDto>> GetAllFaculties();
    Task<int> PostFaculty(CreateFacultyDto createFacultyDto);
    Task UpdateFaculty(int id, CreateFacultyDto updateFacultyDto);
    Task DeleteFaculty(int id);
}