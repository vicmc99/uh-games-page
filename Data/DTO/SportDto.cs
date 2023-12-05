using Data.Model;

namespace Data.DTO;

public class SportDto
{
    //Todo: Add properties
    public static SportDto FromEntity(Sport sport)
    {
        return new SportDto();
    }
}