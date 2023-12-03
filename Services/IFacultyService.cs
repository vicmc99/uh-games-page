using Data.DTO.In;
using Data.DTO.Out;

namespace Services.Domain;

public interface IFacultyService
{
    FacultyDto Get(int id, int year);
    IEnumerable<FacultyDto> GetAllFaculties(int year);
    void CreateFaculty(CreateFacultyDto createFacultyDto);
}