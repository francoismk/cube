using cube;

namespace Namespace;
public interface IRepositoryLocation : IRepositoryData<Location>
{
    public IEnumerable<Location> GetAllWithService();
}
