using cube;

namespace Namespace;
public interface IRepositoryService : IRepositoryData<Service>
{
    public List<Service> GetServicesByLocationName(string locationName);
}
