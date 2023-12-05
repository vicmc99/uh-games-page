using Data.DTO.In;
using Data.DTO.Out;

namespace Services.Domain;

public interface IFacultyService
{
    FacultyDto Get(int id, int year);
    bool CheckFaculty(CreateFacultyDto createFacultyDto);
    IEnumerable<FacultyDto> GetAllFaculties(int year);
    void PostFaculty(CreateFacultyDto createFacultyDto);
}