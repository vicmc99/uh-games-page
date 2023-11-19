using Data.DTO;

namespace Services.Domain;

public interface IFacultyService
{
    FacultyDto Get(int id, int year);
    FacultyDto[] GetAllFaculties(int year);
}