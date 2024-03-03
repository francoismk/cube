namespace Namespace;
public class LocationService
{
    private readonly IRepositoryLocation _locationRepository;

    public LocationService(IRepositoryLocation locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public List<LocationDTO> GetAllWithService()
    {
        var locations = _locationRepository.GetAllWithService();
        return locations.Select(location => new LocationDTO
        {
            LocationId = location.Id,
            LocationName = location.LocationName,
            ServiceName = location.Services.Select(service => service.ServiceName).ToList()
        }).ToList();
    }

    public LocationDTO? GetServiceById(int id)
    {
        var location = _locationRepository.GetById(id);
        if (location == null)
        {
            return null;
        }

        var locationDto = new LocationDTO
        {
            LocationId = location.Id,
            LocationName = location.LocationName,
            ServiceName = location.Services.Select(service => service.ServiceName).ToList()
        };

        return locationDto;
    }

}
