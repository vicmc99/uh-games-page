using Data.DTO.In;

namespace Services.MajorsService;

public interface IMajorsService
{
    void Create(CreateMajorDto majorDto);
}