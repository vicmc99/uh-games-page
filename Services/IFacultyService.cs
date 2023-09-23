using Data.DTO;

namespace Services.Domain;

public interface IFacultyService
{

    FacultyDTO Get(int id, int year);

}
