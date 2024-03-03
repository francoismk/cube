namespace cube;

public interface IRepositoryEmployee : IRepositoryData<Employee>
{
    public IEnumerable<Employee> GetAllWithServiceAndLocation();
    public IEnumerable<Employee> GetByServiceName(string serviceName);

    public IEnumerable<Employee> GetByServiceAndLocation(string serviceName, string locationName);
}
