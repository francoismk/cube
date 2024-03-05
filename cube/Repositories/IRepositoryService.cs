using cube;

namespace Namespace;
public interface IRepositoryService : IRepositoryData<Service>
{
    public List<Service> GetServicesByLocationName(string locationName);
    public List<Service> GetServicesByLocationId(int id);

    public Service? GetByIdWithEmployees(int id);
}
