using Data.DTO;
using Data.DTO.In;

namespace Services.MajorsService;

public interface IMajorsService
{
    Task<MajorDto?> GetMajor(int id);
    Task<int> PostMajor(CreateMajorDto majorDto);
    Task DeleteMajor(int id);
    Task UpdateMajor(int id, CreateMajorDto majorDto);
}