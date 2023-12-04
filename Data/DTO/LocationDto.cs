using Data.Model;

namespace Data.DTO;

public class LocationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string GoogleMapsUrl { get; set; }

    public static LocationDto FromEntity(Location location)
    {
        return new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            GoogleMapsUrl = location.GoogleMapsURL
        };
    }
}